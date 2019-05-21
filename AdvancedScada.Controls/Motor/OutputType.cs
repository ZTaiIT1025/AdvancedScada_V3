
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Motor
{
    public enum OutputType
    {
        MomentarySet,
        MomentaryReset,
        SetTrue,
        SetFalse,
        Toggle,
        WriteValue,
        ValveWeiCtriDialog
    }


}