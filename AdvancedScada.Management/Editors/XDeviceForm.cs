using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Management.Editors
{
    public partial class XDeviceForm : UserControl
    {
        public Channel ch = null;
        public Device dv = null;
        public EventDeviceChanged eventDeviceChanged = null;
        public XDeviceForm()
        {
            InitializeComponent();
        }
    }
}