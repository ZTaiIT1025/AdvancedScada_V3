using System.Collections.Generic;
using System.Xaml;
using AdvancedScada.XamlToCode.DOM;
namespace AdvancedScada.XamlToCode
{
    public class CodeDomDomWriter : XamlWriter
    {
        private readonly Stack<DomNode> writerStack = new Stack<DomNode>();
        public CodeDomDomWriter(XamlSchemaContext schemaContext)
        {
            SchemaContext = schemaContext;
        }

        #region XamlWriter Members

        public ObjectNode RootNode;

        public override void WriteGetObject()
        {
            WriteObject(null, true);
        }

        public override void WriteStartObject(XamlType xamlType)
        {
            WriteObject(xamlType, false);
        }

        private void WriteObject(XamlType xamlType, bool isGetObject)
        {
            CodeDomObjectNode objectNode = null;
            var propertyNode = writerStack.Peek() as MemberNode;

            if (writerStack.Count > 0)
            {
                objectNode = writerStack.Peek() as CodeDomObjectNode;
                if (!(objectNode != null && objectNode.NamespaceNodes.Count > 0))
                {
                    objectNode = new CodeDomObjectNode();
                    writerStack.Push(objectNode);
                }
                else
                {
                    //root node
                    objectNode.SchemaContext = SchemaContext;
                }
            }
            else
            {
                //root node
                objectNode = new CodeDomObjectNode();
                objectNode.SchemaContext = SchemaContext;
                writerStack.Push(objectNode);
            }
            objectNode.Type = xamlType;
            objectNode.IsGetObject = isGetObject;

            if (RootNode != null)
                propertyNode.ItemNodes.Add(objectNode);
            else
                RootNode = objectNode;
        }

        public override void WriteEndObject()
        {
            writerStack.Pop();
        }

        public override void WriteStartMember(XamlMember property)
        {
            var propertyNode = new MemberNode();
            propertyNode.Member = property;

            var objectNode = (CodeDomObjectNode)writerStack.Peek();

            writerStack.Push(propertyNode);

            if (property == XamlLanguage.Name || property.DeclaringType != null && property == property.DeclaringType.GetAliasedProperty(XamlLanguage.Name))
            {
                objectNode.XNameNode = propertyNode;
            }
            else if (property == XamlLanguage.Class)
            {
                objectNode.XClassNode = propertyNode;
            }
            else if (property == XamlLanguage.Initialization)
            {
                objectNode.XInitNode = propertyNode;
            }
            else if (property == XamlLanguage.PositionalParameters)
            {
                objectNode.XPosParamsNode = propertyNode;
            }
            else if (property == XamlLanguage.FactoryMethod)
            {
                objectNode.XFactoryMethodNode = propertyNode;
            }
            else if (property == XamlLanguage.Arguments)
            {
                objectNode.XArgumentsNode = propertyNode;
            }
            else if (property == XamlLanguage.Key)
            {
                objectNode.XKeyNode = propertyNode;
            }
            else
            {
                if (property.DeclaringType != null && property == property.DeclaringType.GetAliasedProperty(XamlLanguage.Key)) objectNode.DictionaryKeyProperty = propertyNode;
                objectNode.MemberNodes.Add(propertyNode);
            }
        }

        public override void WriteEndMember()
        {
            writerStack.Pop();
        }

        public override void WriteValue(object value)
        {
            var valueNode = new ValueNode();
            valueNode.Value = value;

            //text should always be inside of a property...
            var propertyNode = (MemberNode)writerStack.Peek();
            propertyNode.ItemNodes.Add(valueNode);
        }

        public override void WriteNamespace(NamespaceDeclaration namespaceDeclaration)
        {
            CodeDomObjectNode objectNode = null;
            if (writerStack.Count == 0)
            {
                objectNode = new CodeDomObjectNode();
                writerStack.Push(objectNode);
            }
            else
            {
                objectNode = writerStack.Peek() as CodeDomObjectNode;
                if (objectNode.Type != null)
                {
                    objectNode = new CodeDomObjectNode();
                    writerStack.Push(objectNode);
                }
            }
            objectNode.NamespaceNodes.Add(namespaceDeclaration.Prefix, namespaceDeclaration);
        }

        public object Result => RootNode;

        public override XamlSchemaContext SchemaContext
        {
            get;
            //set
            //{
            //    //base.CheckSettingSchemaContext(_schemaContext, value);
            //    _schemaContext = value;
            //}
        }

        #endregion
    }
}
