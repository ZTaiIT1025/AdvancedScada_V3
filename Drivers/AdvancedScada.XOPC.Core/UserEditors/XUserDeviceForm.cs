using System;
using System.Collections.Generic;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.Editors;

namespace AdvancedScada.XOPC.Core.UserEditors
{
    public partial class XUserDeviceForm : XDeviceForm
    {

        public XUserDeviceForm()
        {
            InitializeComponent();
        }
        public XUserDeviceForm(Channel chParam, Device dvPara = null)
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
                {
                    DxErrorProvider1.SetError(txtDeviceName, "The device name is empty");
                }
                else
                {
                    DxErrorProvider1.ClearErrors();
                    if (dv == null)
                    {
                        var dvNew = new Device();
                        dvNew.DeviceId = ch.Devices.Count + 1;
                        dvNew.SlaveId = (short)txtSlaveId.Value;
                        dvNew.DeviceName = txtDeviceName.Text;
                        dvNew.Description = txtDesp.Text;
                        dvNew.DataBlocks = new List<DataBlock>();
                        var log = new LoggerPLC.LoggerPLC(1, "Device",
                            $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Add to Device ");

                        if (eventDeviceChanged != null) eventDeviceChanged(dvNew, true);

                    }
                    else
                    {
                        dv.SlaveId = (short)txtSlaveId.Value;
                        dv.DeviceName = txtDeviceName.Text;
                        dv.Description = txtDesp.Text;
                        var log = new LoggerPLC.LoggerPLC(1, "Device",
                            $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Update to Device ");

                        if (eventDeviceChanged != null) eventDeviceChanged(dv, false);
                    }
                }
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name, ex.Message);
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
                    Text = "Edit Device";
                    txtSlaveId.Value = dv.SlaveId;
                    txtDeviceName.Text = dv.DeviceName;
                    txtDeviceId.Text = $"{dv.DeviceId}";
                    txtDesp.Text = dv.Description;
                }
                else
                {
                    Text = "Add Device";
                    txtDeviceId.Text = Convert.ToString(ch.Devices.Count + 1);
                    txtDeviceName.Text = "PLC" + Convert.ToString(ch.Devices.Count + 1);
                }
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}
