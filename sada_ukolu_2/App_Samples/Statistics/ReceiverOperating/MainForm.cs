using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Accord.Statistics;
using Accord.Statistics.Analysis;

using ZedGraph;
using Be.Timvw.Framework.ComponentModel;

using System.Xml.Serialization;

namespace ReceiverOperating
{

    public partial class MainForm : System.Windows.Forms.Form
    {

        private DataTable sourceTable;
        private ReceiverOperatingCharacteristic rocCurve;

        private enum SHOW_ROC_TYPE { Type_I_Separete, Type_II_Cascade }
        private SHOW_ROC_TYPE show_roc_type;

        

        public MainForm()
        {
            InitializeComponent();
            
            dgvSource.AutoGenerateColumns = true;
            dgvPointDetails.AutoGenerateColumns = false;

            show_roc_type = SHOW_ROC_TYPE.Type_II_Cascade;

            CreateCurveGraph(zedGraph1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox_ScriptFilesFolder.Text = @"G:\_M\Set_03\candidates_classif";
        }

        #region Buttons
        private void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            if (sourceTable == null)
            {
                MessageBox.Show("Please load some data before attempting to plot a curve.");
                return;
            }

            Analyse_ROC_Data(clearGraphToolStripMenuItem.Checked);
        }

        #endregion

        //------

        List<FileInfo> list_ScriptFiles = null;
        Dictionary<string, List<FileInfo>> list_ScriptFiles_Folder = null;
       
        private void Load_Script_And_Fill(string script_filename)
        {
            list_ScriptFiles_Folder = DictionarySerializer.LoadScript(script_filename);
            list_ScriptFiles = list_ScriptFiles_Folder["testing_01"];

            listBox_ScriptFiles.DataSource = null;
            listBox_ScriptFiles.DataSource = list_ScriptFiles;
        }

        private void Analyse_ROC_Data(bool bClearGraph = true)
        {
            // Finishes and save any pending changes to the given data
            dgvSource.EndEdit();

            // Creates a matrix from the source data table
            int n = sourceTable.Rows.Count;

            /*
            // !!
            double min = 0.0, max = 0.0;
            for (int i = 0; i < n; i++)
            {
                if ((i == 0) || (min > (double)sourceTable.Rows[i][1]))
                        min = (double)sourceTable.Rows[i][1];
                if ((i == 0) || (max < (double)sourceTable.Rows[i][1]))
                    max = (double)sourceTable.Rows[i][1];
            }
            // !!
            */
            double[] realData = new double[n];
            double[] testData = new double[n];
            for (int i = 0; i < n; i++)
            {
                realData[i] = (double)sourceTable.Rows[i][0];
                testData[i] = (double)sourceTable.Rows[i][1];//-1.0 + ((double)sourceTable.Rows[i][1] - min) * (1.0 - -1.0) / (max - min);   //
            }

            //Array.Reverse(realData);
            //Array.Reverse(testData);

            // Creates the Receiver Operating Curve of the given source
            rocCurve = new ReceiverOperatingCharacteristic(realData, testData);

            // Compute the ROC curve
            if (rbNumPoints.Checked)
                rocCurve.Compute((int)numPoints.Value);
            //rocCurve.ComputeWithoutScore();
            else
                rocCurve.Compute((float)numIncrement.Value);

            // save data
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("roc_graph_data.csv");
                if (rocCurve != null)
                {
                    for (int i = rocCurve.Points.Count - 1; i >= 0; i--)
                        sw.WriteLine(String.Format("{0};{1}", 1 - rocCurve.Points[i].Specificity, rocCurve.Points[i].Sensitivity));
                }
            }
            catch (Exception) { }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            // Update graphs
            CreateCurveGraph(zedGraph1, bClearGraph);

            // Show point details
            dgvPointDetails.DataSource = new SortableBindingList<ReceiverOperatingCharacteristicPoint>(rocCurve.Points);

            // Show area and error
            tbArea.Text = rocCurve.Area.ToString();
            tbError.Text = rocCurve.StandardError.ToString();
        }

