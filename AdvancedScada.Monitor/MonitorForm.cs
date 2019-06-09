using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.Management.BLManager;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Monitor
{
    public delegate void EventTagSelected(string tagName);

    public partial class MonitorForm : IServiceCallback
    {
        public const string Driver = "Driver";

        private ChannelService objChannelManager = null;
        private DeviceService objDeviceManager = null;
        private DataBlockService objDataBlockManager = null;
        private TagService objTagManager = null;
        private BindingList<Tag> bS7Tags;
        private IReadService client;
        public bool IsDataChanged = false;
        public EventTagSelected OnTagSelected_Clicked = null;

        private readonly string SelectedTag = string.Empty;
        public string[] sp = null;

        private string DriverTypes;

        public MonitorForm(string tagNameSelected = null)
        {
            InitializeComponent();
        }

        public MonitorForm()
        {
            InitializeComponent();
        }
        public void WriteTagValue(string NumValue)
        {
            try
            {
                TreeListMultiSelection SelectebNodes = TreeList1.Selection;

                if (SelectebNodes[0].Level == 2)
                {
                    TreeListNode dbNode = SelectebNodes[0];// Node:DataBlock
                    TreeListNode dvNode = dbNode.ParentNode;// Node:Device
                    TreeListNode chNode = dvNode.ParentNode;// Node:Channel


                    string channelName = chNode["Name"].ToString();
                    string DeviceName = dvNode["Name"].ToString(); ;
                    string DataBlockName = dbNode["Name"].ToString(); ;

                    object obj = gridView1.GetFocusedRowCellValue(colTagName);

                    if (obj != null)
                    {
                        string tgName = obj.ToString();
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
        private void InitializeData(string xmlPath)
        {
            TreeListNode node = null;
            TreeListNode node2 = null;
            objChannelManager.Channels.Clear();
            objChannelManager.XmlPath = xmlPath;
            var chList = objChannelManager.GetChannels(xmlPath);
            TreeList1.Nodes.Clear();
            foreach (var ch in chList)
            {
                var dvList = new List<TreeNode>();
                ////Sort.
                ch.Devices.Sort(delegate (Device x, Device y) { return x.DeviceName.CompareTo(y.DeviceName); });
                node = TreeList1.AppendNode(new object[] { ch.ChannelName }, null);
                foreach (var dv in ch.Devices)
                {
                    var tgList = new List<TreeNode>();
                    node2 = TreeList1.AppendNode(new object[] { dv.DeviceName }, node);
                    foreach (var db in dv.DataBlocks)
                    {
                        tgList.Add(new TreeNode(db.DataBlockName));
                        TreeList1.AppendNode(new object[] { db.DataBlockName }, node2).StateImageIndex = 2;
                    }

                    var dvNode = new TreeNode(dv.DeviceName, tgList.ToArray());
                }

                var chNode = new TreeNode(ch.ChannelName, dvList.ToArray());
            }
        }


        private void mWriteTagValue_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                TreeListMultiSelection SelectebNodes = TreeList1.Selection;

                if (SelectebNodes[0].Level == 2)
                {
                    TreeListNode dbNode = SelectebNodes[0];// Node:DataBlock
                    TreeListNode dvNode = dbNode.ParentNode;// Node:Device
                    TreeListNode chNode = dvNode.ParentNode;// Node:Channel


                    string channelName = chNode["Name"].ToString();
                    string DeviceName = dvNode["Name"].ToString(); ;
                    string DataBlockName = dbNode["Name"].ToString(); ;

                    object obj = gridView1.GetFocusedRowCellValue(colTagName);

                    if (obj != null)
                    {
                        string tgName = obj.ToString();
                        lblSelectedTag.Caption = $"{SelectedTag}{channelName}.{DeviceName}.{DataBlockName}.{tgName}";

                        WriteTagForm objWriteTagForm = new WriteTagForm(lblSelectedTag.Caption, client) { StartPosition = FormStartPosition.CenterParent, ShowInTaskbar = false };

                        objWriteTagForm.ShowDialog();
                    }
                }


            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);

            }
        }

        private void SimaticMonitorForm_Load(object sender, EventArgs e)
        {
            try
            {

                this.Text = $"Monitor:{GetDriverTypes()}";
                objChannelManager = ChannelService.GetChannelManager();
                objDeviceManager = DeviceService.GetDeviceManager();
                objDataBlockManager = DataBlockService.GetDataBlockManager();
                objTagManager = TagService.GetTagManager();

                string xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
                InitializeData(objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT));
                // GetWCF();
            }

            catch (CommunicationException ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
        }

        private void GridControl1_MouseClick(object sender, MouseEventArgs e)
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
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    var obj = gridView1.GetFocusedRowCellValue(colDataType);
                    if (obj != null)
                    {
                        if ("Bit".Equals(obj.ToString()))
                        {
                            mSetON.Visibility = BarItemVisibility.Always;
                            mSetOFF.Visibility = BarItemVisibility.Always;
                        }
                        else
                        {
                            mSetON.Visibility = BarItemVisibility.Never;
                            mSetOFF.Visibility = BarItemVisibility.Never;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                string val = $"{gridView1.GetRowCellValue(e.RowHandle, colValue)}";


                if (val != null || val != string.Empty)
                {
                    if (val == "False" || val == "0")
                    {

                        colValue.AppearanceCell.ForeColor = Color.Red;

                    }
                    else
                    {
                        colValue.AppearanceCell.ForeColor = Color.Green;

                    }

                }
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


        }

        private static string FullNameByNode(TreeListNode node, int columnId)
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
                var SelectebNodes = TreeList1.Selection;
                DataBlock dbCurrent = null; //Node: DataBlock
                Device dvCurrent = null; //Node: Device
                Channel chCurrent = null; //Node: Channel

                switch (SelectebNodes[0].Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        var dbNode = SelectebNodes[0]; // Node:DataBlock
                        var dvNode = dbNode.ParentNode; // Node:Device
                        var chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var DeviceName = dvNode["Name"].ToString();
                        ;
                        var DataBlockName = dbNode["Name"].ToString();
                        ;
                        chCurrent = objChannelManager.GetByChannelName(channelName);
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);
                        var db = new DataBlock
                        {
                            ChannelId = Convert.ToInt16(chCurrent.ChannelId),
                            DeviceId = Convert.ToInt16(dvCurrent.DeviceId),
                            DataBlockId = dbCurrent.DataBlockId
                        };
                        bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                        RealTimeSource1.DataSource = bS7Tags;
                        gridView1.Invalidate();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
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
                        if (OnTagSelected_Clicked != null) OnTagSelected_Clicked(lblSelectedTag.Caption);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                txtHistory.Text += string.Format("+ ERROR: {0}" + Environment.NewLine, ex.Message);
            }
        }

        private void SimaticMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
               // client.Disconnect(XC;
                Application.DoEvents();
            }
        }

        private void mSetON_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WriteTagValue("1");
        }

        private void mSetOFF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WriteTagValue("0");
        }
        public string GetDriverTypes()
        {
            DriverTypes =
                $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "ChannelTypes", null)}";
            return $"{DriverTypes}Service";
        }
        public void GetWCF()
        {
            try
            {
                var HOST =
                    $"{Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                var PORT = ushort.Parse(
                    $"{Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");
                mPort.Caption = $"{PORT}";
                mIP.Caption = HOST;

                string UriService = GetDriverTypes();



                var ic = new InstanceContext(this);
                var binding = new NetTcpBinding(SecurityMode.None) { ReceiveTimeout = TimeSpan.FromMinutes(1) };

                NetTcpBinding netTcpBinding = new NetTcpBinding()
                {
                    TransactionFlow = false,
                    MaxReceivedMessageSize = int.MaxValue,
                    MaxBufferSize = int.MaxValue
                };
                netTcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
                netTcpBinding.Security.Mode = SecurityMode.None;
                var endPoint =
                    new EndpointAddress(new Uri($"net.Tcp://{HOST}:{PORT}/{UriService}/{Driver}"));
                var factory = new DuplexChannelFactory<IReadService>(ic, netTcpBinding, endPoint);
                client = factory.CreateChannel();
               // client.Connect(Machine mac); ();

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
            //    var err = new ScadaException.ScadaException(ex.Message);
            //}
        }

        public void DataChangedDataBlock(List<DataBlock> db)
        {
            try
            {

                TreeListMultiSelection SelectebNodes = TreeList1.Selection;
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
                        dbNode = SelectebNodes[0];// Node:DataBlock
                        dvNode = dbNode.ParentNode;// Node:Device
                        chNode = dvNode.ParentNode;// Node:Channel

                        string channelName = chNode["Name"].ToString();
                        string DeviceName = dvNode["Name"].ToString();
                        string DataBlockName = dbNode["Name"].ToString();
                        var tagDataBlock = new List<Tag>();
                        chCurrent = objChannelManager.GetByChannelName(channelName);
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);
                        if (db != null)

                            foreach (var item in db)
                            {
                                if (dbCurrent.DataBlockId == item.DataBlockId && dbCurrent.DeviceId == item.DeviceId && dbCurrent.ChannelId == item.ChannelId)
                                {
                                    tagDataBlock = item.Tags;
                                    break;
                                }
                            }


                        bS7Tags = new BindingList<Tag>(tagDataBlock);
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

        public void DataTags(Dictionary<string, Tag> Tags)
        {
            //  throw new NotImplementedException();
        }
    }
}