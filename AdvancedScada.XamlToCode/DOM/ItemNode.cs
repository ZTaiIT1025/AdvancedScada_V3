using System.ComponentModel;
namespace AdvancedScada.XamlToCode.DOM
{
    public abstract class ItemNode : DomNode
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public MemberNode ParentMemberNode { get; set; }
    }
}
