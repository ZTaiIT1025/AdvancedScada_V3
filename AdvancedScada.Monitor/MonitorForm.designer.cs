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

namespace AdvancedScada.Monitor
{
 	public partial class MonitorForm : DevExpress.XtraEditors.XtraForm
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			if (disposing && Components != null)
			{
				Components.Dispose();
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer
		private IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.DocumentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.TabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.DockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.BarManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.Bar3 = new DevExpress.XtraBars.Bar();
            this.BarButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.mIP = new DevExpress.XtraBars.BarStaticItem();
            this.BarStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.BarStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.mPort = new DevExpress.XtraBars.BarStaticItem();
            this.BarStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.BarStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
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
            this.DockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.DockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.DockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.TreeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colXGT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
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
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu1)).BeginInit();
            this.DockPanel1.SuspendLayout();
            this.DockPanel1_Container.SuspendLayout();
            this.DockPanel2.SuspendLayout();
            this.DockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentManager1
            // 
            this.DocumentManager1.MdiParent = this;
            this.DocumentManager1.View = this.TabbedView1;
            this.DocumentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.TabbedView1});
            // 
            // DockManager1
            // 
            this.DockManager1.Form = this;
            this.DockManager1.MenuManager = this.BarManager1;
            this.DockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.DockPanel1,
            this.DockPanel2});
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
            this.BarButtonItem1,
            this.BarStaticItem1,
            this.mIP,
            this.BarStaticItem3,
            this.BarStaticItem4,
            this.mPort,
            this.BarStaticItem6,
            this.BarStaticItem7,
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.mIP),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStaticItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStaticItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.mPort),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStaticItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarStaticItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSelectedTag)});
            this.Bar3.OptionsBar.AllowQuickCustomization = false;
            this.Bar3.OptionsBar.DrawDragBorder = false;
            this.Bar3.OptionsBar.UseWholeRow = true;
            this.Bar3.Text = "Status bar";
            // 
            // BarButtonItem1
            // 
            this.BarButtonItem1.Caption = "Server IP:";
            this.BarButtonItem1.Id = 0;
            this.BarButtonItem1.ImageOptions.ImageIndex = 0;
            this.BarButtonItem1.Name = "BarButtonItem1";
            // 
            // mIP
            // 
            this.mIP.Caption = "127.0.0.1";
            this.mIP.Id = 2;
            this.mIP.Name = "mIP";
            // 
            // BarStaticItem3
            // 
            this.BarStaticItem3.Caption = "|";
            this.BarStaticItem3.Id = 3;
            this.BarStaticItem3.Name = "BarStaticItem3";
            // 
            // BarStaticItem4
            // 
            this.BarStaticItem4.Caption = "Port:";
            this.BarStaticItem4.Id = 4;
            this.BarStaticItem4.Name = "BarStaticItem4";
            // 
            // mPort
            // 
            this.mPort.Caption = "8080";
            this.mPort.Id = 5;
            this.mPort.Name = "mPort";
            // 
            // BarStaticItem6
            // 
            this.BarStaticItem6.Caption = "|";
            this.BarStaticItem6.Id = 6;
            this.BarStaticItem6.Name = "BarStaticItem6";
            // 
            // BarStaticItem7
            // 
            this.BarStaticItem7.Caption = "TagName:";
            this.BarStaticItem7.Id = 7;
            this.BarStaticItem7.Name = "BarStaticItem7";
            // 
            // lblSelectedTag
            // 
            this.lblSelectedTag.Caption = "BarStaticItem8";
            this.lblSelectedTag.Id = 8;
            this.lblSelectedTag.Name = "lblSelectedTag";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(984, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 536);
            this.barDockControlBottom.Manager = this.BarManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(984, 29);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 0);
            this.barDockControlRight.Manager = this.BarManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
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
            this.mWriteTagValue.Name = "mWriteTagValue";
            this.mWriteTagValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mWriteTagValue_ItemClick);
            // 
            // mSetON
            // 
            this.mSetON.Caption = "Set ON";
            this.mSetON.Id = 11;
            this.mSetON.Name = "mSetON";
            this.mSetON.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mSetON_ItemClick);
            // 
            // mSetOFF
            // 
            this.mSetOFF.Caption = "Set OFF";
            this.mSetOFF.Id = 12;
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
            // DockPanel1
            // 
            this.DockPanel1.Controls.Add(this.DockPanel1_Container);
            this.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.DockPanel1.ID = new System.Guid("74669b40-02b7-4d17-a8bd-e25e3178f1da");
            this.DockPanel1.Location = new System.Drawing.Point(0, 428);
            this.DockPanel1.Name = "DockPanel1";
            this.DockPanel1.OriginalSize = new System.Drawing.Size(200, 108);
            this.DockPanel1.Size = new System.Drawing.Size(984, 108);
            this.DockPanel1.Text = "Action&Events";
            // 
            // DockPanel1_Container
            // 
            this.DockPanel1_Container.Controls.Add(this.txtHistory);
            this.DockPanel1_Container.Location = new System.Drawing.Point(3, 25);
            this.DockPanel1_Container.Name = "DockPanel1_Container";
            this.DockPanel1_Container.Size = new System.Drawing.Size(978, 80);
            this.DockPanel1_Container.TabIndex = 0;
            // 
            // txtHistory
            // 
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(0, 0);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistory.Size = new System.Drawing.Size(978, 80);
            this.txtHistory.TabIndex = 0;
            // 
            // DockPanel2
            // 
            this.DockPanel2.Controls.Add(this.DockPanel2_Container);
            this.DockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.DockPanel2.ID = new System.Guid("b9eb39e1-9505-4ba9-8dfd-d64503fc6df7");
            this.DockPanel2.Location = new System.Drawing.Point(0, 0);
            this.DockPanel2.Name = "DockPanel2";
            this.DockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.DockPanel2.Size = new System.Drawing.Size(200, 428);
            this.DockPanel2.Text = "ChannelList";
            // 
            // DockPanel2_Container
            // 
            this.DockPanel2_Container.Controls.Add(this.TreeList1);
            this.DockPanel2_Container.Location = new System.Drawing.Point(3, 24);
            this.DockPanel2_Container.Name = "DockPanel2_Container";
            this.DockPanel2_Container.Size = new System.Drawing.Size(193, 401);
            this.DockPanel2_Container.TabIndex = 0;
            // 
            // TreeList1
            // 
            this.TreeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colXGT});
            this.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList1.Location = new System.Drawing.Point(0, 0);
            this.TreeList1.Name = "TreeList1";
            this.TreeList1.Size = new System.Drawing.Size(193, 401);
            this.TreeList1.TabIndex = 0;
            this.TreeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList1_FocusedNodeChanged);
            // 
            // colXGT
            // 
            this.colXGT.Caption = "ChannelList";
            this.colXGT.FieldName = "Name";
            this.colXGT.Name = "colXGT";
            this.colXGT.OptionsColumn.AllowEdit = false;
            this.colXGT.OptionsColumn.AllowFocus = false;
            this.colXGT.OptionsColumn.ReadOnly = true;
            this.colXGT.Visible = true;
            this.colXGT.VisibleIndex = 0;
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
            this.gridControl1.Size = new System.Drawing.Size(784, 428);
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
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
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
            this.colTagId.Width = 60;
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
            this.colTagName.Width = 104;
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
            this.colAddress.Width = 104;
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
            this.colDataType.Width = 104;
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
            this.colValue.Width = 90;
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
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.OptionsColumn.AllowEdit = false;
            this.colTimestamp.OptionsColumn.AllowFocus = false;
            this.colTimestamp.OptionsColumn.ReadOnly = true;
            this.colTimestamp.Visible = true;
            this.colTimestamp.VisibleIndex = 5;
            this.colTimestamp.Width = 136;
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
            this.colDescription.Width = 93;
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
            this.labelControl1.Size = new System.Drawing.Size(784, 35);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "TagList";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.EnableBonusSkins = true;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Black";
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 565);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.DockPanel2);
            this.Controls.Add(this.DockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MonitorForm";
            this.BarManager1.SetPopupContextMenu(this, this.PopupMenu1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimaticMonitorForm_FormClosing);
            this.Load += new System.EventHandler(this.SimaticMonitorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupMenu1)).EndInit();
            this.DockPanel1.ResumeLayout(false);
            this.DockPanel1_Container.ResumeLayout(false);
            this.DockPanel1_Container.PerformLayout();
            this.DockPanel2.ResumeLayout(false);
            this.DockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal DevExpress.XtraBars.Docking2010.DocumentManager DocumentManager1;
		internal DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView TabbedView1;
		internal DevExpress.XtraBars.Docking.DockPanel DockPanel2;
		internal DevExpress.XtraBars.Docking.ControlContainer DockPanel2_Container;
		internal DevExpress.XtraBars.Docking.DockPanel DockPanel1;
		internal DevExpress.XtraBars.Docking.ControlContainer DockPanel1_Container;
		internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
		internal DevExpress.XtraBars.BarDockControl barDockControlRight;
		internal DevExpress.XtraBars.BarDockControl barDockControlBottom;
		internal DevExpress.XtraBars.BarDockControl barDockControlTop;
		internal DevExpress.XtraBars.Docking.DockManager DockManager1;
        internal DevExpress.XtraBars.BarManager BarManager1;
        internal DevExpress.XtraBars.Bar Bar3;
        internal DevExpress.XtraBars.PopupMenu PopupMenu1;
		internal DevExpress.XtraBars.BarButtonItem BarButtonItem1;
		internal DevExpress.XtraBars.BarStaticItem mIP;
		internal DevExpress.XtraBars.BarStaticItem BarStaticItem3;
		internal DevExpress.XtraBars.BarStaticItem BarStaticItem4;
		internal DevExpress.XtraBars.BarStaticItem mPort;
		internal DevExpress.XtraBars.BarStaticItem BarStaticItem6;
        internal DevExpress.XtraBars.BarStaticItem BarStaticItem7;
		internal DevExpress.XtraBars.BarStaticItem BarStaticItem1;
		internal DevExpress.XtraBars.BarButtonItem mWriteTagValue;
		internal DevExpress.XtraBars.BarButtonItem mSetON;
		internal DevExpress.XtraBars.BarButtonItem mSetOFF;
		internal System.Windows.Forms.TextBox txtHistory;
        internal TreeList TreeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colXGT;
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
        public DevExpress.XtraBars.BarStaticItem lblSelectedTag;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;

        public IContainer Components
        {
            get
            {
                return components;
            }

            set
            {
                components = value;
            }
        }
    }

}