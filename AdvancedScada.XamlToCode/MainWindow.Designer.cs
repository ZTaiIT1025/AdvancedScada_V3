namespace AdvancedScada.XamlToCode
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnConvert = new DevExpress.XtraBars.BarButtonItem();
            this.cboxConvertControls = new DevExpress.XtraBars.BarCheckItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.statusInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tbXamlToCode = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtXAML = new System.Windows.Forms.RichTextBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.barBtnDeleteList = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnBaek = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCopy = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXamlToCode)).BeginInit();
            this.tbXamlToCode.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnConvert,
            this.statusInfo,
            this.cboxConvertControls,
            this.barBtnDeleteList,
            this.barBtnBaek,
            this.barBtnCopy});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnConvert, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.cboxConvertControls, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnDeleteList, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnBaek, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnCopy, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnConvert
            // 
            this.btnConvert.Caption = "Convert";
            this.btnConvert.Id = 0;
            this.btnConvert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConvert.ImageOptions.Image")));
            this.btnConvert.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnConvert.ImageOptions.LargeImage")));
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConvert_ItemClick);
            // 
            // cboxConvertControls
            // 
            this.cboxConvertControls.Caption = "ConvertControls";
            this.cboxConvertControls.Id = 2;
            this.cboxConvertControls.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cboxConvertControls.ImageOptions.Image")));
            this.cboxConvertControls.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("cboxConvertControls.ImageOptions.LargeImage")));
            this.cboxConvertControls.Name = "cboxConvertControls";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.statusInfo)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // statusInfo
            // 
            this.statusInfo.Caption = "statusInfo";
            this.statusInfo.Id = 1;
            this.statusInfo.Name = "statusInfo";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(840, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 418);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(840, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 367);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(840, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 367);
            // 
            // tbXamlToCode
            // 
            this.tbXamlToCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbXamlToCode.Location = new System.Drawing.Point(0, 51);
            this.tbXamlToCode.Name = "tbXamlToCode";
            this.tbXamlToCode.SelectedTabPage = this.xtraTabPage1;
            this.tbXamlToCode.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tbXamlToCode.Size = new System.Drawing.Size(840, 367);
            this.tbXamlToCode.TabIndex = 4;
            this.tbXamlToCode.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtXAML);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(835, 362);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // txtXAML
            // 
            this.txtXAML.Location = new System.Drawing.Point(3, 3);
            this.txtXAML.Name = "txtXAML";
            this.txtXAML.Size = new System.Drawing.Size(829, 341);
            this.txtXAML.TabIndex = 0;
            this.txtXAML.Text = "";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.txtCode);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(835, 365);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(835, 365);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "";
            // 
            // barBtnDeleteList
            // 
            this.barBtnDeleteList.Caption = "Clear";
            this.barBtnDeleteList.Id = 3;
            this.barBtnDeleteList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barBtnDeleteList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barBtnDeleteList.Name = "barBtnDeleteList";
            this.barBtnDeleteList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDeleteList_ItemClick);
            // 
            // barBtnBaek
            // 
            this.barBtnBaek.Caption = "Baek";
            this.barBtnBaek.Id = 4;
            this.barBtnBaek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image1")));
            this.barBtnBaek.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage1")));
            this.barBtnBaek.Name = "barBtnBaek";
            this.barBtnBaek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnBaek_ItemClick);
            // 
            // barBtnCopy
            // 
            this.barBtnCopy.Caption = "Copy";
            this.barBtnCopy.Id = 5;
            this.barBtnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image2")));
            this.barBtnCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage2")));
            this.barBtnCopy.Name = "barBtnCopy";
            this.barBtnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCopy_ItemClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 446);
            this.Controls.Add(this.tbXamlToCode);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXamlToCode)).EndInit();
            this.tbXamlToCode.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnConvert;
        private DevExpress.XtraTab.XtraTabControl tbXamlToCode;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.RichTextBox txtXAML;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.RichTextBox txtCode;
        private DevExpress.XtraBars.BarStaticItem statusInfo;
        private DevExpress.XtraBars.BarCheckItem cboxConvertControls;
        private DevExpress.XtraBars.BarButtonItem barBtnDeleteList;
        private DevExpress.XtraBars.BarButtonItem barBtnBaek;
        private DevExpress.XtraBars.BarButtonItem barBtnCopy;
    }
}