using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Display
{
    public class HMIDateTimeDisplay : System.Windows.Forms.Label
    {
        private readonly Timer UpdateTimer;

        #region Properties

        private string m_DisplayFormat = "MM/dd/yyyy hh:mm:ss";

        public string DisplayFormat
        {
            get { return m_DisplayFormat; }
            set { m_DisplayFormat = value; }
        }

        #endregion

        #region Constructor

        public HMIDateTimeDisplay()
        {
            if (ForeColor == Color.FromKnownColor(KnownColor.ControlText) || ForeColor == Color.FromArgb(0, 0, 0))
                ForeColor = Color.WhiteSmoke;

            UpdateTimer = new Timer();
            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += UpdateTick;

            UpdateTick(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                try
                {
                    if (UpdateTimer != null)
                    {
                        UpdateTimer.Enabled = false;
                        UpdateTimer.Tick -= UpdateTick;
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
        }

        #endregion

        #region Events

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (DesignMode)
                UpdateTick(this, EventArgs.Empty);
            else
                UpdateTimer.Enabled = true;
        }

        private void UpdateTick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_DisplayFormat))
                Text = DateTime.Now.ToString();
            else
                Text = DateTime.Now.ToString(m_DisplayFormat);
        }

        #endregion
    }
}