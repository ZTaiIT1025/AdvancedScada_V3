using System;
using System.Text.RegularExpressions;
namespace AdvancedScada.ConvertControls.Parsers
{
    internal class BindingParser : ParserBase
    {

        private static readonly Regex BindingRegex = new Regex(@"\{([\w]+)(\s+\w+=\w+)*\}");

        private static readonly Regex BindingPropertyRegex = new Regex(@"(\w+)=(\w+)");
        public BindingParser(XamlConvertor.State state)
            : base(state)
        {
        }

        public string Parse(string text)
        {
            var match = BindingRegex.Match(text);

            if (!match.Success)
                throw new InvalidOperationException();

            var type = GetTypeFromXName(match.Groups[1].Value);

            var variableName = CreateObject(type, type.Name);
            foreach (Capture capture in match.Groups[2].Captures)
            {
                var propertyMatch = BindingPropertyRegex.Match(capture.Value);
                if (!propertyMatch.Success)
                    throw new InvalidOperationException();
                SetProperty(variableName, type, propertyMatch.Groups[1].Value, propertyMatch.Groups[2].Value);
            }

            return variableName;
        }
    }
}