        private void Load_ROC_Data(string filename)
        {
            //string filename = openFileDialog.FileName;
            string extension = Path.GetExtension(filename);
            if (extension == ".xls" || extension == ".xlsx")
            {
                ExcelReader db = new ExcelReader(filename, true, false);
                TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

                if (t.ShowDialog(this) == DialogResult.OK)
                {
                    this.sourceTable = db.GetWorksheet(t.Selection);
                    this.dgvSource.DataSource = sourceTable;
                }
            }
            else if (extension == ".xml")
            {
                DataTable dataTableAnalysisSource = new DataTable();
                dataTableAnalysisSource.ReadXml(openFileDialog.FileName);

                this.sourceTable = dataTableAnalysisSource;
                this.dgvSource.DataSource = sourceTable;
            }
            else if (extension == ".csv")
            {
                string c1, c2;
                this.sourceTable = new DataTable();
                this.sourceTable.Columns.Add("F1", System.Type.GetType("System.Double"));
                this.sourceTable.Columns.Add("F2", System.Type.GetType("System.Double"));
                StreamReader sr = new StreamReader(File.OpenRead(filename));
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    this.sourceTable.Rows.Add(Convert.ToDouble(values[0]), Convert.ToDouble(values[1])/*useScoreToolStripMenuItem.Checked ? Convert.ToDouble(values[1]) : Convert.ToDouble(values[2]) == 1 ? 1 : 0*/);
                }
                this.dgvSource.DataSource = sourceTable;
            }
        }

        private void Load_ROC_Data_Set(string folder, string sub_filename, string extension, int nStage, bool noClear = false)
        {
            string fix_type_roc = "";
            /*
            switch (show_roc_type)
            {
                case SHOW_ROC_TYPE.Type_I_Separete:
                    fix_type_roc = "I";
                    break;

                case SHOW_ROC_TYPE.Type_II_Cascade:
                    fix_type_roc = "II";
                    break;

                default:
                    fix_type_roc = "";
                    break;
            }
            */

            for (int i = 0; i < nStage; i++)
            {
                Load_ROC_Data(String.Format("{0}{1}{2}", folder, Path.AltDirectorySeparatorChar, String.Format("{0}{1}{2}", String.Format("{0}_roc{1}", sub_filename, i.ToString("0"), fix_type_roc), ".", extension)));
                Analyse_ROC_Data(noClear == false && i == 0);
            }
        }

        //------


        #region Menus
        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                Load_ROC_Data(openFileDialog.FileName);
        }

        #endregion

        #region Graphs
        
        public void CreateCurveGraph(ZedGraphControl zgc, bool bClearGraph = true)
        {
            GraphPane myPane = zgc.GraphPane;
           
            if (bClearGraph == true)
                myPane.CurveList.Clear();

            // Set the titles and axis labels
            myPane.Title.Text = "Receiver Operating Characteristic Curve";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Tahoma";
            myPane.XAxis.Title.Text = "(1-Specificity)";
            myPane.YAxis.Title.Text = "Sensitivity";

            PointPairList list = new PointPairList();
            if (rocCurve != null)
            {                
                for (int i = 0; i < rocCurve.Points.Count; i++)
                {
                    list.Add(1 - rocCurve.Points[i].Specificity, rocCurve.Points[i].Sensitivity);
                }
            }

            // Hide the legend
            myPane.Legend.IsVisible = false;

            // Add a curve 
            Color cl = Color.Red;
            switch (myPane.CurveList.Count)
            {
                case 0:
                    cl = Color.Red;
                    break;
                case 1:
                    cl = Color.Green;
                    break;
                case 2:
                    cl = Color.Blue;
                    break;
                case 3:
                    cl = Color.Black;
                    break;
                case 4:
                    cl = Color.Magenta;
                    break;
                case 5:
                    cl = Color.Yellow;
                    break;
                default:
                    break;
            }

            LineItem curve = myPane.AddCurve("label", list, cl,SymbolType.None/*SymbolType.Circle*/);
            curve.Line.Width = 2.0F;
            curve.Line.IsAntiAlias = true;
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 7;

            myPane.XAxis.Scale.Max = 1.0;
            myPane.XAxis.Scale.Min = 0.0;

            myPane.YAxis.Scale.Max = 1.0;
            myPane.YAxis.Scale.Min = 0.0;


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Invalidate();
        }

        public void CreateCurveGraph(List<ReceiverOperatingCharacteristic> listRoc)
        {
            GraphPane myPane = zedGraph1.GraphPane;
            myPane.CurveList.Clear();

            foreach (ReceiverOperatingCharacteristic it in listRoc)
            {
                // Set the titles and axis labels
                myPane.Title.Text = "Receiver Operating Characteristic Curve";
                myPane.Title.FontSpec.Size = 24f;
                myPane.Title.FontSpec.Family = "Tahoma";
                myPane.XAxis.Title.Text = "(1-Specificity)";
                myPane.YAxis.Title.Text = "Sensitivity";

                PointPairList list = new PointPairList();
                if (rocCurve != null)
                {
                    for (int i = 0; i < rocCurve.Points.Count; i++)
                    {
                        list.Add(1 - rocCurve.Points[i].Specificity, rocCurve.Points[i].Sensitivity);
                    }
                }

                // Hide the legend
                myPane.Legend.IsVisible = false;

                // Add a curve 
                Color cl = Color.Red;
                switch (myPane.CurveList.Count)
                {
                    case 0:
                        cl = Color.Red;
                        break;
                    case 1:
                        cl = Color.Green;
                        break;
                    case 2:
                        cl = Color.Blue;
                        break;
                    case 3:
                        cl = Color.Black;
                        break;
                    case 4:
                        cl = Color.Magenta;
                        break;
                    case 5:
                        cl = Color.Yellow;
                        break;
                    default:
                        break;
                }

                LineItem curve = myPane.AddCurve("label", list, cl, SymbolType.None/*SymbolType.Circle*/);
                curve.Line.Width = 2.0F;
                curve.Line.IsAntiAlias = true;
                curve.Symbol.Fill = new Fill(Color.White);
                curve.Symbol.Size = 7;

                myPane.XAxis.Scale.Max = 1.0;
                myPane.XAxis.Scale.Min = 0.0;

                myPane.YAxis.Scale.Max = 1.0;
                myPane.YAxis.Scale.Min = 0.0;


                // Calculate the Axis Scale Ranges
                zedGraph1.AxisChange();
                zedGraph1.Invalidate();
            }
        }

        
        #endregion

        private void clearGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearGraphToolStripMenuItem.Checked = !clearGraphToolStripMenuItem.Checked;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void useScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useScoreToolStripMenuItem.Checked = !useScoreToolStripMenuItem.Checked;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox_ScriptFiles_SelectedIndexChanged(object sender, EventArgs e)
        {            
            FileInfo it = (FileInfo)listBox_ScriptFiles.SelectedItem;
            if (it != null)
            {
                Load_ROC_Data_Set(textBox_ScriptFilesFolder.Text, String.Format("{0}_{1}", it.Directory.Name, Path.GetFileNameWithoutExtension(it.FullName)), "csv", (int)numericUpDown_nStage.Value);
                //Load_ROC_Data_Set(textBox_ScriptFilesFolder_2.Text, String.Format("{0}_{1}", it.Directory.Name, Path.GetFileNameWithoutExtension(it.FullName)), "csv", (int)numericUpDown_nStage_2.Value, true);
            }
        }

        private void button_Select_ScriptFilesFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                textBox_ScriptFilesFolder.Text = dlg.SelectedPath;
        }

        private void importScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                Load_Script_And_Fill(dlg.FileName);
                */
            Load_Script_And_Fill(@"D:\_Test\_working\settings\_script_L\script_01_t.xml");
        }

        private void textBox_ScriptFilesFolder_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (checkBox_Mode.Checked)
                    {
                        if (numericUpDown_GreedyIdComb.Value > 0)
                            numericUpDown_GreedyIdComb.Value -= 1;//kdyz zmacknes nahoru a box je cheknutej tak numeric greedy id klesa
                    }
                    else
                    {
                        if (listBox_ScriptFiles.SelectedIndex > 0)
                            listBox_ScriptFiles.SelectedIndex = listBox_ScriptFiles.SelectedIndex - 1;//kdyz zmacknes nauoru a box neni cheknutej tak listbox vybere soubor nad vybranym
                    }
                    break;//kdyz selectnuty item je na 0 nebo value NUD je 0 neprovede se nic pri zmacknuti nahoru

                case Keys.Down:
                    if (checkBox_Mode.Checked)
                    {
                        numericUpDown_GreedyIdComb.Value += 1;//kdyz zmacknes dolu a box je cheknutej tak numeric greedy id roste
                    }
                    else
                    {
                        if (listBox_ScriptFiles.SelectedIndex < list_ScriptFiles.Count - 1)
                            listBox_ScriptFiles.SelectedIndex = listBox_ScriptFiles.SelectedIndex + 1;//kdyz zmacknes dolu a box neni cheknutej tak listbox vybere soubor pod nim
                    }
                    break;//kdyz selectnuty item je na MAX a box neni checked tak se neprovede nic pri zmacknuti dolu


                case Keys.F4:
                    if (show_roc_type == SHOW_ROC_TYPE.Type_I_Separete)
                    {
                        show_roc_type = SHOW_ROC_TYPE.Type_II_Cascade;
                        label_show_roc_type.Text = "II";
                    }
                    else
                        if (show_roc_type == SHOW_ROC_TYPE.Type_II_Cascade)
                        {
                            show_roc_type = SHOW_ROC_TYPE.Type_I_Separete;
                            label_show_roc_type.Text = "I";
                        }

                    listBox_ScriptFiles_SelectedIndexChanged(null, null);
                    break;
            }
        }

        private void button_Select_ScriptFilesFolder_2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                textBox_ScriptFilesFolder_2.Text = dlg.SelectedPath;
        }

        private void numericUpDown_GreedyIdComb_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox_Mode.Checked)
            {
                Load_ROC_Data(String.Format("{0}{1}",
                    String.Format("{0}{1}{2}{3}{4}{5}", textBox_ScriptFilesFolder.Text, Path.AltDirectorySeparatorChar, (int)numericUpDown_GreedyIdComb.Value, Path.AltDirectorySeparatorChar, "_data", Path.AltDirectorySeparatorChar),
                    "svm_00_trs_roc0.csv"));
                Analyse_ROC_Data(true);
                Load_ROC_Data(String.Format("{0}{1}",
                    String.Format("{0}{1}{2}{3}{4}{5}", textBox_ScriptFilesFolder.Text, Path.AltDirectorySeparatorChar, (int)numericUpDown_GreedyIdComb.Value, Path.AltDirectorySeparatorChar, "_data", Path.AltDirectorySeparatorChar),
                    "svm_00_vs_roc0.csv"));
                Analyse_ROC_Data(false);
            }
        }
    }
}