using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.NoDocuments;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid;

namespace AdvancedScada.Studio.Monitor
{
    partial class PLC_MonitorForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.gcTags = new DevExpress.XtraGrid.GridControl();
            this.gvTags = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTagId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.noDocumentsView1 = new DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelProperty = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.propertyGridDataBlock = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.propertyGridDevice = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.propertyGridChannel = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.gpCtrlChannel = new DevExpress.XtraEditors.GroupControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colChannelId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDeviceId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDataBlockId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.lblTagCount = new DevExpress.XtraBars.BarStaticItem();
            this.lblSelectedTagName = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelProperty.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridDataBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpCtrlChannel)).BeginInit();
            this.gpCtrlChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ClientControl = this.gcTags;
            this.documentManager1.View = this.noDocumentsView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.noDocumentsView1,
            this.tabbedView1});
            // 
            // gcTags
            // 
            this.gcTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTags.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcTags.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcTags.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcTags.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcTags.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcTags.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gcTags.Location = new System.Drawing.Point(268, 0);
            this.gcTags.MainView = this.gvTags;
            this.gcTags.Name = "gcTags";
            this.gcTags.Size = new System.Drawing.Size(719, 700);
            this.gcTags.TabIndex = 2;
            this.gcTags.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTags});
            // 
            // gvTags
            // 
            this.gvTags.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTagId,
            this.colTagName,
            this.colAddress,
            this.colDataType,
            this.colDescription});
            this.gvTags.GridControl = this.gcTags;
            this.gvTags.Name = "gvTags";
            this.gvTags.OptionsBehavior.Editable = false;
            this.gvTags.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvTags.OptionsView.ShowAutoFilterRow = true;
            this.gvTags.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvTags.OptionsView.ShowGroupPanel = false;
            this.gvTags.OptionsView.ShowViewCaption = true;
            this.gvTags.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvTags_FocusedRowObjectChanged);
            // 
            // colTagId
            // 
            this.colTagId.AppearanceCell.Options.UseTextOptions = true;
            this.colTagId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTagId.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTagId.Caption = "Tag Id";
            this.colTagId.FieldName = "TagId";
            this.colTagId.Name = "colTagId";
            this.colTagId.OptionsColumn.AllowMove = false;
            this.colTagId.OptionsColumn.AllowSize = false;
            this.colTagId.OptionsColumn.FixedWidth = true;
            this.colTagId.Visible = true;
            this.colTagId.VisibleIndex = 0;
            this.colTagId.Width = 66;
            // 
            // colTagName
            // 
            this.colTagName.Caption = "Tag Name";
            this.colTagName.FieldName = "TagName";
            this.colTagName.Name = "colTagName";
            this.colTagName.OptionsColumn.AllowMove = false;
            this.colTagName.Visible = true;
            this.colTagName.VisibleIndex = 1;
            this.colTagName.Width = 129;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "FullAddress";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowMove = false;
            this.colAddress.OptionsColumn.AllowSize = false;
            this.colAddress.OptionsColumn.FixedWidth = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 112;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowMove = false;
            this.colDataType.OptionsColumn.AllowSize = false;
            this.colDataType.OptionsColumn.FixedWidth = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 3;
            this.colDataType.Width = 113;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 357;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelProperty});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanelProperty
            // 
            this.dockPanelProperty.Controls.Add(this.dockPanel1_Container);
            this.dockPanelProperty.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelProperty.ID = new System.Guid("c2693244-afc9-4e15-9016-1d24a97dac8e");
            this.dockPanelProperty.Location = new System.Drawing.Point(987, 0);
            this.dockPanelProperty.Name = "dockPanelProperty";
            this.dockPanelProperty.OriginalSize = new System.Drawing.Size(262, 200);
            this.dockPanelProperty.Size = new System.Drawing.Size(262, 700);
            this.dockPanelProperty.Text = "Properties";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.propertyGridDataBlock);
            this.dockPanel1_Container.Controls.Add(this.propertyGridDevice);
            this.dockPanel1_Container.Controls.Add(this.propertyGridChannel);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(253, 673);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // propertyGridDataBlock
            // 
            this.propertyGridDataBlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.propertyGridDataBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridDataBlock.Location = new System.Drawing.Point(0, 324);
            this.propertyGridDataBlock.Name = "propertyGridDataBlock";
            this.propertyGridDataBlock.OptionsBehavior.Editable = false;
            this.propertyGridDataBlock.Size = new System.Drawing.Size(253, 349);
            this.propertyGridDataBlock.TabIndex = 2;
            // 
            // propertyGridDevice
            // 
            this.propertyGridDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridDevice.Location = new System.Drawing.Point(0, 226);
            this.propertyGridDevice.Name = "propertyGridDevice";
            this.propertyGridDevice.OptionsBehavior.Editable = false;
            this.propertyGridDevice.Size = new System.Drawing.Size(253, 98);
            this.propertyGridDevice.TabIndex = 1;
            // 
            // propertyGridChannel
            // 
            this.propertyGridChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridChannel.Location = new System.Drawing.Point(0, 0);
            this.propertyGridChannel.Name = "propertyGridChannel";
            this.propertyGridChannel.OptionsBehavior.Editable = false;
            this.propertyGridChannel.Size = new System.Drawing.Size(253, 226);
            this.propertyGridChannel.TabIndex = 0;
            // 
            // gpCtrlChannel
            // 
            this.gpCtrlChannel.Controls.Add(this.treeList1);
            this.gpCtrlChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gpCtrlChannel.Location = new System.Drawing.Point(0, 0);
            this.gpCtrlChannel.Name = "gpCtrlChannel";
            this.gpCtrlChannel.Size = new System.Drawing.Size(268, 700);
            this.gpCtrlChannel.TabIndex = 1;
            this.gpCtrlChannel.Text = "Channel List";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colChannelId,
            this.colDeviceId,
            this.colDataBlockId});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(2, 20);
            this.treeList1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(264, 678);
            this.treeList1.TabIndex = 3;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colName
            // 
            this.colName.Caption = " Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 34;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowMove = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colChannelId
            // 
            this.colChannelId.Caption = "ChannelId";
            this.colChannelId.FieldName = "ChannelId";
            this.colChannelId.Name = "colChannelId";
            this.colChannelId.Width = 235;
            // 
            // colDeviceId
            // 
            this.colDeviceId.Caption = "DeviceId";
            this.colDeviceId.FieldName = "DeviceId";
            this.colDeviceId.Name = "colDeviceId";
            // 
            // colDataBlockId
            // 
            this.colDataBlockId.Caption = "DataBlockId";
            this.colDataBlockId.FieldName = "DataBlockId";
            this.colDataBlockId.Name = "colDataBlockId";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblTagCount,
            this.lblSelectedTagName});
            this.barManager1.MaxItemId = 15;
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblTagCount),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblSelectedTagName)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // lblTagCount
            // 
            this.lblTagCount.Caption = "Tagcount: 0";
            this.lblTagCount.Id = 13;
            this.lblTagCount.Name = "lblTagCount";
            // 
            // lblSelectedTagName
            // 
            this.lblSelectedTagName.Caption = "Selected tag: None";
            this.lblSelectedTagName.Id = 14;
            this.lblSelectedTagName.Name = "lblSelectedTagName";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1249, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 700);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1249, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 700);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1249, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 700);
            // 
            // PLC_MonitorForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 725);
            this.Controls.Add(this.gcTags);
            this.Controls.Add(this.gpCtrlChannel);
            this.Controls.Add(this.dockPanelProperty);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PLC_MonitorForm2";
            this.Text = "SELECTION";
            this.Load += new System.EventHandler(this.PLC_MonitorForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noDocumentsView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelProperty.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridDataBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpCtrlChannel)).EndInit();
            this.gpCtrlChannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DocumentManager documentManager1;

        private GridControl gcTags;

        private GridView gvTags;

        private NoDocumentsView noDocumentsView1;

        private TabbedView tabbedView1;

        private DockManager dockManager1;

        private GroupControl gpCtrlChannel;

        private DockPanel dockPanelProperty;

        private ControlContainer dockPanel1_Container;

        private PropertyGridControl propertyGridChannel;

        private TreeList treeList1;

        private TreeListColumn colName;

        private TreeListColumn colChannelId;

        private TreeListColumn colDeviceId;

        private TreeListColumn colDataBlockId;

        private GridColumn colTagId;

        private GridColumn colTagName;

        private GridColumn colAddress;

        private GridColumn colDataType;

        private GridColumn colDescription;

        private BarDockControl barDockControlLeft;

        private BarManager barManager1;

        private BarDockControl barDockControlTop;

        private BarDockControl barDockControlBottom;

        private BarDockControl barDockControlRight;

        private PropertyGridControl propertyGridDataBlock;

        private PropertyGridControl propertyGridDevice;

        private Bar bar1;

        private BarStaticItem lblTagCount;

        private BarStaticItem lblSelectedTagName;
    }
}