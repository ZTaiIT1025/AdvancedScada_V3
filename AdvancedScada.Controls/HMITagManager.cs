using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.Controls
{
    [Designer(typeof(AdvancedScadaDesigner)), ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMIAdvancedScada), "IconControl.TagBuilder.png")]
    public partial class HMIAdvancedScada : Component
    {
        public HMIAdvancedScada()
        {

        }
    }

    internal class AdvancedScadaDesigner : ComponentDesigner
    {
        private DesignerActionListCollection actionLists;
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new AdvancedScadaListItem(this));
                }
                return actionLists;
            }
        }
    }

    internal class AdvancedScadaListItem : DesignerActionList
    {
        private HMIAdvancedScada shape;
        public AdvancedScadaListItem(ComponentDesigner owner)
            : base(owner.Component)
        {
            shape = (HMIAdvancedScada)owner.Component;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Industrial Networks", "Category1"));
            items.Add(new DesignerActionMethodItem(this,
                "ShowTagBuilderDialog", "Tag Manager"));
            return items;
        }

        public void ShowTagBuilderDialog()
        {
            //TagMangementForm objBuildTagForm = new TagMangementForm();
            //objBuildTagForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //objBuildTagForm.ShowDialog();
        }

    }
}
