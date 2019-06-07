using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using AdvancedScada.DriverBase.Devices;
using DevExpress.XtraTreeList;
using AdvancedScada.Management.BLManager;
using DevExpress.XtraGrid.Views.Base;

namespace AdvancedScada.Studio.Monitor
{
    public partial class PLC_MonitorForm2 : DevExpress.XtraEditors.XtraForm
    {
        private string SelectedTagName = string.Empty;

        private BindingSource bsSource;
        private ChannelService objChannelManager;
        private DataBlockService objDataBlockManager;
        private DeviceService objDeviceManager;
        private TagService objTagManager;
        public PLC_MonitorForm2()
        {
            InitializeComponent();
        }

        private void PLC_MonitorForm2_Load(object sender, EventArgs e)
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
                gvTags.Appearance.FocusedRow.BackColor = Color.Yellow;
                gvTags.Appearance.FocusedRow.ForeColor = Color.Black;
                gvTags.Appearance.HideSelectionRow.BackColor = gvTags.Appearance.FocusedRow.BackColor;
                gvTags.Appearance.HideSelectionRow.ForeColor = Color.Black;
                bsSource = new BindingSource();
                gcTags.DataSource = bsSource;
                InitializeTreeList(objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void InitializeTreeList(string xmlPath)
        {
           
            try
            {
                treeList1.ClearNodes();
                TreeListNode treeListNode = treeList1.AppendNode(null, null);
                treeListNode.SetValue("Name", "SIMATIC NET");
                treeListNode.ImageIndex = 0;
                objChannelManager.Channels.Clear();
                objChannelManager.XmlPath = xmlPath;
                var chList = objChannelManager.GetChannels(xmlPath);
                if (chList != null)
                {
                    foreach (Channel channel in chList)
                    {
                        TreeListNode treeListNode2 = treeList1.AppendNode(null, treeListNode);
                        AddChannelNode(treeListNode2, channel);
                        if (channel.Devices != null)
                        {
                            foreach (Device device in channel.Devices)
                            {
                                TreeListNode treeListNode3 = treeList1.AppendNode(null, treeListNode2);
                                AddDeviceNode(treeListNode3, device);
                                if (device.DataBlocks != null)
                                {
                                    foreach (DataBlock dataBlock in device.DataBlocks)
                                    {
                                        TreeListNode dbNode = treeList1.AppendNode(null, treeListNode3);
                                        AddDataBlockNode(dbNode, dataBlock);
                                    }
                                }
                            }
                        }
                    }
                    treeList1.ExpandAll();
                }
            }
           
            catch (Exception ex2)
            {
                XtraMessageBox.Show(this, ex2.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void AddChannelNode(TreeListNode chNode, Channel ch)
        {
            chNode.SetValue("Name", ch.ChannelName);
            chNode.SetValue("ChannelId", ch.ChannelId);
            chNode.ImageIndex = 1;
        }

        public void AddDeviceNode(TreeListNode dvNode, Device dv)
        {
            dvNode.SetValue("Name", dv.DeviceName);
            dvNode.SetValue("DeviceId", dv.DeviceId);
            dvNode.ImageIndex = 2;
        }

        public void AddDataBlockNode(TreeListNode dbNode, DataBlock db)
        {
            dbNode.SetValue("Name", db.DataBlockName);
            dbNode.SetValue("DataBlockId", db.DataBlockId);
            dbNode.ImageIndex = 3;
        }
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeListMultiSelection selection = treeList1.Selection;
            try
            {
                if (selection.Count != 0)
                {
                    Channel channel = null;
                    Device device = null;
                    DataBlock dataBlock = null;
                    selection[0].ImageIndex = selection[0].Level;
                    switch (selection[0].Level)
                    {
                        case 1:
                            {
                                short num = short.Parse(selection[0]["ChannelId"].ToString());
                                channel = objChannelManager.GetByChannelId(num);
                                break;
                            }
                        case 2:
                            {
                                TreeListNode treeListNode2 = selection[0];
                                short num = short.Parse(treeListNode2.ParentNode["ChannelId"].ToString());
                                short deviceId = short.Parse(treeListNode2["DeviceId"].ToString());
                                channel = objChannelManager.GetByChannelId(num);
                                device = objDeviceManager.GetByDeviceId(channel, deviceId);
                                break;
                            }
                        case 3:
                            {
                                TreeListNode treeListNode = selection[0];
                                TreeListNode parentNode = treeListNode.ParentNode;
                                short num = short.Parse(parentNode.ParentNode["ChannelId"].ToString());
                                short deviceId = short.Parse(parentNode["DeviceId"].ToString());
                                short dataBlockId = short.Parse(treeListNode["DataBlockId"].ToString());
                                channel = objChannelManager.GetByChannelId(num);
                                device = objDeviceManager.GetByDeviceId(channel, deviceId);
                                dataBlock = objDataBlockManager.GetByDataBlockId(device, dataBlockId);
                                if (dataBlock.MemoryType == "Datablock")
                                {
                                    gvTags.ViewCaption = $"Memory Type: {dataBlock.MemoryType} | DataBlock Name: {dataBlock.DataBlockName} | DataBlock Name: DB{dataBlock.StartAddress}".ToUpper();
                                }
                                else
                                {
                                    gvTags.ViewCaption = $"Memory Type: {dataBlock.MemoryType}".ToUpper();
                                }
                                bsSource.DataSource = dataBlock.Tags;
                                colTagName.BestFit();
                                break;
                            }
                    }
                    if (channel == null)
                    {
                        propertyGridChannel.Visible = false;
                    }
                    else
                    {
                        propertyGridChannel.SelectedObject = channel;
                        propertyGridChannel.Visible = true;
                    }
                    if (device != null)
                    {
                        propertyGridDevice.SelectedObject = device;
                        propertyGridDevice.Visible = true;
                    }
                    else
                    {
                        propertyGridDevice.Visible = false;
                    }
                    if (dataBlock != null)
                    {
                        propertyGridDataBlock.SelectedObject = dataBlock;
                        propertyGridDataBlock.Visible = true;
                        if (dataBlock.Tags != null)
                        {
                            lblTagCount.Caption = $"Total: {dataBlock.Tags.Count} tags";
                        }
                    }
                    else
                    {
                        propertyGridDataBlock.Visible = false;
                        lblTagCount.Caption = $"Total: {0} tags";
                        lblSelectedTagName.Caption = string.Format("Selected tag: {0}", "None");
                    }
                }
            }
           
            catch (Exception ex2)
            {
                XtraMessageBox.Show(this, ex2.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void gcTags_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //if (OnTagSelected_Clicked != null && !string.IsNullOrEmpty(SelectedTagName) && !string.IsNullOrWhiteSpace(SelectedTagName))
                //{
                //    OnTagSelected_Clicked(SelectedTagName);
                //    base.DialogResult = DialogResult.OK;
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void gvTags_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            try
            {
                if (treeList1.Selection[0].Level == 3)
                {
                    SelectedTagName = GetSelectedTag();
                    lblSelectedTagName.Caption = $"Selected tag: {SelectedTagName}";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string GetSelectedTag()
        {
            string result = null;
            try
            {
                TreeListMultiSelection selection = treeList1.Selection;
                if (selection[0].Level != 3)
                {
                    return result;
                }
                TreeListNode treeListNode = selection[0];
                TreeListNode parentNode = treeListNode.ParentNode;
                string text = parentNode.ParentNode["Name"].ToString();
                string text2 = parentNode["Name"].ToString();
                string text3 = treeListNode["Name"].ToString();
                object focusedRowCellValue = gvTags.GetFocusedRowCellValue(colTagName);
                if (focusedRowCellValue == null)
                {
                    return result;
                }
                string text4 = focusedRowCellValue.ToString();
                result = $"{text}.{text2}.{text3}.{text4}";
                return result;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return result;
            }
        }
    }
}