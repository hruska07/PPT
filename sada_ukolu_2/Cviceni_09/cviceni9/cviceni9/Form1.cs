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

        private void bt_START_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (FileEquals(@"H:\vspj\5 semestr\PTT\PPT\sada_ukolu_2\Cviceni_09\zadani\vzor_vysledku\_overview__svm_00_orig.csv",
                    @"H:\vspj\5 semestr\PTT\PPT\sada_ukolu_2\Cviceni_09\data\_results_data\svm_00\_overview__svm_00_orig.csv"))
                    MessageBox.Show("Soubory jsou stejne", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Soubory nejsou stejne", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Soubory nejsou stejne nebo není vygenerován", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
