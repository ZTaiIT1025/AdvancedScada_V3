using System;
using System.Drawing;
using AdvancedScada.Studio.Properties;

namespace AdvancedScada.Studio
{
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