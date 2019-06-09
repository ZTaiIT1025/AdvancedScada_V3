using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.DB.SQLite
{
    public partial class SQLiteFormCreate : XtraForm
    {
        public List<string> CreateTable = new List<string>();
        private string strSQL = string.Empty;
        private string strSQLTABLE = string.Empty;
        
        public SQLiteFormCreate()
        {
            InitializeComponent();
        }

        private void btnCreate_database_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtDatabasename.Text == string.Empty) return;
              
                SQLiteConnection.CreateFile(txtDatabasename.Text);
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
                if ( txtDatabasename.Text == string.Empty || txtTableName.Text == string.Empty) return;
                strSQLTABLE = string.Format("@CREATE TABLE IF NOT EXISTS [{0}] (", txtTableName.Text);
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
           
        }

        private void btnCreate_Filed_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtFiledName.Text == string.Empty || ComFiledType.Text == string.Empty || txtTableName.Text == string.Empty) return;

                if (chkKey.Checked)
                {
                    var KEY = string.Format("[{0}]   {1}  NOT NULL PRIMARY KEY AUTOINCREMENT,", txtFiledName.Text, ComFiledType.Text);

                    strSQL += KEY;
                    
                }
                else
                {
                    strSQL += strSQL = string.Format("[{0}]  {1} NULL,", txtFiledName.Text, ComFiledType.Text);
                    
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if ( txtDatabasename.Text == string.Empty || txtFiledName.Text == string.Empty ||
                ComFiledType.Text == string.Empty || txtTableName.Text == string.Empty) return;
            try
            {
                string tempStrg = string.Empty;
                strSQLTABLE += strSQL;
                tempStrg = strSQLTABLE.Substring(1, strSQLTABLE.Length - 2);
                tempStrg +=  ")";
                using (SQLiteConnection conn = new SQLiteConnection("data source =" + newName))
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        conn.Open();
                        cmd.CommandText = tempStrg;
                        cmd.ExecuteNonQuery();

                        

                        
                    }

                }
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
        string newName = string.Empty;


        private void txtDatabasename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
         
            saveFileDialog1.Filter = "SQLite database files (*.db,*.sqlite,*.sqlite3,*.db3)|*.db,*.sqlite,*.sqlite3,*.db3|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                txtDatabasename.Text = saveFileDialog1.FileName;
                  newName =  txtDatabasename.Text;

            }
        }
    }
}