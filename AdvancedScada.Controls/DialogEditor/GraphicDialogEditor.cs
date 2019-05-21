
using AdvancedScada.ImagePicker;
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
    public class GraphicDialogEditor : UITypeEditor
    {
        private string TypeLibrary;
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // Indicates that this editor can display a Form-based interface.
            return UITypeEditorEditStyle.Modal;
        }

        //INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Attempts to obtain an IWindowsFormsEditorService.
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (ReferenceEquals(edSvc, null)) return null;

            var frm = new MainView();
            frm.OnImagSelected_Clicked += ImageName1 => { value = ImageName1; };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();



            // If OK was not pressed, return the original value
            return value;
        }
    }
}