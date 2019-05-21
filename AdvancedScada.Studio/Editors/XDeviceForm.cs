using System;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace AdvancedScada.Studio.Editors
{
    public partial class XDeviceForm : XtraForm
    {


        private readonly Channel ch;
        private string DriverTypes;
        private readonly Device dv;
        public EventDeviceChanged eventDeviceChanged = null;

        public XDeviceForm()
        {
            InitializeComponent();
        }
        public XDeviceForm(Channel chParam, Device dvPara = null)
        {
            InitializeComponent();
            ch = chParam;
            dv = dvPara;
        }


        public void GetForm(string Path, string classname)
        {
            var objFunctions = Functions.GetFunctions();
            var context = objFunctions.ParseNamespace($@"\AdvancedScada.{Path}.Core.dll", classname);
            var t = (Type)context;
            Management.Editors.XDeviceForm newObject = null;
            if (dv == null) newObject = (Management.Editors.XDeviceForm)objFunctions.CreateInstance(t, new object[] { ch, dv });
            else newObject = (Management.Editors.XDeviceForm)objFunctions.CreateInstance(t, new object[] { ch, dv });

            newObject.eventDeviceChanged += (dv, isNew) =>
            {
                eventDeviceChanged?.Invoke(dv, isNew);
                DialogResult = DialogResult.OK;
            };


            try
            {

                if (newObject != null)
                {

                    newObject.Dock = DockStyle.Fill;
                    this.Width = newObject.Width;
                    this.Height = newObject.Height;
                    newObject.BringToFront();
                    newObject.Click += NewObject_Click;
                    Controls.Add(newObject);
                    
                }
               
            }
            catch
            {
            }

            newObject.Show();
        }
        private void NewObject_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void XDeviceForm_Load(object sender, EventArgs e)
        {

            DriverTypes = $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\XSelectedDrivers", "DriverTypes", null)}";
            var DriverTypes2 = ch.ChannelTypes.Insert(0, "X");

            if (dv == null)
            {

                GetForm(DriverTypes2, "XUserDeviceForm");

                Text = DriverTypes + "   Add Device";
            }
            else
            {
                GetForm(DriverTypes2, "XUserDeviceForm");

                Text = ch.ChannelTypes + "   Edit Device";
            }


        }

        private void DvFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}