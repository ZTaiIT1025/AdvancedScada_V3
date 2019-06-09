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

namespace AdvancedScada.Studio.Logging
{
    public partial class XtraFormLogging : DevExpress.XtraEditors.XtraForm
    {
        private System.ComponentModel.BindingList<Logger> bLoggers;
        public XtraFormLogging()
        {
            InitializeComponent();
        }

        private void XtraFormLogging_Load(object sender, EventArgs e)
        {
            bLoggers = new BindingList<Logger>(Logger.Loggers);
            realTimeSource1.DataSource = bLoggers;
            GridView1.Invalidate();
        }
    }
}