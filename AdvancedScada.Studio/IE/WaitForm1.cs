using System;
using DevExpress.XtraWaitForm;

namespace AdvancedScada.Studio.IE
{
    public partial class WaitForm1 : WaitForm
    {
        public enum WaitFormCommand
        {
        }

        public WaitForm1()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        private void WaitForm1_Load(object sender, EventArgs e)
        {
        }

        #region Overrides
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }
        #endregion
    }
}