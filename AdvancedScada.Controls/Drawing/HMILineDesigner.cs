using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace AdvancedScada.HMIs.Drawing
{
	internal class HMILineDesigner : ControlDesigner
	{
		private DesignerActionListCollection actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (actionLists == null)
				{
					actionLists = new DesignerActionListCollection();
					actionLists.Add(new HMILineListItem(this));
				}
				return actionLists;
			}
		}
	}
}
