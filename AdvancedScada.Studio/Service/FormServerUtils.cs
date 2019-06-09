using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using AdvancedScada.BaseService;
using AdvancedScada.IBaseService.Common;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.Service
{
    public partial class FormServerUtils
    {
        public readonly List<ServerUtilsGrid> _ServerUtilsGrid = new List<ServerUtilsGrid>();
        public bool close = true;
        public ServiceHost host;
        public FormServerUtils()
        {

            InitializeComponent();


        }


        public static void SetLabelText(TextBox Label, string Text)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new SetLabelTextInvoker(SetLabelText), Label, Text);
            else
                Label.Text += Text;
            Application.DoEvents();
        }

        public ServiceHost InitializeTags(bool Start = false)
        {
            ServiceHost host = null;

            try
            {

                new DriverService().GetStartService();
                host = new DriverService().InitializeReadService();
                host.Opened += host_Opened;
                host.Open();

                foreach (var se in host.Description.Endpoints)
                {
                    var SUGrid = new ServerUtilsGrid();
                    SUGrid.ColDateTime = Convert.ToString(DateTime.Now);
                    SUGrid.ColBinding = se.Binding.Name.ToString();
                    SUGrid.ColAddress = se.Address.ToString();
                    _ServerUtilsGrid.Add(SUGrid);
                }

                GridControl1.DataSource = _ServerUtilsGrid;
                if (host.State == CommunicationState.Opened) txtStatus.Caption = "The Server is running";



            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


            this.Text = "ServerUtils : AdvancedScada";
            return host;
        }


        private void FormServerUtils_Load(object sender, EventArgs e)
        {




            try
            {



                XCollection.EventChannelCount += ServiceBase_eventChannelCount;

            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);

            }

            try
            {

                host = InitializeTags(true);

            }
            catch (Exception ex)
            {
                var SUGrid = new ServerUtilsGrid();
                SUGrid.ColDateTime = Convert.ToString(DateTime.Now);
                SUGrid.ColAddress = ex.Message;
                _ServerUtilsGrid.Add(SUGrid);
            }
        }

        private void ServiceBase_eventChannelCount(int ChannelCount, bool IsNew)
        {
            if (IsNew)
            {
                var ChannelCount2 = int.Parse(txtChannelCount.Caption);

                txtChannelCount.Caption = $"{ChannelCount2 + ChannelCount}";
            }
            else
            {
                var ChannelCount2 = int.Parse(txtChannelCount.Caption);

                txtChannelCount.Caption = $"{ChannelCount2 - ChannelCount}";
            }
        }

        public void host_Opened(object sender, EventArgs e)
        {

            txtStatus.Caption = "The Server is running";
        }

        private void FormServerUtils_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        internal delegate void SetLabelTextInvoker(TextBox label, string Text);
    }
}