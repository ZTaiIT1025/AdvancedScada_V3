

using AdvancedScada.IBaseService;
using System;

namespace AdvancedScada
{
    public partial class WriteTagForm
    {
        public IReadService client;

        public WriteTagForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
        }

        public WriteTagForm(string Address, IReadService client = null)
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            txtAddress.Text = Address;
            this.client = client;
            LayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void WriteTagForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.WriteTag(txtAddress.Text, NumValue.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}