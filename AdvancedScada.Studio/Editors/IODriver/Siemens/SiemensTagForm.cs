using AdvancedScada.DriverBase.Devices;
using System;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace XSiemens.Core.UserEditors
{
    public partial class XUserTagForm : AdvancedScada.Management.Editors.XTagForm
    {
        private int TagsCount = 1;

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
            return string.Format("{0}", db.Tags.Count + 1);
        }
        private void XUserTagForm_Load(object sender, EventArgs e)
        {
            try
            {

                cboxDataType.SelectedItem = string.Format("{0}", this.db.DataType);
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
                    layoutStartAddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    cboxDataType.SelectedItem = string.Format("{0}", tg.DataType);
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
                foreach (var item in dv.DataBlocks)
                {

                    TagsCount += item.Tags.Count;
                    if (db != null)
                    {
                        if (db.DataBlockName.Equals(item.DataBlockName)) break;
                    }

                }
                if (tg == null)
                {
                    Tag newTg = new Tag();
                    newTg.ChannelId = int.Parse(txtChannelId.Text);
                    newTg.DeviceId = int.Parse(txtDeviceId.Text);
                    newTg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    newTg.TagId = db.Tags.Count + 1;
                    newTg.TagName = $"TAG{TagsCount:d5}";


                    newTg.Address = string.Format("{0}{1}", txtAddress.Text, txtStartAddress.Text);

                    newTg.Description = txtDesc.Text;

                    newTg.DataType = string.Format("{0}", cboxDataType.SelectedItem);

                    if (eventTagChanged != null) eventTagChanged(newTg, true);
                    txtTagId.Text = GetIDTag();

                }
                else
                {
                    tg.ChannelId = int.Parse(txtChannelId.Text);
                    tg.DeviceId = int.Parse(txtDeviceId.Text);
                    tg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    tg.TagName = txtTagName.Text;

                    tg.Address = txtAddress.Text;

                    tg.Description = txtDesc.Text;

                    tg.DataType = string.Format("{0}", cboxDataType.SelectedItem);

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

        private void cboxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tg == null)
            {
                switch (cboxDataType.SelectedIndex)
                {
                    case 0:
                        txtAddress.Text = string.Format("DB{0}.DBX", db.StartAddress);
                        break;
                    case 1:
                        txtAddress.Text = string.Empty;
                        break;
                    case 2:
                        txtAddress.Text = string.Format("DB{0}.DBW", db.StartAddress);
                        break;
                    case 3:
                        txtAddress.Text = string.Empty;
                        break;
                    case 4:
                        txtAddress.Text = string.Format("DB{0}.DBW", db.StartAddress);
                        break;
                    case 5:
                        txtAddress.Text = string.Format("DB{0}.DBD", db.StartAddress);
                        break;
                    case 6:
                        txtAddress.Text = string.Format("DB{0}.DBD", db.StartAddress);
                        break;
                    case 7:
                        txtAddress.Text = string.Format("DB{0}.DBB", db.StartAddress);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
