using AdvancedScada.DriverBase.Devices;
using System;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XModbus.Core.UserEditors
{
    public partial class XUserTagForm : AdvancedScada.Management.Editors.XTagForm
    {

        public XUserTagForm()
        {
            InitializeComponent();
        }
        public XUserTagForm(Channel chParam, Device dvParam, DataBlock dbParam, Tag tgParam = null)
        {
            InitializeComponent();
            this.dv = dvParam;
            this.db = dbParam;
            this.ch = chParam;
            this.tg = tgParam;
        }
        public string GetIDTag()
        {
            return $"{db.Tags.Count + 1}";
        }
        private void XUserTagForm_Load(object sender, EventArgs e)
        {
            try
            {

                cboxDataType.SelectedItem = $"{this.db.DataType}";
                this.gpDataBlock.Text = this.ch.ChannelName;
                this.txtDeviceName.Text = this.dv.DeviceName;
                this.txtDataBlock.Text = this.db.DataBlockName;
                txtChannelId.Text = ch.ChannelId.ToString();
                txtDeviceId.Text = Convert.ToString(ch.Devices.Count);
                txtDataBlockId.Text = Convert.ToString(db.DataBlockId);

                if (tg == null)
                {

                    this.Text = "Add Tag";
                    txtTagId.Text = GetIDTag();
                }
                else
                {



                    this.Text = "Edit Tag";
                    txtTagId.Text = tg.TagId.ToString();
                    txtAddress.Text = tg.Address;
                    txtAddress.Enabled = true;
                    cboxDataType.SelectedItem = $"{tg.DataType}";
                    txtTagName.Text = tg.TagName;
                    txtDesc.Text = tg.Description;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (tg == null)
                {
                    Tag newTg = new Tag();
                    newTg.ChannelId = int.Parse(txtChannelId.Text);
                    newTg.DeviceId = int.Parse(txtDeviceId.Text);
                    newTg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    newTg.TagId = db.Tags.Count + 1;
                    newTg.TagName = txtTagName.Text;
                    newTg.Address = txtAddress.Text;
                    newTg.Description = txtDesc.Text;
                    newTg.DataType = $"{cboxDataType.SelectedItem}";
                    if (eventTagChanged != null) eventTagChanged(newTg, true);
                }
                else
                {
                    tg.ChannelId = int.Parse(txtChannelId.Text);
                    tg.DeviceId = int.Parse(txtDeviceId.Text);
                    tg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    tg.TagName = txtTagName.Text;
                    tg.Address = txtAddress.Text;
                    tg.Description = txtDesc.Text;
                    tg.DataType = $"{cboxDataType.SelectedItem}";
                    if (eventTagChanged != null) eventTagChanged(tg, false);

                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnClick(e);
         }
    }
}
