
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Keyboard
{
    public delegate void ButtonClickEventHandler(object sender, KeypadEventArgs e);

    public interface IKeyboard
    {
        // Events
        event ButtonClickEventHandler ButtonClick;

        // Properties
        Font Font { get; set; }
        Color ForeColor { get; set; }
        Point Location { get; set; }
        object StartPosition { get; set; }
        string Text { get; set; }
        bool TopMost { get; set; }
        string Value { get; set; }
        bool Visible { get; set; }

    }





}