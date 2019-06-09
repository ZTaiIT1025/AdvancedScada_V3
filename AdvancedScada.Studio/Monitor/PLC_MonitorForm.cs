using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using AdvancedScada.BaseService.Client;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management.BLManager;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Win32;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.Monitor
{
    public delegate void EventTagSelected(string tagName);
    [CallbackBehavior(UseSynchronizationContext = true)]
    public partial class PLC_MonitorForm : IServiceCallback
    {
        
        private List<string> _SelectedTag;
        private List<Channel> bChannelEthernet;
        private List<DIEthernet> bDIEthernet;
        private List<DISerialPort> bDISerialPort;
        private BindingList<Tag> bS7Tags;
        private List<DataBlock> bvDataBlock;
        private List<Device> bvDevice;
        private bool IsConnected;
        public bool IsDataChanged = false;
        private ChannelService objChannelManager;
        private DataBlockService objDataBlockManager;
        private DeviceService objDeviceManager;
        private TagService objTagManager;
        private readonly string SelectedTag = string.Empty;

         public string[] sp;

        public PLC_MonitorForm()
        {
            InitializeComponent();
            Application.DoEvents();

        }

        private void InitializeData(string xmlPath)
        {
            TreeListNode node = null;
            TreeListNode node2 = null;
            TreeListNode node3 = null;
            objChannelManager.Channels.Clear();
            objChannelManager.XmlPath = xmlPath;
            var chList = objChannelManager.GetChannels(xmlPath);
            TreeList1.Nodes.Clear();
            foreach (var ch in chList)
            {
                ////Sort.
                ch.Devices.Sort(delegate(Device x, Device y) { return x.DeviceName.CompareTo(y.DeviceName); });
                node = TreeList1.AppendNode(new object[] { ch.ChannelName }, null);
                node.StateImageIndex = 1;
                foreach (var dv in ch.Devices)
                {
                    node2 = TreeList1.AppendNode(new object[] { dv.DeviceName }, node);
                    node2.StateImageIndex = 0;
                    foreach (var db in dv.DataBlocks)
                    {
                        node3 = TreeList1.AppendNode(new object[] { db.DataBlockName }, node2);
                        node3.StateImageIndex = 2;
                    }

                }

            }
        }

        public void WriteTagValue(string NumValue)
        {
            try
            {
                var SelectebNodes = TreeList1.Selection;

                if (SelectebNodes[0].Level == 2)
                {
                    var dbNode = SelectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var DeviceName = dvNode["Name"].ToString();
                   
                    var DataBlockName = dbNode["Name"].ToString();
                  

                    var obj = gridView1.GetFocusedRowCellValue(colTagName);

                    if (obj != null)
                    {
                        var tgName = obj.ToString();
                        lblSelectedTag.Caption = $"{SelectedTag}{channelName}.{DeviceName}.{DataBlockName}.{tgName}";
                         
                       
                            client.WriteTag(lblSelectedTag.Caption, NumValue);

                         


                        Thread.Sleep(50);

                    }
                }


            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        private void mWriteTagValue_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                var SelectebNodes = TreeList1.Selection;

                if (SelectebNodes[0].Level == 2)
                {
                    var dbNode = SelectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var DeviceName = dvNode["Name"].ToString();
                    ;
                    var DataBlockName = dbNode["Name"].ToString();
                    ;

                    var obj = gridView1.GetFocusedRowCellValue(colTagName);

                    if (obj != null)
                    {
                        var tgName = obj.ToString();
                        lblSelectedTag.Caption = $"{SelectedTag}{channelName}.{DeviceName}.{DataBlockName}.{tgName}";

                        var objWriteTagForm = new WriteTagForm(lblSelectedTag.Caption, client) { StartPosition = FormStartPosition.CenterParent, ShowInTaskbar = false };

                        objWriteTagForm.ShowDialog();
                    }
                }


            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        private void SimaticMonitorForm_Load(object sender, EventArgs e)
        {
            try
            {

                Text = "Monitor:AdvancedScada";
                objChannelManager = ChannelService.GetChannelManager();
                objDeviceManager = DeviceService.GetDeviceManager();
                objDataBlockManager = DataBlockService.GetDataBlockManager();
                objTagManager = TagService.GetTagManager();

                var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeData(objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT));
                SetCreateChannel();


            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void GridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var obj = gridView1.GetFocusedRowCellValue(colDataType);
                    if (obj != null)
                    {



                        if ("Bit".Equals(obj.ToString()))
                        {
                            mSetON.Visibility = BarItemVisibility.Always;
                            mSetOFF.Visibility = BarItemVisibility.Always;
                            mWriteTagValue.Visibility = BarItemVisibility.Never;
                        }
                        else
                        {
                            mSetON.Visibility = BarItemVisibility.Never;
                            mSetOFF.Visibility = BarItemVisibility.Never;
                            mWriteTagValue.Visibility = BarItemVisibility.Always;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var val = $"{gridView1.GetRowCellValue(e.RowHandle, colValue)}";


            if (val != null || val != string.Empty)
            {
                if (val == "False" || val == "0") colValue.AppearanceCell.ForeColor = Color.Red;
                else colValue.AppearanceCell.ForeColor = Color.Green;

            }

        }
        private void GridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {


                var SelectebNodes = TreeList1.Selection;
                if (SelectebNodes[0].Level == 2)
                {

                    var dbNode = SelectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var DeviceName = dvNode["Name"].ToString();
                    var DataBlockName = dbNode["Name"].ToString();

                    var obj = gridView1.GetFocusedRowCellValue(colTagName);

                    if (obj != null)
                    {
                        var tgName = obj.ToString();
                        lblSelectedTag.Caption = $"{SelectedTag}{channelName}.{DeviceName}.{DataBlockName}.{tgName}";
                    }
                }


            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private string FullNameByNode(TreeListNode node, int columnId)
        {
            var ret = node.GetValue(columnId).ToString();
            while (node.ParentNode != null)
            {
                node = node.ParentNode;
                ret = $"{node.GetValue(columnId)}\\{ret}";
            }
            return ret;
        }
        private void TreeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            try
            {
                var s = FullNameByNode(e.Node, 0);
                sp = s.Split('\\');
                var SelectebNodes = TreeList1.Selection;
                DataBlock dbCurrent = null; //Node: DataBlock
                Device dvCurrent = null; //Node: Device
                Channel chCurrent = null; //Node: Channel

                TreeListNode dbNode = null;
                TreeListNode dvNode = null;
                TreeListNode chNode = null;
                switch (SelectebNodes[0].Level)
                {
                    case 0:
                        chCurrent = objChannelManager.GetByChannelName(TreeList1.FocusedNode.GetDisplayText(0));
                        switch (chCurrent.ConnectionType)
                        {
                            case "SerialPort":
                                vGridSerialPort.Visible = true;
                                bChannelEthernet = new List<Channel>();
                                bDISerialPort = new List<DISerialPort>();
                                var dis = (DISerialPort)chCurrent;

                                bChannelEthernet.Add(chCurrent);
                                bDISerialPort.Add(dis);
                                vGridSerialPort.DataSource = bDISerialPort;
                                vGridChannel.DataSource = bChannelEthernet;
                                vGridEthernet.Visible = false;
                                break;
                            case "Ethernet":
                                vGridEthernet.Visible = true;
                                bChannelEthernet = new List<Channel>();
                                bDIEthernet = new List<DIEthernet>();
                                var die = (DIEthernet)chCurrent;

                                bChannelEthernet.Add(chCurrent);
                                bDIEthernet.Add(die);
                                vGridEthernet.DataSource = bDIEthernet;
                                vGridChannel.DataSource = bChannelEthernet;
                                vGridSerialPort.Visible = false;
                                break;
                        }
                        break;
                    case 1:
                        bvDevice = new List<Device>();
                        chCurrent = objChannelManager.GetByChannelName(TreeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, TreeList1.FocusedNode.GetDisplayText(0));

                        bvDevice.Add(dvCurrent);
                        vGridDevice.DataSource = bvDevice;
                        break;
                    case 2:
                        dbNode = SelectebNodes[0]; // Node:DataBlock
                        dvNode = dbNode.ParentNode; // Node:Device
                        chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var DeviceName = dvNode["Name"].ToString();
                        var DataBlockName = dbNode["Name"].ToString();

                        chCurrent = objChannelManager.GetByChannelName(channelName);
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);

                        bvDataBlock = new List<DataBlock>();

                        bvDataBlock.Add(dbCurrent);
                        vGridDataBlock.DataSource = bvDataBlock;

                        _SelectedTag = new List<string>();

                        foreach (var tg in dbCurrent.Tags)
                        {
                            var tgName = $"{channelName}.{DeviceName}.{DataBlockName}.{tg.TagName}";

                            _SelectedTag.Add(tgName);

                        }

                        bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                        RealTimeSource1.DataSource = bS7Tags;
                        gridView1.Invalidate();
                        break;
                }



            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            mWriteTagValue_ItemClick(null, null);
        }

        private void SimaticMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                try
                {
                     if(client!=null)
                    client.Disconnect(XCollection.CURRENT_MACHINE);
                    IsConnected = false;
                }
                catch (Exception ex)
                {
                   EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                }
                

            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }

        private void mSetON_ItemClick(object sender, ItemClickEventArgs e)
        {
            WriteTagValue("1");
        }

        private void mSetOFF_ItemClick(object sender, ItemClickEventArgs e)
        {
            WriteTagValue("0");
        }
        #region IServiceCallback
        private IReadService client;

        public void SetCreateChannel()
        {
            try
            {


 
                var ic = new InstanceContext(this);
                XCollection.CURRENT_MACHINE = new Machine
                {
                    MachineName = Environment.MachineName,
                    Description = "Free"
                };
                IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress iPAddress in hostAddresses)
                {
                    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        XCollection.CURRENT_MACHINE.IPAddress = $"{iPAddress}";
                        break;
                    }
                }
                client = DriverHelper.GetInstance().GetReadService(ic);
                client.Connect(XCollection.CURRENT_MACHINE);
               
                IsConnected = true;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }



        }


        public void DataChanged(List<Tag>[] registers)
        {
            //try
            //{

            //    TreeListMultiSelection SelectebNodes = TreeList1.Selection;
            //    DataBlock dbCurrent = null; //Node: DataBlock
            //    Device dvCurrent = null; //Node: Device
            //    Channel chCurrent = null; //Node: Channel

            //    TreeListNode dbNode = null;
            //    TreeListNode dvNode = null;
            //    TreeListNode chNode = null;
            //    switch (SelectebNodes[0].Level)
            //    {
            //        case 0:

            //            break;
            //        case 1:

            //            break;
            //        case 2:
            //            dbNode = SelectebNodes[0];// Node:DataBlock
            //            dvNode = dbNode.ParentNode;// Node:Device
            //            chNode = dvNode.ParentNode;// Node:Channel

            //            string channelName = chNode["Name"].ToString();
            //            string DeviceName = dvNode["Name"].ToString();
            //            string DataBlockName = dbNode["Name"].ToString();

            //            chCurrent = ChannelManager.GetByChannelName(channelName);
            //            dvCurrent = DeviceManager.GetByDeviceName(chCurrent, DeviceName);
            //            dbCurrent = DataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);
            //            var db = DVPService.GetTagByDataBlock(dbCurrent);
            //            if (registers == null) return;
            //            var List = registers[chCurrent.ChannelId - 1].Where(item => dbCurrent.Tags.Any(item2 => item2.TagName == item.TagName)).ToList();
            //            if (List == null) return;
            //            bS7Tags = new BindingList<Tag>(List);
            //            RealTimeSource1.DataSource = bS7Tags;
            //            gridView1.Invalidate();
            //            break;
            //    }



            //}
            //catch (Exception ex)
            //{
            //    var err = new ScadaException.ScadaException(this.GetType().Name , ex.Message);
            //}
        }

        public void DataChangedDataBlock(List<DataBlock> db)
        {
            try
            {

                if (IsConnected)
                {


                    var SelectebNodes = TreeList1.Selection;
                    DataBlock dbCurrent = null; //Node: DataBlock
                    Device dvCurrent = null; //Node: Device
                    Channel chCurrent = null; //Node: Channel

                    TreeListNode dbNode = null;
                    TreeListNode dvNode = null;
                    TreeListNode chNode = null;
                    switch (SelectebNodes[0].Level)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:
                            dbNode = SelectebNodes[0]; // Node:DataBlock
                            dvNode = dbNode.ParentNode; // Node:Device
                            chNode = dvNode.ParentNode; // Node:Channel

                            var channelName = chNode["Name"].ToString();
                            var DeviceName = dvNode["Name"].ToString();
                            var DataBlockName = dbNode["Name"].ToString();
                            var tagDataBlock = new List<Tag>();
                            chCurrent = objChannelManager.GetByChannelName(channelName);
                            dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                            dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);
                            if (db != null)

                                foreach (var item in db)
                                    if (dbCurrent.DataBlockId == item.DataBlockId && dbCurrent.DeviceId == item.DeviceId && dbCurrent.ChannelId == item.ChannelId)
                                    {
                                        tagDataBlock = item.Tags;
                                        break;
                                    }


                            bS7Tags = new BindingList<Tag>(tagDataBlock);
                            RealTimeSource1.DataSource = bS7Tags;
                            gridView1.Invalidate();
                            break;
                    }


                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        public void DataTags(Dictionary<string, Tag> Tags)
        {
            try
            {

                if (IsConnected)
                {


                    var SelectebNodes = TreeList1.Selection;
                    DataBlock dbCurrent = null; //Node: DataBlock
                    Device dvCurrent = null; //Node: Device
                    Channel chCurrent = null; //Node: Channel

                    TreeListNode dbNode = null;
                    TreeListNode dvNode = null;
                    TreeListNode chNode = null;
                    switch (SelectebNodes[0].Level)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:
                            dbNode = SelectebNodes[0]; // Node:DataBlock
                            dvNode = dbNode.ParentNode; // Node:Device
                            chNode = dvNode.ParentNode; // Node:Channel

                            var channelName = chNode["Name"].ToString();
                            var DeviceName = dvNode["Name"].ToString();
                            var DataBlockName = dbNode["Name"].ToString();
                            var tagDataBlock = new List<Tag>();
                            chCurrent = objChannelManager.GetByChannelName(channelName);
                            dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                            dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);
                            if (Tags != null)
                            {
                                // var tagDataBlock=   Tags?.ToList().ForEach(c => c.Value.ChannelId== dbCurrent.ChannelId);
                                // var sendTo = Tags?.First(p => p.Value.ChannelId == dbCurrent.ChannelId && p.Value.DeviceId == dbCurrent.DeviceId && p.Value.DataBlockId == dbCurrent.DataBlockId).Value;
                                var List2 = Tags.Where(item => dbCurrent.Tags.Any(p => p.ChannelId == item.Value.ChannelId
                                                                                       && p.DeviceId == item.Value.DeviceId && p.DataBlockId == item.Value.DataBlockId)).ToList();
                                for (var i = 0; i < List2.Count; i++) tagDataBlock.Add(List2[i].Value);


                            }

                            bS7Tags = new BindingList<Tag>(tagDataBlock);
                            RealTimeSource1.DataSource = bS7Tags;
                            gridView1.Invalidate();
                            break;
                    }


                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        #endregion
    }
}