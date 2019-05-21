using AdvancedScada.Controls.Properties;
using AdvancedScada.Monitor;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace AdvancedScada.Controls.DialogEditor
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class TestDialogEditor : UITypeEditor
    {
        private string TypeForms;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // Indicates that this editor can display a Form-based interface.
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Attempts to obtain an IWindowsFormsEditorService.
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (ReferenceEquals(edSvc, null)) return null;


            using (var form = new MonitorForm(value.ToString()))
            {
                if (edSvc.ShowDialog(form) == DialogResult.OK) return form.lblSelectedTag.Caption;
            }

            return value;
        }
    }
}