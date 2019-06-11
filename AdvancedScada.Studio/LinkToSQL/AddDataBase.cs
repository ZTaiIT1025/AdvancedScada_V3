using System;
using System.Windows.Forms;
using AdvancedScada.Management.SQLManager;
using AdvancedScada.Utils.DriverLinkToSQL;
using DevExpress.XtraEditors;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Studio.DriverLinkToSQL
{
    public delegate void EventDataBaseChanged(DataBase dbs);
    public partial class AddDataBase : XtraForm
    {
        private readonly DataBase dbs;
        public EventDataBaseChanged eventDataBaseChanged = null;
        private readonly Server SQl;
        public AddDataBase(Server chParam, DataBase dvPara = null)
        {
            InitializeComponent();
            SQl = chParam;
            dbs = dvPara;
        }
        public AddDataBase()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDataBaseName.Text)
                    || string.IsNullOrWhiteSpace(txtDataBaseName.Text))
                {
                    DxErrorProvider1.SetError(txtDataBaseName, "The DataBase name is empty");
                }
                else
                {
                    DxErrorProvider1.ClearErrors();
                    if (dbs == null)
                    {
                        var dbsNew = new DataBase();
                        dbsNew.DataBaseId = SQl.DataBase.Count + 1;

                        dbsNew.DataBaseName = txtDataBaseName.Text;
                        dbsNew.Description = txtDescription.Text;
                        //dvNew.DataBlocks = new List<DataBlock>();
                        DataBaseManager.Add(SQl, dbsNew);
                        if (eventDataBaseChanged != null) eventDataBaseChanged(dbsNew);
                        Close();
                    }
                    else
                    {
                        dbs.DataBaseId = (short)txtDataBaseId.Value;
                        dbs.DataBaseName = txtDataBaseName.Text;
                        dbs.Description = txtDescription.Text;

                        DataBaseManager.Update(SQl, dbs);
                        if (eventDataBaseChanged != null) eventDataBaseChanged(dbs);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XtraSQLAddDataBase_Load(object sender, EventArgs e)
        {
            try
            {
                txtServerName.Text = SQl.ServerName;
                txtServerId.Text = SQl.ServerId.ToString();

                if (dbs != null)
                {
                    Text = "Edit DataBase";
                    txtDataBaseId.Value = dbs.DataBaseId;
                    txtDataBaseName.Text = dbs.DataBaseName;

                    txtDescription.Text = dbs.Description;
                }
                else
                {
                    Text = "Add DataBase";
                    txtDataBaseId.Text = Convert.ToString(SQl.DataBase.Count + 1);
                    txtDataBaseName.Properties.Items.AddRange(LinkToSQL.AddDatabaseNames(SQl.ServerName));
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }
}