//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace AdvancedScada.Studio.Config
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FormConfiguration : DevExpress.XtraEditors.XtraForm
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
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguration));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.XtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.ImageCollection1 = new DevExpress.Utils.ImageCollection();
            this.XtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.LayoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtPort = new DevExpress.XtraEditors.SpinEdit();
            this.txtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.XtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.LayoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboxDatabaseTypes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LayoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbLibraryImage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl7 = new DevExpress.XtraLayout.LayoutControl();
            this.cboxLibraryImage = new DevExpress.XtraEditors.ButtonEdit();
            this.cboxTypeForms = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutLibraryImage = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutTypeForms = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.FBDLibraryImage = new System.Windows.Forms.FolderBrowserDialog();
            this.FBDSymbols = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabControl1)).BeginInit();
            this.XtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).BeginInit();
            this.XtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl2)).BeginInit();
            this.LayoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem2)).BeginInit();
            this.XtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl3)).BeginInit();
            this.LayoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDatabaseTypes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            this.tbLibraryImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).BeginInit();
            this.layoutControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxLibraryImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxTypeForms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLibraryImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTypeForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.btnCancel);
            this.LayoutControl1.Controls.Add(this.btnOK);
            this.LayoutControl1.Controls.Add(this.XtraTabControl1);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(492, 333);
            this.LayoutControl1.TabIndex = 0;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(366, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 22);
            this.btnCancel.StyleController = this.LayoutControl1;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(248, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 22);
            this.btnOK.StyleController = this.LayoutControl1;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // XtraTabControl1
            // 
            this.XtraTabControl1.Images = this.ImageCollection1;
            this.XtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.XtraTabControl1.Name = "XtraTabControl1";
            this.XtraTabControl1.SelectedTabPage = this.XtraTabPage1;
            this.XtraTabControl1.Size = new System.Drawing.Size(468, 283);
            this.XtraTabControl1.TabIndex = 4;
            this.XtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.XtraTabPage1,
            this.XtraTabPage2,
            this.tbLibraryImage});
            // 
            // ImageCollection1
            // 
            this.ImageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection1.ImageStream")));
            this.ImageCollection1.Images.SetKeyName(0, "Database_16x16.png");
            this.ImageCollection1.Images.SetKeyName(1, "SelectData_16x16.png");
            this.ImageCollection1.Images.SetKeyName(2, "PrintDialog_16x16.png");
            // 
            // XtraTabPage1
            // 
            this.XtraTabPage1.Controls.Add(this.LayoutControl2);
            this.XtraTabPage1.ImageOptions.ImageIndex = 1;
            this.XtraTabPage1.Name = "XtraTabPage1";
            this.XtraTabPage1.Size = new System.Drawing.Size(463, 254);
            this.XtraTabPage1.Text = "PC Server";
            // 
            // LayoutControl2
            // 
            this.LayoutControl2.Controls.Add(this.txtPort);
            this.LayoutControl2.Controls.Add(this.txtIPAddress);
            this.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl2.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl2.Name = "LayoutControl2";
            this.LayoutControl2.Root = this.LayoutControlGroup2;
            this.LayoutControl2.Size = new System.Drawing.Size(463, 254);
            this.LayoutControl2.TabIndex = 0;
            this.LayoutControl2.Text = "LayoutControl2";
            // 
            // txtPort
            // 
            this.txtPort.EditValue = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            this.txtPort.Location = new System.Drawing.Point(350, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPort.Size = new System.Drawing.Size(101, 20);
            this.txtPort.StyleController = this.LayoutControl2;
            this.txtPort.TabIndex = 5;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.EditValue = "localhost";
            this.txtIPAddress.Location = new System.Drawing.Point(71, 12);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(216, 20);
            this.txtIPAddress.StyleController = this.LayoutControl2;
            this.txtIPAddress.TabIndex = 4;
            // 
            // LayoutControlGroup2
            // 
            this.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2";
            this.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup2.GroupBordersVisible = false;
            this.LayoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem4,
            this.LayoutControlItem5,
            this.EmptySpaceItem2});
            this.LayoutControlGroup2.Name = "LayoutControlGroup2";
            this.LayoutControlGroup2.Size = new System.Drawing.Size(463, 254);
            this.LayoutControlGroup2.TextVisible = false;
            // 
            // LayoutControlItem4
            // 
            this.LayoutControlItem4.Control = this.txtIPAddress;
            this.LayoutControlItem4.CustomizationFormText = "IP Address:";
            this.LayoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem4.Name = "LayoutControlItem4";
            this.LayoutControlItem4.Size = new System.Drawing.Size(279, 24);
            this.LayoutControlItem4.Text = "IP Address:";
            this.LayoutControlItem4.TextSize = new System.Drawing.Size(56, 13);
            // 
            // LayoutControlItem5
            // 
            this.LayoutControlItem5.Control = this.txtPort;
            this.LayoutControlItem5.CustomizationFormText = "Port:";
            this.LayoutControlItem5.Location = new System.Drawing.Point(279, 0);
            this.LayoutControlItem5.Name = "LayoutControlItem5";
            this.LayoutControlItem5.Size = new System.Drawing.Size(164, 24);
            this.LayoutControlItem5.Text = "Port:";
            this.LayoutControlItem5.TextSize = new System.Drawing.Size(56, 13);
            // 
            // EmptySpaceItem2
            // 
            this.EmptySpaceItem2.AllowHotTrack = false;
            this.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2";
            this.EmptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.EmptySpaceItem2.Name = "EmptySpaceItem2";
            this.EmptySpaceItem2.Size = new System.Drawing.Size(443, 210);
            this.EmptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // XtraTabPage2
            // 
            this.XtraTabPage2.Controls.Add(this.LayoutControl3);
            this.XtraTabPage2.ImageOptions.ImageIndex = 0;
            this.XtraTabPage2.Name = "XtraTabPage2";
            this.XtraTabPage2.Size = new System.Drawing.Size(458, 252);
            this.XtraTabPage2.Text = "SQL Server";
            // 
            // LayoutControl3
            // 
            this.LayoutControl3.Controls.Add(this.groupControl2);
            this.LayoutControl3.Controls.Add(this.txtServerName);
            this.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl3.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl3.Name = "LayoutControl3";
            this.LayoutControl3.Root = this.LayoutControlGroup3;
            this.LayoutControl3.Size = new System.Drawing.Size(458, 252);
            this.LayoutControl3.TabIndex = 0;
            this.LayoutControl3.Text = "LayoutControl3";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.cboxDatabaseTypes);
            this.groupControl2.Location = new System.Drawing.Point(12, 36);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(434, 204);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "ScreenDatabaseTypes";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "DatabaseTypes :";
            // 
            // cboxDatabaseTypes
            // 
            this.cboxDatabaseTypes.Location = new System.Drawing.Point(93, 23);
            this.cboxDatabaseTypes.Name = "cboxDatabaseTypes";
            this.cboxDatabaseTypes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxDatabaseTypes.Properties.Items.AddRange(new object[] {
            "SQLite",
            "SQL"});
            this.cboxDatabaseTypes.Size = new System.Drawing.Size(200, 20);
            this.cboxDatabaseTypes.TabIndex = 7;
            this.cboxDatabaseTypes.SelectedIndexChanged += new System.EventHandler(this.cboxDatabaseTypes_SelectedIndexChanged);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(77, 12);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtServerName.Size = new System.Drawing.Size(369, 20);
            this.txtServerName.StyleController = this.LayoutControl3;
            this.txtServerName.TabIndex = 4;
            // 
            // LayoutControlGroup3
            // 
            this.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3";
            this.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup3.GroupBordersVisible = false;
            this.LayoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem8,
            this.layoutControlItem14});
            this.LayoutControlGroup3.Name = "LayoutControlGroup3";
            this.LayoutControlGroup3.Size = new System.Drawing.Size(458, 252);
            this.LayoutControlGroup3.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            this.LayoutControlItem8.Control = this.txtServerName;
            this.LayoutControlItem8.CustomizationFormText = "Server Name";
            this.LayoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem8.Name = "LayoutControlItem8";
            this.LayoutControlItem8.Size = new System.Drawing.Size(438, 24);
            this.LayoutControlItem8.Text = "Server Name";
            this.LayoutControlItem8.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.groupControl2;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(438, 208);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // tbLibraryImage
            // 
            this.tbLibraryImage.Controls.Add(this.layoutControl7);
            this.tbLibraryImage.Name = "tbLibraryImage";
            this.tbLibraryImage.Size = new System.Drawing.Size(458, 252);
            this.tbLibraryImage.Text = "LibraryImage";
            // 
            // layoutControl7
            // 
            this.layoutControl7.Controls.Add(this.cboxLibraryImage);
            this.layoutControl7.Controls.Add(this.cboxTypeForms);
            this.layoutControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl7.Location = new System.Drawing.Point(0, 0);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.Root = this.layoutControlGroup6;
            this.layoutControl7.Size = new System.Drawing.Size(458, 252);
            this.layoutControl7.TabIndex = 0;
            this.layoutControl7.Text = "layoutControl7";
            // 
            // cboxLibraryImage
            // 
            this.cboxLibraryImage.Location = new System.Drawing.Point(82, 12);
            this.cboxLibraryImage.Name = "cboxLibraryImage";
            this.cboxLibraryImage.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("cboxLibraryImage.Properties.Appearance.Image")));
            this.cboxLibraryImage.Properties.Appearance.Options.UseImage = true;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.cboxLibraryImage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cboxLibraryImage.Size = new System.Drawing.Size(364, 22);
            this.cboxLibraryImage.StyleController = this.layoutControl7;
            this.cboxLibraryImage.TabIndex = 4;
            this.cboxLibraryImage.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboxLibraryImage_ButtonClick);
            // 
            // cboxTypeForms
            // 
            this.cboxTypeForms.Location = new System.Drawing.Point(82, 38);
            this.cboxTypeForms.Name = "cboxTypeForms";
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.cboxTypeForms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cboxTypeForms.Size = new System.Drawing.Size(364, 22);
            this.cboxTypeForms.StyleController = this.layoutControl7;
            this.cboxTypeForms.TabIndex = 5;
            this.cboxTypeForms.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboxTypeForms_ButtonClick);
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup6.GroupBordersVisible = false;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutLibraryImage,
            this.emptySpaceItem5,
            this.layoutTypeForms});
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(458, 252);
            this.layoutControlGroup6.TextVisible = false;
            // 
            // layoutLibraryImage
            // 
            this.layoutLibraryImage.Control = this.cboxLibraryImage;
            this.layoutLibraryImage.Location = new System.Drawing.Point(0, 0);
            this.layoutLibraryImage.Name = "layoutLibraryImage";
            this.layoutLibraryImage.Size = new System.Drawing.Size(438, 26);
            this.layoutLibraryImage.Text = "LibraryImage:";
            this.layoutLibraryImage.TextSize = new System.Drawing.Size(67, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(438, 180);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutTypeForms
            // 
            this.layoutTypeForms.Control = this.cboxTypeForms;
            this.layoutTypeForms.Location = new System.Drawing.Point(0, 26);
            this.layoutTypeForms.Name = "layoutTypeForms";
            this.layoutTypeForms.Size = new System.Drawing.Size(438, 26);
            this.layoutTypeForms.Text = "Symbols:";
            this.layoutTypeForms.TextSize = new System.Drawing.Size(67, 13);
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1";
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem1,
            this.EmptySpaceItem1,
            this.LayoutControlItem2,
            this.LayoutControlItem3});
            this.LayoutControlGroup1.Name = "LayoutControlGroup1";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(492, 333);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            this.LayoutControlItem1.Control = this.XtraTabControl1;
            this.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1";
            this.LayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem1.Name = "LayoutControlItem1";
            this.LayoutControlItem1.Size = new System.Drawing.Size(472, 287);
            this.LayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem1.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            this.EmptySpaceItem1.AllowHotTrack = false;
            this.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1";
            this.EmptySpaceItem1.Location = new System.Drawing.Point(0, 287);
            this.EmptySpaceItem1.Name = "EmptySpaceItem1";
            this.EmptySpaceItem1.Size = new System.Drawing.Size(236, 26);
            this.EmptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.btnOK;
            this.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2";
            this.LayoutControlItem2.Location = new System.Drawing.Point(236, 287);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(118, 26);
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem2.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            this.LayoutControlItem3.Control = this.btnCancel;
            this.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3";
            this.LayoutControlItem3.Location = new System.Drawing.Point(354, 287);
            this.LayoutControlItem3.Name = "LayoutControlItem3";
            this.LayoutControlItem3.Size = new System.Drawing.Size(118, 26);
            this.LayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem3.TextVisible = false;
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 333);
            this.Controls.Add(this.LayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XtraTabControl1)).EndInit();
            this.XtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).EndInit();
            this.XtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl2)).EndInit();
            this.LayoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem2)).EndInit();
            this.XtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl3)).EndInit();
            this.LayoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxDatabaseTypes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            this.tbLibraryImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).EndInit();
            this.layoutControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxLibraryImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxTypeForms.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLibraryImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutTypeForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).EndInit();
            this.ResumeLayout(false);

		}
        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
		internal DevExpress.XtraTab.XtraTabPage XtraTabPage1;
		internal DevExpress.XtraTab.XtraTabPage XtraTabPage2;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
		internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
		internal DevExpress.XtraEditors.SimpleButton btnOK;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
		internal DevExpress.XtraEditors.SimpleButton btnCancel;
		internal DevExpress.Utils.ImageCollection ImageCollection1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
		internal DevExpress.XtraLayout.LayoutControl LayoutControl2;
		internal DevExpress.XtraEditors.SpinEdit txtPort;
		internal DevExpress.XtraEditors.TextEdit txtIPAddress;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup2;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
		internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
		internal DevExpress.XtraLayout.LayoutControl LayoutControl3;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup3;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
        private DevExpress.XtraEditors.ComboBoxEdit txtServerName;
        public DevExpress.XtraTab.XtraTabControl XtraTabControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboxDatabaseTypes;
        private DevExpress.XtraTab.XtraTabPage tbLibraryImage;
        private DevExpress.XtraLayout.LayoutControl layoutControl7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlItem layoutLibraryImage;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutTypeForms;
        private DevExpress.XtraEditors.ButtonEdit cboxLibraryImage;
        private DevExpress.XtraEditors.ButtonEdit cboxTypeForms;
        private FolderBrowserDialog FBDLibraryImage;
        private FolderBrowserDialog FBDSymbols;

        public IContainer Components { get => components; set => components = value; }
    }

}