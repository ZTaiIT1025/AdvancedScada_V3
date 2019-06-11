namespace AdvancedScada.Studio.Service
{
    partial class FormFrameMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrameMonitor));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.chkPause = new DevExpress.XtraEditors.CheckEdit();
            this.ButtonStop = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.ButtonStart = new DevExpress.XtraEditors.SimpleButton();
            this.GridRequest = new DevExpress.XtraGrid.GridControl();
            this.realTimeRequest = new DevExpress.Data.RealTimeSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrame = new DevExpress.XtraGrid.Columns.GridColumn();
            this.realTimeResponse = new DevExpress.Data.RealTimeSource();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkButtonAscii = new DevExpress.XtraEditors.CheckButton();
            this.chkButtonHex = new DevExpress.XtraEditors.CheckButton();
            this.chkButtonbyte = new DevExpress.XtraEditors.CheckButton();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPause.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(765, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 340);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(765, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 311);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(765, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 311);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 29);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.GridRequest);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(765, 311);
            this.splitContainerControl1.SplitterPosition = 110;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.chkPause);
            this.groupControl2.Controls.Add(this.ButtonStop);
            this.groupControl2.Controls.Add(this.ButtonSave);
            this.groupControl2.Controls.Add(this.ButtonClose);
            this.groupControl2.Controls.Add(this.ButtonStart);
            this.groupControl2.Location = new System.Drawing.Point(193, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(381, 104);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Button All";
            // 
            // chkPause
            // 
            this.chkPause.Location = new System.Drawing.Point(103, 56);
            this.chkPause.MenuManager = this.barManager1;
            this.chkPause.Name = "chkPause";
            this.chkPause.Properties.Caption = "Pause";
            this.chkPause.Size = new System.Drawing.Size(75, 19);
            this.chkPause.TabIndex = 4;
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(5, 52);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(92, 23);
            this.ButtonStop.TabIndex = 3;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(201, 23);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(92, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save as File";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(103, 23);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(92, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(5, 23);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(92, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // GridRequest
            // 
            this.GridRequest.DataSource = this.realTimeRequest;
            this.GridRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridRequest.Location = new System.Drawing.Point(0, 0);
            this.GridRequest.MainView = this.gridView1;
            this.GridRequest.MenuManager = this.barManager1;
            this.GridRequest.Name = "GridRequest";
            this.GridRequest.Size = new System.Drawing.Size(765, 196);
            this.GridRequest.TabIndex = 0;
            this.GridRequest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // realTimeRequest
            // 
            this.realTimeRequest.DisplayableProperties = null;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResult,
            this.colSize,
            this.colTime,
            this.colFrame,
            this.colType});
            this.gridView1.GridControl = this.GridRequest;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // colResult
            // 
            this.colResult.Caption = "Result";
            this.colResult.FieldName = "Result";
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 1;
            this.colResult.Width = 90;
            // 
            // colSize
            // 
            this.colSize.Caption = "Size";
            this.colSize.FieldName = "Size";
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 2;
            this.colSize.Width = 56;
            // 
            // colTime
            // 
            this.colTime.Caption = "Time";
            this.colTime.FieldName = "CTime";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 3;
            this.colTime.Width = 151;
            // 
            // colFrame
            // 
            this.colFrame.Caption = "Frame Data";
            this.colFrame.FieldName = "FrameData";
            this.colFrame.Name = "colFrame";
            this.colFrame.Visible = true;
            this.colFrame.VisibleIndex = 4;
            this.colFrame.Width = 304;
            // 
            // realTimeResponse
            // 
            this.realTimeResponse.DisplayableProperties = null;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkButtonAscii);
            this.groupControl1.Controls.Add(this.chkButtonHex);
            this.groupControl1.Controls.Add(this.chkButtonbyte);
            this.groupControl1.Location = new System.Drawing.Point(3, 29);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(184, 104);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Select View";
            // 
            // chkButtonAscii
            // 
            this.chkButtonAscii.Location = new System.Drawing.Point(5, 48);
            this.chkButtonAscii.Name = "chkButtonAscii";
            this.chkButtonAscii.Size = new System.Drawing.Size(86, 23);
            this.chkButtonAscii.TabIndex = 2;
            this.chkButtonAscii.Text = "View by ASCII";
            // 
            // chkButtonHex
            // 
            this.chkButtonHex.Location = new System.Drawing.Point(4, 76);
            this.chkButtonHex.Name = "chkButtonHex";
            this.chkButtonHex.Size = new System.Drawing.Size(86, 23);
            this.chkButtonHex.TabIndex = 1;
            this.chkButtonHex.Text = "View by HEX";
            // 
            // chkButtonbyte
            // 
            this.chkButtonbyte.Location = new System.Drawing.Point(5, 21);
            this.chkButtonbyte.Name = "chkButtonbyte";
            this.chkButtonbyte.Size = new System.Drawing.Size(86, 23);
            this.chkButtonbyte.TabIndex = 0;
            this.chkButtonbyte.Text = "View by byte";
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            this.colType.Width = 91;
            // 
            // FormFrameMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 363);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFrameMonitor";
            this.Text = "FormFrameMonitor";
            this.Load += new System.EventHandler(this.FormFrameMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPause.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl GridRequest;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Data.RealTimeSource realTimeResponse;
        private DevExpress.Data.RealTimeSource realTimeRequest;
        private DevExpress.XtraEditors.CheckButton chkButtonAscii;
        private DevExpress.XtraEditors.CheckButton chkButtonHex;
        private DevExpress.XtraEditors.CheckButton chkButtonbyte;
        private DevExpress.XtraEditors.SimpleButton ButtonStop;
        private DevExpress.XtraEditors.SimpleButton ButtonSave;
        private DevExpress.XtraEditors.SimpleButton ButtonClose;
        private DevExpress.XtraEditors.SimpleButton ButtonStart;
        private DevExpress.XtraEditors.CheckEdit chkPause;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn colSize;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFrame;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
    }
}