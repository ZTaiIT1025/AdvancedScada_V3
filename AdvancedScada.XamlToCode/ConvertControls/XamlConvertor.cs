﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using AdvancedScada.ConvertControls.Parsers;
using Microsoft.CSharp;
namespace AdvancedScada.ConvertControls
{
    public class XamlConvertor
    {


        public string ConvertToString(string xamlCode)
        {
            var dom = ConvertToDom(xamlCode);
            var compiler = new CSharpCodeProvider();
            var stringWriter = new StringWriter();
            compiler.GenerateCodeFromMember(dom, stringWriter, new CodeGeneratorOptions {BracingStyle = "C"});
            return stringWriter.ToString();
        }

        public CodeMemberMethod ConvertToDom(string xamlCode)
        {
            var state = new State();

            var root = XElement.Parse(xamlCode);

            new RootObjectParser(state).Parse(root);

            return state.Method;
        }
        internal class State
        {
            private readonly Dictionary<string, int> m_variables = new Dictionary<string, int>();

            public State()
            {
                Method = new CodeMemberMethod {Name = "Get"};
            }

            public CodeMemberMethod Method { get; set; }

            public void AddStatement(CodeStatement statement)
            {
                Method.Statements.Add(statement);
            }

            public void SetReturnType(Type returnType)
            {
                Method.ReturnType = new CodeTypeReference(returnType.Name);
            }

            public string GetVariableName(string originalName)
            {
                originalName = originalName.Substring(0, 1).ToLower() + originalName.Substring(1);
                if (m_variables.ContainsKey(originalName))
                {
                    var number = ++m_variables[originalName];
                    return originalName + number;
                }
                m_variables.Add(originalName, 1);
                return originalName;
            }
        }
    }
}
