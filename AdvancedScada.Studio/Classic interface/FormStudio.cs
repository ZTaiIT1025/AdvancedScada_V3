using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;
using System.ServiceModel;
using DevExpress.XtraEditors;
using System.Drawing;
using AdvancedScada.Utils;
using AdvancedScada.Studio.Properties;
using AdvancedScada.Studio.Monitor;
using AdvancedScada.Studio.Config;
using AdvancedScada.Studio.Service;
using AdvancedScada.Studio.IE;
using AdvancedScada.Studio.Editors;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Studio.DB;
using AdvancedScada.Studio.DB.SQLite;
using AdvancedScada.Studio.Logging;
using AdvancedScada.Studio.DriverLinkToSQL;

namespace TagManagerLibrary.Studio
{
    public partial class FormStudio
    {
       
        private delegate void SetLabelTextInvoker(TextBox label, string Text);
        
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            Message msg = new Message();

            alertControl1.Show(this, msg.Caption, msg.Text, "", msg.Image, msg);


            WindowState = FormWindowState.Maximized;
        }

        #region Constoer
      
        public FormStudio()
        {
           
             InitSkins();
            InitializeComponent();
           
        }

        public void InitSkins()
        {
            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
        }

        #endregion

        private void mExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
        }
        #region Form
        public static void SetLabelText(TextBox Label, string Text)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new SetLabelTextInvoker(SetLabelText), Label, Text);
            else
                Label.Text += Text;
            Application.DoEvents();
        }
        private void FormStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
              //  e.Cancel = true;
                base.WindowState = FormWindowState.Minimized;
            }
            
               
           
            Message msg = new Message();

            alertControl1.Show(this, msg.Caption, msg.Text, "", msg.Image, msg);


          

        }
        private readonly IniClass inicls = new IniClass();
        private void FormS7Studio_Load(object sender, EventArgs e)
        {
          
            Left = SystemInformation.WorkingArea.Size.Width - Size.Width;
            Top = SystemInformation.WorkingArea.Size.Height - Size.Height;

            XCollection.eventLoggingMessage += ServiceBase_eventChannelCount;
            XCollection.EventscadaException += ServiceBase_eventChannelCount;
            ServiceItem_LinkClicked(null, null);
            try
            {
                Message msg = new Message();
              
                alertControl1.Show(this, msg.Caption, msg.Text, "", msg.Image, msg);


                this.Text = "Main Studio 2018 : " + "Siemens S7";


                barCheckEnabele.Checked = Settings.Default.CheckEnabele;

            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
        }
        private void ServiceBase_eventChannelCount(string message)
        {
            txtHistory.Text += string.Format("{0}" + Environment.NewLine, message);
        }
        private void ServiceBase_eventChannelCount(string classname, string erorr)
        {
            txtHistory.Text += string.Format("{0} : {1}" + Environment.NewLine, classname, erorr);
        }
        private void mMonioring_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(PLC_MonitorForm))
                {
                    form.Activate();
                    return;
                }
            }
            PLC_MonitorForm child = new PLC_MonitorForm() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();

        }

        private void mConfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormConfiguration))
                {
                    form.Activate();
                    return;
                }
            }
            FormConfiguration child = new FormConfiguration() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();


        }

        private void mSQLServerUtils_ItemClick(object sender, ItemClickEventArgs e)
        {

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormSQLServerUtils))
                {
                    form.Activate();
                    return;
                }
            }
            FormSQLServerUtils child = new FormSQLServerUtils() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();

        }

        #endregion

        #region Click

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Environment.Exit(0);
        }







        private void barCheckEnabele_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Settings.Default.CheckEnabele == false)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "TagManager.Dev",
                    Application.ExecutablePath);
                Settings.Default.CheckEnabele = true;
                Settings.Default.Save();
            }
            else
            {
                Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true)
                    .DeleteValue("TagManager.Dev", false);
                Settings.Default.CheckEnabele = false;
                Settings.Default.Save();
            }
        }

        private void barButtonLibraryImages_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //var frm = new frmSymbolsList();
                //frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File not found", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonCreateDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #endregion

        #region BarControl
        private void barSQLite_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new SQLiteFormCreate();
            frm.Show();
        }

        private void barSQL_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new SQLFormCreate();
            frm.Show();
        }


        public void OpenWaitForm()
        {
            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            for (var i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                Application.DoEvents();
                Thread.Sleep(10);

            }

            //Close Wait Form
            SplashScreenManager.CloseForm(false);
        }
        private void ServiceItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormServerUtils))
                {
                    form.Activate();
                    return;
                }
            }
            FormServerUtils child = new FormServerUtils() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }

        private void TagManagerItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(XTagManager))
                {
                    form.Activate();
                    return;
                }
            }
            XTagManager child = new XTagManager() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();

        }

        private void LoggingItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(XtraFormLogging))
                {
                    form.Activate();
                    return;
                }
            }
            XtraFormLogging child = new XtraFormLogging() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }

        private void SQLManagerItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SQLMaster))
                {
                    form.Activate();
                    return;
                }
            }
            SQLMaster child = new SQLMaster() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rs = MessageBox.Show(this, "You sure you want to save?", "QUESTION", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            
            if (rs == DialogResult.Yes) Application.ExitThread();

        }

        private void barItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtHistory.Text = string.Empty;
        }

        private void mAddNew_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void SQLItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SQLFormCreate))
                {
                    form.Activate();
                    return;
                }
            }
            SQLFormCreate child = new SQLFormCreate() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }

        private void SQLiteItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SQLiteFormCreate))
                {
                    form.Activate();
                    return;
                }
            }
            SQLiteFormCreate child = new SQLiteFormCreate() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }

        private void mPCControllercs_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormPCControllercs))
                {
                    form.Activate();
                    return;
                }
            }
            FormPCControllercs child = new FormPCControllercs();
            child.Show();
            // OpenWaitForm();
        }

        private void barCheckEnabele_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }
       

        private void navFrameMonitor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormFrameMonitor))
                {
                    form.Activate();
                    return;
                }
            }
            FormFrameMonitor child = new FormFrameMonitor() { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();
        }
        #endregion
        #region Commands


        private void mRestart_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart(); Application.ExitThread(); Environment.Exit(0);
        }

        private void mStart_ItemClick(object sender, ItemClickEventArgs e)
        {
            //  MainForm frm = new MainForm();
            FormServerUtils form = Application.OpenForms["FormServerUtils"] as FormServerUtils;
            if (form != null)
                form.Focus();
            if (form.close == true)
            {
                //IGetServiceBase iServiceDriver = Functions.GetAssemblyService(@"\Service\BaseService.dll", "BaseService.ServiceBase");
                //form.host = iServiceDriver.GetServiceHostHttp("Modbus");
                //form.host.Opened += form.host_Opened;
                //form.host.Open();
               
                //form.close = false;
            }


            if (form.host.State == CommunicationState.Opened)
            {
                mStart.Enabled = false;
                mStop.Enabled = true;
                form.txtStatus.Caption = "The Server is  running";
            }
            foreach (var se in form.host.Description.Endpoints)
            {
                //var SUGrid = new ServerUtilsGrid();
                //SUGrid.ColTIME = Convert.ToString(DateTime.Now);
                //SUGrid.ColMESSAGE = se.Address.ToString();
                //form._ServerUtilsGrid.Add(SUGrid);
            }

            form.GridControl1.DataSource = form._ServerUtilsGrid;
        }

        private void mStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            { //  MainForm frm = new MainForm();
                FormServerUtils form = Application.OpenForms["FormServerUtils"] as FormServerUtils;
                if (form != null)
                    form.Focus();

                form.host.Close();
                form.close = true;

                if (form.host.State != CommunicationState.Opened)
                {
                    mStart.Enabled = true; mStop.Enabled = false;
                    form.txtStatus.Caption = "The Server is Not running";
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (CommunicationException ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

                
            }
        }

        private void mPause_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void mResume_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        #endregion

        

        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            //Make the Alert Window opaque
            e.AlertForm.OpacityLevel = 1;

        }

        private void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            //Process Alert Window click
            Message msg = e.Info.Tag as Message;
            XtraMessageBox.Show(msg.Text, msg.Caption);

        }

        private void FormStudio_Resize(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Hide();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && IsHandleCreated)
               popupMenuNotifyIcon.ShowPopup(MousePosition);
            
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }
    }
    public class Message
    {
        public Message()
        {
            this.Caption = "سكادا";
            this.Text = "عبدالله الصاوى" + Environment.NewLine + "Siemens S7";
            Image = AdvancedScada.Studio.Properties.Resources.TagManager;
        }
        public string Caption { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }
    }

}