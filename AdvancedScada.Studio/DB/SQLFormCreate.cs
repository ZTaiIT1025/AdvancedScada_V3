using AdvancedScada.Utils.Databases;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.DB
{
    public partial class SQLFormCreate : XtraForm
    {
        public List<string> CreateTable = new List<string>();
        private string strSQL = string.Empty;
        private string strSQLTABLE = string.Empty;

        public SQLFormCreate()
        {
            InitializeComponent();
        }

        private void btnCreate_database_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComServerName.Text == string.Empty || txtDatabasename.Text == string.Empty) return;
                ClassSQL.CREATE_DATABASE(ComServerName.Text, txtDatabasename.Text);
                MessageBox.Show("تم بنجاح انشاء قاعدة البيانات", "معلومة", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCreate_Table_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComServerName.Text == string.Empty || txtDatabasename.Text == string.Empty || txtTableName.Text == string.Empty) return;
                strSQLTABLE = string.Format("CREATE TABLE {0} (", txtTableName.Text);
                MessageBox.Show("تم بنجاح انشاء قاعدة البيانات", "معلومة", MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void FormCreate_database_Load(object sender, EventArgs e)
        {
            try
            {
                var rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server");
                var instances = (string[])rk.GetValue("InstalledInstances");
                if (instances == null) return;
                if (instances.Length > 0)
                    foreach (var element in instances)
                        if (element == "MSSQLSERVER")
                            ComServerName.Properties.Items.Add(Environment.MachineName);
                        else
                            ComServerName.Properties.Items.Add(Environment.MachineName + "\\" + element);
                ComFiledType.Properties.Items.AddRange(Enum.GetNames(typeof(SqlDbType)));
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }

        private void btnCreate_Filed_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFiledName.Text == string.Empty || ComFiledType.Text == string.Empty || txtTableName.Text == string.Empty) return;

                if (chkKey.Checked)
                {
                    var KEY = string.Format("CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ({0}),", txtFiledName.Text);
                    strSQL += strSQL = string.Format("{0} {1} NOT NULL,", txtFiledName.Text, ComFiledType.Text);
                    strSQL += KEY;
                }
                else
                {
                    strSQL += strSQL = string.Format("{0} {1} NULL,", txtFiledName.Text, ComFiledType.Text);
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (ComServerName.Text == string.Empty || txtDatabasename.Text == string.Empty || txtFiledName.Text == string.Empty ||
                ComFiledType.Text == string.Empty || txtTableName.Text == string.Empty) return;
            try
            {
                strSQLTABLE += strSQL + ")";
                ClassSQL.CREATE_TABLE(ComServerName.Text, txtDatabasename.Text, strSQLTABLE);
                MessageBox.Show("تم بنجاح انشاء الجدول", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFiledName.Text = string.Empty;
                ComFiledType.Text = string.Empty;
                txtTableName.Text = string.Empty;
                chkKey.Checked = false;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }
}