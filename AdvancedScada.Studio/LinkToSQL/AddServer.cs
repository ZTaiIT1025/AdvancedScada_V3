using System;
using System.Windows.Forms;
using AdvancedScada.Management.SQLManager;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Studio.DriverLinkToSQL
{
    public delegate void EventSQLServerChanged(Server SQ);
    public partial class AddServer : XtraForm
    {
        public EventSQLServerChanged eventSQLServerChanged = null;
        private readonly ServerManager objServerManager;
        private readonly Server SQ;
        public AddServer()
        {
            InitializeComponent();
        }
        public AddServer(ServerManager SManager, Server SQLCurrent = null)
        {
            InitializeComponent();
            SQ = SQLCurrent;
            objServerManager = SManager;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SQ == null)
            {
                var clsSql = new Server();
                clsSql.ServerId = Convert.ToInt32(txtServerId.Value);
                clsSql.ServerName = txtServerName.Text;
                clsSql.UserName = txtUserName.Text;
                clsSql.Passwerd = Convert.ToInt32(txtPasswerd.Text);
                clsSql.Description = txtDescription.Text;
                objServerManager.Add(clsSql);
                if (eventSQLServerChanged != null) eventSQLServerChanged(clsSql);
                DialogResult = DialogResult.OK;

            }
            else
            {
                SQ.ServerId = Convert.ToInt32(txtServerId.Value);
                SQ.ServerName = txtServerName.Text;
                SQ.UserName = txtUserName.Text;
                SQ.Passwerd = Convert.ToInt32(txtPasswerd.Text);
                SQ.Description = txtDescription.Text;
                objServerManager.Update(SQ);
                if (eventSQLServerChanged != null) eventSQLServerChanged(SQ);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XtraSQLAdd_Load(object sender, EventArgs e)
        {
            if (SQ != null)
            {
                Text = "Edit SQL";




            }
            else
            {
                Text = "Add SQL";
                txtServerId.Value = +1;
            }
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
    }
}