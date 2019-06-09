using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Utils.Excel;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.Studio.IE
{
    public delegate void EventDataBlockImport(DataBlock db);

    public partial class FormImport
    {
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
        private readonly Channel ch;
        private readonly DataBlock db;
        private readonly Device dv;
        public EventDataBlockImport eventDataBlockChanged = null;

        public FormImport(Channel chParam = null, Device dvParam = null, DataBlock dbParam = null, Tag tgParam = null)
        {
            InitializeComponent();
            ch = chParam;
            dv = dvParam;
            db = dbParam;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (eventDataBlockChanged != null) eventDataBlockChanged(db);

            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);

            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            for (var i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SetWaitFormDescription(i + "%");
                Thread.Sleep(25);
            }

            //Close Wait Form
            SplashScreenManager.CloseForm(false);


            DialogResult = DialogResult.OK;
        }

        private void cboxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var dt = ExcelUtils.ReadExcel(btnPathFile.Text, cboxSheet.SelectedText);

                short counter = 0;
                var tag = new List<Tag>();
                tag.Clear();
                db.Tags.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    counter++;
                    var newTag = new Tag {
                        TagId = counter,
                        TagName = $"{item["TagName"]}",
                        Address =
                            $"{item["Address"]}",
                        DataType = $"{item["DataType"]}",
                        Description = $"{item["Description"]}"
                    };
                    tag.Add(newTag);
                    db.Tags.Add(newTag);
                }

                gcTag.DataSource = tag;
                gcTag.RefreshDataSource();
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        private void btnPathFile_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            openFileDialog.FileName = "*.xls";
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                btnPathFile.Text = openFileDialog.FileName;
                var sheetNames = new string[100];
                sheetNames = ExcelHelper.getExcelSheets(openFileDialog.FileName);
                cboxSheet.Properties.Items.Clear();
                cboxSheet.Properties.Items.AddRange(sheetNames);
            }
        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            txtDevice.Text = dv.DeviceName;
            txtChannel.Text = ch.ChannelName;
            txtDataBlock.Text = db.DataBlockName;
        }

        private void gcTag_Click(object sender, EventArgs e)
        {
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}