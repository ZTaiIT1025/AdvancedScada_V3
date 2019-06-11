using System;
using System.Threading;
using System.Windows.Forms;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.ImagePicker;
using AdvancedScada.Management.BLManager;
using AdvancedScada.Studio.Config;
using AdvancedScada.Studio.Editors;
using AdvancedScada.Studio.IE;
using AdvancedScada.Studio.Monitor;
using AdvancedScada.Studio.Properties;
using AdvancedScada.Studio.Service;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;

namespace AdvancedScada.Studio
{
   
    public partial class FormStudio
    {
         public bool IsDataChanged;

        private void mExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
            Application.ExitThread();
        }
        private delegate void SetLabelTextInvoker(TextBox label, string Text);

        #region Constoer
        public FormStudio()
        {
          
            InitializeComponent();

            SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem1);
            UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();
        }

        public void InitSkins()
        {
            SkinManager.EnableFormSkins();
            BonusSkins.Register();
        }
        #endregion
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
            if (e.CloseReason == CloseReason.UserClosing) WindowState = FormWindowState.Minimized;

            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();

            var msg = new Message("AdvancedScada");

            alertControl1.Show(this, msg.Caption, msg.Text, string.Empty, msg.Image, msg);


        }
        private void FormS7Studio_Load(object sender, EventArgs e)
        {

          
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", "localhost");
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", "8080");


            XCollection.eventLoggingMessage += ServiceBase_eventChannelCount;
           XCollection.EventscadaException += ServiceBase_eventChannelCount;
            var objChannelManager = ChannelService.GetChannelManager();

            try
            {
                var msg = new Message("AdvancedScada");
                alertControl1.Show(this, msg.Caption, msg.Text, string.Empty, msg.Image, msg);
                Text = "Main Studio 2019 : AdvancedScada";
                barCheckEnabele.Checked = Settings.Default.CheckEnabele;

            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
            var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
            if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
            var chList = objChannelManager.GetChannels(xmlFile);
            if (chList.Count < 1) return;
            //ServiceItem_LinkClicked(null, null);
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
                if (form.GetType() == typeof(PLC_MonitorForm))
                {
                    form.Activate();
                    return;
                }
            var child = new PLC_MonitorForm { Padding = new Padding(0), MdiParent = this };
            child.Show();
            OpenWaitForm();

        }

        private void mConfiguration_ItemClick(object sender, ItemClickEventArgs e)
        {

            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(FormConfiguration))
                {
                    form.Activate();
                    return;
                }
            var child = new FormConfiguration();
            child.Show();
            OpenWaitForm();


        }

       
        #endregion

        #region Click
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
                    ?.DeleteValue("TagManager.Dev", false);
                Settings.Default.CheckEnabele = false;
                Settings.Default.Save();
            }
        }

        private void barButtonLibraryImages_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var frm = new MainView();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File not found", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region BarControl
        public void OpenWaitForm()
        {
            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            for (var i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                Thread.Sleep(25);
                Application.DoEvents();
            }

            //Close Wait Form
            SplashScreenManager.CloseForm(false);
        }
        private void ServiceItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(FormServerUtils))
                {
                    form.Activate();
                    return;
                }
            var child = new FormServerUtils { Padding = new Padding(0), MdiParent = this };
            child.Show();
            

        }

        private void TagManagerItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
                if (form.GetType() == typeof(XTagManager))
                {
                    form.Activate();
                    return;
                }
            var child = new XTagManager { Padding = new Padding(0), MdiParent = this };
            child.Show();


        }

       

       

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            var rs = MessageBox.Show(this, "You sure you want to save?", "MSG_QUESTION", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
            if (rs == DialogResult.Yes) Application.ExitThread();

        }

        private void barItemClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtHistory.Text = string.Empty;
        }
        #endregion
         


        #region AlertControl
        private bool bAlertForm;
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

            Show();
            var msg = new Message("AdvancedScada");
            if (bAlertForm == false)
            {
                alertControl1.Show(this, msg.Caption, msg.Text, string.Empty, msg.Image, msg);
                bAlertForm = true;
            }
            else
            {
                bAlertForm = true;
                return;
            }


            WindowState = FormWindowState.Maximized;
        }

        private void alertControl1_BeforeFormShow(object sender, AlertFormEventArgs e)
        {

            //Make the Alert Window opaque
            e.AlertForm.OpacityLevel = 1;

        }

        private void alertControl1_AlertClick(object sender, AlertClickEventArgs e)
        {
            //Process Alert Window click
            var msg = e.Info.Tag as Message;
            XtraMessageBox.Show(msg.Text, msg.Caption);

        }

        private void FormStudio_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) Hide();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && IsHandleCreated)
                popupMenuNotifyIcon.ShowPopup(MousePosition);
        }
        #endregion
    }
}