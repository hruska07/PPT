using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace cviceni9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArrayList datazcsv = new ArrayList();
        string pathVzor = Application.StartupPath + @"\..\..\..\zadani\vzor_vysledku\";
        string pathData = Application.StartupPath + @"\..\..\..\data\_results_data\svm_00\";
        string OrigFileName = "_overview__svm_00_orig.csv";
        string OrigSortedFileName = "_overview__svm_00_sortByAUCvs.csv";

        static bool FileEquals(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                    if (file1[i] != file2[i])
                        return false;
                return true;
            }
            return false;
        }

        void Napln(string path1, int length = 1764)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    var line ="";
                    var reader = new StreamReader(path1 + i + @"\_data\roc.csv");
                    line = reader.ReadLine();
                    if (i == 0)
                        datazcsv.Add(line);
                    line = "svm_00;" + reader.ReadLine();
                    datazcsv.Add(line);
                    lb_proces.Text = i.ToString();
                }
                catch (System.Exception )
                {
                    string neneneneneco = "svm_00;svm_"+i.ToString()+";notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT";
                    datazcsv.Add(neneneneneco);
                    lb_proces.Text = i.ToString() + "xxxxx";
                }

            }
            StreamWriter writer = new StreamWriter(path1 + OrigFileName);

            for (int i = 0; i < datazcsv.Count; i++)
                writer.WriteLine(datazcsv[i]);
            writer.Close();
        }

        void seradNamTo(string path1)
        {
            Dictionary<double, string> dictionary = new Dictionary<double, string>();
           
            for (int i = 0; i < datazcsv.Count; i++)
            {
                string[] pole = datazcsv[i].ToString().Split(';');
                double cislo = 0.00;
                if (double.TryParse(pole[5], out cislo))
                {
                    dictionary.Add(cislo, datazcsv[i].ToString());
                }
            }
            SortedDictionary<double, string> dictionarySorted = new SortedDictionary<double, string>(dictionary);

            StreamWriter writer = new StreamWriter(path1 + OrigSortedFileName);

            foreach (string it in dictionarySorted.Values)
                writer.WriteLine(it);
            writer.Close();


        }
        private void bt_START_Click(object sender, System.EventArgs e)
        {
            string path1 = pathVzor + OrigFileName;
            string path2 = pathData + OrigFileName;
            Porovnej(path1, path2);
        }

        private static void Porovnej(string path1, string path2)
        {
            try
            {
                if (FileEquals(path1, path2))
                    MessageBox.Show("Soubory jsou stejne", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Soubory nejsou stejne", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Soubory nejsou stejne nebo není vygenerován", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            string path1 = pathData;
            Napln(path1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path1 = pathData;
            seradNamTo(path1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path1 = pathVzor + OrigSortedFileName;
            string path2 = pathData + OrigSortedFileName;
            Porovnej(path1, path2);
        }
    }
}
