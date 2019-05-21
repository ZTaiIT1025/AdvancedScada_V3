
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Hydraulic
{
    public class HMIPump : Control
    {
        private ArrayList m_Images = new ArrayList();

        private int m_Count = 1;
        public Timer Tmr_Move = new Timer();
        private bool _Value;
        private Bitmap LightOnImage;
        #region MY
        public HMIPump()
        {

            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            Tmr_Move.Tick += Tmr_Move_Tick;
            Tmr_Move.Interval = 100;

            LightOnImage = Properties.Resources.p_h;
            this.BackgroundImage = LightOnImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.Transparent;



        }
        public enum ShowPump
        {
            Blou,
            Blak,
            None
        }
        private ShowPump m_Show = ShowPump.Blou;
        public ShowPump ShowPumps
        {
            get
            {
                return m_Show;
            }
            set
            {
                m_Show = value;
                ShowPumpRotation(m_Show, m_Rotation);
            }
        }
        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            this.BackgroundImage = LightOnImage;
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);
            this.BackgroundImage = LightOnImage;
        }
        public enum UPORDewn
        {
            UP,
            Dewn
        }
        private UPORDewn m_UPORDewn = UPORDewn.Dewn;
        public UPORDewn UPORDewns
        {
            get
            {
                return m_UPORDewn;
            }
            set
            {
                m_UPORDewn = value;
                if (value == UPORDewn.Dewn)
                {
                    m_Count = 1;
                }
                else if (value == UPORDewn.UP)
                {
                    m_Count = 4;
                }
                this.Invalidate();
            }
        }

        private void Tmr_Move_Tick(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (m_Show == ShowPump.Blou)
                {
                    if (m_UPORDewn == UPORDewn.Dewn)
                    {
                        m_Count = (m_Count + 1) % 4;
                        this.BackgroundImage = (System.Drawing.Image)m_Images[m_Count];
                    }
                    else if (m_UPORDewn == UPORDewn.UP)
                    {
                        if (m_Count == 0)
                        {
                            m_Count = 4;
                        }
                        m_Count = (m_Count - 1) % 4;
                        this.BackgroundImage = (System.Drawing.Image)m_Images[m_Count];
                    }
                }
                else if (m_Show == ShowPump.Blak)
                {
                    if (m_UPORDewn == UPORDewn.Dewn)
                    {
                        m_Count = (m_Count + 1) % 4;
                        this.BackgroundImage = (System.Drawing.Image)m_Images[m_Count];
                    }
                    else if (m_UPORDewn == UPORDewn.UP)
                    {
                        if (m_Count == 0)
                        {
                            m_Count = 4;
                        }
                        m_Count = (m_Count - 1) % 4;
                        this.BackgroundImage = (System.Drawing.Image)m_Images[m_Count];
                    }

                }
                this.Invalidate();
            }
            catch (Exception ex)
            {
                return;
            }


        }


        public bool Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
                if (value == true)
                {
                    Tmr_Move.Enabled = true;
                }
                else if (value == false)
                {

                    Tmr_Move.Enabled = false;

                }

                this.Invalidate();
            }
        }

        public OutputType m_OutputType;
        public OutputType OutputTypes
        {
            get
            {
                return this.m_OutputType;
            }
            set
            {
                this.m_OutputType = value;
            }
        }
        public enum OutputType
        {
            // Fields
            MomentaryReset = 1,
            MomentarySet = 0,
            SetFalse = 3,
            SetTrue = 2,
            Toggle = 4,
            WriteValue = 5
        }
        public enum RotateFlipMY
        {
            // Fields
            Rotate180,
            Rotate90,
            Rotate270,
            RotateNone

        }
        private void ShowPumpRotation(ShowPump n_Show, RotateFlipMY m_Rotation)
        {
            m_Images.Clear();

            if (m_Rotation == RotateFlipMY.Rotate180 && n_Show == ShowPump.Blou)
            {
                m_Images.Add(Properties.Resources._1_v);
                m_Images.Add(Properties.Resources._2_v);
                m_Images.Add(Properties.Resources._3_v);
                m_Images.Add(Properties.Resources._4_v);
                LightOnImage = Properties.Resources._1_v;
                this.BackgroundImage = Properties.Resources._1_v;
            }
            else if (m_Rotation == RotateFlipMY.Rotate90 && n_Show == ShowPump.Blou)
            {
                m_Images.Add(Properties.Resources._1);
                m_Images.Add(Properties.Resources._2);
                m_Images.Add(Properties.Resources._3);
                m_Images.Add(Properties.Resources._4);
                LightOnImage = Properties.Resources._1;
                this.BackgroundImage = Properties.Resources._1;
            }
            else if (m_Rotation == RotateFlipMY.Rotate270 && n_Show == ShowPump.Blou)
            {
                m_Images.Add(Properties.Resources._1_vY);
                m_Images.Add(Properties.Resources._2_vY);
                m_Images.Add(Properties.Resources._3_vY);
                m_Images.Add(Properties.Resources._4_vY);
                LightOnImage = Properties.Resources._1_vY;
                this.BackgroundImage = Properties.Resources._1_vY;
            }
            else if (m_Rotation == RotateFlipMY.RotateNone && n_Show == ShowPump.Blou)
            {
                m_Images.Add(Properties.Resources._1N);
                m_Images.Add(Properties.Resources._2N);
                m_Images.Add(Properties.Resources._3N);
                m_Images.Add(Properties.Resources._4N);
                LightOnImage = Properties.Resources._1N;
                this.BackgroundImage = Properties.Resources._1N;
            }
            else if (m_Rotation == RotateFlipMY.RotateNone && n_Show == ShowPump.Blak)
            {

                m_Images.Add(Properties.Resources._1p);
                m_Images.Add(Properties.Resources._2p);
                m_Images.Add(Properties.Resources._3p);
                m_Images.Add(Properties.Resources._4p);
                LightOnImage = Properties.Resources._1p;
                BackgroundImage = Properties.Resources._1p;
            }
            else
            {
                LightOnImage = Properties.Resources.p_h;
                BackgroundImage = Properties.Resources.p_h;
            }
            this.Invalidate();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle |= 32;
                return cp;
                return base.CreateParams;
            }
        }
        private RotateFlipMY m_Rotation;
        private bool BackNeedsRefreshed;
        public RotateFlipMY Rotation
        {
            get
            {
                return this.m_Rotation;
            }
            set
            {
                if (this.m_Rotation != value)
                {
                    this.m_Rotation = value;
                    this.BackNeedsRefreshed = true;
                    ShowPumpRotation(m_Show, m_Rotation);
                }
                this.Invalidate();
            }
        }
        #endregion

    }


}