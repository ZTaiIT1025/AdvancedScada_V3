using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace AdvancedScada.Studio.IE
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FormImport : DevExpress.XtraEditors.XtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImport));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.S7ImageCollection = new DevExpress.Utils.ImageCollection();
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gcTag = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboxSheet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPathFile = new DevExpress.XtraEditors.ButtonEdit();
            this.txtDevice = new DevExpress.XtraEditors.TextEdit();
            this.txtDataBlock = new DevExpress.XtraEditors.TextEdit();
            this.txtChannel = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EmptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.LayoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.S7ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPathFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBlock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // S7ImageCollection
            // 
            this.S7ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("S7ImageCollection.ImageStream")));
            this.S7ImageCollection.Images.SetKeyName(0, "AddChannel.png");
            this.S7ImageCollection.Images.SetKeyName(1, "AddDataBlock.png");
            this.S7ImageCollection.Images.SetKeyName(2, "AddDevice.png");
            this.S7ImageCollection.Images.SetKeyName(3, "AddGoup.png");
            this.S7ImageCollection.Images.SetKeyName(4, "AddTag.png");
            this.S7ImageCollection.Images.SetKeyName(5, "Channel.png");
            this.S7ImageCollection.Images.SetKeyName(6, "Close.png");
            this.S7ImageCollection.Images.SetKeyName(7, "Delete.png");
            this.S7ImageCollection.Images.SetKeyName(8, "Device.png");
            this.S7ImageCollection.Images.SetKeyName(9, "Exit.png");
            this.S7ImageCollection.Images.SetKeyName(10, "Group.png");
            this.S7ImageCollection.Images.SetKeyName(11, "Help.png");
            this.S7ImageCollection.Images.SetKeyName(12, "New.png");
            this.S7ImageCollection.Images.SetKeyName(13, "Open.png");
            this.S7ImageCollection.Images.SetKeyName(14, "Play.png");
            this.S7ImageCollection.Images.SetKeyName(15, "Quit.png");
            this.S7ImageCollection.Images.SetKeyName(16, "Save.png");
            this.S7ImageCollection.Images.SetKeyName(17, "SaveAs.png");
            this.S7ImageCollection.Images.SetKeyName(18, "Stop.png");
            this.S7ImageCollection.Images.SetKeyName(19, "Tag.png");
            this.S7ImageCollection.Images.SetKeyName(20, "TagManager.png");
            this.S7ImageCollection.Images.SetKeyName(21, "TreeView_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(22, "Tag_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(23, "Export_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(24, "ExportToXLS_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(25, "Print_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(26, "Example_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(27, "Database_16x16.png");
            this.S7ImageCollection.Images.SetKeyName(28, "IDE_16x16.png");
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.btnExecute);
            this.LayoutControl1.Controls.Add(this.btnOK);
            this.LayoutControl1.Controls.Add(this.gcTag);
            this.LayoutControl1.Controls.Add(this.cboxSheet);
            this.LayoutControl1.Controls.Add(this.btnPathFile);
            this.LayoutControl1.Controls.Add(this.txtDevice);
            this.LayoutControl1.Controls.Add(this.txtDataBlock);
            this.LayoutControl1.Controls.Add(this.txtChannel);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(847, 452);
            this.LayoutControl1.TabIndex = 0;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(602, 418);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(123, 22);
            this.btnExecute.StyleController = this.LayoutControl1;
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Execute";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(729, 418);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 22);
            this.btnOK.StyleController = this.LayoutControl1;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Cancel";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gcTag
            // 
            this.gcTag.Location = new System.Drawing.Point(12, 68);
            this.gcTag.MainView = this.GridView1;
            this.gcTag.Name = "gcTag";
            this.gcTag.Size = new System.Drawing.Size(823, 346);
            this.gcTag.TabIndex = 9;
            this.gcTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            this.gcTag.Click += new System.EventHandler(this.gcTag_Click);
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn1,
            this.GridColumn2,
            this.GridColumn3,
            this.GridColumn4,
            this.GridColumn6});
            this.GridView1.GridControl = this.gcTag;
            this.GridView1.Name = "GridView1";
            // 
            // GridColumn1
            // 
            this.GridColumn1.Caption = "TagId";
            this.GridColumn1.FieldName = "TagId";
            this.GridColumn1.Name = "GridColumn1";
            this.GridColumn1.Visible = true;
            this.GridColumn1.VisibleIndex = 0;
            // 
            // GridColumn2
            // 
            this.GridColumn2.Caption = "TagName";
            this.GridColumn2.FieldName = "TagName";
            this.GridColumn2.Name = "GridColumn2";
            this.GridColumn2.Visible = true;
            this.GridColumn2.VisibleIndex = 1;
            // 
            // GridColumn3
            // 
            this.GridColumn3.Caption = "Address";
            this.GridColumn3.FieldName = "Address";
            this.GridColumn3.Name = "GridColumn3";
            this.GridColumn3.Visible = true;
            this.GridColumn3.VisibleIndex = 2;
            // 
            // GridColumn4
            // 
            this.GridColumn4.Caption = "DataType";
            this.GridColumn4.FieldName = "DataType";
            this.GridColumn4.Name = "GridColumn4";
            this.GridColumn4.Visible = true;
            this.GridColumn4.VisibleIndex = 3;
            // 
            // GridColumn6
            // 
            this.GridColumn6.Caption = "Description";
            this.GridColumn6.FieldName = "Description";
            this.GridColumn6.Name = "GridColumn6";
            this.GridColumn6.Visible = true;
            this.GridColumn6.VisibleIndex = 4;
            // 
            // cboxSheet
            // 
            this.cboxSheet.Location = new System.Drawing.Point(475, 36);
            this.cboxSheet.Name = "cboxSheet";
            this.cboxSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboxSheet.Size = new System.Drawing.Size(360, 20);
            this.cboxSheet.StyleController = this.LayoutControl1;
            this.cboxSheet.TabIndex = 8;
            this.cboxSheet.SelectedIndexChanged += new System.EventHandler(this.cboxSheet_SelectedIndexChanged);
            // 
            // btnPathFile
            // 
            this.btnPathFile.Location = new System.Drawing.Point(62, 36);
            this.btnPathFile.Name = "btnPathFile";
            this.btnPathFile.Properties.Appearance.Options.UseImage = true;
            editorButtonImageOptions1.ImageIndex = 0;
            editorButtonImageOptions1.ImageList = this.S7ImageCollection;
            editorButtonImageOptions1.ImageUri.Uri = "AddNewDataSource;Size16x16";
            this.btnPathFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnPathFile.Size = new System.Drawing.Size(359, 22);
            this.btnPathFile.StyleController = this.LayoutControl1;
            this.btnPathFile.TabIndex = 7;
            this.btnPathFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnPathFile_ButtonClick);
            this.btnPathFile.EditValueChanged += new System.EventHandler(this.cboxSheet_SelectedIndexChanged);
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(348, 12);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(228, 20);
            this.txtDevice.StyleController = this.LayoutControl1;
            this.txtDevice.TabIndex = 6;
            // 
            // txtDataBlock
            // 
            this.txtDataBlock.Location = new System.Drawing.Point(630, 12);
            this.txtDataBlock.Name = "txtDataBlock";
            this.txtDataBlock.Size = new System.Drawing.Size(205, 20);
            this.txtDataBlock.StyleController = this.LayoutControl1;
            this.txtDataBlock.TabIndex = 5;
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(62, 12);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(232, 20);
            this.txtChannel.StyleController = this.LayoutControl1;
            this.txtChannel.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1";
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem2,
            this.LayoutControlItem1,
            this.LayoutControlItem3,
            this.LayoutControlItem4,
            this.LayoutControlItem5,
            this.EmptySpaceItem2,
            this.LayoutControlItem6,
            this.LayoutControlItem7,
            this.LayoutControlItem8});
            this.LayoutControlGroup1.Name = "LayoutControlGroup1";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(847, 452);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.txtDataBlock;
            this.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2";
            this.LayoutControlItem2.Location = new System.Drawing.Point(568, 0);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(259, 24);
            this.LayoutControlItem2.Text = "DataBlock";
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(47, 13);
            // 
            // LayoutControlItem1
            // 
            this.LayoutControlItem1.Control = this.txtChannel;
            this.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1";
            this.LayoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem1.Name = "LayoutControlItem1";
            this.LayoutControlItem1.Size = new System.Drawing.Size(286, 24);
            this.LayoutControlItem1.Text = "Channel";
            this.LayoutControlItem1.TextSize = new System.Drawing.Size(47, 13);
            // 
            // LayoutControlItem3
            // 
            this.LayoutControlItem3.Control = this.txtDevice;
            this.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3";
            this.LayoutControlItem3.Location = new System.Drawing.Point(286, 0);
            this.LayoutControlItem3.Name = "LayoutControlItem3";
            this.LayoutControlItem3.Size = new System.Drawing.Size(282, 24);
            this.LayoutControlItem3.Text = "Device";
            this.LayoutControlItem3.TextSize = new System.Drawing.Size(47, 13);
            // 
            // LayoutControlItem4
            // 
            this.LayoutControlItem4.Control = this.btnPathFile;
            this.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4";
            this.LayoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItem4.MinSize = new System.Drawing.Size(104, 26);
            this.LayoutControlItem4.Name = "LayoutControlItem4";
            this.LayoutControlItem4.Size = new System.Drawing.Size(413, 32);
            this.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.LayoutControlItem4.Text = "Path File";
            this.LayoutControlItem4.TextSize = new System.Drawing.Size(47, 13);
            // 
            // LayoutControlItem5
            // 
            this.LayoutControlItem5.Control = this.cboxSheet;
            this.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5";
            this.LayoutControlItem5.Location = new System.Drawing.Point(413, 24);
            this.LayoutControlItem5.MinSize = new System.Drawing.Size(104, 24);
            this.LayoutControlItem5.Name = "LayoutControlItem5";
            this.LayoutControlItem5.Size = new System.Drawing.Size(414, 32);
            this.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.LayoutControlItem5.Text = "Sheet";
            this.LayoutControlItem5.TextSize = new System.Drawing.Size(47, 13);
            // 
            // EmptySpaceItem2
            // 
            this.EmptySpaceItem2.AllowHotTrack = false;
            this.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2";
            this.EmptySpaceItem2.Location = new System.Drawing.Point(0, 406);
            this.EmptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.EmptySpaceItem2.Name = "EmptySpaceItem2";
            this.EmptySpaceItem2.Size = new System.Drawing.Size(590, 26);
            this.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.EmptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // LayoutControlItem6
            // 
            this.LayoutControlItem6.Control = this.gcTag;
            this.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6";
            this.LayoutControlItem6.Location = new System.Drawing.Point(0, 56);
            this.LayoutControlItem6.Name = "LayoutControlItem6";
            this.LayoutControlItem6.Size = new System.Drawing.Size(827, 350);
            this.LayoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem6.TextVisible = false;
            // 
            // LayoutControlItem7
            // 
            this.LayoutControlItem7.Control = this.btnOK;
            this.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7";
            this.LayoutControlItem7.Location = new System.Drawing.Point(717, 406);
            this.LayoutControlItem7.Name = "LayoutControlItem7";
            this.LayoutControlItem7.Size = new System.Drawing.Size(110, 26);
            this.LayoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem7.TextVisible = false;
            // 
            // LayoutControlItem8
            // 
            this.LayoutControlItem8.Control = this.btnExecute;
            this.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8";
            this.LayoutControlItem8.Location = new System.Drawing.Point(590, 406);
            this.LayoutControlItem8.Name = "LayoutControlItem8";
            this.LayoutControlItem8.Size = new System.Drawing.Size(127, 26);
            this.LayoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem8.TextVisible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 452);
            this.Controls.Add(this.LayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImport";
            this.Text = "FormImport";
            this.Load += new System.EventHandler(this.FormImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.S7ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboxSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPathFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBlock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem8)).EndInit();
            this.ResumeLayout(false);

		}
		internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
		internal DevExpress.XtraEditors.TextEdit txtDevice;
		internal DevExpress.XtraEditors.TextEdit txtDataBlock;
		internal DevExpress.XtraEditors.TextEdit txtChannel;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraEditors.ComboBoxEdit cboxSheet;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem5;
		internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem2;
		internal DevExpress.XtraEditors.SimpleButton btnExecute;
		internal DevExpress.XtraEditors.SimpleButton btnOK;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem8;
		internal DevExpress.XtraGrid.GridControl gcTag;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem6;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn1;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn2;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn3;
        internal DevExpress.XtraGrid.Columns.GridColumn GridColumn4;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn6;
        internal DevExpress.Utils.ImageCollection S7ImageCollection;
        private DevExpress.XtraEditors.ButtonEdit btnPathFile;
        private OpenFileDialog openFileDialog;

        public IContainer Components { get => components; set => components = value; }
    }

}