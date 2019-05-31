namespace AdvancedScada.Studio.Editors
{
    partial class XDataBlockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XDataBlockForm));
            this.DxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DxErrorProvider1
            // 
            this.DxErrorProvider1.ContainerControl = this;
            // 
            // XDataBlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 190);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XDataBlockForm";
            this.Text = "XDataBlockForm";
            this.Load += new System.EventHandler(this.XDataBlockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider1;
    }
}