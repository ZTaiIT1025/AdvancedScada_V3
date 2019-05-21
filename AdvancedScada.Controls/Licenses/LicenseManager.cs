using System.Diagnostics;

namespace AdvancedScada.Controls.Licenses
{
    public static class LicenseManager
    {
        public static bool IsInDesignMode
        {
            get
            {
                if (Process.GetCurrentProcess().ProcessName == "devenv"
                    || Process.GetCurrentProcess().ProcessName == "VCSExpress"
                    || Process.GetCurrentProcess().ProcessName == "vbexpress"
                    || Process.GetCurrentProcess().ProcessName == "WDExpress")
                    return true;
                return false;
            }
        }
    }
}