using System.ComponentModel;
using System.Windows.Forms;

using DevExpress.XtraEditors;



namespace AdvancedScada.Studio
{

    public partial class FormStudio : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && Components != null)
				{
					Components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudio));
            this.mnMonioring = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.mCommands = new DevExpress.XtraBars.BarSubItem();
            this.mOption = new DevExpress.XtraBars.BarSubItem();
            this.barCheckEnabele = new DevExpress.XtraBars.BarCheckItem();
            this.mConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLibraryImages = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barItemClear = new DevExpress.XtraBars.BarButtonItem();
            this.ItemView = new DevExpress.XtraBars.BarButtonItem();
            this.ItemExit = new DevExpress.XtraBars.BarButtonItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.mailGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.ServiceItem = new DevExpress.XtraNavBar.NavBarItem();
            this.TagManagerItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SQLItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SQLiteItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navFrameMonitor = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.popupMenuNotifyIcon = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskbarAssistant1 = new DevExpress.Utils.Taskbar.TaskbarAssistant();
            this.LoggingDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gpLogging = new DevExpress.XtraEditors.GroupControl();
            this.txtHistory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNotifyIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingDockManager)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpLogging)).BeginInit();
            this.gpLogging.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnMonioring
            // 
            this.mnMonioring.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.mnMonioring.Caption = "Monioring";
            this.mnMonioring.Id = 54;
            this.mnMonioring.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnMonioring.ImageOptions.Image")));
            this.mnMonioring.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnMonioring.ImageOptions.LargeImage")));
            this.mnMonioring.Name = "mnMonioring";
            this.mnMonioring.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mMonioring_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "File";
            this.barSubItem1.Id = 65;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonExit)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonExit
            // 
            this.barButtonExit.Caption = "Exit";
            this.barButtonExit.Id = 68;
            this.barButtonExit.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Exit;
            this.barButtonExit.Name = "barButtonExit";
            this.barButtonExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mExit_ItemClick);
            // 
            // mCommands
            // 
            this.mCommands.Caption = "&Commands";
            this.mCommands.Id = 74;
            this.mCommands.Name = "mCommands";
            // 
            // mOption
            // 
            this.mOption.Caption = "&Option";
            this.mOption.Id = 17;
            this.mOption.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckEnabele),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mConfiguration, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mOption.Name = "mOption";
            // 
            // barCheckEnabele
            // 
            this.barCheckEnabele.Caption = "Auto-run at boot time";
            this.barCheckEnabele.Id = 41;
            this.barCheckEnabele.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Edit;
            this.barCheckEnabele.Name = "barCheckEnabele";
            this.barCheckEnabele.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckEnabele_ItemClick);
            // 
            // mConfiguration
            // 
            this.mConfiguration.Caption = "Configuration";
            this.mConfiguration.Id = 24;
            this.mConfiguration.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mConfiguration.ImageOptions.Image")));
            this.mConfiguration.ImageOptions.ImageIndex = 28;
            this.mConfiguration.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mConfiguration.ImageOptions.LargeImage")));
            this.mConfiguration.Name = "mConfiguration";
            this.mConfiguration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mConfiguration_ItemClick);
            // 
            // barButtonLibraryImages
            // 
            this.barButtonLibraryImages.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonLibraryImages.Caption = "LibraryImages";
            this.barButtonLibraryImages.Id = 45;
            this.barButtonLibraryImages.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonLibraryImages.ImageOptions.Image")));
            this.barButtonLibraryImages.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonLibraryImages.ImageOptions.LargeImage")));
            this.barButtonLibraryImages.Name = "barButtonLibraryImages";
            this.barButtonLibraryImages.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLibraryImages_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "TagCount:";
            this.barStaticItem1.Id = 43;
            this.barStaticItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem1.ImageOptions.Image")));
            this.barStaticItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItem1.ImageOptions.LargeImage")));
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barItemClear
            // 
            this.barItemClear.Caption = "Clear";
            this.barItemClear.Id = 72;
            this.barItemClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barItemClear.ImageOptions.Image")));
            this.barItemClear.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barItemClear.ImageOptions.LargeImage")));
            this.barItemClear.Name = "barItemClear";
            this.barItemClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barItemClear_ItemClick);
            // 
            // ItemView
            // 
            this.ItemView.Caption = "View";
            this.ItemView.Id = 69;
            this.ItemView.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.TagManager;
            this.ItemView.Name = "ItemView";
            this.ItemView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemView_ItemClick);
            // 
            // ItemExit
            // 
            this.ItemExit.Caption = "Exit";
            this.ItemExit.Id = 70;
            this.ItemExit.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Exit;
            this.ItemExit.Name = "ItemExit";
            this.ItemExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemExit_ItemClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Convert_16x16.png");
            this.imageList1.Images.SetKeyName(1, "TreeView_16x16.png");
            this.imageList1.Images.SetKeyName(2, "PublicFix_16x16.png");
            this.imageList1.Images.SetKeyName(3, "User_16x16.png");
            this.imageList1.Images.SetKeyName(4, "HistoryItem_16x16.png");
            this.imageList1.Images.SetKeyName(5, "Tag_16x16.png");
            this.imageList1.Images.SetKeyName(6, "ManageDatasource_16x16.png");
            this.imageList1.Images.SetKeyName(7, "Database_16x16.png");
            // 
            // LookAndFeel1
            // 
            this.LookAndFeel1.LookAndFeel.SkinName = "Black";
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Options.UseFont = true;
            this.treeListColumn1.Caption = "SimaticNet";
            this.treeListColumn1.FieldName = "ChannelName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.OptionsColumn.AllowFocus = false;
            this.treeListColumn1.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Options.UseFont = true;
            this.treeListColumn2.Caption = "SimaticNet";
            this.treeListColumn2.FieldName = "ChannelName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowFocus = false;
            this.treeListColumn2.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // document1
            // 
            this.document1.Caption = "dockPanel4";
            this.document1.ControlName = "dockPanel4";
            this.document1.FloatLocation = new System.Drawing.Point(454, 152);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 5";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.FloatLocation = new System.Drawing.Point(305, 294);
            this.bar4.FloatSize = new System.Drawing.Size(46, 24);
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Custom 5";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.mailGroup;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.mailGroup});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.ServiceItem,
            this.SQLItem,
            this.SQLiteItem,
            this.TagManagerItem,
            this.navFrameMonitor});
            this.navBarControl.LargeImages = this.imageList1;
            this.navBarControl.Location = new System.Drawing.Point(0, 147);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 166;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(166, 315);
            this.navBarControl.SmallImages = this.imageList1;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 34;
            this.navBarControl.Text = "navBarControl1";
            // 
            // mailGroup
            // 
            this.mailGroup.Caption = "Management";
            this.mailGroup.Expanded = true;
            this.mailGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.ServiceItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TagManagerItem)});
            this.mailGroup.Name = "mailGroup";
            // 
            // ServiceItem
            // 
            this.ServiceItem.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ServiceItem.Appearance.Image")));
            this.ServiceItem.Appearance.Options.UseImage = true;
            this.ServiceItem.Caption = "Service";
            this.ServiceItem.ImageOptions.SmallImageIndex = 0;
            this.ServiceItem.Name = "ServiceItem";
            this.ServiceItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.ServiceItem_LinkClicked);
            // 
            // TagManagerItem
            // 
            this.TagManagerItem.Caption = "Tag Manager";
            this.TagManagerItem.ImageOptions.SmallImageIndex = 5;
            this.TagManagerItem.Name = "TagManagerItem";
            this.TagManagerItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TagManagerItem_LinkClicked);
            // 
            // SQLItem
            // 
            this.SQLItem.Caption = "Microsoft SQL Server";
            this.SQLItem.ImageOptions.SmallImageIndex = 7;
            this.SQLItem.Name = "SQLItem";
             // 
            // SQLiteItem
            // 
            this.SQLiteItem.Caption = "SQLite";
            this.SQLiteItem.ImageOptions.SmallImageIndex = 7;
            this.SQLiteItem.Name = "SQLiteItem";
            // 
            // navFrameMonitor
            // 
            this.navFrameMonitor.Caption = "FormFrameMonitor";
            this.navFrameMonitor.ImageOptions.SmallImageIndex = 0;
            this.navFrameMonitor.Name = "navFrameMonitor";
             // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabbedMdiManager1.HeaderButtons = DevExpress.XtraTab.TabButtons.Close;
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // alertControl1
            // 
            this.alertControl1.AllowHotTrack = false;
            this.alertControl1.AutoFormDelay = 5000;
            this.alertControl1.Images = this.imageList1;
            this.alertControl1.PopupMenu = this.popupMenuNotifyIcon;
            this.alertControl1.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl1_AlertClick);
            this.alertControl1.BeforeFormShow += new DevExpress.XtraBars.Alerter.AlertFormEventHandler(this.alertControl1_BeforeFormShow);
            // 
            // popupMenuNotifyIcon
            // 
            this.popupMenuNotifyIcon.ItemLinks.Add(this.ItemView);
            this.popupMenuNotifyIcon.ItemLinks.Add(this.ItemExit);
            this.popupMenuNotifyIcon.Name = "popupMenuNotifyIcon";
            this.popupMenuNotifyIcon.Ribbon = this.ribbonControl1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.mConfiguration,
            this.barCheckEnabele,
            this.barStaticItem1,
            this.barButtonLibraryImages,
            this.mnMonioring,
            this.barButtonExit,
            this.ItemView,
            this.ItemExit,
            this.barItemClear,
            this.skinRibbonGalleryBarItem1,
            this.ribbonControl1.SearchEditItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1116, 147);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup6});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "MainMenu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonExit);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "File";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barCheckEnabele);
            this.ribbonPageGroup3.ItemLinks.Add(this.mConfiguration);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Option";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonLibraryImages);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "MainMenu";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Skin";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Monioring";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.mnMonioring, true);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Tools";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barItemClear, true);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 599);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1116, 23);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "برمجة عبداللة الصاوى";
            this.notifyIcon1.BalloonTipTitle = " اتصالServer WCF";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Main Studio";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // taskbarAssistant1
            // 
            this.taskbarAssistant1.OverlayIcon = global::AdvancedScada.Studio.Properties.Resources._38;
            this.taskbarAssistant1.ParentControl = this;
            // 
            // LoggingDockManager
            // 
            this.LoggingDockManager.Form = this;
            this.LoggingDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.LoggingDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.ID = new System.Guid("0cae9186-fd92-4e38-aac5-ba07b35bc93d");
            this.dockPanel1.Location = new System.Drawing.Point(0, 462);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 137);
            this.dockPanel1.Size = new System.Drawing.Size(1116, 137);
            this.dockPanel1.Text = "Logging";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gpLogging);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1110, 104);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // gpLogging
            // 
            this.gpLogging.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("gpLogging.AppearanceCaption.Image")));
            this.gpLogging.AppearanceCaption.Options.UseImage = true;
            this.gpLogging.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("gpLogging.CaptionImageOptions.Image")));
            this.gpLogging.Controls.Add(this.txtHistory);
            this.gpLogging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpLogging.Location = new System.Drawing.Point(0, 0);
            this.gpLogging.Name = "gpLogging";
            this.gpLogging.Size = new System.Drawing.Size(1110, 104);
            this.gpLogging.TabIndex = 38;
            this.gpLogging.Text = "Logging";
            // 
            // txtHistory
            // 
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(2, 23);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistory.Size = new System.Drawing.Size(1106, 79);
            this.txtHistory.TabIndex = 33;
            // 
            // FormStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 622);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormStudio";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Main Studio 2019";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStudio_FormClosing);
            this.Load += new System.EventHandler(this.FormS7Studio_Load);
            this.Resize += new System.EventHandler(this.FormStudio_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNotifyIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingDockManager)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpLogging)).EndInit();
            this.gpLogging.ResumeLayout(false);
            this.gpLogging.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        internal DevExpress.LookAndFeel.DefaultLookAndFeel LookAndFeel1;
        internal DevExpress.XtraBars.BarSubItem mOption;
        internal DevExpress.XtraBars.BarButtonItem mConfiguration;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraBars.BarCheckItem barCheckEnabele;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonLibraryImages;
        private DevExpress.XtraBars.BarButtonItem mnMonioring;
        private ImageList imageList1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup mailGroup;
        private DevExpress.XtraNavBar.NavBarItem ServiceItem;
        private DevExpress.XtraNavBar.NavBarItem TagManagerItem;
        private DevExpress.XtraNavBar.NavBarItem SQLItem;
        private DevExpress.XtraNavBar.NavBarItem SQLiteItem;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonExit;
        private DevExpress.XtraBars.BarButtonItem ItemView;
        private DevExpress.XtraBars.BarButtonItem ItemExit;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.PopupMenu popupMenuNotifyIcon;
        private NotifyIcon notifyIcon1;
        private DevExpress.XtraBars.BarButtonItem barItemClear;
        private DevExpress.XtraNavBar.NavBarItem navFrameMonitor;
        private DevExpress.XtraBars.BarSubItem mCommands;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private GroupControl gpLogging;
        private TextBox txtHistory;
        private DevExpress.XtraBars.Docking.DockManager LoggingDockManager;

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