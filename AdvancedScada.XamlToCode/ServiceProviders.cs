using System;
using System.Collections.Generic;
using System.Windows.Markup;
using System.Xaml;
namespace AdvancedScada.XamlToCode
{
    public class CamlContext
    {
        public CamlContext()
        {
            Stack = new Stack<Frame>();
        }

        public Uri BaseUri { get; set; }

        public Stack<Frame> Stack { get; set; }

        public XamlSchemaContext SchemaContext { get; set; }

        public class Frame
        {
            public XamlType Type { get; set; }
            public object Instance { get; set; }
            public XamlMember Member { get; set; }
            public List<NamespaceDeclaration> Namespaces { get; set; }
        }
    }

    internal class ServiceProviders : IServiceProvider, IXamlTypeResolver, IAmbientProvider,
        IXamlNameResolver, IXamlNamespaceResolver, IRootObjectProvider, IXamlObjectWriterFactory, IXamlSchemaContextProvider,
        IUriContext, IProvideValueTarget
    {

        private readonly CamlContext _context;
        public ServiceProviders(CamlContext context)
        {
            _context = context;
        }

        IEnumerable<AmbientPropertyValue> IAmbientProvider.GetAllAmbientValues(IEnumerable<XamlType> ceilingTypes, params XamlMember[] properties)
        {
            throw new NotImplementedException();
        }

        AmbientPropertyValue IAmbientProvider.GetFirstAmbientValue(IEnumerable<XamlType> ceilingTypes, params XamlMember[] properties)
        {
            throw new NotImplementedException();
        }

        object IProvideValueTarget.TargetObject => _context.Stack.Peek().Instance;

        object IProvideValueTarget.TargetProperty => _context.Stack.Peek().Member;

        object IRootObjectProvider.RootObject => _context.Stack.ToArray()[0].Instance;

        object IServiceProvider.GetService(Type serviceType)
        {
            if (serviceType == typeof(IXamlTypeResolver)) return this;
            if (serviceType == typeof(IUriContext)) return this;
            //if (serviceType == typeof(IXamlTypeResolver2))
            //{
            //    return this;
            //}
            //if (serviceType == typeof(IAmbientPropertyProvider))
            //{
            //    return this;
            //}
            //if (serviceType == typeof(IXamlTextSyntax))
            //{
            //    return this;
            //}
            if (serviceType == typeof(IXamlSchemaContextProvider)) return this;
            if (serviceType == typeof(IProvideValueTarget)) return this;
            if (serviceType == typeof(IRootObjectProvider)) return this;
            if (serviceType == typeof(IXamlNamespaceResolver)) return this;
            if (serviceType == typeof(IXamlNameResolver)) return this;
            if (serviceType == typeof(IXamlObjectWriterFactory)) throw new NotImplementedException();

            return null;
        }

        Uri IUriContext.BaseUri
        {
            get => _context.BaseUri;
            set => throw new NotSupportedException();
        }

        IEnumerable<KeyValuePair<string, object>> IXamlNameResolver.GetAllNamesAndValuesInScope()
        {
            throw new NotImplementedException();
        }

        event EventHandler IXamlNameResolver.OnNameScopeInitializationComplete
        {
            add => throw new NotImplementedException();
            remove => throw new NotImplementedException();
        }

        object IXamlNameResolver.Resolve(string name)
        {
            throw new NotImplementedException();
        }

        string IXamlNamespaceResolver.GetNamespace(string prefix)
        {
            throw new NotImplementedException();
        }

        IEnumerable<NamespaceDeclaration> IXamlNamespaceResolver.GetNamespacePrefixes()
        {
            throw new NotImplementedException();
        }

        XamlObjectWriterSettings IXamlObjectWriterFactory.GetParentSettings()
        {
            throw new NotImplementedException();
        }

        XamlObjectWriter IXamlObjectWriterFactory.GetXamlObjectWriter(XamlObjectWriterSettings settings)
        {
            throw new NotImplementedException();
        }

        XamlSchemaContext IXamlSchemaContextProvider.SchemaContext => _context.SchemaContext;

        Type IXamlTypeResolver.Resolve(string qualifiedTypeName)
        {
            throw new NotImplementedException();
        }

        #region IAmbientProvider Members

        IEnumerable<AmbientPropertyValue> IAmbientProvider.GetAllAmbientValues(IEnumerable<XamlType> ceilingTypes, bool searchLiveStackOnly, IEnumerable<XamlType> types,
            params XamlMember[] properties)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> IAmbientProvider.GetAllAmbientValues(params XamlType[] types)
        {
            throw new NotImplementedException();
        }

        object IAmbientProvider.GetFirstAmbientValue(params XamlType[] types)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IXamlNameResolver Members

        object IXamlNameResolver.GetFixupToken(IEnumerable<string> names, bool canAssignDirectly)
        {
            throw new NotImplementedException();
        }

        object IXamlNameResolver.GetFixupToken(IEnumerable<string> names)
        {
            throw new NotImplementedException();
        }

        bool IXamlNameResolver.IsFixupTokenAvailable => throw new NotImplementedException();

        object IXamlNameResolver.Resolve(string name, out bool isFullyInitialized)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
