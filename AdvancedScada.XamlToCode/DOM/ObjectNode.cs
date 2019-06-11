using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Markup;
using System.Xaml;
using System.Xaml.Schema;
namespace AdvancedScada.XamlToCode.DOM
{
    [DebuggerDisplay("<{Type.Name}>")]
    [ContentProperty("MemberNodes")]
    public class ObjectNode : ItemNode, IXamlTypeResolver
    {

        private Dictionary<string, NamespaceDeclaration> _NamespaceNodes;

        private NodeCollection<MemberNode> _PropertyNodes;

        private XamlSchemaContext _SchemaContext;
        [DefaultValue(null)] public XamlType Type { get; set; }

        public bool IsGetObject { get; set; }

        [DefaultValue(null)] public string XmlLang { get; set; }
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NodeCollection<MemberNode> MemberNodes
        {
            get
            {
                if (_PropertyNodes == null)
                    _PropertyNodes = new NodeCollection<MemberNode>(this);
                return _PropertyNodes;
            }
        }
        public XamlSchemaContext SchemaContext
        {
            get
            {
                if (_SchemaContext != null)
                    return _SchemaContext;
                if (ParentMemberNode != null)
                    return ParentMemberNode.SchemaContext;
                return null;
            }
            set => _SchemaContext = value;
        }
        public Type Resolve(string qualifiedTypeName)
        {
            var colon = qualifiedTypeName.IndexOf(':');
            var prefix = "";
            if (colon > -1) prefix = qualifiedTypeName.Substring(0, colon);
            var xmlNs = LookupNamespaceByPrefix(prefix);
            if (xmlNs == null)
                return null;
            var typeName = qualifiedTypeName.Substring(colon + 1);

            var referencedXamlType = SchemaContext.GetXamlType(new XamlTypeName(xmlNs, typeName));

            return referencedXamlType == null || referencedXamlType.UnderlyingType == null
                ? null
                : referencedXamlType.UnderlyingType;
        }

        public string LookupNamespaceByPrefix(string prefix)
        {
            if (_NamespaceNodes != null && _NamespaceNodes.ContainsKey(prefix)) return _NamespaceNodes[prefix].Namespace;
            if (ParentMemberNode != null)
                return ParentMemberNode.LookupNamespaceByPrefix(prefix);
            return null;
        }
    }
}
