using AdvancedScada.Controls.Motor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.SelectorSwitch
{
    public class HMIIllumButton : Control
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            mOutputType = OutputType.MomentarySet;
            MinHoldTimer = new System.Windows.Forms.Timer();
        }

        #region Notes:
        //// Title:    IllumButton
        //// Author:   Morgan Haueisen
        //// Created:  5/24/2016

        // This software is provided "as-is," without any express or implied warranty.
        // In no event shall the author be held liable for any damages arising from the use of this software.
        // If you do not agree with these terms, do not use "IllumButton". Use of the program implicitly means
        // you have agreed to these terms.

        // Permission is granted to anyone to use this software for any purpose,
        // including commercial use, and to alter and redistribute it.
        #endregion

        #region Constructor/Destructor
        public HMIIllumButton() : base()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Padding = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(32, 32);
            this.Name = "IllumButton";
            this.Size = new System.Drawing.Size(75, 75);
            this.ResumeLayout(false);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SubscribeToEvents();
        }




        #endregion

        #region Properties and variables
        private string mErrMsg = string.Empty;
        private bool mButtonDn = false;
        private bool mValue = false;

        private System.Drawing.Image mButtonUp;
        public System.Drawing.Image Button1Up
        {
            get
            {
                return mButtonUp;
            }
            set
            {
                mButtonUp = value;
                this.Invalidate();
            }
        }
        private System.Drawing.Image mButtonPressed;
        public System.Drawing.Image Button2Pressed
        {
            get
            {
                return mButtonPressed;
            }
            set
            {
                mButtonPressed = value;
                this.Invalidate();
            }
        }
        private System.Drawing.Image mButtonOn;
        public System.Drawing.Image Button3On
        {
            get
            {
                return mButtonOn;
            }
            set
            {
                mButtonOn = value;
                this.Invalidate();
            }
        }
        private OutputType mOutputType;
        [System.ComponentModel.Category("PLC Properties")]
        public OutputType OutputType
        {
            get
            {
                return mOutputType;
            }
            set
            {
                mOutputType = value;
            }
        }
        private int m_ValueToWrite = 0;
        [System.ComponentModel.Category("PLC Properties")]
        public int ValueToWrite
        {
            get
            {
                return m_ValueToWrite;
            }
            set
            {
                m_ValueToWrite = value;
            }
        }
        #endregion

        #region Draw Button
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Image iImage = null;

            //// Get image to draw
            if (mValue)
            {
                iImage = mButtonOn;
            }
            else if (mButtonDn)
            {
                iImage = mButtonPressed;
            }
            else
            {
                iImage = mButtonUp;
            }

            //// Draw Image
            if (iImage != null)
            {
                e.Graphics.DrawImage(iImage, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Width);
            }

            if (!string.IsNullOrWhiteSpace(mErrMsg))
            {
                //// Draw Text
                StringFormat strFormat = new StringFormat();
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(mErrMsg, new Font("Arial", 8), new SolidBrush(Color.White), new Point(10, 10), strFormat);
            }

        }

        private void IllumButton_SizeChanged(object sender, EventArgs e)
        {
            //// Keep the control square so that the button is always round
            int iSize = 0;
            if (this.Width > this.Height)
            {
                iSize = this.Height;
                this.Width = iSize;
            }
            else
            {
                iSize = this.Width;
                this.Height = iSize;
            }
        }
        #endregion



        #region Button Pressed minimum hold time
        private bool mMouseIsDown;
        private bool mHoldTimeMet;

        //*****************************************
        //* Property - Hold time before bit reset
        //*****************************************

        private System.Windows.Forms.Timer _MinHoldTimer;
        private System.Windows.Forms.Timer MinHoldTimer
        {
            [System.Diagnostics.DebuggerNonUserCode]
            get
            {
                return _MinHoldTimer;
            }
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized), System.Diagnostics.DebuggerNonUserCode]
            set
            {
                if (_MinHoldTimer != null)
                {
                    _MinHoldTimer.Tick -= HoldTimer_Tick;
                }

                _MinHoldTimer = value;

                if (value != null)
                {
                    _MinHoldTimer.Tick += HoldTimer_Tick;
                }
            }
        }
        private int m_MinimumHoldTime = 500;
        [System.ComponentModel.Category("PLC Properties")]
        public int MinimumHoldTime
        {
            get
            {
                return m_MinimumHoldTime;
            }
            set
            {
                m_MinimumHoldTime = value;
                if (value > 0)
                {
                    MinHoldTimer.Interval = value;
                }
            }
        }

        private void HoldTimer_Tick(object sender, System.EventArgs e)
        {
            MinHoldTimer.Enabled = false;
            mHoldTimeMet = true;
            if (!mMouseIsDown)
            {

            }
        }


        #endregion








        //INSTANT C# NOTE: Converted event handler wireups:
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.SizeChanged += IllumButton_SizeChanged;
        }

    }
}