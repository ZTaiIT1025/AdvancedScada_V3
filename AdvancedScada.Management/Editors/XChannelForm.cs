using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.BLManager;

namespace AdvancedScada.Management.Editors
{
    public partial class XChannelForm : UserControl
    {
        public Channel ch = null;
        public EventChannelChanged eventChannelChanged = null;
        public ChannelManager objChannelManager = null;
        public XChannelForm()
        {
            InitializeComponent();
        }
    }
}