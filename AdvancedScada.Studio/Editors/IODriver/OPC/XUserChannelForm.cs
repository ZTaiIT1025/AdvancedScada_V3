using System;
using System.Collections.Generic;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.BLManager;
using AdvancedScada.Management.Editors;
using Opc;
using OpcCom;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.XOPC.Core.UserEditors
{
    public partial class XUserChannelForm : XChannelForm
    {
        public XUserChannelForm()
        {
            InitializeComponent();
            GetOpcServers();
        }
        public XUserChannelForm(ChannelService chm = null, Channel chCurrent = null)
        {
            InitializeComponent();
            objChannelManager = chm;
            ch = chCurrent;
            GetOpcServers();

        }

        #region IPlugin
        public string PluginName => throw new NotImplementedException();
        #endregion
        private void GetOpcServers()
        {
            try
            {
                var se = new ServerEnumerator();

                var servers = se.GetAvailableServers(Specification.COM_DA_20);
                serversComboBox.Items.Clear();
                foreach (var item in servers) serversComboBox.Items.Add(item.Name);
            }
            catch (Exception)
            {
            }
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
                dxErrorProvider1.ClearErrors();
                DIEthernet die = null;

                die = new DIEthernet
                {
                    ChannelName = txtChannelName.Text,
                    ChannelTypes = "OPC",
                    CPU = serversComboBox.Text,
                    Rack = 0,
                    Slot = 0,
                    IPAddress = "127.0.0.1",
                    Port = 502,
                    ConnectionType = "Ethernet",
                    Mode = serverTextBox.Text
                };

                if (ch == null)
                {
                    //var log = new LoggerPLC.LoggerPLC(1, "Channel",
                    //    $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Add to Channel ");

                    die.ChannelId = objChannelManager.Channels.Count + 1;
                    die.Devices = new List<Device>();
                    if (eventChannelChanged != null) eventChannelChanged(die, true);
                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }
                else
                {
                    //var log = new LoggerPLC.LoggerPLC(1, "Channel",
                    //    $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}", "Add to Update  ");

                    die.ChannelId = ch.ChannelId;
                    die.Devices = ch.Devices;
                    if (eventChannelChanged != null) eventChannelChanged(die, false);
                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;

                }

                btnNext.Text = "Finish";
                btnBlack.Enabled = true;


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


                if (ch != null)
                {
                    Text = "Edit Channel";
                    txtChannelName.Text = ch.ChannelName;
                    txtDesc.Text = ch.ChannelName;
                }
                else
                {
                    Text = "Add Channel";
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            GetOpcServers();
        }

        #region IUiElement
        public int Init()
        {
            return 0;
        }

        public void Active(bool active)
        {

        }
        #endregion
    }
}
