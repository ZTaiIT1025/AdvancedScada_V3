
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.Controls.Utility;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;

using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.Display

{
    [Designer(typeof(HMIEditorDesigner))]
    [ToolboxBitmap(typeof(HMITextEditor), "HMIEditor.ico")]
    [ToolboxItem(true)]
    public class HMITextEditor : System.Windows.Forms.TextBox
    {


        private string m_PLCAddressValue = string.Empty;

        public HMITextEditor()
        {
            InitializeComponents();
        }



        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressValue
        {
            get { return m_PLCAddressValue; }
            set
            {
                if (m_PLCAddressValue != value) m_PLCAddressValue = value;
            }
        }


        private void HMIEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (string.IsNullOrEmpty(PLCAddressValue) ? true : string.IsNullOrWhiteSpace(PLCAddressValue))
                    {
                        Utility.Utility.ShowTagNameInvalidMessage(this, Name);
                    }
                    else if (TagCollectionClient.Tags[PLCAddressValue] != null)
                    {
                        dynamic text = Text;


                        WCFChannelFactory.Write(PLCAddressValue, text);
                    }
                    else
                    {
                        Utility.Utility.ShowTagInvalidMessage(this, Name);
                    }
                }
            }
            catch (Exception exception1)
            {
                var exception = exception1;
                MessageBox.Show(this, exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void InitializeComponents()
        {
            BorderStyle = BorderStyle.Fixed3D;
            Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            TextAlign = HorizontalAlignment.Right;
            BorderStyle = BorderStyle.Fixed3D;
            KeyDown += HMIEditor_KeyDown;
        }
    }

    internal class HMIEditorDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIEditorListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMIEditorListItem : DesignerActionList
    {
        private readonly HMITextEditor _HMIEditor;

        public HMIEditorListItem(HMIEditorDesigner owner) : base(owner.Component)
        {
            _HMIEditor = (HMITextEditor)owner.Component;
        }

        public bool AutoSize
        {
            get { return _HMIEditor.AutoSize; }
            set { _HMIEditor.AutoSize = value; }
        }

        public Color BackColor
        {
            get { return _HMIEditor.BackColor; }
            set { _HMIEditor.BackColor = value; }
        }

        public BorderStyle BorderStyle
        {
            get { return _HMIEditor.BorderStyle; }
            set { _HMIEditor.BorderStyle = value; }
        }


        public Font Font
        {
            get { return _HMIEditor.Font; }
            set { _HMIEditor.Font = value; }
        }

        public Color ForeColor
        {
            get { return _HMIEditor.ForeColor; }
            set { _HMIEditor.ForeColor = value; }
        }

        public string PLCAddressValue
        {
            get { return _HMIEditor.PLCAddressValue; }
            set
            {
                _HMIEditor.PLCAddressValue = value;
                _HMIEditor.Invalidate();
            }
        }

        public HorizontalAlignment TextAlign
        {
            get { return _HMIEditor.TextAlign; }
            set { _HMIEditor.TextAlign = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var designerActionItemCollection = new DesignerActionItemCollection();
            designerActionItemCollection.Add(new DesignerActionTextItem("HMI Professional Edition",
                "HMI Professional Edition"));
            designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("BorderStyle", "BorderStyle"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("Font", "Font"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("TextAlign", "TextAlign"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("AutoSize", "AutoSize"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("PLCAddressValue", "PLCAddressValue"));
            designerActionItemCollection.Add(new DesignerActionPropertyItem("DataType", "DataType"));
            return designerActionItemCollection;
        }

        public void SetProperty(System.Windows.Forms.TextBox control, string propertyName, object value)
        {
            var item = TypeDescriptor.GetProperties(control)[propertyName];
            item.SetValue(control, value);
        }

        private void ShowTagListForm()
        {
            var frm = new MonitorForm(PLCAddressValue);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(_HMIEditor)["TagName"];
                pd.SetValue(_HMIEditor, tagName);
            };
        }
    }
}