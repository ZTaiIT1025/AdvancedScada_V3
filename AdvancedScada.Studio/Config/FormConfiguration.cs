using System;
using System.Data;
using System.Data.Sql;
using System.IO.Ports;
using System.Windows.Forms;
using AdvancedScada.Studio.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.Config
{
    public partial class FormConfiguration
    {
        private string DatabaseTypes = string.Empty;

        public FormConfiguration()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", txtIPAddress.Text);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", txtPort.Text);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "TypeLibrary", cboxLibraryImage.Text);
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "TypeForms", cboxTypeForms.Text);


                Settings.Default.teServer = txtServerName.Text;
                Settings.Default.Port = txtPort.Text;
                Settings.Default.IPAddress = txtIPAddress.Text;
                Settings.Default.DatabaseTypes = DatabaseTypes;
                
                Settings.Default.TypeLibrary = cboxLibraryImage.Text;
                Settings.Default.TypeForms = cboxTypeForms.Text;
                Settings.Default.Save();

                Close();

            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


        }

        public void FillComboServers(ComboBoxEdit Combo)
        {
            var SqlEnumerator = SqlDataSourceEnumerator.Instance;
            var dTable = SqlEnumerator.GetDataSources();
            foreach (DataRow Dr in dTable.Rows) Combo.Properties.Items.Add(Dr[0]);
        }
        public void GetSQLServer()
        {
            var rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server");
            var instances = (string[])rk.GetValue("InstalledInstances");
            if (instances != null)
                if (instances.Length > 0)
                    foreach (var element in instances)
                        if (element == "MSSQLSERVER")
                            txtServerName.Properties.Items.Add(Environment.MachineName);
                        else
                            txtServerName.Properties.Items.Add(Environment.MachineName + "\\" + element);
        }
        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            try
            {



                cboxDatabaseTypes.Text = Settings.Default.DatabaseTypes;

                cboxLibraryImage.Text = Settings.Default.TypeLibrary;



                cboxTypeForms.Text = Settings.Default.TypeForms;

 


                GetSQLServer();

                txtIPAddress.Text = Settings.Default.IPAddress;
                txtPort.Text = Settings.Default.Port;
                txtServerName.Text = Settings.Default.teServer;


                
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }




        private void cboxDatabaseTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseTypes = cboxDatabaseTypes.Text;

        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            Settings.Default.Save();

            Close();
        }
        public   void WriteKey(string keyName, string keyValue)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\HMI");
                regKey.SetValue(keyName, keyValue);
                regKey.Close();
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        private void cboxLibraryImage_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (FBDLibraryImage.ShowDialog() == DialogResult.OK) WriteKey("LibraryImage", FBDLibraryImage.SelectedPath);
            cboxLibraryImage.Text = FBDLibraryImage.SelectedPath;
        }

        private void cboxTypeForms_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (FBDSymbols.ShowDialog() == DialogResult.OK) WriteKey("Symbols", FBDSymbols.SelectedPath);
            cboxTypeForms.Text = FBDSymbols.SelectedPath;
        }
    }
}