using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdvancedScada.Utils
{
    public static class PC
    {
        /// <summary>
        ///     Lock WorkStation
        /// </summary>
        [DllImport("user32.dll")]
        public static extern void LockWorkStation();

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);

        /// <summary>
        ///     Lock WorkStation
        /// </summary>
        public static void Lock()
        {
            LockWorkStation();
        }

        /// <summary>
        ///     Logoff
        /// </summary>
        public static void LogOff()
        {
            ExitWindowsEx(0, 0);
        }

        /// <summary>
        ///     Reboot
        /// </summary>
        public static void Reboot()
        {
            Process.Start("shutdown", "-r -t 00");
        }

        /// <summary>
        ///     Shutdown
        /// </summary>
        public static void Shutdown()
        {
            Process.Start("shutdown", "-s -t 00");
        }

        /// <summary>
        ///     Force LogOff
        /// </summary>
        public static void ForceLogOff()
        {
            ExitWindowsEx(4, 0);
        }

        /// <summary>
        ///     Hibernate
        /// </summary>
        public static void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        /// <summary>
        ///     Stand By
        /// </summary>
        public static void StandBy()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }
    }
}
