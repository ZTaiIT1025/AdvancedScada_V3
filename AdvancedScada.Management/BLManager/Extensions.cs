namespace AdvancedScada.Management.BLManager
{
    public static class Extensions
    {
        public static int IsNumeric(this string strg)
        {
            var result = 0;
            var array = strg.ToCharArray();
            var numberStrg = string.Empty;
            foreach (var c in array)
                if (char.IsDigit(c))
                    numberStrg += c;
            if (!string.IsNullOrEmpty(numberStrg) && !string.IsNullOrWhiteSpace(numberStrg))
                result = int.Parse(numberStrg);
            return result;
        }
    }
}