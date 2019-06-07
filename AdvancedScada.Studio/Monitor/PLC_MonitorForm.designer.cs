using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace AdvancedScada.Studio.Monitor
{
	 
	public partial class PLC_MonitorForm : DevExpress.XtraEditors.XtraForm
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLC_MonitorForm));
            this.DockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.BarManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.Bar3 = new DevExpress.XtraBars.Bar();
            this.BarTagName = new DevExpress.XtraBars.BarStaticItem();
            this.lblSelectedTag = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.BarStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.mWriteTagValue = new DevExpress.XtraBars.BarButtonItem();
            this.mSetON = new DevExpress.XtraBars.BarButtonItem();
            this.mSetOFF = new DevExpress.XtraBars.BarButtonItem();
            this.PopupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.DockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.TreeList1 = new DevExpress.XtraTreeList.TreeList();
            this.ChannelName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dockPanel4 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.vGridDataBlock = new DevExpress.XtraVerticalGrid.VGridControl();
            this.category = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vGridDevice = new DevExpress.XtraVerticalGrid.VGridControl();
            this.catDevice = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.colDeviceName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colSlaveId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colDeviceDesp = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vGridChannel = new DevExpress.XtraVerticalGrid.VGridControl();
            this.catChannel = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.colConnectionType = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colChannelName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colDescription2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vGridSerialPort = new DevExpress.XtraVerticalGrid.VGridControl();
            this.catSerialPort = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.colPortName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colBaudRate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colDataBits = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colStopBits = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colDescription3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.vGridEthernet = new DevExpress.XtraVerticalGrid.VGridControl();
            this.catEthernet = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.colIPAddress = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.colPort = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.RealTimeSource1 = new DevExpress.Data.RealTimeSource();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTagId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu1)).BeginInit();
            this.DockPanel2.SuspendLayout();
            this.DockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).BeginInit();
            this.dockPanel4.SuspendLayout();
            this.dockPanel4_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridDataBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridSerialPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridEthernet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DockManager1
            // 
            this.DockManager1.Form = this;
            this.DockManager1.MenuManager = this.BarManager1;
            this.DockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.DockPanel2,
            this.dockPanel4});
            this.DockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // BarManager1
            // 
            this.BarManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.Bar3});
            this.BarManager1.DockControls.Add(this.barDockControlTop);
            this.BarManager1.DockControls.Add(this.barDockControlBottom);
            this.BarManager1.DockControls.Add(this.barDockControlLeft);
            this.BarManager1.DockControls.Add(this.barDockControlRight);
            this.BarManager1.DockManager = this.DockManager1;
            this.BarManager1.Form = this;
            this.BarManager1.Images = this.imageCollection1;
            this.BarManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarStaticItem1,
            this.BarTagName,
            this.lblSelectedTag,
            this.mWriteTagValue,
            this.mSetON,
            this.mSetOFF});
            this.BarManager1.MaxItemId = 13;
            this.BarManager1.StatusBar = this.Bar3;
            // 
            // Bar3
            // 
            this.Bar3.BarName = "Status bar";
            this.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.Bar3.DockCol = 0;
            this.Bar3.DockRow = 0;
            this.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.Bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarTagName),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSelectedTag, true)});
            this.Bar3.OptionsBar.AllowQuickCustomization = false;
            this.Bar3.OptionsBar.DrawDragBorder = false;
            this.Bar3.OptionsBar.UseWholeRow = true;
            this.Bar3.Text = "Status bar";
            // 
            // BarTagName
            // 
            this.BarTagName.Caption = "TagName:";
            this.BarTagName.Id = 7;
            this.BarTagName.Name = "BarTagName";
            // 
            // lblSelectedTag
            // 
            this.lblSelectedTag.Caption = "TagName:";
            this.lblSelectedTag.Id = 8;
            this.lblSelectedTag.Name = "lblSelectedTag";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1276, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 590);
            this.barDockControlBottom.Manager = this.BarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1276, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 590);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1276, 0);
            this.barDockControlRight.Manager = this.BarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 590);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Build_16x16.png");
            // 
            // BarStaticItem1
            // 
            this.BarStaticItem1.Caption = "BarStaticItem1";
            this.BarStaticItem1.Id = 1;
            this.BarStaticItem1.Name = "BarStaticItem1";
            // 
            // mWriteTagValue
            // 
            this.mWriteTagValue.Caption = "WriteTagValue";
            this.mWriteTagValue.Id = 10;
            this.mWriteTagValue.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mWriteTagValue.ImageOptions.Image")));
            this.mWriteTagValue.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mWriteTagValue.ImageOptions.LargeImage")));
            this.mWriteTagValue.Name = "mWriteTagValue";
            this.mWriteTagValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mWriteTagValue_ItemClick);
            // 
            // mSetON
            // 
            this.mSetON.Caption = "Set ON";
            this.mSetON.Id = 11;
            this.mSetON.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mSetON.ImageOptions.Image")));
            this.mSetON.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mSetON.ImageOptions.LargeImage")));
            this.mSetON.Name = "mSetON";
            this.mSetON.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mSetON_ItemClick);
            // 
            // mSetOFF
            // 
            this.mSetOFF.Caption = "Set OFF";
            this.mSetOFF.Id = 12;
            this.mSetOFF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mSetOFF.ImageOptions.Image")));
            this.mSetOFF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mSetOFF.ImageOptions.LargeImage")));
            this.mSetOFF.Name = "mSetOFF";
            this.mSetOFF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mSetOFF_ItemClick);
            // 
            // PopupMenu1
            // 
            this.PopupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mWriteTagValue, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.mSetON),
            new DevExpress.XtraBars.LinkPersistInfo(this.mSetOFF)});
            this.PopupMenu1.Manager = this.BarManager1;
            this.PopupMenu1.Name = "PopupMenu1";
            // 
            // DockPanel2
            // 
            this.DockPanel2.Controls.Add(this.DockPanel2_Container);
            this.DockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.DockPanel2.ID = new System.Guid("b9eb39e1-9505-4ba9-8dfd-d64503fc6df7");
            this.DockPanel2.Location = new System.Drawing.Point(0, 0);
            this.DockPanel2.Name = "DockPanel2";
            this.DockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.DockPanel2.Size = new System.Drawing.Size(200, 590);
            this.DockPanel2.Text = "ChannelList";
            // 
            // DockPanel2_Container
            // 
            this.DockPanel2_Container.Controls.Add(this.TreeList1);
            this.DockPanel2_Container.Location = new System.Drawing.Point(3, 24);
            this.DockPanel2_Container.Name = "DockPanel2_Container";
            this.DockPanel2_Container.Size = new System.Drawing.Size(193, 563);
            this.DockPanel2_Container.TabIndex = 0;
            // 
            // TreeList1
            // 
            this.TreeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ChannelName});
            this.TreeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList1.Location = new System.Drawing.Point(0, 0);
            this.TreeList1.Name = "TreeList1";
            this.TreeList1.Size = new System.Drawing.Size(193, 563);
            this.TreeList1.StateImageList = this.imageList1;
            this.TreeList1.TabIndex = 0;
            this.TreeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList1_FocusedNodeChanged);
            // 
            // ChannelName
            // 
            this.ChannelName.Caption = "ChannelName";
            this.ChannelName.FieldName = "Name";
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.OptionsColumn.AllowEdit = false;
            this.ChannelName.OptionsColumn.AllowFocus = false;
            this.ChannelName.OptionsColumn.ReadOnly = true;
            this.ChannelName.Visible = true;
            this.ChannelName.VisibleIndex = 0;
            this.ChannelName.Width = 211;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Convert_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TreeView_16x16.png");
            this.imageList1.Images.SetKeyName(2, "Database_16x16.png");
            // 
            // dockPanel4
            // 
            this.dockPanel4.Controls.Add(this.dockPanel4_Container);
            this.dockPanel4.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel4.ID = new System.Guid("312e91b5-f979-4dce-9bf1-458563cefc59");
            this.dockPanel4.Location = new System.Drawing.Point(1061, 0);
            this.dockPanel4.Name = "dockPanel4";
            this.dockPanel4.OriginalSize = new System.Drawing.Size(215, 200);
            this.dockPanel4.Size = new System.Drawing.Size(215, 590);
            this.dockPanel4.TabsPosition = DevExpress.XtraBars.Docking.TabsPosition.Right;
            this.dockPanel4.Text = "Properties";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Controls.Add(this.vGridDataBlock);
            this.dockPanel4_Container.Controls.Add(this.vGridDevice);
            this.dockPanel4_Container.Controls.Add(this.vGridChannel);
            this.dockPanel4_Container.Controls.Add(this.vGridSerialPort);
            this.dockPanel4_Container.Controls.Add(this.vGridEthernet);
            this.dockPanel4_Container.Location = new System.Drawing.Point(4, 24);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(208, 563);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // vGridDataBlock
            // 
            this.vGridDataBlock.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridDataBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridDataBlock.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.BandsView;
            this.vGridDataBlock.Location = new System.Drawing.Point(0, 413);
            this.vGridDataBlock.Name = "vGridDataBlock";
            this.vGridDataBlock.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.category,
            this.row,
            this.row1,
            this.row2,
            this.row3,
            this.row4,
            this.row5});
            this.vGridDataBlock.Size = new System.Drawing.Size(208, 134);
            this.vGridDataBlock.TabIndex = 39;
            this.vGridDataBlock.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.ExplorerBar;
            // 
            // category
            // 
            this.category.Height = 18;
            this.category.Name = "category";
            this.category.Properties.Caption = "DataBlock";
            // 
            // row
            // 
            this.row.Appearance.Options.UseTextOptions = true;
            this.row.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row.Height = 16;
            this.row.Name = "row";
            this.row.Properties.Caption = "Description";
            this.row.Properties.FieldName = "Description";
            // 
            // row1
            // 
            this.row1.Appearance.Options.UseTextOptions = true;
            this.row1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row1.Name = "row1";
            this.row1.Properties.Caption = "DataType";
            this.row1.Properties.FieldName = "DataType";
            // 
            // row2
            // 
            this.row2.Appearance.Options.UseTextOptions = true;
            this.row2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row2.Name = "row2";
            this.row2.Properties.Caption = "AddressLength";
            this.row2.Properties.FieldName = "Length";
            // 
            // row3
            // 
            this.row3.Appearance.Options.UseTextOptions = true;
            this.row3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row3.Name = "row3";
            this.row3.Properties.Caption = "StartAddress";
            this.row3.Properties.FieldName = "StartAddress";
            // 
            // row4
            // 
            this.row4.Appearance.Options.UseTextOptions = true;
            this.row4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row4.Name = "row4";
            this.row4.Properties.Caption = "DataBlockName";
            this.row4.Properties.FieldName = "DataBlockName";
            // 
            // row5
            // 
            this.row5.Appearance.Options.UseTextOptions = true;
            this.row5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.row5.Height = 16;
            this.row5.Name = "row5";
            this.row5.Properties.Caption = "MemoryType";
            this.row5.Properties.FieldName = "MemoryType";
            // 
            // vGridDevice
            // 
            this.vGridDevice.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridDevice.Location = new System.Drawing.Point(0, 332);
            this.vGridDevice.Name = "vGridDevice";
            this.vGridDevice.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catDevice,
            this.colDeviceName,
            this.colSlaveId,
            this.colDeviceDesp});
            this.vGridDevice.Size = new System.Drawing.Size(208, 81);
            this.vGridDevice.TabIndex = 39;
            // 
            // catDevice
            // 
            this.catDevice.Name = "catDevice";
            this.catDevice.Properties.Caption = "DeviceName";
            // 
            // colDeviceName
            // 
            this.colDeviceName.Appearance.Options.UseTextOptions = true;
            this.colDeviceName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceName.Height = 17;
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.Properties.Caption = "DeviceName";
            this.colDeviceName.Properties.FieldName = "DeviceName";
            // 
            // colSlaveId
            // 
            this.colSlaveId.Appearance.Options.UseTextOptions = true;
            this.colSlaveId.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSlaveId.Name = "colSlaveId";
            this.colSlaveId.Properties.Caption = "SlaveId";
            this.colSlaveId.Properties.FieldName = "SlaveId";
            // 
            // colDeviceDesp
            // 
            this.colDeviceDesp.Appearance.Options.UseTextOptions = true;
            this.colDeviceDesp.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceDesp.Name = "colDeviceDesp";
            this.colDeviceDesp.Properties.Caption = "Description";
            this.colDeviceDesp.Properties.FieldName = "Description";
            // 
            // vGridChannel
            // 
            this.vGridChannel.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridChannel.Location = new System.Drawing.Point(0, 229);
            this.vGridChannel.Name = "vGridChannel";
            this.vGridChannel.RowHeaderWidth = 98;
            this.vGridChannel.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catChannel,
            this.colConnectionType,
            this.colChannelName,
            this.colDescription2});
            this.vGridChannel.Size = new System.Drawing.Size(208, 103);
            this.vGridChannel.TabIndex = 39;
            // 
            // catChannel
            // 
            this.catChannel.Name = "catChannel";
            this.catChannel.Properties.Caption = "Channel";
            // 
            // colConnectionType
            // 
            this.colConnectionType.Appearance.Options.UseTextOptions = true;
            this.colConnectionType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConnectionType.Name = "colConnectionType";
            this.colConnectionType.Properties.Caption = "ConnectionType";
            this.colConnectionType.Properties.FieldName = "ConnectionType";
            // 
            // colChannelName
            // 
            this.colChannelName.Appearance.Options.UseTextOptions = true;
            this.colChannelName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChannelName.Name = "colChannelName";
            this.colChannelName.Properties.Caption = "ChannelName";
            this.colChannelName.Properties.FieldName = "ChannelName";
            // 
            // colDescription2
            // 
            this.colDescription2.Appearance.Options.UseTextOptions = true;
            this.colDescription2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription2.Name = "colDescription2";
            this.colDescription2.Properties.Caption = "Description";
            this.colDescription2.Properties.FieldName = "Description";
            // 
            // vGridSerialPort
            // 
            this.vGridSerialPort.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridSerialPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridSerialPort.Location = new System.Drawing.Point(0, 93);
            this.vGridSerialPort.Name = "vGridSerialPort";
            this.vGridSerialPort.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catSerialPort,
            this.colPortName,
            this.colBaudRate,
            this.colDataBits,
            this.colStopBits,
            this.colDescription3});
            this.vGridSerialPort.Size = new System.Drawing.Size(208, 136);
            this.vGridSerialPort.TabIndex = 37;
            // 
            // catSerialPort
            // 
            this.catSerialPort.Name = "catSerialPort";
            this.catSerialPort.Properties.Caption = "SerialPort";
            // 
            // colPortName
            // 
            this.colPortName.Appearance.Options.UseTextOptions = true;
            this.colPortName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPortName.Height = 16;
            this.colPortName.Name = "colPortName";
            this.colPortName.Properties.Caption = "PortName:";
            this.colPortName.Properties.FieldName = "PortName";
            // 
            // colBaudRate
            // 
            this.colBaudRate.Appearance.Options.UseTextOptions = true;
            this.colBaudRate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBaudRate.Name = "colBaudRate";
            this.colBaudRate.Properties.Caption = "BaudRate:";
            this.colBaudRate.Properties.FieldName = "BaudRate";
            // 
            // colDataBits
            // 
            this.colDataBits.Appearance.Options.UseTextOptions = true;
            this.colDataBits.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataBits.Name = "colDataBits";
            this.colDataBits.Properties.Caption = "DataBits:";
            this.colDataBits.Properties.FieldName = "DataBits";
            // 
            // colStopBits
            // 
            this.colStopBits.Appearance.Options.UseTextOptions = true;
            this.colStopBits.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStopBits.Name = "colStopBits";
            this.colStopBits.Properties.Caption = "StopBits";
            this.colStopBits.Properties.FieldName = "StopBits";
            // 
            // colDescription3
            // 
            this.colDescription3.Appearance.Options.UseTextOptions = true;
            this.colDescription3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription3.Name = "colDescription3";
            this.colDescription3.Properties.Caption = "Description";
            this.colDescription3.Properties.FieldName = "Description";
            // 
            // vGridEthernet
            // 
            this.vGridEthernet.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridEthernet.Dock = System.Windows.Forms.DockStyle.Top;
            this.vGridEthernet.Location = new System.Drawing.Point(0, 0);
            this.vGridEthernet.Name = "vGridEthernet";
            this.vGridEthernet.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.catEthernet,
            this.colIPAddress,
            this.colPort});
            this.vGridEthernet.Size = new System.Drawing.Size(208, 93);
            this.vGridEthernet.TabIndex = 37;
            // 
            // catEthernet
            // 
            this.catEthernet.Height = 18;
            this.catEthernet.Name = "catEthernet";
            this.catEthernet.Properties.Caption = "Ethernet";
            // 
            // colIPAddress
            // 
            this.colIPAddress.Appearance.Options.UseTextOptions = true;
            this.colIPAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIPAddress.Name = "colIPAddress";
            this.colIPAddress.Properties.Caption = "IPAddress:";
            this.colIPAddress.Properties.FieldName = "IPAddress";
            // 
            // colPort
            // 
            this.colPort.Appearance.Options.UseTextOptions = true;
            this.colPort.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPort.Height = 28;
            this.colPort.Name = "colPort";
            this.colPort.Properties.Caption = "Port:";
            this.colPort.Properties.FieldName = "Port";
            // 
            // RealTimeSource1
            // 
            this.RealTimeSource1.DisplayableProperties = "Value;Timestamp";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.RealTimeSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(200, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.BarManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(861, 590);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.GridControl1_DoubleClick);
            this.gridControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridControl1_MouseClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTagId,
            this.colTagName,
            this.colAddress,
            this.colDataType,
            this.colValue,
            this.colTimestamp,
            this.colDescription});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridView1_FocusedRowChanged);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridControl1_MouseClick);
            // 
            // colTagId
            // 
            this.colTagId.AppearanceCell.Options.UseTextOptions = true;
            this.colTagId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.Caption = "TagId";
            this.colTagId.FieldName = "TagId";
            this.colTagId.Name = "colTagId";
            this.colTagId.OptionsColumn.AllowEdit = false;
            this.colTagId.OptionsColumn.AllowFocus = false;
            this.colTagId.OptionsColumn.ReadOnly = true;
            this.colTagId.Visible = true;
            this.colTagId.VisibleIndex = 0;
            this.colTagId.Width = 45;
            // 
            // colTagName
            // 
            this.colTagName.AppearanceCell.Options.UseTextOptions = true;
            this.colTagName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagName.Caption = "TagName";
            this.colTagName.FieldName = "TagName";
            this.colTagName.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTagName.Name = "colTagName";
            this.colTagName.OptionsColumn.AllowEdit = false;
            this.colTagName.OptionsColumn.AllowFocus = false;
            this.colTagName.OptionsColumn.ReadOnly = true;
            this.colTagName.Visible = true;
            this.colTagName.VisibleIndex = 1;
            this.colTagName.Width = 120;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowFocus = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 120;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowFocus = false;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 3;
            this.colDataType.Width = 85;
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsColumn.AllowEdit = false;
            this.colValue.OptionsColumn.AllowFocus = false;
            this.colValue.OptionsColumn.ReadOnly = true;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 4;
            this.colValue.Width = 100;
            // 
            // colTimestamp
            // 
            this.colTimestamp.AppearanceCell.Options.UseTextOptions = true;
            this.colTimestamp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimestamp.AppearanceHeader.Options.UseTextOptions = true;
            this.colTimestamp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimestamp.Caption = "Timestamp";
            this.colTimestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.colTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTimestamp.FieldName = "Timestamp";
            this.colTimestamp.MinWidth = 30;
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.OptionsColumn.AllowEdit = false;
            this.colTimestamp.OptionsColumn.AllowFocus = false;
            this.colTimestamp.OptionsColumn.ReadOnly = true;
            this.colTimestamp.Visible = true;
            this.colTimestamp.VisibleIndex = 5;
            this.colTimestamp.Width = 197;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 6;
            this.colDescription.Width = 113;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(200, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(861, 35);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "TagList";
            // 
            // PLC_MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 618);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dockPanel4);
            this.Controls.Add(this.DockPanel2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PLC_MonitorForm";
            this.BarManager1.SetPopupContextMenu(this, this.PopupMenu1);
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimaticMonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.SimaticMonitorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu1)).EndInit();
            this.DockPanel2.ResumeLayout(false);
            this.DockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).EndInit();
            this.dockPanel4.ResumeLayout(false);
            this.dockPanel4_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridDataBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridSerialPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridEthernet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		internal DevExpress.XtraBars.Docking.DockPanel DockPanel2;
        internal DevExpress.XtraBars.Docking.ControlContainer DockPanel2_Container;
		internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
		internal DevExpress.XtraBars.BarDockControl barDockControlRight;
		internal DevExpress.XtraBars.BarDockControl barDockControlBottom;
		internal DevExpress.XtraBars.BarDockControl barDockControlTop;
		internal DevExpress.XtraBars.Docking.DockManager DockManager1;
        internal DevExpress.XtraBars.BarManager BarManager1;
        internal DevExpress.XtraBars.Bar Bar3;
		internal DevExpress.XtraBars.BarStaticItem BarTagName;
		internal DevExpress.XtraBars.BarStaticItem lblSelectedTag;
		internal DevExpress.XtraBars.BarStaticItem BarStaticItem1;
		internal DevExpress.XtraBars.BarButtonItem mWriteTagValue;
        internal DevExpress.XtraBars.BarButtonItem mSetOFF;
        internal TreeList TreeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ChannelName;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTagId;
        private DevExpress.XtraGrid.Columns.GridColumn colTagName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.Data.RealTimeSource RealTimeSource1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel4;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraVerticalGrid.VGridControl vGridEthernet;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catEthernet;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colIPAddress;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colPort;
        private DevExpress.XtraVerticalGrid.VGridControl vGridDataBlock;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row3;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row4;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row5;
        private DevExpress.XtraVerticalGrid.VGridControl vGridDevice;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catDevice;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colDeviceName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colSlaveId;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colDeviceDesp;
        private DevExpress.XtraVerticalGrid.VGridControl vGridChannel;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catChannel;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colConnectionType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colChannelName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colDescription2;
        private DevExpress.XtraVerticalGrid.VGridControl vGridSerialPort;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow catSerialPort;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colPortName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colBaudRate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colDataBits;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colStopBits;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow colDescription3;
        private DevExpress.XtraBars.BarButtonItem mSetON;
        private DevExpress.XtraBars.PopupMenu PopupMenu1;
        private ImageList imageList1;
        private IContainer components;
    }

}