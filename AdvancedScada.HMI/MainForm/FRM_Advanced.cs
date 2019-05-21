using AdvancedScada.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdvancedScada.HMI.MainForm
{
    public partial class FRM_Advanced : DevExpress.XtraEditors.XtraForm
    {
        #region Filed
        private SqlConnection con = new SqlConnection("Server=" + Properties.Settings.Default.Server + "; Database=" + Properties.Settings.Default.DataBase + "; Integrated Security=true");
        private SqlCommand cmd;
        public void GetSQLServer()
        {
            var rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server");
            var instances = (string[])rk.GetValue("InstalledInstances");
            if (instances != null)
                if (instances.Length > 0)
                    foreach (var element in instances)
                        if (element == "MSSQLSERVER")
                            cboxServer.Items.Add(Environment.MachineName);
                        else
                            cboxServer.Items.Add(Environment.MachineName + "\\" + element);
        }
        #endregion
        public FRM_Advanced()
        {
            InitializeComponent();
            cboxServer.Text = Properties.Settings.Default.Server;
            txtDateBase.Text = Properties.Settings.Default.DataBase;

        }

        private void FRM_Advanced_Load(object sender, EventArgs e)
        {
            try
            {
                GetSQLServer();
                txt_IP.Text = Properties.Settings.Default.IPAddress;
                txt_Port.Text = Properties.Settings.Default.Port;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = FolderBrowserDialog1.SelectedPath;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text + "\\batchs_DB" + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongTimeString().Replace(':', '-');
            string strQuery = "Backup Database batchs to Disk='" + fileName + ".bak'";
            cmd = new SqlCommand(strQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم انشاء النسخة");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=" + Properties.Settings.Default.Server + "; Database=master; Integrated Security=true");
            SqlCommand cmd = null;

            string strQuery = "ALTER Database batchs SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database batchs From Disk='" + TextBox2.Text + "'";
            cmd = new SqlCommand(strQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم ارجاع النسخة");

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {

                TextBox2.Text = OpenFileDialog1.FileName;

            }


        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "ServerUser", cboxServer.Text);
            Properties.Settings.Default.Server = cboxServer.Text;
            Properties.Settings.Default.DataBase = txtDateBase.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم حفظ الاعدادات");

        }

        private void tsSeve_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = TabPage3;

        }

        private void ts_Res_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = TabPage4;

        }

        private void ts_con_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = TabPage5;
        }

        private void ts_Del_DataBase_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;

        }

        private void btn_Batchs_Details_Click(object sender, EventArgs e)
        {
            SqlDb.DELETE_Batchs();
        }

        private void btn_BatchFinal_Click(object sender, EventArgs e)
        {
            SqlDb.DELETE_BatchFinal();

        }

        private void tsPorts_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage2;

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.IPAddress = txt_IP.Text;
                Properties.Settings.Default.Port = txt_Port.Text;
                Properties.Settings.Default.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ts_Del_DataBase2_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = TabPage7;
        }
    }
}
