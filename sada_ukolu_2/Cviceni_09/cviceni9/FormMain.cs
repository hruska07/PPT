using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace cviceni9
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        ArrayList dataserazena = new ArrayList();
        ArrayList datazcsv = new ArrayList();
        string pathVzor = Application.StartupPath + @"\..\..\..\zadani\vzor_vysledku\";//cesta ke vzoru
        string pathData = Application.StartupPath + @"\..\..\..\data\_results_data\svm_00\";//cesta k datum
        string OrigFileName = "_overview__svm_00_orig.csv";
        string OrigSortedFileName = "_overview__svm_00_sortByAUCvs.csv";

        static bool PorovnaniSouboru(string path1, string path2)
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
                    var line = "";
                    var reader = new StreamReader(path1 + i + @"\_data\roc.csv");
                    line = reader.ReadLine();
                    if (i == 0)
                        datazcsv.Add(line);
                    line = "svm_00;" + reader.ReadLine();
                    datazcsv.Add(line);
                    lb_proces.Text = i.ToString();
                }
                catch (System.Exception)
                {
                    string neneneneneco = "svm_00;svm_" + i.ToString() + ";notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT";
                    datazcsv.Add(neneneneneco);
                    lb_proces.Text = i.ToString() + "xxxxx";
                }

            }
            StreamWriter writer = new StreamWriter(path1 + OrigFileName);
            for (int i = 0; i < datazcsv.Count; i++)
                writer.WriteLine(datazcsv[i]);
            writer.Close();
        }

        void SeradDict(string path1)//nepouziva se
        {
            Dictionary<double, string> dictionary = new Dictionary<double, string>();

            for (int i = 0; i < datazcsv.Count; i++)
            {
                string[] pole = datazcsv[i].ToString().Split(';');
                double cislo = 0.00;
                if (double.TryParse(pole[5], out cislo))
                    dictionary.Add(cislo, datazcsv[i].ToString());
            }
            SortedDictionary<double, string> dictionarySorted = new SortedDictionary<double, string>(dictionary);

            StreamWriter writer = new StreamWriter(path1 + OrigSortedFileName);
            foreach (string it in dictionarySorted.Values)
                writer.WriteLine(it);
            writer.Close();
        }

        void seradNamTo(string path1)
        {
            for (int i = 1; i < datazcsv.Count; i++)
            {
                try
                {
                    string[] pole = datazcsv[i].ToString().Split(';');
                    double cislo = 0.00;
                    if (double.TryParse(pole[5], out cislo))
                    {
                        trideni neco = new trideni();
                        neco.sl_1 = Convert.ToInt32(pole[1]);
                        neco.sl_5 = Convert.ToDouble(pole[5]);
                        neco.radek = datazcsv[i].ToString();
                        dataserazena.Add(neco);
                    }
                    else
                    {
                        string neneneneneco = "svm_00;svm_" + (i - 1).ToString() + ";notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT";
                        trideni neco = new trideni();
                        neco.sl_1 = i - 1;
                        neco.sl_5 = 100;
                        neco.radek = neneneneneco;
                        dataserazena.Add(neco);
                        lb_proces.Text = i.ToString() + "xxxxx";
                    }
                }
                catch (System.Exception) { }
            }
            dataserazena.Sort(new trideni.myComparer());
            StreamWriter writer = new StreamWriter(path1 + OrigSortedFileName);
            writer.WriteLine(datazcsv[0].ToString());
            for (int i = 0; i < dataserazena.Count; i++)
                writer.WriteLine(((trideni)(dataserazena[i])).radek);
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
                if (PorovnaniSouboru(path1, path2))
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

        void Naplnserazeno(string path1, int length = 1764)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    var line = "";
                    var reader = new StreamReader(path1 + i + @"\_data\roc.csv");
                    line = reader.ReadLine();
                    if (i == 0)
                        dataserazena.Add(line);
                    line = "svm_00;" + reader.ReadLine();
                    dataserazena.Add(line);
                    lb_proces.Text = i.ToString();
                }
                catch (System.Exception)
                {
                    string neneneneneco = "svm_00;svm_" + i.ToString() + ";notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT;notT";
                    dataserazena.Add(neneneneneco);
                    lb_proces.Text = i.ToString() + "xxxxx";
                }
            }
            StreamWriter writer = new StreamWriter(path1 + OrigFileName);
            for (int i = 0; i < dataserazena.Count; i++)
                writer.WriteLine(dataserazena[i]);
            writer.Close();
        }
    }

    public class trideni
    {
        public int sl_1; //tady bude 1 spoupec
        public double sl_5;//tady bude 5 sloupec
        public string radek; //tady bude celej zaznam
        public class myComparer : IComparer // podle 5. sloupce  a poté podle 1. sloupce
        {
            int IComparer.Compare(object x, object y)
            {
                trideni p1 = (trideni)x;
                trideni p2 = (trideni)y;
                double sl_61 = p1.sl_5;
                double sl_62 = p2.sl_5;

                int sl_0Compare = sl_61.CompareTo(sl_62);
                if (sl_0Compare != 0) // jestli se 5.sloupce nerovnaji
                {
                    return sl_0Compare * (-1);
                }
                else // porovnani podle 1. sloupce 
                {
                    int sl_01 = p1.sl_1;
                    int sl_02 = p2.sl_1;
                    return sl_01.CompareTo(sl_02);
                }
            }
        } // class myComparer
    } // class trideni
}