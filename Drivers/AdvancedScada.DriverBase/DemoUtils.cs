using HslCommunication;
using System;
using System.Windows.Forms;
namespace AdvancedScada.DriverBase
{
    public class DemoUtils
    {
        
        public static void ReadResultRender<T>(OperateResult<T> result, string address, string textBox)
        {
            if (result.IsSuccess)
            {
                textBox=(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] {result.Content}{Environment.NewLine}");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] Read Failed {Environment.NewLine}Reason：{result.ToMessageShowString()}");
            }
        }

       
        public static void WriteResultRender(OperateResult result, string address)
        {
            if (result.IsSuccess)
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] Write Success");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString()}");
            }
        }

        
        public static void WriteResultRender(Func<OperateResult> write, string address)
        {
            try
            {
                OperateResult result = write();
                if (result.IsSuccess)
                {
                    MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] Write Success");
                }
                else
                {
                    MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] Write Failed {Environment.NewLine} Reason：{result.ToMessageShowString()}");
                }
            }
            catch (Exception ex)
            {
                //  EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                throw ex;
            }
        }

        public static byte[] BulkReadRenderResult(HslCommunication.Core.IReadWriteNet readWrite, string address, ushort length)
        {
            byte[] resultDate = null;
            try
            {
              
                OperateResult<byte[]> read = readWrite.Read(address, length);
                if (read.IsSuccess)
                {
                    resultDate= read.Content;
                }
                else
                {
                    
                }
               
            }
            catch (Exception ex)
            {
                // EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                throw ex;
            }
            return resultDate;
        }

        public static readonly string IpAddressInputWrong = "IpAddress input wrong";
        public static readonly string PortInputWrong = "Port input wrong";
        public static readonly string SlotInputWrong = "Slot input wrong";
        public static readonly string BaudRateInputWrong = "Baud rate input wrong";
        public static readonly string DataBitsInputWrong = "Data bit input wrong";
        public static readonly string StopBitInputWrong = "Stop bit input wrong";
    }
}
