using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using Accord.Statistics.Analysis;


namespace ReceiverOperating
{
    static public class ROC
    {
        public static DataTable LoadData(string filename)
        {
            DataTable sourceTable = null;
            string extension = Path.GetExtension(filename);
            if (extension == ".xls" || extension == ".xlsx")
            {
                ExcelReader db = new ExcelReader(filename, true, false);
                TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

                //if (t.ShowDialog(this) == DialogResult.OK)
                {
                    sourceTable = db.GetWorksheet(t.Selection);
                    //this.dgvSource.DataSource = sourceTable;
                }
            }
            else if (extension == ".xml")
            {
                DataTable dataTableAnalysisSource = new DataTable();
                dataTableAnalysisSource.ReadXml(filename);

                sourceTable = dataTableAnalysisSource;
                //this.dgvSource.DataSource = sourceTable;
            }
            else if (extension == ".csv")
            {
                string c1, c2;
                sourceTable = new DataTable();
                sourceTable.Columns.Add("F1", System.Type.GetType("System.Double"));
                sourceTable.Columns.Add("F2", System.Type.GetType("System.Double"));
                StreamReader sr = new StreamReader(File.OpenRead(filename));
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(';');
                    sourceTable.Rows.Add(Convert.ToDouble(values[0]), Convert.ToDouble(values[1]));
                }
                //this.dgvSource.DataSource = sourceTable;
            }
            return sourceTable;
        }

        public static double CalcData(DataTable sourceTable, bool bNumPoints = false, int numPoints = 5, float numIncrement = (float)0.01)
        {
            ReceiverOperatingCharacteristic rocCurve = null;
            // Creates a matrix from the source data table
            int n = sourceTable.Rows.Count;

            double[] realData = new double[n];
            double[] testData = new double[n];
            for (int i = 0; i < n; i++)
            {
                realData[i] = (double)sourceTable.Rows[i][0];
                testData[i] = (double)sourceTable.Rows[i][1];
            }

            // Creates the Receiver Operating Curve of the given source
            rocCurve = new ReceiverOperatingCharacteristic(realData, testData);
            
            // Compute the ROC curve
            if (bNumPoints)
                rocCurve.Compute(numPoints);
            else
                rocCurve.Compute(numIncrement);

            return rocCurve.Area;
        }

        public static ReceiverOperatingCharacteristic CreateDataRoc(DataTable sourceTable, bool bNumPoints = false, int numPoints = 5, float numIncrement = (float)0.01)
        {
            ReceiverOperatingCharacteristic rocCurve = null;
            // Creates a matrix from the source data table
            int n = sourceTable.Rows.Count;

            double[] realData = new double[n];
            double[] testData = new double[n];
            for (int i = 0; i < n; i++)
            {
                realData[i] = (double)sourceTable.Rows[i][0];
                testData[i] = (double)sourceTable.Rows[i][1];
            }

            // Creates the Receiver Operating Curve of the given source
            rocCurve = new ReceiverOperatingCharacteristic(realData, testData);

            // Compute the ROC curve
            if (bNumPoints)
                rocCurve.Compute(numPoints);
            else
                rocCurve.Compute(numIncrement);

            return rocCurve;
        }

        public static void CalcParamsRoc(float fpr, ReceiverOperatingCharacteristic roc, out double area, out double error)
        {
            area = roc.Area; // ccalculateAreaUnderCurve();
            error = roc.StandardError; // roc.calculateStandardError();
        }

        public static void ShowChart(List<string> roc_files)
        {
            List<ReceiverOperatingCharacteristic> roc = new List<ReceiverOperatingCharacteristic>();
            foreach (string it in roc_files)
                roc.Add(CreateDataRoc(LoadData(it)));
            MainForm f = new MainForm();
            f.CreateCurveGraph(roc);
            f.Show();
        }
    }
}
