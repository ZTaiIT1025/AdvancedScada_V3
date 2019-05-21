
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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class AutoToDoubleEditor : UITypeEditor
    {
        private IWindowsFormsEditorService editorService;


        private void AutoClicked(object sender, EventArgs e)
        {
            if (this.editorService != null)
            {
                this.editorService.CloseDropDown();
            }
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object obj = null;
            if (context != null && context.Instance != null && provider != null)
            {
                this.editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (this.editorService != null)
                {
                    ListBox listBox = new ListBox();
                    AutoToDoubleEditor autoToDoubleEditor = this;
                    listBox.Click += autoToDoubleEditor.AutoClicked;
                    listBox.Items.Add("Auto");
                    listBox.SetSelected(1, true);
                    listBox.Height = 20;
                    this.editorService.DropDownControl(listBox);
                    if (Operators.ConditionalCompareObjectNotEqual(listBox.SelectedItem, string.Empty, false))
                    {
                        obj = double.NaN;
                        return obj;
                    }
                }
            }
            obj = value;
            return obj;
        }

        public override UITypeEditorEditStyle GetEditStyle(
System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }


}