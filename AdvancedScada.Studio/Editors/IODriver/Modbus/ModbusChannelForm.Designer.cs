namespace AdvancedScada.XModbus.Core.UserEditors
{
    partial class XUserChannelForm
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageChannel = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxConnType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChannelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageEthernet = new DevExpress.XtraTab.XtraTabPage();
            this.gpDIEChannel = new System.Windows.Forms.GroupBox();
            this.txtIPAddress = new AdvancedScada.Utils.Net.IPAddressText();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageSerialPort = new DevExpress.XtraTab.XtraTabPage();
            this.cboxModeSP = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxHandshake = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboxParity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboxStopBits = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxDataBits = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxBaudRate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboxPort = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnBlack = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPageChannel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageEthernet.SuspendLayout();
            this.gpDIEChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.tabPageSerialPort.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.xtraTabControl1.SelectedTabPage = this.tabPageChannel;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(453, 274);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageChannel,
            this.tabPageEthernet,
            this.tabPageSerialPort});
            // 
            // tabPageChannel
            // 
            this.tabPageChannel.Controls.Add(this.groupBox1);
            this.tabPageChannel.Name = "tabPageChannel";
            this.tabPageChannel.Size = new System.Drawing.Size(448, 269);
            this.tabPageChannel.Text = "Channel";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboxConnType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChannelName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(425, 230);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // cboxConnType
            // 
            this.cboxConnType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxConnType.ForeColor = System.Drawing.Color.Black;
            this.cboxConnType.FormattingEnabled = true;
            this.cboxConnType.Items.AddRange(new object[] {
            "None",
            "Ethernet",
            "SerialPort"});
            this.cboxConnType.Location = new System.Drawing.Point(109, 45);
            this.cboxConnType.Name = "cboxConnType";
            this.cboxConnType.Size = new System.Drawing.Size(168, 21);
            this.cboxConnType.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(15, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Connection Type:";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Location = new System.Drawing.Point(109, 74);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(309, 139);
            this.txtDesc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description:";
            // 
            // txtChannelName
            // 
            this.txtChannelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannelName.ForeColor = System.Drawing.Color.Black;
            this.txtChannelName.Location = new System.Drawing.Point(109, 19);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(200, 20);
            this.txtChannelName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel Name:";
            // 
            // tabPageEthernet
            // 
            this.tabPageEthernet.Controls.Add(this.gpDIEChannel);
            this.tabPageEthernet.Name = "tabPageEthernet";
            this.tabPageEthernet.Size = new System.Drawing.Size(447, 268);
            this.tabPageEthernet.Text = "Ethernet";
            // 
            // gpDIEChannel
            // 
            this.gpDIEChannel.Controls.Add(this.txtIPAddress);
            this.gpDIEChannel.Controls.Add(this.txtPort);
            this.gpDIEChannel.Controls.Add(this.label4);
            this.gpDIEChannel.Controls.Add(this.label5);
            this.gpDIEChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDIEChannel.Location = new System.Drawing.Point(5, 2);
            this.gpDIEChannel.Margin = new System.Windows.Forms.Padding(4);
            this.gpDIEChannel.Name = "gpDIEChannel";
            this.gpDIEChannel.Padding = new System.Windows.Forms.Padding(4);
            this.gpDIEChannel.Size = new System.Drawing.Size(420, 203);
            this.gpDIEChannel.TabIndex = 6;
            this.gpDIEChannel.TabStop = false;
            this.gpDIEChannel.Text = "General";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(81, 19);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(162, 20);
            this.txtIPAddress.TabIndex = 5;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.ForeColor = System.Drawing.Color.Black;
            this.txtPort.Location = new System.Drawing.Point(93, 53);
            this.txtPort.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(87, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Value = new decimal(new int[] {
            502,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP Address:";
            // 
            // tabPageSerialPort
            // 
            this.tabPageSerialPort.Controls.Add(this.cboxModeSP);
            this.tabPageSerialPort.Controls.Add(this.label1);
            this.tabPageSerialPort.Controls.Add(this.groupBox2);
            this.tabPageSerialPort.Name = "tabPageSerialPort";
            this.tabPageSerialPort.Size = new System.Drawing.Size(447, 268);
            this.tabPageSerialPort.Text = "SerialPort";
            // 
            // cboxModeSP
            // 
            this.cboxModeSP.FormattingEnabled = true;
            this.cboxModeSP.Items.AddRange(new object[] {
            "RTU",
            "ASCII"});
            this.cboxModeSP.Location = new System.Drawing.Point(44, 14);
            this.cboxModeSP.Name = "cboxModeSP";
            this.cboxModeSP.Size = new System.Drawing.Size(86, 21);
            this.cboxModeSP.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mode:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxHandshake);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboxParity);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboxStopBits);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboxDataBits);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboxBaudRate);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cboxPort);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(142, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 203);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SerialPort";
            // 
            // cboxHandshake
            // 
            this.cboxHandshake.FormattingEnabled = true;
            this.cboxHandshake.Location = new System.Drawing.Point(69, 171);
            this.cboxHandshake.Name = "cboxHandshake";
            this.cboxHandshake.Size = new System.Drawing.Size(132, 21);
            this.cboxHandshake.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Handshake";
            // 
            // cboxParity
            // 
            this.cboxParity.FormattingEnabled = true;
            this.cboxParity.Location = new System.Drawing.Point(69, 141);
            this.cboxParity.Name = "cboxParity";
            this.cboxParity.Size = new System.Drawing.Size(131, 21);
            this.cboxParity.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Parity";
            // 
            // cboxStopBits
            // 
            this.cboxStopBits.FormattingEnabled = true;
            this.cboxStopBits.Location = new System.Drawing.Point(69, 111);
            this.cboxStopBits.Name = "cboxStopBits";
            this.cboxStopBits.Size = new System.Drawing.Size(131, 21);
            this.cboxStopBits.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Stop Bits";
            // 
            // cboxDataBits
            // 
            this.cboxDataBits.FormattingEnabled = true;
            this.cboxDataBits.Location = new System.Drawing.Point(69, 81);
            this.cboxDataBits.Name = "cboxDataBits";
            this.cboxDataBits.Size = new System.Drawing.Size(131, 21);
            this.cboxDataBits.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Data Bits";
            // 
            // cboxBaudRate
            // 
            this.cboxBaudRate.FormattingEnabled = true;
            this.cboxBaudRate.Location = new System.Drawing.Point(69, 51);
            this.cboxBaudRate.Name = "cboxBaudRate";
            this.cboxBaudRate.Size = new System.Drawing.Size(131, 21);
            this.cboxBaudRate.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Baud rate";
            // 
            // cboxPort
            // 
            this.cboxPort.FormattingEnabled = true;
            this.cboxPort.Location = new System.Drawing.Point(69, 21);
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.Size = new System.Drawing.Size(131, 21);
            this.cboxPort.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Port";
            // 
            // btnBlack
            // 
            this.btnBlack.Location = new System.Drawing.Point(120, 280);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(103, 22);
            this.btnBlack.TabIndex = 9;
            this.btnBlack.Text = "< Back";
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(229, 280);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 22);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(334, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // XUserChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Name = "XUserChannelForm";
            this.Size = new System.Drawing.Size(453, 311);
            this.Load += new System.EventHandler(this.XUserChannelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPageChannel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageEthernet.ResumeLayout(false);
            this.gpDIEChannel.ResumeLayout(false);
            this.gpDIEChannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.tabPageSerialPort.ResumeLayout(false);
            this.tabPageSerialPort.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPageChannel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxConnType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChannelName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraTab.XtraTabPage tabPageEthernet;
        private System.Windows.Forms.GroupBox gpDIEChannel;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraTab.XtraTabPage tabPageSerialPort;
        private System.Windows.Forms.ComboBox cboxModeSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboxHandshake;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboxParity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboxStopBits;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxDataBits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxBaudRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboxPort;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.SimpleButton btnBlack;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private AdvancedScada.Utils.Net.IPAddressText txtIPAddress;
    }
}
