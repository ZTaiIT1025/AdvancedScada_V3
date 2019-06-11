using System;
using System.Windows.Forms;
using AdvancedScada.Management.SQLManager;
using AdvancedScada.Utils.DriverLinkToSQL;
using DevExpress.XtraEditors;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Studio.DriverLinkToSQL
{
    public delegate void EventTableChanged(Table db);
    public partial class AddTable : XtraForm
    {
        private readonly Server ch;
        private readonly Table db;
        private readonly DataBase dv;
        public EventTableChanged eventTableChanged = null;
        public AddTable()
        {
            InitializeComponent();
        }
        public AddTable(Server chParam, DataBase dvParam, Table dbParam = null)
        {
            InitializeComponent();

            ch = chParam;
            dv = dvParam;
            db = dbParam;

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDataBaseName.Text)
                    || string.IsNullOrWhiteSpace(txtDataBaseName.Text))
                {
                    DxErrorProvider1.SetError(txtDataBaseName, "The Table name is empty");
                }
                else
                {
                    DxErrorProvider1.ClearErrors();
                    if (db == null)
                    {
                        var TableNew = new Table();
                        TableNew.TableId = dv.Tables.Count + 1;

                        TableNew.TableName = txtTableName.Text;
                        TableNew.Description = txtDescription.Text;
                        TableManager.Add(dv, TableNew);
                        if (eventTableChanged != null) eventTableChanged(TableNew);
                        Close();
                    }
                    else
                    {
                        db.TableId = (short)txtTableId.Value;
                        db.TableName = txtTableName.Text;
                        db.Description = txtDescription.Text;

                        TableManager.Update(dv, db);
                        if (eventTableChanged != null) eventTableChanged(db);
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

        private void AddTable_Load(object sender, EventArgs e)
        {
            try
            {
                if (db == null)
                {
                    Text = "Add Table";
                    txtServerId.Text = Convert.ToString(ch.ServerId);
                    txtServerName.Text = ch.ServerName;
                    txtDataBaseId.Text = Convert.ToString(dv.DataBaseId);
                    txtDataBaseName.Text = dv.DataBaseName;
                    txtTableId.Text = Convert.ToString(dv.Tables.Count + 1);
                    var linkToSql = new LinkToSQL();
                    txtTableName.Properties.Items.AddRange(linkToSql.AddTable(ch.ServerName, dv.DataBaseName));
                }
                else
                {
                    Text = "Edit Table";
                    txtTableId.Text = Convert.ToString(db.TableId);
                    txtTableName.Text = db.TableName;
                    txtDescription.Text = db.Description;

                }
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

        }
    }
}