using DevExpress.XtraSplashScreen;
using System;

namespace AdvancedScada.HMI
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {


        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}