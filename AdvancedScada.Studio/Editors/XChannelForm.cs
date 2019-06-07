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
        private string _DriverTypes;

        public EventChannelChanged eventChannelChanged = null;
        private readonly ChannelService objChannelManager;


        public XChannelForm()
        {
            InitializeComponent();
        }
        public XChannelForm(string DriverTypes,  ChannelService chm = null, Channel chCurrent = null)
        {
            InitializeComponent();
            objChannelManager = chm;
            ch = chCurrent;
            _DriverTypes = DriverTypes;

        }

        Management.Editors.XChannelForm ctrl = null;
        public void GetForm(string Path, string classname)
        {
            switch (_DriverTypes )
            {
                case "LSIS":
                    ctrl = new XLSIS.Core.UserEditors.XUserChannelForm(objChannelManager, ch);
                 
                    break;
                case "Modbus":
                    ctrl = new XModbus.Core.UserEditors.XUserChannelForm(objChannelManager, ch);
                    break;
                case "Panasonic":
                    ctrl = new XPanasonic.Core.UserEditors.XUserChannelForm(objChannelManager, ch);
                    break;
                case "Siemens":
                    ctrl = new XSiemens.Core.UserEditors.XUserChannelForm(objChannelManager, ch);
                    break;
                default:
                    break;
            }

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
                    this.Width = ctrl.Width + 25;
                    this.Height = ctrl.Height + 25;
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

            
            if (ch == null)
            {
                GetForm(_DriverTypes, "XUserChannelForm");
                Text = _DriverTypes + "   Add Channel";
            }
            else
            {
               
                GetForm(_DriverTypes, "XUserChannelForm");
                Text = ch.ChannelTypes + "   Edit Channel";
            }



        }

       
    }
}