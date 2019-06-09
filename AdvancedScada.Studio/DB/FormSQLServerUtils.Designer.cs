
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace AdvancedScada.Studio.DB
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class FormSQLServerUtils : DevExpress.XtraEditors.XtraForm
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

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQLServerUtils));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.DBListLookUpEdit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.ColDBId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColDBName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColCreateDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.SplitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.TableNamesListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.ColumnLookUpEdit = new DevExpress.XtraGrid.GridControl();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ImageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBListLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).BeginInit();
            this.SplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableNamesListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.DBListLookUpEdit);
            this.LayoutControl1.Controls.Add(this.SplitContainerControl1);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(736, 531);
            this.LayoutControl1.TabIndex = 0;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // DBListLookUpEdit
            // 
            this.DBListLookUpEdit.EditValue = "";
            this.DBListLookUpEdit.Location = new System.Drawing.Point(82, 12);
            this.DBListLookUpEdit.Name = "DBListLookUpEdit";
            editorButtonImageOptions1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.DBListLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DBListLookUpEdit.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DBListLookUpEdit.Properties.ContextImageOptions.Image")));
            this.DBListLookUpEdit.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.DBListLookUpEdit.Size = new System.Drawing.Size(642, 20);
            this.DBListLookUpEdit.StyleController = this.LayoutControl1;
            this.DBListLookUpEdit.TabIndex = 6;
            this.DBListLookUpEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DBListLookUpEdit_ButtonClick);
            this.DBListLookUpEdit.EditValueChanged += new System.EventHandler(this.DBListLookUpEdit_EditValueChanged);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColDBId,
            this.ColDBName,
            this.ColCreateDate,
            this.ColStatus});
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // ColDBId
            // 
            this.ColDBId.Caption = "DBId";
            this.ColDBId.FieldName = "DBID";
            this.ColDBId.Name = "ColDBId";
            this.ColDBId.Visible = true;
            this.ColDBId.VisibleIndex = 0;
            // 
            // ColDBName
            // 
            this.ColDBName.Caption = "DB Name";
            this.ColDBName.FieldName = "DatabaseName";
            this.ColDBName.Name = "ColDBName";
            this.ColDBName.Visible = true;
            this.ColDBName.VisibleIndex = 1;
            // 
            // ColCreateDate
            // 
            this.ColCreateDate.Caption = "Create Date";
            this.ColCreateDate.FieldName = "CreateDate";
            this.ColCreateDate.Name = "ColCreateDate";
            this.ColCreateDate.Visible = true;
            this.ColCreateDate.VisibleIndex = 2;
            // 
            // ColStatus
            // 
            this.ColStatus.Caption = "Status";
            this.ColStatus.FieldName = "State";
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.Visible = true;
            this.ColStatus.VisibleIndex = 3;
            // 
            // SplitContainerControl1
            // 
            this.SplitContainerControl1.Location = new System.Drawing.Point(12, 36);
            this.SplitContainerControl1.Name = "SplitContainerControl1";
            this.SplitContainerControl1.Panel1.Controls.Add(this.GroupControl1);
            this.SplitContainerControl1.Panel1.Text = "Panel1";
            this.SplitContainerControl1.Panel2.Controls.Add(this.ColumnLookUpEdit);
            this.SplitContainerControl1.Panel2.Text = "Panel2";
            this.SplitContainerControl1.Size = new System.Drawing.Size(712, 483);
            this.SplitContainerControl1.SplitterPosition = 182;
            this.SplitContainerControl1.TabIndex = 5;
            this.SplitContainerControl1.Text = "SplitContainerControl1";
            // 
            // GroupControl1
            // 
            this.GroupControl1.CaptionImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Database_16x16;
            this.GroupControl1.Controls.Add(this.TableNamesListBox);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(182, 483);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Tables";
            // 
            // TableNamesListBox
            // 
            this.TableNamesListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TableNamesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableNamesListBox.Location = new System.Drawing.Point(2, 23);
            this.TableNamesListBox.Name = "TableNamesListBox";
            this.TableNamesListBox.Size = new System.Drawing.Size(178, 458);
            this.TableNamesListBox.TabIndex = 0;
            this.TableNamesListBox.SelectedIndexChanged += new System.EventHandler(this.TableNamesListBox_SelectedIndexChanged);
            this.TableNamesListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TableNamesListBox_MouseClick);
            // 
            // ColumnLookUpEdit
            // 
            this.ColumnLookUpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColumnLookUpEdit.Location = new System.Drawing.Point(0, 0);
            this.ColumnLookUpEdit.MainView = this.GridView1;
            this.ColumnLookUpEdit.Name = "ColumnLookUpEdit";
            this.ColumnLookUpEdit.Size = new System.Drawing.Size(524, 483);
            this.ColumnLookUpEdit.TabIndex = 0;
            this.ColumnLookUpEdit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GridColumn1,
            this.GridColumn2,
            this.GridColumn3,
            this.GridColumn4,
            this.GridColumn5,
            this.GridColumn6,
            this.GridColumn7});
            this.GridView1.GridControl = this.ColumnLookUpEdit;
            this.GridView1.Name = "GridView1";
            // 
            // GridColumn1
            // 
            this.GridColumn1.Caption = "Column Name";
            this.GridColumn1.FieldName = "ColumnName";
            this.GridColumn1.Name = "GridColumn1";
            this.GridColumn1.Visible = true;
            this.GridColumn1.VisibleIndex = 0;
            // 
            // GridColumn2
            // 
            this.GridColumn2.Caption = "Data Type";
            this.GridColumn2.FieldName = "DataType";
            this.GridColumn2.Name = "GridColumn2";
            this.GridColumn2.Visible = true;
            this.GridColumn2.VisibleIndex = 1;
            // 
            // GridColumn3
            // 
            this.GridColumn3.Caption = "Max Length";
            this.GridColumn3.FieldName = "MaxLength";
            this.GridColumn3.Name = "GridColumn3";
            this.GridColumn3.Visible = true;
            this.GridColumn3.VisibleIndex = 2;
            // 
            // GridColumn4
            // 
            this.GridColumn4.Caption = "Precision";
            this.GridColumn4.FieldName = "Precision";
            this.GridColumn4.Name = "GridColumn4";
            this.GridColumn4.Visible = true;
            this.GridColumn4.VisibleIndex = 3;
            // 
            // GridColumn5
            // 
            this.GridColumn5.Caption = "Scale";
            this.GridColumn5.FieldName = "Scale";
            this.GridColumn5.Name = "GridColumn5";
            this.GridColumn5.Visible = true;
            this.GridColumn5.VisibleIndex = 4;
            // 
            // GridColumn6
            // 
            this.GridColumn6.Caption = "Is Nullable";
            this.GridColumn6.FieldName = "IsNullable";
            this.GridColumn6.Name = "GridColumn6";
            this.GridColumn6.Visible = true;
            this.GridColumn6.VisibleIndex = 5;
            // 
            // GridColumn7
            // 
            this.GridColumn7.Caption = "Primary Key";
            this.GridColumn7.FieldName = "PrimaryKey";
            this.GridColumn7.Name = "GridColumn7";
            this.GridColumn7.Visible = true;
            this.GridColumn7.VisibleIndex = 6;
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1";
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem2,
            this.layoutControlItem1});
            this.LayoutControlGroup1.Name = "LayoutControlGroup1";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(736, 531);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.SplitContainerControl1;
            this.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2";
            this.LayoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(716, 487);
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.DBListLookUpEdit;
            this.layoutControlItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("layoutControlItem1.ImageOptions.Image")));
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(716, 24);
            this.layoutControlItem1.Text = "Databaes";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(67, 16);
            // 
            // ImageCollection1
            // 
            this.ImageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection1.ImageStream")));
            this.ImageCollection1.Images.SetKeyName(0, "Database_16x16.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // FormSQLServerUtils
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 531);
            this.Controls.Add(this.LayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSQLServerUtils";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server Utils";
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DBListLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerControl1)).EndInit();
            this.SplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableNamesListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection1)).EndInit();
            this.ResumeLayout(false);

		}
		internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
		internal DevExpress.Utils.ImageCollection ImageCollection1;
		internal DevExpress.XtraEditors.SplitContainerControl SplitContainerControl1;
		internal DevExpress.XtraGrid.GridControl ColumnLookUpEdit;
		internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
		internal DevExpress.XtraEditors.GroupControl GroupControl1;
		internal DevExpress.XtraEditors.ListBoxControl TableNamesListBox;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn1;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn2;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn3;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn4;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn5;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn6;
		internal DevExpress.XtraGrid.Columns.GridColumn GridColumn7;
        private DevExpress.XtraEditors.TreeListLookUpEdit DBListLookUpEdit;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColDBId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColDBName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColCreateDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColStatus;
        private OpenFileDialog openFileDialog;
    }

}