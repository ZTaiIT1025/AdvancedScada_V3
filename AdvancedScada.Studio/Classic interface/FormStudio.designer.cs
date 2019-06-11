using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;



namespace TagManagerLibrary.Studio
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FormStudio : XtraForm
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
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.Bar1 = new DevExpress.XtraBars.Bar();
            this.mnMonioring = new DevExpress.XtraBars.BarButtonItem();
            this.Bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonExit = new DevExpress.XtraBars.BarButtonItem();
            this.mCommands = new DevExpress.XtraBars.BarSubItem();
            this.mStart = new DevExpress.XtraBars.BarButtonItem();
            this.mStop = new DevExpress.XtraBars.BarButtonItem();
            this.mPause = new DevExpress.XtraBars.BarButtonItem();
            this.mResume = new DevExpress.XtraBars.BarButtonItem();
            this.mRestart = new DevExpress.XtraBars.BarButtonItem();
            this.mOption = new DevExpress.XtraBars.BarSubItem();
            this.barCheckEnabele = new DevExpress.XtraBars.BarCheckItem();
            this.mConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.mSQLServerUtils = new DevExpress.XtraBars.BarButtonItem();
            this.mPCControllercs = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLibraryImages = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDownload = new DevExpress.XtraBars.BarButtonItem();
            this.Bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barItemClear = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gpLogging = new DevExpress.XtraEditors.GroupControl();
            this.txtHistory = new System.Windows.Forms.TextBox();
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
            this.organizerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.SQLItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SQLiteItem = new DevExpress.XtraNavBar.NavBarItem();
            this.mailGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.ServiceItem = new DevExpress.XtraNavBar.NavBarItem();
            this.LoggingItem = new DevExpress.XtraNavBar.NavBarItem();
            this.TagManagerItem = new DevExpress.XtraNavBar.NavBarItem();
            this.SQLManagerItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navFrameMonitor = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.popupMenuNotifyIcon = new DevExpress.XtraBars.PopupMenu(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskbarAssistant1 = new DevExpress.Utils.Taskbar.TaskbarAssistant();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpLogging)).BeginInit();
            this.gpLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNotifyIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // BarManager
            // 
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.Bar1,
            this.Bar2,
            this.Bar3});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.DockManager = this.dockManager1;
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mOption,
            this.mConfiguration,
            this.mSQLServerUtils,
            this.barCheckEnabele,
            this.barStaticItem1,
            this.barButtonLibraryImages,
            this.barButtonDownload,
            this.mnMonioring,
            this.barSubItem1,
            this.barButtonExit,
            this.ItemView,
            this.ItemExit,
            this.barItemClear,
            this.mPCControllercs,
            this.mCommands,
            this.mStart,
            this.mStop,
            this.mPause,
            this.mResume,
            this.mRestart});
            this.BarManager.MainMenu = this.Bar2;
            this.BarManager.MaxItemId = 80;
            this.BarManager.StatusBar = this.Bar3;
            // 
            // Bar1
            // 
            this.Bar1.BarName = "Tools";
            this.Bar1.DockCol = 0;
            this.Bar1.DockRow = 1;
            this.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.Bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mnMonioring, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.Bar1.OptionsBar.AllowQuickCustomization = false;
            this.Bar1.OptionsBar.UseWholeRow = true;
            this.Bar1.Text = "Tools";
            // 
            // mnMonioring
            // 
            this.mnMonioring.Caption = "Monioring";
            this.mnMonioring.Id = 54;
            this.mnMonioring.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnMonioring.ImageOptions.Image")));
            this.mnMonioring.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnMonioring.ImageOptions.LargeImage")));
            this.mnMonioring.Name = "mnMonioring";
            this.mnMonioring.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mMonioring_ItemClick);
            // 
            // Bar2
            // 
            this.Bar2.BarName = "Main menu";
            this.Bar2.DockCol = 0;
            this.Bar2.DockRow = 0;
            this.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.Bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.mCommands),
            new DevExpress.XtraBars.LinkPersistInfo(this.mOption),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonLibraryImages),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDownload)});
            this.Bar2.OptionsBar.MultiLine = true;
            this.Bar2.OptionsBar.UseWholeRow = true;
            this.Bar2.Text = "Main menu";
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
            this.mCommands.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mStart, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.mStop),
            new DevExpress.XtraBars.LinkPersistInfo(this.mPause),
            new DevExpress.XtraBars.LinkPersistInfo(this.mResume),
            new DevExpress.XtraBars.LinkPersistInfo(this.mRestart)});
            this.mCommands.Name = "mCommands";
            // 
            // mStart
            // 
            this.mStart.Caption = "Start";
            this.mStart.Id = 75;
            this.mStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mStart.ImageOptions.Image")));
            this.mStart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mStart.ImageOptions.LargeImage")));
            this.mStart.Name = "mStart";
            this.mStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mStart_ItemClick);
            // 
            // mStop
            // 
            this.mStop.Caption = "Stop";
            this.mStop.Id = 76;
            this.mStop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mStop.ImageOptions.Image")));
            this.mStop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mStop.ImageOptions.LargeImage")));
            this.mStop.Name = "mStop";
            this.mStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mStop_ItemClick);
            // 
            // mPause
            // 
            this.mPause.Caption = "Pause";
            this.mPause.Id = 77;
            this.mPause.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mPause.ImageOptions.Image")));
            this.mPause.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mPause.ImageOptions.LargeImage")));
            this.mPause.Name = "mPause";
            this.mPause.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mPause_ItemClick);
            // 
            // mResume
            // 
            this.mResume.Caption = "Resume";
            this.mResume.Id = 78;
            this.mResume.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mResume.ImageOptions.Image")));
            this.mResume.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mResume.ImageOptions.LargeImage")));
            this.mResume.Name = "mResume";
            this.mResume.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mResume_ItemClick);
            // 
            // mRestart
            // 
            this.mRestart.Caption = "Restart";
            this.mRestart.Id = 79;
            this.mRestart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mRestart.ImageOptions.Image")));
            this.mRestart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mRestart.ImageOptions.LargeImage")));
            this.mRestart.Name = "mRestart";
            this.mRestart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mRestart_ItemClick);
            // 
            // mOption
            // 
            this.mOption.Caption = "&Option";
            this.mOption.Id = 17;
            this.mOption.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckEnabele),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.mConfiguration, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.mSQLServerUtils),
            new DevExpress.XtraBars.LinkPersistInfo(this.mPCControllercs)});
            this.mOption.Name = "mOption";
            // 
            // barCheckEnabele
            // 
            this.barCheckEnabele.Caption = "Auto-run at boot time";
            this.barCheckEnabele.Id = 41;
            this.barCheckEnabele.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Edit;
            this.barCheckEnabele.Name = "barCheckEnabele";
            this.barCheckEnabele.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckEnabele_CheckedChanged);
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
            // mSQLServerUtils
            // 
            this.mSQLServerUtils.Caption = "SQL Server Utils";
            this.mSQLServerUtils.Id = 26;
            this.mSQLServerUtils.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Database_16x16;
            this.mSQLServerUtils.ImageOptions.ImageIndex = 27;
            this.mSQLServerUtils.Name = "mSQLServerUtils";
            this.mSQLServerUtils.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mSQLServerUtils_ItemClick);
            // 
            // mPCControllercs
            // 
            this.mPCControllercs.Caption = "PC Controllercs";
            this.mPCControllercs.Id = 73;
            this.mPCControllercs.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mPCControllercs.ImageOptions.Image")));
            this.mPCControllercs.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mPCControllercs.ImageOptions.LargeImage")));
            this.mPCControllercs.Name = "mPCControllercs";
            this.mPCControllercs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mPCControllercs_ItemClick);
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
            // barButtonDownload
            // 
            this.barButtonDownload.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonDownload.Caption = "Download";
            this.barButtonDownload.Id = 46;
            this.barButtonDownload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonDownload.ImageOptions.Image")));
            this.barButtonDownload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonDownload.ImageOptions.LargeImage")));
            this.barButtonDownload.Name = "barButtonDownload";
            // 
            // Bar3
            // 
            this.Bar3.BarName = "Status bar";
            this.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.Bar3.DockCol = 0;
            this.Bar3.DockRow = 0;
            this.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.Bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barStaticItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barItemClear, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.Bar3.OptionsBar.AllowQuickCustomization = false;
            this.Bar3.OptionsBar.DrawDragBorder = false;
            this.Bar3.OptionsBar.UseWholeRow = true;
            this.Bar3.Text = "Status bar";
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(970, 56);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 609);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(970, 31);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 56);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 553);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(970, 56);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 553);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.BarManager;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
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
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.ID = new System.Guid("fad79bd7-2784-4090-8e88-e62b0d8ef483");
            this.dockPanel1.Location = new System.Drawing.Point(0, 481);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 128);
            this.dockPanel1.Size = new System.Drawing.Size(970, 128);
            this.dockPanel1.Text = "Logging";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gpLogging);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 30);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(964, 95);
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
            this.gpLogging.Size = new System.Drawing.Size(964, 95);
            this.gpLogging.TabIndex = 40;
            this.gpLogging.Text = "Logging";
            // 
            // txtHistory
            // 
            this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistory.Location = new System.Drawing.Point(2, 23);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistory.Size = new System.Drawing.Size(960, 70);
            this.txtHistory.TabIndex = 33;
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
            this.mailGroup,
            this.organizerGroup,
            this.navBarGroup1});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.ServiceItem,
            this.SQLItem,
            this.SQLiteItem,
            this.LoggingItem,
            this.TagManagerItem,
            this.SQLManagerItem,
            this.navFrameMonitor});
            this.navBarControl.LargeImages = this.imageList1;
            this.navBarControl.Location = new System.Drawing.Point(0, 56);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 166;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(166, 425);
            this.navBarControl.SmallImages = this.imageList1;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 34;
            this.navBarControl.Text = "navBarControl1";
            // 
            // organizerGroup
            // 
            this.organizerGroup.Caption = "Database";
            this.organizerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.SQLItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SQLiteItem)});
            this.organizerGroup.Name = "organizerGroup";
            // 
            // SQLItem
            // 
            this.SQLItem.Caption = "Microsoft SQL Server";
            this.SQLItem.ImageOptions.SmallImageIndex = 7;
            this.SQLItem.Name = "SQLItem";
            this.SQLItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SQLItem_LinkClicked);
            // 
            // SQLiteItem
            // 
            this.SQLiteItem.Caption = "SQLite";
            this.SQLiteItem.ImageOptions.SmallImageIndex = 7;
            this.SQLiteItem.Name = "SQLiteItem";
            this.SQLiteItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SQLiteItem_LinkClicked);
            // 
            // mailGroup
            // 
            this.mailGroup.Caption = "Management";
            this.mailGroup.Expanded = true;
            this.mailGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.ServiceItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.LoggingItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.TagManagerItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.SQLManagerItem)});
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
            // LoggingItem
            // 
            this.LoggingItem.Caption = "Logging";
            this.LoggingItem.ImageOptions.SmallImageIndex = 4;
            this.LoggingItem.Name = "LoggingItem";
            this.LoggingItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.LoggingItem_LinkClicked);
            // 
            // TagManagerItem
            // 
            this.TagManagerItem.Caption = "Tag Manager";
            this.TagManagerItem.ImageOptions.SmallImageIndex = 5;
            this.TagManagerItem.Name = "TagManagerItem";
            this.TagManagerItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.TagManagerItem_LinkClicked);
            // 
            // SQLManagerItem
            // 
            this.SQLManagerItem.Caption = "SQLManager";
            this.SQLManagerItem.ImageOptions.SmallImageIndex = 6;
            this.SQLManagerItem.Name = "SQLManagerItem";
            this.SQLManagerItem.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.SQLManagerItem_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "FrameMonitor";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navFrameMonitor)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navFrameMonitor
            // 
            this.navFrameMonitor.Caption = "FormFrameMonitor";
            this.navFrameMonitor.ImageOptions.SmallImageIndex = 0;
            this.navFrameMonitor.Name = "navFrameMonitor";
            this.navFrameMonitor.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navFrameMonitor_LinkClicked);
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
            this.popupMenuNotifyIcon.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemView),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemExit)});
            this.popupMenuNotifyIcon.Manager = this.BarManager;
            this.popupMenuNotifyIcon.Name = "popupMenuNotifyIcon";
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
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // taskbarAssistant1
            // 
            this.taskbarAssistant1.OverlayIcon = global::AdvancedScada.Studio.Properties.Resources.AddChannel;
            this.taskbarAssistant1.ParentControl = this;
            // 
            // FormStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 640);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FormStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Studio 2018";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStudio_FormClosing);
            this.Load += new System.EventHandler(this.FormS7Studio_Load);
            this.Resize += new System.EventHandler(this.FormStudio_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpLogging)).EndInit();
            this.gpLogging.ResumeLayout(false);
            this.gpLogging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuNotifyIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal DevExpress.XtraBars.BarManager BarManager;
		internal DevExpress.XtraBars.Bar Bar1;
		internal DevExpress.XtraBars.Bar Bar2;
		internal DevExpress.XtraBars.Bar Bar3;
		internal DevExpress.XtraBars.BarDockControl barDockControlTop;
		internal DevExpress.XtraBars.BarDockControl barDockControlBottom;
		internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
        internal DevExpress.XtraBars.BarDockControl barDockControlRight;
        internal DevExpress.LookAndFeel.DefaultLookAndFeel LookAndFeel1;
        internal DevExpress.XtraBars.BarSubItem mOption;
        internal DevExpress.XtraBars.BarButtonItem mConfiguration;
        internal DevExpress.XtraBars.BarButtonItem mSQLServerUtils;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraBars.BarCheckItem barCheckEnabele;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonLibraryImages;
        private DevExpress.XtraBars.BarButtonItem barButtonDownload;
        private DevExpress.XtraBars.BarButtonItem mnMonioring;
        private ImageList imageList1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup mailGroup;
        private DevExpress.XtraNavBar.NavBarItem ServiceItem;
        private DevExpress.XtraNavBar.NavBarItem LoggingItem;
        private DevExpress.XtraNavBar.NavBarItem TagManagerItem;
        private DevExpress.XtraNavBar.NavBarItem SQLManagerItem;
        private DevExpress.XtraNavBar.NavBarGroup organizerGroup;
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
        private DevExpress.XtraBars.BarButtonItem mPCControllercs;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navFrameMonitor;
        private DevExpress.XtraBars.BarSubItem mCommands;
        private DevExpress.XtraBars.BarButtonItem mStart;
        private DevExpress.XtraBars.BarButtonItem mStop;
        private DevExpress.XtraBars.BarButtonItem mPause;
        private DevExpress.XtraBars.BarButtonItem mResume;
        private DevExpress.XtraBars.BarButtonItem mRestart;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private GroupControl gpLogging;
        private TextBox txtHistory;

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