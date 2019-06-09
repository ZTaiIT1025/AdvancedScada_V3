namespace AdvancedScada.Studio.Logging
{
    partial class XtraFormLogging
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFormLogging));
            this.GridControl1 = new DevExpress.XtraGrid.GridControl();
            this.realTimeSource1 = new DevExpress.Data.RealTimeSource();
            this.GridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LogTypeColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColMESSAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridControl1
            // 
            this.GridControl1.DataSource = this.realTimeSource1;
            this.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.GridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.GridControl1.Location = new System.Drawing.Point(0, 0);
            this.GridControl1.MainView = this.GridView1;
            this.GridControl1.Name = "GridControl1";
            this.GridControl1.Size = new System.Drawing.Size(783, 402);
            this.GridControl1.TabIndex = 5;
            this.GridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GridView1});
            // 
            // realTimeSource1
            // 
            this.realTimeSource1.DisplayableProperties = "ID;LogType;TIME;MESSAGE";
            // 
            // GridView1
            // 
            this.GridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdColumn,
            this.LogTypeColumn,
            this.ColTIME,
            this.ColMESSAGE});
            this.GridView1.GridControl = this.GridControl1;
            this.GridView1.Name = "GridView1";
            this.GridView1.OptionsView.ShowAutoFilterRow = true;
            this.GridView1.OptionsView.ShowViewCaption = true;
            // 
            // IdColumn
            // 
            this.IdColumn.Caption = "ID";
            this.IdColumn.FieldName = "ID";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.Visible = true;
            this.IdColumn.VisibleIndex = 0;
            // 
            // LogTypeColumn
            // 
            this.LogTypeColumn.Caption = "Log Type";
            this.LogTypeColumn.FieldName = "LogType";
            this.LogTypeColumn.Name = "LogTypeColumn";
            this.LogTypeColumn.Visible = true;
            this.LogTypeColumn.VisibleIndex = 1;
            // 
            // ColTIME
            // 
            this.ColTIME.Caption = "TIME";
            this.ColTIME.FieldName = "TIME";
            this.ColTIME.Name = "ColTIME";
            this.ColTIME.OptionsColumn.AllowEdit = false;
            this.ColTIME.OptionsColumn.AllowMove = false;
            this.ColTIME.OptionsColumn.ReadOnly = true;
            this.ColTIME.Visible = true;
            this.ColTIME.VisibleIndex = 2;
            this.ColTIME.Width = 195;
            // 
            // ColMESSAGE
            // 
            this.ColMESSAGE.Caption = "MESSAGE";
            this.ColMESSAGE.FieldName = "MESSAGE";
            this.ColMESSAGE.Name = "ColMESSAGE";
            this.ColMESSAGE.OptionsColumn.AllowEdit = false;
            this.ColMESSAGE.OptionsColumn.ReadOnly = true;
            this.ColMESSAGE.Visible = true;
            this.ColMESSAGE.VisibleIndex = 3;
            this.ColMESSAGE.Width = 345;
            // 
            // XtraFormLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 402);
            this.Controls.Add(this.GridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XtraFormLogging";
            this.Text = "Logging";
            this.Load += new System.EventHandler(this.XtraFormLogging_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraGrid.GridControl GridControl1;
        internal DevExpress.XtraGrid.Views.Grid.GridView GridView1;
        internal DevExpress.XtraGrid.Columns.GridColumn ColTIME;
        internal DevExpress.XtraGrid.Columns.GridColumn ColMESSAGE;
        private DevExpress.XtraGrid.Columns.GridColumn IdColumn;
        private DevExpress.XtraGrid.Columns.GridColumn LogTypeColumn;
        private DevExpress.Data.RealTimeSource realTimeSource1;
    }
}