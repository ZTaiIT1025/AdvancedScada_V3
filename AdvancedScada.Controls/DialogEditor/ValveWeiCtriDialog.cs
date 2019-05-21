using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AdvancedScada.Controls.DialogEditor
{
    public partial class ValveWeiCtriDialog : DevExpress.XtraEditors.XtraForm
    {
        public string PLCAddressClick { get; private set; }

        public ValveWeiCtriDialog()
        {
            InitializeComponent();
        }
        public ValveWeiCtriDialog(string _PLCAddressClick)
        {
            InitializeComponent();
            PLCAddressClick = _PLCAddressClick;

        }
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            WCFChannelFactory.Write(PLCAddressClick, "1");
        }

        private void BtnCLOSE_Click(object sender, EventArgs e)
        {
            WCFChannelFactory.Write(PLCAddressClick, "0");
        }

        private void BtnInterLoke_Click(object sender, EventArgs e)
        {

        }

        private void BtnRESET_Click(object sender, EventArgs e)
        {

        }

        private void BtnAuto_Click(object sender, EventArgs e)
        {

        }

        private void BtnMANUAL_Click(object sender, EventArgs e)
        {

        }
    }
}