namespace AdvancedScada.HMI.MainForm
{
    partial class FRM_Advanced
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
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxServer = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtDateBase = new System.Windows.Forms.TextBox();
            this.Button7 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button4 = new System.Windows.Forms.Button();
            this.TabPage7 = new System.Windows.Forms.TabPage();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_BatchFinal = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Batchs_Details = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.Button8 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Button5 = new System.Windows.Forms.Button();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPorts = new System.Windows.Forms.ToolStripButton();
            this.ts_Del_DataBase = new System.Windows.Forms.ToolStripButton();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsSeve = new System.Windows.Forms.ToolStripButton();
            this.ts_Res = new System.Windows.Forms.ToolStripButton();
            this.ts_con = new System.Windows.Forms.ToolStripButton();
            this.ts_Del_DataBase2 = new System.Windows.Forms.ToolStripButton();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.Button6 = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabPage7.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.ToolStrip2.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.groupBox1);
            this.TabPage5.Location = new System.Drawing.Point(4, 22);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(807, 299);
            this.TabPage5.TabIndex = 2;
            this.TabPage5.Text = "TabPage5";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxServer);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.txtDateBase);
            this.groupBox1.Controls.Add(this.Button7);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(236, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(320, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الاتصال";
            // 
            // cboxServer
            // 
            this.cboxServer.FormattingEnabled = true;
            this.cboxServer.Location = new System.Drawing.Point(38, 51);
            this.cboxServer.Name = "cboxServer";
            this.cboxServer.Size = new System.Drawing.Size(176, 21);
            this.cboxServer.TabIndex = 5;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(234, 91);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "قاعدة البيانات";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(238, 51);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(73, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "اسم السرفر";
            // 
            // txtDateBase
            // 
            this.txtDateBase.Location = new System.Drawing.Point(38, 88);
            this.txtDateBase.Name = "txtDateBase";
            this.txtDateBase.Size = new System.Drawing.Size(176, 20);
            this.txtDateBase.TabIndex = 2;
            // 
            // Button7
            // 
            this.Button7.Location = new System.Drawing.Point(19, 126);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(110, 23);
            this.Button7.TabIndex = 0;
            this.Button7.Text = "حفظ الاعدادات";
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(524, 99);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(115, 19);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "مسار النسخة ";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(159, 121);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ReadOnly = true;
            this.TextBox2.Size = new System.Drawing.Size(489, 28);
            this.TextBox2.TabIndex = 13;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(465, 155);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(183, 23);
            this.Button4.TabIndex = 12;
            this.Button4.Text = "اعادة النسخة";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // TabPage7
            // 
            this.TabPage7.Controls.Add(this.GroupBox4);
            this.TabPage7.Controls.Add(this.GroupBox3);
            this.TabPage7.Location = new System.Drawing.Point(4, 22);
            this.TabPage7.Name = "TabPage7";
            this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage7.Size = new System.Drawing.Size(807, 299);
            this.TabPage7.TabIndex = 3;
            this.TabPage7.Text = "TabPage7";
            this.TabPage7.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.btn_BatchFinal);
            this.GroupBox4.Location = new System.Drawing.Point(101, 17);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(332, 151);
            this.GroupBox4.TabIndex = 3;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "حذف قاعدة بيانات التقرير";
            // 
            // btn_BatchFinal
            // 
            this.btn_BatchFinal.Location = new System.Drawing.Point(111, 58);
            this.btn_BatchFinal.Name = "btn_BatchFinal";
            this.btn_BatchFinal.Size = new System.Drawing.Size(151, 25);
            this.btn_BatchFinal.TabIndex = 0;
            this.btn_BatchFinal.Text = "حذف قاعدة بيانات التقرير";
            this.btn_BatchFinal.UseVisualStyleBackColor = true;
            this.btn_BatchFinal.Click += new System.EventHandler(this.btn_BatchFinal_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.btn_Batchs_Details);
            this.GroupBox3.Location = new System.Drawing.Point(460, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(332, 151);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "حذف قاعدة بيانات الخلطات";
            // 
            // btn_Batchs_Details
            // 
            this.btn_Batchs_Details.Location = new System.Drawing.Point(111, 58);
            this.btn_Batchs_Details.Name = "btn_Batchs_Details";
            this.btn_Batchs_Details.Size = new System.Drawing.Size(151, 25);
            this.btn_Batchs_Details.TabIndex = 0;
            this.btn_Batchs_Details.Text = "حذف قاعدة بيانات الخلطات";
            this.btn_Batchs_Details.UseVisualStyleBackColor = true;
            this.btn_Batchs_Details.Click += new System.EventHandler(this.btn_Batchs_Details_Click);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(821, 331);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "TabPage2";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.txt_IP);
            this.GroupBox2.Controls.Add(this.txt_Port);
            this.GroupBox2.Controls.Add(this.Button8);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Location = new System.Drawing.Point(81, 43);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GroupBox2.Size = new System.Drawing.Size(402, 157);
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "GroupBox2";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(111, 26);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(206, 20);
            this.txt_IP.TabIndex = 11;
            this.txt_IP.Text = "183.109.197.100";
            this.txt_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(100, 63);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(217, 20);
            this.txt_Port.TabIndex = 10;
            this.txt_Port.Text = "2004";
            this.txt_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Button8
            // 
            this.Button8.Location = new System.Drawing.Point(260, 115);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(136, 36);
            this.Button8.TabIndex = 9;
            this.Button8.Text = "Seva";
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label5.Location = new System.Drawing.Point(18, 26);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 19);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "IPAddress";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label6.Location = new System.Drawing.Point(18, 67);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(41, 19);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Port";
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(384, 155);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(75, 23);
            this.Button5.TabIndex = 11;
            this.Button5.Text = "الغاء";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPorts,
            this.ts_Del_DataBase});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(829, 25);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tsPorts
            // 
            this.tsPorts.Image = global::AdvancedScada.HMI.Properties.Resources.Math_Trig_16x16;
            this.tsPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPorts.Name = "tsPorts";
            this.tsPorts.Size = new System.Drawing.Size(99, 22);
            this.tsPorts.Text = "اعدادات الاتصال";
            this.tsPorts.Click += new System.EventHandler(this.tsPorts_Click);
            // 
            // ts_Del_DataBase
            // 
            this.ts_Del_DataBase.Image = global::AdvancedScada.HMI.Properties.Resources.DeleteDataSource2_32x32;
            this.ts_Del_DataBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Del_DataBase.Name = "ts_Del_DataBase";
            this.ts_Del_DataBase.Size = new System.Drawing.Size(140, 22);
            this.ts_Del_DataBase.Text = "طرق اخرة لقاعدة البيانات";
            this.ts_Del_DataBase.Click += new System.EventHandler(this.ts_Del_DataBase_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(0, 28);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(829, 357);
            this.TabControl1.TabIndex = 3;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ToolStrip2);
            this.TabPage1.Controls.Add(this.TabControl2);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(821, 331);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "TabPage1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSeve,
            this.ts_Res,
            this.ts_con,
            this.ts_Del_DataBase2});
            this.ToolStrip2.Location = new System.Drawing.Point(3, 3);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(815, 25);
            this.ToolStrip2.TabIndex = 0;
            this.ToolStrip2.Text = "ToolStrip2";
            // 
            // tsSeve
            // 
            this.tsSeve.Image = global::AdvancedScada.HMI.Properties.Resources.ExportModelDifferences_16x16;
            this.tsSeve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSeve.Name = "tsSeve";
            this.tsSeve.Size = new System.Drawing.Size(46, 22);
            this.tsSeve.Text = "حفظ";
            this.tsSeve.Click += new System.EventHandler(this.tsSeve_Click);
            // 
            // ts_Res
            // 
            this.ts_Res.Image = global::AdvancedScada.HMI.Properties.Resources.ResetModelDifferences_16x16;
            this.ts_Res.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Res.Name = "ts_Res";
            this.ts_Res.Size = new System.Drawing.Size(67, 22);
            this.ts_Res.Text = "استرجاع";
            this.ts_Res.Click += new System.EventHandler(this.ts_Res_Click);
            // 
            // ts_con
            // 
            this.ts_con.Image = global::AdvancedScada.HMI.Properties.Resources._2063;
            this.ts_con.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_con.Name = "ts_con";
            this.ts_con.Size = new System.Drawing.Size(99, 22);
            this.ts_con.Text = "اعدادات الاتصال";
            this.ts_con.Click += new System.EventHandler(this.ts_con_Click);
            // 
            // ts_Del_DataBase2
            // 
            this.ts_Del_DataBase2.Image = global::AdvancedScada.HMI.Properties.Resources.AddNewDataSource_16x16;
            this.ts_Del_DataBase2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Del_DataBase2.Name = "ts_Del_DataBase2";
            this.ts_Del_DataBase2.Size = new System.Drawing.Size(88, 22);
            this.ts_Del_DataBase2.Text = "حذف البيانات ";
            this.ts_Del_DataBase2.Click += new System.EventHandler(this.ts_Del_DataBase2_Click);
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Controls.Add(this.TabPage4);
            this.TabControl2.Controls.Add(this.TabPage5);
            this.TabControl2.Controls.Add(this.TabPage7);
            this.TabControl2.Location = new System.Drawing.Point(3, 31);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(815, 325);
            this.TabControl2.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.label1);
            this.TabPage3.Controls.Add(this.textBox1);
            this.TabPage3.Controls.Add(this.button3);
            this.TabPage3.Controls.Add(this.button2);
            this.TabPage3.Controls.Add(this.button1);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(807, 299);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(591, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "مسار النسخة ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 123);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(489, 28);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "انشاء النسخة";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(419, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "الغاء";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(111, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "اختيار";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.Label2);
            this.TabPage4.Controls.Add(this.TextBox2);
            this.TabPage4.Controls.Add(this.Button4);
            this.TabPage4.Controls.Add(this.Button5);
            this.TabPage4.Controls.Add(this.Button6);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(807, 299);
            this.TabPage4.TabIndex = 1;
            this.TabPage4.Text = "TabPage4";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // Button6
            // 
            this.Button6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Button6.Location = new System.Drawing.Point(33, 121);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(111, 31);
            this.Button6.TabIndex = 10;
            this.Button6.Text = "اختيار";
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "*.bak";
            // 
            // FRM_Advanced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 405);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.TabControl1);
            this.Name = "FRM_Advanced";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اعدادات البرنامج";
            this.Load += new System.EventHandler(this.FRM_Advanced_Load);
            this.TabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabPage7.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.TabPage3.PerformLayout();
            this.TabPage4.ResumeLayout(false);
            this.TabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabPage TabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtDateBase;
        private System.Windows.Forms.Button Button7;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.TabPage TabPage7;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btn_BatchFinal;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btn_Batchs_Details;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txt_IP;
        internal System.Windows.Forms.TextBox txt_Port;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tsPorts;
        internal System.Windows.Forms.ToolStripButton ts_Del_DataBase;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.ToolStrip ToolStrip2;
        internal System.Windows.Forms.ToolStripButton tsSeve;
        internal System.Windows.Forms.ToolStripButton ts_Res;
        internal System.Windows.Forms.ToolStripButton ts_con;
        internal System.Windows.Forms.ToolStripButton ts_Del_DataBase2;
        internal System.Windows.Forms.TabControl TabControl2;
        internal System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TabPage TabPage4;
        private System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.ComboBox cboxServer;
    }
}