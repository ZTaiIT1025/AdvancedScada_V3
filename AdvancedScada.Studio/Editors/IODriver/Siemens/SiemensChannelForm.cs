using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.BLManager;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace XSiemens.Core.UserEditors
{
    public partial class XUserChannelForm : AdvancedScada.Management.Editors.XChannelForm
    {

        public XUserChannelForm()
        {
            InitializeComponent();
        }
        public XUserChannelForm(ChannelService chm = null, Channel chCurrent = null)
        {
            InitializeComponent();
            this.objChannelManager = chm;
            this.ch = chCurrent;

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                dxErrorProvider1.ClearErrors();
                if (string.IsNullOrEmpty(txtChannelName.Text)
                               || string.IsNullOrWhiteSpace(txtChannelName.Text))
                {
                    dxErrorProvider1.SetError(txtChannelName, "The channel name is empty");
                    return;
                }
                var ConnType = string.Format("{0}", cboxConnType.SelectedItem);
                xtraTabControl1.SelectedTabPageIndex = cboxConnType.SelectedIndex;
                dxErrorProvider1.ClearErrors();
                switch (ConnType)
                {
                    case "SerialPort":
                        if ("Finish".Equals(btnNext.Text))
                        {
                            DISerialPort dis = new DISerialPort()
                            {
                                ChannelId = objChannelManager.Channels.Count + 1,
                                ChannelName = txtChannelName.Text,
                                ChannelTypes = "Siemens",
                                CPU = string.Empty,
                                PortName = string.Format("{0}", cboxPort.SelectedItem),
                                BaudRate = int.Parse(string.Format("{0}", cboxBaudRate.SelectedItem)),
                                DataBits = int.Parse(string.Format("{0}", cboxDataBits.SelectedItem)),
                                StopBits = (StopBits)System.Enum.Parse(typeof(StopBits), string.Format("{0}", cboxStopBits.SelectedItem)),
                                Parity = (Parity)System.Enum.Parse(typeof(Parity), string.Format("{0}", cboxParity.SelectedItem)),
                                Handshake = (Handshake)System.Enum.Parse(typeof(Handshake), string.Format("{0}", cboxHandshake.SelectedItem)),
                                ConnectionType = ConnType,
                                Mode = string.Format("{0}", cboxModeSP.SelectedItem),
                                Description = txtDesc.Text
                            };
                            if (ch == null)
                            {
                              
                                dis.ChannelId = objChannelManager.Channels.Count + 1;
                                if (eventChannelChanged != null) eventChannelChanged(dis, true);

                            }
                            else
                            {
                                dis.ChannelId = ch.ChannelId;
                                dis.Devices = ch.Devices;
                                if (eventChannelChanged != null) eventChannelChanged(dis, false);

                            }
                        }
                        btnNext.Text = "Finish";
                        btnBlack.Enabled = true;

                        break;
                    case "Ethernet":
                        if ("Finish".Equals(btnNext.Text))
                        {
                            DIEthernet die = null;

                            die = new DIEthernet()
                            {
                                ChannelName = txtChannelName.Text,
                                ChannelTypes = "Siemens",
                                CPU = string.Format("{0}", cboxModel.SelectedItem),
                                Rack = (short)txtRack.Value,
                                Slot = (short)txtSlot.Value,
                                IPAddress = txtIPAddress.Text,
                                Port = (short)txtPort.Value,
                                ConnectionType = ConnType,
                                Mode = "TCP"
                            };

                            if (ch == null)
                            {
                                die.ChannelId = objChannelManager.Channels.Count + 1;
                                die.Devices = new List<Device>();
                                if (eventChannelChanged != null) eventChannelChanged(die, true);

                            }
                            else
                            {
                                die.ChannelId = ch.ChannelId;
                                die.Devices = ch.Devices;
                                if (eventChannelChanged != null) eventChannelChanged(die, false);

                            }

                        }
                        btnNext.Text = "Finish";
                        btnBlack.Enabled = true;

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void XUserChannelForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboxPort.Items.Clear();
                cboxBaudRate.Items.Clear();
                cboxPort.Items.AddRange(SerialPort.GetPortNames());
                cboxBaudRate.Items.AddRange(new string[] { "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "56000", "57600", "115200" });
                cboxDataBits.Items.AddRange(new string[] { "7", "8" });
                cboxParity.Items.AddRange(System.Enum.GetNames(typeof(Parity)));
                cboxStopBits.Items.AddRange(System.Enum.GetNames(typeof(StopBits)));
                cboxHandshake.Items.AddRange(System.Enum.GetNames(typeof(Handshake)));


                if (ch != null)
                {
                    cboxConnType.Enabled = false;
                    this.Text = "Edit Channel";
                    this.txtChannelName.Text = ch.ChannelName;
                    this.cboxConnType.SelectedItem = string.Format("{0}", ch.ConnectionType);
                    cboxModel.SelectedItem = string.Format("{0}", ch.CPU);
                    txtRack.Text = string.Format("{0}", ch.Rack);
                    txtSlot.Text = string.Format("{0}", ch.Slot);
                    txtDesc.Text = ch.ChannelName;
                    switch (ch.ConnectionType)
                    {
                        case "SerialPort":
                            DISerialPort dis = (DISerialPort)ch;
                            cboxPort.SelectedItem = dis.PortName;
                            cboxBaudRate.SelectedItem = string.Format("{0}", dis.BaudRate);
                            cboxDataBits.SelectedItem = string.Format("{0}", dis.DataBits);
                            cboxParity.SelectedItem = string.Format("{0}", dis.Parity);
                            cboxStopBits.SelectedItem = string.Format("{0}", dis.StopBits);
                            cboxHandshake.SelectedItem = string.Format("{0}", dis.Handshake);
                            cboxModeSP.SelectedItem = string.Format("{0}", dis.Mode);

                            break;
                        case "Ethernet":

                            DIEthernet die = (DIEthernet)ch;
                            txtIPAddress.Text = die.IPAddress;
                            txtPort.Value = die.Port;
                            break;


                    }

                }
                else
                {
                    cboxConnType.Enabled = true;
                    this.Text = "Add Channel";
                    this.cboxConnType.SelectedIndex = 0;
                    cboxPort.SelectedIndex = 0;
                    cboxBaudRate.SelectedIndex = 3;
                    cboxDataBits.SelectedIndex = 1;
                    cboxParity.SelectedIndex = 0;
                    cboxStopBits.SelectedIndex = 1;
                    cboxHandshake.SelectedIndex = 0;
                    cboxModeSP.SelectedIndex = 0;
                    cboxModel.SelectedIndex = 1;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            try
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
                btnBlack.Enabled = false;
                btnNext.Text = "Next >";
            }
            catch (Exception)
            {
            }
        }
    }
}
