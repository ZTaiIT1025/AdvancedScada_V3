namespace AdvancedScada.Management
{
    public class Utils
    {
        public static string BitAddress(string strgParam)
        {
            return strgParam.Substring(1, strgParam.Length - 1);
        }

        public static string WordAddress(string strgParam)
        {
            return strgParam.Substring(2, strgParam.Length - 2);
        }
    }
}