using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.BLManager;
using AdvancedScada.Studio.IE;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using OfficeOpenXml;
using RowClickEventArgs = DevExpress.XtraGrid.Views.Grid.RowClickEventArgs;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.Editors
{
    public partial class XTagManager : XtraForm
    {
        private string _lblValueInfo = string.Empty;
        private List<Channel> bChannelEthernet;
        private List<DIEthernet> bDIEthernet;
        private List<DISerialPort> bDISerialPort;
        private BindingList<Tag> bS7Tags;
        private List<DataBlock> bvDataBlock;
        private List<Device> bvDevice;
        public bool IsDataChanged;
        private ChannelService objChannelManager;
        private DataBlockService objDataBlockManager;
        private DeviceService objDeviceManager;
        private TagService objTagManager;
        private string[] SelectebNodesHelpr;

        private Device result;
        private Channel fCh;
        private Channel fChNew;
        private Device dvNewCopy;
        private DataBlock dbNewCopy;
        private Tag tgNewCopy;
        public string SelecteCopy_Paste;
        public TreeListNode node = null;

        public XTagManager()
        {
            InitializeComponent();
        }
        public void GettreeListChannel()
        {
            TreeListNode node = null;
            TreeListNode node2 = null;
            TreeListNode node3 = null;

            treeList1.Nodes.Clear();
            foreach (var ch in objChannelManager.Channels)
            {
                var dvList = new List<TreeNode>();
                ////Sort.
                ch.Devices.Sort(delegate (Device x, Device y) { return x.DeviceName.CompareTo(y.DeviceName); });
                node = treeList1.AppendNode(new object[] { ch.ChannelName }, null);
                node.StateImageIndex = 1;
                foreach (var dv in ch.Devices)
                {
                    var tgList = new List<TreeNode>();
                    node2 = treeList1.AppendNode(new object[] { dv.DeviceName }, node);
                    node2.StateImageIndex = 0;
                    foreach (var db in dv.DataBlocks)
                    {
                        tgList.Add(new TreeNode(db.DataBlockName));
                        node3 = treeList1.AppendNode(new object[] { db.DataBlockName }, node2);
                        node3.StateImageIndex = 7;
                    }
                    var dvNode = new TreeNode(dv.DeviceName, tgList.ToArray());
                }

                var chNode = new TreeNode(ch.ChannelName, dvList.ToArray());
            }

           
        }
        public void InitializeData(string xmlPath = "")
        {

            TreeListNode node = null;
            TreeListNode node2 = null;
            TreeListNode node3 = null;
            objChannelManager.Channels.Clear();
            objChannelManager.XmlPath = xmlPath;
            var chList = objChannelManager.GetChannels(xmlPath);
            treeList1.Nodes.Clear();
            foreach (var ch in chList)
            {
                ////Sort.
                ch.Devices.Sort(delegate (Device x, Device y) { return x.DeviceName.CompareTo(y.DeviceName); });
                node = treeList1.AppendNode(new object[] { ch.ChannelName }, null);
                node.StateImageIndex = 1;
                foreach (var dv in ch.Devices)
                {
                    node2 = treeList1.AppendNode(new object[] { dv.DeviceName }, node);
                    node2.StateImageIndex = 0;
                    foreach (var db in dv.DataBlocks)
                    {
                        node3 = treeList1.AppendNode(new object[] { db.DataBlockName }, node2);
                        node3.StateImageIndex = 7;
                    }

                }

            }

        }

        private void barButtonNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog { Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*", FileName = objChannelManager.XML_NAME_DEFAULT };
                var dr = saveFileDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var xmlPath = saveFileDialog.FileName;
                    objChannelManager.CreatFile(xmlPath);
                    treeList1.Nodes.Clear();

                    objChannelManager.Channels.Clear();
                    IsDataChanged = true;
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void barButtonOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog { /* Show the dialog and get result.*/Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*", FileName = "config" };
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    //   InitializeData(openFileDialog.FileName);
                    objChannelManager.Channels.Clear();
                    objChannelManager.XmlPath = openFileDialog.FileName;
                    var chList = objChannelManager.GetChannels(openFileDialog.FileName);

                    InitializeData(openFileDialog.FileName);
                    IsDataChanged = true;
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void barButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                objChannelManager.Save(objChannelManager.XmlPath);
                MessageBox.Show(this, "Data saved successfully!", "INFORMATION", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                IsDataChanged = false;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        #region treeList
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

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node == null) return;
                var s = FullNameByNode(e.Node, 0);
                SelectebNodesHelpr = s.Split('\\');
                var SelectebNodes = treeList1.Selection;
                DataBlock dbCurrent = null; //Node: DataBlock
                Device dvCurrent = null; //Node: Device
                Channel chCurrent = null; //Node: Channel
                Selection();
                switch (SelectebNodes[0].Level)
                {
                    case 0:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.GetDisplayText(0));

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
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.GetDisplayText(0));
                        bvDevice.Add(dvCurrent);
                        vGridDevice.DataSource = bvDevice;
                        break;
                    case 2:
                        var dbNode = SelectebNodes[0]; // Node:DataBlock
                        var dvNode = dbNode.ParentNode; // Node:Device
                        var chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var DeviceName = dvNode["Name"].ToString();
                        var DataBlockName = dbNode["Name"].ToString();


                        chCurrent = objChannelManager.GetByChannelName(channelName);
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);

                        bvDataBlock = new List<DataBlock>();
                        bvDataBlock.Add(dbCurrent);
                        vGridDataBlock.DataSource = bvDataBlock;


                        bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                        gridControl1.DataSource = bS7Tags;
                        gridControl1.Invalidate();
                        //  barStaticITagCount.Caption = Convert.ToString(bS7Tags.Count);
                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        private void Selection()
        {
            var SelectebNodes = treeList1.Selection;
            if (SelectebNodes[0] == null) return;
            var Level = SelectebNodes[0].Level;
            switch (Level)
            {
                case 0:
                    ItemAddChannel.Enabled = true;
                    ItemAddDevice.Enabled = true;
                    ItemAddDataBlock.Enabled = false;
                    ItemAddTag.Enabled = false;
                    break;
                case 1:
                    ItemAddChannel.Enabled = false;
                    ItemAddDevice.Enabled = true;
                    ItemAddDataBlock.Enabled = true;
                    ItemAddTag.Enabled = false;
                    break;
                case 2:
                    ItemAddChannel.Enabled = false;
                    ItemAddDevice.Enabled = false;
                    ItemAddDataBlock.Enabled = true;
                    ItemAddTag.Enabled = true;
                    break;
            }
        }

        private void treeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var SelectebNodes = treeList1.Selection;
                if (e.Button != MouseButtons.Left) return;
                var Level = SelectebNodes[0].Level;

                Channel chCurrent = null;
                Device dvCurrent = null;
                DataBlock dbCurrent = null;
                switch (Level)
                {
                    case 0:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.GetDisplayText(0));

                        var chFrm = new XChannelForm(chCurrent.ChannelTypes, objChannelManager, chCurrent);
                        chFrm.eventChannelChanged += (ch, isNew) =>
                        {
                            if (!isNew) objChannelManager.Update(ch);

                            treeList1.SetRowCellValue(treeList1.FocusedNode, "Name", ch.ChannelName);
                        };
                        chFrm.StartPosition = FormStartPosition.CenterScreen;
                        chFrm.ShowDialog();


                        break;
                    case 1:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.GetDisplayText(0));

                        var dvFrm = new XDeviceForm(chCurrent, dvCurrent);
                        dvFrm.eventDeviceChanged += (dv, isNew) =>
                        {
                            if (!isNew) objDeviceManager.Update(chCurrent, dv);
                            treeList1.SetRowCellValue(treeList1.FocusedNode, "Name", dv.DeviceName);
                        };
                        dvFrm.StartPosition = FormStartPosition.CenterScreen;
                        dvFrm.ShowDialog();

                        break;
                    case 2:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, treeList1.FocusedNode.GetDisplayText(0));

                        var dbFrm = new XDataBlockForm(chCurrent, dvCurrent, dbCurrent);
                        dbFrm.eventDataBlockChanged += (db, isNew) =>
                        {
                            if (!isNew) objDataBlockManager.Update(dvCurrent, db);
                            treeList1.SetRowCellValue(treeList1.FocusedNode, "Name", db.DataBlockName);
                            gridControl1.RefreshDataSource();
                        };
                        dbFrm.StartPosition = FormStartPosition.CenterScreen;
                        dbFrm.ShowDialog();

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    Selection();
                    popupMenuLeft.ShowPopup(MousePosition);
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        #endregion
        #region GridControl
        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Channel chCurrent = null;
                Device dvCurrent = null;
                DataBlock dbCurrent = null;
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");
                if (selectebNodes[0].Level == 2)
                {
                    var dbNode = selectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var deviceName = dvNode["Name"].ToString();
                    ;
                    var dataBlockName = dbNode["Name"].ToString();


                    chCurrent = objChannelManager.GetByChannelName(channelName);
                    dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, deviceName);
                    dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, dataBlockName);

                    var obj = gridView1.GetFocusedRowCellValue(colTagName);
                    var tgName = obj.ToString();
                    if (obj != null)
                    {
                        var tagName = $"{channelName}.{deviceName}.{dataBlockName}.{tgName}";
                        _lblValueInfo = tagName;
                        var tgCurrent = objTagManager.GetByTagName(dbCurrent, tgName);

                        var tgFrm = new XTagForm(chCurrent, dvCurrent, dbCurrent, tgCurrent);
                        tgFrm.eventTagChanged += (tg, isNew) =>
                        {
                            objTagManager.Update(dbCurrent, tgCurrent);

                            gridControl1.RefreshDataSource();
                            IsDataChanged = true;
                        };
                        tgFrm.StartPosition = FormStartPosition.CenterScreen;
                        tgFrm.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right) popupMenuRight.ShowPopup(MousePosition);
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }



        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");
                if (selectebNodes[0].Level == 2)
                {
                    var dbNode = selectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var deviceName = dvNode["Name"].ToString();

                    var dataBlockName = dbNode["Name"].ToString();


                    var obj = gridView1.GetFocusedRowCellValue(colTagName);
                    var tgName = obj.ToString();
                    if (obj != null)
                    {
                        var tagName = $"{channelName}.{deviceName}.{dataBlockName}.{tgName}";
                        _lblValueInfo = tagName;
                    }
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }




        private void XtraTagManager_Load(object sender, EventArgs e)
        {
            objChannelManager = ChannelService.GetChannelManager();
            objDeviceManager = DeviceService.GetDeviceManager();
            objDataBlockManager = DataBlockService.GetDataBlockManager();
            objTagManager = TagService.GetTagManager();
            var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
            if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
            InitializeData(xmlFile);

        }
        #endregion
        #region Add
       
        public void OpenWaitForm()
        {
            ////Open Wait Form
            //SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            ////The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            //for (var i = 1; i <= 100; i++)
            //{
            //    SplashScreenManager.Default.SetWaitFormDescription(i + "%");
            //    Thread.Sleep(25);
            //}

            ////Close Wait Form
            //SplashScreenManager.CloseForm(false);
        }


        private void ItemAddChannel_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var DriverFrm = new XSelectedDrivers();

                if (DriverFrm.ShowDialog() == DialogResult.OK)
                {

                    var chFrm = new XChannelForm(DriverFrm.cboxSelectedDrivers.Text, objChannelManager, null);
                    chFrm.eventChannelChanged += (ch, isNew) =>
                    {
                        try
                        {
                            if (isNew) objChannelManager.Add(ch);
                            else objChannelManager.Update(ch);
                            if (treeList1.Nodes.Count > 0)
                            {
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { ch.ChannelName },
                                    treeList1.FocusedNode.ParentNode);
                                treeList1.FocusedNode.StateImageIndex = 1;


                            }
                            else
                            {
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { ch.ChannelName }, null);
                                treeList1.FocusedNode.StateImageIndex = 1;
                            }



                            IsDataChanged = true;
                        }
                        catch (Exception ex)
                        {

                           EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                        }
                    };
                    chFrm.ShowDialog();
                }

            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemAddDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectebNodes = treeList1.Selection;
            if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");
            Channel chCurrent = null;
            XDeviceForm dvFrm = null;
            try
            {
                var Level = selectebNodes[0].Level;
                switch (Level)
                {
                    case 0:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.GetDisplayText(0));
                        break;
                    case 1:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        break;
                }


                dvFrm = new XDeviceForm(chCurrent);
                dvFrm.eventDeviceChanged += (dv, isNew) =>
                {
                    try
                    {
                        if (isNew) objDeviceManager.Add(chCurrent, dv);
                        else objDeviceManager.Update(chCurrent, dv);
                        switch (Level)
                        {
                            case 0:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { dv.DeviceName },
                                    treeList1.FocusedNode);
                                treeList1.FocusedNode.StateImageIndex = 0;
                                IsDataChanged = true;
                                break;
                            case 1:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { dv.DeviceName },
                                    treeList1.FocusedNode.ParentNode);
                                IsDataChanged = true;
                                break;
                        }

                    }
                    catch (Exception ex)
                    {

                       EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                    }
                };
                dvFrm.ShowDialog();


            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemAddDataBlock_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Channel chCurrent = null;
                Device dvCurrent = null;
                XDataBlockForm dbFrm = null;
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");


                var Level = selectebNodes[0].Level;
                switch (Level)
                {
                    case 1:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.GetDisplayText(0));
                        break;
                    case 2:
                        chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.ParentNode.GetDisplayText(0));
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        break;
                }

                dbFrm = new XDataBlockForm(chCurrent, dvCurrent);
                dbFrm.eventDataBlockChanged += (db, isNew) =>
                {
                    try
                    {
                        if (isNew) objDataBlockManager.Add(dvCurrent, db);
                        else objDataBlockManager.Update(dvCurrent, db);
                        switch (Level)
                        {
                            case 1:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { db.DataBlockName },
                                    treeList1.FocusedNode);
                                treeList1.FocusedNode.StateImageIndex = 7;

                                IsDataChanged = true;
                                break;
                            case 2:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { db.DataBlockName },
                                    treeList1.FocusedNode.ParentNode);
                                treeList1.FocusedNode.StateImageIndex = 7;

                                IsDataChanged = true;
                                break;
                        }
                        gridControl1.RefreshDataSource();

                    }
                    catch (Exception ex)
                    {

                       EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                    }
                };
                dbFrm.ShowDialog();

            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemAddTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                var SelectebNodes = treeList1.Selection;
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                if (SelectebNodes[0].Level == null) return;
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
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

                        var chCurrent = objChannelManager.GetByChannelName(treeList1.FocusedNode.ParentNode.ParentNode.GetDisplayText(0));
                        var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, treeList1.FocusedNode.ParentNode.GetDisplayText(0));
                        var dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, treeList1.FocusedNode.GetDisplayText(0));


                        var tgFrm = new XTagForm(chCurrent, dvCurrent, dbCurrent);
                        tgFrm.eventTagChanged += (tg, isNew) =>
                        {
                            try
                            {
                                if (isNew) objTagManager.Add(dbCurrent, tg);
                                else objTagManager.Update(dbCurrent, tg);
                                bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                                gridControl1.DataSource = bS7Tags;
                                gridView1.Invalidate();
                            }
                            catch (Exception ex)
                            {

                               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                            }
                        };
                        tgFrm.ShowDialog();

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataBlock dbCurrent;
            try
            {
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");

                switch (selectebNodes[0].Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        var dbNode = selectebNodes[0]; // Node:DataBlock
                        var dvNode = dbNode.ParentNode; // Node:Device
                        var chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var deviceName = dvNode["Name"].ToString();
                        var dataBlockName = dbNode["Name"].ToString();

                        var chCurrent = objChannelManager.GetByChannelName(channelName);
                        var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, deviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, dataBlockName);
                        var frm = new FormImport(chCurrent, dvCurrent, dbCurrent);
                        foreach (Form form in Application.OpenForms)
                            if (form.GetType() == typeof(FormImport))
                            {
                                form.Activate();
                                return;
                            }
                        frm.eventDataBlockChanged += db =>
                        {
                            try
                            {
                                IsDataChanged = true;
                                bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                                gridControl1.DataSource = bS7Tags;
                                gridControl1.Invalidate();
                                gridControl1.RefreshDataSource();
                            }
                            catch (Exception ex)
                            {

                               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                            }
                        };

                        frm.ShowDialog();

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Creating a Excel object.
                using (var p = new ExcelPackage())
                {
                    // List Channels.
                    var chCurrent = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                    p.Workbook.Properties.Author = chCurrent.ChannelName;
                    p.Workbook.Properties.Title = chCurrent.ConnectionType;
                    p.Workbook.Properties.Company = chCurrent.ConnectionType;
                    var cellRowIndex = 1;
                    var cellColumnIndex = 1;
                    // List Devices.
                    foreach (var dv in chCurrent.Devices)
                    {
                        if (dv.DataBlocks.Count == 0) continue;
                        // List DataBlock.
                        var Worksheets = 1;
                        foreach (var db in dv.DataBlocks)
                        {
                            cellRowIndex = 1;
                            cellColumnIndex = 1;
                            // The rest of our code will go here...
                            p.Workbook.Worksheets.Add(db.DataBlockName);
                            // 1 is the position of the worksheet
                            var ws = p.Workbook.Worksheets[Worksheets];
                            ws.Name = db.DataBlockName + chCurrent.ChannelId;
                            for (var j = 0; j < gridView1.Columns.Count; j++)
                            {
                                // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
                                if (cellRowIndex == 1)
                                {
                                    var cell_actionName = ws.Cells[cellRowIndex, cellColumnIndex];
                                    cell_actionName.Value = gridView1.Columns[j].GetTextCaption();
                                }

                                cellColumnIndex++;
                            }

                            cellRowIndex++;
                            // List Tags.
                            foreach (var tg in db.Tags)
                            {
                                cellColumnIndex = 1;
                                var TagId = ws.Cells[cellRowIndex, cellColumnIndex];
                                TagId.Value = tg.TagId;
                                cellColumnIndex++;
                                var TagName = ws.Cells[cellRowIndex, cellColumnIndex];
                                TagName.Value = tg.TagName;
                                cellColumnIndex++;
                                var Address = ws.Cells[cellRowIndex, cellColumnIndex];
                                Address.Value = tg.Address;
                                cellColumnIndex++;
                                var DataType = ws.Cells[cellRowIndex, cellColumnIndex];
                                DataType.Value = tg.DataType;
                                cellColumnIndex++;
                                var Desp = ws.Cells[cellRowIndex, cellColumnIndex];
                                Desp.Value = tg.Description;
                                cellRowIndex++;
                            }

                            Worksheets++;
                        }
                    }

                    //Getting the location and file name of the excel to save from user.
                    var saveDialog = new SaveFileDialog { Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*", FilterIndex = 1, FileName = "DataBlockName" };
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var bin = p.GetAsByteArray();
                        File.WriteAllBytes(saveDialog.FileName, bin);
                        MessageBox.Show("Export Successful");
                    }
                }

            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var SelectebNodes = treeList1.Selection;
                var Level = SelectebNodes[0].Level;
                if (SelectebNodes[0] == null) return;
                fChNew = null;
                dvNewCopy = null;
                dvNewCopy = null;
                switch (Level)
                {
                    case 0:

                        fChNew = new Channel();
                        fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                        fChNew = objChannelManager.Copy(fCh);
                        SelecteCopy_Paste = "Channel";
                        break;
                    case 1:
                        dvNewCopy = new Device();
                        fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                        result = objDeviceManager.GetByDeviceName(fCh, SelectebNodesHelpr[1]);
                        dvNewCopy = objDeviceManager.Copy(result, fCh);
                        SelecteCopy_Paste = "Device";
                        break;
                    case 2:
                        dbNewCopy = new DataBlock();
                        fChNew = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                        dvNewCopy = objDeviceManager.GetByDeviceName(fChNew, SelectebNodesHelpr[1]);
                        var dbCurrent = objDataBlockManager.GetByDataBlockName(dvNewCopy, SelectebNodesHelpr[2]);
                        dbNewCopy = objDataBlockManager.Copy(dbCurrent, dvNewCopy);
                        SelecteCopy_Paste = "DataBlock";

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }

        private void ItemPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var SelectebNodes = treeList1.Selection;
                var Level = SelectebNodes[0].Level;
                if (SelectebNodes[0] == null) return;


                switch (SelecteCopy_Paste)
                {
                    case "Channel":
                        switch (fCh.ConnectionType)
                        {
                            case "SerialPort":
                                objChannelManager.Add((DISerialPort)fChNew);
                                break;
                            case "Ethernet":
                                objChannelManager.Add((DIEthernet)fChNew);

                                break;
                        }


                        break;
                    case "Device":
                        fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                        objDeviceManager.Add(fCh, dvNewCopy);

                        break;
                    case "DataBlock":
                        fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                        dvNewCopy = objDeviceManager.GetByDeviceName(fCh, SelectebNodesHelpr[1]);
                        objDataBlockManager.Add(dvNewCopy, dbNewCopy);


                        break;
                }
                GettreeListChannel(); IsDataChanged = true;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

            try
            {
                var SelectebNodes = treeList1.Selection;
                var Level = SelectebNodes[0].Level;
                if (SelectebNodes[0] == null) return;

                DialogResult result;
                switch (Level)
                {
                    case 0:
                        result = MessageBox.Show(this,
                            $"Are you sure delete channel: {SelectebNodesHelpr[0]}?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                            objChannelManager.Delete(fCh);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                    case 1:
                        result = MessageBox.Show(this,
                            $"Are you sure delete device: {SelectebNodesHelpr[0]} of the channel: {SelectebNodesHelpr[1]}?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var fCh = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                            objDeviceManager.Delete(fCh, SelectebNodesHelpr[1]);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                    case 2:
                        result = MessageBox.Show(this,
                            $"Are you sure delete datablock: {SelectebNodesHelpr[0]} of the device: {SelectebNodesHelpr[1]}, channel: {SelectebNodesHelpr[2]}?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var chCurrent = objChannelManager.GetByChannelName(SelectebNodesHelpr[0]);
                            var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, SelectebNodesHelpr[1]);
                            var dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, SelectebNodesHelpr[2]);
                            objDataBlockManager.Delete(dvCurrent, dbCurrent);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        #endregion
        #region popupMenuRight
        private void RItemAddTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Channel chCurrent = null;
                Device dvCurrent = null;
                DataBlock dbCurrent = null;
                var SelectebNodes = treeList1.Selection;
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                if (SelectebNodes[0].Level == null) return;
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
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

                        var DataBlockName = dbNode["Name"].ToString();


                        chCurrent = objChannelManager.GetByChannelName(channelName);
                        dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, DeviceName);
                        dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, DataBlockName);

                        var tgFrm = new XTagForm(chCurrent, dvCurrent, dbCurrent);
                        tgFrm.eventTagChanged += (tg, isNew) =>
                        {
                            try
                            {
                                if (isNew) objTagManager.Add(dbCurrent, tg);
                                else objTagManager.Update(dbCurrent, tg);

                                bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                                gridControl1.DataSource = bS7Tags;
                                gridView1.Invalidate();
                            }
                            catch (Exception ex)
                            {

                               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                            }
                        };
                        tgFrm.ShowDialog();

                        break;
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemCopyToTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_lblValueInfo == string.Empty) return;
            Clipboard.SetText(_lblValueInfo);
        }

        private void mDeleteTag_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException($"{"sender"}");
                Selection();
                switch (selectebNodes[0].Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        var dbNode = selectebNodes[0]; // Node:DataBlock
                        var dvNode = dbNode.ParentNode; // Node:Device
                        var chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var deviceName = dvNode["Name"].ToString();
                        var dataBlockName = dbNode["Name"].ToString();

                        var obj = gridView1.GetFocusedRowCellValue(colTagName);
                        if (obj != null)
                        {
                            var chCurrent = objChannelManager.GetByChannelName(channelName); //Node: Channel
                            var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, deviceName); //Node: Device
                            var dbCurrent =
                                objDataBlockManager.GetByDataBlockName(dvCurrent, dataBlockName); //Node: DataBlock
                            objTagManager.Delete(dbCurrent, obj.ToString());
                            gridControl1.RefreshDataSource();
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void RItemCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Channel chCurrent = null;
                Device dvCurrent = null;
                DataBlock dbCurrent = null;
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");
                if (selectebNodes[0].Level == 2)
                {
                    var dbNode = selectebNodes[0]; // Node:DataBlock
                    var dvNode = dbNode.ParentNode; // Node:Device
                    var chNode = dvNode.ParentNode; // Node:Channel


                    var channelName = chNode["Name"].ToString();
                    var deviceName = dvNode["Name"].ToString();
                    ;
                    var dataBlockName = dbNode["Name"].ToString();


                    chCurrent = objChannelManager.GetByChannelName(channelName);
                    dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, deviceName);
                    dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, dataBlockName);

                    var obj = gridView1.GetFocusedRowCellValue(colTagName);
                    var tgName = obj.ToString();
                    if (obj != null)
                    {
                        var tagName = $"{channelName}.{deviceName}.{dataBlockName}.{tgName}";
                        _lblValueInfo = tagName;
                        var tgCurrent = objTagManager.GetByTagName(dbCurrent, tgName);
                        tgNewCopy = new Tag();


                        tgNewCopy.TagName = tgCurrent.TagName + "New";
                        tgNewCopy.TagId = dbCurrent.Tags.Count + 1;
                        tgNewCopy.Address = tgCurrent.Address;
                        tgNewCopy.ChannelId = tgCurrent.ChannelId;
                        tgNewCopy.DeviceId = tgCurrent.DeviceId;
                        tgNewCopy.DataBlockId = tgCurrent.DataBlockId;
                        tgNewCopy.DataType = tgCurrent.DataType;
                        tgNewCopy.Description = tgCurrent.Description;
                    }
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void RItemPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException($"{"sender"}");
                Selection();
                switch (selectebNodes[0].Level)
                {
                    case 0:

                        break;
                    case 1:
                        break;
                    case 2:
                        var dbNode = selectebNodes[0]; // Node:DataBlock
                        var dvNode = dbNode.ParentNode; // Node:Device
                        var chNode = dvNode.ParentNode; // Node:Channel


                        var channelName = chNode["Name"].ToString();
                        var deviceName = dvNode["Name"].ToString();
                        var dataBlockName = dbNode["Name"].ToString();


                        var chCurrent = objChannelManager.GetByChannelName(channelName); //Node: Channel
                        var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, deviceName); //Node: Device
                        var dbCurrent =
                            objDataBlockManager.GetByDataBlockName(dvCurrent, dataBlockName); //Node: DataBlock
                        dbCurrent.Tags.Add(tgNewCopy);
                        gridControl1.RefreshDataSource();


                        break;
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