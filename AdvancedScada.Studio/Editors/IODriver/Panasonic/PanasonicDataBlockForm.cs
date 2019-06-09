
using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XPanasonic.Core.UserEditors
{
    public enum MemoryType
    {
        X,
        Y,
        R,
        T,
        C,
        L,
        DT,
        LD,
        FL,
        SV,
        EV,
        IX,
        IY,
        WX,
        WY,
        WR,
        WL
    }
    public partial class XUserDataBlockForm : AdvancedScada.Management.Editors.XDataBlockForm
    {
        int TagsCount = 1;
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
        public void AddressCreateTagModbus(DataBlock db, bool IsNew, int TagsCount = 1)
        {
            if (IsNew == false) db.Tags.Clear();
            foreach (var item in dv.DataBlocks)
            {

                TagsCount += item.Tags.Count;
                if (db != null)
                {
                    if (db.DataBlockName.Equals(item.DataBlockName)) break;
                }

            }
            if (chkCreateTag.Checked)
            {

                for (var i = 0; i < txtAddressLength.Value; i++)
                {
                    var tg = new Tag()
                    {
                        ChannelId = int.Parse(txtChannelId.Text),
                        DeviceId = int.Parse(txtDeviceId.Text),
                        DataBlockId = int.Parse(txtDataBlockId.Text),
                        TagId = i + 1,
                        TagName = $"TAG{i + TagsCount:d5}",
                        Address = $"{txtDomain.Text}{txtStartAddress.Value + i}",
                        DataType = $"{cboxDataType.SelectedItem}",
                        Description = $"{txtDesc.Text} {i + 1}"
                    };
                    db.Tags.Add(tg);
                }
            }


        }
        private void XUserDataBlockForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtDeviceName.Text = dv.DeviceName;
                gpDataBlock.Text = ch.ChannelName;
                txtChannelId.Text = ch.ChannelId.ToString();
                txtDeviceId.Text = dv.DeviceId.ToString();

                txtDomain.Properties.Items.AddRange(Enum.GetNames(typeof(MemoryType)));
               
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
                    CboxTypeOfRead.Text = db.TypeOfRead;
                    txtStartAddress.Value = db.StartAddress;
                    txtAddressLength.Value = db.Length;
                    txtDomain.Text = db.MemoryType;
                    txtDesc.Text = db.Description;
                    txtDataBlockId.Text = $"{db.DataBlockId}";
                    cboxDataType.Text = $"{db.DataType}";
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
                if (chkCreateTag.Checked && (string.IsNullOrEmpty(txtDomain.Text)
                                            || string.IsNullOrWhiteSpace(txtDomain.Text)))
                    DxErrorProvider1.SetError(txtDomain, "The Prefix is empty");
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
                            TypeOfRead = CboxTypeOfRead.SelectedText,
                            StartAddress = (ushort)txtStartAddress.Value,
                            MemoryType = txtDomain.Text,
                            Description = txtDesc.Text,
                            Length = (ushort)txtAddressLength.Value,
                            DataType = cboxDataType.SelectedText,
                            Tags = new List<Tag>()
                        };
                        foreach (var item in dv.DataBlocks)
                        {

                            TagsCount += item.Tags.Count;

                        }
                        AddressCreateTagModbus(dbNew, true, TagsCount);
                        if (eventDataBlockChanged != null) eventDataBlockChanged(dbNew, true);

                    }
                    else
                    {
                        db.ChannelId = db.ChannelId;
                        db.DeviceId = db.DeviceId;
                        db.DataBlockId = int.Parse(txtDataBlockId.Text);
                        db.DataBlockName = txtDataBlock.Text;
                        db.TypeOfRead = CboxTypeOfRead.SelectedText;
                        db.StartAddress = (ushort)txtStartAddress.Value;
                        db.MemoryType = txtDomain.Text;
                        db.Length = (ushort)txtAddressLength.Value;
                        db.Description = txtDesc.Text;
                        db.DataType = $"{cboxDataType.SelectedItem}";


                        AddressCreateTagModbus(db, false);

                        if (eventDataBlockChanged != null) eventDataBlockChanged(db, false);

                    }
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void chkCreateTag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtDomain.Enabled = chkCreateTag.Checked;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void cboxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ohj = cboxDataType.SelectedItem;

                if (ohj != null)
                    switch (ohj.ToString())
                    {
                        case "Bit":
                        case "Byte":

                            txtAddressLength.Properties.MaxValue = 2000;
                            txtAddressLength.Properties.MinValue = 1;


                            break;
                        case "Word":
                        case "Int":

                            txtAddressLength.Properties.MaxValue = 120;
                            txtAddressLength.Properties.MinValue = 1;

                            break;
                        case "DWord":
                        case "DInt":
                        case "Real":

                            txtAddressLength.Properties.MaxValue = 60;
                            txtAddressLength.Properties.MinValue = 1;

                            break;
                    }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         }
    }
}
