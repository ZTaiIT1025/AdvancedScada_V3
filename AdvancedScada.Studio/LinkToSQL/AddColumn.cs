using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.Management.BLManager;
using AdvancedScada.Management.SQLManager;
using AdvancedScada.Utils.DriverLinkToSQL;
using DevExpress.XtraEditors;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Studio.DriverLinkToSQL
{
    public partial class AddColumn : XtraForm
    {
        public delegate void EventColumnChanged(Column tg);
        private BindingList<Tag> bS7Tags;

        private Channel ch;
        private readonly Column Co;
        private readonly DataBase DBS;

        public EventColumnChanged eventColumnChanged = null;
        private ChannelService objChannelManager;
        private DataBlockService objDataBlockManager;
        private DeviceService objDeviceManager;
        private TagService objTagManager;
        private readonly Server SQL;
        private readonly Table Tb;
        public AddColumn()
        {
            objChannelManager = ChannelService.GetChannelManager();
            objDeviceManager = DeviceService.GetDeviceManager();
            objDataBlockManager = DataBlockService.GetDataBlockManager();
            objTagManager = TagService.GetTagManager();
            InitializeComponent();
        }

        public AddColumn(Server SQLParam, DataBase dbsParam, Table tbParam, Column coParam = null)

        {
            InitializeComponent();
            DBS = dbsParam;
            Tb = tbParam;
            SQL = SQLParam;
            Co = coParam;
            objChannelManager = ChannelService.GetChannelManager();
            objDeviceManager = DeviceService.GetDeviceManager();
            objDataBlockManager = DataBlockService.GetDataBlockManager();
            objTagManager = TagService.GetTagManager();


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Co == null)
                {
                    var newColumn = new Column();
                    newColumn.ColumnId = int.Parse(txtColumnId.Text);
                    newColumn.TagName = txtTagName.Text;
                    newColumn.Channel = txtChannel.Text;
                    newColumn.ColumnName = txtColumnName.Text;
                    newColumn.DataBlock = txtDataBlock.Text;
                    newColumn.Device = txtDevice.Text;
                    newColumn.Mode = txtMode.Text;
                    newColumn.TriggerType = txtTriggerType.Text;
                    newColumn.Description = txtDescription.Text;
                    ColumnManager.Add(Tb, newColumn);
                    if (eventColumnChanged != null) eventColumnChanged(newColumn);
                }
                else
                {
                    Co.ColumnId = int.Parse(txtColumnId.Text);
                    Co.TagName = txtTagName.Text;
                    Co.Channel = txtChannel.Text;
                    Co.ColumnName = txtColumnName.Text;
                    Co.DataBlock = txtDataBlock.Text;
                    Co.Device = txtDevice.Text;
                    Co.Mode = txtMode.Text;
                    Co.TriggerType = txtTriggerType.Text;
                    Co.Description = txtDescription.Text;
                    ColumnManager.Update(Tb, Co);
                    if (eventColumnChanged != null) eventColumnChanged(Co);
                    DialogResult = DialogResult.OK;
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

        private void AddColumn_Load(object sender, EventArgs e)
        {
            try
            {
                txtSQLDataBase.Text = DBS.DataBaseName;
                txtSQLTable.Text = Tb.TableName;

                txtChannel.Properties.DataSource = objChannelManager.Channels.ToList();
                txtChannel.Properties.DisplayMember = "ChannelName";
                txtChannel.Properties.ValueMember = "ChannelId";
                var linkToSql = new LinkToSQL();

                txtColumnName.Properties.DataSource = linkToSql.AddColumn(txtSQLTable.Text, SQL.ServerName, DBS.DataBaseName);
                txtColumnName.Properties.DisplayMember = "ColumnName";
                txtColumnName.Properties.ValueMember = "ColumnName";
                if (Co == null)
                {
                    Text = "Add Column";
                }
                else
                {
                    Text = "Edit Column";
                    txtTagName.Text = Co.TagName;
                    txtColumnId.Text = Convert.ToString(Co.ColumnId);
                    txtChannel.Text = Co.Channel;
                    txtColumnName.Text = Co.ColumnName;
                    txtDataBlock.Text = Co.DataBlock;
                    txtDevice.Text = Co.Device;
                    txtMode.Text = Co.Mode;
                    txtTriggerType.Text = Co.TriggerType;
                    txtDescription.Text = Co.Description;

                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }



        private void txtChannel_EditValueChanged(object sender, EventArgs e)
        {
            ch = objChannelManager.GetByChannelName(txtChannel.Text);
            txtDevice.Properties.DataSource = ch.Devices.ToList();
            txtDevice.Properties.DisplayMember = "DeviceName";
            txtDevice.Properties.ValueMember = "DeviceId";
        }

        private void txtDevice_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var chCurrent = objChannelManager.GetByChannelName(txtChannel.Text);
                var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, txtDevice.Text);
                txtDataBlock.Properties.DataSource = dvCurrent.DataBlocks.ToList();
                txtDataBlock.Properties.DisplayMember = "DataBlockName";
                txtDataBlock.Properties.ValueMember = "DataBlockId";
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void txtDataBlock_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var chCurrent = objChannelManager.GetByChannelName(txtChannel.Text);
                var dvCurrent = objDeviceManager.GetByDeviceName(chCurrent, txtDevice.Text);
                var dbCurrent = objDataBlockManager.GetByDataBlockName(dvCurrent, txtDataBlock.Text);
                bS7Tags = new BindingList<Tag>(dbCurrent.Tags);
                txtTagName.Properties.DataSource = dbCurrent.Tags.ToList();
                txtTagName.Properties.DisplayMember = "TagName";
                txtTagName.Properties.ValueMember = "TagId";
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }
}