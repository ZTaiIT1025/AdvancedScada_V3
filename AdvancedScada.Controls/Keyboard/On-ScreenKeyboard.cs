
using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

//*****************************************************************************************************
//* Archie Jacobs
//* Manufacturing Automation, LLC
//* support@advancedhmi.com
//* 12-JUN-11
//*
//* Copyright 2011 Archie Jacobs
//*
//* Distributed under the GNU General Public License (www.gnu.org)
//*
//* This program is free software; you can redistribute it and/or
//* as published by the Free Software Foundation; either version 2
//* of the License, or (at your option) any later version.
//*
//* This program is distributed in the hope that it will be useful,
//* but WITHOUT ANY WARRANTY; without even the implied warranty of
//* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//* GNU General Public License for more details.

//* You should have received a copy of the GNU General Public License
//* along with this program; if not, write to the Free Software
//* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
//*
//******************************************************************************************************

namespace AdvancedScada.Controls.Keyboard
{
    [ToolboxItem(false)]
    public class OnScreenKeyboard : System.Windows.Forms.Button
    {
        #region Constructor

        public OnScreenKeyboard() : base()
        {
            base.DoubleBuffered = true;
            this.DoubleBuffered = true;
            this.Size = new Size(134, 38);
            base.ForeColor = Color.MidnightBlue;
            SubscribeToEvents();
        }

        #endregion

        #region Private Methods

        private void OSK_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        #endregion


        //INSTANT C# NOTE: Converted event handler wireups:
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Click += OSK_Click;
        }

    }


}