using AdvancedScada.BaseService;
using AdvancedScada.BaseService.Client;
using AdvancedScada.DataAccess;
using AdvancedScada.DriverBase;
using AdvancedScada.HMI.Tools;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.ReportViewer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Windows.Forms;
using static AdvancedScada.HMI.Tools.Tools;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.HMI.MainForm
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region Filed
        protected DateTime myFrom;
        public double[] TankMixWeight;
        private double[] TankMixWeightFinel;
        #endregion

        public IReadService client = null;


        public MainForm()
        {
            try
            {

                ReadServiceCallbackClient.LoadTagCollection();
                XCollection.CURRENT_MACHINE = new Machine
                {
                    MachineName = Environment.MachineName,
                    Description = "Free"
                };
                IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress iPAddress in hostAddresses)
                {
                    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        XCollection.CURRENT_MACHINE.IPAddress = $"{iPAddress}";
                        break;
                    }
                }
                client = DriverHelper.GetInstance().GetReadService();
                client.Connect(XCollection.CURRENT_MACHINE);

            }
            catch (CommunicationException ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Work(lbl_DeyOfWeek);



            var readValue = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "Name", null);
            TankMixWeightRC[0] = thnk_rec_1;
            TankMixWeightRC[1] = thnk_rec_2;
            TankMixWeightRC[2] = thnk_rec_3;
            TankMixWeightRC[3] = thnk_rec_4;
            TankMixWeightRC[4] = thnk_rec_5;
            TankMixWeightRC[5] = thnk_rec_6;
            TankMixWeightRC[6] = thnk_rec_7;
            TankMixWeightRC[7] = thnk_rec_8;


            LBL_Name_Silo1.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo1", null));
            LBL_Name_Silo2.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo2", null));
            LBL_Name_Silo3.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo3", null));
            LBL_Name_Silo4.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo4", null));
            LBL_Name_Silo5.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo5", null));
            LBL_Name_Silo6.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo6", null));
            LBL_Name_Silo7.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo7", null));
            LBL_Name_Silo8.Text = Convert.ToString(Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo8", null));


            // Add any initialization after the InitializeComponent() call.
            TankNameSelected[0] = LBL_Name_Silo1;
            TankNameSelected[1] = LBL_Name_Silo2;
            TankNameSelected[2] = LBL_Name_Silo3;
            TankNameSelected[3] = LBL_Name_Silo4;
            TankNameSelected[4] = LBL_Name_Silo5;
            TankNameSelected[5] = LBL_Name_Silo6;
            TankNameSelected[6] = LBL_Name_Silo7;
            TankNameSelected[7] = LBL_Name_Silo8;


            if (readValue == null) return;
            LBL_BatchName.Text = readValue.ToString();
            DataTable dt = new DataTable();

            dt = SqlDb.Get_BatchsDetails(LBL_BatchName.Text);
            for (int i = 0; i <= 11; i++)
            {
                ListTankName.Add(dt.Rows[i]["TankName"].ToString());
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client?.Disconnect(XCollection.CURRENT_MACHINE);
                // client?.Stop();

            }
            catch (CommunicationException ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void lbl_frm_Editr_Click(object sender, EventArgs e)
        {
            FRM_Editr frm = new FRM_Editr();
            frm.Show();
        }

        private void lbl_Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("الخروج من النظام", "الخروج من النظام", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo1", LBL_Name_Silo1.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo2", LBL_Name_Silo2.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo3", LBL_Name_Silo3.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo4", LBL_Name_Silo4.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo5", LBL_Name_Silo5.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo6", LBL_Name_Silo6.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo7", LBL_Name_Silo7.Text);
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\TestApp", "LBL_Name_Silo8", LBL_Name_Silo8.Text);

                    client?.Disconnect(XCollection.CURRENT_MACHINE);
                    //client.Stop();
                    Application.ExitThread();

                }
                catch (Exception ex)
                {
                   EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                }
            }
            else
            {
                return;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker1.Value = DateTime.Now;
                LBL_WeightFinel.Text =
                    $"{int.Parse(thnk_set_1.Value) + int.Parse(thnk_set_2.Value) + int.Parse(thnk_set_3.Value) + int.Parse(thnk_set_4.Value) + int.Parse(thnk_set_5.Value) + int.Parse(thnk_set_6.Value) + int.Parse(thnk_set_7.Value) + int.Parse(thnk_set_8.Value)}";
                LBL_Weight_old.Text = $"{int.Parse(LBL_WeightFinel.Text) - int.Parse(LBL_WeightSet.Value)}";
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


        }
        #region Dynamic Report
        /// <summary>
        /// دالة لتثبيت قيم واسماء التنكات المنزلة فى مكنها الصحيح
        /// </summary>
        /// <param name="TankNameDB"> اسماء الخلطة من الداتا بيز</param>
        /// <param name="TankNameSelected">اسماء الخلطة من البرنامج</param>
        /// <param name="TankMixWeightRC"> قيم التنكات المنزلة</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public double[] DynamicTankName(List<string> TankNameDB, Label[] TankNameSelected, Label[] TankMixWeightRC)
        {
            int i = 0;

            try
            {
                TankMixWeightFinel = new double[7];
                int x = Convert.ToInt32(SqlDb.GET_LAST_ID("GET_LAST_BatchWeight_ID").Rows[0].ToString());
                DateTime d = Convert.ToDateTime(DateTimePicker1.Value.ToString("yyyy/MM/dd"));


                for (i = 0; i <= 7; i++)
                {


                    if ((TankNameSelected[i].Text) == TankNameDB[0].ToString())
                    {

                        TankMixWeightFinel[0] = (NumericHelperHMI.Val(TankMixWeightFinel[0] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));


                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[1].ToString())
                    {

                        TankMixWeightFinel[1] = (NumericHelperHMI.Val(TankMixWeightFinel[1] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[2].ToString())
                    {

                        TankMixWeightFinel[2] = (NumericHelperHMI.Val(TankMixWeightFinel[2] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[3].ToString())
                    {

                        TankMixWeightFinel[3] = (NumericHelperHMI.Val(TankMixWeightFinel[3] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[4].ToString())
                    {

                        TankMixWeightFinel[4] = (NumericHelperHMI.Val(TankMixWeightFinel[4] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[5].ToString())
                    {

                        TankMixWeightFinel[5] = (NumericHelperHMI.Val(TankMixWeightFinel[5] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[6].ToString())
                    {

                        TankMixWeightFinel[6] = (NumericHelperHMI.Val(TankMixWeightFinel[6] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }
                    else if ((TankNameSelected[i].Text) == TankNameDB[7].ToString())
                    {

                        TankMixWeightFinel[7] = (NumericHelperHMI.Val(TankMixWeightFinel[7] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));

                    }

                    else
                    {
                        TankMixWeightFinel[i] = (NumericHelperHMI.Val(TankMixWeightFinel[i] + NumericHelperHMI.Val(TankMixWeightRC[i].Text)));



                    }

                }
                for (int s = 0; s <= 7; s++)
                {
                    SqlDb.ADD_BatchWeight(x, LBL_BatchName.Text, TankNameDB[s].ToString(), Convert.ToInt32(TankMixWeightFinel[s]), Convert.ToInt32(lbl_DeyOfWeek.Text), d, DateTimePicker1.Value.ToString("hh:mm:ss tt"));
                }

            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return TankMixWeightFinel;
        }
        private void LBL_ReportViewer_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                TankMixWeight = new double[12];
                if (LBL_ReportViewer.Value == "True" && ListTankName.Count > 0)
                {
                    TankMixWeight = DynamicTankName(ListTankName, TankNameSelected, TankMixWeightRC);



                    int x = Convert.ToInt32(SqlDb.GET_LAST_ID("GET_LAST_BatchFinal_ID").Rows[0][0].ToString());
                    SqlDb.InsertNameTankFinal(x, LBL_BatchName.Text, ListTankName[0], ListTankName[1], ListTankName[2], ListTankName[3],
                        ListTankName[4], ListTankName[5], ListTankName[6],
                        ListTankName[7], int.Parse(lbl_DeyOfWeek.Text), DateTime.Parse(DateTimePicker1.Value.ToString("yyyy/MM/dd")), DateTimePicker1.Value.ToString("hh:mm:ss tt"));

                    SqlDb.InsertBatchFinal(x, LBL_BatchName.Text, TankMixWeight[0], TankMixWeight[1], TankMixWeight[2], TankMixWeight[3], TankMixWeight[4], TankMixWeight[5], TankMixWeight[6], TankMixWeight[7], double.Parse(thnk_rec_oil.Text), int.Parse(lbl_DeyOfWeek.Text), DateTimePicker1.Value.ToString("yyyy/MM/dd"), DateTimePicker1.Value.ToString("hh:mm:ss tt"));


                }


            }
            catch
            {
                return;
            }

        }


        #endregion

        private void LBL_REPORT_Click(object sender, EventArgs e)
        {
            FRM_Rpot_All frm = new FRM_Rpot_All();
            frm.Show();
        }

        private void P_FRM_Advanced_Click(object sender, EventArgs e)
        {
            FRM_Advanced frm = new FRM_Advanced();
            frm.Show();
        }

        private void LBL_ReportViewer_Click(object sender, EventArgs e)
        {

        }

    }
}
