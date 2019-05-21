using System;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.Editors;

namespace AdvancedScada.XOPC.Core.UserEditors
{
    public partial class XUserTagForm : XTagForm
    {

        public XUserTagForm()
        {
            InitializeComponent();
        }
        public XUserTagForm(Channel chParam, Device dvParam, DataBlock dbParam, Tag tgParam = null)
        {
            InitializeComponent();
            dv = dvParam;
            db = dbParam;
            ch = chParam;
            tg = tgParam;
        }
        public string GetIDTag()
        {
            return $"{db.Tags.Count + 1}";
        }
        private void XUserTagForm_Load(object sender, EventArgs e)
        {
            try
            {

                cboxDataType.SelectedItem = $"{db.DataType}";
                gpDataBlock.Text = ch.ChannelName;
                txtDeviceName.Text = dv.DeviceName;
                txtDataBlock.Text = db.DataBlockName;
                txtChannelId.Text = ch.ChannelId.ToString();
                txtDeviceId.Text = Convert.ToString(ch.Devices.Count);
                txtDataBlockId.Text = Convert.ToString(db.DataBlockId);

                if (tg == null)
                {

                    Text = "Add Tag";
                    txtTagId.Text = GetIDTag();
                }
                else
                {



                    Text = "Edit Tag";
                    txtTagId.Text = tg.TagId.ToString();
                    txtAddress.Text = tg.Address;
                    txtAddress.Enabled = true;
                    cboxDataType.SelectedItem = $"{tg.DataType}";
                    txtTagName.Text = tg.TagName;
                    txtDesc.Text = tg.Desp;
                }
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name, ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (tg == null)
                {
                    var newTg = new Tag();
                    newTg.ChannelId = int.Parse(txtChannelId.Text);
                    newTg.DeviceId = int.Parse(txtDeviceId.Text);
                    newTg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    newTg.TagId = db.Tags.Count + 1;
                    newTg.TagName = txtTagName.Text;
                    newTg.Address = txtAddress.Text;
                    newTg.Desp = txtDesc.Text;
                    newTg.DataType = $"{cboxDataType.SelectedItem}";
                    var log = new LoggerPLC.LoggerPLC(1, "Tag",
                        $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Add to Tag ");

                    if (eventTagChanged != null) eventTagChanged(newTg, true);
                }
                else
                {
                    tg.ChannelId = int.Parse(txtChannelId.Text);
                    tg.DeviceId = int.Parse(txtDeviceId.Text);
                    tg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    tg.TagName = txtTagName.Text;
                    tg.Address = txtAddress.Text;
                    tg.Desp = txtDesc.Text;
                    tg.DataType = $"{cboxDataType.SelectedItem}";
                    var log = new LoggerPLC.LoggerPLC(1, "Tag",
                        $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Update to Tag ");

                    if (eventTagChanged != null) eventTagChanged(tg, false);

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
