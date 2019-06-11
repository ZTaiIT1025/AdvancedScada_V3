using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace AdvancedScada.HMIs.Drawing
{
	internal class HMIValveDesigner : ControlDesigner
	{
		private DesignerActionListCollection actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (actionLists == null)
				{
					actionLists = new DesignerActionListCollection();
					actionLists.Add(new HMIValveListItem(this));
				}
				return actionLists;
			}
		}
	}
}
