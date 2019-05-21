using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Components
{
    public class FileFolderEditor : System.Drawing.Design.UITypeEditor
    {
        public FileFolderEditor()
        {
        }

        // Indicates whether the UITypeEditor provides a form-based (modal) dialog,  
        // drop down dialog, or no UI outside of the properties window. 
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return System.Drawing.Design.UITypeEditorEditStyle.Modal;
        }

        // Displays the UI for value selection. 
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.ShowDialog();

                return fb.SelectedPath;
            }
        }

        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }

    }
}
