using AdvancedScada.XamlToCode.DOM;
namespace AdvancedScada.XamlToCode
{
    public class CodeDomObjectNode : ObjectNode
    {
        public MemberNode XClassNode { get; set; }
        public MemberNode XNameNode { get; set; }
        public MemberNode XInitNode { get; set; }
        public MemberNode XPosParamsNode { get; set; }
        public MemberNode XFactoryMethodNode { get; set; }
        public MemberNode XArgumentsNode { get; set; }
        public MemberNode XKeyNode { get; set; }
        public MemberNode DictionaryKeyProperty { get; set; }
    }
}
