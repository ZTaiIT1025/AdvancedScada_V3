
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class RotationValueEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;


        public RotationValueEditor()
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                this.editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (this.editorService != null)
                {
                    RotationValueEditorForm frm = new RotationValueEditorForm();
                    RotationScale frmR = (RotationScale)value;
                    frm.ValueAtMaxCCWTextBox.Text = Conversions.ToString(frmR.RotationMaxValueCCW);
                    frm.ValueAtMaxCWTextBox.Text = Conversions.ToString(frmR.RotationMaxValueCW);
                    frm.CCWRotationTextBox.Text = Conversions.ToString(frmR.RotationCCWAngle);
                    frm.CWRotationTextBox.Text = Conversions.ToString(frmR.RotationCWAngle);
                    frm.XPositionTextBox.Text = Conversions.ToString(frmR.XPosition);
                    frm.YPositionTextBox.Text = Conversions.ToString(frmR.YPosition);
                    if (this.editorService.ShowDialog(frm) == DialogResult.OK)
                    {
                        frmR.RotationMaxValueCCW = Conversions.ToSingle(frm.ValueAtMaxCCWTextBox.Text);
                        frmR.RotationMaxValueCW = Conversions.ToSingle(frm.ValueAtMaxCWTextBox.Text);
                        frmR.RotationCCWAngle = Conversions.ToSingle(frm.CCWRotationTextBox.Text);
                        frmR.RotationCWAngle = Conversions.ToSingle(frm.CWRotationTextBox.Text);
                        frmR.XPosition = Conversions.ToInteger(frm.XPositionTextBox.Text);
                        frmR.YPosition = Conversions.ToInteger(frm.YPositionTextBox.Text);
                    }
                }
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            UITypeEditorEditStyle uITypeEditorEditStyle = (!(context != null && context.Instance != null) ? base.GetEditStyle(context) : System.Drawing.Design.UITypeEditorEditStyle.Modal);
            return uITypeEditorEditStyle;
        }

        protected virtual void SetEditorProps(RotationScale editingInstance, RotationValueEditorForm editor)
        {
            editor.ValueAtMaxCCWTextBox.Text = Conversions.ToString(editingInstance.RotationMaxValueCCW);
        }
    }


}