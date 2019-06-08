namespace AdvancedScada.ImagePicker
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.xtbImageGallery = new DevExpress.XtraTab.XtraTabControl();
            this.tbImageGallerySVG = new DevExpress.XtraTab.XtraTabPage();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cboxListForderSVG = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gcSVG = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ImageGallery = new DevExpress.XtraTab.XtraTabPage();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cboxListForder = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.gc = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient2 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.PoBtnXAML = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.xtbImageGallery)).BeginInit();
            this.xtbImageGallery.SuspendLayout();
            this.tbImageGallerySVG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxListForderSVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSVG)).BeginInit();
            this.gcSVG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.ImageGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxListForder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            this.gc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtbImageGallery
            // 
            this.xtbImageGallery.Appearance.BackColor = System.Drawing.Color.White;
            this.xtbImageGallery.Appearance.Options.UseBackColor = true;
            this.xtbImageGallery.Location = new System.Drawing.Point(1, 12);
            this.xtbImageGallery.Name = "xtbImageGallery";
            this.xtbImageGallery.SelectedTabPage = this.tbImageGallerySVG;
            this.xtbImageGallery.Size = new System.Drawing.Size(632, 407);
            this.xtbImageGallery.TabIndex = 4;
            this.xtbImageGallery.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbImageGallerySVG,
            this.ImageGallery});
            // 
            // tbImageGallerySVG
            // 
            this.tbImageGallerySVG.Controls.Add(this.textEdit2);
            this.tbImageGallerySVG.Controls.Add(this.splitContainerControl1);
            this.tbImageGallerySVG.Controls.Add(this.panelControl1);
            this.tbImageGallerySVG.Name = "tbImageGallerySVG";
            this.tbImageGallerySVG.Size = new System.Drawing.Size(626, 379);
            this.tbImageGallerySVG.Text = "ImageGallerySVG";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(474, 15);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit2.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.textEdit2.Properties.ContextImageOptions.AllowChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit2.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit2.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("textEdit2.Properties.ContextImageOptions.Image")));
            this.textEdit2.Size = new System.Drawing.Size(144, 20);
            this.textEdit2.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 48);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cboxListForderSVG);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcSVG);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(626, 295);
            this.splitContainerControl1.SplitterPosition = 200;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // cboxListForderSVG
            // 
            this.cboxListForderSVG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxListForderSVG.Location = new System.Drawing.Point(0, 0);
            this.cboxListForderSVG.Name = "cboxListForderSVG";
            this.cboxListForderSVG.Size = new System.Drawing.Size(200, 295);
            this.cboxListForderSVG.TabIndex = 0;
            this.cboxListForderSVG.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.cboxListForderSVG_ItemCheck);
            // 
            // gcSVG
            // 
            this.gcSVG.Controls.Add(this.galleryControlClient1);
            this.gcSVG.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gcSVG.Gallery.ItemDoubleClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.gcSVG_Gallery_ItemDoubleClick);
            this.gcSVG.Location = new System.Drawing.Point(0, 0);
            this.gcSVG.Name = "gcSVG";
            this.gcSVG.Size = new System.Drawing.Size(421, 295);
            this.gcSVG.TabIndex = 0;
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.gcSVG;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(400, 291);
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 344);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(626, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // ImageGallery
            // 
            this.ImageGallery.Appearance.PageClient.BackColor = System.Drawing.Color.White;
            this.ImageGallery.Appearance.PageClient.Options.UseBackColor = true;
            this.ImageGallery.Controls.Add(this.textEdit1);
            this.ImageGallery.Controls.Add(this.splitContainerControl2);
            this.ImageGallery.Controls.Add(this.panelControl4);
            this.ImageGallery.Name = "ImageGallery";
            this.ImageGallery.Size = new System.Drawing.Size(626, 379);
            this.ImageGallery.Text = "ImageGallery";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(474, 18);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit1.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.textEdit1.Properties.ContextImageOptions.AllowChangeAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit1.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit1.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("textEdit1.Properties.ContextImageOptions.Image")));
            this.textEdit1.Size = new System.Drawing.Size(144, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 53);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.cboxListForder);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.gc);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(626, 291);
            this.splitContainerControl2.SplitterPosition = 200;
            this.splitContainerControl2.TabIndex = 8;
            // 
            // cboxListForder
            // 
            this.cboxListForder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboxListForder.Location = new System.Drawing.Point(0, 0);
            this.cboxListForder.Name = "cboxListForder";
            this.cboxListForder.Size = new System.Drawing.Size(200, 291);
            this.cboxListForder.TabIndex = 0;
            this.cboxListForder.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.cboxListForder_ItemCheck);
            // 
            // gc
            // 
            this.gc.Controls.Add(this.galleryControlClient2);
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gc.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.gc_Gallery_ItemClick);
            this.gc.Gallery.ItemDoubleClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.gc_Gallery_ItemDoubleClick);
            this.gc.Gallery.ItemCheckedChanged += new DevExpress.XtraBars.Ribbon.GalleryItemEventHandler(this.gc_Gallery_ItemCheckedChanged);
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(421, 291);
            this.gc.TabIndex = 0;
            this.gc.Text = "galleryControl1";
            // 
            // galleryControlClient2
            // 
            this.galleryControlClient2.GalleryControl = this.gc;
            this.galleryControlClient2.Location = new System.Drawing.Point(0, 0);
            this.galleryControlClient2.Size = new System.Drawing.Size(0, 0);
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 344);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(626, 35);
            this.panelControl4.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(538, 436);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(450, 436);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 22);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PoBtnXAML
            // 
            this.PoBtnXAML.Caption = "ExPortXAML";
            this.PoBtnXAML.Id = 0;
            this.PoBtnXAML.Name = "PoBtnXAML";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.PoBtnXAML});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(632, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 470);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(632, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 470);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(632, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 470);
            // 
            // MainView
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 470);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.xtbImageGallery);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 502);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(642, 502);
            this.Name = "MainView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Picker";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtbImageGallery)).EndInit();
            this.xtbImageGallery.ResumeLayout(false);
            this.tbImageGallerySVG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxListForderSVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSVG)).EndInit();
            this.gcSVG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ImageGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxListForder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            this.gc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtbImageGallery;
        private DevExpress.XtraTab.XtraTabPage tbImageGallerySVG;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl cboxListForderSVG;
        private DevExpress.XtraBars.Ribbon.GalleryControl gcSVG;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabPage ImageGallery;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl cboxListForder;
        private DevExpress.XtraBars.Ribbon.GalleryControl gc;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraBars.BarButtonItem PoBtnXAML;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

