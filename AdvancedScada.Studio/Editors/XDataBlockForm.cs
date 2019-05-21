using System;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using DevExpress.XtraEditors;

namespace AdvancedScada.Studio.Editors
{
    public partial class XDataBlockForm : XtraForm
    {

        private readonly Channel ch;
        private readonly DataBlock db;
        private readonly Device dv;
        public EventDataBlockChanged eventDataBlockChanged = null;


        public XDataBlockForm()
        {
            InitializeComponent();
        }
        public XDataBlockForm(Channel chParam, Device dvParam, DataBlock dbParam = null)
        {
            InitializeComponent();
            ch = chParam;
            dv = dvParam;
            db = dbParam;
        }
        public void GetForm(string Path, string classname)
        {
            var objFunctions = Functions.GetFunctions();
            var context = objFunctions.ParseNamespace($@"\AdvancedScada.{Path}.Core.dll", classname);
            var t = (Type)context;
            Management.Editors.XDataBlockForm newObject = null;
            if (db == null) newObject = (Management.Editors.XDataBlockForm)objFunctions.CreateInstance(t, new object[] { ch, dv, null });
            else newObject = (Management.Editors.XDataBlockForm)objFunctions.CreateInstance(t, new object[] { ch, dv, db });
            newObject.eventDataBlockChanged += (db, isNew) =>
            {
                eventDataBlockChanged?.Invoke(db, isNew);
                DialogResult = DialogResult.OK;
            };

            try
            {
                if (newObject != null)
                {
                    newObject.Dock = DockStyle.Fill;
                    this.Width = newObject.Width + 25;
                    this.Height = newObject.Height + 25;
                    newObject.BringToFront();
                    newObject.Click += NewObject_Click;
                    Controls.Add(newObject);
                   
                }
                
            }
            catch
            {
            }
        }

        private void NewObject_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void XDataBlockForm_Load(object sender, EventArgs e)
        {

            var DriverTypes2 = ch.ChannelTypes.Insert(0, "X");

            if (db == null)
            {

                GetForm(DriverTypes2, "XUserDataBlockForm");

                Text = ch.ChannelTypes + "   Add DataBlock";
            }
            else
            {
                GetForm(DriverTypes2, "XUserDataBlockForm");

                Text = ch.ChannelTypes + "   Edit DataBlock";
            }


        }

        private void DbFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}