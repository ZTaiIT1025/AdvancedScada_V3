using System;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management;
using DevExpress.XtraEditors;

namespace AdvancedScada.Studio.Editors
{
    public partial class XTagForm : XtraForm
    {
        private readonly Channel ch;
        private readonly DataBlock db;
        private readonly Device dv;

        public EventTagChanged eventTagChanged = null;
        private readonly Tag tg;
        public XTagForm()
        {
            InitializeComponent();
        }
        public XTagForm(Channel chParam, Device dvParam, DataBlock dbParam, Tag tgParam = null)
        {
            InitializeComponent();
            dv = dvParam;
            db = dbParam;
            ch = chParam;
            tg = tgParam;
        }
        public void GetForm(string Path, string classname)
        {
            var objFunctions = Functions.GetFunctions();
            var context = objFunctions.ParseNamespace($@"\AdvancedScada.{Path}.Core.dll", classname);
            var t = (Type)context;
            Management.Editors.XTagForm newObject = null;
            if (tg == null) newObject = (Management.Editors.XTagForm)objFunctions.CreateInstance(t, new object[] { ch, dv, db, null });
            else newObject = (Management.Editors.XTagForm)objFunctions.CreateInstance(t, new object[] { ch, dv, db, tg });

            newObject.eventTagChanged += (tg, isNew) =>
            {
                eventTagChanged?.Invoke(tg, isNew);
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
        private void XTagForm_Load(object sender, EventArgs e)
        {
            var DriverTypes2 = ch.ChannelTypes.Insert(0, "X");

            if (tg == null)
            {

                GetForm(DriverTypes2, "XUserTagForm");

                Text = ch.ChannelTypes + "   Add Tag";
            }
            else
            {
                GetForm(DriverTypes2, "XUserTagForm");

                Text = ch.ChannelTypes + "   Edit Tag";
            }

        }
        private void TgFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}