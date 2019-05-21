using System;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using AdvancedScada.Management.BLManager;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace AdvancedScada.Studio.Editors
{
    public partial class XChannelForm : XtraForm
    {
        private readonly Channel ch;
        private string DriverTypes;

        public EventChannelChanged eventChannelChanged = null;
        private readonly ChannelManager objChannelManager;


        public XChannelForm()
        {
            InitializeComponent();
        }
        public XChannelForm(ChannelManager chm = null, Channel chCurrent = null)
        {
            InitializeComponent();
            objChannelManager = chm;
            ch = chCurrent;

        }

       
        public void GetForm(string Path, string classname)
        {
            var objFunctions = Functions.GetFunctions();
            var context = objFunctions.ParseNamespace($@"\AdvancedScada.{Path}.Core.dll", classname);
            var t = (Type)context;
            var ctrl = (Management.Editors.XChannelForm)objFunctions.CreateInstance(t, new object[] { objChannelManager, ch });
            ctrl.eventChannelChanged += (ch, isNew) =>
            {
                eventChannelChanged?.Invoke(ch, isNew);
                DialogResult = DialogResult.OK;
            };
            try
            {
                if (ctrl != null)
                {
                    ctrl.Dock = DockStyle.Fill;
                    this.Width = ctrl.Width+25;
                    this.Height = ctrl.Height+25;
                    ctrl.BringToFront();
                    ctrl.Click += Ctrl_Click;
                   
                    Controls.Add(ctrl);
                    
                }
                
            }
            catch
            {
            }
           
        }

        private void Ctrl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XChannelForm_Load(object sender, EventArgs e)
        {

            DriverTypes =
                $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "ChannelTypes", null)}".Insert(0, "X");
            if (ch == null)
            {
                GetForm(DriverTypes, "XUserChannelForm");
                Text = DriverTypes + "   Add Channel";
            }
            else
            {
                var DriverTypes2 = ch.ChannelTypes.Insert(0, "X");
                GetForm(DriverTypes2, "XUserChannelForm");
                Text = ch.ChannelTypes + "   Edit Channel";
            }



        }

       
    }
}