using System;
using System.Drawing;
using AdvancedScada.Studio.Properties;
using System.Windows.Forms;

namespace AdvancedScada.Studio
{
    public class TrayProcessIcon : IDisposable
    {

        private readonly FormStudio form;
        private readonly NotifyIcon ni;

        public TrayProcessIcon(FormStudio form)
        {
            ni = new NotifyIcon();
            this.form = form;
        }

        public void Dispose()
        {
            ni.MouseClick -= ni_MouseClick;
            ni.Icon = null;
            ni.Text = null;
            ni.Visible = false;
            ni.Dispose();
        }

        public void Display()
        {
            ni.MouseClick += ni_MouseClick;
            //ni.Icon = Resources.;
            ni.Text = "X-Middbleware-ModbusServer";
            ni.Visible = true;
            ni.ContextMenuStrip = new TrayContextMenus(form).Create();
        }

        private void ni_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) form.Show();
        }
    }
    public class TrayContextMenus
    {
        private readonly FormStudio form;

        public TrayContextMenus(FormStudio form)
        {
            this.form = form;
        }

        public ContextMenuStrip Create()
        {
            var contextMenuStrip = new ContextMenuStrip();
            var toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = "Open";
            toolStripMenuItem.Click += Explorer_Click;
            toolStripMenuItem.Image = Resources.TagManager;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = "About";
            toolStripMenuItem.Click += About_Click;
            toolStripMenuItem.Image = Resources.TagManager;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            var value = new ToolStripSeparator();
            contextMenuStrip.Items.Add(value);
            toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = "Exit";
            toolStripMenuItem.Click += Exit_Click;
            toolStripMenuItem.Image = Resources.TagManager;
            contextMenuStrip.Items.Add(toolStripMenuItem);
            return contextMenuStrip;
        }

        private void Explorer_Click(object sender, EventArgs e)
        {
            form.Show();
        }

        private void About_Click(object sender, EventArgs e)
        {
            //if (!form.isAboutLoaded)
            //{
            //    form.isAboutLoaded = true;
            //    //new AboutBox().ShowDialog();
            //    form.isAboutLoaded = false;
            //}
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you really want to close?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
                Application.Exit();
            }
        }
    }
    public class Message
    {
        public Message(string DriverTypes)
        {
            var frame = string.Empty;
            if (Settings.Default.Simulation) frame = "  Server Simulation";
            Caption = "سكادا";
            Text = "عبدالله الصاوى" + Environment.NewLine + DriverTypes + Environment.NewLine + frame;
            Image = Resources.TagManager;
        }
        public string Caption { get; set; }
        public string Text { get; set; }
        public Image Image { get; set; }
    }
}