using AdvancedScada.DriverBase.Comm;
using HslCommunication;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdvancedScada.DriverBase
{
    public interface IDriverAdapter
    {
        bool IsConnected { get; set; }
      
        void Connection();

        void Disconnection();

        TValue[] Read<TValue>(string address, ushort length);


        bool  Write(string address, dynamic value);

    }

    public class DemoUtils
    {
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T">类型对象</typeparam>
        /// <param name="result">读取的结果值</param>
        /// <param name="address">地址信息</param>
        /// <param name="textBox">输入的控件</param>
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

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result">写入的结果信息</param>
        /// <param name="address">地址信息</param>
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

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result">写入的结果信息</param>
        /// <param name="address">地址信息</param>
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
