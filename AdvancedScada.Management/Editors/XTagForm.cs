using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Management.Editors
{
    public partial class XTagForm : UserControl
    {
        public Channel ch;
        public DataBlock db;
        public Device dv;
        public EventTagChanged eventTagChanged = null;
        public Tag tg;
        public XTagForm()
        {
            InitializeComponent();
        }
    }
}