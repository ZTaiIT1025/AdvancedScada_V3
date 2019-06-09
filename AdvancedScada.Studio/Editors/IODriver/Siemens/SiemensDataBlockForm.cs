using static AdvancedScada.IBaseService.Common.XCollection;
using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XSiemens.Core.UserEditors
{
    public partial class XUserDataBlockForm : AdvancedScada.Management.Editors.XDataBlockForm
    {

        public XUserDataBlockForm()
        {
            InitializeComponent();
        }
        public XUserDataBlockForm(Channel chParam, Device dvParam, DataBlock dbParam = null)
        {
            InitializeComponent();

            ch = chParam;
            dv = dvParam;
            db = dbParam;


        }

        private void XUserDataBlockForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtDeviceName.Text = dv.DeviceName;
                txtChannelName.Text = ch.ChannelName;
                txtChannelId.Text = ch.ChannelId.ToString();
                txtDeviceId.Text = dv.DeviceId.ToString();

                if (db == null)
                {
                    Text = "Add DataBlock";
                    txtDataBlockId.Text = Convert.ToString(dv.DataBlocks.Count + 1);
                    txtDataBlock.Text = "DataBlock" + Convert.ToString(dv.DataBlocks.Count + 1);

                }
                else
                {
                    Text = "Edit DataBlock";
                    txtChannelId.Text = db.ChannelId.ToString();
                    txtDeviceId.Text = db.DeviceId.ToString();
                    txtDataBlock.Text = db.DataBlockName;
                    txtDBNumber.Value = db.StartAddress;

                    txtDesc.Text = db.Description;
                    txtDataBlockId.Text = string.Format("{0}", db.DataBlockId);

                    cboxDataType.SelectedText = string.Format("{0}", db.DataType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtDataBlock.Text)
                    || string.IsNullOrWhiteSpace(txtDataBlock.Text))
                {
                    DxErrorProvider1.SetError(txtDataBlock, "The datablock is empty");
                }
                else
                {


                    if (db == null)
                    {
                        var dbNew = new DataBlock()
                        {
                            ChannelId = ch.ChannelId,
                            DeviceId = dv.DeviceId,
                            DataBlockId = dv.DataBlocks.Count + 1,
                            DataBlockName = txtDataBlock.Text,
                            StartAddress = (ushort)txtDBNumber.Value,
                            Description = txtDesc.Text,
                            DataType = string.Format("{0}", cboxDataType.SelectedItem),

                            Tags = new List<Tag>()
                        };


                        if (eventDataBlockChanged != null) eventDataBlockChanged(dbNew, true);
                    }
                    else
                    {
                        db.ChannelId = db.ChannelId;
                        db.DeviceId = db.DeviceId;
                        db.DataBlockId = int.Parse(txtDataBlockId.Text);
                        db.DataBlockName = txtDataBlock.Text;
                        db.StartAddress = (ushort)txtDBNumber.Value;

                        db.Description = txtDesc.Text;
                        db.DataType = string.Format("{0}", cboxDataType.SelectedItem);

                        if (eventDataBlockChanged != null) eventDataBlockChanged(db, false);
                    }
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
