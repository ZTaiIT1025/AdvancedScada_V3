namespace AdvancedScada.XPanasonic.Core.UserEditors
{
    partial class XUserDeviceForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtDesp = new System.Windows.Forms.TextBox();
            this.txtSlaveId = new DevExpress.XtraEditors.SpinEdit();
            this.txtDeviceName = new DevExpress.XtraEditors.TextEdit();
            this.txtDeviceId = new DevExpress.XtraEditors.TextEdit();
            this.txtChannelID = new DevExpress.XtraEditors.TextEdit();
            this.txtChannelName = new DevExpress.XtraEditors.TextEdit();
            this.LayoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EmptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.SimpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.DxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).BeginInit();
            this.LayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlaveId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl1
            // 
            this.LayoutControl1.Controls.Add(this.btnCancel);
            this.LayoutControl1.Controls.Add(this.btnOK);
            this.LayoutControl1.Controls.Add(this.txtDesp);
            this.LayoutControl1.Controls.Add(this.txtSlaveId);
            this.LayoutControl1.Controls.Add(this.txtDeviceName);
            this.LayoutControl1.Controls.Add(this.txtDeviceId);
            this.LayoutControl1.Controls.Add(this.txtChannelID);
            this.LayoutControl1.Controls.Add(this.txtChannelName);
            this.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.LayoutControl1.Name = "LayoutControl1";
            this.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(686, 203, 360, 442);
            this.LayoutControl1.Root = this.LayoutControlGroup1;
            this.LayoutControl1.Size = new System.Drawing.Size(480, 231);
            this.LayoutControl1.TabIndex = 1;
            this.LayoutControl1.Text = "LayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(351, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 22);
            this.btnCancel.StyleController = this.LayoutControl1;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 22);
            this.btnOK.StyleController = this.LayoutControl1;
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDesp
            // 
            this.txtDesp.Location = new System.Drawing.Point(8, 98);
            this.txtDesp.Multiline = true;
            this.txtDesp.Name = "txtDesp";
            this.txtDesp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesp.Size = new System.Drawing.Size(464, 97);
            this.txtDesp.TabIndex = 8;
            // 
            // txtSlaveId
            // 
            this.txtSlaveId.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSlaveId.Location = new System.Drawing.Point(83, 59);
            this.txtSlaveId.Name = "txtSlaveId";
            this.txtSlaveId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSlaveId.Size = new System.Drawing.Size(389, 20);
            this.txtSlaveId.StyleController = this.LayoutControl1;
            this.txtSlaveId.TabIndex = 10;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(278, 34);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(194, 20);
            this.txtDeviceName.StyleController = this.LayoutControl1;
            this.txtDeviceName.TabIndex = 7;
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(83, 34);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(118, 20);
            this.txtDeviceId.StyleController = this.LayoutControl1;
            this.txtDeviceId.TabIndex = 6;
            // 
            // txtChannelID
            // 
            this.txtChannelID.Location = new System.Drawing.Point(83, 10);
            this.txtChannelID.Name = "txtChannelID";
            this.txtChannelID.Size = new System.Drawing.Size(118, 20);
            this.txtChannelID.StyleController = this.LayoutControl1;
            this.txtChannelID.TabIndex = 5;
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(278, 10);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(194, 20);
            this.txtChannelName.StyleController = this.LayoutControl1;
            this.txtChannelName.TabIndex = 4;
            // 
            // LayoutControlGroup1
            // 
            this.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1";
            this.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.LayoutControlGroup1.GroupBordersVisible = false;
            this.LayoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutControlItem1,
            this.LayoutControlItem2,
            this.LayoutControlItem3,
            this.LayoutControlItem4,
            this.LayoutControlItem7,
            this.LayoutControlItem10,
            this.LayoutControlItem9,
            this.LayoutControlItem11,
            this.EmptySpaceItem1,
            this.SimpleSeparator1});
            this.LayoutControlGroup1.Name = "Root";
            this.LayoutControlGroup1.Size = new System.Drawing.Size(480, 231);
            this.LayoutControlGroup1.TextVisible = false;
            // 
            // LayoutControlItem1
            // 
            this.LayoutControlItem1.Control = this.txtChannelName;
            this.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1";
            this.LayoutControlItem1.Location = new System.Drawing.Point(195, 0);
            this.LayoutControlItem1.Name = "LayoutControlItem1";
            this.LayoutControlItem1.Size = new System.Drawing.Size(271, 24);
            this.LayoutControlItem1.Text = "Channel Name:";
            this.LayoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem2
            // 
            this.LayoutControlItem2.Control = this.txtChannelID;
            this.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2";
            this.LayoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.LayoutControlItem2.Name = "LayoutControlItem2";
            this.LayoutControlItem2.Size = new System.Drawing.Size(195, 24);
            this.LayoutControlItem2.Text = "Channel Id:";
            this.LayoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem3
            // 
            this.LayoutControlItem3.Control = this.txtDeviceId;
            this.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3";
            this.LayoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.LayoutControlItem3.Name = "LayoutControlItem3";
            this.LayoutControlItem3.Size = new System.Drawing.Size(195, 24);
            this.LayoutControlItem3.Text = "Device Id:";
            this.LayoutControlItem3.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem4
            // 
            this.LayoutControlItem4.Control = this.txtDeviceName;
            this.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4";
            this.LayoutControlItem4.Location = new System.Drawing.Point(195, 24);
            this.LayoutControlItem4.Name = "LayoutControlItem4";
            this.LayoutControlItem4.Size = new System.Drawing.Size(271, 24);
            this.LayoutControlItem4.Text = "Device Name:";
            this.LayoutControlItem4.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem7
            // 
            this.LayoutControlItem7.Control = this.txtSlaveId;
            this.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7";
            this.LayoutControlItem7.Location = new System.Drawing.Point(0, 49);
            this.LayoutControlItem7.Name = "LayoutControlItem7";
            this.LayoutControlItem7.Size = new System.Drawing.Size(466, 24);
            this.LayoutControlItem7.Text = "SlaveId:";
            this.LayoutControlItem7.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem10
            // 
            this.LayoutControlItem10.Control = this.txtDesp;
            this.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10";
            this.LayoutControlItem10.Location = new System.Drawing.Point(0, 73);
            this.LayoutControlItem10.Name = "LayoutControlItem10";
            this.LayoutControlItem10.Size = new System.Drawing.Size(466, 116);
            this.LayoutControlItem10.Text = "Description:";
            this.LayoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.LayoutControlItem10.TextSize = new System.Drawing.Size(73, 13);
            // 
            // LayoutControlItem9
            // 
            this.LayoutControlItem9.Control = this.btnOK;
            this.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9";
            this.LayoutControlItem9.Location = new System.Drawing.Point(223, 189);
            this.LayoutControlItem9.Name = "LayoutControlItem9";
            this.LayoutControlItem9.Size = new System.Drawing.Size(120, 26);
            this.LayoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem9.TextVisible = false;
            // 
            // LayoutControlItem11
            // 
            this.LayoutControlItem11.Control = this.btnCancel;
            this.LayoutControlItem11.CustomizationFormText = "LayoutControlItem11";
            this.LayoutControlItem11.Location = new System.Drawing.Point(343, 189);
            this.LayoutControlItem11.Name = "LayoutControlItem11";
            this.LayoutControlItem11.Size = new System.Drawing.Size(123, 26);
            this.LayoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.LayoutControlItem11.TextVisible = false;
            // 
            // EmptySpaceItem1
            // 
            this.EmptySpaceItem1.AllowHotTrack = false;
            this.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1";
            this.EmptySpaceItem1.Location = new System.Drawing.Point(0, 189);
            this.EmptySpaceItem1.Name = "EmptySpaceItem1";
            this.EmptySpaceItem1.Size = new System.Drawing.Size(223, 26);
            this.EmptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // SimpleSeparator1
            // 
            this.SimpleSeparator1.AllowHotTrack = false;
            this.SimpleSeparator1.CustomizationFormText = "SimpleSeparator1";
            this.SimpleSeparator1.Location = new System.Drawing.Point(0, 48);
            this.SimpleSeparator1.Name = "SimpleSeparator1";
            this.SimpleSeparator1.Size = new System.Drawing.Size(466, 1);
            // 
            // DxErrorProvider1
            // 
            this.DxErrorProvider1.ContainerControl = this;
            // 
            // XUserDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LayoutControl1);
            this.Name = "XUserDeviceForm";
            this.Size = new System.Drawing.Size(480, 231);
            this.Load += new System.EventHandler(this.XUserDeviceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl1)).EndInit();
            this.LayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSlaveId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraLayout.LayoutControl LayoutControl1;
        internal DevExpress.XtraEditors.SimpleButton btnCancel;
        internal DevExpress.XtraEditors.SimpleButton btnOK;
        internal System.Windows.Forms.TextBox txtDesp;
        internal DevExpress.XtraEditors.SpinEdit txtSlaveId;
        internal DevExpress.XtraEditors.TextEdit txtDeviceName;
        internal DevExpress.XtraEditors.TextEdit txtDeviceId;
        internal DevExpress.XtraEditors.TextEdit txtChannelID;
        internal DevExpress.XtraEditors.TextEdit txtChannelName;
        internal DevExpress.XtraLayout.LayoutControlGroup LayoutControlGroup1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem1;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem2;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem3;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem4;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem7;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem10;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem9;
        internal DevExpress.XtraLayout.LayoutControlItem LayoutControlItem11;
        internal DevExpress.XtraLayout.EmptySpaceItem EmptySpaceItem1;
        internal DevExpress.XtraLayout.SimpleSeparator SimpleSeparator1;
        internal DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider DxErrorProvider1;
    }
}
