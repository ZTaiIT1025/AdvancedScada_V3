using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Comm;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AdvancedScada.Studio.Service
{
    public partial class FormFrameMonitor : XtraForm
    {
        //public static BindingList<ReceptionTransmissionMessage> RequestMessages = new BindingList<ReceptionTransmissionMessage>();

        //public static BindingList<ResponseMessage> ResponseMessages = new BindingList<ResponseMessage>();

        private bool bStop;
        public FormFrameMonitor()
        {
            InitializeComponent();
        }
        private string bytesTostring(byte[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}";
            return ret;
        }
        private string stringsTostring(string[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}/";
            return ret;
        }
        private string boolsTostring(bool[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}/";
            return ret;
        }
        private void FormFrameMonitor_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bStop = false;
            try
            {
                //RequestAndResponseMessage.eventDataChanged += (Type, Result, db) =>
                //{
                //    if (bStop != true)
                //        if (chkPause.Checked != true)
                //        {


                //            if (chkButtonHex.Checked)
                //            {
                //                var hex = BitConverter.ToString(db);
                //                hex = hex.Replace("-", string.Empty);
                //                string[] row = {
                //                    Type, Result, $"{db.Length}",
                //                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}", hex
                //                };


                //                var _RequestMessage = new ReceptionTransmissionMessage();
                //                _RequestMessage.Type = row[0];
                //                _RequestMessage.Result = row[1];
                //                _RequestMessage.Size = row[2];
                //                _RequestMessage.CTime = row[3];
                //                _RequestMessage.FrameData = row[4];
                //                RequestMessages.Add(_RequestMessage);
                //                realTimeRequest.DataSource = RequestMessages;
                //                gridView1.Invalidate();

                //            }
                //            else if (chkButtonAscii.Checked)
                //            {
                //                var s = Encoding.ASCII.GetString(db).Trim();
                //                var ss = Regex.Replace(s, "[\x00]", "0");
                //                var sss = Regex.Replace(ss, "[^ -~]+", c => $"{(int)c.Value[0]:x2}");
                //                string[] row = {
                //                    Type, Result, $"{db.Length}",
                //                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}", sss
                //                };

                //                var _RequestMessage = new ReceptionTransmissionMessage();
                //                _RequestMessage.Type = row[0];
                //                _RequestMessage.Result = row[1];
                //                _RequestMessage.Size = row[2];
                //                _RequestMessage.CTime = row[3];
                //                _RequestMessage.FrameData = row[4];
                //                RequestMessages.Add(_RequestMessage);
                //                realTimeRequest.DataSource = RequestMessages;
                //                gridView1.Invalidate();
                //            }
                //            else if (chkButtonbyte.Checked)
                //            {
                //                var str = bytesTostring(db);
                //                string[] row = {
                //                    Type, Result, $"{db.Length}",
                //                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}", $"{str}"
                //                };

                //                var _RequestMessage = new ReceptionTransmissionMessage();
                //                _RequestMessage.Type = row[0];
                //                _RequestMessage.Result = row[1];
                //                _RequestMessage.Size = row[2];
                //                _RequestMessage.CTime = row[3];
                //                _RequestMessage.FrameData = row[4];
                //                RequestMessages.Add(_RequestMessage);
                //                realTimeRequest.DataSource = RequestMessages;
                //                gridView1.Invalidate();
                //            }
                //        }
                //};
            }
            catch (Exception ex)
            {

               // EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            try
            {
                //RequestAndResponseMessage.eventTransmissionChanged += (Type, Result, db) =>
                //{
                //    if (bStop != true)
                //        if (chkPause.Checked != true)
                //        {



                //            var ss = Regex.Replace(db, "[\x00]", "0");
                //            var sss = Regex.Replace(ss, "[^ -~]+", c => $"{(int)c.Value[0]:x2}");
                //            string[] row = {
                //                Type, Result, $"{db.Length}",
                //                $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}", $"{sss}"
                //            };

                //            var _RequestMessage = new ReceptionTransmissionMessage();
                //            _RequestMessage.Type = row[0];
                //            _RequestMessage.Result = row[1];
                //            _RequestMessage.Size = row[2];
                //            _RequestMessage.CTime = row[3];
                //            _RequestMessage.FrameData = row[4];
                //            RequestMessages.Add(_RequestMessage);
                //            realTimeRequest.DataSource = RequestMessages;
                //            gridView1.Invalidate();

                //        }
                //};
            }
            catch (Exception ex)
            {

              //  EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            try
            {
                //RequestAndResponseMessage.eventbDataChanged += new EventbDataChanged((Command, db) =>
                //{
                //    if (bStop != true)
                //    {


                //        if (chkPause.Checked != true)
                //        {


                //            var str = boolsTostring(db);
                //            string[] row = { "Send", Command, string.Format("{0}", db.Length), string.Format("{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")), string.Format("{0}", str) };

                //            ResponseMessage _ResponseMessage = new ResponseMessage();
                //            _ResponseMessage.Form = row[0];
                //            _ResponseMessage.Processing = row[1];
                //            _ResponseMessage.Size = row[2];
                //            _ResponseMessage.CTime = row[3];
                //            _ResponseMessage.Frame = row[4];
                //            ResponseMessages.Add(_ResponseMessage);
                //            realTimeResponse.DataSource = ResponseMessages;
                //            gridView1.Invalidate();
                //        }
                //        else
                //        {

                //        }
                //    }
                //});
            }
            catch (Exception ex)
            {

              //  EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            try
            {
                //ResponseMessages.Clear();
                //RequestMessages.Clear();
                bStop = true;
                //RequestAndResponseMessage.eventDataChanged = null;
                ////RequestAndResponseMessage.eventSDataChanged = null;
                //RequestAndResponseMessage.eventTransmissionChanged = null;
            }
            catch (Exception ex)
            {

               // EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            //Getting the location and file name of the excel to save from user.
            var saveDialog = new SaveFileDialog { Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*", FilterIndex = 1, FileName = "DataBlockName" };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                //if (TabControlMonitor.SelectedTabPage == TabPageRequest)
                //{
                //    GridRequest.ExportToXls(saveDialog.FileName);
                //}
                //else if (TabControlMonitor.SelectedTabPage == TabPageResponse)
                //{
                //    GridResponse.ExportToXls(saveDialog.FileName);
                //}
                //{

                //}

               // var err = new ErorrPLC.ErorrPLC(GetType().Name, "Export Successful");
            }


        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var val = $"{gridView1.GetRowCellValue(e.RowHandle, colType)}";


            if (val != null || val != string.Empty)
            {
                if (val == "Reception" || val == "0") e.Appearance.ForeColor = Color.Red;
                else e.Appearance.ForeColor = Color.Blue;

            }
        }
    }
}