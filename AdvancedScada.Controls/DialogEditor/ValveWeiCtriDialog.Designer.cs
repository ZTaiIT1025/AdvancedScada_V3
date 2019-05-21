namespace AdvancedScada.Controls.DialogEditor
{
    partial class ValveWeiCtriDialog
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.BtnMANUAL = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAuto = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.BtnRESET = new DevExpress.XtraEditors.SimpleButton();
            this.BtnInterLoke = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCLOSE = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOpen = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(237, 76);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.BtnMANUAL);
            this.groupControl2.Controls.Add(this.BtnAuto);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 76);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(237, 72);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // BtnMANUAL
            // 
            this.BtnMANUAL.Location = new System.Drawing.Point(118, 23);
            this.BtnMANUAL.Name = "BtnMANUAL";
            this.BtnMANUAL.Size = new System.Drawing.Size(110, 42);
            this.BtnMANUAL.TabIndex = 1;
            this.BtnMANUAL.Text = "MANUAL";
            this.BtnMANUAL.Click += new System.EventHandler(this.BtnMANUAL_Click);
            // 
            // BtnAuto
            // 
            this.BtnAuto.Location = new System.Drawing.Point(5, 23);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(110, 42);
            this.BtnAuto.TabIndex = 0;
            this.BtnAuto.Text = "Auto";
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.BtnRESET);
            this.groupControl3.Controls.Add(this.BtnInterLoke);
            this.groupControl3.Controls.Add(this.BtnCLOSE);
            this.groupControl3.Controls.Add(this.BtnOpen);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 148);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(237, 120);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "groupControl3";
            // 
            // BtnRESET
            // 
            this.BtnRESET.Location = new System.Drawing.Point(118, 71);
            this.BtnRESET.Name = "BtnRESET";
            this.BtnRESET.Size = new System.Drawing.Size(110, 42);
            this.BtnRESET.TabIndex = 4;
            this.BtnRESET.Text = "RESET";
            this.BtnRESET.Click += new System.EventHandler(this.BtnRESET_Click);
            // 
            // BtnInterLoke
            // 
            this.BtnInterLoke.Location = new System.Drawing.Point(5, 71);
            this.BtnInterLoke.Name = "BtnInterLoke";
            this.BtnInterLoke.Size = new System.Drawing.Size(110, 42);
            this.BtnInterLoke.TabIndex = 3;
            this.BtnInterLoke.Text = "ENTERLOKE";
            this.BtnInterLoke.Click += new System.EventHandler(this.BtnInterLoke_Click);
            // 
            // BtnCLOSE
            // 
            this.BtnCLOSE.Location = new System.Drawing.Point(118, 23);
            this.BtnCLOSE.Name = "BtnCLOSE";
            this.BtnCLOSE.Size = new System.Drawing.Size(110, 42);
            this.BtnCLOSE.TabIndex = 2;
            this.BtnCLOSE.Text = "CLOSE";
            this.BtnCLOSE.Click += new System.EventHandler(this.BtnCLOSE_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(5, 23);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(110, 42);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "OPEN";
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // ValveWeiCtriDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 268);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ValveWeiCtriDialog";
            this.Text = "ValveWeiCtriDialog";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton BtnMANUAL;
        private DevExpress.XtraEditors.SimpleButton BtnAuto;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton BtnRESET;
        private DevExpress.XtraEditors.SimpleButton BtnInterLoke;
        private DevExpress.XtraEditors.SimpleButton BtnCLOSE;
        private DevExpress.XtraEditors.SimpleButton BtnOpen;
    }
}