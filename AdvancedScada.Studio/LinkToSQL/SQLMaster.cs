using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdvancedScada.Management.SQLManager;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Studio.DriverLinkToSQL
{
    public partial class SQLMaster : XtraForm
    {
        private BindingList<Column> bColumns;
        private List<DataBase> bvDataBase;
        private List<Server> bvServer;
        private List<Table> bvTable;

        public bool IsDataChanged;
        private ServerManager objServerManager;
        private TreeListNode parentNode;

        private string[] SelectebNodesHelpr;
        public SQLMaster()
        {
            InitializeComponent();
        }
        private void InitializeData(string xmlPath)
        {

            TreeListNode node = null;
            TreeListNode node2 = null;
            TreeListNode node3 = null;
            objServerManager.SQLServers.Clear();
            objServerManager.XmlPath = xmlPath;
            var chList = objServerManager.GetServers(xmlPath);
            treeList1.Nodes.Clear();
            parentNode = treeList1.AppendNode(new object[] { "DriverLinkToSQL" }, null);
            parentNode.StateImageIndex = 0;
            foreach (var ch in chList)
            {
                var dvList = new List<TreeNode>();
                ////Sort.
                ch.DataBase.Sort(delegate(DataBase x, DataBase y) { return x.DataBaseName.CompareTo(y.DataBaseName); });
                node = treeList1.AppendNode(new object[] { ch.ServerName }, null);
                node.StateImageIndex = 1;
                foreach (var dv in ch.DataBase)
                {
                    var tgList = new List<TreeNode>();
                    node2 = treeList1.AppendNode(new object[] { dv.DataBaseName }, node);
                    node2.StateImageIndex = 0;
                    foreach (var db in dv.Tables)
                    {
                        tgList.Add(new TreeNode(db.TableName));
                        node3 = treeList1.AppendNode(new object[] { db.TableName }, node2);
                        node3.StateImageIndex = 7;
                    }

                    var dvNode = new TreeNode(dv.DataBaseName, tgList.ToArray());
                }

                var chNode = new TreeNode(ch.ServerName, dvList.ToArray());
            }
        }
        private string FullNameByNode(TreeListNode node, int columnId)
        {
            var ret = node.GetValue(columnId).ToString();
            while (node.ParentNode != null)
            {
                node = node.ParentNode;
                ret = node.GetValue(columnId) + "\\" + ret;
            }

            return ret;
        }
        private void SQLMaster_Load(object sender, EventArgs e)
        {
            objServerManager = ServerManager.GetServerManager();
            var xmlFile = objServerManager.ReadKey(ServerManager.XML_NAME_DEFAULT);
            if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return;
            InitializeData(xmlFile);
            //for (int i = 0; i < 5; i++)
            //{
            //parentNode = treeList1.AppendNode(new object[] { "DriverLinkToSQL" }, null);
            //parentNode.StateImageIndex = 0;

            //for (int j = i + 1; j < i + 3; j++)
            //{
            //TreeListNode ChildNode =   treeList1.AppendNode(new object[] { "Child Node " + j.ToString() }, parentNode);
            //ChildNode.StateImageIndex = 7;
            //for (int x = i + 1; x < i + 3; x++)
            //{
            //    TreeListNode Child2Node = treeList1.AppendNode(new object[] { "Child2 Node " + j.ToString() }, ChildNode);
            //    Child2Node.StateImageIndex = 5;
            //}
            //}

            // }

        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                var SelectebNodes = treeList1.Selection;
                var s = FullNameByNode(e.Node, 0);
                SelectebNodesHelpr = s.Split('\\');
                var Level = SelectebNodes[0].Level;
                if (SelectebNodes[0] == null) return;
                Table dbCurrent = null; //Node: Table
                DataBase dvCurrent = null; //Node: DataBase
                Server chCurrent = null; //Node: Server

                switch (Level)
                {
                    case 0:
                        bvServer = new List<Server>();
                        chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                        bvServer.Add(chCurrent);
                        vGridSQLServer.DataSource = bvServer;
                        break;
                    case 1:
                        bvDataBase = new List<DataBase>();
                        chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                        dvCurrent = DataBaseManager.GetByDataBaseName(chCurrent, SelectebNodesHelpr[1]);

                        bvDataBase.Add(dvCurrent);
                        VGridSQLDataBase.DataSource = bvDataBase;
                        break;
                    case 2:
                        chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                        dvCurrent = DataBaseManager.GetByDataBaseName(chCurrent, SelectebNodesHelpr[1]);
                        dbCurrent = TableManager.GetByTableName(dvCurrent, SelectebNodesHelpr[2]);
                        bvTable = new List<Table>();

                        bvTable.Add(dbCurrent);
                        vGridTable.DataSource = bvTable;
                        gridControl1.DataSource = dbCurrent.Columns;
                        gridView1.Invalidate();

                        break;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {

                    popupMenuRight.ShowPopup(MousePosition);
                    Selection();
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        private void Selection()
        {
            var SelectebNodes = treeList1.Selection;
            if (SelectebNodes[0] == null) return;
            var Level = SelectebNodes[0].Level;
            switch (Level)
            {
                case 0:
                    ItemSQLServer.Enabled = true;
                    ItemDataBase.Enabled = true;
                    ItemTable.Enabled = false;
                    ItemDriverLinkToSQL.Enabled = false;
                    break;
                case 1:
                    ItemSQLServer.Enabled = false;
                    ItemDataBase.Enabled = true;
                    ItemTable.Enabled = true;
                    ItemDriverLinkToSQL.Enabled = false;
                    break;
                case 2:
                    ItemSQLServer.Enabled = false;
                    ItemDataBase.Enabled = false;
                    ItemTable.Enabled = true;
                    ItemDriverLinkToSQL.Enabled = true;
                    break;
            }
        }
        private void ItemSQLServer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var chFrm = new AddServer(objServerManager);
                chFrm.eventSQLServerChanged += ch =>
                {

                    try
                    {
                        if (treeList1.Nodes.Count > 0)
                        {
                            treeList1.FocusedNode = treeList1.AppendNode(new object[] { ch.ServerName }, treeList1.FocusedNode.ParentNode);
                            treeList1.FocusedNode.StateImageIndex = 1;


                        }
                        else
                        {
                            treeList1.AppendNode(new object[] { ch.ServerName }, null);

                        }

                        //IsDataChanged = true;
                    }
                    catch (Exception ex)
                    {
                        EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                    }
                };
                chFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemDataBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectebNodes = treeList1.Selection;
            if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");
            Server chCurrent = null;
            try
            {
                var Level = selectebNodes[0].Level;
                switch (Level)
                {
                    case 0:
                    case 1:
                        chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                        break;
                }

                var dvFrm = new AddDataBase(chCurrent);
                dvFrm.eventDataBaseChanged += dv =>
                {
                    try
                    {
                        switch (Level)
                        {
                            case 0:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { dv.DataBaseName }, treeList1.FocusedNode);
                                treeList1.FocusedNode.StateImageIndex = 0;
                                IsDataChanged = true;
                                break;
                            case 1:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { dv.DataBaseName }, treeList1.FocusedNode.ParentNode);

                                treeList1.FocusedNode.StateImageIndex = 0;
                                IsDataChanged = true;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                    }
                };
                dvFrm.ShowDialog();


            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Server chCurrent = null;
                DataBase dvCurrent = null;

                var selectebNodes = treeList1.Selection;
                if (selectebNodes == null) throw new ArgumentNullException("selectebNodes");


                var Level = selectebNodes[0].Level;

                switch (Level)
                {
                    case 1:
                    case 2:
                        chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                        dvCurrent = DataBaseManager.GetByDataBaseName(chCurrent, SelectebNodesHelpr[1]);
                        break;
                }
                var dbFrm = new AddTable(chCurrent, dvCurrent);
                dbFrm.eventTableChanged += db =>
                {
                    try
                    {
                        switch (Level)
                        {
                            case 1:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { db.TableName },
                                    treeList1.FocusedNode);
                                treeList1.FocusedNode.StateImageIndex = 7;
                                IsDataChanged = true;
                                break;
                            case 2:
                                treeList1.FocusedNode = treeList1.AppendNode(new object[] { db.TableName },
                                    treeList1.FocusedNode.ParentNode);
                                treeList1.FocusedNode.StateImageIndex = 7;
                                IsDataChanged = true;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                    }
                };
                dbFrm.ShowDialog();

            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void barSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                objServerManager.Save(Application.StartupPath + "\\SQLCollection.xml");
                MessageBox.Show(this, "Data saved successfully!", "INFORMATION", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // IsDataChanged = false;
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        public void ItemDriverLinkToSQL_ItemClick(object sender, ItemClickEventArgs e)
        {

            Server chCurrent = null;
            DataBase dvCurrent = null;
            Table dbCurrent = null;
            var SelectebNodes = treeList1.Selection;
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (SelectebNodes[0].Level == null) return;
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

            var dbNode = SelectebNodes[0]; // Node:DataBlock
            var dvNode = dbNode.ParentNode; // Node:Device
            var chNode = dvNode.ParentNode; // Node:Channel


            var channelName = chNode["Name"].ToString();
            var DeviceName = dvNode["Name"].ToString();

            var DataBlockName = dbNode["Name"].ToString();


            chCurrent = objServerManager.GetBySQLServerName(channelName);
            dvCurrent = DataBaseManager.GetByDataBaseName(chCurrent, DeviceName);
            dbCurrent = TableManager.GetByTableName(dvCurrent, DataBlockName);

            var tgFrm = new AddColumn(chCurrent, dvCurrent, dbCurrent);
            tgFrm.eventColumnChanged += tg =>
            {
                try
                {
                    bColumns = new BindingList<Column>(dbCurrent.Columns);
                    gridControl1.DataSource = bColumns;
                    gridView1.Invalidate();
                }
                catch (Exception ex)
                {
                    EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                }
            };
            tgFrm.ShowDialog();




        }

        private void ItemOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                // Show the dialog and get result.
                openFileDialog.Filter = "Xml Files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FileName = "config";
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {

                    objServerManager.SQLServers.Clear();
                    objServerManager.XmlPath = openFileDialog.FileName;
                    InitializeData(openFileDialog.FileName);
                    IsDataChanged = true;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        private void ItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var SelectebNodes = treeList1.Selection;
                var Level = SelectebNodes[0].Level;
                if (SelectebNodes[0] == null) return;

                DialogResult result;
                switch (Level)
                {
                    case 0:
                        result = MessageBox.Show(this,
                            $"Are you sure delete Server: {SelectebNodesHelpr[0]}?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var fCh = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                            objServerManager.Delete(fCh);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                    case 1:
                        result = MessageBox.Show(this,
                            $"Are you sure delete DataBase: {SelectebNodesHelpr[0]} of the channel: {SelectebNodesHelpr[1]}?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var fCh = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                            DataBaseManager.Delete(fCh, SelectebNodesHelpr[1]);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                    case 2:
                        result = MessageBox.Show(this,
                            $"Are you sure delete Table: {SelectebNodesHelpr[0]} of the device: {SelectebNodesHelpr[1]}, channel: {SelectebNodesHelpr[2]}?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            var chCurrent = objServerManager.GetBySQLServerName(SelectebNodesHelpr[0]);
                            var dvCurrent = DataBaseManager.GetByDataBaseName(chCurrent, SelectebNodesHelpr[1]);
                            var dbCurrent = TableManager.GetByTableName(dvCurrent, SelectebNodesHelpr[2]);
                            TableManager.Delete(dvCurrent, dbCurrent);
                            treeList1.DeleteSelectedNodes();
                            IsDataChanged = true;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }
}