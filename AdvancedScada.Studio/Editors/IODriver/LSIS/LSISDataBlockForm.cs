using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Utils.LSIS;
using System;
using System.Collections.Generic;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.XLSIS.Core.UserEditors
{
    public partial class XUserDataBlockForm : AdvancedScada.Management.Editors.XDataBlockForm
    {
        private int IDX;
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


        public void AddressCreateTagWord(DataBlock db, bool IsNew)
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
            var y = txtStartAddress.Value;
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
                        Address = $"{txtDomain.Text}{y}",
                        DataType = $"{cboxDataType.SelectedItem}",
                        Description = $"{txtDesc.Text} {i + 1}"
                    };
                    db.Tags.Add(tg);
                    y += 1;
                }
            }


        }
        public void AddressCreateTagBit(DataBlock db, int Address, int Save_BufAddr, bool IsNew)
        {
            var hex1 = 0;
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
                var y = Address;
                hex1 = (int)HexadecimalToDecimal.HexToDec(Address.ToString());
                for (var i = Address; i < Save_BufAddr + y; i++)
                {
                    var hexaNumber = string.Empty;
                    var tg = new Tag() { TagId = IDX += 1 };

                    if (hex1 == 0)
                        hexaNumber = "0";
                    else
                        hexaNumber = DecimalToHex.GetDecimalToHex(long.Parse(hex1.ToString()));
                    tg.ChannelId = int.Parse(txtChannelId.Text);
                    tg.DeviceId = int.Parse(txtDeviceId.Text);
                    tg.DataBlockId = int.Parse(txtDataBlockId.Text);
                    tg.TagName = $"TAG{TagsCount:d5}";
                    tg.Address = $"{txtDomain.Text}{hexaNumber}";
                    tg.Description = $"{txtDesc.Text} {i.ToString("X")}";
                    tg.DataType = $"{cboxDataType.SelectedItem}";
                    db.Tags.Add(tg);
                    hex1 += 1;
                    TagsCount += 1;
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
                    //CboxTypeOfRead.Text = db.TypeOfRead;
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
                var Address = 0;
                var Save_BufAddr = 0;


                if (cboxDataType.Text == "Bit" || cboxDataType.Text == "Byte")
                    Save_BufAddr = (int)txtAddressLength.Value * 16;
                else
                    Save_BufAddr = (int)txtAddressLength.Value;
                if (chkX10.Checked)
                    Address = 10 * (int)txtStartAddress.Value;
                else
                    Address = (int)txtStartAddress.Value;



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
                            TypeOfRead = string.Empty,
                            StartAddress = (ushort)txtStartAddress.Value,
                            MemoryType = txtDomain.Text,
                            Description = txtDesc.Text,
                            Length = (ushort)txtAddressLength.Value,
                            DataType = cboxDataType.SelectedText,
                            Tags = new List<Tag>()
                        };


                        if (cboxDataType.Text == "Bit" || cboxDataType.Text == "Byte")
                        {
                            if (chkCreateTag.Checked) AddressCreateTagBit(dbNew, Address, Save_BufAddr, true);

                        }
                        else
                        {
                            if (chkCreateTag.Checked) AddressCreateTagWord(dbNew, true);

                        }

                      
                        if (eventDataBlockChanged != null) eventDataBlockChanged(dbNew, true);

                    }
                    else
                    {
                        db.ChannelId = db.ChannelId;
                        db.DeviceId = db.DeviceId;
                        db.DataBlockId = int.Parse(txtDataBlockId.Text);
                        db.DataBlockName = txtDataBlock.Text;
                        db.TypeOfRead = string.Empty;
                        db.StartAddress = (ushort)txtStartAddress.Value;
                        db.MemoryType = txtDomain.Text;
                        db.Length = (ushort)txtAddressLength.Value;
                        db.Description = txtDesc.Text;
                        db.DataType = $"{cboxDataType.SelectedItem}";

                        if (cboxDataType.Text == "Bit" || cboxDataType.Text == "Byte")
                        {
                            if (chkCreateTag.Checked) AddressCreateTagBit(db, Address, Save_BufAddr, false);

                        }
                        else
                        {
                            if (chkCreateTag.Checked) AddressCreateTagWord(db, false);

                        }

                        
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

                var ohj = cboxDataType.Text;

                switch (ohj)
                {
                    case "Bit":
                    case "Byte":
                        txtAddressLength.Properties.MaxValue = 1;
                        chkX10.Enabled = true;

                        txtAddressLength.Properties.MinValue = 1;

                        break;
                    case "Word":
                    case "Int":
                        if (ch.ConnectionType == "SerialPort")
                        {
                            txtAddressLength.Properties.MaxValue = 60;
                            txtAddressLength.Properties.MinValue = 1;
                            chkX10.Enabled = false;
                        }

                        else
                        {
                            txtAddressLength.Properties.MaxValue = 120;
                            txtAddressLength.Properties.MinValue = 1;
                            chkX10.Enabled = false;
                        }
                        break;
                    case "DWord":
                    case "DInt":
                    case "Real":

                        txtAddressLength.Properties.MaxValue = 60;
                        txtAddressLength.Properties.MinValue = 1;
                        chkX10.Enabled = false;

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
