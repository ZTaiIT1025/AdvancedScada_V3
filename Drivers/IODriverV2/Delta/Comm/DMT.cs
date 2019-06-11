using System;
using System.Linq;
using System.Text;

namespace AdvancedScada.XDelta.Core.Comm
{
    public class DMT
    {
        #region Filed_DMT
        public static StringBuilder req = new StringBuilder(1024);
        public static StringBuilder res = new StringBuilder(1024);

        public static byte[] strData;


        public static UInt32 data_from_dev;


        public static UInt32 data_to_dev;


        public static string strProduct;


        public static string strDev;

        public static int slave_addr = 0;


        public static int dev_qty;



        #endregion
        #region DMT
        public static System.IntPtr hDMTDll; // handle of a loaded dll , used for dynamic link

        public delegate void DelegateClose(int conn_num); // function pointer for disconnection

        // About .Net P/Invoke:

        // Declare Auto Function ABC Lib "XXX.dll" (ByVal a As Integer, ByVal b As Integer) As Integer

        // indicates that "ABC" function is imported from XXX.dll
        // XXX.dll exports a function of the same name with "ABC"
        // the return type and the parameter's data type of "ABC" 
        // must be identical with the function exported from XXX.dll

        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "LoadLibrary", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllPath);
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "FreeLibrary", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hDll);

        //// Data Access
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "RequestData", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int RequestData(int comm_type, int conn_num, int slave_addr, int func_code, ref byte sendbuf, int sendlen);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ResponseData", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ResponseData(int comm_type, int conn_num, ref int slave_addr, ref int func_code, ref byte recvbuf);

        //// Serial Communication
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "OpenModbusSerial", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int OpenModbusSerial(int conn_num, int baud_rate, int data_len, char parity, int stop_bits, int modbus_mode);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "CloseSerial", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern void CloseSerial(int conn_num);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "GetLastSerialErr", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetLastSerialErr();
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ResetSerialErr", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern void ResetSerialErr();

        //// Socket Communication
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "OpenModbusTCPSocket", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int OpenModbusTCPSocket(int conn_num, int ipaddr);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "CloseSocket", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern void CloseSocket(int conn_num);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "GetLastSocketErr", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int GetLastSocketErr();
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ResetSocketErr", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern void ResetSocketErr();
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadSelect", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadSelect(int conn_num, int millisecs);

        //// MODBUS Address Calculation
        [System.Runtime.InteropServices.DllImport("Resources\\DMT.dll", EntryPoint = "DevToAddrW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int DevToAddrW(string series, string device, int qty);

        //// Wrapped MODBUS Funcion : 0x01
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadCoilsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadCoilsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_r, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x02
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadInputsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadInputsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_r, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x03
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadHoldRegsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadHoldRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_r, StringBuilder req, StringBuilder res);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadHoldRegs32W", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadHoldRegs32W(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_r, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x04
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "ReadInputRegsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int ReadInputRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_r, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x05		   
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteSingleCoilW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteSingleCoilW(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x06
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteSingleRegW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteSingleRegW(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteSingleReg32W", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteSingleReg32W(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x0F
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteMultiCoilsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteMultiCoilsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_w, StringBuilder req, StringBuilder res);

        //// Wrapped MODBUS Funcion : 0x10
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteMultiRegsW", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteMultiRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_w, StringBuilder req, StringBuilder res);
        [System.Runtime.InteropServices.DllImport("DMT.dll", EntryPoint = "WriteMultiRegs32W", ExactSpelling = false, CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int WriteMultiRegs32W(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, ref UInt32 data_w, StringBuilder req, StringBuilder res);
        #endregion



    }
}
