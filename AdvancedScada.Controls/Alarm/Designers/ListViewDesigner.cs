using System;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.Alarm.Designers
{
    public class ListViewDesigner : ControlDesigner
    {
        public override DesignerVerbCollection Verbs
        {
            get
            {
                var verbs_ = new DesignerVerbCollection();
                //* "Editor" will be added to the Smart Tags popup menu
                var dv1 = new DesignerVerb("Editor", ShowDesignerWindow);
                verbs_.Add(dv1);
                return verbs_;
            }
        }

        private void ShowDesignerWindow(object sender, EventArgs e)
        {
            if (Component != null)
            {
                var mcdf = new ListViewDesignerForm();
                mcdf.ControlToEdit = (HMIAlarmMan)Component;
                mcdf.ShowDialog();
            }
        }

        public override void DoDefaultAction() //Implements IDesigner.DoDefaultAction
        {
            //Throw New NotImplementedException()
            if (Component != null)
            {
                var mcdf = new ListViewDesignerForm();
                mcdf.ControlToEdit = (HMIAlarmMan)Component;
                mcdf.ShowDialog();
            }
        }
    }
}