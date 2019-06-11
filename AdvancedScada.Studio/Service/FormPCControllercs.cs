using System;
using AdvancedScada.Utils;
using DevExpress.XtraEditors;

namespace AdvancedScada.Studio.Service
{
    public partial class FormPCControllercs : XtraForm
    {
        public FormPCControllercs()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PC.Shutdown();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            PC.Lock();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PC.Reboot();
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            PC.StandBy();
        }

        private void btnHtbernaion_Click(object sender, EventArgs e)
        {
            PC.Hibernate();
        }

        private void btnLongoff_Click(object sender, EventArgs e)
        {
            PC.LogOff();
        }
    }
}