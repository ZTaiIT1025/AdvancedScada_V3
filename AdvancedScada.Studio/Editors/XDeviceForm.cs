using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.Editors
{
    public partial class XDeviceForm : XtraForm
    {


        private readonly Channel ch;
       
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



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDeviceName.Text)
                               || string.IsNullOrWhiteSpace(txtDeviceName.Text))
                    DxErrorProvider1.SetError(txtDeviceName, "The device name is empty");
                else
                {
                    DxErrorProvider1.ClearErrors();
                    if (dv == null)
                    {
                        Device dvNew = new Device();
                        dvNew.DeviceId = ch.Devices.Count + 1;
                        dvNew.SlaveId = (short)txtSlaveId.Value;
                        dvNew.DeviceName = txtDeviceName.Text;
                        dvNew.Description = txtDesp.Text;
                        dvNew.DataBlocks = new List<DataBlock>();

                        if (eventDeviceChanged != null) eventDeviceChanged(dvNew, true);

                    }
                    else
                    {
                        dv.SlaveId = (short)txtSlaveId.Value;
                        dv.DeviceName = txtDeviceName.Text;
                        dv.Description = txtDesp.Text;

                        if (eventDeviceChanged != null) eventDeviceChanged(dv, false);
                    }
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void XUserDeviceForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtChannelName.Text = ch.ChannelName;
                txtChannelID.Text = ch.ChannelId.ToString();

                if (dv != null)
                {
                    this.Text = "Edit Device";
                    txtSlaveId.Value = dv.SlaveId;
                    txtDeviceName.Text = dv.DeviceName;
                    txtDeviceId.Text = $"{dv.DeviceId}";
                    txtDesp.Text = dv.Description;
                }
                else
                {
                    this.Text = "Add Device";
                    txtDeviceId.Text = Convert.ToString(ch.Devices.Count + 1);
                    txtDeviceName.Text = "PLC" + Convert.ToString(ch.Devices.Count + 1);
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}