using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AdvancedScada.Utils
{
    public delegate void GetErorr(string erorr);
    /// <summary>
    ///     Create a New INI file to store or load data
    /// </summary>
    public class IniClass
    {


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
            int size, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // INI 값 읽기
        public string GetIniValue(string Section, string Key, string iniPath)
        {
            var temp = new StringBuilder(255);
            var i = GetPrivateProfileString(Section, Key, string.Empty, temp, 255, iniPath);
            return temp.ToString();
        }

        // INI 값 설정
        public void SetIniValue(string Section, string Key, string Value, string iniPath)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }



    }
}
