//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace AdvancedScada.Studio.Monitor
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class WriteTagForm : DevExpress.XtraEditors.XtraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteTagForm));
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboxAuto = new DevExpress.XtraEditors.CheckEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.NumValue = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboxAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.cboxAuto);
            this.LayoutControl1.Controls.Add(this.btnSend);
            this.LayoutControl1.Controls.Add(this.btnCancel);
            this.LayoutControl1.Controls.Add(this.NumValue);
            this.LayoutControl1.Controls.Add(this.txtAddress);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(789, 244, 250, 350);
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(450, 97);
            this.LayoutControl1.TabIndex = 0;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // cboxAuto
            // 
            this.cboxAuto.Location = new System.Drawing.Point(12, 60);
            this.cboxAuto.Name = "cboxAuto";
            this.cboxAuto.Properties.Caption = "Auto increment";
            this.cboxAuto.Size = new System.Drawing.Size(101, 19);
            this.cboxAuto.StyleController = this.LayoutControl1;
            this.cboxAuto.TabIndex = 10;
             // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(284, 60);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 25);
            this.btnSend.StyleController = this.LayoutControl1;
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.StyleController = this.LayoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NumValue
            // 
            this.NumValue.EditValue = "";
            this.NumValue.Location = new System.Drawing.Point(58, 36);
            this.NumValue.Name = "NumValue";
            this.NumValue.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.NumValue.Size = new System.Drawing.Size(380, 20);
            this.NumValue.StyleController = this.LayoutControl1;
            this.NumValue.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(58, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAddress.Size = new System.Drawing.Size(380, 20);
            this.txtAddress.StyleController = this.LayoutControl1;
            this.txtAddress.TabIndex = 5;
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1";
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem2,
            this.LayoutControlItem4,
            this.LayoutControlItem1,
            this.LayoutControlItem3,
            this.EmptySpaceItem1,
            this.layoutControlItem5});
            this.LayoutControlGroup1.Name = "LayoutControlGroup1";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(450, 97);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.txtAddress;
            this.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2";
            this.LayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(430, 24);
            this.LayoutControlItem2.Text = "Address:";
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(43, 13);
            // 
            // LayoutControlItem4
            // 
            this.LayoutControlItem4.Control = this.NumValue;
            this.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4";
            this.LayoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItem4.Name = "LayoutControlItem4";
            this.LayoutControlItem4.Size = new System.Drawing.Size(430, 24);
            this.LayoutControlItem4.Text = "Value:";
            this.LayoutControlItem4.TextSize = new System.Drawing.Size(43, 13);
            // 
            // LayoutControlItem1
            // 
            this.LayoutControlItem1.Control = this.btnCancel;
            this.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1";
            this.LayoutControlItem1.Location = new System.Drawing.Point(346, 48);
            this.LayoutControlItem1.MinSize = new System.Drawing.Size(47, 26);
            this.LayoutControlItem1.Name = "LayoutControlItem1";
            this.LayoutControlItem1.Size = new System.Drawing.Size(84, 29);
            this.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.LayoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem1.TextVisible = false;
            // 
            // LayoutControlItem3
            // 
            this.LayoutControlItem3.Control = this.btnSend;
            this.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3";
            this.LayoutControlItem3.Location = new System.Drawing.Point(272, 48);
            this.LayoutControlItem3.MinSize = new System.Drawing.Size(39, 26);
            this.LayoutControlItem3.Name = "LayoutControlItem3";
            this.LayoutControlItem3.Size = new System.Drawing.Size(74, 29);
            this.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.LayoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem3.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            this.EmptySpaceItem1.AllowHotTrack = false;
            this.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1";
            this.EmptySpaceItem1.Location = new System.Drawing.Point(105, 48);
            this.EmptySpaceItem1.MaxSize = new System.Drawing.Size(167, 28);
            this.EmptySpaceItem1.MinSize = new System.Drawing.Size(167, 28);
            this.EmptySpaceItem1.Name = "EmptySpaceItem1";
            this.EmptySpaceItem1.Size = new System.Drawing.Size(167, 29);
            this.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.EmptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cboxAuto;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(105, 29);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // WriteTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 97);
            this.Controls.Add(this.LayoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WriteTag";
             this.Load += new System.EventHandler(this.WriteTagForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboxAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

		}
		internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
		internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
		internal DevExpress.XtraEditors.SimpleButton btnSend;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
		internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
		internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        private DevExpress.XtraEditors.ComboBoxEdit txtAddress;
        public DevExpress.XtraEditors.TextEdit NumValue;
        private DevExpress.XtraEditors.CheckEdit cboxAuto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

        public IContainer Components
        {
            get
            {
                return components;
            }

            set
            {
                components = value;
            }
        }
    }

}