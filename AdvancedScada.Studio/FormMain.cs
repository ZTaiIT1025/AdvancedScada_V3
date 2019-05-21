using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace AdvancedScada.Studio
{
    public partial class FormMain : XtraForm
    {
        public static readonly Audio Audio = new Audio();
        public static readonly Clock Clock = new Clock();
        public static readonly ComputerInfo Info = new ComputerInfo();
        public static readonly Keyboard Keyboard = new Keyboard();
        public static readonly Mouse Mouse = new Mouse();
        public static readonly Network Network = new Network();
        public static readonly Ports Ports = new Ports();
        private int cpu1;
        private readonly int cpu2 = 0;
        private int ram;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var CPUName = Convert.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0", "ProcessorNameString", null));

            Label14.Text = CPUName;
            lblcname.Text = Environment.MachineName;
            lblcuser.Text = Environment.UserName;
            lblos.Text = Info.OSFullName;
            lblplat.Text = Environment.OSVersion.Platform.ToString();
            lblver.Text = Environment.OSVersion.Version.ToString();
            lbllang.Text = Info.InstalledUICulture.ToString();
            timer1.Enabled = true;
            timer2.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cpu1 = Convert.ToInt16(PerformanceCounter1.NextValue());
            try
            {
                //  cpu2 = Convert.ToInt16(PerformanceCounter3.NextValue());
            }
            catch
            {


            }

            ram = Convert.ToInt16(PerformanceCounter2.NextValue());

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ProgressBar1.Value < cpu1) ProgressBar1.Value += 1;
            else if (ProgressBar1.Value > cpu1) ProgressBar1.Value -= 1;
            if (ProgressBar2.Value < ram) ProgressBar2.Value += 1;
            else if (ProgressBar2.Value > ram) ProgressBar2.Value -= 1;
            if (ProgressBar3.Value < cpu2) ProgressBar3.Value += 1;
            else if (ProgressBar3.Value > cpu2) ProgressBar3.Value -= 1;
            Label3.Text = ProgressBar1.Value + "%";
            Label4.Text = ProgressBar2.Value + "%";
            Label6.Text = ProgressBar3.Value + "%";

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}