using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using System.Xaml;
namespace AdvancedScada.XamlToCode.DOM
{
    [DebuggerDisplay("{Member.Name}")]
    [ContentProperty("ItemNodes")]
    public class MemberNode : DomNode
    {

        private Dictionary<string, NamespaceDeclaration> _NamespaceNodes;

        private NodeCollection<ItemNode> _ValueNodes;
        [DefaultValue(null)] public XamlMember Member { get; set; }
        [DefaultValue(null)] public string Prefix { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObjectNode ParentObjectNode { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NodeCollection<ItemNode> ItemNodes
        {
            get
            {
                if (_ValueNodes == null)
                    _ValueNodes = new NodeCollection<ItemNode>(this);
                return _ValueNodes;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Dictionary<string, NamespaceDeclaration> NamespaceNodes
        {
            get
            {
                if (_NamespaceNodes == null)
                    _NamespaceNodes = new Dictionary<string, NamespaceDeclaration>();
                return _NamespaceNodes;
            }
        }

        public XamlSchemaContext SchemaContext => ParentObjectNode.SchemaContext;

        internal string LookupNamespaceByPrefix(string prefix)
        {
            if (_NamespaceNodes != null && _NamespaceNodes.ContainsKey(prefix))
                return _NamespaceNodes[prefix].Namespace;
            return ParentObjectNode.LookupNamespaceByPrefix(prefix);
        }
    }
}
