using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.Controls.Components
{
    public class HMISoundPlayer : System.ComponentModel.Component
    {
        public HMISoundPlayer() : base()
        {

        }
        public HMISoundPlayer(System.ComponentModel.IContainer container) : this()
        {

            //Required for Windows.Forms Class Composition Designer support
            if (container != null)
            {
                container.Add(this);
            }
        }

        #region Properties
        private string m_FileFolder = "C:\\Windows\\Media\\";
        [System.ComponentModel.BrowsableAttribute(true), System.ComponentModel.EditorAttribute(typeof(FileFolderEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string FileFolder
        {
            get
            {
                return m_FileFolder;
            }
            set
            {
                if (value.Length > 0)
                {
                    //* Remove the last back slash if it is there
                    if (value.Substring(value.Length - 1, 1) == "\\")
                    {
                        value = value.Substring(0, value.Length - 1);
                    }
                    m_FileFolder = value;
                }
            }
        }

        private string m_SoundFileName = "tada.wav";
        public string SoundFileName
        {
            get
            {
                return m_SoundFileName;
            }
            set
            {
                if (m_SoundFileName != value)
                {
                    m_SoundFileName = value;
                }
            }
        }

        public enum TriggerTypeOptions
        {
            PositiveChange,
            NegativeChange,
            AnyChange
        }
        private TriggerTypeOptions m_TriggerType = TriggerTypeOptions.AnyChange;
        public TriggerTypeOptions TriggerType
        {
            get
            {
                return m_TriggerType;
            }
            set
            {
                m_TriggerType = value;
            }
        }

        private bool m_Enabled = true;
        public bool Enabled
        {
            get
            {
                return m_Enabled;
            }
            set
            {
                m_Enabled = value;
            }
        }
        #endregion

        #region Constructor/Destructor
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion


    }
}
