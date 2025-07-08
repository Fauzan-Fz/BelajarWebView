using System.Windows.Forms;
using PuppeteerWebView.Models;

namespace PuppeteerWebView
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        #region Variabel

        public DataSettings DS = new DataSettings();

        #endregion Variabel

        #region Fungsi

        public void Account(string Username, string Password)
        {
            textBox_Username.Text = Username;
            textBox_Password.Text = Password;
        }

        public void GetList(int Start, int End)
        {
            numGetList_Start.Value = Start;
            numGetList_End.Value = End;
        }

        public void GetDetail(int Start, int End)
        {
            numGetDetail_Start.Value = Start;
            numGetDetail_End.Value = End;
        }

        public void NextPage(int Start, int End)
        {
            numNextPage_Start.Value = Start;
            numNextPage_End.Value = End;
        }

        #endregion Fungsi

        private void Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, System.EventArgs e)
        {
            Form form = Application.OpenForms["PuppeteerForm"];
            ((PuppeteerForm)form).DS.Username = textBox_Username.Text;
            ((PuppeteerForm)form).DS.Password = textBox_Password.Text;
            ((PuppeteerForm)form).DS.GetList_Start = (int)numGetList_Start.Value;
            ((PuppeteerForm)form).DS.GetList_End = (int)numGetList_End.Value;
            ((PuppeteerForm)form).DS.GetDetail_Start = (int)numGetDetail_Start.Value;
            ((PuppeteerForm)form).DS.GetDetail_End = (int)numGetDetail_End.Value;
            ((PuppeteerForm)form).DS.NextPage_Start = (int)numNextPage_Start.Value;
            ((PuppeteerForm)form).DS.NextPage_End = (int)numNextPage_End.Value;
            this.Close();
        }
    }
}