using System;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using DevExpress.XtraEditors;

namespace AdvancedScada.Studio.Editors
{
    public partial class XTagForm : XtraForm
    {
        private readonly Channel ch;
        private readonly DataBlock db;
        private readonly Device dv;

        public EventTagChanged eventTagChanged = null;
        private readonly Tag tg;
        public XTagForm()
        {
            InitializeComponent();
        }
        public XTagForm(Channel chParam, Device dvParam, DataBlock dbParam, Tag tgParam = null)
        {
            InitializeComponent();
            dv = dvParam;
            db = dbParam;
            ch = chParam;
            tg = tgParam;
        }
        Management.Editors.XTagForm newObject = null;
        public void GetForm(string Path, string classname)
        {
            if (tg == null)
            {
                switch (Path)
                {
                    case "LSIS":
                        newObject = new XLSIS.Core.UserEditors.XUserTagForm(ch, dv, db, null);

                        break;
                    case "Modbus":
                        newObject = new XModbus.Core.UserEditors.XUserTagForm(ch, dv, db, null);
                        break;
                    case "Panasonic":
                        newObject = new XPanasonic.Core.UserEditors.XUserTagForm(ch, dv, db, null);
                        break;
                    case "Siemens":
                        newObject = new XSiemens.Core.UserEditors.XUserTagForm(ch, dv, db, null);
                        break;
                    default:
                        break;
                }

            }

            else
            {
                switch (Path)
                {
                    case "LSIS":
                        newObject = new XLSIS.Core.UserEditors.XUserTagForm(ch, dv, db, tg);

                        break;
                    case "Modbus":
                        newObject = new XModbus.Core.UserEditors.XUserTagForm(ch, dv, db, tg);
                        break;
                    case "Panasonic":
                        newObject = new XPanasonic.Core.UserEditors.XUserTagForm(ch, dv, db, tg);
                        break;
                    case "Siemens":
                        newObject = new XSiemens.Core.UserEditors.XUserTagForm(ch, dv, db, tg);
                        break;
                    default:
                        break;
                }
            }
          
           
            newObject.eventTagChanged += (tg, isNew) =>
            {
                eventTagChanged?.Invoke(tg, isNew);
                DialogResult = DialogResult.OK;
            };


            try
            {

                if (newObject != null)
                {
                    newObject.Dock = DockStyle.Fill;
                    this.Width = newObject.Width + 25;
                    this.Height = newObject.Height + 25;
                    newObject.BringToFront();
                    newObject.Click += NewObject_Click;
                    Controls.Add(newObject);
                    
                }
              
            }
            catch
            {
            }


        }
        private void NewObject_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void XTagForm_Load(object sender, EventArgs e)
        {
            var DriverTypes2 = ch.ChannelTypes;

            if (tg == null)
            {

                GetForm(DriverTypes2, "XUserTagForm");

                Text = ch.ChannelTypes + "   Add Tag";
            }
            else
            {
                GetForm(DriverTypes2, "XUserTagForm");

                Text = ch.ChannelTypes + "   Edit Tag";
            }

        }
        private void TgFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}