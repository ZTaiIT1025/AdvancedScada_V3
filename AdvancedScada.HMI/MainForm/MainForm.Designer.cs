using AdvancedScada.Controls.Controls;
using AdvancedScada.Controls.DigitalDisplay;
using AdvancedScada.Controls.Enum;
using AdvancedScada.Controls.LED;
using AdvancedScada.Controls.Motor;
using AdvancedScada.Controls.SevenSegment;

namespace AdvancedScada.HMI.MainForm
{
    partial class MainForm
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::AdvancedScada.HMI.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Panel3 = new System.Windows.Forms.Panel();
            this.hmiLabel54 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel20 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel19 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel18 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel17 = new AdvancedScada.Controls.Display.HMILabel();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_datar = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.txt_sdata = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.lbl_DeyOfWeek = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label52 = new System.Windows.Forms.Label();
            this.Label53 = new System.Windows.Forms.Label();
            this.Label54 = new System.Windows.Forms.Label();
            this.LBL_BatchName = new System.Windows.Forms.Label();
            this.Label55 = new System.Windows.Forms.Label();
            this.Label56 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.Label31 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo2 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo3 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo4 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo5 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo6 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo7 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo8 = new System.Windows.Forms.Label();
            this.LBL_Name_Silo1 = new System.Windows.Forms.Label();
            this.Panel14 = new System.Windows.Forms.Panel();
            this.hmiLabel33 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel34 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_4 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_4 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel15 = new System.Windows.Forms.Panel();
            this.hmiLabel41 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel42 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_8 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_8 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel13 = new System.Windows.Forms.Panel();
            this.hmiLabel39 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel40 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_7 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_7 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel12 = new System.Windows.Forms.Panel();
            this.hmiLabel37 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel38 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_6 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_6 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel11 = new System.Windows.Forms.Panel();
            this.hmiLabel35 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel36 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_5 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_5 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.hmiLabel31 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel32 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_3 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_3 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel10 = new System.Windows.Forms.Panel();
            this.hmiLabel28 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel27 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_1 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_1 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel20 = new System.Windows.Forms.Panel();
            this.hmiLabel29 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel30 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_2 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_set_2 = new AdvancedScada.Controls.Display.HMILabel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.hmiLabel25 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiSevenSegment1 = new AdvancedScada.Controls.SevenSegment.HMISevenSegment2();
            this.msg_thnk = new System.Windows.Forms.Label();
            this.Panel21 = new System.Windows.Forms.Panel();
            this.hmiSimpleLED1 = new AdvancedScada.Controls.LED.HMISimpleLED();
            this.hmiIndicator2 = new AdvancedScada.Controls.Controls.HMIIndicator();
            this.hmiLabel23 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel24 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel21 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel22 = new AdvancedScada.Controls.Display.HMILabel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.P__Exit = new System.Windows.Forms.Panel();
            this.lbl_Exit = new System.Windows.Forms.Label();
            this.P_FRM_Advanced = new System.Windows.Forms.Panel();
            this.Lbl_FRM_Advanced = new System.Windows.Forms.Label();
            this.P_REPORT = new System.Windows.Forms.Panel();
            this.LBL_REPORT = new System.Windows.Forms.Label();
            this.P_Frm_Editr = new System.Windows.Forms.Panel();
            this.lbl_frm_Editr = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.LBL_WeightSet = new AdvancedScada.Controls.Display.HMILabel();
            this.Label38 = new System.Windows.Forms.Label();
            this.Label39 = new System.Windows.Forms.Label();
            this.Label40 = new System.Windows.Forms.Label();
            this.LBL_Weight_old = new System.Windows.Forms.Label();
            this.LBL_WeightFinel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hmiLabel44 = new AdvancedScada.Controls.Display.HMILabel();
            this.thnk_rec_oil = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel46 = new AdvancedScada.Controls.Display.HMILabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.hmiSimpleLED2 = new AdvancedScada.Controls.LED.HMISimpleLED();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.hmiLabel53 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel52 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel51 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel50 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel49 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel48 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel47 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiLabel43 = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiPilotLight4 = new AdvancedScada.Controls.SelectorSwitch.HMIPilotLight();
            this.hmiPilotLight3 = new AdvancedScada.Controls.SelectorSwitch.HMIPilotLight();
            this.hmiPilotLight2 = new AdvancedScada.Controls.SelectorSwitch.HMIPilotLight();
            this.hmiPilotLight1 = new AdvancedScada.Controls.SelectorSwitch.HMIPilotLight();
            this.hmiDigitalPanelMeter1 = new AdvancedScada.Controls.DigitalDisplay.HMIDigitalPanelMeter();
            this.hmiMushroomButton1 = new AdvancedScada.Controls.SelectorSwitch.HMIMushroomButton();
            this.hmiWaterPump1 = new AdvancedScada.Controls.Motor.HMIWaterPump();
            this.hmiIndicator1 = new AdvancedScada.Controls.Controls.HMIIndicator();
            this.hmiMotor8 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor7 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor6 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor5 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor4 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor3 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor2 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.hmiMotor1 = new AdvancedScada.Controls.Motor.HMIMotor();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LBL_ReportViewer = new AdvancedScada.Controls.Display.HMILabel();
            this.hmiProcessLevel1 = new AdvancedScada.Controls.ProcessAll.HMIProcessIndicator();
            this.hmiProcessLevel2 = new AdvancedScada.Controls.ProcessAll.HMIProcessIndicator();
            this.hmiProcessLevel3 = new AdvancedScada.Controls.ProcessAll.HMIProcessIndicator();
            this.hmiSevenSegment21 = new AdvancedScada.Controls.SevenSegment.HMISevenSegment2();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel9 = new System.Windows.Forms.Panel();
            this.Label3 = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.hmiLedSingle1 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle2 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle3 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle4 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle5 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle6 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle7 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiLedSingle8 = new AdvancedScada.Controls.Leds.HMILedSingle();
            this.hmiDigitalPanelMeter2 = new AdvancedScada.Controls.DigitalDisplay.HMIDigitalPanelMeter();
            this.hmiSimpleWebServer1 = new AdvancedScada.Controls.Components.HMISimpleWebServer();
            this.Panel3.SuspendLayout();
            this.Panel14.SuspendLayout();
            this.Panel15.SuspendLayout();
            this.Panel13.SuspendLayout();
            this.Panel12.SuspendLayout();
            this.Panel11.SuspendLayout();
            this.Panel7.SuspendLayout();
            this.Panel10.SuspendLayout();
            this.Panel20.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel21.SuspendLayout();
            this.P__Exit.SuspendLayout();
            this.P_FRM_Advanced.SuspendLayout();
            this.P_REPORT.SuspendLayout();
            this.P_Frm_Editr.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.Panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmiSimpleWebServer1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.ToolBer;
            this.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.hmiLabel54);
            this.Panel3.Controls.Add(this.hmiLabel20);
            this.Panel3.Controls.Add(this.hmiLabel19);
            this.Panel3.Controls.Add(this.hmiLabel18);
            this.Panel3.Controls.Add(this.hmiLabel17);
            this.Panel3.Controls.Add(this.DateTimePicker1);
            this.Panel3.Controls.Add(this.txt_datar);
            this.Panel3.Controls.Add(this.Label13);
            this.Panel3.Controls.Add(this.txt_sdata);
            this.Panel3.Controls.Add(this.Label14);
            this.Panel3.Controls.Add(this.Label15);
            this.Panel3.Controls.Add(this.Label16);
            this.Panel3.Controls.Add(this.lbl_DeyOfWeek);
            this.Panel3.Controls.Add(this.Label17);
            this.Panel3.Controls.Add(this.Label52);
            this.Panel3.Controls.Add(this.Label53);
            this.Panel3.Controls.Add(this.Label54);
            this.Panel3.Controls.Add(this.LBL_BatchName);
            this.Panel3.Controls.Add(this.Label55);
            this.Panel3.Controls.Add(this.Label56);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Panel3.ForeColor = System.Drawing.Color.Black;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(1286, 59);
            this.Panel3.TabIndex = 449;
            // 
            // hmiLabel54
            // 
            this.hmiLabel54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel54.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel54.DisplayAsTime = false;
            this.hmiLabel54.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel54.Highlight = false;
            this.hmiLabel54.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel54.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel54.HighlightKeyCharacter = "!";
            this.hmiLabel54.InterpretValueAsBCD = false;
            this.hmiLabel54.KeypadAlphaNumeric = false;
            this.hmiLabel54.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel54.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel54.KeypadMaxValue = 0D;
            this.hmiLabel54.KeypadMinValue = 0D;
            this.hmiLabel54.KeypadScaleFactor = 1D;
            this.hmiLabel54.KeypadShowCurrentValue = false;
            this.hmiLabel54.KeypadText = null;
            this.hmiLabel54.KeypadWidth = 400;
            this.hmiLabel54.Location = new System.Drawing.Point(655, 32);
            this.hmiLabel54.Name = "hmiLabel54";
            this.hmiLabel54.NumericFormat = null;
            this.hmiLabel54.PLCAddressHighlight = "";
            this.hmiLabel54.PLCAddressKeypad = "";
            this.hmiLabel54.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:92";
            this.hmiLabel54.PLCAddressVisible = "";
            this.hmiLabel54.PollRate = 0;
            this.hmiLabel54.Size = new System.Drawing.Size(56, 22);
            this.hmiLabel54.TabIndex = 608;
            this.hmiLabel54.Text = "0";
            this.hmiLabel54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel54.Value = "0";
            this.hmiLabel54.ValueLeftPadCharacter = ' ';
            this.hmiLabel54.ValueLeftPadLength = 0;
            this.hmiLabel54.ValuePrefix = null;
            this.hmiLabel54.ValueScaleFactor = 1D;
            this.hmiLabel54.ValueSuffix = null;
            this.hmiLabel54.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel20
            // 
            this.hmiLabel20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel20.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel20.DisplayAsTime = false;
            this.hmiLabel20.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel20.Highlight = false;
            this.hmiLabel20.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel20.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel20.HighlightKeyCharacter = "!";
            this.hmiLabel20.InterpretValueAsBCD = false;
            this.hmiLabel20.KeypadAlphaNumeric = false;
            this.hmiLabel20.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel20.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel20.KeypadMaxValue = 0D;
            this.hmiLabel20.KeypadMinValue = 0D;
            this.hmiLabel20.KeypadScaleFactor = 1D;
            this.hmiLabel20.KeypadShowCurrentValue = false;
            this.hmiLabel20.KeypadText = null;
            this.hmiLabel20.KeypadWidth = 400;
            this.hmiLabel20.Location = new System.Drawing.Point(137, 0);
            this.hmiLabel20.Name = "hmiLabel20";
            this.hmiLabel20.NumericFormat = null;
            this.hmiLabel20.PLCAddressHighlight = "";
            this.hmiLabel20.PLCAddressKeypad = "";
            this.hmiLabel20.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:128";
            this.hmiLabel20.PLCAddressVisible = "";
            this.hmiLabel20.PollRate = 0;
            this.hmiLabel20.Size = new System.Drawing.Size(56, 22);
            this.hmiLabel20.TabIndex = 607;
            this.hmiLabel20.Text = "0";
            this.hmiLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel20.Value = "0";
            this.hmiLabel20.ValueLeftPadCharacter = ' ';
            this.hmiLabel20.ValueLeftPadLength = 0;
            this.hmiLabel20.ValuePrefix = null;
            this.hmiLabel20.ValueScaleFactor = 1D;
            this.hmiLabel20.ValueSuffix = null;
            this.hmiLabel20.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel19
            // 
            this.hmiLabel19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel19.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel19.DisplayAsTime = false;
            this.hmiLabel19.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel19.Highlight = false;
            this.hmiLabel19.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel19.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel19.HighlightKeyCharacter = "!";
            this.hmiLabel19.InterpretValueAsBCD = false;
            this.hmiLabel19.KeypadAlphaNumeric = false;
            this.hmiLabel19.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel19.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel19.KeypadMaxValue = 0D;
            this.hmiLabel19.KeypadMinValue = 0D;
            this.hmiLabel19.KeypadScaleFactor = 1D;
            this.hmiLabel19.KeypadShowCurrentValue = false;
            this.hmiLabel19.KeypadText = null;
            this.hmiLabel19.KeypadWidth = 400;
            this.hmiLabel19.Location = new System.Drawing.Point(293, 0);
            this.hmiLabel19.Name = "hmiLabel19";
            this.hmiLabel19.NumericFormat = null;
            this.hmiLabel19.PLCAddressHighlight = "";
            this.hmiLabel19.PLCAddressKeypad = "TEST.PLC.StartAddress90.StartAddress90:124";
            this.hmiLabel19.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:124";
            this.hmiLabel19.PLCAddressVisible = "";
            this.hmiLabel19.PollRate = 0;
            this.hmiLabel19.Size = new System.Drawing.Size(56, 22);
            this.hmiLabel19.TabIndex = 606;
            this.hmiLabel19.Text = "0";
            this.hmiLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel19.Value = "0";
            this.hmiLabel19.ValueLeftPadCharacter = ' ';
            this.hmiLabel19.ValueLeftPadLength = 0;
            this.hmiLabel19.ValuePrefix = null;
            this.hmiLabel19.ValueScaleFactor = 1D;
            this.hmiLabel19.ValueSuffix = null;
            this.hmiLabel19.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel18
            // 
            this.hmiLabel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel18.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel18.DisplayAsTime = false;
            this.hmiLabel18.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel18.Highlight = false;
            this.hmiLabel18.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel18.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel18.HighlightKeyCharacter = "!";
            this.hmiLabel18.InterpretValueAsBCD = false;
            this.hmiLabel18.KeypadAlphaNumeric = false;
            this.hmiLabel18.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel18.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel18.KeypadMaxValue = 0D;
            this.hmiLabel18.KeypadMinValue = 0D;
            this.hmiLabel18.KeypadScaleFactor = 1D;
            this.hmiLabel18.KeypadShowCurrentValue = false;
            this.hmiLabel18.KeypadText = null;
            this.hmiLabel18.KeypadWidth = 400;
            this.hmiLabel18.Location = new System.Drawing.Point(551, 32);
            this.hmiLabel18.Name = "hmiLabel18";
            this.hmiLabel18.NumericFormat = null;
            this.hmiLabel18.PLCAddressHighlight = "";
            this.hmiLabel18.PLCAddressKeypad = "TEST.PLC.StartAddress90.StartAddress90:90";
            this.hmiLabel18.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:90";
            this.hmiLabel18.PLCAddressVisible = "";
            this.hmiLabel18.PollRate = 0;
            this.hmiLabel18.Size = new System.Drawing.Size(56, 22);
            this.hmiLabel18.TabIndex = 605;
            this.hmiLabel18.Text = "0";
            this.hmiLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel18.Value = "0";
            this.hmiLabel18.ValueLeftPadCharacter = ' ';
            this.hmiLabel18.ValueLeftPadLength = 0;
            this.hmiLabel18.ValuePrefix = null;
            this.hmiLabel18.ValueScaleFactor = 1D;
            this.hmiLabel18.ValueSuffix = null;
            this.hmiLabel18.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel17
            // 
            this.hmiLabel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel17.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel17.DisplayAsTime = false;
            this.hmiLabel17.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel17.Highlight = false;
            this.hmiLabel17.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel17.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel17.HighlightKeyCharacter = "!";
            this.hmiLabel17.InterpretValueAsBCD = false;
            this.hmiLabel17.KeypadAlphaNumeric = false;
            this.hmiLabel17.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel17.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel17.KeypadMaxValue = 0D;
            this.hmiLabel17.KeypadMinValue = 0D;
            this.hmiLabel17.KeypadScaleFactor = 1D;
            this.hmiLabel17.KeypadShowCurrentValue = false;
            this.hmiLabel17.KeypadText = null;
            this.hmiLabel17.KeypadWidth = 400;
            this.hmiLabel17.Location = new System.Drawing.Point(760, 30);
            this.hmiLabel17.Name = "hmiLabel17";
            this.hmiLabel17.NumericFormat = null;
            this.hmiLabel17.PLCAddressHighlight = "";
            this.hmiLabel17.PLCAddressKeypad = "TEST.PLC.StartAddress22.StartAddress22:88";
            this.hmiLabel17.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:88";
            this.hmiLabel17.PLCAddressVisible = "";
            this.hmiLabel17.PollRate = 0;
            this.hmiLabel17.Size = new System.Drawing.Size(56, 22);
            this.hmiLabel17.TabIndex = 604;
            this.hmiLabel17.Text = "0";
            this.hmiLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel17.Value = "0";
            this.hmiLabel17.ValueLeftPadCharacter = ' ';
            this.hmiLabel17.ValueLeftPadLength = 0;
            this.hmiLabel17.ValuePrefix = null;
            this.hmiLabel17.ValueScaleFactor = 1D;
            this.hmiLabel17.ValueSuffix = null;
            this.hmiLabel17.ValueToSubtractFrom = 0F;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CustomFormat = "yyyy-MM-dd ss:mm:hh";
            this.DateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker1.Location = new System.Drawing.Point(952, 31);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(233, 23);
            this.DateTimePicker1.TabIndex = 603;
            // 
            // txt_datar
            // 
            this.txt_datar.AutoSize = true;
            this.txt_datar.BackColor = System.Drawing.Color.Transparent;
            this.txt_datar.Location = new System.Drawing.Point(41, 33);
            this.txt_datar.Name = "txt_datar";
            this.txt_datar.Size = new System.Drawing.Size(27, 19);
            this.txt_datar.TabIndex = 322;
            this.txt_datar.Text = "\"\"";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Location = new System.Drawing.Point(178, 30);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(101, 19);
            this.Label13.TabIndex = 321;
            this.Label13.Text = "زمن نهاية الخلطة";
            // 
            // txt_sdata
            // 
            this.txt_sdata.AutoSize = true;
            this.txt_sdata.BackColor = System.Drawing.Color.Transparent;
            this.txt_sdata.Location = new System.Drawing.Point(307, 32);
            this.txt_sdata.Name = "txt_sdata";
            this.txt_sdata.Size = new System.Drawing.Size(27, 19);
            this.txt_sdata.TabIndex = 320;
            this.txt_sdata.Text = "\"\"";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Location = new System.Drawing.Point(353, 33);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(99, 19);
            this.Label14.TabIndex = 319;
            this.Label14.Text = "زمن بداية الخلطة";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Location = new System.Drawing.Point(199, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(68, 19);
            this.Label15.TabIndex = 318;
            this.Label15.Text = "زمن الفعلى";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Location = new System.Drawing.Point(355, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(97, 19);
            this.Label16.TabIndex = 317;
            this.Label16.Text = "زمن غلق البوابة";
            // 
            // lbl_DeyOfWeek
            // 
            this.lbl_DeyOfWeek.AutoSize = true;
            this.lbl_DeyOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DeyOfWeek.Location = new System.Drawing.Point(878, 35);
            this.lbl_DeyOfWeek.Name = "lbl_DeyOfWeek";
            this.lbl_DeyOfWeek.Size = new System.Drawing.Size(17, 19);
            this.lbl_DeyOfWeek.TabIndex = 285;
            this.lbl_DeyOfWeek.Text = "0";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Location = new System.Drawing.Point(633, 10);
            this.Label17.Name = "Label17";
            this.Label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label17.Size = new System.Drawing.Size(93, 19);
            this.Label17.TabIndex = 266;
            this.Label17.Text = "الوزنات الحالية:";
            // 
            // Label52
            // 
            this.Label52.AutoSize = true;
            this.Label52.BackColor = System.Drawing.Color.Transparent;
            this.Label52.Location = new System.Drawing.Point(538, 10);
            this.Label52.Name = "Label52";
            this.Label52.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label52.Size = new System.Drawing.Size(73, 19);
            this.Label52.TabIndex = 265;
            this.Label52.Text = "وزن الصفر:";
            // 
            // Label53
            // 
            this.Label53.AutoSize = true;
            this.Label53.BackColor = System.Drawing.Color.Transparent;
            this.Label53.Location = new System.Drawing.Point(728, 8);
            this.Label53.Name = "Label53";
            this.Label53.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label53.Size = new System.Drawing.Size(126, 19);
            this.Label53.TabIndex = 4;
            this.Label53.Text = "عدد الوزنات المطلوبة:";
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.BackColor = System.Drawing.Color.Transparent;
            this.Label54.Location = new System.Drawing.Point(860, 8);
            this.Label54.Name = "Label54";
            this.Label54.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label54.Size = new System.Drawing.Size(52, 19);
            this.Label54.TabIndex = 3;
            this.Label54.Text = "الوردية:";
            // 
            // LBL_BatchName
            // 
            this.LBL_BatchName.AutoSize = true;
            this.LBL_BatchName.BackColor = System.Drawing.Color.Transparent;
            this.LBL_BatchName.Location = new System.Drawing.Point(1095, 8);
            this.LBL_BatchName.Name = "LBL_BatchName";
            this.LBL_BatchName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LBL_BatchName.Size = new System.Drawing.Size(73, 19);
            this.LBL_BatchName.TabIndex = 2;
            this.LBL_BatchName.Text = "اسم الخلطة:";
            // 
            // Label55
            // 
            this.Label55.AutoSize = true;
            this.Label55.BackColor = System.Drawing.Color.Transparent;
            this.Label55.Location = new System.Drawing.Point(1191, 33);
            this.Label55.Name = "Label55";
            this.Label55.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label55.Size = new System.Drawing.Size(81, 19);
            this.Label55.TabIndex = 1;
            this.Label55.Text = "بداية التشغيل:";
            // 
            // Label56
            // 
            this.Label56.AutoSize = true;
            this.Label56.BackColor = System.Drawing.Color.Transparent;
            this.Label56.Location = new System.Drawing.Point(1199, 8);
            this.Label56.Name = "Label56";
            this.Label56.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Label56.Size = new System.Drawing.Size(73, 19);
            this.Label56.TabIndex = 0;
            this.Label56.Text = "اسم الخلطة:";
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label37.ForeColor = System.Drawing.Color.Blue;
            this.Label37.Location = new System.Drawing.Point(1139, 61);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(16, 15);
            this.Label37.TabIndex = 499;
            this.Label37.Text = "2";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label36.ForeColor = System.Drawing.Color.Blue;
            this.Label36.Location = new System.Drawing.Point(1079, 61);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(16, 15);
            this.Label36.TabIndex = 498;
            this.Label36.Text = "3";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label35.ForeColor = System.Drawing.Color.Blue;
            this.Label35.Location = new System.Drawing.Point(1004, 61);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(16, 15);
            this.Label35.TabIndex = 497;
            this.Label35.Text = "4";
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label34.ForeColor = System.Drawing.Color.Blue;
            this.Label34.Location = new System.Drawing.Point(934, 61);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(16, 15);
            this.Label34.TabIndex = 496;
            this.Label34.Text = "5";
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label33.ForeColor = System.Drawing.Color.Blue;
            this.Label33.Location = new System.Drawing.Point(864, 61);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(16, 15);
            this.Label33.TabIndex = 495;
            this.Label33.Text = "6";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label32.ForeColor = System.Drawing.Color.Blue;
            this.Label32.Location = new System.Drawing.Point(802, 61);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(16, 15);
            this.Label32.TabIndex = 494;
            this.Label32.Text = "7";
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label31.ForeColor = System.Drawing.Color.Blue;
            this.Label31.Location = new System.Drawing.Point(739, 61);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(16, 15);
            this.Label31.TabIndex = 493;
            this.Label31.Text = "8";
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label26.ForeColor = System.Drawing.Color.Blue;
            this.Label26.Location = new System.Drawing.Point(1213, 61);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(16, 15);
            this.Label26.TabIndex = 492;
            this.Label26.Text = "1";
            // 
            // LBL_Name_Silo2
            // 
            this.LBL_Name_Silo2.AutoSize = true;
            this.LBL_Name_Silo2.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo2.Location = new System.Drawing.Point(1129, 94);
            this.LBL_Name_Silo2.Name = "LBL_Name_Silo2";
            this.LBL_Name_Silo2.Size = new System.Drawing.Size(44, 13);
            this.LBL_Name_Silo2.TabIndex = 491;
            this.LBL_Name_Silo2.Text = "ذورة 2";
            this.LBL_Name_Silo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo3
            // 
            this.LBL_Name_Silo3.AutoSize = true;
            this.LBL_Name_Silo3.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo3.Location = new System.Drawing.Point(1061, 94);
            this.LBL_Name_Silo3.Name = "LBL_Name_Silo3";
            this.LBL_Name_Silo3.Size = new System.Drawing.Size(34, 13);
            this.LBL_Name_Silo3.TabIndex = 490;
            this.LBL_Name_Silo3.Text = "صويا";
            this.LBL_Name_Silo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo4
            // 
            this.LBL_Name_Silo4.AutoSize = true;
            this.LBL_Name_Silo4.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo4.Location = new System.Drawing.Point(986, 94);
            this.LBL_Name_Silo4.Name = "LBL_Name_Silo4";
            this.LBL_Name_Silo4.Size = new System.Drawing.Size(45, 13);
            this.LBL_Name_Silo4.TabIndex = 489;
            this.LBL_Name_Silo4.Text = "صويا 2";
            this.LBL_Name_Silo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo5
            // 
            this.LBL_Name_Silo5.AutoSize = true;
            this.LBL_Name_Silo5.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo5.Location = new System.Drawing.Point(931, 94);
            this.LBL_Name_Silo5.Name = "LBL_Name_Silo5";
            this.LBL_Name_Silo5.Size = new System.Drawing.Size(30, 13);
            this.LBL_Name_Silo5.TabIndex = 488;
            this.LBL_Name_Silo5.Text = "جير ";
            this.LBL_Name_Silo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo6
            // 
            this.LBL_Name_Silo6.AutoSize = true;
            this.LBL_Name_Silo6.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo6.Location = new System.Drawing.Point(861, 94);
            this.LBL_Name_Silo6.Name = "LBL_Name_Silo6";
            this.LBL_Name_Silo6.Size = new System.Drawing.Size(25, 13);
            this.LBL_Name_Silo6.TabIndex = 487;
            this.LBL_Name_Silo6.Text = "ماء";
            this.LBL_Name_Silo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo7
            // 
            this.LBL_Name_Silo7.AutoSize = true;
            this.LBL_Name_Silo7.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo7.Location = new System.Drawing.Point(786, 94);
            this.LBL_Name_Silo7.Name = "LBL_Name_Silo7";
            this.LBL_Name_Silo7.Size = new System.Drawing.Size(46, 13);
            this.LBL_Name_Silo7.TabIndex = 486;
            this.LBL_Name_Silo7.Text = "مركبات";
            this.LBL_Name_Silo7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo8
            // 
            this.LBL_Name_Silo8.AutoSize = true;
            this.LBL_Name_Silo8.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo8.Location = new System.Drawing.Point(716, 94);
            this.LBL_Name_Silo8.Name = "LBL_Name_Silo8";
            this.LBL_Name_Silo8.Size = new System.Drawing.Size(64, 13);
            this.LBL_Name_Silo8.TabIndex = 485;
            this.LBL_Name_Silo8.Text = "عبد الشمس";
            this.LBL_Name_Silo8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Name_Silo1
            // 
            this.LBL_Name_Silo1.AutoSize = true;
            this.LBL_Name_Silo1.ForeColor = System.Drawing.Color.Black;
            this.LBL_Name_Silo1.Location = new System.Drawing.Point(1201, 94);
            this.LBL_Name_Silo1.Name = "LBL_Name_Silo1";
            this.LBL_Name_Silo1.Size = new System.Drawing.Size(37, 13);
            this.LBL_Name_Silo1.TabIndex = 484;
            this.LBL_Name_Silo1.Text = "ذورة ";
            this.LBL_Name_Silo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel14
            // 
            this.Panel14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel14.BackgroundImage")));
            this.Panel14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel14.Controls.Add(this.hmiLabel33);
            this.Panel14.Controls.Add(this.hmiLabel34);
            this.Panel14.Controls.Add(this.thnk_rec_4);
            this.Panel14.Controls.Add(this.thnk_set_4);
            this.Panel14.Location = new System.Drawing.Point(978, 111);
            this.Panel14.Name = "Panel14";
            this.Panel14.Size = new System.Drawing.Size(68, 114);
            this.Panel14.TabIndex = 478;
            // 
            // hmiLabel33
            // 
            this.hmiLabel33.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel33.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel33.DisplayAsTime = false;
            this.hmiLabel33.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel33.Highlight = false;
            this.hmiLabel33.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel33.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel33.HighlightKeyCharacter = "!";
            this.hmiLabel33.InterpretValueAsBCD = false;
            this.hmiLabel33.KeypadAlphaNumeric = false;
            this.hmiLabel33.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel33.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel33.KeypadMaxValue = 0D;
            this.hmiLabel33.KeypadMinValue = 0D;
            this.hmiLabel33.KeypadScaleFactor = 1D;
            this.hmiLabel33.KeypadShowCurrentValue = false;
            this.hmiLabel33.KeypadText = null;
            this.hmiLabel33.KeypadWidth = 400;
            this.hmiLabel33.Location = new System.Drawing.Point(23, 88);
            this.hmiLabel33.Name = "hmiLabel33";
            this.hmiLabel33.NumericFormat = null;
            this.hmiLabel33.PLCAddressHighlight = "";
            this.hmiLabel33.PLCAddressKeypad = "";
            this.hmiLabel33.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:78";
            this.hmiLabel33.PLCAddressVisible = "";
            this.hmiLabel33.PollRate = 0;
            this.hmiLabel33.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel33.TabIndex = 5;
            this.hmiLabel33.Text = "0";
            this.hmiLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel33.Value = "0";
            this.hmiLabel33.ValueLeftPadCharacter = ' ';
            this.hmiLabel33.ValueLeftPadLength = 0;
            this.hmiLabel33.ValuePrefix = null;
            this.hmiLabel33.ValueScaleFactor = 1D;
            this.hmiLabel33.ValueSuffix = null;
            this.hmiLabel33.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel34
            // 
            this.hmiLabel34.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel34.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel34.DisplayAsTime = false;
            this.hmiLabel34.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel34.Highlight = false;
            this.hmiLabel34.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel34.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel34.HighlightKeyCharacter = "!";
            this.hmiLabel34.InterpretValueAsBCD = false;
            this.hmiLabel34.KeypadAlphaNumeric = false;
            this.hmiLabel34.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel34.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel34.KeypadMaxValue = 0D;
            this.hmiLabel34.KeypadMinValue = 0D;
            this.hmiLabel34.KeypadScaleFactor = 1D;
            this.hmiLabel34.KeypadShowCurrentValue = false;
            this.hmiLabel34.KeypadText = null;
            this.hmiLabel34.KeypadWidth = 400;
            this.hmiLabel34.Location = new System.Drawing.Point(24, 64);
            this.hmiLabel34.Name = "hmiLabel34";
            this.hmiLabel34.NumericFormat = null;
            this.hmiLabel34.PLCAddressHighlight = "";
            this.hmiLabel34.PLCAddressKeypad = "";
            this.hmiLabel34.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:16";
            this.hmiLabel34.PLCAddressVisible = "";
            this.hmiLabel34.PollRate = 0;
            this.hmiLabel34.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel34.TabIndex = 4;
            this.hmiLabel34.Text = "0";
            this.hmiLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel34.Value = "0";
            this.hmiLabel34.ValueLeftPadCharacter = ' ';
            this.hmiLabel34.ValueLeftPadLength = 0;
            this.hmiLabel34.ValuePrefix = null;
            this.hmiLabel34.ValueScaleFactor = 1D;
            this.hmiLabel34.ValueSuffix = null;
            this.hmiLabel34.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_4
            // 
            this.thnk_rec_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_4.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_4.DisplayAsTime = false;
            this.thnk_rec_4.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_4.Highlight = false;
            this.thnk_rec_4.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_4.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_4.HighlightKeyCharacter = "!";
            this.thnk_rec_4.InterpretValueAsBCD = false;
            this.thnk_rec_4.KeypadAlphaNumeric = false;
            this.thnk_rec_4.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_4.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_4.KeypadMaxValue = 0D;
            this.thnk_rec_4.KeypadMinValue = 0D;
            this.thnk_rec_4.KeypadScaleFactor = 1D;
            this.thnk_rec_4.KeypadShowCurrentValue = false;
            this.thnk_rec_4.KeypadText = null;
            this.thnk_rec_4.KeypadWidth = 400;
            this.thnk_rec_4.Location = new System.Drawing.Point(9, 36);
            this.thnk_rec_4.Name = "thnk_rec_4";
            this.thnk_rec_4.NumericFormat = null;
            this.thnk_rec_4.PLCAddressHighlight = "";
            this.thnk_rec_4.PLCAddressKeypad = "";
            this.thnk_rec_4.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:100";
            this.thnk_rec_4.PLCAddressVisible = "";
            this.thnk_rec_4.PollRate = 0;
            this.thnk_rec_4.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_4.TabIndex = 3;
            this.thnk_rec_4.Text = "0";
            this.thnk_rec_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_4.Value = "0";
            this.thnk_rec_4.ValueLeftPadCharacter = ' ';
            this.thnk_rec_4.ValueLeftPadLength = 0;
            this.thnk_rec_4.ValuePrefix = null;
            this.thnk_rec_4.ValueScaleFactor = 1D;
            this.thnk_rec_4.ValueSuffix = null;
            this.thnk_rec_4.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_4
            // 
            this.thnk_set_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_4.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_4.DisplayAsTime = false;
            this.thnk_set_4.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_4.Highlight = false;
            this.thnk_set_4.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_4.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_4.HighlightKeyCharacter = "!";
            this.thnk_set_4.InterpretValueAsBCD = false;
            this.thnk_set_4.KeypadAlphaNumeric = false;
            this.thnk_set_4.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_4.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_4.KeypadMaxValue = 0D;
            this.thnk_set_4.KeypadMinValue = 0D;
            this.thnk_set_4.KeypadScaleFactor = 1D;
            this.thnk_set_4.KeypadShowCurrentValue = false;
            this.thnk_set_4.KeypadText = null;
            this.thnk_set_4.KeypadWidth = 400;
            this.thnk_set_4.Location = new System.Drawing.Point(9, 11);
            this.thnk_set_4.Name = "thnk_set_4";
            this.thnk_set_4.NumericFormat = null;
            this.thnk_set_4.PLCAddressHighlight = "";
            this.thnk_set_4.PLCAddressKeypad = "";
            this.thnk_set_4.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00020";
            this.thnk_set_4.PLCAddressVisible = "";
            this.thnk_set_4.PollRate = 0;
            this.thnk_set_4.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_4.TabIndex = 2;
            this.thnk_set_4.Text = "0";
            this.thnk_set_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_4.Value = "0";
            this.thnk_set_4.ValueLeftPadCharacter = ' ';
            this.thnk_set_4.ValueLeftPadLength = 0;
            this.thnk_set_4.ValuePrefix = null;
            this.thnk_set_4.ValueScaleFactor = 1D;
            this.thnk_set_4.ValueSuffix = null;
            this.thnk_set_4.ValueToSubtractFrom = 0F;
            // 
            // Panel15
            // 
            this.Panel15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel15.BackgroundImage")));
            this.Panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel15.Controls.Add(this.hmiLabel41);
            this.Panel15.Controls.Add(this.hmiLabel42);
            this.Panel15.Controls.Add(this.thnk_rec_8);
            this.Panel15.Controls.Add(this.thnk_set_8);
            this.Panel15.Location = new System.Drawing.Point(705, 111);
            this.Panel15.Name = "Panel15";
            this.Panel15.Size = new System.Drawing.Size(68, 114);
            this.Panel15.TabIndex = 483;
            // 
            // hmiLabel41
            // 
            this.hmiLabel41.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel41.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel41.DisplayAsTime = false;
            this.hmiLabel41.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel41.Highlight = false;
            this.hmiLabel41.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel41.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel41.HighlightKeyCharacter = "!";
            this.hmiLabel41.InterpretValueAsBCD = false;
            this.hmiLabel41.KeypadAlphaNumeric = false;
            this.hmiLabel41.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel41.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel41.KeypadMaxValue = 0D;
            this.hmiLabel41.KeypadMinValue = 0D;
            this.hmiLabel41.KeypadScaleFactor = 1D;
            this.hmiLabel41.KeypadShowCurrentValue = false;
            this.hmiLabel41.KeypadText = null;
            this.hmiLabel41.KeypadWidth = 400;
            this.hmiLabel41.Location = new System.Drawing.Point(22, 88);
            this.hmiLabel41.Name = "hmiLabel41";
            this.hmiLabel41.NumericFormat = null;
            this.hmiLabel41.PLCAddressHighlight = "";
            this.hmiLabel41.PLCAddressKeypad = "";
            this.hmiLabel41.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:86";
            this.hmiLabel41.PLCAddressVisible = "";
            this.hmiLabel41.PollRate = 0;
            this.hmiLabel41.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel41.TabIndex = 5;
            this.hmiLabel41.Text = "0";
            this.hmiLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel41.Value = "0";
            this.hmiLabel41.ValueLeftPadCharacter = ' ';
            this.hmiLabel41.ValueLeftPadLength = 0;
            this.hmiLabel41.ValuePrefix = null;
            this.hmiLabel41.ValueScaleFactor = 1D;
            this.hmiLabel41.ValueSuffix = null;
            this.hmiLabel41.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel42
            // 
            this.hmiLabel42.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel42.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel42.DisplayAsTime = false;
            this.hmiLabel42.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel42.Highlight = false;
            this.hmiLabel42.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel42.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel42.HighlightKeyCharacter = "!";
            this.hmiLabel42.InterpretValueAsBCD = false;
            this.hmiLabel42.KeypadAlphaNumeric = false;
            this.hmiLabel42.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel42.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel42.KeypadMaxValue = 0D;
            this.hmiLabel42.KeypadMinValue = 0D;
            this.hmiLabel42.KeypadScaleFactor = 1D;
            this.hmiLabel42.KeypadShowCurrentValue = false;
            this.hmiLabel42.KeypadText = null;
            this.hmiLabel42.KeypadWidth = 400;
            this.hmiLabel42.Location = new System.Drawing.Point(23, 64);
            this.hmiLabel42.Name = "hmiLabel42";
            this.hmiLabel42.NumericFormat = null;
            this.hmiLabel42.PLCAddressHighlight = "";
            this.hmiLabel42.PLCAddressKeypad = "";
            this.hmiLabel42.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:32";
            this.hmiLabel42.PLCAddressVisible = "";
            this.hmiLabel42.PollRate = 0;
            this.hmiLabel42.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel42.TabIndex = 4;
            this.hmiLabel42.Text = "0";
            this.hmiLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel42.Value = "0";
            this.hmiLabel42.ValueLeftPadCharacter = ' ';
            this.hmiLabel42.ValueLeftPadLength = 0;
            this.hmiLabel42.ValuePrefix = null;
            this.hmiLabel42.ValueScaleFactor = 1D;
            this.hmiLabel42.ValueSuffix = null;
            this.hmiLabel42.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_8
            // 
            this.thnk_rec_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_8.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_8.DisplayAsTime = false;
            this.thnk_rec_8.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_8.Highlight = false;
            this.thnk_rec_8.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_8.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_8.HighlightKeyCharacter = "!";
            this.thnk_rec_8.InterpretValueAsBCD = false;
            this.thnk_rec_8.KeypadAlphaNumeric = false;
            this.thnk_rec_8.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_8.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_8.KeypadMaxValue = 0D;
            this.thnk_rec_8.KeypadMinValue = 0D;
            this.thnk_rec_8.KeypadScaleFactor = 1D;
            this.thnk_rec_8.KeypadShowCurrentValue = false;
            this.thnk_rec_8.KeypadText = null;
            this.thnk_rec_8.KeypadWidth = 400;
            this.thnk_rec_8.Location = new System.Drawing.Point(10, 36);
            this.thnk_rec_8.Name = "thnk_rec_8";
            this.thnk_rec_8.NumericFormat = null;
            this.thnk_rec_8.PLCAddressHighlight = "";
            this.thnk_rec_8.PLCAddressKeypad = "";
            this.thnk_rec_8.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:108";
            this.thnk_rec_8.PLCAddressVisible = "";
            this.thnk_rec_8.PollRate = 0;
            this.thnk_rec_8.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_8.TabIndex = 3;
            this.thnk_rec_8.Text = "0";
            this.thnk_rec_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_8.Value = "0";
            this.thnk_rec_8.ValueLeftPadCharacter = ' ';
            this.thnk_rec_8.ValueLeftPadLength = 0;
            this.thnk_rec_8.ValuePrefix = null;
            this.thnk_rec_8.ValueScaleFactor = 1D;
            this.thnk_rec_8.ValueSuffix = null;
            this.thnk_rec_8.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_8
            // 
            this.thnk_set_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_8.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_8.DisplayAsTime = false;
            this.thnk_set_8.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_8.Highlight = false;
            this.thnk_set_8.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_8.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_8.HighlightKeyCharacter = "!";
            this.thnk_set_8.InterpretValueAsBCD = false;
            this.thnk_set_8.KeypadAlphaNumeric = false;
            this.thnk_set_8.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_8.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_8.KeypadMaxValue = 0D;
            this.thnk_set_8.KeypadMinValue = 0D;
            this.thnk_set_8.KeypadScaleFactor = 1D;
            this.thnk_set_8.KeypadShowCurrentValue = false;
            this.thnk_set_8.KeypadText = null;
            this.thnk_set_8.KeypadWidth = 400;
            this.thnk_set_8.Location = new System.Drawing.Point(10, 11);
            this.thnk_set_8.Name = "thnk_set_8";
            this.thnk_set_8.NumericFormat = null;
            this.thnk_set_8.PLCAddressHighlight = "";
            this.thnk_set_8.PLCAddressKeypad = "";
            this.thnk_set_8.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00024";
            this.thnk_set_8.PLCAddressVisible = "";
            this.thnk_set_8.PollRate = 0;
            this.thnk_set_8.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_8.TabIndex = 2;
            this.thnk_set_8.Text = "0";
            this.thnk_set_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_8.Value = "0";
            this.thnk_set_8.ValueLeftPadCharacter = ' ';
            this.thnk_set_8.ValueLeftPadLength = 0;
            this.thnk_set_8.ValuePrefix = null;
            this.thnk_set_8.ValueScaleFactor = 1D;
            this.thnk_set_8.ValueSuffix = null;
            this.thnk_set_8.ValueToSubtractFrom = 0F;
            // 
            // Panel13
            // 
            this.Panel13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel13.BackgroundImage")));
            this.Panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel13.Controls.Add(this.hmiLabel39);
            this.Panel13.Controls.Add(this.hmiLabel40);
            this.Panel13.Controls.Add(this.thnk_rec_7);
            this.Panel13.Controls.Add(this.thnk_set_7);
            this.Panel13.Location = new System.Drawing.Point(773, 111);
            this.Panel13.Name = "Panel13";
            this.Panel13.Size = new System.Drawing.Size(68, 114);
            this.Panel13.TabIndex = 480;
            // 
            // hmiLabel39
            // 
            this.hmiLabel39.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel39.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel39.DisplayAsTime = false;
            this.hmiLabel39.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel39.Highlight = false;
            this.hmiLabel39.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel39.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel39.HighlightKeyCharacter = "!";
            this.hmiLabel39.InterpretValueAsBCD = false;
            this.hmiLabel39.KeypadAlphaNumeric = false;
            this.hmiLabel39.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel39.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel39.KeypadMaxValue = 0D;
            this.hmiLabel39.KeypadMinValue = 0D;
            this.hmiLabel39.KeypadScaleFactor = 1D;
            this.hmiLabel39.KeypadShowCurrentValue = false;
            this.hmiLabel39.KeypadText = null;
            this.hmiLabel39.KeypadWidth = 400;
            this.hmiLabel39.Location = new System.Drawing.Point(22, 88);
            this.hmiLabel39.Name = "hmiLabel39";
            this.hmiLabel39.NumericFormat = null;
            this.hmiLabel39.PLCAddressHighlight = "";
            this.hmiLabel39.PLCAddressKeypad = "";
            this.hmiLabel39.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:84";
            this.hmiLabel39.PLCAddressVisible = "";
            this.hmiLabel39.PollRate = 0;
            this.hmiLabel39.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel39.TabIndex = 5;
            this.hmiLabel39.Text = "0";
            this.hmiLabel39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel39.Value = "0";
            this.hmiLabel39.ValueLeftPadCharacter = ' ';
            this.hmiLabel39.ValueLeftPadLength = 0;
            this.hmiLabel39.ValuePrefix = null;
            this.hmiLabel39.ValueScaleFactor = 1D;
            this.hmiLabel39.ValueSuffix = null;
            this.hmiLabel39.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel40
            // 
            this.hmiLabel40.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel40.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel40.DisplayAsTime = false;
            this.hmiLabel40.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel40.Highlight = false;
            this.hmiLabel40.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel40.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel40.HighlightKeyCharacter = "!";
            this.hmiLabel40.InterpretValueAsBCD = false;
            this.hmiLabel40.KeypadAlphaNumeric = false;
            this.hmiLabel40.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel40.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel40.KeypadMaxValue = 0D;
            this.hmiLabel40.KeypadMinValue = 0D;
            this.hmiLabel40.KeypadScaleFactor = 1D;
            this.hmiLabel40.KeypadShowCurrentValue = false;
            this.hmiLabel40.KeypadText = null;
            this.hmiLabel40.KeypadWidth = 400;
            this.hmiLabel40.Location = new System.Drawing.Point(23, 64);
            this.hmiLabel40.Name = "hmiLabel40";
            this.hmiLabel40.NumericFormat = null;
            this.hmiLabel40.PLCAddressHighlight = "";
            this.hmiLabel40.PLCAddressKeypad = "";
            this.hmiLabel40.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:28";
            this.hmiLabel40.PLCAddressVisible = "";
            this.hmiLabel40.PollRate = 0;
            this.hmiLabel40.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel40.TabIndex = 4;
            this.hmiLabel40.Text = "0";
            this.hmiLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel40.Value = "0";
            this.hmiLabel40.ValueLeftPadCharacter = ' ';
            this.hmiLabel40.ValueLeftPadLength = 0;
            this.hmiLabel40.ValuePrefix = null;
            this.hmiLabel40.ValueScaleFactor = 1D;
            this.hmiLabel40.ValueSuffix = null;
            this.hmiLabel40.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_7
            // 
            this.thnk_rec_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_7.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_7.DisplayAsTime = false;
            this.thnk_rec_7.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_7.Highlight = false;
            this.thnk_rec_7.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_7.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_7.HighlightKeyCharacter = "!";
            this.thnk_rec_7.InterpretValueAsBCD = false;
            this.thnk_rec_7.KeypadAlphaNumeric = false;
            this.thnk_rec_7.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_7.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_7.KeypadMaxValue = 0D;
            this.thnk_rec_7.KeypadMinValue = 0D;
            this.thnk_rec_7.KeypadScaleFactor = 1D;
            this.thnk_rec_7.KeypadShowCurrentValue = false;
            this.thnk_rec_7.KeypadText = null;
            this.thnk_rec_7.KeypadWidth = 400;
            this.thnk_rec_7.Location = new System.Drawing.Point(10, 36);
            this.thnk_rec_7.Name = "thnk_rec_7";
            this.thnk_rec_7.NumericFormat = null;
            this.thnk_rec_7.PLCAddressHighlight = "";
            this.thnk_rec_7.PLCAddressKeypad = "";
            this.thnk_rec_7.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:106";
            this.thnk_rec_7.PLCAddressVisible = "";
            this.thnk_rec_7.PollRate = 0;
            this.thnk_rec_7.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_7.TabIndex = 3;
            this.thnk_rec_7.Text = "0";
            this.thnk_rec_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_7.Value = "0";
            this.thnk_rec_7.ValueLeftPadCharacter = ' ';
            this.thnk_rec_7.ValueLeftPadLength = 0;
            this.thnk_rec_7.ValuePrefix = null;
            this.thnk_rec_7.ValueScaleFactor = 1D;
            this.thnk_rec_7.ValueSuffix = null;
            this.thnk_rec_7.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_7
            // 
            this.thnk_set_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_7.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_7.DisplayAsTime = false;
            this.thnk_set_7.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_7.Highlight = false;
            this.thnk_set_7.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_7.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_7.HighlightKeyCharacter = "!";
            this.thnk_set_7.InterpretValueAsBCD = false;
            this.thnk_set_7.KeypadAlphaNumeric = false;
            this.thnk_set_7.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_7.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_7.KeypadMaxValue = 0D;
            this.thnk_set_7.KeypadMinValue = 0D;
            this.thnk_set_7.KeypadScaleFactor = 1D;
            this.thnk_set_7.KeypadShowCurrentValue = false;
            this.thnk_set_7.KeypadText = null;
            this.thnk_set_7.KeypadWidth = 400;
            this.thnk_set_7.Location = new System.Drawing.Point(10, 11);
            this.thnk_set_7.Name = "thnk_set_7";
            this.thnk_set_7.NumericFormat = null;
            this.thnk_set_7.PLCAddressHighlight = "";
            this.thnk_set_7.PLCAddressKeypad = "";
            this.thnk_set_7.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00023";
            this.thnk_set_7.PLCAddressVisible = "";
            this.thnk_set_7.PollRate = 0;
            this.thnk_set_7.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_7.TabIndex = 2;
            this.thnk_set_7.Text = "0";
            this.thnk_set_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_7.Value = "0";
            this.thnk_set_7.ValueLeftPadCharacter = ' ';
            this.thnk_set_7.ValueLeftPadLength = 0;
            this.thnk_set_7.ValuePrefix = null;
            this.thnk_set_7.ValueScaleFactor = 1D;
            this.thnk_set_7.ValueSuffix = null;
            this.thnk_set_7.ValueToSubtractFrom = 0F;
            // 
            // Panel12
            // 
            this.Panel12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel12.BackgroundImage")));
            this.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel12.Controls.Add(this.hmiLabel37);
            this.Panel12.Controls.Add(this.hmiLabel38);
            this.Panel12.Controls.Add(this.thnk_rec_6);
            this.Panel12.Controls.Add(this.thnk_set_6);
            this.Panel12.Location = new System.Drawing.Point(841, 111);
            this.Panel12.Name = "Panel12";
            this.Panel12.Size = new System.Drawing.Size(68, 114);
            this.Panel12.TabIndex = 481;
            // 
            // hmiLabel37
            // 
            this.hmiLabel37.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel37.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel37.DisplayAsTime = false;
            this.hmiLabel37.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel37.Highlight = false;
            this.hmiLabel37.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel37.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel37.HighlightKeyCharacter = "!";
            this.hmiLabel37.InterpretValueAsBCD = false;
            this.hmiLabel37.KeypadAlphaNumeric = false;
            this.hmiLabel37.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel37.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel37.KeypadMaxValue = 0D;
            this.hmiLabel37.KeypadMinValue = 0D;
            this.hmiLabel37.KeypadScaleFactor = 1D;
            this.hmiLabel37.KeypadShowCurrentValue = false;
            this.hmiLabel37.KeypadText = null;
            this.hmiLabel37.KeypadWidth = 400;
            this.hmiLabel37.Location = new System.Drawing.Point(22, 88);
            this.hmiLabel37.Name = "hmiLabel37";
            this.hmiLabel37.NumericFormat = null;
            this.hmiLabel37.PLCAddressHighlight = "";
            this.hmiLabel37.PLCAddressKeypad = "";
            this.hmiLabel37.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:82";
            this.hmiLabel37.PLCAddressVisible = "";
            this.hmiLabel37.PollRate = 0;
            this.hmiLabel37.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel37.TabIndex = 5;
            this.hmiLabel37.Text = "0";
            this.hmiLabel37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel37.Value = "0";
            this.hmiLabel37.ValueLeftPadCharacter = ' ';
            this.hmiLabel37.ValueLeftPadLength = 0;
            this.hmiLabel37.ValuePrefix = null;
            this.hmiLabel37.ValueScaleFactor = 1D;
            this.hmiLabel37.ValueSuffix = null;
            this.hmiLabel37.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel38
            // 
            this.hmiLabel38.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel38.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel38.DisplayAsTime = false;
            this.hmiLabel38.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel38.Highlight = false;
            this.hmiLabel38.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel38.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel38.HighlightKeyCharacter = "!";
            this.hmiLabel38.InterpretValueAsBCD = false;
            this.hmiLabel38.KeypadAlphaNumeric = false;
            this.hmiLabel38.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel38.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel38.KeypadMaxValue = 0D;
            this.hmiLabel38.KeypadMinValue = 0D;
            this.hmiLabel38.KeypadScaleFactor = 1D;
            this.hmiLabel38.KeypadShowCurrentValue = false;
            this.hmiLabel38.KeypadText = null;
            this.hmiLabel38.KeypadWidth = 400;
            this.hmiLabel38.Location = new System.Drawing.Point(23, 64);
            this.hmiLabel38.Name = "hmiLabel38";
            this.hmiLabel38.NumericFormat = null;
            this.hmiLabel38.PLCAddressHighlight = "";
            this.hmiLabel38.PLCAddressKeypad = "";
            this.hmiLabel38.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:24";
            this.hmiLabel38.PLCAddressVisible = "";
            this.hmiLabel38.PollRate = 0;
            this.hmiLabel38.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel38.TabIndex = 4;
            this.hmiLabel38.Text = "0";
            this.hmiLabel38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel38.Value = "0";
            this.hmiLabel38.ValueLeftPadCharacter = ' ';
            this.hmiLabel38.ValueLeftPadLength = 0;
            this.hmiLabel38.ValuePrefix = null;
            this.hmiLabel38.ValueScaleFactor = 1D;
            this.hmiLabel38.ValueSuffix = null;
            this.hmiLabel38.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_6
            // 
            this.thnk_rec_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_6.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_6.DisplayAsTime = false;
            this.thnk_rec_6.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_6.Highlight = false;
            this.thnk_rec_6.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_6.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_6.HighlightKeyCharacter = "!";
            this.thnk_rec_6.InterpretValueAsBCD = false;
            this.thnk_rec_6.KeypadAlphaNumeric = false;
            this.thnk_rec_6.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_6.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_6.KeypadMaxValue = 0D;
            this.thnk_rec_6.KeypadMinValue = 0D;
            this.thnk_rec_6.KeypadScaleFactor = 1D;
            this.thnk_rec_6.KeypadShowCurrentValue = false;
            this.thnk_rec_6.KeypadText = null;
            this.thnk_rec_6.KeypadWidth = 400;
            this.thnk_rec_6.Location = new System.Drawing.Point(10, 36);
            this.thnk_rec_6.Name = "thnk_rec_6";
            this.thnk_rec_6.NumericFormat = null;
            this.thnk_rec_6.PLCAddressHighlight = "";
            this.thnk_rec_6.PLCAddressKeypad = "";
            this.thnk_rec_6.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:104";
            this.thnk_rec_6.PLCAddressVisible = "";
            this.thnk_rec_6.PollRate = 0;
            this.thnk_rec_6.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_6.TabIndex = 3;
            this.thnk_rec_6.Text = "0";
            this.thnk_rec_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_6.Value = "0";
            this.thnk_rec_6.ValueLeftPadCharacter = ' ';
            this.thnk_rec_6.ValueLeftPadLength = 0;
            this.thnk_rec_6.ValuePrefix = null;
            this.thnk_rec_6.ValueScaleFactor = 1D;
            this.thnk_rec_6.ValueSuffix = null;
            this.thnk_rec_6.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_6
            // 
            this.thnk_set_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_6.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_6.DisplayAsTime = false;
            this.thnk_set_6.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_6.Highlight = false;
            this.thnk_set_6.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_6.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_6.HighlightKeyCharacter = "!";
            this.thnk_set_6.InterpretValueAsBCD = false;
            this.thnk_set_6.KeypadAlphaNumeric = false;
            this.thnk_set_6.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_6.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_6.KeypadMaxValue = 0D;
            this.thnk_set_6.KeypadMinValue = 0D;
            this.thnk_set_6.KeypadScaleFactor = 1D;
            this.thnk_set_6.KeypadShowCurrentValue = false;
            this.thnk_set_6.KeypadText = null;
            this.thnk_set_6.KeypadWidth = 400;
            this.thnk_set_6.Location = new System.Drawing.Point(10, 11);
            this.thnk_set_6.Name = "thnk_set_6";
            this.thnk_set_6.NumericFormat = null;
            this.thnk_set_6.PLCAddressHighlight = "";
            this.thnk_set_6.PLCAddressKeypad = "";
            this.thnk_set_6.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00022";
            this.thnk_set_6.PLCAddressVisible = "";
            this.thnk_set_6.PollRate = 0;
            this.thnk_set_6.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_6.TabIndex = 2;
            this.thnk_set_6.Text = "0";
            this.thnk_set_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_6.Value = "0";
            this.thnk_set_6.ValueLeftPadCharacter = ' ';
            this.thnk_set_6.ValueLeftPadLength = 0;
            this.thnk_set_6.ValuePrefix = null;
            this.thnk_set_6.ValueScaleFactor = 1D;
            this.thnk_set_6.ValueSuffix = null;
            this.thnk_set_6.ValueToSubtractFrom = 0F;
            // 
            // Panel11
            // 
            this.Panel11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel11.BackgroundImage")));
            this.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel11.Controls.Add(this.hmiLabel35);
            this.Panel11.Controls.Add(this.hmiLabel36);
            this.Panel11.Controls.Add(this.thnk_rec_5);
            this.Panel11.Controls.Add(this.thnk_set_5);
            this.Panel11.Location = new System.Drawing.Point(910, 111);
            this.Panel11.Name = "Panel11";
            this.Panel11.Size = new System.Drawing.Size(68, 114);
            this.Panel11.TabIndex = 482;
            // 
            // hmiLabel35
            // 
            this.hmiLabel35.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel35.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel35.DisplayAsTime = false;
            this.hmiLabel35.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel35.Highlight = false;
            this.hmiLabel35.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel35.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel35.HighlightKeyCharacter = "!";
            this.hmiLabel35.InterpretValueAsBCD = false;
            this.hmiLabel35.KeypadAlphaNumeric = false;
            this.hmiLabel35.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel35.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel35.KeypadMaxValue = 0D;
            this.hmiLabel35.KeypadMinValue = 0D;
            this.hmiLabel35.KeypadScaleFactor = 1D;
            this.hmiLabel35.KeypadShowCurrentValue = false;
            this.hmiLabel35.KeypadText = null;
            this.hmiLabel35.KeypadWidth = 400;
            this.hmiLabel35.Location = new System.Drawing.Point(23, 88);
            this.hmiLabel35.Name = "hmiLabel35";
            this.hmiLabel35.NumericFormat = null;
            this.hmiLabel35.PLCAddressHighlight = "";
            this.hmiLabel35.PLCAddressKeypad = "";
            this.hmiLabel35.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:80";
            this.hmiLabel35.PLCAddressVisible = "";
            this.hmiLabel35.PollRate = 0;
            this.hmiLabel35.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel35.TabIndex = 5;
            this.hmiLabel35.Text = "0";
            this.hmiLabel35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel35.Value = "0";
            this.hmiLabel35.ValueLeftPadCharacter = ' ';
            this.hmiLabel35.ValueLeftPadLength = 0;
            this.hmiLabel35.ValuePrefix = null;
            this.hmiLabel35.ValueScaleFactor = 1D;
            this.hmiLabel35.ValueSuffix = null;
            this.hmiLabel35.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel36
            // 
            this.hmiLabel36.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel36.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel36.DisplayAsTime = false;
            this.hmiLabel36.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel36.Highlight = false;
            this.hmiLabel36.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel36.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel36.HighlightKeyCharacter = "!";
            this.hmiLabel36.InterpretValueAsBCD = false;
            this.hmiLabel36.KeypadAlphaNumeric = false;
            this.hmiLabel36.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel36.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel36.KeypadMaxValue = 0D;
            this.hmiLabel36.KeypadMinValue = 0D;
            this.hmiLabel36.KeypadScaleFactor = 1D;
            this.hmiLabel36.KeypadShowCurrentValue = false;
            this.hmiLabel36.KeypadText = null;
            this.hmiLabel36.KeypadWidth = 400;
            this.hmiLabel36.Location = new System.Drawing.Point(24, 64);
            this.hmiLabel36.Name = "hmiLabel36";
            this.hmiLabel36.NumericFormat = null;
            this.hmiLabel36.PLCAddressHighlight = "";
            this.hmiLabel36.PLCAddressKeypad = "";
            this.hmiLabel36.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:20";
            this.hmiLabel36.PLCAddressVisible = "";
            this.hmiLabel36.PollRate = 0;
            this.hmiLabel36.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel36.TabIndex = 4;
            this.hmiLabel36.Text = "0";
            this.hmiLabel36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel36.Value = "0";
            this.hmiLabel36.ValueLeftPadCharacter = ' ';
            this.hmiLabel36.ValueLeftPadLength = 0;
            this.hmiLabel36.ValuePrefix = null;
            this.hmiLabel36.ValueScaleFactor = 1D;
            this.hmiLabel36.ValueSuffix = null;
            this.hmiLabel36.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_5
            // 
            this.thnk_rec_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_5.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_5.DisplayAsTime = false;
            this.thnk_rec_5.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_5.Highlight = false;
            this.thnk_rec_5.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_5.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_5.HighlightKeyCharacter = "!";
            this.thnk_rec_5.InterpretValueAsBCD = false;
            this.thnk_rec_5.KeypadAlphaNumeric = false;
            this.thnk_rec_5.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_5.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_5.KeypadMaxValue = 0D;
            this.thnk_rec_5.KeypadMinValue = 0D;
            this.thnk_rec_5.KeypadScaleFactor = 1D;
            this.thnk_rec_5.KeypadShowCurrentValue = false;
            this.thnk_rec_5.KeypadText = null;
            this.thnk_rec_5.KeypadWidth = 400;
            this.thnk_rec_5.Location = new System.Drawing.Point(7, 36);
            this.thnk_rec_5.Name = "thnk_rec_5";
            this.thnk_rec_5.NumericFormat = null;
            this.thnk_rec_5.PLCAddressHighlight = "";
            this.thnk_rec_5.PLCAddressKeypad = "";
            this.thnk_rec_5.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:102";
            this.thnk_rec_5.PLCAddressVisible = "";
            this.thnk_rec_5.PollRate = 0;
            this.thnk_rec_5.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_5.TabIndex = 3;
            this.thnk_rec_5.Text = "0";
            this.thnk_rec_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_5.Value = "0";
            this.thnk_rec_5.ValueLeftPadCharacter = ' ';
            this.thnk_rec_5.ValueLeftPadLength = 0;
            this.thnk_rec_5.ValuePrefix = null;
            this.thnk_rec_5.ValueScaleFactor = 1D;
            this.thnk_rec_5.ValueSuffix = null;
            this.thnk_rec_5.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_5
            // 
            this.thnk_set_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_5.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_5.DisplayAsTime = false;
            this.thnk_set_5.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_5.Highlight = false;
            this.thnk_set_5.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_5.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_5.HighlightKeyCharacter = "!";
            this.thnk_set_5.InterpretValueAsBCD = false;
            this.thnk_set_5.KeypadAlphaNumeric = false;
            this.thnk_set_5.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_5.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_5.KeypadMaxValue = 0D;
            this.thnk_set_5.KeypadMinValue = 0D;
            this.thnk_set_5.KeypadScaleFactor = 1D;
            this.thnk_set_5.KeypadShowCurrentValue = false;
            this.thnk_set_5.KeypadText = null;
            this.thnk_set_5.KeypadWidth = 400;
            this.thnk_set_5.Location = new System.Drawing.Point(7, 11);
            this.thnk_set_5.Name = "thnk_set_5";
            this.thnk_set_5.NumericFormat = null;
            this.thnk_set_5.PLCAddressHighlight = "";
            this.thnk_set_5.PLCAddressKeypad = "";
            this.thnk_set_5.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00021";
            this.thnk_set_5.PLCAddressVisible = "";
            this.thnk_set_5.PollRate = 0;
            this.thnk_set_5.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_5.TabIndex = 2;
            this.thnk_set_5.Text = "0";
            this.thnk_set_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_5.Value = "0";
            this.thnk_set_5.ValueLeftPadCharacter = ' ';
            this.thnk_set_5.ValueLeftPadLength = 0;
            this.thnk_set_5.ValuePrefix = null;
            this.thnk_set_5.ValueScaleFactor = 1D;
            this.thnk_set_5.ValueSuffix = null;
            this.thnk_set_5.ValueToSubtractFrom = 0F;
            // 
            // Panel7
            // 
            this.Panel7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel7.BackgroundImage")));
            this.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel7.Controls.Add(this.hmiLabel31);
            this.Panel7.Controls.Add(this.hmiLabel32);
            this.Panel7.Controls.Add(this.thnk_rec_3);
            this.Panel7.Controls.Add(this.thnk_set_3);
            this.Panel7.Location = new System.Drawing.Point(1047, 111);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(68, 114);
            this.Panel7.TabIndex = 479;
            // 
            // hmiLabel31
            // 
            this.hmiLabel31.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel31.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel31.DisplayAsTime = false;
            this.hmiLabel31.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel31.Highlight = false;
            this.hmiLabel31.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel31.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel31.HighlightKeyCharacter = "!";
            this.hmiLabel31.InterpretValueAsBCD = false;
            this.hmiLabel31.KeypadAlphaNumeric = false;
            this.hmiLabel31.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel31.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel31.KeypadMaxValue = 0D;
            this.hmiLabel31.KeypadMinValue = 0D;
            this.hmiLabel31.KeypadScaleFactor = 1D;
            this.hmiLabel31.KeypadShowCurrentValue = false;
            this.hmiLabel31.KeypadText = null;
            this.hmiLabel31.KeypadWidth = 400;
            this.hmiLabel31.Location = new System.Drawing.Point(23, 88);
            this.hmiLabel31.Name = "hmiLabel31";
            this.hmiLabel31.NumericFormat = null;
            this.hmiLabel31.PLCAddressHighlight = "";
            this.hmiLabel31.PLCAddressKeypad = "";
            this.hmiLabel31.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:76";
            this.hmiLabel31.PLCAddressVisible = "";
            this.hmiLabel31.PollRate = 0;
            this.hmiLabel31.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel31.TabIndex = 5;
            this.hmiLabel31.Text = "0";
            this.hmiLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel31.Value = "0";
            this.hmiLabel31.ValueLeftPadCharacter = ' ';
            this.hmiLabel31.ValueLeftPadLength = 0;
            this.hmiLabel31.ValuePrefix = null;
            this.hmiLabel31.ValueScaleFactor = 1D;
            this.hmiLabel31.ValueSuffix = null;
            this.hmiLabel31.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel32
            // 
            this.hmiLabel32.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel32.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel32.DisplayAsTime = false;
            this.hmiLabel32.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel32.Highlight = false;
            this.hmiLabel32.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel32.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel32.HighlightKeyCharacter = "!";
            this.hmiLabel32.InterpretValueAsBCD = false;
            this.hmiLabel32.KeypadAlphaNumeric = false;
            this.hmiLabel32.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel32.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel32.KeypadMaxValue = 0D;
            this.hmiLabel32.KeypadMinValue = 0D;
            this.hmiLabel32.KeypadScaleFactor = 1D;
            this.hmiLabel32.KeypadShowCurrentValue = false;
            this.hmiLabel32.KeypadText = null;
            this.hmiLabel32.KeypadWidth = 400;
            this.hmiLabel32.Location = new System.Drawing.Point(24, 64);
            this.hmiLabel32.Name = "hmiLabel32";
            this.hmiLabel32.NumericFormat = null;
            this.hmiLabel32.PLCAddressHighlight = "";
            this.hmiLabel32.PLCAddressKeypad = "";
            this.hmiLabel32.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:12";
            this.hmiLabel32.PLCAddressVisible = "";
            this.hmiLabel32.PollRate = 0;
            this.hmiLabel32.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel32.TabIndex = 4;
            this.hmiLabel32.Text = "0";
            this.hmiLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel32.Value = "0";
            this.hmiLabel32.ValueLeftPadCharacter = ' ';
            this.hmiLabel32.ValueLeftPadLength = 0;
            this.hmiLabel32.ValuePrefix = null;
            this.hmiLabel32.ValueScaleFactor = 1D;
            this.hmiLabel32.ValueSuffix = null;
            this.hmiLabel32.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_3
            // 
            this.thnk_rec_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_3.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_3.DisplayAsTime = false;
            this.thnk_rec_3.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_3.Highlight = false;
            this.thnk_rec_3.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_3.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_3.HighlightKeyCharacter = "!";
            this.thnk_rec_3.InterpretValueAsBCD = false;
            this.thnk_rec_3.KeypadAlphaNumeric = false;
            this.thnk_rec_3.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_3.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_3.KeypadMaxValue = 0D;
            this.thnk_rec_3.KeypadMinValue = 0D;
            this.thnk_rec_3.KeypadScaleFactor = 1D;
            this.thnk_rec_3.KeypadShowCurrentValue = false;
            this.thnk_rec_3.KeypadText = null;
            this.thnk_rec_3.KeypadWidth = 400;
            this.thnk_rec_3.Location = new System.Drawing.Point(9, 36);
            this.thnk_rec_3.Name = "thnk_rec_3";
            this.thnk_rec_3.NumericFormat = null;
            this.thnk_rec_3.PLCAddressHighlight = "";
            this.thnk_rec_3.PLCAddressKeypad = "";
            this.thnk_rec_3.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:98";
            this.thnk_rec_3.PLCAddressVisible = "";
            this.thnk_rec_3.PollRate = 0;
            this.thnk_rec_3.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_3.TabIndex = 3;
            this.thnk_rec_3.Text = "0";
            this.thnk_rec_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_3.Value = "0";
            this.thnk_rec_3.ValueLeftPadCharacter = ' ';
            this.thnk_rec_3.ValueLeftPadLength = 0;
            this.thnk_rec_3.ValuePrefix = null;
            this.thnk_rec_3.ValueScaleFactor = 1D;
            this.thnk_rec_3.ValueSuffix = null;
            this.thnk_rec_3.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_3
            // 
            this.thnk_set_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_3.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_3.DisplayAsTime = false;
            this.thnk_set_3.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_3.Highlight = false;
            this.thnk_set_3.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_3.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_3.HighlightKeyCharacter = "!";
            this.thnk_set_3.InterpretValueAsBCD = false;
            this.thnk_set_3.KeypadAlphaNumeric = false;
            this.thnk_set_3.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_3.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_3.KeypadMaxValue = 0D;
            this.thnk_set_3.KeypadMinValue = 0D;
            this.thnk_set_3.KeypadScaleFactor = 1D;
            this.thnk_set_3.KeypadShowCurrentValue = false;
            this.thnk_set_3.KeypadText = null;
            this.thnk_set_3.KeypadWidth = 400;
            this.thnk_set_3.Location = new System.Drawing.Point(9, 11);
            this.thnk_set_3.Name = "thnk_set_3";
            this.thnk_set_3.NumericFormat = null;
            this.thnk_set_3.PLCAddressHighlight = "";
            this.thnk_set_3.PLCAddressKeypad = "";
            this.thnk_set_3.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00019";
            this.thnk_set_3.PLCAddressVisible = "";
            this.thnk_set_3.PollRate = 0;
            this.thnk_set_3.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_3.TabIndex = 2;
            this.thnk_set_3.Text = "0";
            this.thnk_set_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_3.Value = "0";
            this.thnk_set_3.ValueLeftPadCharacter = ' ';
            this.thnk_set_3.ValueLeftPadLength = 0;
            this.thnk_set_3.ValuePrefix = null;
            this.thnk_set_3.ValueScaleFactor = 1D;
            this.thnk_set_3.ValueSuffix = null;
            this.thnk_set_3.ValueToSubtractFrom = 0F;
            // 
            // Panel10
            // 
            this.Panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel10.BackgroundImage")));
            this.Panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel10.Controls.Add(this.hmiLabel28);
            this.Panel10.Controls.Add(this.hmiLabel27);
            this.Panel10.Controls.Add(this.thnk_rec_1);
            this.Panel10.Controls.Add(this.thnk_set_1);
            this.Panel10.Location = new System.Drawing.Point(1185, 111);
            this.Panel10.Name = "Panel10";
            this.Panel10.Size = new System.Drawing.Size(68, 114);
            this.Panel10.TabIndex = 477;
            // 
            // hmiLabel28
            // 
            this.hmiLabel28.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel28.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel28.DisplayAsTime = false;
            this.hmiLabel28.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel28.Highlight = false;
            this.hmiLabel28.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel28.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel28.HighlightKeyCharacter = "!";
            this.hmiLabel28.InterpretValueAsBCD = false;
            this.hmiLabel28.KeypadAlphaNumeric = false;
            this.hmiLabel28.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel28.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel28.KeypadMaxValue = 0D;
            this.hmiLabel28.KeypadMinValue = 0D;
            this.hmiLabel28.KeypadScaleFactor = 1D;
            this.hmiLabel28.KeypadShowCurrentValue = false;
            this.hmiLabel28.KeypadText = null;
            this.hmiLabel28.KeypadWidth = 400;
            this.hmiLabel28.Location = new System.Drawing.Point(23, 88);
            this.hmiLabel28.Name = "hmiLabel28";
            this.hmiLabel28.NumericFormat = null;
            this.hmiLabel28.PLCAddressHighlight = "";
            this.hmiLabel28.PLCAddressKeypad = "";
            this.hmiLabel28.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:72";
            this.hmiLabel28.PLCAddressVisible = "";
            this.hmiLabel28.PollRate = 0;
            this.hmiLabel28.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel28.TabIndex = 3;
            this.hmiLabel28.Text = "0";
            this.hmiLabel28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel28.Value = "0";
            this.hmiLabel28.ValueLeftPadCharacter = ' ';
            this.hmiLabel28.ValueLeftPadLength = 0;
            this.hmiLabel28.ValuePrefix = null;
            this.hmiLabel28.ValueScaleFactor = 1D;
            this.hmiLabel28.ValueSuffix = null;
            this.hmiLabel28.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel27
            // 
            this.hmiLabel27.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel27.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel27.DisplayAsTime = false;
            this.hmiLabel27.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel27.Highlight = false;
            this.hmiLabel27.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel27.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel27.HighlightKeyCharacter = "!";
            this.hmiLabel27.InterpretValueAsBCD = false;
            this.hmiLabel27.KeypadAlphaNumeric = false;
            this.hmiLabel27.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel27.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel27.KeypadMaxValue = 0D;
            this.hmiLabel27.KeypadMinValue = 0D;
            this.hmiLabel27.KeypadScaleFactor = 1D;
            this.hmiLabel27.KeypadShowCurrentValue = false;
            this.hmiLabel27.KeypadText = null;
            this.hmiLabel27.KeypadWidth = 400;
            this.hmiLabel27.Location = new System.Drawing.Point(24, 64);
            this.hmiLabel27.Name = "hmiLabel27";
            this.hmiLabel27.NumericFormat = null;
            this.hmiLabel27.PLCAddressHighlight = "";
            this.hmiLabel27.PLCAddressKeypad = "";
            this.hmiLabel27.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:8";
            this.hmiLabel27.PLCAddressVisible = "";
            this.hmiLabel27.PollRate = 0;
            this.hmiLabel27.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel27.TabIndex = 2;
            this.hmiLabel27.Text = "0";
            this.hmiLabel27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel27.Value = "0";
            this.hmiLabel27.ValueLeftPadCharacter = ' ';
            this.hmiLabel27.ValueLeftPadLength = 0;
            this.hmiLabel27.ValuePrefix = null;
            this.hmiLabel27.ValueScaleFactor = 1D;
            this.hmiLabel27.ValueSuffix = null;
            this.hmiLabel27.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_1
            // 
            this.thnk_rec_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_1.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_1.DisplayAsTime = false;
            this.thnk_rec_1.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_1.Highlight = false;
            this.thnk_rec_1.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_1.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_1.HighlightKeyCharacter = "!";
            this.thnk_rec_1.InterpretValueAsBCD = false;
            this.thnk_rec_1.KeypadAlphaNumeric = false;
            this.thnk_rec_1.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_1.KeypadMaxValue = 0D;
            this.thnk_rec_1.KeypadMinValue = 0D;
            this.thnk_rec_1.KeypadScaleFactor = 1D;
            this.thnk_rec_1.KeypadShowCurrentValue = false;
            this.thnk_rec_1.KeypadText = null;
            this.thnk_rec_1.KeypadWidth = 400;
            this.thnk_rec_1.Location = new System.Drawing.Point(10, 36);
            this.thnk_rec_1.Name = "thnk_rec_1";
            this.thnk_rec_1.NumericFormat = null;
            this.thnk_rec_1.PLCAddressHighlight = "";
            this.thnk_rec_1.PLCAddressKeypad = "";
            this.thnk_rec_1.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:94";
            this.thnk_rec_1.PLCAddressVisible = "";
            this.thnk_rec_1.PollRate = 0;
            this.thnk_rec_1.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_1.TabIndex = 1;
            this.thnk_rec_1.Text = "0";
            this.thnk_rec_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_1.Value = "0";
            this.thnk_rec_1.ValueLeftPadCharacter = ' ';
            this.thnk_rec_1.ValueLeftPadLength = 0;
            this.thnk_rec_1.ValuePrefix = null;
            this.thnk_rec_1.ValueScaleFactor = 1D;
            this.thnk_rec_1.ValueSuffix = null;
            this.thnk_rec_1.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_1
            // 
            this.thnk_set_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_1.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_1.DisplayAsTime = false;
            this.thnk_set_1.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_1.Highlight = false;
            this.thnk_set_1.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_1.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_1.HighlightKeyCharacter = "!";
            this.thnk_set_1.InterpretValueAsBCD = false;
            this.thnk_set_1.KeypadAlphaNumeric = false;
            this.thnk_set_1.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_1.KeypadMaxValue = 0D;
            this.thnk_set_1.KeypadMinValue = 0D;
            this.thnk_set_1.KeypadScaleFactor = 1D;
            this.thnk_set_1.KeypadShowCurrentValue = false;
            this.thnk_set_1.KeypadText = null;
            this.thnk_set_1.KeypadWidth = 400;
            this.thnk_set_1.Location = new System.Drawing.Point(10, 11);
            this.thnk_set_1.Name = "thnk_set_1";
            this.thnk_set_1.NumericFormat = null;
            this.thnk_set_1.PLCAddressHighlight = "";
            this.thnk_set_1.PLCAddressKeypad = "";
            this.thnk_set_1.PLCAddressValue = "CH1.PLC1.DataBlock1.TAG00001";
            this.thnk_set_1.PLCAddressVisible = "";
            this.thnk_set_1.PollRate = 0;
            this.thnk_set_1.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_1.TabIndex = 0;
            this.thnk_set_1.Text = "0";
            this.thnk_set_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_1.Value = "0";
            this.thnk_set_1.ValueLeftPadCharacter = ' ';
            this.thnk_set_1.ValueLeftPadLength = 0;
            this.thnk_set_1.ValuePrefix = null;
            this.thnk_set_1.ValueScaleFactor = 1D;
            this.thnk_set_1.ValueSuffix = null;
            this.thnk_set_1.ValueToSubtractFrom = 0F;
            // 
            // Panel20
            // 
            this.Panel20.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel20.BackgroundImage")));
            this.Panel20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel20.Controls.Add(this.hmiLabel29);
            this.Panel20.Controls.Add(this.hmiLabel30);
            this.Panel20.Controls.Add(this.thnk_rec_2);
            this.Panel20.Controls.Add(this.thnk_set_2);
            this.Panel20.Location = new System.Drawing.Point(1116, 111);
            this.Panel20.Name = "Panel20";
            this.Panel20.Size = new System.Drawing.Size(68, 114);
            this.Panel20.TabIndex = 500;
            // 
            // hmiLabel29
            // 
            this.hmiLabel29.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel29.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel29.DisplayAsTime = false;
            this.hmiLabel29.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel29.Highlight = false;
            this.hmiLabel29.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel29.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel29.HighlightKeyCharacter = "!";
            this.hmiLabel29.InterpretValueAsBCD = false;
            this.hmiLabel29.KeypadAlphaNumeric = false;
            this.hmiLabel29.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel29.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel29.KeypadMaxValue = 0D;
            this.hmiLabel29.KeypadMinValue = 0D;
            this.hmiLabel29.KeypadScaleFactor = 1D;
            this.hmiLabel29.KeypadShowCurrentValue = false;
            this.hmiLabel29.KeypadText = null;
            this.hmiLabel29.KeypadWidth = 400;
            this.hmiLabel29.Location = new System.Drawing.Point(23, 88);
            this.hmiLabel29.Name = "hmiLabel29";
            this.hmiLabel29.NumericFormat = null;
            this.hmiLabel29.PLCAddressHighlight = "";
            this.hmiLabel29.PLCAddressKeypad = "";
            this.hmiLabel29.PLCAddressValue = "TEST.PLC.StartAddress22.StartAddress22:74";
            this.hmiLabel29.PLCAddressVisible = "";
            this.hmiLabel29.PollRate = 0;
            this.hmiLabel29.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel29.TabIndex = 5;
            this.hmiLabel29.Text = "0";
            this.hmiLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel29.Value = "0";
            this.hmiLabel29.ValueLeftPadCharacter = ' ';
            this.hmiLabel29.ValueLeftPadLength = 0;
            this.hmiLabel29.ValuePrefix = null;
            this.hmiLabel29.ValueScaleFactor = 1D;
            this.hmiLabel29.ValueSuffix = null;
            this.hmiLabel29.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel30
            // 
            this.hmiLabel30.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel30.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel30.DisplayAsTime = false;
            this.hmiLabel30.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel30.Highlight = false;
            this.hmiLabel30.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel30.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel30.HighlightKeyCharacter = "!";
            this.hmiLabel30.InterpretValueAsBCD = false;
            this.hmiLabel30.KeypadAlphaNumeric = false;
            this.hmiLabel30.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel30.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel30.KeypadMaxValue = 0D;
            this.hmiLabel30.KeypadMinValue = 0D;
            this.hmiLabel30.KeypadScaleFactor = 1D;
            this.hmiLabel30.KeypadShowCurrentValue = false;
            this.hmiLabel30.KeypadText = null;
            this.hmiLabel30.KeypadWidth = 400;
            this.hmiLabel30.Location = new System.Drawing.Point(24, 64);
            this.hmiLabel30.Name = "hmiLabel30";
            this.hmiLabel30.NumericFormat = null;
            this.hmiLabel30.PLCAddressHighlight = "";
            this.hmiLabel30.PLCAddressKeypad = "";
            this.hmiLabel30.PLCAddressValue = "TEST.PLC.StartAddressTimer0.StartAddressTimer0:10";
            this.hmiLabel30.PLCAddressVisible = "";
            this.hmiLabel30.PollRate = 0;
            this.hmiLabel30.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel30.TabIndex = 4;
            this.hmiLabel30.Text = "0";
            this.hmiLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel30.Value = "0";
            this.hmiLabel30.ValueLeftPadCharacter = ' ';
            this.hmiLabel30.ValueLeftPadLength = 0;
            this.hmiLabel30.ValuePrefix = null;
            this.hmiLabel30.ValueScaleFactor = 1D;
            this.hmiLabel30.ValueSuffix = null;
            this.hmiLabel30.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_2
            // 
            this.thnk_rec_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_2.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_2.DisplayAsTime = false;
            this.thnk_rec_2.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_2.Highlight = false;
            this.thnk_rec_2.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_2.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_2.HighlightKeyCharacter = "!";
            this.thnk_rec_2.InterpretValueAsBCD = false;
            this.thnk_rec_2.KeypadAlphaNumeric = false;
            this.thnk_rec_2.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_2.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_2.KeypadMaxValue = 0D;
            this.thnk_rec_2.KeypadMinValue = 0D;
            this.thnk_rec_2.KeypadScaleFactor = 1D;
            this.thnk_rec_2.KeypadShowCurrentValue = false;
            this.thnk_rec_2.KeypadText = null;
            this.thnk_rec_2.KeypadWidth = 400;
            this.thnk_rec_2.Location = new System.Drawing.Point(9, 36);
            this.thnk_rec_2.Name = "thnk_rec_2";
            this.thnk_rec_2.NumericFormat = null;
            this.thnk_rec_2.PLCAddressHighlight = "";
            this.thnk_rec_2.PLCAddressKeypad = "";
            this.thnk_rec_2.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:96";
            this.thnk_rec_2.PLCAddressVisible = "";
            this.thnk_rec_2.PollRate = 0;
            this.thnk_rec_2.Size = new System.Drawing.Size(51, 19);
            this.thnk_rec_2.TabIndex = 3;
            this.thnk_rec_2.Text = "0";
            this.thnk_rec_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_2.Value = "0";
            this.thnk_rec_2.ValueLeftPadCharacter = ' ';
            this.thnk_rec_2.ValueLeftPadLength = 0;
            this.thnk_rec_2.ValuePrefix = null;
            this.thnk_rec_2.ValueScaleFactor = 1D;
            this.thnk_rec_2.ValueSuffix = null;
            this.thnk_rec_2.ValueToSubtractFrom = 0F;
            // 
            // thnk_set_2
            // 
            this.thnk_set_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.thnk_set_2.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_set_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_set_2.DisplayAsTime = false;
            this.thnk_set_2.ForeColor = System.Drawing.Color.Black;
            this.thnk_set_2.Highlight = false;
            this.thnk_set_2.HighlightColor = System.Drawing.Color.Red;
            this.thnk_set_2.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_set_2.HighlightKeyCharacter = "!";
            this.thnk_set_2.InterpretValueAsBCD = false;
            this.thnk_set_2.KeypadAlphaNumeric = false;
            this.thnk_set_2.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_set_2.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_set_2.KeypadMaxValue = 0D;
            this.thnk_set_2.KeypadMinValue = 0D;
            this.thnk_set_2.KeypadScaleFactor = 1D;
            this.thnk_set_2.KeypadShowCurrentValue = false;
            this.thnk_set_2.KeypadText = null;
            this.thnk_set_2.KeypadWidth = 400;
            this.thnk_set_2.Location = new System.Drawing.Point(9, 11);
            this.thnk_set_2.Name = "thnk_set_2";
            this.thnk_set_2.NumericFormat = null;
            this.thnk_set_2.PLCAddressHighlight = "";
            this.thnk_set_2.PLCAddressKeypad = "";
            this.thnk_set_2.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00018";
            this.thnk_set_2.PLCAddressVisible = "";
            this.thnk_set_2.PollRate = 0;
            this.thnk_set_2.Size = new System.Drawing.Size(51, 19);
            this.thnk_set_2.TabIndex = 2;
            this.thnk_set_2.Text = "0";
            this.thnk_set_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_set_2.Value = "0";
            this.thnk_set_2.ValueLeftPadCharacter = ' ';
            this.thnk_set_2.ValueLeftPadLength = 0;
            this.thnk_set_2.ValuePrefix = null;
            this.thnk_set_2.ValueScaleFactor = 1D;
            this.thnk_set_2.ValueSuffix = null;
            this.thnk_set_2.ValueToSubtractFrom = 0F;
            // 
            // Panel2
            // 
            this.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.Micro_flowmeter;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.hmiLabel25);
            this.Panel2.Controls.Add(this.hmiSevenSegment1);
            this.Panel2.Controls.Add(this.msg_thnk);
            this.Panel2.Location = new System.Drawing.Point(724, 265);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(543, 157);
            this.Panel2.TabIndex = 502;
            // 
            // hmiLabel25
            // 
            this.hmiLabel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.hmiLabel25.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel25.DisplayAsTime = false;
            this.hmiLabel25.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel25.Highlight = false;
            this.hmiLabel25.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel25.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel25.HighlightKeyCharacter = "!";
            this.hmiLabel25.InterpretValueAsBCD = false;
            this.hmiLabel25.KeypadAlphaNumeric = false;
            this.hmiLabel25.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel25.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel25.KeypadMaxValue = 0D;
            this.hmiLabel25.KeypadMinValue = 0D;
            this.hmiLabel25.KeypadScaleFactor = 1D;
            this.hmiLabel25.KeypadShowCurrentValue = false;
            this.hmiLabel25.KeypadText = null;
            this.hmiLabel25.KeypadWidth = 400;
            this.hmiLabel25.Location = new System.Drawing.Point(9, 12);
            this.hmiLabel25.Name = "hmiLabel25";
            this.hmiLabel25.NumericFormat = null;
            this.hmiLabel25.PLCAddressHighlight = "";
            this.hmiLabel25.PLCAddressKeypad = "";
            this.hmiLabel25.PLCAddressValue = "TEST.PLC.DW.DW3";
            this.hmiLabel25.PLCAddressVisible = "";
            this.hmiLabel25.PollRate = 0;
            this.hmiLabel25.Size = new System.Drawing.Size(51, 19);
            this.hmiLabel25.TabIndex = 8;
            this.hmiLabel25.Text = "0";
            this.hmiLabel25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel25.Value = "0";
            this.hmiLabel25.ValueLeftPadCharacter = ' ';
            this.hmiLabel25.ValueLeftPadLength = 0;
            this.hmiLabel25.ValuePrefix = null;
            this.hmiLabel25.ValueScaleFactor = 1D;
            this.hmiLabel25.ValueSuffix = null;
            this.hmiLabel25.ValueToSubtractFrom = 0F;
            // 
            // hmiSevenSegment1
            // 
            this.hmiSevenSegment1.BackColor = System.Drawing.Color.Transparent;
            this.hmiSevenSegment1.DecimalPosition = 0;
            this.hmiSevenSegment1.ForecolorHighLimitValue = 999999D;
            this.hmiSevenSegment1.ForeColorInLimits = System.Drawing.Color.Blue;
            this.hmiSevenSegment1.ForecolorLowLimitValue = -999999D;
            this.hmiSevenSegment1.ForeColorOverHighLimit = System.Drawing.Color.Red;
            this.hmiSevenSegment1.ForeColorUnderLowLimit = System.Drawing.Color.Yellow;
            this.hmiSevenSegment1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiSevenSegment1.KeypadMaxValue = 0D;
            this.hmiSevenSegment1.KeypadMinValue = 0D;
            this.hmiSevenSegment1.KeypadScaleFactor = 1D;
            this.hmiSevenSegment1.KeypadText = null;
            this.hmiSevenSegment1.KeypadWidth = 300;
            this.hmiSevenSegment1.Location = new System.Drawing.Point(84, 15);
            this.hmiSevenSegment1.Name = "hmiSevenSegment1";
            this.hmiSevenSegment1.NumberOfDigits = 5;
            this.hmiSevenSegment1.PLCAddressKeypad = "CH2.PLC1.DataBlock2.TAG00017";
            this.hmiSevenSegment1.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00017";
            this.hmiSevenSegment1.PLCAddressVisible = "";
            this.hmiSevenSegment1.ResolutionOfLastDigit = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiSevenSegment1.ShowOffSegments = true;
            this.hmiSevenSegment1.Size = new System.Drawing.Size(397, 103);
            this.hmiSevenSegment1.TabIndex = 7;
            this.hmiSevenSegment1.Text = "hmiSevenSegment1";
            this.hmiSevenSegment1.Value = 0D;
            // 
            // msg_thnk
            // 
            this.msg_thnk.BackColor = System.Drawing.Color.Transparent;
            this.msg_thnk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msg_thnk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_thnk.ForeColor = System.Drawing.Color.Green;
            this.msg_thnk.Location = new System.Drawing.Point(124, 130);
            this.msg_thnk.Name = "msg_thnk";
            this.msg_thnk.Size = new System.Drawing.Size(305, 26);
            this.msg_thnk.TabIndex = 6;
            this.msg_thnk.Text = "تانك الاول يعمل";
            this.msg_thnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel21
            // 
            this.Panel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Panel21.BackColor = System.Drawing.Color.Transparent;
            this.Panel21.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.Sanitary_inline_mixer;
            this.Panel21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel21.Controls.Add(this.hmiSimpleLED1);
            this.Panel21.Controls.Add(this.hmiIndicator2);
            this.Panel21.Controls.Add(this.hmiLabel23);
            this.Panel21.Controls.Add(this.hmiLabel24);
            this.Panel21.Controls.Add(this.hmiLabel21);
            this.Panel21.Controls.Add(this.hmiLabel22);
            this.Panel21.Controls.Add(this.Label4);
            this.Panel21.Controls.Add(this.Label24);
            this.Panel21.Controls.Add(this.Label23);
            this.Panel21.Controls.Add(this.Label22);
            this.Panel21.Controls.Add(this.Label18);
            this.Panel21.Location = new System.Drawing.Point(2, 529);
            this.Panel21.Name = "Panel21";
            this.Panel21.Size = new System.Drawing.Size(548, 181);
            this.Panel21.TabIndex = 503;
            // 
            // hmiSimpleLED1
            // 
            this.hmiSimpleLED1.BackColor = System.Drawing.Color.Transparent;
            this.hmiSimpleLED1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hmiSimpleLED1.Location = new System.Drawing.Point(506, 140);
            this.hmiSimpleLED1.MaximumHoldTime = 3000;
            this.hmiSimpleLED1.MaximumSize = new System.Drawing.Size(360, 360);
            this.hmiSimpleLED1.MinimumHoldTime = 500;
            this.hmiSimpleLED1.MinimumSize = new System.Drawing.Size(27, 27);
            this.hmiSimpleLED1.Name = "hmiSimpleLED1";
            this.hmiSimpleLED1.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiSimpleLED1.PLCAddressClick = "";
            this.hmiSimpleLED1.PLCAddressText = "";
            this.hmiSimpleLED1.PLCAddressValue = "";
            this.hmiSimpleLED1.PLCAddressVisible = "";
            this.hmiSimpleLED1.Size = new System.Drawing.Size(27, 27);
            this.hmiSimpleLED1.TabIndex = 518;
            this.hmiSimpleLED1.Text = " ";
            this.hmiSimpleLED1.ValueToWrite = 0;
            // 
            // hmiIndicator2
            // 
            this.hmiIndicator2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hmiIndicator2.Color1 = System.Drawing.Color.Red;
            this.hmiIndicator2.Color2 = System.Drawing.Color.Green;
            this.hmiIndicator2.Color3 = System.Drawing.Color.Red;
            this.hmiIndicator2.Location = new System.Drawing.Point(202, 167);
            this.hmiIndicator2.Name = "hmiIndicator2";
            this.hmiIndicator2.OutlineColor = System.Drawing.Color.Transparent;
            this.hmiIndicator2.OutlineWidth = 1;
            this.hmiIndicator2.PLCAddressClick = "";
            this.hmiIndicator2.PLCAddressText = "";
            this.hmiIndicator2.PLCAddressValue = "";
            this.hmiIndicator2.PLCAddressVisible = "";
            this.hmiIndicator2.SelectColor2 = false;
            this.hmiIndicator2.SelectColor3 = false;
            this.hmiIndicator2.Shape = AdvancedScada.Controls.Controls.HMIIndicator.ShapeTypes.Rectangle;
            this.hmiIndicator2.Size = new System.Drawing.Size(131, 12);
            this.hmiIndicator2.TabIndex = 517;
            this.hmiIndicator2.Text = "hmiIndicator2";
            // 
            // hmiLabel23
            // 
            this.hmiLabel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hmiLabel23.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel23.DisplayAsTime = false;
            this.hmiLabel23.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel23.Highlight = false;
            this.hmiLabel23.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel23.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel23.HighlightKeyCharacter = "!";
            this.hmiLabel23.InterpretValueAsBCD = false;
            this.hmiLabel23.KeypadAlphaNumeric = false;
            this.hmiLabel23.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel23.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel23.KeypadMaxValue = 0D;
            this.hmiLabel23.KeypadMinValue = 0D;
            this.hmiLabel23.KeypadScaleFactor = 1D;
            this.hmiLabel23.KeypadShowCurrentValue = false;
            this.hmiLabel23.KeypadText = null;
            this.hmiLabel23.KeypadWidth = 400;
            this.hmiLabel23.Location = new System.Drawing.Point(230, 108);
            this.hmiLabel23.Name = "hmiLabel23";
            this.hmiLabel23.NumericFormat = null;
            this.hmiLabel23.PLCAddressHighlight = "";
            this.hmiLabel23.PLCAddressKeypad = "";
            this.hmiLabel23.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:122";
            this.hmiLabel23.PLCAddressVisible = "";
            this.hmiLabel23.PollRate = 0;
            this.hmiLabel23.Size = new System.Drawing.Size(51, 19);
            this.hmiLabel23.TabIndex = 493;
            this.hmiLabel23.Text = "0";
            this.hmiLabel23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel23.Value = "0";
            this.hmiLabel23.ValueLeftPadCharacter = ' ';
            this.hmiLabel23.ValueLeftPadLength = 0;
            this.hmiLabel23.ValuePrefix = null;
            this.hmiLabel23.ValueScaleFactor = 1D;
            this.hmiLabel23.ValueSuffix = null;
            this.hmiLabel23.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel24
            // 
            this.hmiLabel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel24.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel24.DisplayAsTime = false;
            this.hmiLabel24.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel24.Highlight = false;
            this.hmiLabel24.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel24.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel24.HighlightKeyCharacter = "!";
            this.hmiLabel24.InterpretValueAsBCD = false;
            this.hmiLabel24.KeypadAlphaNumeric = false;
            this.hmiLabel24.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel24.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel24.KeypadMaxValue = 0D;
            this.hmiLabel24.KeypadMinValue = 0D;
            this.hmiLabel24.KeypadScaleFactor = 1D;
            this.hmiLabel24.KeypadShowCurrentValue = false;
            this.hmiLabel24.KeypadText = null;
            this.hmiLabel24.KeypadWidth = 400;
            this.hmiLabel24.Location = new System.Drawing.Point(230, 83);
            this.hmiLabel24.Name = "hmiLabel24";
            this.hmiLabel24.NumericFormat = null;
            this.hmiLabel24.PLCAddressHighlight = "";
            this.hmiLabel24.PLCAddressKeypad = "";
            this.hmiLabel24.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:116";
            this.hmiLabel24.PLCAddressVisible = "";
            this.hmiLabel24.PollRate = 0;
            this.hmiLabel24.Size = new System.Drawing.Size(51, 19);
            this.hmiLabel24.TabIndex = 492;
            this.hmiLabel24.Text = "0";
            this.hmiLabel24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel24.Value = "0";
            this.hmiLabel24.ValueLeftPadCharacter = ' ';
            this.hmiLabel24.ValueLeftPadLength = 0;
            this.hmiLabel24.ValuePrefix = null;
            this.hmiLabel24.ValueScaleFactor = 1D;
            this.hmiLabel24.ValueSuffix = null;
            this.hmiLabel24.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel21
            // 
            this.hmiLabel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.hmiLabel21.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel21.DisplayAsTime = false;
            this.hmiLabel21.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel21.Highlight = false;
            this.hmiLabel21.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel21.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel21.HighlightKeyCharacter = "!";
            this.hmiLabel21.InterpretValueAsBCD = false;
            this.hmiLabel21.KeypadAlphaNumeric = false;
            this.hmiLabel21.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel21.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel21.KeypadMaxValue = 0D;
            this.hmiLabel21.KeypadMinValue = 0D;
            this.hmiLabel21.KeypadScaleFactor = 1D;
            this.hmiLabel21.KeypadShowCurrentValue = false;
            this.hmiLabel21.KeypadText = null;
            this.hmiLabel21.KeypadWidth = 400;
            this.hmiLabel21.Location = new System.Drawing.Point(384, 109);
            this.hmiLabel21.Name = "hmiLabel21";
            this.hmiLabel21.NumericFormat = null;
            this.hmiLabel21.PLCAddressHighlight = "";
            this.hmiLabel21.PLCAddressKeypad = "TEST.PLC.StartAddress90.StartAddress90:118";
            this.hmiLabel21.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:118";
            this.hmiLabel21.PLCAddressVisible = "";
            this.hmiLabel21.PollRate = 0;
            this.hmiLabel21.Size = new System.Drawing.Size(51, 19);
            this.hmiLabel21.TabIndex = 491;
            this.hmiLabel21.Text = "0";
            this.hmiLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel21.Value = "0";
            this.hmiLabel21.ValueLeftPadCharacter = ' ';
            this.hmiLabel21.ValueLeftPadLength = 0;
            this.hmiLabel21.ValuePrefix = null;
            this.hmiLabel21.ValueScaleFactor = 1D;
            this.hmiLabel21.ValueSuffix = null;
            this.hmiLabel21.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel22
            // 
            this.hmiLabel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel22.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel22.DisplayAsTime = false;
            this.hmiLabel22.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel22.Highlight = false;
            this.hmiLabel22.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel22.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel22.HighlightKeyCharacter = "!";
            this.hmiLabel22.InterpretValueAsBCD = false;
            this.hmiLabel22.KeypadAlphaNumeric = false;
            this.hmiLabel22.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel22.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel22.KeypadMaxValue = 0D;
            this.hmiLabel22.KeypadMinValue = 0D;
            this.hmiLabel22.KeypadScaleFactor = 1D;
            this.hmiLabel22.KeypadShowCurrentValue = false;
            this.hmiLabel22.KeypadText = null;
            this.hmiLabel22.KeypadWidth = 400;
            this.hmiLabel22.Location = new System.Drawing.Point(384, 84);
            this.hmiLabel22.Name = "hmiLabel22";
            this.hmiLabel22.NumericFormat = null;
            this.hmiLabel22.PLCAddressHighlight = "";
            this.hmiLabel22.PLCAddressKeypad = "TEST.PLC.StartAddress90.StartAddress90:114";
            this.hmiLabel22.PLCAddressValue = "TEST.PLC.StartAddress90.StartAddress90:114";
            this.hmiLabel22.PLCAddressVisible = "";
            this.hmiLabel22.PollRate = 0;
            this.hmiLabel22.Size = new System.Drawing.Size(51, 19);
            this.hmiLabel22.TabIndex = 490;
            this.hmiLabel22.Text = "0";
            this.hmiLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel22.Value = "0";
            this.hmiLabel22.ValueLeftPadCharacter = ' ';
            this.hmiLabel22.ValueLeftPadLength = 0;
            this.hmiLabel22.ValuePrefix = null;
            this.hmiLabel22.ValueScaleFactor = 1D;
            this.hmiLabel22.ValueSuffix = null;
            this.hmiLabel22.ValueToSubtractFrom = 0F;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arabic Typesetting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label4.Location = new System.Drawing.Point(370, 140);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(130, 37);
            this.Label4.TabIndex = 489;
            this.Label4.Text = "حساس الخلاط";
            // 
            // Label24
            // 
            this.Label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.Transparent;
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(286, 108);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(67, 13);
            this.Label24.TabIndex = 20;
            this.Label24.Text = "زمن الفعلى";
            // 
            // Label23
            // 
            this.Label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label23.AutoSize = true;
            this.Label23.BackColor = System.Drawing.Color.Transparent;
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(286, 84);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(67, 13);
            this.Label23.TabIndex = 19;
            this.Label23.Text = "زمن الفعلى";
            // 
            // Label22
            // 
            this.Label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label22.AutoSize = true;
            this.Label22.BackColor = System.Drawing.Color.Transparent;
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(441, 108);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(69, 13);
            this.Label22.TabIndex = 18;
            this.Label22.Text = "زمن التفريغ";
            // 
            // Label18
            // 
            this.Label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label18.AutoSize = true;
            this.Label18.BackColor = System.Drawing.Color.Transparent;
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(441, 84);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(59, 13);
            this.Label18.TabIndex = 13;
            this.Label18.Text = "زمن الخلط";
            // 
            // P__Exit
            // 
            this.P__Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P__Exit.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources._17_1;
            this.P__Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P__Exit.Controls.Add(this.lbl_Exit);
            this.P__Exit.Location = new System.Drawing.Point(666, 649);
            this.P__Exit.Name = "P__Exit";
            this.P__Exit.Size = new System.Drawing.Size(129, 56);
            this.P__Exit.TabIndex = 507;
            this.P__Exit.Click += new System.EventHandler(this.lbl_Exit_Click);
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Exit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exit.ForeColor = System.Drawing.Color.Black;
            this.lbl_Exit.Location = new System.Drawing.Point(47, 20);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(40, 19);
            this.lbl_Exit.TabIndex = 450;
            this.lbl_Exit.Text = "خروج";
            this.lbl_Exit.Click += new System.EventHandler(this.lbl_Exit_Click);
            // 
            // P_FRM_Advanced
            // 
            this.P_FRM_Advanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P_FRM_Advanced.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources._17_5;
            this.P_FRM_Advanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_FRM_Advanced.Controls.Add(this.Lbl_FRM_Advanced);
            this.P_FRM_Advanced.Location = new System.Drawing.Point(879, 649);
            this.P_FRM_Advanced.Name = "P_FRM_Advanced";
            this.P_FRM_Advanced.Size = new System.Drawing.Size(129, 56);
            this.P_FRM_Advanced.TabIndex = 506;
            this.P_FRM_Advanced.Click += new System.EventHandler(this.P_FRM_Advanced_Click);
            // 
            // Lbl_FRM_Advanced
            // 
            this.Lbl_FRM_Advanced.AutoSize = true;
            this.Lbl_FRM_Advanced.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_FRM_Advanced.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FRM_Advanced.ForeColor = System.Drawing.Color.Black;
            this.Lbl_FRM_Advanced.Location = new System.Drawing.Point(47, 20);
            this.Lbl_FRM_Advanced.Name = "Lbl_FRM_Advanced";
            this.Lbl_FRM_Advanced.Size = new System.Drawing.Size(50, 19);
            this.Lbl_FRM_Advanced.TabIndex = 450;
            this.Lbl_FRM_Advanced.Text = "اعدادات";
            this.Lbl_FRM_Advanced.Click += new System.EventHandler(this.P_FRM_Advanced_Click);
            // 
            // P_REPORT
            // 
            this.P_REPORT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P_REPORT.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources._17_2;
            this.P_REPORT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_REPORT.Controls.Add(this.LBL_REPORT);
            this.P_REPORT.Location = new System.Drawing.Point(1009, 649);
            this.P_REPORT.Name = "P_REPORT";
            this.P_REPORT.Size = new System.Drawing.Size(129, 56);
            this.P_REPORT.TabIndex = 505;
            this.P_REPORT.Click += new System.EventHandler(this.LBL_REPORT_Click);
            // 
            // LBL_REPORT
            // 
            this.LBL_REPORT.AutoSize = true;
            this.LBL_REPORT.BackColor = System.Drawing.Color.Transparent;
            this.LBL_REPORT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_REPORT.ForeColor = System.Drawing.Color.Black;
            this.LBL_REPORT.Location = new System.Drawing.Point(47, 20);
            this.LBL_REPORT.Name = "LBL_REPORT";
            this.LBL_REPORT.Size = new System.Drawing.Size(44, 19);
            this.LBL_REPORT.TabIndex = 450;
            this.LBL_REPORT.Text = "التقرير";
            this.LBL_REPORT.Click += new System.EventHandler(this.LBL_REPORT_Click);
            // 
            // P_Frm_Editr
            // 
            this.P_Frm_Editr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P_Frm_Editr.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources._17_4;
            this.P_Frm_Editr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Frm_Editr.Controls.Add(this.lbl_frm_Editr);
            this.P_Frm_Editr.Location = new System.Drawing.Point(1140, 649);
            this.P_Frm_Editr.Name = "P_Frm_Editr";
            this.P_Frm_Editr.Size = new System.Drawing.Size(129, 56);
            this.P_Frm_Editr.TabIndex = 504;
            this.P_Frm_Editr.Click += new System.EventHandler(this.lbl_frm_Editr_Click);
            // 
            // lbl_frm_Editr
            // 
            this.lbl_frm_Editr.AutoSize = true;
            this.lbl_frm_Editr.BackColor = System.Drawing.Color.Transparent;
            this.lbl_frm_Editr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_frm_Editr.ForeColor = System.Drawing.Color.Black;
            this.lbl_frm_Editr.Location = new System.Drawing.Point(26, 19);
            this.lbl_frm_Editr.Name = "lbl_frm_Editr";
            this.lbl_frm_Editr.Size = new System.Drawing.Size(87, 19);
            this.lbl_frm_Editr.TabIndex = 450;
            this.lbl_frm_Editr.Text = "اضافة وتركيب ";
            this.lbl_frm_Editr.Click += new System.EventHandler(this.lbl_frm_Editr_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.Micro_flowmeter;
            this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel1.Controls.Add(this.LBL_WeightSet);
            this.Panel1.Controls.Add(this.Label38);
            this.Panel1.Controls.Add(this.Label39);
            this.Panel1.Controls.Add(this.Label40);
            this.Panel1.Controls.Add(this.LBL_Weight_old);
            this.Panel1.Controls.Add(this.LBL_WeightFinel);
            this.Panel1.Location = new System.Drawing.Point(721, 435);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(543, 157);
            this.Panel1.TabIndex = 501;
            // 
            // LBL_WeightSet
            // 
            this.LBL_WeightSet.BackColor = System.Drawing.Color.Transparent;
            this.LBL_WeightSet.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.LBL_WeightSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_WeightSet.DisplayAsTime = false;
            this.LBL_WeightSet.ForeColor = System.Drawing.Color.Black;
            this.LBL_WeightSet.Highlight = false;
            this.LBL_WeightSet.HighlightColor = System.Drawing.Color.Red;
            this.LBL_WeightSet.HighlightForeColor = System.Drawing.Color.White;
            this.LBL_WeightSet.HighlightKeyCharacter = "!";
            this.LBL_WeightSet.InterpretValueAsBCD = false;
            this.LBL_WeightSet.KeypadAlphaNumeric = false;
            this.LBL_WeightSet.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.LBL_WeightSet.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_WeightSet.KeypadMaxValue = 0D;
            this.LBL_WeightSet.KeypadMinValue = 0D;
            this.LBL_WeightSet.KeypadScaleFactor = 1D;
            this.LBL_WeightSet.KeypadShowCurrentValue = false;
            this.LBL_WeightSet.KeypadText = null;
            this.LBL_WeightSet.KeypadWidth = 400;
            this.LBL_WeightSet.Location = new System.Drawing.Point(183, 81);
            this.LBL_WeightSet.Name = "LBL_WeightSet";
            this.LBL_WeightSet.NumericFormat = null;
            this.LBL_WeightSet.PLCAddressHighlight = "";
            this.LBL_WeightSet.PLCAddressKeypad = "";
            this.LBL_WeightSet.PLCAddressValue = "TEST.PLC.DW.DW5";
            this.LBL_WeightSet.PLCAddressVisible = "";
            this.LBL_WeightSet.PollRate = 0;
            this.LBL_WeightSet.Size = new System.Drawing.Size(18, 19);
            this.LBL_WeightSet.TabIndex = 52;
            this.LBL_WeightSet.Text = "0";
            this.LBL_WeightSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_WeightSet.Value = "0";
            this.LBL_WeightSet.ValueLeftPadCharacter = ' ';
            this.LBL_WeightSet.ValueLeftPadLength = 0;
            this.LBL_WeightSet.ValuePrefix = null;
            this.LBL_WeightSet.ValueScaleFactor = 1D;
            this.LBL_WeightSet.ValueSuffix = null;
            this.LBL_WeightSet.ValueToSubtractFrom = 0F;
            // 
            // Label38
            // 
            this.Label38.AutoSize = true;
            this.Label38.BackColor = System.Drawing.Color.Transparent;
            this.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label38.ForeColor = System.Drawing.Color.Blue;
            this.Label38.Location = new System.Drawing.Point(360, 53);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(103, 15);
            this.Label38.TabIndex = 47;
            this.Label38.Text = "وزن الكلى للخلطة";
            // 
            // Label39
            // 
            this.Label39.AutoSize = true;
            this.Label39.BackColor = System.Drawing.Color.Transparent;
            this.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label39.ForeColor = System.Drawing.Color.Blue;
            this.Label39.Location = new System.Drawing.Point(360, 85);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(109, 15);
            this.Label39.TabIndex = 48;
            this.Label39.Text = "وزن المنزال للخلطة";
            // 
            // Label40
            // 
            this.Label40.AutoSize = true;
            this.Label40.BackColor = System.Drawing.Color.Transparent;
            this.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label40.ForeColor = System.Drawing.Color.Blue;
            this.Label40.Location = new System.Drawing.Point(356, 113);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(113, 15);
            this.Label40.TabIndex = 49;
            this.Label40.Text = "وزن المتبقى للخلطة";
            // 
            // LBL_Weight_old
            // 
            this.LBL_Weight_old.AutoSize = true;
            this.LBL_Weight_old.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Weight_old.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_Weight_old.ForeColor = System.Drawing.Color.Blue;
            this.LBL_Weight_old.Location = new System.Drawing.Point(184, 113);
            this.LBL_Weight_old.Name = "LBL_Weight_old";
            this.LBL_Weight_old.Size = new System.Drawing.Size(16, 15);
            this.LBL_Weight_old.TabIndex = 51;
            this.LBL_Weight_old.Text = "1";
            // 
            // LBL_WeightFinel
            // 
            this.LBL_WeightFinel.AutoSize = true;
            this.LBL_WeightFinel.BackColor = System.Drawing.Color.Transparent;
            this.LBL_WeightFinel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_WeightFinel.ForeColor = System.Drawing.Color.Green;
            this.LBL_WeightFinel.Location = new System.Drawing.Point(184, 53);
            this.LBL_WeightFinel.Name = "LBL_WeightFinel";
            this.LBL_WeightFinel.Size = new System.Drawing.Size(16, 15);
            this.LBL_WeightFinel.TabIndex = 50;
            this.LBL_WeightFinel.Text = "1";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.hmiLabel44);
            this.panel4.Controls.Add(this.thnk_rec_oil);
            this.panel4.Controls.Add(this.hmiLabel46);
            this.panel4.Location = new System.Drawing.Point(417, 343);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(98, 120);
            this.panel4.TabIndex = 518;
            // 
            // hmiLabel44
            // 
            this.hmiLabel44.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel44.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel44.DisplayAsTime = false;
            this.hmiLabel44.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel44.Highlight = false;
            this.hmiLabel44.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel44.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel44.HighlightKeyCharacter = "!";
            this.hmiLabel44.InterpretValueAsBCD = false;
            this.hmiLabel44.KeypadAlphaNumeric = false;
            this.hmiLabel44.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel44.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel44.KeypadMaxValue = 0D;
            this.hmiLabel44.KeypadMinValue = 0D;
            this.hmiLabel44.KeypadScaleFactor = 1D;
            this.hmiLabel44.KeypadShowCurrentValue = false;
            this.hmiLabel44.KeypadText = null;
            this.hmiLabel44.KeypadWidth = 400;
            this.hmiLabel44.Location = new System.Drawing.Point(39, 69);
            this.hmiLabel44.Name = "hmiLabel44";
            this.hmiLabel44.NumericFormat = null;
            this.hmiLabel44.PLCAddressHighlight = "";
            this.hmiLabel44.PLCAddressKeypad = "";
            this.hmiLabel44.PLCAddressValue = "";
            this.hmiLabel44.PLCAddressVisible = "";
            this.hmiLabel44.PollRate = 0;
            this.hmiLabel44.Size = new System.Drawing.Size(22, 19);
            this.hmiLabel44.TabIndex = 4;
            this.hmiLabel44.Text = "0";
            this.hmiLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel44.Value = "0";
            this.hmiLabel44.ValueLeftPadCharacter = ' ';
            this.hmiLabel44.ValueLeftPadLength = 0;
            this.hmiLabel44.ValuePrefix = null;
            this.hmiLabel44.ValueScaleFactor = 1D;
            this.hmiLabel44.ValueSuffix = null;
            this.hmiLabel44.ValueToSubtractFrom = 0F;
            // 
            // thnk_rec_oil
            // 
            this.thnk_rec_oil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.thnk_rec_oil.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.thnk_rec_oil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thnk_rec_oil.DisplayAsTime = false;
            this.thnk_rec_oil.ForeColor = System.Drawing.Color.Black;
            this.thnk_rec_oil.Highlight = false;
            this.thnk_rec_oil.HighlightColor = System.Drawing.Color.Red;
            this.thnk_rec_oil.HighlightForeColor = System.Drawing.Color.White;
            this.thnk_rec_oil.HighlightKeyCharacter = "!";
            this.thnk_rec_oil.InterpretValueAsBCD = false;
            this.thnk_rec_oil.KeypadAlphaNumeric = false;
            this.thnk_rec_oil.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.thnk_rec_oil.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.thnk_rec_oil.KeypadMaxValue = 0D;
            this.thnk_rec_oil.KeypadMinValue = 0D;
            this.thnk_rec_oil.KeypadScaleFactor = 1D;
            this.thnk_rec_oil.KeypadShowCurrentValue = false;
            this.thnk_rec_oil.KeypadText = null;
            this.thnk_rec_oil.KeypadWidth = 400;
            this.thnk_rec_oil.Location = new System.Drawing.Point(10, 36);
            this.thnk_rec_oil.Name = "thnk_rec_oil";
            this.thnk_rec_oil.NumericFormat = null;
            this.thnk_rec_oil.PLCAddressHighlight = "";
            this.thnk_rec_oil.PLCAddressKeypad = "";
            this.thnk_rec_oil.PLCAddressValue = "";
            this.thnk_rec_oil.PLCAddressVisible = "";
            this.thnk_rec_oil.PollRate = 0;
            this.thnk_rec_oil.Size = new System.Drawing.Size(75, 19);
            this.thnk_rec_oil.TabIndex = 3;
            this.thnk_rec_oil.Text = "0";
            this.thnk_rec_oil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thnk_rec_oil.Value = "0";
            this.thnk_rec_oil.ValueLeftPadCharacter = ' ';
            this.thnk_rec_oil.ValueLeftPadLength = 0;
            this.thnk_rec_oil.ValuePrefix = null;
            this.thnk_rec_oil.ValueScaleFactor = 1D;
            this.thnk_rec_oil.ValueSuffix = null;
            this.thnk_rec_oil.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel46
            // 
            this.hmiLabel46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.hmiLabel46.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmiLabel46.DisplayAsTime = false;
            this.hmiLabel46.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel46.Highlight = false;
            this.hmiLabel46.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel46.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel46.HighlightKeyCharacter = "!";
            this.hmiLabel46.InterpretValueAsBCD = false;
            this.hmiLabel46.KeypadAlphaNumeric = false;
            this.hmiLabel46.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel46.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel46.KeypadMaxValue = 0D;
            this.hmiLabel46.KeypadMinValue = 0D;
            this.hmiLabel46.KeypadScaleFactor = 1D;
            this.hmiLabel46.KeypadShowCurrentValue = false;
            this.hmiLabel46.KeypadText = null;
            this.hmiLabel46.KeypadWidth = 400;
            this.hmiLabel46.Location = new System.Drawing.Point(10, 11);
            this.hmiLabel46.Name = "hmiLabel46";
            this.hmiLabel46.NumericFormat = null;
            this.hmiLabel46.PLCAddressHighlight = "";
            this.hmiLabel46.PLCAddressKeypad = "";
            this.hmiLabel46.PLCAddressValue = "";
            this.hmiLabel46.PLCAddressVisible = "";
            this.hmiLabel46.PollRate = 0;
            this.hmiLabel46.Size = new System.Drawing.Size(75, 19);
            this.hmiLabel46.TabIndex = 2;
            this.hmiLabel46.Text = "0";
            this.hmiLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel46.Value = "0";
            this.hmiLabel46.ValueLeftPadCharacter = ' ';
            this.hmiLabel46.ValueLeftPadLength = 0;
            this.hmiLabel46.ValuePrefix = null;
            this.hmiLabel46.ValueScaleFactor = 1D;
            this.hmiLabel46.ValueSuffix = null;
            this.hmiLabel46.ValueToSubtractFrom = 0F;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.Hopper_3;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.hmiSimpleLED2);
            this.panel5.Controls.Add(this.Label5);
            this.panel5.Controls.Add(this.Label1);
            this.panel5.Location = new System.Drawing.Point(117, 122);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 195);
            this.panel5.TabIndex = 520;
            // 
            // hmiSimpleLED2
            // 
            this.hmiSimpleLED2.BackColor = System.Drawing.Color.Transparent;
            this.hmiSimpleLED2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hmiSimpleLED2.Location = new System.Drawing.Point(66, 25);
            this.hmiSimpleLED2.MaximumHoldTime = 3000;
            this.hmiSimpleLED2.MaximumSize = new System.Drawing.Size(360, 360);
            this.hmiSimpleLED2.MinimumHoldTime = 500;
            this.hmiSimpleLED2.MinimumSize = new System.Drawing.Size(27, 27);
            this.hmiSimpleLED2.Name = "hmiSimpleLED2";
            this.hmiSimpleLED2.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiSimpleLED2.PLCAddressClick = "";
            this.hmiSimpleLED2.PLCAddressText = "";
            this.hmiSimpleLED2.PLCAddressValue = "";
            this.hmiSimpleLED2.PLCAddressVisible = "";
            this.hmiSimpleLED2.Size = new System.Drawing.Size(27, 27);
            this.hmiSimpleLED2.TabIndex = 520;
            this.hmiSimpleLED2.Text = " ";
            this.hmiSimpleLED2.ValueToWrite = 0;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arabic Typesetting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label5.Location = new System.Drawing.Point(8, 55);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(131, 37);
            this.Label5.TabIndex = 490;
            this.Label5.Text = "حساس المكبس";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arabic Typesetting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label1.Location = new System.Drawing.Point(38, 106);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 37);
            this.Label1.TabIndex = 32;
            this.Label1.Text = "المكبس";
            // 
            // hmiLabel53
            // 
            this.hmiLabel53.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel53.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel53.DisplayAsTime = false;
            this.hmiLabel53.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel53.Highlight = false;
            this.hmiLabel53.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel53.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel53.HighlightKeyCharacter = "!";
            this.hmiLabel53.InterpretValueAsBCD = false;
            this.hmiLabel53.KeypadAlphaNumeric = false;
            this.hmiLabel53.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel53.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel53.KeypadMaxValue = 0D;
            this.hmiLabel53.KeypadMinValue = 0D;
            this.hmiLabel53.KeypadScaleFactor = 1D;
            this.hmiLabel53.KeypadShowCurrentValue = false;
            this.hmiLabel53.KeypadText = null;
            this.hmiLabel53.KeypadWidth = 400;
            this.hmiLabel53.Location = new System.Drawing.Point(722, 76);
            this.hmiLabel53.Name = "hmiLabel53";
            this.hmiLabel53.NumericFormat = null;
            this.hmiLabel53.PLCAddressHighlight = "";
            this.hmiLabel53.PLCAddressKeypad = "";
            this.hmiLabel53.PLCAddressValue = "TEST.PLC.MB.MB7";
            this.hmiLabel53.PLCAddressVisible = "";
            this.hmiLabel53.PollRate = 0;
            this.hmiLabel53.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel53.TabIndex = 533;
            this.hmiLabel53.Text = "لا يعمل";
            this.hmiLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel53.Value = "لا يعمل";
            this.hmiLabel53.ValueLeftPadCharacter = ' ';
            this.hmiLabel53.ValueLeftPadLength = 0;
            this.hmiLabel53.ValuePrefix = null;
            this.hmiLabel53.ValueScaleFactor = 1D;
            this.hmiLabel53.ValueSuffix = null;
            this.hmiLabel53.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel52
            // 
            this.hmiLabel52.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel52.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel52.DisplayAsTime = false;
            this.hmiLabel52.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel52.Highlight = false;
            this.hmiLabel52.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel52.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel52.HighlightKeyCharacter = "!";
            this.hmiLabel52.InterpretValueAsBCD = false;
            this.hmiLabel52.KeypadAlphaNumeric = false;
            this.hmiLabel52.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel52.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel52.KeypadMaxValue = 0D;
            this.hmiLabel52.KeypadMinValue = 0D;
            this.hmiLabel52.KeypadScaleFactor = 1D;
            this.hmiLabel52.KeypadShowCurrentValue = false;
            this.hmiLabel52.KeypadText = null;
            this.hmiLabel52.KeypadWidth = 400;
            this.hmiLabel52.Location = new System.Drawing.Point(786, 77);
            this.hmiLabel52.Name = "hmiLabel52";
            this.hmiLabel52.NumericFormat = null;
            this.hmiLabel52.PLCAddressHighlight = "";
            this.hmiLabel52.PLCAddressKeypad = "";
            this.hmiLabel52.PLCAddressValue = "TEST.PLC.MB.MB6";
            this.hmiLabel52.PLCAddressVisible = "";
            this.hmiLabel52.PollRate = 0;
            this.hmiLabel52.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel52.TabIndex = 532;
            this.hmiLabel52.Text = "لا يعمل";
            this.hmiLabel52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel52.Value = "لا يعمل";
            this.hmiLabel52.ValueLeftPadCharacter = ' ';
            this.hmiLabel52.ValueLeftPadLength = 0;
            this.hmiLabel52.ValuePrefix = null;
            this.hmiLabel52.ValueScaleFactor = 1D;
            this.hmiLabel52.ValueSuffix = null;
            this.hmiLabel52.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel51
            // 
            this.hmiLabel51.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel51.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel51.DisplayAsTime = false;
            this.hmiLabel51.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel51.Highlight = false;
            this.hmiLabel51.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel51.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel51.HighlightKeyCharacter = "!";
            this.hmiLabel51.InterpretValueAsBCD = false;
            this.hmiLabel51.KeypadAlphaNumeric = false;
            this.hmiLabel51.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel51.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel51.KeypadMaxValue = 0D;
            this.hmiLabel51.KeypadMinValue = 0D;
            this.hmiLabel51.KeypadScaleFactor = 1D;
            this.hmiLabel51.KeypadShowCurrentValue = false;
            this.hmiLabel51.KeypadText = null;
            this.hmiLabel51.KeypadWidth = 400;
            this.hmiLabel51.Location = new System.Drawing.Point(851, 77);
            this.hmiLabel51.Name = "hmiLabel51";
            this.hmiLabel51.NumericFormat = null;
            this.hmiLabel51.PLCAddressHighlight = "";
            this.hmiLabel51.PLCAddressKeypad = "";
            this.hmiLabel51.PLCAddressValue = "TEST.PLC.MB.MB5";
            this.hmiLabel51.PLCAddressVisible = "";
            this.hmiLabel51.PollRate = 0;
            this.hmiLabel51.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel51.TabIndex = 531;
            this.hmiLabel51.Text = "لا يعمل";
            this.hmiLabel51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel51.Value = "لا يعمل";
            this.hmiLabel51.ValueLeftPadCharacter = ' ';
            this.hmiLabel51.ValueLeftPadLength = 0;
            this.hmiLabel51.ValuePrefix = null;
            this.hmiLabel51.ValueScaleFactor = 1D;
            this.hmiLabel51.ValueSuffix = null;
            this.hmiLabel51.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel50
            // 
            this.hmiLabel50.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel50.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel50.DisplayAsTime = false;
            this.hmiLabel50.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel50.Highlight = false;
            this.hmiLabel50.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel50.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel50.HighlightKeyCharacter = "!";
            this.hmiLabel50.InterpretValueAsBCD = false;
            this.hmiLabel50.KeypadAlphaNumeric = false;
            this.hmiLabel50.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel50.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel50.KeypadMaxValue = 0D;
            this.hmiLabel50.KeypadMinValue = 0D;
            this.hmiLabel50.KeypadScaleFactor = 1D;
            this.hmiLabel50.KeypadShowCurrentValue = false;
            this.hmiLabel50.KeypadText = null;
            this.hmiLabel50.KeypadWidth = 400;
            this.hmiLabel50.Location = new System.Drawing.Point(925, 77);
            this.hmiLabel50.Name = "hmiLabel50";
            this.hmiLabel50.NumericFormat = null;
            this.hmiLabel50.PLCAddressHighlight = "";
            this.hmiLabel50.PLCAddressKeypad = "";
            this.hmiLabel50.PLCAddressValue = "TEST.PLC.MB.MB4";
            this.hmiLabel50.PLCAddressVisible = "";
            this.hmiLabel50.PollRate = 0;
            this.hmiLabel50.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel50.TabIndex = 530;
            this.hmiLabel50.Text = "لا يعمل";
            this.hmiLabel50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel50.Value = "لا يعمل";
            this.hmiLabel50.ValueLeftPadCharacter = ' ';
            this.hmiLabel50.ValueLeftPadLength = 0;
            this.hmiLabel50.ValuePrefix = null;
            this.hmiLabel50.ValueScaleFactor = 1D;
            this.hmiLabel50.ValueSuffix = null;
            this.hmiLabel50.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel49
            // 
            this.hmiLabel49.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel49.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel49.DisplayAsTime = false;
            this.hmiLabel49.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel49.Highlight = false;
            this.hmiLabel49.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel49.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel49.HighlightKeyCharacter = "!";
            this.hmiLabel49.InterpretValueAsBCD = false;
            this.hmiLabel49.KeypadAlphaNumeric = false;
            this.hmiLabel49.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel49.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel49.KeypadMaxValue = 0D;
            this.hmiLabel49.KeypadMinValue = 0D;
            this.hmiLabel49.KeypadScaleFactor = 1D;
            this.hmiLabel49.KeypadShowCurrentValue = false;
            this.hmiLabel49.KeypadText = null;
            this.hmiLabel49.KeypadWidth = 400;
            this.hmiLabel49.Location = new System.Drawing.Point(989, 76);
            this.hmiLabel49.Name = "hmiLabel49";
            this.hmiLabel49.NumericFormat = null;
            this.hmiLabel49.PLCAddressHighlight = "";
            this.hmiLabel49.PLCAddressKeypad = "";
            this.hmiLabel49.PLCAddressValue = "TEST.PLC.MB.MB3";
            this.hmiLabel49.PLCAddressVisible = "";
            this.hmiLabel49.PollRate = 0;
            this.hmiLabel49.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel49.TabIndex = 529;
            this.hmiLabel49.Text = "لا يعمل";
            this.hmiLabel49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel49.Value = "لا يعمل";
            this.hmiLabel49.ValueLeftPadCharacter = ' ';
            this.hmiLabel49.ValueLeftPadLength = 0;
            this.hmiLabel49.ValuePrefix = null;
            this.hmiLabel49.ValueScaleFactor = 1D;
            this.hmiLabel49.ValueSuffix = null;
            this.hmiLabel49.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel48
            // 
            this.hmiLabel48.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel48.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel48.DisplayAsTime = false;
            this.hmiLabel48.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel48.Highlight = false;
            this.hmiLabel48.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel48.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel48.HighlightKeyCharacter = "!";
            this.hmiLabel48.InterpretValueAsBCD = false;
            this.hmiLabel48.KeypadAlphaNumeric = false;
            this.hmiLabel48.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel48.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel48.KeypadMaxValue = 0D;
            this.hmiLabel48.KeypadMinValue = 0D;
            this.hmiLabel48.KeypadScaleFactor = 1D;
            this.hmiLabel48.KeypadShowCurrentValue = false;
            this.hmiLabel48.KeypadText = null;
            this.hmiLabel48.KeypadWidth = 400;
            this.hmiLabel48.Location = new System.Drawing.Point(1060, 77);
            this.hmiLabel48.Name = "hmiLabel48";
            this.hmiLabel48.NumericFormat = null;
            this.hmiLabel48.PLCAddressHighlight = "";
            this.hmiLabel48.PLCAddressKeypad = "";
            this.hmiLabel48.PLCAddressValue = "TEST.PLC.MB.MB2";
            this.hmiLabel48.PLCAddressVisible = "";
            this.hmiLabel48.PollRate = 0;
            this.hmiLabel48.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel48.TabIndex = 528;
            this.hmiLabel48.Text = "لا يعمل";
            this.hmiLabel48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel48.Value = "لا يعمل";
            this.hmiLabel48.ValueLeftPadCharacter = ' ';
            this.hmiLabel48.ValueLeftPadLength = 0;
            this.hmiLabel48.ValuePrefix = null;
            this.hmiLabel48.ValueScaleFactor = 1D;
            this.hmiLabel48.ValueSuffix = null;
            this.hmiLabel48.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel47
            // 
            this.hmiLabel47.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel47.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel47.DisplayAsTime = false;
            this.hmiLabel47.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel47.Highlight = false;
            this.hmiLabel47.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel47.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel47.HighlightKeyCharacter = "!";
            this.hmiLabel47.InterpretValueAsBCD = false;
            this.hmiLabel47.KeypadAlphaNumeric = false;
            this.hmiLabel47.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel47.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel47.KeypadMaxValue = 0D;
            this.hmiLabel47.KeypadMinValue = 0D;
            this.hmiLabel47.KeypadScaleFactor = 1D;
            this.hmiLabel47.KeypadShowCurrentValue = false;
            this.hmiLabel47.KeypadText = null;
            this.hmiLabel47.KeypadWidth = 400;
            this.hmiLabel47.Location = new System.Drawing.Point(1126, 76);
            this.hmiLabel47.Name = "hmiLabel47";
            this.hmiLabel47.NumericFormat = null;
            this.hmiLabel47.PLCAddressHighlight = "";
            this.hmiLabel47.PLCAddressKeypad = "";
            this.hmiLabel47.PLCAddressValue = "TEST.PLC.MB.MB1";
            this.hmiLabel47.PLCAddressVisible = "";
            this.hmiLabel47.PollRate = 0;
            this.hmiLabel47.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel47.TabIndex = 527;
            this.hmiLabel47.Text = "لا يعمل";
            this.hmiLabel47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel47.Value = "لا يعمل";
            this.hmiLabel47.ValueLeftPadCharacter = ' ';
            this.hmiLabel47.ValueLeftPadLength = 0;
            this.hmiLabel47.ValuePrefix = null;
            this.hmiLabel47.ValueScaleFactor = 1D;
            this.hmiLabel47.ValueSuffix = null;
            this.hmiLabel47.ValueToSubtractFrom = 0F;
            // 
            // hmiLabel43
            // 
            this.hmiLabel43.BackColor = System.Drawing.Color.Transparent;
            this.hmiLabel43.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel43.DisplayAsTime = false;
            this.hmiLabel43.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel43.Highlight = false;
            this.hmiLabel43.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel43.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel43.HighlightKeyCharacter = "!";
            this.hmiLabel43.InterpretValueAsBCD = false;
            this.hmiLabel43.KeypadAlphaNumeric = false;
            this.hmiLabel43.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel43.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel43.KeypadMaxValue = 0D;
            this.hmiLabel43.KeypadMinValue = 0D;
            this.hmiLabel43.KeypadScaleFactor = 1D;
            this.hmiLabel43.KeypadShowCurrentValue = false;
            this.hmiLabel43.KeypadText = null;
            this.hmiLabel43.KeypadWidth = 400;
            this.hmiLabel43.Location = new System.Drawing.Point(1193, 76);
            this.hmiLabel43.Name = "hmiLabel43";
            this.hmiLabel43.NumericFormat = null;
            this.hmiLabel43.PLCAddressHighlight = "";
            this.hmiLabel43.PLCAddressKeypad = "";
            this.hmiLabel43.PLCAddressValue = "TEST.PLC.MB.MB0";
            this.hmiLabel43.PLCAddressVisible = "";
            this.hmiLabel43.PollRate = 0;
            this.hmiLabel43.Size = new System.Drawing.Size(53, 19);
            this.hmiLabel43.TabIndex = 526;
            this.hmiLabel43.Text = "لا يعمل";
            this.hmiLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel43.Value = "لا يعمل";
            this.hmiLabel43.ValueLeftPadCharacter = ' ';
            this.hmiLabel43.ValueLeftPadLength = 0;
            this.hmiLabel43.ValuePrefix = null;
            this.hmiLabel43.ValueScaleFactor = 1D;
            this.hmiLabel43.ValueSuffix = null;
            this.hmiLabel43.ValueToSubtractFrom = 0F;
            // 
            // hmiPilotLight4
            // 
            this.hmiPilotLight4.Blink = false;
            this.hmiPilotLight4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.hmiPilotLight4.LegendPlate = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LegendPlates.Small;
            this.hmiPilotLight4.LightColor = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Red;
            this.hmiPilotLight4.LightColorOff = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Yellow;
            this.hmiPilotLight4.Location = new System.Drawing.Point(4, 343);
            this.hmiPilotLight4.MaximumHoldTime = 3000;
            this.hmiPilotLight4.MinimumHoldTime = 500;
            this.hmiPilotLight4.Name = "hmiPilotLight4";
            this.hmiPilotLight4.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiPilotLight4.PLCAddressClick = "TEST.PLC.MB.MBC";
            this.hmiPilotLight4.PLCAddressText = "";
            this.hmiPilotLight4.PLCAddressValue = "TEST.PLC.MB.MBC";
            this.hmiPilotLight4.PLCAddressVisible = "";
            this.hmiPilotLight4.Size = new System.Drawing.Size(79, 84);
            this.hmiPilotLight4.TabIndex = 525;
            this.hmiPilotLight4.Text = "يدوى";
            this.hmiPilotLight4.Value = false;
            this.hmiPilotLight4.ValueToWrite = 0;
            // 
            // hmiPilotLight3
            // 
            this.hmiPilotLight3.Blink = false;
            this.hmiPilotLight3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.hmiPilotLight3.LegendPlate = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LegendPlates.Small;
            this.hmiPilotLight3.LightColor = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Red;
            this.hmiPilotLight3.LightColorOff = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Blue;
            this.hmiPilotLight3.Location = new System.Drawing.Point(4, 257);
            this.hmiPilotLight3.MaximumHoldTime = 3000;
            this.hmiPilotLight3.MinimumHoldTime = 500;
            this.hmiPilotLight3.Name = "hmiPilotLight3";
            this.hmiPilotLight3.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiPilotLight3.PLCAddressClick = "TEST.PLC.MB.MBC";
            this.hmiPilotLight3.PLCAddressText = "";
            this.hmiPilotLight3.PLCAddressValue = "TEST.PLC.MB.MBC";
            this.hmiPilotLight3.PLCAddressVisible = "";
            this.hmiPilotLight3.Size = new System.Drawing.Size(79, 84);
            this.hmiPilotLight3.TabIndex = 524;
            this.hmiPilotLight3.Text = "ايقاف مؤقت";
            this.hmiPilotLight3.Value = false;
            this.hmiPilotLight3.ValueToWrite = 0;
            // 
            // hmiPilotLight2
            // 
            this.hmiPilotLight2.Blink = false;
            this.hmiPilotLight2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.hmiPilotLight2.LegendPlate = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LegendPlates.Small;
            this.hmiPilotLight2.LightColor = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Red;
            this.hmiPilotLight2.LightColorOff = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Red;
            this.hmiPilotLight2.Location = new System.Drawing.Point(4, 171);
            this.hmiPilotLight2.MaximumHoldTime = 3000;
            this.hmiPilotLight2.MinimumHoldTime = 500;
            this.hmiPilotLight2.Name = "hmiPilotLight2";
            this.hmiPilotLight2.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiPilotLight2.PLCAddressClick = "TEST.PLC.MB.MB9";
            this.hmiPilotLight2.PLCAddressText = "";
            this.hmiPilotLight2.PLCAddressValue = "TEST.PLC.MB.MB9";
            this.hmiPilotLight2.PLCAddressVisible = "";
            this.hmiPilotLight2.Size = new System.Drawing.Size(79, 84);
            this.hmiPilotLight2.TabIndex = 523;
            this.hmiPilotLight2.Text = "ايقاف";
            this.hmiPilotLight2.Value = false;
            this.hmiPilotLight2.ValueToWrite = 0;
            // 
            // hmiPilotLight1
            // 
            this.hmiPilotLight1.Blink = false;
            this.hmiPilotLight1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.hmiPilotLight1.LegendPlate = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LegendPlates.Small;
            this.hmiPilotLight1.LightColor = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Green;
            this.hmiPilotLight1.LightColorOff = AdvancedScada.Controls.SelectorSwitch.HMIPilotLight.LightColorOption.Green;
            this.hmiPilotLight1.Location = new System.Drawing.Point(4, 84);
            this.hmiPilotLight1.MaximumHoldTime = 3000;
            this.hmiPilotLight1.MinimumHoldTime = 500;
            this.hmiPilotLight1.Name = "hmiPilotLight1";
            this.hmiPilotLight1.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiPilotLight1.PLCAddressClick = "TEST.PLC.MB.MBE";
            this.hmiPilotLight1.PLCAddressText = "";
            this.hmiPilotLight1.PLCAddressValue = "TEST.PLC.MB.MBE";
            this.hmiPilotLight1.PLCAddressVisible = "";
            this.hmiPilotLight1.Size = new System.Drawing.Size(79, 84);
            this.hmiPilotLight1.TabIndex = 522;
            this.hmiPilotLight1.Text = "تشغيل";
            this.hmiPilotLight1.Value = false;
            this.hmiPilotLight1.ValueToWrite = 0;
            // 
            // hmiDigitalPanelMeter1
            // 
            this.hmiDigitalPanelMeter1.BackColor = System.Drawing.Color.Transparent;
            this.hmiDigitalPanelMeter1.BackgroundColors = AdvancedScada.Controls.DigitalDisplay.HMIDigitalPanelMeter.BackgroundColor.Black;
            this.hmiDigitalPanelMeter1.DecimalPosition = 0;
            this.hmiDigitalPanelMeter1.ForeColor = System.Drawing.Color.LightGray;
            this.hmiDigitalPanelMeter1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiDigitalPanelMeter1.KeypadMaxValue = 0D;
            this.hmiDigitalPanelMeter1.KeypadMinValue = 0D;
            this.hmiDigitalPanelMeter1.KeypadScaleFactor = 1D;
            this.hmiDigitalPanelMeter1.KeypadText = null;
            this.hmiDigitalPanelMeter1.KeypadWidth = 300;
            this.hmiDigitalPanelMeter1.LegendText = "Text";
            this.hmiDigitalPanelMeter1.Location = new System.Drawing.Point(427, 123);
            this.hmiDigitalPanelMeter1.Name = "hmiDigitalPanelMeter1";
            this.hmiDigitalPanelMeter1.NumberOfDigits = 5;
            this.hmiDigitalPanelMeter1.PLCAddressKeypad = "CH2.PLC1.DataBlock2.TAG00023";
            this.hmiDigitalPanelMeter1.PLCAddressText = "";
            this.hmiDigitalPanelMeter1.PLCAddressValue = "CH2.PLC1.DataBlock2.TAG00023";
            this.hmiDigitalPanelMeter1.PLCAddressVisible = "";
            this.hmiDigitalPanelMeter1.Resolution = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter1.Size = new System.Drawing.Size(147, 65);
            this.hmiDigitalPanelMeter1.TabIndex = 521;
            this.hmiDigitalPanelMeter1.Text = "شاشة الانفارتار";
            this.hmiDigitalPanelMeter1.Value = 0F;
            this.hmiDigitalPanelMeter1.ValueScaleFactor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter1.ValueScaleOffset = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // hmiMushroomButton1
            // 
            this.hmiMushroomButton1.ButtonColor = AdvancedScada.Controls.SelectorSwitch.HMIMushroomButton.ButtonColors.RedMushroom;
            this.hmiMushroomButton1.LegendPlate = AdvancedScada.Controls.SelectorSwitch.HMIMushroomButton.LegendPlates.Small;
            this.hmiMushroomButton1.Location = new System.Drawing.Point(4, 433);
            this.hmiMushroomButton1.MaximumHoldTime = 3000;
            this.hmiMushroomButton1.MinimumHoldTime = 500;
            this.hmiMushroomButton1.Name = "hmiMushroomButton1";
            this.hmiMushroomButton1.OutputType = AdvancedScada.Controls.SelectorSwitch.HMIMushroomButton.OutputTypes.Toggle;
            this.hmiMushroomButton1.PLCAddressClick = "TEST.PLC.MB.MBA";
            this.hmiMushroomButton1.PLCAddressText = "";
            this.hmiMushroomButton1.PLCAddressValue = "TEST.PLC.MB.MBA";
            this.hmiMushroomButton1.PLCAddressVisible = "";
            this.hmiMushroomButton1.Size = new System.Drawing.Size(80, 85);
            this.hmiMushroomButton1.TabIndex = 519;
            this.hmiMushroomButton1.Text = "طواري";
            this.hmiMushroomButton1.Value = false;
            this.hmiMushroomButton1.ValueToWrite = 0;
            // 
            // hmiWaterPump1
            // 
            this.hmiWaterPump1.Location = new System.Drawing.Point(374, 463);
            this.hmiWaterPump1.MaximumHoldTime = 3000;
            this.hmiWaterPump1.MinimumHoldTime = 500;
            this.hmiWaterPump1.Name = "hmiWaterPump1";
            this.hmiWaterPump1.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiWaterPump1.PLCAddressClick = "CH2.PLC1.DataBlock2.TAG00021";
            this.hmiWaterPump1.PLCAddressText = "";
            this.hmiWaterPump1.PLCAddressValue = "CH2.PLC1.DataBlock1.TAG00005";
            this.hmiWaterPump1.PLCAddressVisible = "";
            this.hmiWaterPump1.Size = new System.Drawing.Size(101, 49);
            this.hmiWaterPump1.TabIndex = 517;
            this.hmiWaterPump1.Text = " ";
            this.hmiWaterPump1.Value = false;
            this.hmiWaterPump1.ValueToWrite = 0;
            // 
            // hmiIndicator1
            // 
            this.hmiIndicator1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hmiIndicator1.Color1 = System.Drawing.Color.Red;
            this.hmiIndicator1.Color2 = System.Drawing.Color.Green;
            this.hmiIndicator1.Color3 = System.Drawing.Color.Red;
            this.hmiIndicator1.Location = new System.Drawing.Point(866, 422);
            this.hmiIndicator1.Name = "hmiIndicator1";
            this.hmiIndicator1.OutlineColor = System.Drawing.Color.Transparent;
            this.hmiIndicator1.OutlineWidth = 1;
            this.hmiIndicator1.PLCAddressClick = "";
            this.hmiIndicator1.PLCAddressText = "";
            this.hmiIndicator1.PLCAddressValue = "";
            this.hmiIndicator1.PLCAddressVisible = "";
            this.hmiIndicator1.SelectColor2 = false;
            this.hmiIndicator1.SelectColor3 = false;
            this.hmiIndicator1.Shape = AdvancedScada.Controls.Controls.HMIIndicator.ShapeTypes.Rectangle;
            this.hmiIndicator1.Size = new System.Drawing.Size(256, 12);
            this.hmiIndicator1.TabIndex = 516;
            this.hmiIndicator1.Text = "hmiIndicator1";
            // 
            // hmiMotor8
            // 
            this.hmiMotor8.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor8.Location = new System.Drawing.Point(680, 193);
            this.hmiMotor8.MaximumHoldTime = 3000;
            this.hmiMotor8.MinimumHoldTime = 500;
            this.hmiMotor8.Name = "hmiMotor8";
            this.hmiMotor8.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor8.PLCAddressClick = "";
            this.hmiMotor8.PLCAddressText = "";
            this.hmiMotor8.PLCAddressValue = "";
            this.hmiMotor8.PLCAddressVisible = "";
            this.hmiMotor8.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor8.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor8.TabIndex = 515;
            this.hmiMotor8.Value = false;
            this.hmiMotor8.ValueToWrite = 0;
            // 
            // hmiMotor7
            // 
            this.hmiMotor7.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor7.Location = new System.Drawing.Point(751, 192);
            this.hmiMotor7.MaximumHoldTime = 3000;
            this.hmiMotor7.MinimumHoldTime = 500;
            this.hmiMotor7.Name = "hmiMotor7";
            this.hmiMotor7.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor7.PLCAddressClick = "";
            this.hmiMotor7.PLCAddressText = "";
            this.hmiMotor7.PLCAddressValue = "";
            this.hmiMotor7.PLCAddressVisible = "";
            this.hmiMotor7.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor7.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor7.TabIndex = 514;
            this.hmiMotor7.Value = false;
            this.hmiMotor7.ValueToWrite = 0;
            // 
            // hmiMotor6
            // 
            this.hmiMotor6.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor6.Location = new System.Drawing.Point(820, 192);
            this.hmiMotor6.MaximumHoldTime = 3000;
            this.hmiMotor6.MinimumHoldTime = 500;
            this.hmiMotor6.Name = "hmiMotor6";
            this.hmiMotor6.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor6.PLCAddressClick = "";
            this.hmiMotor6.PLCAddressText = "";
            this.hmiMotor6.PLCAddressValue = "";
            this.hmiMotor6.PLCAddressVisible = "";
            this.hmiMotor6.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor6.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor6.TabIndex = 513;
            this.hmiMotor6.Value = false;
            this.hmiMotor6.ValueToWrite = 0;
            // 
            // hmiMotor5
            // 
            this.hmiMotor5.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor5.Location = new System.Drawing.Point(885, 193);
            this.hmiMotor5.MaximumHoldTime = 3000;
            this.hmiMotor5.MinimumHoldTime = 500;
            this.hmiMotor5.Name = "hmiMotor5";
            this.hmiMotor5.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor5.PLCAddressClick = "";
            this.hmiMotor5.PLCAddressText = "";
            this.hmiMotor5.PLCAddressValue = "";
            this.hmiMotor5.PLCAddressVisible = "";
            this.hmiMotor5.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor5.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor5.TabIndex = 512;
            this.hmiMotor5.Value = false;
            this.hmiMotor5.ValueToWrite = 0;
            // 
            // hmiMotor4
            // 
            this.hmiMotor4.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor4.Location = new System.Drawing.Point(957, 192);
            this.hmiMotor4.MaximumHoldTime = 3000;
            this.hmiMotor4.MinimumHoldTime = 500;
            this.hmiMotor4.Name = "hmiMotor4";
            this.hmiMotor4.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor4.PLCAddressClick = "";
            this.hmiMotor4.PLCAddressText = "";
            this.hmiMotor4.PLCAddressValue = "";
            this.hmiMotor4.PLCAddressVisible = "";
            this.hmiMotor4.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor4.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor4.TabIndex = 511;
            this.hmiMotor4.Value = false;
            this.hmiMotor4.ValueToWrite = 0;
            // 
            // hmiMotor3
            // 
            this.hmiMotor3.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor3.Location = new System.Drawing.Point(1026, 194);
            this.hmiMotor3.MaximumHoldTime = 3000;
            this.hmiMotor3.MinimumHoldTime = 500;
            this.hmiMotor3.Name = "hmiMotor3";
            this.hmiMotor3.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor3.PLCAddressClick = "";
            this.hmiMotor3.PLCAddressText = "";
            this.hmiMotor3.PLCAddressValue = "";
            this.hmiMotor3.PLCAddressVisible = "";
            this.hmiMotor3.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor3.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor3.TabIndex = 510;
            this.hmiMotor3.Value = false;
            this.hmiMotor3.ValueToWrite = 0;
            // 
            // hmiMotor2
            // 
            this.hmiMotor2.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor2.Location = new System.Drawing.Point(1094, 192);
            this.hmiMotor2.MaximumHoldTime = 3000;
            this.hmiMotor2.MinimumHoldTime = 500;
            this.hmiMotor2.Name = "hmiMotor2";
            this.hmiMotor2.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor2.PLCAddressClick = "";
            this.hmiMotor2.PLCAddressText = "";
            this.hmiMotor2.PLCAddressValue = "";
            this.hmiMotor2.PLCAddressVisible = "";
            this.hmiMotor2.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor2.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor2.TabIndex = 509;
            this.hmiMotor2.Value = false;
            this.hmiMotor2.ValueToWrite = 0;
            // 
            // hmiMotor1
            // 
            this.hmiMotor1.LightColor = AdvancedScada.Controls.Motor.HMIMotor.LightColorOption.Green;
            this.hmiMotor1.Location = new System.Drawing.Point(1164, 194);
            this.hmiMotor1.MaximumHoldTime = 3000;
            this.hmiMotor1.MinimumHoldTime = 500;
            this.hmiMotor1.Name = "hmiMotor1";
            this.hmiMotor1.OutputType = AdvancedScada.Controls.Motor.OutputType.Toggle;
            this.hmiMotor1.PLCAddressClick = "";
            this.hmiMotor1.PLCAddressText = "";
            this.hmiMotor1.PLCAddressValue = "";
            this.hmiMotor1.PLCAddressVisible = "";
            this.hmiMotor1.Rotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.hmiMotor1.Size = new System.Drawing.Size(46, 31);
            this.hmiMotor1.TabIndex = 508;
            this.hmiMotor1.Value = false;
            this.hmiMotor1.ValueToWrite = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LBL_ReportViewer
            // 
            this.LBL_ReportViewer.AutoSize = true;
            this.LBL_ReportViewer.BackColor = System.Drawing.Color.Transparent;
            this.LBL_ReportViewer.BooleanDisplay = AdvancedScada.Controls.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.LBL_ReportViewer.DisplayAsTime = false;
            this.LBL_ReportViewer.ForeColor = System.Drawing.Color.Black;
            this.LBL_ReportViewer.Highlight = false;
            this.LBL_ReportViewer.HighlightColor = System.Drawing.Color.Red;
            this.LBL_ReportViewer.HighlightForeColor = System.Drawing.Color.White;
            this.LBL_ReportViewer.HighlightKeyCharacter = "!";
            this.LBL_ReportViewer.InterpretValueAsBCD = false;
            this.LBL_ReportViewer.KeypadAlphaNumeric = false;
            this.LBL_ReportViewer.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.LBL_ReportViewer.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_ReportViewer.KeypadMaxValue = 0D;
            this.LBL_ReportViewer.KeypadMinValue = 0D;
            this.LBL_ReportViewer.KeypadScaleFactor = 1D;
            this.LBL_ReportViewer.KeypadShowCurrentValue = false;
            this.LBL_ReportViewer.KeypadText = null;
            this.LBL_ReportViewer.KeypadWidth = 400;
            this.LBL_ReportViewer.Location = new System.Drawing.Point(481, 84);
            this.LBL_ReportViewer.Name = "LBL_ReportViewer";
            this.LBL_ReportViewer.NumericFormat = null;
            this.LBL_ReportViewer.PLCAddressHighlight = "";
            this.LBL_ReportViewer.PLCAddressKeypad = "";
            this.LBL_ReportViewer.PLCAddressValue = "TEST.PLC.StartAddress100bit.StartAddress100bit:100";
            this.LBL_ReportViewer.PLCAddressVisible = "";
            this.LBL_ReportViewer.PollRate = 0;
            this.LBL_ReportViewer.Size = new System.Drawing.Size(69, 13);
            this.LBL_ReportViewer.TabIndex = 534;
            this.LBL_ReportViewer.Text = "BasicLabel";
            this.LBL_ReportViewer.Value = "BasicLabel";
            this.LBL_ReportViewer.ValueLeftPadCharacter = ' ';
            this.LBL_ReportViewer.ValueLeftPadLength = 0;
            this.LBL_ReportViewer.ValuePrefix = null;
            this.LBL_ReportViewer.ValueScaleFactor = 1D;
            this.LBL_ReportViewer.ValueSuffix = null;
            this.LBL_ReportViewer.ValueToSubtractFrom = 0F;
            this.LBL_ReportViewer.ValueChanged += new System.EventHandler(this.LBL_ReportViewer_ValueChanged);
            this.LBL_ReportViewer.Click += new System.EventHandler(this.LBL_ReportViewer_Click);
            // 
            // hmiProcessLevel1
            // 
            this.hmiProcessLevel1.BkGradient = false;
            this.hmiProcessLevel1.BkGradientAngle = 90;
            this.hmiProcessLevel1.BkGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel1.BkGradientRate = 0.5F;
            this.hmiProcessLevel1.BkGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel1.BkShinePosition = 1F;
            this.hmiProcessLevel1.BkTransparency = 0F;
            this.hmiProcessLevel1.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiProcessLevel1.BorderExteriorLength = 0;
            this.hmiProcessLevel1.BorderGradientAngle = 225;
            this.hmiProcessLevel1.BorderGradientLightPos1 = 1F;
            this.hmiProcessLevel1.BorderGradientLightPos2 = -1F;
            this.hmiProcessLevel1.BorderGradientRate = 0.5F;
            this.hmiProcessLevel1.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Ring;
            this.hmiProcessLevel1.BorderLightIntermediateBrightness = 0F;
            this.hmiProcessLevel1.BorderShape = AdvancedScada.Controls.Enum.DAS_BorderStyle.BS_RoundRect;
            this.hmiProcessLevel1.ControlShadow = false;
            this.hmiProcessLevel1.Gradient = true;
            this.hmiProcessLevel1.IndicatorBorderColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel1.IndicatorColor = System.Drawing.Color.YellowGreen;
            this.hmiProcessLevel1.IndicatorColor2 = System.Drawing.Color.DarkGreen;
            this.hmiProcessLevel1.IndicatorColor3 = System.Drawing.Color.Red;
            this.hmiProcessLevel1.IndicatorGap = 30;
            this.hmiProcessLevel1.IndicatorGradientAngle = 90;
            this.hmiProcessLevel1.IndicatorGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel1.IndicatorGradientRate = 0.5F;
            this.hmiProcessLevel1.IndicatorGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel1.IndicatorImage = null;
            this.hmiProcessLevel1.IndicatorShinePosition = 1F;
            this.hmiProcessLevel1.IndicatorSize = 20;
            this.hmiProcessLevel1.IndicatorString = "...";
            this.hmiProcessLevel1.IndicatorType = AdvancedScada.Controls.Enum.DAS_ProcessIndicatorType.PIT_Arrow;
            this.hmiProcessLevel1.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel1.InnerBorderLength = 2;
            this.hmiProcessLevel1.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel1.InverseDirection = true;
            this.hmiProcessLevel1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiProcessLevel1.KeypadMaxValue = 0D;
            this.hmiProcessLevel1.KeypadMinValue = 0D;
            this.hmiProcessLevel1.KeypadScaleFactor = 1D;
            this.hmiProcessLevel1.KeypadText = null;
            this.hmiProcessLevel1.KeypadWidth = 300;
            this.hmiProcessLevel1.Location = new System.Drawing.Point(788, 595);
            this.hmiProcessLevel1.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiProcessLevel1.MiddleBorderLength = 0;
            this.hmiProcessLevel1.Name = "hmiProcessLevel1";
            this.hmiProcessLevel1.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel1.OuterBorderLength = 3;
            this.hmiProcessLevel1.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel1.PLCAddressKeypad = "";
            this.hmiProcessLevel1.PLCAddressText = "";
            this.hmiProcessLevel1.PLCAddressValue = "CH2.PLC1.DataBlock1.TAG00004";
            this.hmiProcessLevel1.PLCAddressVisible = "";
            this.hmiProcessLevel1.RoundRadius = 30;
            this.hmiProcessLevel1.ShadowColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel1.ShadowDepth = 8;
            this.hmiProcessLevel1.ShadowRate = 0.5F;
            this.hmiProcessLevel1.Size = new System.Drawing.Size(398, 31);
            this.hmiProcessLevel1.TabIndex = 535;
            this.hmiProcessLevel1.Text = "hmiProcessLevel1";
            this.hmiProcessLevel1.UpdateDuration = 500;
            this.hmiProcessLevel1.UpdatePercentage = 0.1F;
            this.hmiProcessLevel1.Value = false;
            this.hmiProcessLevel1.Vertical = false;
            // 
            // hmiProcessLevel2
            // 
            this.hmiProcessLevel2.BkGradient = false;
            this.hmiProcessLevel2.BkGradientAngle = 90;
            this.hmiProcessLevel2.BkGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel2.BkGradientRate = 0.5F;
            this.hmiProcessLevel2.BkGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel2.BkShinePosition = 1F;
            this.hmiProcessLevel2.BkTransparency = 0F;
            this.hmiProcessLevel2.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiProcessLevel2.BorderExteriorLength = 0;
            this.hmiProcessLevel2.BorderGradientAngle = 225;
            this.hmiProcessLevel2.BorderGradientLightPos1 = 1F;
            this.hmiProcessLevel2.BorderGradientLightPos2 = -1F;
            this.hmiProcessLevel2.BorderGradientRate = 0.5F;
            this.hmiProcessLevel2.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Ring;
            this.hmiProcessLevel2.BorderLightIntermediateBrightness = 0F;
            this.hmiProcessLevel2.BorderShape = AdvancedScada.Controls.Enum.DAS_BorderStyle.BS_RoundRect;
            this.hmiProcessLevel2.ControlShadow = false;
            this.hmiProcessLevel2.Gradient = true;
            this.hmiProcessLevel2.IndicatorBorderColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel2.IndicatorColor = System.Drawing.Color.YellowGreen;
            this.hmiProcessLevel2.IndicatorColor2 = System.Drawing.Color.DarkGreen;
            this.hmiProcessLevel2.IndicatorColor3 = System.Drawing.Color.Red;
            this.hmiProcessLevel2.IndicatorGap = 30;
            this.hmiProcessLevel2.IndicatorGradientAngle = 90;
            this.hmiProcessLevel2.IndicatorGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel2.IndicatorGradientRate = 0.5F;
            this.hmiProcessLevel2.IndicatorGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel2.IndicatorImage = null;
            this.hmiProcessLevel2.IndicatorShinePosition = 1F;
            this.hmiProcessLevel2.IndicatorSize = 20;
            this.hmiProcessLevel2.IndicatorString = "...";
            this.hmiProcessLevel2.IndicatorType = AdvancedScada.Controls.Enum.DAS_ProcessIndicatorType.PIT_Arrow;
            this.hmiProcessLevel2.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel2.InnerBorderLength = 2;
            this.hmiProcessLevel2.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel2.InverseDirection = true;
            this.hmiProcessLevel2.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiProcessLevel2.KeypadMaxValue = 0D;
            this.hmiProcessLevel2.KeypadMinValue = 0D;
            this.hmiProcessLevel2.KeypadScaleFactor = 1D;
            this.hmiProcessLevel2.KeypadText = null;
            this.hmiProcessLevel2.KeypadWidth = 300;
            this.hmiProcessLevel2.Location = new System.Drawing.Point(169, 84);
            this.hmiProcessLevel2.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiProcessLevel2.MiddleBorderLength = 0;
            this.hmiProcessLevel2.Name = "hmiProcessLevel2";
            this.hmiProcessLevel2.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel2.OuterBorderLength = 3;
            this.hmiProcessLevel2.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel2.PLCAddressKeypad = "";
            this.hmiProcessLevel2.PLCAddressText = "";
            this.hmiProcessLevel2.PLCAddressValue = "CH3.PLC1.DataBlock1.TAG00006";
            this.hmiProcessLevel2.PLCAddressVisible = "";
            this.hmiProcessLevel2.RoundRadius = 30;
            this.hmiProcessLevel2.ShadowColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel2.ShadowDepth = 8;
            this.hmiProcessLevel2.ShadowRate = 0.5F;
            this.hmiProcessLevel2.Size = new System.Drawing.Size(129, 31);
            this.hmiProcessLevel2.TabIndex = 536;
            this.hmiProcessLevel2.Text = "hmiProcessLevel2";
            this.hmiProcessLevel2.UpdateDuration = 500;
            this.hmiProcessLevel2.UpdatePercentage = 0.1F;
            this.hmiProcessLevel2.Value = false;
            this.hmiProcessLevel2.Vertical = false;
            // 
            // hmiProcessLevel3
            // 
            this.hmiProcessLevel3.BkGradient = false;
            this.hmiProcessLevel3.BkGradientAngle = 90;
            this.hmiProcessLevel3.BkGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel3.BkGradientRate = 0.5F;
            this.hmiProcessLevel3.BkGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel3.BkShinePosition = 1F;
            this.hmiProcessLevel3.BkTransparency = 0F;
            this.hmiProcessLevel3.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiProcessLevel3.BorderExteriorLength = 0;
            this.hmiProcessLevel3.BorderGradientAngle = 225;
            this.hmiProcessLevel3.BorderGradientLightPos1 = 1F;
            this.hmiProcessLevel3.BorderGradientLightPos2 = -1F;
            this.hmiProcessLevel3.BorderGradientRate = 0.5F;
            this.hmiProcessLevel3.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Ring;
            this.hmiProcessLevel3.BorderLightIntermediateBrightness = 0F;
            this.hmiProcessLevel3.BorderShape = AdvancedScada.Controls.Enum.DAS_BorderStyle.BS_RoundRect;
            this.hmiProcessLevel3.ControlShadow = false;
            this.hmiProcessLevel3.Gradient = true;
            this.hmiProcessLevel3.IndicatorBorderColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel3.IndicatorColor = System.Drawing.Color.YellowGreen;
            this.hmiProcessLevel3.IndicatorColor2 = System.Drawing.Color.DarkGreen;
            this.hmiProcessLevel3.IndicatorColor3 = System.Drawing.Color.Red;
            this.hmiProcessLevel3.IndicatorGap = 30;
            this.hmiProcessLevel3.IndicatorGradientAngle = 90;
            this.hmiProcessLevel3.IndicatorGradientColor = System.Drawing.Color.White;
            this.hmiProcessLevel3.IndicatorGradientRate = 0.5F;
            this.hmiProcessLevel3.IndicatorGradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Linear;
            this.hmiProcessLevel3.IndicatorImage = null;
            this.hmiProcessLevel3.IndicatorShinePosition = 1F;
            this.hmiProcessLevel3.IndicatorSize = 20;
            this.hmiProcessLevel3.IndicatorString = "...";
            this.hmiProcessLevel3.IndicatorType = AdvancedScada.Controls.Enum.DAS_ProcessIndicatorType.PIT_Arrow;
            this.hmiProcessLevel3.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel3.InnerBorderLength = 2;
            this.hmiProcessLevel3.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel3.InverseDirection = false;
            this.hmiProcessLevel3.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiProcessLevel3.KeypadMaxValue = 0D;
            this.hmiProcessLevel3.KeypadMinValue = 0D;
            this.hmiProcessLevel3.KeypadScaleFactor = 1D;
            this.hmiProcessLevel3.KeypadText = null;
            this.hmiProcessLevel3.KeypadWidth = 300;
            this.hmiProcessLevel3.Location = new System.Drawing.Point(275, 123);
            this.hmiProcessLevel3.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiProcessLevel3.MiddleBorderLength = 0;
            this.hmiProcessLevel3.Name = "hmiProcessLevel3";
            this.hmiProcessLevel3.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel3.OuterBorderLength = 3;
            this.hmiProcessLevel3.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiProcessLevel3.PLCAddressKeypad = "CH3.PLC1.DataBlock2.TAG00021";
            this.hmiProcessLevel3.PLCAddressText = "";
            this.hmiProcessLevel3.PLCAddressValue = "CH3.PLC1.DataBlock2.TAG00021";
            this.hmiProcessLevel3.PLCAddressVisible = "";
            this.hmiProcessLevel3.RoundRadius = 30;
            this.hmiProcessLevel3.ShadowColor = System.Drawing.Color.DimGray;
            this.hmiProcessLevel3.ShadowDepth = 8;
            this.hmiProcessLevel3.ShadowRate = 0.5F;
            this.hmiProcessLevel3.Size = new System.Drawing.Size(30, 250);
            this.hmiProcessLevel3.TabIndex = 537;
            this.hmiProcessLevel3.Text = "hmiProcessLevel3";
            this.hmiProcessLevel3.UpdateDuration = 500;
            this.hmiProcessLevel3.UpdatePercentage = 0.1F;
            this.hmiProcessLevel3.Value = false;
            this.hmiProcessLevel3.Vertical = true;
            // 
            // hmiSevenSegment21
            // 
            this.hmiSevenSegment21.BackColor = System.Drawing.Color.Transparent;
            this.hmiSevenSegment21.DecimalPosition = 0;
            this.hmiSevenSegment21.ForecolorHighLimitValue = 999999D;
            this.hmiSevenSegment21.ForeColorInLimits = System.Drawing.Color.Blue;
            this.hmiSevenSegment21.ForecolorLowLimitValue = -999999D;
            this.hmiSevenSegment21.ForeColorOverHighLimit = System.Drawing.Color.Red;
            this.hmiSevenSegment21.ForeColorUnderLowLimit = System.Drawing.Color.Yellow;
            this.hmiSevenSegment21.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiSevenSegment21.KeypadMaxValue = 0D;
            this.hmiSevenSegment21.KeypadMinValue = 0D;
            this.hmiSevenSegment21.KeypadScaleFactor = 1D;
            this.hmiSevenSegment21.KeypadText = null;
            this.hmiSevenSegment21.KeypadWidth = 300;
            this.hmiSevenSegment21.Location = new System.Drawing.Point(386, 293);
            this.hmiSevenSegment21.Name = "hmiSevenSegment21";
            this.hmiSevenSegment21.NumberOfDigits = 5;
            this.hmiSevenSegment21.PLCAddressKeypad = "";
            this.hmiSevenSegment21.PLCAddressValue = "TEST.PLC.DW.DW1";
            this.hmiSevenSegment21.PLCAddressVisible = "";
            this.hmiSevenSegment21.ResolutionOfLastDigit = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiSevenSegment21.ShowOffSegments = true;
            this.hmiSevenSegment21.Size = new System.Drawing.Size(169, 44);
            this.hmiSevenSegment21.TabIndex = 538;
            this.hmiSevenSegment21.Text = "hmiSevenSegment21";
            this.hmiSevenSegment21.Value = 0D;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arabic Typesetting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label6.Location = new System.Drawing.Point(328, 74);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(126, 37);
            this.Label6.TabIndex = 540;
            this.Label6.Text = "الاسكادا تعمل";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arabic Typesetting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Label2.Location = new System.Drawing.Point(427, 245);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 37);
            this.Label2.TabIndex = 539;
            this.Label2.Text = "الزيت";
            // 
            // Panel9
            // 
            this.Panel9.BackgroundImage = global::AdvancedScada.HMI.Properties.Resources.Untitled;
            this.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel9.Controls.Add(this.Label3);
            this.Panel9.Location = new System.Drawing.Point(136, 345);
            this.Panel9.Name = "Panel9";
            this.Panel9.Size = new System.Drawing.Size(132, 78);
            this.Panel9.TabIndex = 541;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(-3, 26);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 19);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "XGT";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.EnableBonusSkins = true;
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Black";
            // 
            // hmiLedSingle1
            // 
            this.hmiLedSingle1.ArrowWidth = 20;
            this.hmiLedSingle1.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle1.BorderExteriorLength = 0;
            this.hmiLedSingle1.BorderGradientAngle = 225;
            this.hmiLedSingle1.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle1.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle1.BorderGradientRate = 0.5F;
            this.hmiLedSingle1.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle1.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle1.GradientAngle = 225;
            this.hmiLedSingle1.GradientRate = 0.6F;
            this.hmiLedSingle1.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle1.IndicatorAutoSize = true;
            this.hmiLedSingle1.IndicatorHeight = 50;
            this.hmiLedSingle1.IndicatorWidth = 50;
            this.hmiLedSingle1.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle1.InnerBorderLength = 2;
            this.hmiLedSingle1.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle1.Location = new System.Drawing.Point(1208, 231);
            this.hmiLedSingle1.LocationDialog = "1208; 231";
            this.hmiLedSingle1.MaximumHoldTime = 3000;
            this.hmiLedSingle1.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle1.MiddleBorderLength = 0;
            this.hmiLedSingle1.MinimumHoldTime = 500;
            this.hmiLedSingle1.Name = "hmiLedSingle1";
            this.hmiLedSingle1.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle1.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle1.OnColor = System.Drawing.Color.Red;
            this.hmiLedSingle1.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle1.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle1.OuterBorderLength = 2;
            this.hmiLedSingle1.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle1.OutputType = AdvancedScada.Controls.Motor.OutputType.ValveWeiCtriDialog;
            this.hmiLedSingle1.PLCAddressClick = "CH2.PLC1.DataBlock1.TAG00001";
            this.hmiLedSingle1.PLCAddressText = "";
            this.hmiLedSingle1.PLCAddressValue = "CH2.PLC1.DataBlock1.TAG00001";
            this.hmiLedSingle1.PLCAddressVisible = "";
            this.hmiLedSingle1.RoundRadius = 30;
            this.hmiLedSingle1.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle1.ShinePosition = 0.5F;
            this.hmiLedSingle1.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle1.TabIndex = 542;
            this.hmiLedSingle1.Text = "hmiLedSingle1";
            this.hmiLedSingle1.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle1.TextVisible = false;
            this.hmiLedSingle1.Value = false;
            this.hmiLedSingle1.ValueToWrite = 0;
            // 
            // hmiLedSingle2
            // 
            this.hmiLedSingle2.ArrowWidth = 20;
            this.hmiLedSingle2.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle2.BorderExteriorLength = 0;
            this.hmiLedSingle2.BorderGradientAngle = 225;
            this.hmiLedSingle2.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle2.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle2.BorderGradientRate = 0.5F;
            this.hmiLedSingle2.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle2.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle2.GradientAngle = 225;
            this.hmiLedSingle2.GradientRate = 0.6F;
            this.hmiLedSingle2.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle2.IndicatorAutoSize = true;
            this.hmiLedSingle2.IndicatorHeight = 50;
            this.hmiLedSingle2.IndicatorWidth = 50;
            this.hmiLedSingle2.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle2.InnerBorderLength = 2;
            this.hmiLedSingle2.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle2.Location = new System.Drawing.Point(1138, 231);
            this.hmiLedSingle2.LocationDialog = "1138; 231";
            this.hmiLedSingle2.MaximumHoldTime = 3000;
            this.hmiLedSingle2.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle2.MiddleBorderLength = 0;
            this.hmiLedSingle2.MinimumHoldTime = 500;
            this.hmiLedSingle2.Name = "hmiLedSingle2";
            this.hmiLedSingle2.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle2.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle2.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.hmiLedSingle2.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle2.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle2.OuterBorderLength = 2;
            this.hmiLedSingle2.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle2.OutputType = AdvancedScada.Controls.Motor.OutputType.ValveWeiCtriDialog;
            this.hmiLedSingle2.PLCAddressClick = "CH2.PLC1.DataBlock1.TAG00002";
            this.hmiLedSingle2.PLCAddressText = "";
            this.hmiLedSingle2.PLCAddressValue = "CH2.PLC1.DataBlock1.TAG00002";
            this.hmiLedSingle2.PLCAddressVisible = "";
            this.hmiLedSingle2.RoundRadius = 30;
            this.hmiLedSingle2.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle2.ShinePosition = 0.5F;
            this.hmiLedSingle2.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle2.TabIndex = 543;
            this.hmiLedSingle2.Text = "hmiLedSingle2";
            this.hmiLedSingle2.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle2.TextVisible = false;
            this.hmiLedSingle2.Value = false;
            this.hmiLedSingle2.ValueToWrite = 0;
            // 
            // hmiLedSingle3
            // 
            this.hmiLedSingle3.ArrowWidth = 20;
            this.hmiLedSingle3.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle3.BorderExteriorLength = 0;
            this.hmiLedSingle3.BorderGradientAngle = 225;
            this.hmiLedSingle3.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle3.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle3.BorderGradientRate = 0.5F;
            this.hmiLedSingle3.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle3.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle3.GradientAngle = 225;
            this.hmiLedSingle3.GradientRate = 0.6F;
            this.hmiLedSingle3.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle3.IndicatorAutoSize = true;
            this.hmiLedSingle3.IndicatorHeight = 50;
            this.hmiLedSingle3.IndicatorWidth = 50;
            this.hmiLedSingle3.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle3.InnerBorderLength = 2;
            this.hmiLedSingle3.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle3.Location = new System.Drawing.Point(999, 231);
            this.hmiLedSingle3.LocationDialog = "999; 231";
            this.hmiLedSingle3.MaximumHoldTime = 3000;
            this.hmiLedSingle3.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle3.MiddleBorderLength = 0;
            this.hmiLedSingle3.MinimumHoldTime = 500;
            this.hmiLedSingle3.Name = "hmiLedSingle3";
            this.hmiLedSingle3.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle3.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle3.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle3.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle3.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle3.OuterBorderLength = 2;
            this.hmiLedSingle3.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle3.OutputType = AdvancedScada.Controls.Motor.OutputType.ValveWeiCtriDialog;
            this.hmiLedSingle3.PLCAddressClick = "CH1.PLC1.DataBlock2.TAG00069";
            this.hmiLedSingle3.PLCAddressText = "";
            this.hmiLedSingle3.PLCAddressValue = "CH1.PLC1.DataBlock2.TAG00069";
            this.hmiLedSingle3.PLCAddressVisible = "";
            this.hmiLedSingle3.RoundRadius = 30;
            this.hmiLedSingle3.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle3.ShinePosition = 0.5F;
            this.hmiLedSingle3.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle3.TabIndex = 545;
            this.hmiLedSingle3.Text = "hmiLedSingle3";
            this.hmiLedSingle3.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle3.TextVisible = false;
            this.hmiLedSingle3.Value = false;
            this.hmiLedSingle3.ValueToWrite = 0;
            // 
            // hmiLedSingle4
            // 
            this.hmiLedSingle4.ArrowWidth = 20;
            this.hmiLedSingle4.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle4.BorderExteriorLength = 0;
            this.hmiLedSingle4.BorderGradientAngle = 225;
            this.hmiLedSingle4.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle4.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle4.BorderGradientRate = 0.5F;
            this.hmiLedSingle4.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle4.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle4.GradientAngle = 225;
            this.hmiLedSingle4.GradientRate = 0.6F;
            this.hmiLedSingle4.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle4.IndicatorAutoSize = true;
            this.hmiLedSingle4.IndicatorHeight = 50;
            this.hmiLedSingle4.IndicatorWidth = 50;
            this.hmiLedSingle4.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle4.InnerBorderLength = 2;
            this.hmiLedSingle4.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle4.Location = new System.Drawing.Point(1069, 231);
            this.hmiLedSingle4.LocationDialog = "1069; 231";
            this.hmiLedSingle4.MaximumHoldTime = 3000;
            this.hmiLedSingle4.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle4.MiddleBorderLength = 0;
            this.hmiLedSingle4.MinimumHoldTime = 500;
            this.hmiLedSingle4.Name = "hmiLedSingle4";
            this.hmiLedSingle4.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle4.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle4.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.hmiLedSingle4.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle4.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle4.OuterBorderLength = 2;
            this.hmiLedSingle4.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle4.OutputType = AdvancedScada.Controls.Motor.OutputType.ValveWeiCtriDialog;
            this.hmiLedSingle4.PLCAddressClick = "CH2.PLC1.DataBlock1.TAG00003";
            this.hmiLedSingle4.PLCAddressText = "";
            this.hmiLedSingle4.PLCAddressValue = "CH2.PLC1.DataBlock1.TAG00003";
            this.hmiLedSingle4.PLCAddressVisible = "";
            this.hmiLedSingle4.RoundRadius = 30;
            this.hmiLedSingle4.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle4.ShinePosition = 0.5F;
            this.hmiLedSingle4.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle4.TabIndex = 544;
            this.hmiLedSingle4.Text = "hmiLedSingle4";
            this.hmiLedSingle4.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle4.TextVisible = false;
            this.hmiLedSingle4.Value = false;
            this.hmiLedSingle4.ValueToWrite = 0;
            // 
            // hmiLedSingle5
            // 
            this.hmiLedSingle5.ArrowWidth = 20;
            this.hmiLedSingle5.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle5.BorderExteriorLength = 0;
            this.hmiLedSingle5.BorderGradientAngle = 225;
            this.hmiLedSingle5.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle5.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle5.BorderGradientRate = 0.5F;
            this.hmiLedSingle5.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle5.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle5.GradientAngle = 225;
            this.hmiLedSingle5.GradientRate = 0.6F;
            this.hmiLedSingle5.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle5.IndicatorAutoSize = true;
            this.hmiLedSingle5.IndicatorHeight = 50;
            this.hmiLedSingle5.IndicatorWidth = 50;
            this.hmiLedSingle5.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle5.InnerBorderLength = 2;
            this.hmiLedSingle5.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle5.Location = new System.Drawing.Point(863, 231);
            this.hmiLedSingle5.LocationDialog = null;
            this.hmiLedSingle5.MaximumHoldTime = 3000;
            this.hmiLedSingle5.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle5.MiddleBorderLength = 0;
            this.hmiLedSingle5.MinimumHoldTime = 500;
            this.hmiLedSingle5.Name = "hmiLedSingle5";
            this.hmiLedSingle5.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle5.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle5.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle5.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle5.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle5.OuterBorderLength = 2;
            this.hmiLedSingle5.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle5.OutputType = AdvancedScada.Controls.Motor.OutputType.MomentarySet;
            this.hmiLedSingle5.PLCAddressClick = "";
            this.hmiLedSingle5.PLCAddressText = "";
            this.hmiLedSingle5.PLCAddressValue = "";
            this.hmiLedSingle5.PLCAddressVisible = "";
            this.hmiLedSingle5.RoundRadius = 30;
            this.hmiLedSingle5.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle5.ShinePosition = 0.5F;
            this.hmiLedSingle5.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle5.TabIndex = 547;
            this.hmiLedSingle5.Text = "hmiLedSingle5";
            this.hmiLedSingle5.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle5.TextVisible = false;
            this.hmiLedSingle5.Value = true;
            this.hmiLedSingle5.ValueToWrite = 0;
            // 
            // hmiLedSingle6
            // 
            this.hmiLedSingle6.ArrowWidth = 20;
            this.hmiLedSingle6.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle6.BorderExteriorLength = 0;
            this.hmiLedSingle6.BorderGradientAngle = 225;
            this.hmiLedSingle6.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle6.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle6.BorderGradientRate = 0.5F;
            this.hmiLedSingle6.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle6.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle6.GradientAngle = 225;
            this.hmiLedSingle6.GradientRate = 0.6F;
            this.hmiLedSingle6.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle6.IndicatorAutoSize = true;
            this.hmiLedSingle6.IndicatorHeight = 50;
            this.hmiLedSingle6.IndicatorWidth = 50;
            this.hmiLedSingle6.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle6.InnerBorderLength = 2;
            this.hmiLedSingle6.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle6.Location = new System.Drawing.Point(933, 231);
            this.hmiLedSingle6.LocationDialog = null;
            this.hmiLedSingle6.MaximumHoldTime = 3000;
            this.hmiLedSingle6.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle6.MiddleBorderLength = 0;
            this.hmiLedSingle6.MinimumHoldTime = 500;
            this.hmiLedSingle6.Name = "hmiLedSingle6";
            this.hmiLedSingle6.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle6.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle6.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle6.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle6.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle6.OuterBorderLength = 2;
            this.hmiLedSingle6.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle6.OutputType = AdvancedScada.Controls.Motor.OutputType.MomentarySet;
            this.hmiLedSingle6.PLCAddressClick = "";
            this.hmiLedSingle6.PLCAddressText = "";
            this.hmiLedSingle6.PLCAddressValue = "";
            this.hmiLedSingle6.PLCAddressVisible = "";
            this.hmiLedSingle6.RoundRadius = 30;
            this.hmiLedSingle6.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle6.ShinePosition = 0.5F;
            this.hmiLedSingle6.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle6.TabIndex = 546;
            this.hmiLedSingle6.Text = "hmiLedSingle6";
            this.hmiLedSingle6.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle6.TextVisible = false;
            this.hmiLedSingle6.Value = true;
            this.hmiLedSingle6.ValueToWrite = 0;
            // 
            // hmiLedSingle7
            // 
            this.hmiLedSingle7.ArrowWidth = 20;
            this.hmiLedSingle7.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle7.BorderExteriorLength = 0;
            this.hmiLedSingle7.BorderGradientAngle = 225;
            this.hmiLedSingle7.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle7.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle7.BorderGradientRate = 0.5F;
            this.hmiLedSingle7.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle7.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle7.GradientAngle = 225;
            this.hmiLedSingle7.GradientRate = 0.6F;
            this.hmiLedSingle7.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle7.IndicatorAutoSize = true;
            this.hmiLedSingle7.IndicatorHeight = 50;
            this.hmiLedSingle7.IndicatorWidth = 50;
            this.hmiLedSingle7.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle7.InnerBorderLength = 2;
            this.hmiLedSingle7.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle7.Location = new System.Drawing.Point(724, 231);
            this.hmiLedSingle7.LocationDialog = null;
            this.hmiLedSingle7.MaximumHoldTime = 3000;
            this.hmiLedSingle7.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle7.MiddleBorderLength = 0;
            this.hmiLedSingle7.MinimumHoldTime = 500;
            this.hmiLedSingle7.Name = "hmiLedSingle7";
            this.hmiLedSingle7.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle7.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle7.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle7.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle7.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle7.OuterBorderLength = 2;
            this.hmiLedSingle7.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle7.OutputType = AdvancedScada.Controls.Motor.OutputType.MomentarySet;
            this.hmiLedSingle7.PLCAddressClick = "";
            this.hmiLedSingle7.PLCAddressText = "";
            this.hmiLedSingle7.PLCAddressValue = "";
            this.hmiLedSingle7.PLCAddressVisible = "";
            this.hmiLedSingle7.RoundRadius = 30;
            this.hmiLedSingle7.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle7.ShinePosition = 0.5F;
            this.hmiLedSingle7.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle7.TabIndex = 549;
            this.hmiLedSingle7.Text = "hmiLedSingle7";
            this.hmiLedSingle7.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle7.TextVisible = false;
            this.hmiLedSingle7.Value = true;
            this.hmiLedSingle7.ValueToWrite = 0;
            // 
            // hmiLedSingle8
            // 
            this.hmiLedSingle8.ArrowWidth = 20;
            this.hmiLedSingle8.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle8.BorderExteriorLength = 0;
            this.hmiLedSingle8.BorderGradientAngle = 225;
            this.hmiLedSingle8.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle8.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle8.BorderGradientRate = 0.5F;
            this.hmiLedSingle8.BorderGradientType = AdvancedScada.Controls.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle8.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle8.GradientAngle = 225;
            this.hmiLedSingle8.GradientRate = 0.6F;
            this.hmiLedSingle8.GradientType = AdvancedScada.Controls.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle8.IndicatorAutoSize = true;
            this.hmiLedSingle8.IndicatorHeight = 50;
            this.hmiLedSingle8.IndicatorWidth = 50;
            this.hmiLedSingle8.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle8.InnerBorderLength = 2;
            this.hmiLedSingle8.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle8.Location = new System.Drawing.Point(794, 231);
            this.hmiLedSingle8.LocationDialog = null;
            this.hmiLedSingle8.MaximumHoldTime = 3000;
            this.hmiLedSingle8.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle8.MiddleBorderLength = 0;
            this.hmiLedSingle8.MinimumHoldTime = 500;
            this.hmiLedSingle8.Name = "hmiLedSingle8";
            this.hmiLedSingle8.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle8.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle8.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle8.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle8.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle8.OuterBorderLength = 2;
            this.hmiLedSingle8.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle8.OutputType = AdvancedScada.Controls.Motor.OutputType.MomentarySet;
            this.hmiLedSingle8.PLCAddressClick = "";
            this.hmiLedSingle8.PLCAddressText = "";
            this.hmiLedSingle8.PLCAddressValue = "";
            this.hmiLedSingle8.PLCAddressVisible = "";
            this.hmiLedSingle8.RoundRadius = 30;
            this.hmiLedSingle8.Shape = AdvancedScada.Controls.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle8.ShinePosition = 0.5F;
            this.hmiLedSingle8.Size = new System.Drawing.Size(23, 28);
            this.hmiLedSingle8.TabIndex = 548;
            this.hmiLedSingle8.Text = "hmiLedSingle8";
            this.hmiLedSingle8.TextPosition = AdvancedScada.Controls.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle8.TextVisible = false;
            this.hmiLedSingle8.Value = true;
            this.hmiLedSingle8.ValueToWrite = 0;
            // 
            // hmiDigitalPanelMeter2
            // 
            this.hmiDigitalPanelMeter2.BackColor = System.Drawing.Color.Transparent;
            this.hmiDigitalPanelMeter2.BackgroundColors = AdvancedScada.Controls.DigitalDisplay.HMIDigitalPanelMeter.BackgroundColor.Black;
            this.hmiDigitalPanelMeter2.DecimalPosition = 0;
            this.hmiDigitalPanelMeter2.ForeColor = System.Drawing.Color.LightGray;
            this.hmiDigitalPanelMeter2.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiDigitalPanelMeter2.KeypadMaxValue = 0D;
            this.hmiDigitalPanelMeter2.KeypadMinValue = 0D;
            this.hmiDigitalPanelMeter2.KeypadScaleFactor = 1D;
            this.hmiDigitalPanelMeter2.KeypadText = null;
            this.hmiDigitalPanelMeter2.KeypadWidth = 300;
            this.hmiDigitalPanelMeter2.LegendText = "Text";
            this.hmiDigitalPanelMeter2.Location = new System.Drawing.Point(539, 371);
            this.hmiDigitalPanelMeter2.Name = "hmiDigitalPanelMeter2";
            this.hmiDigitalPanelMeter2.NumberOfDigits = 5;
            this.hmiDigitalPanelMeter2.PLCAddressKeypad = "CH3.PLC1.DataBlock2.TAG00019";
            this.hmiDigitalPanelMeter2.PLCAddressText = "";
            this.hmiDigitalPanelMeter2.PLCAddressValue = "CH3.PLC1.DataBlock2.TAG00019";
            this.hmiDigitalPanelMeter2.PLCAddressVisible = "";
            this.hmiDigitalPanelMeter2.Resolution = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter2.Size = new System.Drawing.Size(152, 67);
            this.hmiDigitalPanelMeter2.TabIndex = 551;
            this.hmiDigitalPanelMeter2.Text = "hmiDigitalPanelMeter2";
            this.hmiDigitalPanelMeter2.Value = 0F;
            this.hmiDigitalPanelMeter2.ValueScaleFactor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter2.ValueScaleOffset = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // hmiSimpleWebServer1
            // 
            this.hmiSimpleWebServer1.AutoStart = true;
            this.hmiSimpleWebServer1.RefreshTime = 10;
            this.hmiSimpleWebServer1.SourceForm = this;
            this.hmiSimpleWebServer1.SynchronizingObject = this;
            this.hmiSimpleWebServer1.TCPPort = 80;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 718);
            this.Controls.Add(this.hmiDigitalPanelMeter2);
            this.Controls.Add(this.hmiLedSingle7);
            this.Controls.Add(this.hmiLedSingle8);
            this.Controls.Add(this.hmiLedSingle5);
            this.Controls.Add(this.hmiLedSingle6);
            this.Controls.Add(this.hmiLedSingle3);
            this.Controls.Add(this.hmiLedSingle4);
            this.Controls.Add(this.hmiLedSingle2);
            this.Controls.Add(this.hmiLedSingle1);
            this.Controls.Add(this.Panel9);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.hmiSevenSegment21);
            this.Controls.Add(this.hmiProcessLevel3);
            this.Controls.Add(this.hmiProcessLevel2);
            this.Controls.Add(this.hmiProcessLevel1);
            this.Controls.Add(this.LBL_ReportViewer);
            this.Controls.Add(this.hmiLabel53);
            this.Controls.Add(this.hmiLabel52);
            this.Controls.Add(this.hmiLabel51);
            this.Controls.Add(this.hmiLabel50);
            this.Controls.Add(this.hmiLabel49);
            this.Controls.Add(this.hmiLabel48);
            this.Controls.Add(this.hmiLabel47);
            this.Controls.Add(this.hmiLabel43);
            this.Controls.Add(this.hmiPilotLight4);
            this.Controls.Add(this.hmiPilotLight3);
            this.Controls.Add(this.hmiPilotLight2);
            this.Controls.Add(this.hmiPilotLight1);
            this.Controls.Add(this.hmiDigitalPanelMeter1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.hmiMushroomButton1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.hmiWaterPump1);
            this.Controls.Add(this.hmiIndicator1);
            this.Controls.Add(this.hmiMotor8);
            this.Controls.Add(this.hmiMotor7);
            this.Controls.Add(this.hmiMotor6);
            this.Controls.Add(this.hmiMotor5);
            this.Controls.Add(this.hmiMotor4);
            this.Controls.Add(this.hmiMotor3);
            this.Controls.Add(this.hmiMotor2);
            this.Controls.Add(this.hmiMotor1);
            this.Controls.Add(this.P__Exit);
            this.Controls.Add(this.P_FRM_Advanced);
            this.Controls.Add(this.P_REPORT);
            this.Controls.Add(this.P_Frm_Editr);
            this.Controls.Add(this.Panel21);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Label37);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.Label35);
            this.Controls.Add(this.Label34);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.Label32);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.Label26);
            this.Controls.Add(this.LBL_Name_Silo2);
            this.Controls.Add(this.LBL_Name_Silo3);
            this.Controls.Add(this.LBL_Name_Silo4);
            this.Controls.Add(this.LBL_Name_Silo5);
            this.Controls.Add(this.LBL_Name_Silo6);
            this.Controls.Add(this.LBL_Name_Silo7);
            this.Controls.Add(this.LBL_Name_Silo8);
            this.Controls.Add(this.LBL_Name_Silo1);
            this.Controls.Add(this.Panel14);
            this.Controls.Add(this.Panel15);
            this.Controls.Add(this.Panel13);
            this.Controls.Add(this.Panel12);
            this.Controls.Add(this.Panel11);
            this.Controls.Add(this.Panel7);
            this.Controls.Add(this.Panel10);
            this.Controls.Add(this.Panel20);
            this.Controls.Add(this.Panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scade2019";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.Panel14.ResumeLayout(false);
            this.Panel15.ResumeLayout(false);
            this.Panel13.ResumeLayout(false);
            this.Panel12.ResumeLayout(false);
            this.Panel11.ResumeLayout(false);
            this.Panel7.ResumeLayout(false);
            this.Panel10.ResumeLayout(false);
            this.Panel20.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel21.ResumeLayout(false);
            this.Panel21.PerformLayout();
            this.P__Exit.ResumeLayout(false);
            this.P__Exit.PerformLayout();
            this.P_FRM_Advanced.ResumeLayout(false);
            this.P_FRM_Advanced.PerformLayout();
            this.P_REPORT.ResumeLayout(false);
            this.P_REPORT.PerformLayout();
            this.P_Frm_Editr.ResumeLayout(false);
            this.P_Frm_Editr.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.Panel9.ResumeLayout(false);
            this.Panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmiSimpleWebServer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        internal System.Windows.Forms.Label txt_datar;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label txt_sdata;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label lbl_DeyOfWeek;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label52;
        internal System.Windows.Forms.Label Label53;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.Label Label55;
        internal System.Windows.Forms.Label Label56;
        internal System.Windows.Forms.Label Label37;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label Label34;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.Panel Panel14;
        internal System.Windows.Forms.Panel Panel15;
        internal System.Windows.Forms.Panel Panel13;
        internal System.Windows.Forms.Panel Panel12;
        internal System.Windows.Forms.Panel Panel11;
        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Panel Panel10;
        internal System.Windows.Forms.Panel Panel20;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label38;
        internal System.Windows.Forms.Label Label39;
        internal System.Windows.Forms.Label Label40;
        internal System.Windows.Forms.Label LBL_Weight_old;
        internal System.Windows.Forms.Label LBL_WeightFinel;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label msg_thnk;
        internal System.Windows.Forms.Panel Panel21;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Panel P__Exit;
        internal System.Windows.Forms.Label lbl_Exit;
        internal System.Windows.Forms.Panel P_FRM_Advanced;
        internal System.Windows.Forms.Label Lbl_FRM_Advanced;
        internal System.Windows.Forms.Panel P_REPORT;
        internal System.Windows.Forms.Label LBL_REPORT;
        internal System.Windows.Forms.Panel P_Frm_Editr;
        internal System.Windows.Forms.Label lbl_frm_Editr;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_4;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_4;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_8;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_8;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_7;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_7;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_6;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_6;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_5;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_5;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_3;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_3;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_1;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_1;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_2;
        private AdvancedScada.Controls.Display.HMILabel thnk_set_2;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel20;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel19;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel18;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel17;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel25;
        private HMISevenSegment2 hmiSevenSegment1;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel23;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel24;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel21;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel22;
        private AdvancedScada.Controls.Display.HMILabel LBL_WeightSet;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel33;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel34;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel41;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel42;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel39;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel40;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel37;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel38;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel35;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel36;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel31;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel32;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel28;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel27;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel29;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel30;
        private HMIMotor hmiMotor1;
        private HMIMotor hmiMotor2;
        private HMIMotor hmiMotor3;
        private HMIMotor hmiMotor4;
        private HMIMotor hmiMotor5;
        private HMIMotor hmiMotor6;
        private HMIMotor hmiMotor7;
        private HMIMotor hmiMotor8;
        private HMISimpleLED hmiSimpleLED1;
        private HMIIndicator hmiIndicator2;
        private HMIIndicator hmiIndicator1;
        private HMIWaterPump hmiWaterPump1;
        internal System.Windows.Forms.Panel panel4;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel44;
        private AdvancedScada.Controls.Display.HMILabel thnk_rec_oil;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel46;
        private AdvancedScada.Controls.SelectorSwitch.HMIMushroomButton hmiMushroomButton1;
        internal System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label1;
        private HMIDigitalPanelMeter hmiDigitalPanelMeter1;
        private AdvancedScada.Controls.SelectorSwitch.HMIPilotLight hmiPilotLight1;
        private AdvancedScada.Controls.SelectorSwitch.HMIPilotLight hmiPilotLight2;
        private AdvancedScada.Controls.SelectorSwitch.HMIPilotLight hmiPilotLight3;
        private AdvancedScada.Controls.SelectorSwitch.HMIPilotLight hmiPilotLight4;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel43;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel47;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel48;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel49;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel50;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel51;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel52;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel53;
        private AdvancedScada.Controls.Display.HMILabel hmiLabel54;
        public System.Windows.Forms.Label LBL_BatchName;
        public System.Windows.Forms.Label LBL_Name_Silo2;
        public System.Windows.Forms.Label LBL_Name_Silo3;
        public System.Windows.Forms.Label LBL_Name_Silo4;
        public System.Windows.Forms.Label LBL_Name_Silo5;
        public System.Windows.Forms.Label LBL_Name_Silo6;
        public System.Windows.Forms.Label LBL_Name_Silo7;
        public System.Windows.Forms.Label LBL_Name_Silo8;
        public System.Windows.Forms.Label LBL_Name_Silo1;
        private System.Windows.Forms.Timer timer1;
        private AdvancedScada.Controls.Display.HMILabel LBL_ReportViewer;
        private AdvancedScada.Controls.ProcessAll.HMIProcessIndicator hmiProcessLevel1;
        private AdvancedScada.Controls.ProcessAll.HMIProcessIndicator hmiProcessLevel2;
        private AdvancedScada.Controls.ProcessAll.HMIProcessIndicator hmiProcessLevel3;
        private HMISimpleLED hmiSimpleLED2;
        private HMISevenSegment2 hmiSevenSegment21;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel9;
        internal System.Windows.Forms.Label Label3;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private Controls.Leds.HMILedSingle hmiLedSingle1;
        private Controls.Leds.HMILedSingle hmiLedSingle2;
        private Controls.Leds.HMILedSingle hmiLedSingle3;
        private Controls.Leds.HMILedSingle hmiLedSingle4;
        private Controls.Leds.HMILedSingle hmiLedSingle5;
        private Controls.Leds.HMILedSingle hmiLedSingle6;
        private Controls.Leds.HMILedSingle hmiLedSingle7;
        private Controls.Leds.HMILedSingle hmiLedSingle8;
        private HMIDigitalPanelMeter hmiDigitalPanelMeter2;
        private Controls.Components.HMISimpleWebServer hmiSimpleWebServer1;
    }
}