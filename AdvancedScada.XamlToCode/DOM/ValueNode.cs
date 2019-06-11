using System.ComponentModel;
using System.Diagnostics;
namespace AdvancedScada.XamlToCode.DOM
{
    [DebuggerDisplay("{Value}")]
    public class ValueNode : ItemNode
    {
        [DefaultValue(null)] public object Value { get; set; }
    }
}
