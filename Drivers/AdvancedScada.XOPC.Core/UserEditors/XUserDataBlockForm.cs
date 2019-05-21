using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.Editors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Opc;
using Opc.Da;
using OpcRcw.Da;
using Convert = System.Convert;
using Factory = OpcCom.Factory;
using Server = Opc.Da.Server;
using Type = System.Type;

namespace AdvancedScada.XOPC.Core.UserEditors
{
    public partial class XUserDataBlockForm : XDataBlockForm
    {
        private Server _server;
        private readonly Factory fact = new Factory();
        private ItemResult[] ItemResult;
        private List<string> SubscribedCollection;
        private Item[] SubscribedItems;
        private Subscription SubscriptionOPC;
        private readonly SubscriptionState SubscriptionState = new SubscriptionState();
        private readonly int TagsCount = 1;
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

        public List<OPCChannelInfo> Channels
        {
            get;
        } = new List<OPCChannelInfo>();



        private void XUserDataBlockForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtDeviceName.Text = dv.DeviceName;
                gpDataBlock.Text = ch.ChannelName;
                txtChannelId.Text = ch.ChannelId.ToString();
                txtDeviceId.Text = dv.DeviceId.ToString();
                txtOPCServerPath.Text = ch.Mode;
                txtOPCServer.Text = ch.CPU;
                txtOPCServerPath.Enabled = false;
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
                    //txtOPCServerPath.Text = ch.Mode;
                    //txtOPCServer.Text = ch.CPU;
                    txtDataBlockId.Text = $"{db.DataBlockId}";
                }
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name, ex.Message);
            }
        }
        public string[] GetDataType(List<OPCChannelInfo> Subscribed)
        {
            var serverName = txtOPCServer.Text;
            var hostName = txtOPCServerPath.Text;

            _server = new Server(fact, null);
            _server.Url = new URL(hostName + "/" +
                                  serverName);
            _server.Connect();

            SubscribedCollection = new List<string>();

            for (var i = 0; i < Subscribed.Count; i++) SubscribedCollection.Add(Subscribed[i].channel);

            if (SubscriptionOPC == null)
            {
                SubscriptionState.Name = "SubscribedGroup";

                SubscriptionOPC = (Subscription)_server.CreateSubscription(SubscriptionState);
            }
            SubscribedItems = new Item[SubscribedCollection.Count];




            for (var i = 0; i < SubscribedCollection.Count; i++)
            {
                SubscribedItems[i] = new Item();
                SubscribedItems[i].ItemName = SubscribedCollection[i];
                SubscribedItems[i].SamplingRate = 200;
                SubscribedItems[i].Active = true;
                SubscribedItems[i].ClientHandle = i;
            }
            ItemResult = SubscriptionOPC.AddItems(SubscribedItems);

            ItemValue[] values = _server.Read(SubscribedItems);

            var ArraySize = values.Length;
            if (values[0].Value is Array) ArraySize = ((Array)values[0].Value).Length - 1;
            var ReturnValues = new string[ArraySize];
            for (var i = 0; i < values.Length; i++)
            {
                if (values[i].Value is string) ReturnValues[i] = "String";
                if (values[i].Value is bool)
                    ReturnValues[i] = "Bit";
                else if (values[i].Value is byte)
                    ReturnValues[i] = "byte";
                else if (values[i].Value is float)
                    ReturnValues[i] = "Float";
                else if (values[i].Value is char)
                    ReturnValues[i] = "char";
                else if (values[i].Value is short)
                    ReturnValues[i] = "Word";
                else if (values[i].Value is int)
                    ReturnValues[i] = "Long";
                else if (values[i].Value is double)
                    ReturnValues[i] = "double";
                else if (values[i].Value is Array)
                    ReturnValues[i] = "Array";
                else if (values[i].Value is uint)
                    ReturnValues[i] = "DWord";
                else if (values[i].Value is short)
                    ReturnValues[i] = "short";
                else if (values[i].Value is ushort) ReturnValues[i] = "ushort";
                //else
                //{
                //    ReturnValues[i] = "null";
                //}
            }

            if (_server != null)
            {
                if (_server.IsConnected)
                    try
                    {
                        _server.Disconnect();
                    }
                    catch
                    {
                    }
                _server.Dispose();

            }
            return ReturnValues;
        }

        public void AddressCreateTagModbus(DataBlock db, bool IsNew, int TagsCount = 1)
        {

            if (IsNew == false) db.Tags.Clear();
            foreach (var item in dv.DataBlocks)
            {

                TagsCount += item.Tags.Count;
                if (db != null)
                    if (db.DataBlockName.Equals(item.DataBlockName))
                        break;

            }
            var type = GetDataType(Channels);

            for (var i = 0; i < Channels.Count; i++)
            {
                // Find out what the type is before you try to get the value

                var tg = new Tag();


                tg.ChannelId = int.Parse(txtChannelId.Text);
                tg.DeviceId = int.Parse(txtDeviceId.Text);
                tg.DataBlockId = int.Parse(txtDataBlockId.Text);
                tg.TagId = i + 1;
                tg.TagName = $"TAG{i + TagsCount:d5}";
                tg.Address = $"{Channels[i].channel}";
                tg.DataType = $"{type[i]}";
                var channelsArray = Channels[i].channel.Split('.');
                if (channelsArray.Length >= 4)
                    tg.Desp = $"{Channels[i].channel.Split('.')[3]}";
                else
                    tg.Desp = $"{Channels[i].channel.Split('.')[2]}";
                db.Tags.Add(tg);

            }


        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Channels.Clear();
                SaveOPCChannels(channelsTree.Nodes);
                //  Close();
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name, ex.Message);
            }
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
                        var dbNew = new DataBlock
                        {
                            ChannelId = ch.ChannelId,
                            DeviceId = dv.DeviceId,
                            DataBlockId = dv.DataBlocks.Count + 1,
                            DataBlockName = txtDataBlock.Text,
                            TypeOfRead = string.Empty,
                            StartAddress = 0,
                            MemoryType = string.Empty,
                            Description = string.Empty,
                            Length = (ushort)Channels.Count,
                            DataType = string.Empty,
                            Tags = new List<Tag>()
                        };

                        AddressCreateTagModbus(dbNew, true, TagsCount);
                        if (eventDataBlockChanged != null) eventDataBlockChanged(dbNew, true);

                    }
                    else
                    {
                        db.ChannelId = db.ChannelId;
                        db.DeviceId = db.DeviceId;
                        db.DataBlockId = int.Parse(txtDataBlockId.Text);
                        db.DataBlockName = txtDataBlock.Text;
                        db.TypeOfRead = string.Empty;
                        db.StartAddress = (ushort)Channels.Count;
                        db.MemoryType = string.Empty;
                        db.Length = (ushort)Channels.Count;
                        db.Description = string.Empty;
                        db.DataType = string.Empty;


                        AddressCreateTagModbus(db, false);

                        if (eventDataBlockChanged != null) eventDataBlockChanged(db, false);

                    }
                }
            }
            catch (Exception ex)
            {
                var err = new ErorrPLC.ErorrPLC(GetType().Name + ".UserEditors.btnOK_Click", ex.Message);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            var serverName = txtOPCServer.Text;

            Type t;
            //if (localServerButton.Checked)
            t = Type.GetTypeFromProgID(serverName);
            //else
            //    t = Type.GetTypeFromProgID(serverName, txtOPCServerPath.Text);

            var obj = Activator.CreateInstance(t);
            var srv = (IOPCBrowseServerAddressSpace)obj;


            if (srv != null)
            {
                try
                {
                    for (;;)
                        srv.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_UP, string.Empty);
                }
                catch (COMException) { }
                ;
                channelsTree.Nodes.Clear();
                ImportOPCChannels(srv, channelsTree.Nodes);
            }
            channelsTree.AfterCheckNode += ChannelsTree_AfterCheckNode;
            connectButton.Enabled = false;

        }



        private void serversComboBox_TextChanged(object sender, EventArgs e)
        {
            connectButton.Enabled = txtOPCServer.Text.Length > 0;
        }

        private void ChannelsTree_AfterCheckNode(object sender, NodeEventArgs e)
        {

            if (e.Node.Nodes.Count > 0) CheckAllChildNodes(e.Node, e.Node.Checked);

        }
        public struct OPCChannelInfo
        {
            public string progId;
            public string host;
            public string channel;

        }
        #region channelsTree
        private void SaveOPCChannels(TreeListNodes root)
        {
            foreach (TreeListNode node in root)
                if (node.Nodes.Count > 0)
                    SaveOPCChannels(node.Nodes);
                else if (node.Checked)

                    Channels.Add((OPCChannelInfo)node.Tag);
        }

        private void CheckAllChildNodes(TreeListNode treeNode, bool nodeChecked)
        {
            foreach (TreeListNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0) CheckAllChildNodes(node, nodeChecked);
            }
        }
        private void ImportOPCChannels(IOPCBrowseServerAddressSpace srv, TreeListNodes root)
        {
            OPCNAMESPACETYPE nsType;
            srv.QueryOrganization(out nsType);
            IEnumString es;
            if (nsType == OPCNAMESPACETYPE.OPC_NS_HIERARCHIAL)
            {
                try { srv.BrowseOPCItemIDs(OPCBROWSETYPE.OPC_BRANCH, string.Empty, 0, 0, out es); }
                catch (COMException) { return; }

                int fetched;
                do
                {
                    var tmp = new string[100];
                    es.RemoteNext(tmp.Length, tmp, out fetched);
                    for (var i = 0; i < fetched; i++)
                    {
                        try { srv.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_DOWN, tmp[i]); }
                        catch (Exception e)
                        {
                            var err = new ErorrPLC.ErorrPLC(GetType().Name, string.Format("OPC server failed to handle OPC_BROWSE_DOWN request for item '{0}' ({1})", tmp[i], e.Message));
                            continue;
                        }
                        ;
                        var node = root.Add(new object[] { tmp[i] });
                        ImportOPCChannels(srv, node.Nodes);
                        try { srv.ChangeBrowsePosition(OPCBROWSEDIRECTION.OPC_BROWSE_UP, string.Empty); }
                        catch (Exception e)
                        {
                            var err = new ErorrPLC.ErorrPLC(GetType().Name, string.Format("OPC server failed to handle OPC_BROWSE_UP request for item '{0}' ({1})", tmp[i], e.Message));
                        }
                        ;
                    }
                } while (fetched > 0);

                try { srv.BrowseOPCItemIDs(OPCBROWSETYPE.OPC_LEAF, string.Empty, 0, 0, out es); }
                catch (COMException) { return; }
                IterateOPCItems(srv, root, es);
            }
            else if (nsType == OPCNAMESPACETYPE.OPC_NS_FLAT)
            {
                try { srv.BrowseOPCItemIDs(OPCBROWSETYPE.OPC_FLAT, string.Empty, 0, 0, out es); }
                catch (COMException) { return; }
                IterateOPCItems(srv, root, es);
            }
            es = null;
        }

        private void IterateOPCItems(IOPCBrowseServerAddressSpace srv, TreeListNodes root, IEnumString es)
        {
            int fetched;
            do
            {
                var tmp = new string[100];
                es.RemoteNext(tmp.Length, tmp, out fetched);
                for (var i = 0; i < fetched; i++)
                    AddTreeNode(srv, root, tmp[i]);
            } while (fetched > 0);
        }

        private void AddTreeNode(IOPCBrowseServerAddressSpace srv, TreeListNodes root, string tag)
        {
            var item = root.Add(new object[] { tag });
            var channel = new OPCChannelInfo();
            channel.progId = txtOPCServer.Text;
            channel.host = txtOPCServerPath.Text;
            srv.GetItemID(tag, out channel.channel);
            item.Tag = channel;
        }
        #endregion
    }
}
