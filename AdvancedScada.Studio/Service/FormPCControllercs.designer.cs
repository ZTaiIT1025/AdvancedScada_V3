namespace AdvancedScada.Studio.Service
{
    partial class FormPCControllercs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPCControllercs));
            this.btnShutdown = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnSleep = new DevExpress.XtraEditors.SimpleButton();
            this.btnHtbernaion = new DevExpress.XtraEditors.SimpleButton();
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.btnLongoff = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnShutdown
            // 
            this.btnShutdown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShutdown.ImageOptions.Image")));
            this.btnShutdown.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnShutdown.Location = new System.Drawing.Point(2, 4);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(108, 86);
            this.btnShutdown.TabIndex = 0;
            this.btnShutdown.Text = "Shut down";
            this.btnShutdown.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnReset
            // 
            this.btnReset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageOptions.Image")));
            this.btnReset.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnReset.Location = new System.Drawing.Point(116, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 86);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSleep
            // 
            this.btnSleep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSleep.ImageOptions.Image")));
            this.btnSleep.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSleep.Location = new System.Drawing.Point(230, 4);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(108, 86);
            this.btnSleep.TabIndex = 2;
            this.btnSleep.Text = "Sleep";
            this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
            // 
            // btnHtbernaion
            // 
            this.btnHtbernaion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHtbernaion.ImageOptions.Image")));
            this.btnHtbernaion.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnHtbernaion.Location = new System.Drawing.Point(2, 96);
            this.btnHtbernaion.Name = "btnHtbernaion";
            this.btnHtbernaion.Size = new System.Drawing.Size(108, 86);
            this.btnHtbernaion.TabIndex = 3;
            this.btnHtbernaion.Text = "Htbernaion";
            this.btnHtbernaion.Click += new System.EventHandler(this.btnHtbernaion_Click);
            // 
            // btnLock
            // 
            this.btnLock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.ImageOptions.Image")));
            this.btnLock.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnLock.Location = new System.Drawing.Point(116, 96);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(108, 86);
            this.btnLock.TabIndex = 4;
            this.btnLock.Text = "Lock";
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnLongoff
            // 
            this.btnLongoff.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLongoff.ImageOptions.Image")));
            this.btnLongoff.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnLongoff.Location = new System.Drawing.Point(230, 97);
            this.btnLongoff.Name = "btnLongoff";
            this.btnLongoff.Size = new System.Drawing.Size(108, 86);
            this.btnLongoff.TabIndex = 5;
            this.btnLongoff.Text = "Logoff";
            this.btnLongoff.Click += new System.EventHandler(this.btnLongoff_Click);
            // 
            // FormPCControllercs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 195);
            this.Controls.Add(this.btnLongoff);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnHtbernaion);
            this.Controls.Add(this.btnSleep);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnShutdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(359, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(349, 227);
            this.Name = "FormPCControllercs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC Controllercs";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnShutdown;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnSleep;
        private DevExpress.XtraEditors.SimpleButton btnHtbernaion;
        private DevExpress.XtraEditors.SimpleButton btnLock;
        private DevExpress.XtraEditors.SimpleButton btnLongoff;
    }
}