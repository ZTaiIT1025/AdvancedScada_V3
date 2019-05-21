
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Keyboard
{
    public class Keypad_v3 : System.Windows.Forms.Form, IKeyboard
    {

        //' Public Event ButtonClick As EventHandler(Of KeypadEventArgs) Implements IKeyboard.ButtonClick
        public event ButtonClickEventHandler ButtonClick;

        private bool drag;
        private int mouseX;
        private int mouseY;
        public bool PasscodeVerify;
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "HideCaret", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern Int32 HideCaret(Int32 hwnd);

        #region Constructor

        private System.ComponentModel.IContainer components;

        internal Button Button1;
        internal Button Button2;
        internal Button Button3;
        internal Button Button4;
        internal Button Button5;
        internal Button Button6;
        internal Button Button7;
        internal Button Button8;
        internal Button Button9;
        internal Button Button0;
        public Button buDecimal;
        internal Button buBksp;
        internal Button buClear;
        internal Button buCancel;
        public Button buAccept;
        public Button buNegative;
        public Label lblMaxValue;
        public Label lblMinValue;
        public Label lblCurrentValue;
        public TextBox txtValue;

        public Keypad_v3()
        {

            //* reduce the flicker
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
        }
        public Keypad_v3(int keypadWidth) : this()
        {
            //Me.KeypadWidth = keypadWidth

        }
        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.Button9 = new System.Windows.Forms.Button();
            this.Button0 = new System.Windows.Forms.Button();
            this.buDecimal = new System.Windows.Forms.Button();
            this.buBksp = new System.Windows.Forms.Button();
            this.buClear = new System.Windows.Forms.Button();
            this.buCancel = new System.Windows.Forms.Button();
            this.buAccept = new System.Windows.Forms.Button();
            this.buNegative = new System.Windows.Forms.Button();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //Button1
            //
            this.Button1.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button1.FlatAppearance.BorderSize = 0;
            this.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button1.ForeColor = System.Drawing.Color.Transparent;
            this.Button1.Location = new System.Drawing.Point(12, 217);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(55, 55);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "1";
            this.Button1.UseVisualStyleBackColor = false;
            //
            //Button2
            //
            this.Button2.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button2.ForeColor = System.Drawing.Color.Transparent;
            this.Button2.Location = new System.Drawing.Point(76, 217);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(55, 55);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "2";
            this.Button2.UseVisualStyleBackColor = false;
            //
            //Button3
            //
            this.Button3.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button3.FlatAppearance.BorderSize = 0;
            this.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button3.ForeColor = System.Drawing.Color.Transparent;
            this.Button3.Location = new System.Drawing.Point(140, 217);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(55, 55);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "3";
            this.Button3.UseVisualStyleBackColor = false;
            //
            //Button4
            //
            this.Button4.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button4.FlatAppearance.BorderSize = 0;
            this.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button4.ForeColor = System.Drawing.Color.Transparent;
            this.Button4.Location = new System.Drawing.Point(12, 151);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(55, 55);
            this.Button4.TabIndex = 3;
            this.Button4.Text = "4";
            this.Button4.UseVisualStyleBackColor = false;
            //
            //Button5
            //
            this.Button5.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button5.FlatAppearance.BorderSize = 0;
            this.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button5.ForeColor = System.Drawing.Color.Transparent;
            this.Button5.Location = new System.Drawing.Point(76, 151);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(55, 55);
            this.Button5.TabIndex = 4;
            this.Button5.Text = "5";
            this.Button5.UseVisualStyleBackColor = false;
            //
            //Button6
            //
            this.Button6.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button6.FlatAppearance.BorderSize = 0;
            this.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button6.ForeColor = System.Drawing.Color.Transparent;
            this.Button6.Location = new System.Drawing.Point(140, 151);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(55, 55);
            this.Button6.TabIndex = 5;
            this.Button6.Text = "6";
            this.Button6.UseVisualStyleBackColor = false;
            //
            //Button7
            //
            this.Button7.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button7.FlatAppearance.BorderSize = 0;
            this.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button7.ForeColor = System.Drawing.Color.Transparent;
            this.Button7.Location = new System.Drawing.Point(12, 85);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(55, 55);
            this.Button7.TabIndex = 6;
            this.Button7.Text = "7";
            this.Button7.UseVisualStyleBackColor = false;
            //
            //Button8
            //
            this.Button8.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button8.FlatAppearance.BorderSize = 0;
            this.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button8.ForeColor = System.Drawing.Color.Transparent;
            this.Button8.Location = new System.Drawing.Point(76, 85);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(55, 55);
            this.Button8.TabIndex = 7;
            this.Button8.Text = "8";
            this.Button8.UseVisualStyleBackColor = false;
            //
            //Button9
            //
            this.Button9.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button9.FlatAppearance.BorderSize = 0;
            this.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button9.ForeColor = System.Drawing.Color.Transparent;
            this.Button9.Location = new System.Drawing.Point(140, 85);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(55, 55);
            this.Button9.TabIndex = 8;
            this.Button9.Text = "9";
            this.Button9.UseVisualStyleBackColor = false;
            //
            //Button0
            //
            this.Button0.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.Button0.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Button0.FlatAppearance.BorderSize = 0;
            this.Button0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.Button0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.Button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.Button0.ForeColor = System.Drawing.Color.Transparent;
            this.Button0.Location = new System.Drawing.Point(76, 283);
            this.Button0.Name = "Button0";
            this.Button0.Size = new System.Drawing.Size(55, 55);
            this.Button0.TabIndex = 9;
            this.Button0.Text = "0";
            this.Button0.UseVisualStyleBackColor = false;
            //
            //buDecimal
            //
            this.buDecimal.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buDecimal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buDecimal.FlatAppearance.BorderSize = 0;
            this.buDecimal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buDecimal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buDecimal.ForeColor = System.Drawing.Color.Transparent;
            this.buDecimal.Location = new System.Drawing.Point(140, 283);
            this.buDecimal.Name = "buDecimal";
            this.buDecimal.Size = new System.Drawing.Size(55, 55);
            this.buDecimal.TabIndex = 10;
            this.buDecimal.Text = ".";
            this.buDecimal.UseVisualStyleBackColor = false;
            //
            //buBksp
            //
            this.buBksp.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buBksp.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buBksp.FlatAppearance.BorderSize = 0;
            this.buBksp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buBksp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buBksp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buBksp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buBksp.ForeColor = System.Drawing.Color.Transparent;
            this.buBksp.Location = new System.Drawing.Point(229, 85);
            this.buBksp.Name = "buBksp";
            this.buBksp.Size = new System.Drawing.Size(110, 55);
            this.buBksp.TabIndex = 11;
            this.buBksp.Text = "Backspace";
            this.buBksp.UseVisualStyleBackColor = false;
            //
            //buClear
            //
            this.buClear.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buClear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buClear.FlatAppearance.BorderSize = 0;
            this.buClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buClear.ForeColor = System.Drawing.Color.Transparent;
            this.buClear.Location = new System.Drawing.Point(229, 151);
            this.buClear.Name = "buClear";
            this.buClear.Size = new System.Drawing.Size(110, 55);
            this.buClear.TabIndex = 12;
            this.buClear.Text = "Clear";
            this.buClear.UseVisualStyleBackColor = false;
            //
            //buCancel
            //
            this.buCancel.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buCancel.FlatAppearance.BorderSize = 0;
            this.buCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buCancel.ForeColor = System.Drawing.Color.Transparent;
            this.buCancel.Location = new System.Drawing.Point(229, 217);
            this.buCancel.Name = "buCancel";
            this.buCancel.Size = new System.Drawing.Size(110, 55);
            this.buCancel.TabIndex = 13;
            this.buCancel.Text = "Cancel";
            this.buCancel.UseVisualStyleBackColor = false;
            //
            //buAccept
            //
            this.buAccept.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buAccept.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buAccept.FlatAppearance.BorderSize = 0;
            this.buAccept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buAccept.ForeColor = System.Drawing.Color.Transparent;
            this.buAccept.Location = new System.Drawing.Point(229, 283);
            this.buAccept.Name = "buAccept";
            this.buAccept.Size = new System.Drawing.Size(110, 55);
            this.buAccept.TabIndex = 14;
            this.buAccept.Text = "Accept";
            this.buAccept.UseVisualStyleBackColor = false;
            //
            //buNegative
            //
            this.buNegative.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.buNegative.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buNegative.FlatAppearance.BorderSize = 0;
            this.buNegative.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.buNegative.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.buNegative.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buNegative.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.buNegative.ForeColor = System.Drawing.Color.Transparent;
            this.buNegative.Location = new System.Drawing.Point(12, 283);
            this.buNegative.Name = "buNegative";
            this.buNegative.Size = new System.Drawing.Size(55, 55);
            this.buNegative.TabIndex = 15;
            this.buNegative.Text = "-";
            this.buNegative.UseVisualStyleBackColor = false;
            //
            //lblMaxValue
            //
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMaxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblMaxValue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMaxValue.Location = new System.Drawing.Point(172, 65);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(30, 13);
            this.lblMaxValue.TabIndex = 16;
            this.lblMaxValue.Text = "Max:";
            //
            //lblMinValue
            //
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMinValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblMinValue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMinValue.Location = new System.Drawing.Point(12, 65);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(27, 13);
            this.lblMinValue.TabIndex = 18;
            this.lblMinValue.Text = "Min:";
            //
            //lblCurrentValue
            //
            this.lblCurrentValue.AutoSize = true;
            this.lblCurrentValue.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblCurrentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.lblCurrentValue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentValue.Location = new System.Drawing.Point(12, 10);
            this.lblCurrentValue.Name = "lblCurrentValue";
            this.lblCurrentValue.Size = new System.Drawing.Size(74, 13);
            this.lblCurrentValue.TabIndex = 19;
            this.lblCurrentValue.Text = "Current Value:";
            //
            //txtValue
            //
            this.txtValue.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtValue.Location = new System.Drawing.Point(12, 30);
            this.txtValue.MaxLength = 16;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(327, 26);
            this.txtValue.TabIndex = 20;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            //Keypad_v3
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb((int)((byte)28), (int)((byte)28), (int)((byte)28));
            this.ClientSize = new System.Drawing.Size(353, 350);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblCurrentValue);
            this.Controls.Add(this.lblMinValue);
            this.Controls.Add(this.lblMaxValue);
            this.Controls.Add(this.buNegative);
            this.Controls.Add(this.buAccept);
            this.Controls.Add(this.buCancel);
            this.Controls.Add(this.buClear);
            this.Controls.Add(this.buBksp);
            this.Controls.Add(this.buDecimal);
            this.Controls.Add(this.Button0);
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.Button8);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Keypad_v3";
            this.ShowInTaskbar = false;
            this.Text = "Keypad";
            this.ResumeLayout(false);
            this.PerformLayout();

            //INSTANT C# NOTE: Converted design-time event handler wireups:
            base.Load += new System.EventHandler(Keypad_TDSA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(Form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(Form_KeyUp);
            Button0.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button1.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button2.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button3.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button4.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button5.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button6.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button7.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button8.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button9.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buBksp.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buClear.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buCancel.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buAccept.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buNegative.MouseEnter += new System.EventHandler(mouseEnterHandler);
            buDecimal.MouseEnter += new System.EventHandler(mouseEnterHandler);
            Button0.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button1.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button2.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button3.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button4.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button5.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button6.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button7.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button8.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button9.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buBksp.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buClear.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buCancel.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buAccept.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buNegative.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            buDecimal.MouseLeave += new System.EventHandler(mouseLeaveHandler);
            Button0.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button1.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button2.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button3.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button4.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button5.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button6.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button7.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button8.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button9.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buBksp.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buClear.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buAccept.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            buDecimal.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownHandler);
            Button0.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button1.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button2.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button3.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button4.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button5.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button6.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button7.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button8.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            Button9.MouseUp += new System.Windows.Forms.MouseEventHandler(NumericMouseUp);
            buAccept.MouseUp += new System.Windows.Forms.MouseEventHandler(buAccept_MouseUp);
            buCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(buCancel_MouseUp);
            buClear.MouseUp += new System.Windows.Forms.MouseEventHandler(buClear_MouseUp);
            buBksp.MouseUp += new System.Windows.Forms.MouseEventHandler(buBksp_MouseUp);
            buDecimal.MouseUp += new System.Windows.Forms.MouseEventHandler(buDecimal_MouseUp);
            buNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(buNegative_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(Keypad_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(Keypad_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(Keypad_MouseUp);
            txtValue.GotFocus += new System.EventHandler(txtValue_GotFocus);
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Properties

        private decimal? m_MinValue;
        /// <summary>
        /// Minimum value allowed to be entered from Keypad
        /// </summary>
        /// <remarks></remarks>
        [Description("Minimum value allowed to be entered from Keypad")]
        public decimal? MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
                lblMinValue.Text = "Min: " + Conversions.ToString(value);
                Invalidate();
            }
        }

        private decimal? m_MaxValue;
        /// <summary>
        /// Maximum value allowed to be entered from Keypad
        /// </summary>
        /// <remarks></remarks>
        [Description("Maximum value allowed to be entered from Keypad")]
        public decimal? MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
                lblMaxValue.Text = "Max: " + Conversions.ToString(value);
                Invalidate();
            }
        }

        private bool m_AllowNegative;
        /// <summary>
        /// Allow a negative value to be entered from Keypad
        /// </summary>
        /// <remarks></remarks>
        [Description("Allow a negative value to be entered from Keypad")]
        public bool AllowNegative
        {
            get
            {
                return m_AllowNegative;
            }
            set
            {
                m_AllowNegative = value;
                buNegative.Visible = value;
                Invalidate();
            }
        }

        private bool m_AllowDecimal;
        /// <summary>
        /// Allow a decimal value to be entered from Keypad
        /// </summary>
        /// <remarks></remarks>
        [Description("Allow a decimal value to be entered from Keypad")]
        public bool AllowDecimal
        {
            get
            {
                return m_AllowDecimal;
            }
            set
            {
                m_AllowDecimal = value;
                buDecimal.Visible = value;
                Invalidate();
            }
        }

        private string m_Value;
        /// <summary>
        /// Keypad current entered value
        /// </summary>
        /// <remarks></remarks>
        [Description("Keypad current entered value")]
        public string Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
                if (Operators.CompareString(value, string.Empty, false) == 0)
                {
                    txtValue.Text = string.Empty;
                    buAccept.Enabled = false;
                }
                else
                {
                    txtValue.Text = value;
                    buAccept.Enabled = true;
                }
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        public new Point Location
        {
            get
            {
                return base.Location;
            }
            set
            {
                base.Location = value;
            }
        }
        public new object StartPosition
        {
            get
            {
                return base.StartPosition;
            }
            set
            {
                base.StartPosition = (FormStartPosition)Conversions.ToInteger(value);
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }



        public new bool TopMost
        {
            get
            {
                return base.TopMost;
            }
            set
            {
                base.TopMost = value;
            }
        }



        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
            }
        }

        #endregion

        #region Events

        private void Keypad_TDSA_Load(object sender, EventArgs e)
        {

            m_Value = string.Empty;

            txtValue.ForeColor = Color.Black;
            txtValue.BackColor = Color.WhiteSmoke;

            if (m_MinValue == null && !AllowNegative)
            {
                MinValue = 0M;
            }
            else if (m_MinValue == null && AllowNegative)
            {
                MinValue = -2147483648M;
            }

            if (m_MaxValue == null)
            {
                MaxValue = 2147483647M;
            }

            if (string.IsNullOrEmpty(m_Value))
            {
                buAccept.Enabled = false;
            }

            this.KeyPreview = true;

        }

        private void Form_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad0 || e.KeyValue == 48)
            {
                mouseDownHandler(Button0, e);
            }

            if (e.KeyCode == Keys.NumPad1 || e.KeyValue == 49)
            {
                mouseDownHandler(Button1, e);
            }

            if (e.KeyCode == Keys.NumPad2 || e.KeyValue == 50)
            {
                mouseDownHandler(Button2, e);
            }

            if (e.KeyCode == Keys.NumPad3 || e.KeyValue == 51)
            {
                mouseDownHandler(Button3, e);
            }

            if (e.KeyCode == Keys.NumPad4 || e.KeyValue == 52)
            {
                mouseDownHandler(Button4, e);
            }

            if (e.KeyCode == Keys.NumPad5 || e.KeyValue == 53)
            {
                mouseDownHandler(Button5, e);
            }

            if (e.KeyCode == Keys.NumPad6 || e.KeyValue == 54)
            {
                mouseDownHandler(Button6, e);
            }

            if (e.KeyCode == Keys.NumPad7 || e.KeyValue == 55)
            {
                mouseDownHandler(Button7, e);
            }

            if (e.KeyCode == Keys.NumPad8 || e.KeyValue == 56)
            {
                mouseDownHandler(Button8, e);
            }

            if (e.KeyCode == Keys.NumPad9 || e.KeyValue == 57)
            {
                mouseDownHandler(Button9, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                mouseDownHandler(buCancel, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                mouseDownHandler(buAccept, e);
            }

            if (e.KeyCode == Keys.Subtract || e.KeyValue == 189)
            {
                mouseDownHandler(buNegative, e);
            }

            if (e.KeyCode == Keys.Decimal || e.KeyValue == 190)
            {
                mouseDownHandler(buDecimal, e);
            }

            if (e.KeyCode == Keys.Back)
            {
                mouseDownHandler(buBksp, e);
            }

            if (e.KeyCode == Keys.Delete)
            {
                mouseDownHandler(buClear, e);
            }

        }

        private void Form_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.NumPad0 || e.KeyValue == 48)
            {
                NumericMouseUp(Button0, e);
                mouseLeaveHandler(Button0, e);
            }

            if (e.KeyCode == Keys.NumPad1 || e.KeyValue == 49)
            {
                NumericMouseUp(Button1, e);
                mouseLeaveHandler(Button1, e);
            }

            if (e.KeyCode == Keys.NumPad2 || e.KeyValue == 50)
            {
                NumericMouseUp(Button2, e);
                mouseLeaveHandler(Button2, e);
            }

            if (e.KeyCode == Keys.NumPad3 || e.KeyValue == 51)
            {
                NumericMouseUp(Button3, e);
                mouseLeaveHandler(Button3, e);
            }

            if (e.KeyCode == Keys.NumPad4 || e.KeyValue == 52)
            {
                NumericMouseUp(Button4, e);
                mouseLeaveHandler(Button4, e);
            }

            if (e.KeyCode == Keys.NumPad5 || e.KeyValue == 53)
            {
                NumericMouseUp(Button5, e);
                mouseLeaveHandler(Button5, e);
            }

            if (e.KeyCode == Keys.NumPad6 || e.KeyValue == 54)
            {
                NumericMouseUp(Button6, e);
                mouseLeaveHandler(Button6, e);
            }

            if (e.KeyCode == Keys.NumPad7 || e.KeyValue == 55)
            {
                NumericMouseUp(Button7, e);
                mouseLeaveHandler(Button7, e);
            }

            if (e.KeyCode == Keys.NumPad8 || e.KeyValue == 56)
            {
                NumericMouseUp(Button8, e);
                mouseLeaveHandler(Button8, e);
            }

            if (e.KeyCode == Keys.NumPad9 || e.KeyValue == 57)
            {
                NumericMouseUp(Button9, e);
                mouseLeaveHandler(Button9, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                buCancel.ForeColor = Color.Black;
                buCancel.BackColor = Color.FromArgb(229, 229, 229);
                Value = string.Empty;
                lblMinValue.ForeColor = Color.WhiteSmoke;
                lblMaxValue.ForeColor = Color.WhiteSmoke;
                mouseLeaveHandler(buCancel, e);
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (buAccept.Enabled)
                {
                    buAccept.ForeColor = Color.Black;
                    buAccept.BackColor = Color.FromArgb(229, 229, 229);
                    Accept();
                    mouseLeaveHandler(buAccept, e);
                }

            }

            if (e.KeyCode == Keys.Subtract || e.KeyValue == 189)
            {
                Value = Value.Contains("-") ? Value.Substring(1, Value.Length - 1) : Convert.ToString("-") + Value;
                buNegative.ForeColor = Color.Black;
                buNegative.BackColor = Color.FromArgb(229, 229, 229);
                Check_Limits();
                mouseLeaveHandler(buNegative, e);
            }

            if (e.KeyCode == Keys.Decimal || e.KeyValue == 190)
            {
                if (!Value.Contains("."))
                {
                    Value = Value + Convert.ToString(".");
                }
                buDecimal.ForeColor = Color.Black;
                buDecimal.BackColor = Color.FromArgb(229, 229, 229);
                Check_Limits();
                mouseLeaveHandler(buDecimal, e);
            }

            if (e.KeyCode == Keys.Back)
            {
                if (Value != "Enter Passcode" && Value != "Incorrect Passcode" && Value != null)
                {
                    Value = (Value.Length != 0) ? Value.Substring(0, Value.Length - 1) : string.Empty;
                    Check_Limits();
                }
                buBksp.ForeColor = Color.Black;
                buBksp.BackColor = Color.FromArgb(229, 229, 229);
                mouseLeaveHandler(buBksp, e);
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (Value != "Enter Passcode" && Value != "Incorrect Passcode")
                {
                    Value = string.Empty;
                    txtValue.BackColor = Color.WhiteSmoke;
                    txtValue.ForeColor = Color.Black;
                    lblMinValue.ForeColor = Color.WhiteSmoke;
                    lblMaxValue.ForeColor = Color.WhiteSmoke;
                }
                buClear.ForeColor = Color.Black;
                buClear.BackColor = Color.FromArgb(229, 229, 229);
                mouseLeaveHandler(buClear, e);
            }

        }


        public void mouseEnterHandler(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ForeColor = Color.Black;
            control.BackColor = Color.White;
        }

        public void mouseLeaveHandler(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ForeColor = Color.White;
            control.BackColor = Color.FromArgb(65, 65, 65);
        }

        public void mouseDownHandler(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ForeColor = Color.White;
            control.BackColor = Color.Red;
            control.BackColor = Color.FromArgb(0, 154, 187);
        }

        public void NumericMouseUp(Object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            if (Value == "Enter Passcode" || Value == "Incorrect Passcode")
            {
                Value = string.Empty;
                txtValue.PasswordChar = '*';
            }

            if (txtValue.TextLength >= 28)
            {
                return;
            }

            if (lb.Text != "0" && Operators.CompareString(Value, "0", false) == 0)
            {
                Value = string.Empty;
            }

            if (lb.Text == "0" && Operators.CompareString(Value, "0", false) == 0)
            {
                return;
            }

            lblMinValue.Text = "Min: " + Conversions.ToString(m_MinValue);
            lblMaxValue.Text = "Max: " + Conversions.ToString(m_MaxValue);

            decimal data = 0M;
            decimal.TryParse(Value, out data);
            Value = Value + lb.Text;
            Check_Limits();

            Control control = (Control)sender;
            control.ForeColor = Color.Black;
            control.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void buAccept_MouseUp(object sender, MouseEventArgs e)
        {
            Accept();
        }

        private void Accept()
        {
            OnButtonClick(new KeypadEventArgs("Enter"));
            buAccept.ForeColor = Color.Black;
            buAccept.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void buCancel_MouseUp(object sender, MouseEventArgs e)
        {
            buCancel.ForeColor = Color.Black;
            buCancel.BackColor = Color.FromArgb(229, 229, 229);
            Value = string.Empty;
            lblMinValue.ForeColor = Color.WhiteSmoke;
            lblMaxValue.ForeColor = Color.WhiteSmoke;
            this.Close();
        }

        private void buClear_MouseUp(object sender, MouseEventArgs e)
        {
            if (Value != "Enter Passcode" && Value != "Incorrect Passcode")
            {
                Value = string.Empty;
                txtValue.BackColor = Color.WhiteSmoke;
                txtValue.ForeColor = Color.Black;
                lblMinValue.ForeColor = Color.WhiteSmoke;
                lblMaxValue.ForeColor = Color.WhiteSmoke;
            }
            buClear.ForeColor = Color.Black;
            buClear.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void buBksp_MouseUp(object sender, MouseEventArgs e)
        {
            if (Value != "Enter Passcode" && Value != "Incorrect Passcode" && Value != null)
            {
                Value = (Value.Length != 0) ? Value.Substring(0, Value.Length - 1) : string.Empty;
                Check_Limits();
            }
            buBksp.ForeColor = Color.Black;
            buBksp.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void buDecimal_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Value.Contains("."))
            {
                Value = Value + Convert.ToString(".");
            }
            buDecimal.ForeColor = Color.Black;
            buDecimal.BackColor = Color.FromArgb(229, 229, 229);
            Check_Limits();
        }

        private void buNegative_MouseUp(object sender, MouseEventArgs e)
        {
            Value = Value.Contains("-") ? Value.Substring(1, Value.Length - 1) : Convert.ToString("-") + Value;
            buNegative.ForeColor = Color.Black;
            buNegative.BackColor = Color.FromArgb(229, 229, 229);
            Check_Limits();
        }

        private void Keypad_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mouseX = System.Windows.Forms.Cursor.Position.X - this.Left;
            mouseY = System.Windows.Forms.Cursor.Position.Y - this.Top;
        }

        private void Keypad_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drag)
            {
                return;
            }
            Point position = System.Windows.Forms.Cursor.Position;
            this.Left = position.X - mouseX;
            position = System.Windows.Forms.Cursor.Position;
            this.Top = position.Y - mouseY;
        }

        private void Keypad_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        protected virtual void OnButtonClick(KeypadEventArgs e)
        {
            if (ButtonClick != null)
                ButtonClick(this, e);
        }

        private void Check_Limits()
        {

            if (NumericHelper.IsNumeric(Value))
            {
                if (Convert.ToDecimal(Value) < m_MinValue)
                {
                    lblMinValue.ForeColor = Color.Red;
                }
                else
                {
                    lblMinValue.ForeColor = Color.WhiteSmoke;
                }
            }
            else
            {
                lblMinValue.ForeColor = Color.WhiteSmoke;
            }

            if (NumericHelper.IsNumeric(Value))
            {
                if (Convert.ToDecimal(Value) > m_MaxValue)
                {
                    lblMaxValue.ForeColor = Color.Red;
                }
                else
                {
                    lblMaxValue.ForeColor = Color.WhiteSmoke;
                }
            }
            else
            {
                lblMaxValue.ForeColor = Color.WhiteSmoke;
            }

            if (!PasscodeVerify)
            {
                //if (NumericHelper.IsNumeric(Value))
                //{
                //	if (Convert.ToDecimal(Value) >= m_MinValue && Convert.ToDecimal(Value) <= m_MaxValue)
                //	{
                //		txtValue.ForeColor = Color.Black;
                //		txtValue.BackColor = Color.WhiteSmoke;
                //		buAccept.Enabled = true;
                //	}
                //	else
                //	{
                //		txtValue.ForeColor = Color.White;
                //		txtValue.BackColor = Color.Red;
                //		buAccept.Enabled = true;
                //	}
                //}
                //else
                //{
                txtValue.ForeColor = Color.Black;
                txtValue.BackColor = Color.WhiteSmoke;
                buAccept.Enabled = true;
                //}
            }

        }

        private void txtValue_GotFocus(object sender, System.EventArgs e)
        {

            HideCaret(txtValue.Handle.ToInt32());

        }

        #endregion

    }
}