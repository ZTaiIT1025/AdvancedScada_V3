using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Management.Editors
{
    public partial class XDataBlockForm : UserControl
    {
        public Channel ch;
        public DataBlock db;
        public Device dv;
        public EventDataBlockChanged eventDataBlockChanged = null;
        public XDataBlockForm()
        {
            InitializeComponent();
        }
    }
}