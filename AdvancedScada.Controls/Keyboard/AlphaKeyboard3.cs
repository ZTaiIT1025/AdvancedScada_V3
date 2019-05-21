
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Keyboard
{
    public class AlphaKeyboard3 : System.Windows.Forms.Form, IKeyboard
    {

        private string m_Value;
        private bool ShiftMemory;
        private bool CapsMemory;
        public event ButtonClickEventHandler ButtonClick;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    //	if (m.Result == IntPtr.op_Explicit(HTCLIENT))
                    //{
                    //		m.Result = IntPtr.(HTCAPTION);
                    //}
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #region Constructor
        private System.ComponentModel.IContainer components;

        internal Button btnSelectAll;
        internal Button btnSpace;
        internal Button btnDown;
        internal Button btnRight;
        internal Button btnUp;
        internal Button btnLeft;
        internal Button btn28;
        internal Button btn40;
        internal Button btn41;
        internal Button btn_M;
        internal Button btn_N;
        internal Button btn_B;
        internal Button btn_V;
        internal Button btn_C;
        internal Button btn_X;
        internal Button btn_Z;
        internal Button btnShiftL;
        internal Button btnEnter;
        internal Button btn29;
        internal Button btn30;
        internal Button btn_L;
        internal Button btn_K;
        internal Button btn_J;
        internal Button btn_H;
        internal Button btn_G;
        internal Button btn_F;
        internal Button btn_D;
        internal Button btn_S;
        internal Button btn_A;
        internal Button btnCaps;
        internal Button btn14;
        internal Button btn15;
        internal Button btn16;
        internal Button btn_P;
        internal Button btn_O;
        internal Button btn_I;
        internal Button btn_U;
        internal Button btn_Y;
        internal Button btn_T;
        internal Button btn_R;
        internal Button btn_E;
        internal Button btn_W;
        internal Button btn_Q;
        internal Button btnTab;
        internal Button btnBack;
        internal Button btn13;
        internal Button btn12;
        internal Button btn11;
        internal Button btn10;
        internal Button btn9;
        internal Button btn8;
        internal Button btn7;
        internal Button btn6;
        internal Button btn5;
        internal Button btn4;
        internal Button btn3;
        internal Button btn2;
        internal Button btn1;
        internal Button btnCancel;
        internal TextBox TextBox1;

        public AlphaKeyboard3()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSpace = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btn28 = new System.Windows.Forms.Button();
            this.btn40 = new System.Windows.Forms.Button();
            this.btn41 = new System.Windows.Forms.Button();
            this.btn_M = new System.Windows.Forms.Button();
            this.btn_N = new System.Windows.Forms.Button();
            this.btn_B = new System.Windows.Forms.Button();
            this.btn_V = new System.Windows.Forms.Button();
            this.btn_C = new System.Windows.Forms.Button();
            this.btn_X = new System.Windows.Forms.Button();
            this.btn_Z = new System.Windows.Forms.Button();
            this.btnShiftL = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btn29 = new System.Windows.Forms.Button();
            this.btn30 = new System.Windows.Forms.Button();
            this.btn_L = new System.Windows.Forms.Button();
            this.btn_K = new System.Windows.Forms.Button();
            this.btn_J = new System.Windows.Forms.Button();
            this.btn_H = new System.Windows.Forms.Button();
            this.btn_G = new System.Windows.Forms.Button();
            this.btn_F = new System.Windows.Forms.Button();
            this.btn_D = new System.Windows.Forms.Button();
            this.btn_S = new System.Windows.Forms.Button();
            this.btn_A = new System.Windows.Forms.Button();
            this.btnCaps = new System.Windows.Forms.Button();
            this.btn14 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn16 = new System.Windows.Forms.Button();
            this.btn_P = new System.Windows.Forms.Button();
            this.btn_O = new System.Windows.Forms.Button();
            this.btn_I = new System.Windows.Forms.Button();
            this.btn_U = new System.Windows.Forms.Button();
            this.btn_Y = new System.Windows.Forms.Button();
            this.btn_T = new System.Windows.Forms.Button();
            this.btn_R = new System.Windows.Forms.Button();
            this.btn_E = new System.Windows.Forms.Button();
            this.btn_W = new System.Windows.Forms.Button();
            this.btn_Q = new System.Windows.Forms.Button();
            this.btnTab = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btn13 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            //btnSelectAll
            //
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(21, 270);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(91, 50);
            this.btnSelectAll.TabIndex = 122;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            //
            //btnSpace
            //
            this.btnSpace.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnSpace.FlatAppearance.BorderSize = 0;
            this.btnSpace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnSpace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnSpace.ForeColor = System.Drawing.Color.White;
            this.btnSpace.Location = new System.Drawing.Point(114, 270);
            this.btnSpace.Name = "btnSpace";
            this.btnSpace.Size = new System.Drawing.Size(470, 50);
            this.btnSpace.TabIndex = 120;
            this.btnSpace.Text = "Space";
            this.btnSpace.UseVisualStyleBackColor = false;
            //
            //btnDown
            //
            this.btnDown.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(638, 270);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 50);
            this.btnDown.TabIndex = 119;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = false;
            //
            //btnRight
            //
            this.btnRight.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnRight.ForeColor = System.Drawing.Color.White;
            this.btnRight.Location = new System.Drawing.Point(690, 270);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 50);
            this.btnRight.TabIndex = 118;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = false;
            //
            //btnUp
            //
            this.btnUp.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(742, 270);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 50);
            this.btnUp.TabIndex = 117;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = false;
            //
            //btnLeft
            //
            this.btnLeft.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnLeft.ForeColor = System.Drawing.Color.White;
            this.btnLeft.Location = new System.Drawing.Point(586, 270);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(50, 50);
            this.btnLeft.TabIndex = 116;
            this.btnLeft.Text = "←";
            this.btnLeft.UseVisualStyleBackColor = false;
            //
            //btn28
            //
            this.btn28.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn28.FlatAppearance.BorderSize = 0;
            this.btn28.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn28.ForeColor = System.Drawing.Color.White;
            this.btn28.Location = new System.Drawing.Point(608, 218);
            this.btn28.Name = "btn28";
            this.btn28.Size = new System.Drawing.Size(50, 50);
            this.btn28.TabIndex = 114;
            this.btn28.Text = "/";
            this.btn28.UseVisualStyleBackColor = false;
            //
            //btn40
            //
            this.btn40.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn40.FlatAppearance.BorderSize = 0;
            this.btn40.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn40.ForeColor = System.Drawing.Color.White;
            this.btn40.Location = new System.Drawing.Point(556, 218);
            this.btn40.Name = "btn40";
            this.btn40.Size = new System.Drawing.Size(50, 50);
            this.btn40.TabIndex = 113;
            this.btn40.Text = ".";
            this.btn40.UseVisualStyleBackColor = false;
            //
            //btn41
            //
            this.btn41.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn41.FlatAppearance.BorderSize = 0;
            this.btn41.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn41.ForeColor = System.Drawing.Color.White;
            this.btn41.Location = new System.Drawing.Point(504, 218);
            this.btn41.Name = "btn41";
            this.btn41.Size = new System.Drawing.Size(50, 50);
            this.btn41.TabIndex = 112;
            this.btn41.Text = ",";
            this.btn41.UseVisualStyleBackColor = false;
            //
            //btn_M
            //
            this.btn_M.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_M.FlatAppearance.BorderSize = 0;
            this.btn_M.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_M.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_M.ForeColor = System.Drawing.Color.White;
            this.btn_M.Location = new System.Drawing.Point(452, 218);
            this.btn_M.Name = "btn_M";
            this.btn_M.Size = new System.Drawing.Size(50, 50);
            this.btn_M.TabIndex = 111;
            this.btn_M.Text = "m";
            this.btn_M.UseVisualStyleBackColor = false;
            //
            //btn_N
            //
            this.btn_N.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_N.FlatAppearance.BorderSize = 0;
            this.btn_N.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_N.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_N.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_N.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_N.ForeColor = System.Drawing.Color.White;
            this.btn_N.Location = new System.Drawing.Point(400, 218);
            this.btn_N.Name = "btn_N";
            this.btn_N.Size = new System.Drawing.Size(50, 50);
            this.btn_N.TabIndex = 110;
            this.btn_N.Text = "n";
            this.btn_N.UseVisualStyleBackColor = false;
            //
            //btn_B
            //
            this.btn_B.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_B.FlatAppearance.BorderSize = 0;
            this.btn_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_B.ForeColor = System.Drawing.Color.White;
            this.btn_B.Location = new System.Drawing.Point(348, 218);
            this.btn_B.Name = "btn_B";
            this.btn_B.Size = new System.Drawing.Size(50, 50);
            this.btn_B.TabIndex = 109;
            this.btn_B.Text = "b";
            this.btn_B.UseVisualStyleBackColor = false;
            //
            //btn_V
            //
            this.btn_V.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_V.FlatAppearance.BorderSize = 0;
            this.btn_V.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_V.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_V.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_V.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_V.ForeColor = System.Drawing.Color.White;
            this.btn_V.Location = new System.Drawing.Point(296, 218);
            this.btn_V.Name = "btn_V";
            this.btn_V.Size = new System.Drawing.Size(50, 50);
            this.btn_V.TabIndex = 108;
            this.btn_V.Text = "v";
            this.btn_V.UseVisualStyleBackColor = false;
            //
            //btn_C
            //
            this.btn_C.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_C.FlatAppearance.BorderSize = 0;
            this.btn_C.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_C.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_C.ForeColor = System.Drawing.Color.White;
            this.btn_C.Location = new System.Drawing.Point(244, 218);
            this.btn_C.Name = "btn_C";
            this.btn_C.Size = new System.Drawing.Size(50, 50);
            this.btn_C.TabIndex = 107;
            this.btn_C.Text = "c";
            this.btn_C.UseVisualStyleBackColor = false;
            //
            //btn_X
            //
            this.btn_X.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_X.FlatAppearance.BorderSize = 0;
            this.btn_X.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_X.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_X.ForeColor = System.Drawing.Color.White;
            this.btn_X.Location = new System.Drawing.Point(192, 218);
            this.btn_X.Name = "btn_X";
            this.btn_X.Size = new System.Drawing.Size(50, 50);
            this.btn_X.TabIndex = 106;
            this.btn_X.Text = "x";
            this.btn_X.UseVisualStyleBackColor = false;
            //
            //btn_Z
            //
            this.btn_Z.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_Z.FlatAppearance.BorderSize = 0;
            this.btn_Z.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_Z.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_Z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_Z.ForeColor = System.Drawing.Color.White;
            this.btn_Z.Location = new System.Drawing.Point(140, 218);
            this.btn_Z.Name = "btn_Z";
            this.btn_Z.Size = new System.Drawing.Size(50, 50);
            this.btn_Z.TabIndex = 105;
            this.btn_Z.Text = "z";
            this.btn_Z.UseVisualStyleBackColor = false;
            //
            //btnShiftL
            //
            this.btnShiftL.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnShiftL.FlatAppearance.BorderSize = 0;
            this.btnShiftL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnShiftL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnShiftL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShiftL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnShiftL.ForeColor = System.Drawing.Color.White;
            this.btnShiftL.Location = new System.Drawing.Point(21, 218);
            this.btnShiftL.Name = "btnShiftL";
            this.btnShiftL.Size = new System.Drawing.Size(117, 50);
            this.btnShiftL.TabIndex = 104;
            this.btnShiftL.Text = "Shift";
            this.btnShiftL.UseVisualStyleBackColor = false;
            //
            //btnEnter
            //
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(686, 166);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(106, 50);
            this.btnEnter.TabIndex = 103;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            //
            //btn29
            //
            this.btn29.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn29.FlatAppearance.BorderSize = 0;
            this.btn29.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn29.ForeColor = System.Drawing.Color.White;
            this.btn29.Location = new System.Drawing.Point(634, 166);
            this.btn29.Name = "btn29";
            this.btn29.Size = new System.Drawing.Size(50, 50);
            this.btn29.TabIndex = 102;
            this.btn29.Text = "'";
            this.btn29.UseVisualStyleBackColor = false;
            //
            //btn30
            //
            this.btn30.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn30.FlatAppearance.BorderSize = 0;
            this.btn30.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn30.ForeColor = System.Drawing.Color.White;
            this.btn30.Location = new System.Drawing.Point(582, 166);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(50, 50);
            this.btn30.TabIndex = 101;
            this.btn30.Text = ";";
            this.btn30.UseVisualStyleBackColor = false;
            //
            //btn_L
            //
            this.btn_L.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_L.FlatAppearance.BorderSize = 0;
            this.btn_L.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_L.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_L.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_L.ForeColor = System.Drawing.Color.White;
            this.btn_L.Location = new System.Drawing.Point(530, 166);
            this.btn_L.Name = "btn_L";
            this.btn_L.Size = new System.Drawing.Size(50, 50);
            this.btn_L.TabIndex = 100;
            this.btn_L.Text = "l";
            this.btn_L.UseVisualStyleBackColor = false;
            //
            //btn_K
            //
            this.btn_K.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_K.FlatAppearance.BorderSize = 0;
            this.btn_K.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_K.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_K.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_K.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_K.ForeColor = System.Drawing.Color.White;
            this.btn_K.Location = new System.Drawing.Point(478, 166);
            this.btn_K.Name = "btn_K";
            this.btn_K.Size = new System.Drawing.Size(50, 50);
            this.btn_K.TabIndex = 99;
            this.btn_K.Text = "k";
            this.btn_K.UseVisualStyleBackColor = false;
            //
            //btn_J
            //
            this.btn_J.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_J.FlatAppearance.BorderSize = 0;
            this.btn_J.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_J.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_J.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_J.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_J.ForeColor = System.Drawing.Color.White;
            this.btn_J.Location = new System.Drawing.Point(426, 166);
            this.btn_J.Name = "btn_J";
            this.btn_J.Size = new System.Drawing.Size(50, 50);
            this.btn_J.TabIndex = 98;
            this.btn_J.Text = "j";
            this.btn_J.UseVisualStyleBackColor = false;
            //
            //btn_H
            //
            this.btn_H.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_H.FlatAppearance.BorderSize = 0;
            this.btn_H.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_H.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_H.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_H.ForeColor = System.Drawing.Color.White;
            this.btn_H.Location = new System.Drawing.Point(374, 166);
            this.btn_H.Name = "btn_H";
            this.btn_H.Size = new System.Drawing.Size(50, 50);
            this.btn_H.TabIndex = 97;
            this.btn_H.Text = "h";
            this.btn_H.UseVisualStyleBackColor = false;
            //
            //btn_G
            //
            this.btn_G.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_G.FlatAppearance.BorderSize = 0;
            this.btn_G.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_G.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_G.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_G.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_G.ForeColor = System.Drawing.Color.White;
            this.btn_G.Location = new System.Drawing.Point(322, 166);
            this.btn_G.Name = "btn_G";
            this.btn_G.Size = new System.Drawing.Size(50, 50);
            this.btn_G.TabIndex = 96;
            this.btn_G.Text = "g";
            this.btn_G.UseVisualStyleBackColor = false;
            //
            //btn_F
            //
            this.btn_F.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_F.FlatAppearance.BorderSize = 0;
            this.btn_F.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_F.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_F.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_F.ForeColor = System.Drawing.Color.White;
            this.btn_F.Location = new System.Drawing.Point(270, 166);
            this.btn_F.Name = "btn_F";
            this.btn_F.Size = new System.Drawing.Size(50, 50);
            this.btn_F.TabIndex = 95;
            this.btn_F.Text = "f";
            this.btn_F.UseVisualStyleBackColor = false;
            //
            //btn_D
            //
            this.btn_D.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_D.FlatAppearance.BorderSize = 0;
            this.btn_D.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_D.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_D.ForeColor = System.Drawing.Color.White;
            this.btn_D.Location = new System.Drawing.Point(218, 166);
            this.btn_D.Name = "btn_D";
            this.btn_D.Size = new System.Drawing.Size(50, 50);
            this.btn_D.TabIndex = 94;
            this.btn_D.Text = "d";
            this.btn_D.UseVisualStyleBackColor = false;
            //
            //btn_S
            //
            this.btn_S.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_S.FlatAppearance.BorderSize = 0;
            this.btn_S.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_S.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_S.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_S.ForeColor = System.Drawing.Color.White;
            this.btn_S.Location = new System.Drawing.Point(166, 166);
            this.btn_S.Name = "btn_S";
            this.btn_S.Size = new System.Drawing.Size(50, 50);
            this.btn_S.TabIndex = 93;
            this.btn_S.Text = "s";
            this.btn_S.UseVisualStyleBackColor = false;
            //
            //btn_A
            //
            this.btn_A.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_A.FlatAppearance.BorderSize = 0;
            this.btn_A.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_A.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_A.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_A.ForeColor = System.Drawing.Color.White;
            this.btn_A.Location = new System.Drawing.Point(114, 166);
            this.btn_A.Name = "btn_A";
            this.btn_A.Size = new System.Drawing.Size(50, 50);
            this.btn_A.TabIndex = 92;
            this.btn_A.Text = "a";
            this.btn_A.UseVisualStyleBackColor = false;
            //
            //btnCaps
            //
            this.btnCaps.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnCaps.FlatAppearance.BorderSize = 0;
            this.btnCaps.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnCaps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnCaps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnCaps.ForeColor = System.Drawing.Color.White;
            this.btnCaps.Location = new System.Drawing.Point(21, 166);
            this.btnCaps.Name = "btnCaps";
            this.btnCaps.Size = new System.Drawing.Size(91, 50);
            this.btnCaps.TabIndex = 91;
            this.btnCaps.Text = "Caps";
            this.btnCaps.UseVisualStyleBackColor = false;
            //
            //btn14
            //
            this.btn14.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn14.FlatAppearance.BorderSize = 0;
            this.btn14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn14.ForeColor = System.Drawing.Color.White;
            this.btn14.Location = new System.Drawing.Point(723, 114);
            this.btn14.Name = "btn14";
            this.btn14.Size = new System.Drawing.Size(69, 50);
            this.btn14.TabIndex = 90;
            this.btn14.Text = "\\";
            this.btn14.UseVisualStyleBackColor = false;
            //
            //btn15
            //
            this.btn15.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn15.FlatAppearance.BorderSize = 0;
            this.btn15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn15.ForeColor = System.Drawing.Color.White;
            this.btn15.Location = new System.Drawing.Point(671, 114);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(50, 50);
            this.btn15.TabIndex = 89;
            this.btn15.Text = "]";
            this.btn15.UseVisualStyleBackColor = false;
            //
            //btn16
            //
            this.btn16.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn16.FlatAppearance.BorderSize = 0;
            this.btn16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn16.ForeColor = System.Drawing.Color.White;
            this.btn16.Location = new System.Drawing.Point(619, 114);
            this.btn16.Name = "btn16";
            this.btn16.Size = new System.Drawing.Size(50, 50);
            this.btn16.TabIndex = 88;
            this.btn16.Text = "[";
            this.btn16.UseVisualStyleBackColor = false;
            //
            //btn_P
            //
            this.btn_P.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_P.FlatAppearance.BorderSize = 0;
            this.btn_P.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_P.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_P.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_P.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_P.ForeColor = System.Drawing.Color.White;
            this.btn_P.Location = new System.Drawing.Point(567, 114);
            this.btn_P.Name = "btn_P";
            this.btn_P.Size = new System.Drawing.Size(50, 50);
            this.btn_P.TabIndex = 87;
            this.btn_P.Text = "p";
            this.btn_P.UseVisualStyleBackColor = false;
            //
            //btn_O
            //
            this.btn_O.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_O.FlatAppearance.BorderSize = 0;
            this.btn_O.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_O.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_O.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_O.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_O.ForeColor = System.Drawing.Color.White;
            this.btn_O.Location = new System.Drawing.Point(515, 114);
            this.btn_O.Name = "btn_O";
            this.btn_O.Size = new System.Drawing.Size(50, 50);
            this.btn_O.TabIndex = 86;
            this.btn_O.Text = "o";
            this.btn_O.UseVisualStyleBackColor = false;
            //
            //btn_I
            //
            this.btn_I.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_I.FlatAppearance.BorderSize = 0;
            this.btn_I.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_I.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_I.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_I.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_I.ForeColor = System.Drawing.Color.White;
            this.btn_I.Location = new System.Drawing.Point(463, 114);
            this.btn_I.Name = "btn_I";
            this.btn_I.Size = new System.Drawing.Size(50, 50);
            this.btn_I.TabIndex = 85;
            this.btn_I.Text = "i";
            this.btn_I.UseVisualStyleBackColor = false;
            //
            //btn_U
            //
            this.btn_U.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_U.FlatAppearance.BorderSize = 0;
            this.btn_U.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_U.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_U.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_U.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_U.ForeColor = System.Drawing.Color.White;
            this.btn_U.Location = new System.Drawing.Point(411, 114);
            this.btn_U.Name = "btn_U";
            this.btn_U.Size = new System.Drawing.Size(50, 50);
            this.btn_U.TabIndex = 84;
            this.btn_U.Text = "u";
            this.btn_U.UseVisualStyleBackColor = false;
            //
            //btn_Y
            //
            this.btn_Y.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_Y.FlatAppearance.BorderSize = 0;
            this.btn_Y.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_Y.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_Y.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_Y.ForeColor = System.Drawing.Color.White;
            this.btn_Y.Location = new System.Drawing.Point(359, 114);
            this.btn_Y.Name = "btn_Y";
            this.btn_Y.Size = new System.Drawing.Size(50, 50);
            this.btn_Y.TabIndex = 83;
            this.btn_Y.Text = "y";
            this.btn_Y.UseVisualStyleBackColor = false;
            //
            //btn_T
            //
            this.btn_T.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_T.FlatAppearance.BorderSize = 0;
            this.btn_T.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_T.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_T.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_T.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_T.ForeColor = System.Drawing.Color.White;
            this.btn_T.Location = new System.Drawing.Point(307, 114);
            this.btn_T.Name = "btn_T";
            this.btn_T.Size = new System.Drawing.Size(50, 50);
            this.btn_T.TabIndex = 82;
            this.btn_T.Text = "t";
            this.btn_T.UseVisualStyleBackColor = false;
            //
            //btn_R
            //
            this.btn_R.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_R.FlatAppearance.BorderSize = 0;
            this.btn_R.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_R.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_R.ForeColor = System.Drawing.Color.White;
            this.btn_R.Location = new System.Drawing.Point(255, 114);
            this.btn_R.Name = "btn_R";
            this.btn_R.Size = new System.Drawing.Size(50, 50);
            this.btn_R.TabIndex = 81;
            this.btn_R.Text = "r";
            this.btn_R.UseVisualStyleBackColor = false;
            //
            //btn_E
            //
            this.btn_E.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_E.FlatAppearance.BorderSize = 0;
            this.btn_E.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_E.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_E.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_E.ForeColor = System.Drawing.Color.White;
            this.btn_E.Location = new System.Drawing.Point(203, 114);
            this.btn_E.Name = "btn_E";
            this.btn_E.Size = new System.Drawing.Size(50, 50);
            this.btn_E.TabIndex = 80;
            this.btn_E.Text = "e";
            this.btn_E.UseVisualStyleBackColor = false;
            //
            //btn_W
            //
            this.btn_W.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_W.FlatAppearance.BorderSize = 0;
            this.btn_W.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_W.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_W.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_W.ForeColor = System.Drawing.Color.White;
            this.btn_W.Location = new System.Drawing.Point(151, 114);
            this.btn_W.Name = "btn_W";
            this.btn_W.Size = new System.Drawing.Size(50, 50);
            this.btn_W.TabIndex = 79;
            this.btn_W.Text = "w";
            this.btn_W.UseVisualStyleBackColor = false;
            //
            //btn_Q
            //
            this.btn_Q.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn_Q.FlatAppearance.BorderSize = 0;
            this.btn_Q.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn_Q.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn_Q.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Q.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn_Q.ForeColor = System.Drawing.Color.White;
            this.btn_Q.Location = new System.Drawing.Point(99, 114);
            this.btn_Q.Name = "btn_Q";
            this.btn_Q.Size = new System.Drawing.Size(50, 50);
            this.btn_Q.TabIndex = 78;
            this.btn_Q.Text = "q";
            this.btn_Q.UseVisualStyleBackColor = false;
            //
            //btnTab
            //
            this.btnTab.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnTab.FlatAppearance.BorderSize = 0;
            this.btnTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnTab.ForeColor = System.Drawing.Color.White;
            this.btnTab.Location = new System.Drawing.Point(21, 114);
            this.btnTab.Name = "btnTab";
            this.btnTab.Size = new System.Drawing.Size(76, 50);
            this.btnTab.TabIndex = 77;
            this.btnTab.Text = "Tab";
            this.btnTab.UseVisualStyleBackColor = false;
            //
            //btnBack
            //
            this.btnBack.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(697, 62);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(95, 50);
            this.btnBack.TabIndex = 76;
            this.btnBack.Text = "Backspace";
            this.btnBack.UseVisualStyleBackColor = false;
            //
            //btn13
            //
            this.btn13.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn13.FlatAppearance.BorderSize = 0;
            this.btn13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn13.ForeColor = System.Drawing.Color.Transparent;
            this.btn13.Location = new System.Drawing.Point(21, 62);
            this.btn13.Name = "btn13";
            this.btn13.Size = new System.Drawing.Size(50, 50);
            this.btn13.TabIndex = 75;
            this.btn13.Text = "~" + "\r" + "\n" + "`";
            this.btn13.UseVisualStyleBackColor = false;
            //
            //btn12
            //
            this.btn12.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn12.FlatAppearance.BorderSize = 0;
            this.btn12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn12.ForeColor = System.Drawing.Color.White;
            this.btn12.Location = new System.Drawing.Point(645, 62);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(50, 50);
            this.btn12.TabIndex = 74;
            this.btn12.Text = "+" + "\r" + "\n" + "=";
            this.btn12.UseVisualStyleBackColor = false;
            //
            //btn11
            //
            this.btn11.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn11.FlatAppearance.BorderSize = 0;
            this.btn11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn11.ForeColor = System.Drawing.Color.White;
            this.btn11.Location = new System.Drawing.Point(593, 62);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(50, 50);
            this.btn11.TabIndex = 73;
            this.btn11.Text = "_" + "\r" + "\n" + "-";
            this.btn11.UseVisualStyleBackColor = false;
            //
            //btn10
            //
            this.btn10.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn10.FlatAppearance.BorderSize = 0;
            this.btn10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn10.ForeColor = System.Drawing.Color.White;
            this.btn10.Location = new System.Drawing.Point(541, 62);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(50, 50);
            this.btn10.TabIndex = 72;
            this.btn10.Text = ")" + "\r" + "\n" + "0";
            this.btn10.UseVisualStyleBackColor = false;
            //
            //btn9
            //
            this.btn9.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.Location = new System.Drawing.Point(489, 62);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(50, 50);
            this.btn9.TabIndex = 71;
            this.btn9.Text = "(" + "\r" + "\n" + "9";
            this.btn9.UseVisualStyleBackColor = false;
            //
            //btn8
            //
            this.btn8.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.Location = new System.Drawing.Point(437, 62);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(50, 50);
            this.btn8.TabIndex = 70;
            this.btn8.Text = "*" + "\r" + "\n" + "8";
            this.btn8.UseVisualStyleBackColor = false;
            //
            //btn7
            //
            this.btn7.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.Location = new System.Drawing.Point(385, 62);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(50, 50);
            this.btn7.TabIndex = 69;
            this.btn7.Text = "&" + "\r" + "\n" + "7";
            this.btn7.UseMnemonic = false;
            this.btn7.UseVisualStyleBackColor = false;
            //
            //btn6
            //
            this.btn6.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.Location = new System.Drawing.Point(333, 62);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(50, 50);
            this.btn6.TabIndex = 68;
            this.btn6.Text = "^" + "\r" + "\n" + "6";
            this.btn6.UseVisualStyleBackColor = false;
            //
            //btn5
            //
            this.btn5.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(281, 62);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(50, 50);
            this.btn5.TabIndex = 67;
            this.btn5.Text = "%" + "\r" + "\n" + "5";
            this.btn5.UseVisualStyleBackColor = false;
            //
            //btn4
            //
            this.btn4.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.Location = new System.Drawing.Point(229, 62);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(50, 50);
            this.btn4.TabIndex = 66;
            this.btn4.Text = "$" + "\r" + "\n" + "4";
            this.btn4.UseVisualStyleBackColor = false;
            //
            //btn3
            //
            this.btn3.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.Location = new System.Drawing.Point(177, 62);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(50, 50);
            this.btn3.TabIndex = 65;
            this.btn3.Text = "#" + "\r" + "\n" + "3" + "\r" + "\n";
            this.btn3.UseVisualStyleBackColor = false;
            //
            //btn2
            //
            this.btn2.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(125, 62);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(50, 50);
            this.btn2.TabIndex = 64;
            this.btn2.Text = "@" + "\r" + "\n" + "2";
            this.btn2.UseVisualStyleBackColor = false;
            //
            //btn1
            //
            this.btn1.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(73, 62);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(50, 50);
            this.btn1.TabIndex = 63;
            this.btn1.Text = "!" + "\r" + "\n" + "1";
            this.btn1.UseVisualStyleBackColor = false;
            //
            //TextBox1
            //
            this.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.0F);
            this.TextBox1.Location = new System.Drawing.Point(21, 21);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(771, 32);
            this.TextBox1.TabIndex = 123;
            //
            //btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb((int)((byte)65), (int)((byte)65), (int)((byte)65));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb((int)((byte)0), (int)((byte)154), (int)((byte)187));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb((int)((byte)229), (int)((byte)229), (int)((byte)229));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(660, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 50);
            this.btnCancel.TabIndex = 124;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            //AlphaKeyboard3
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb((int)((byte)28), (int)((byte)28), (int)((byte)28));
            this.ClientSize = new System.Drawing.Size(815, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnSpace);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btn28);
            this.Controls.Add(this.btn40);
            this.Controls.Add(this.btn41);
            this.Controls.Add(this.btn_M);
            this.Controls.Add(this.btn_N);
            this.Controls.Add(this.btn_B);
            this.Controls.Add(this.btn_V);
            this.Controls.Add(this.btn_C);
            this.Controls.Add(this.btn_X);
            this.Controls.Add(this.btn_Z);
            this.Controls.Add(this.btnShiftL);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btn29);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn_L);
            this.Controls.Add(this.btn_K);
            this.Controls.Add(this.btn_J);
            this.Controls.Add(this.btn_H);
            this.Controls.Add(this.btn_G);
            this.Controls.Add(this.btn_F);
            this.Controls.Add(this.btn_D);
            this.Controls.Add(this.btn_S);
            this.Controls.Add(this.btn_A);
            this.Controls.Add(this.btnCaps);
            this.Controls.Add(this.btn14);
            this.Controls.Add(this.btn15);
            this.Controls.Add(this.btn16);
            this.Controls.Add(this.btn_P);
            this.Controls.Add(this.btn_O);
            this.Controls.Add(this.btn_I);
            this.Controls.Add(this.btn_U);
            this.Controls.Add(this.btn_Y);
            this.Controls.Add(this.btn_T);
            this.Controls.Add(this.btn_R);
            this.Controls.Add(this.btn_E);
            this.Controls.Add(this.btn_W);
            this.Controls.Add(this.btn_Q);
            this.Controls.Add(this.btnTab);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btn13);
            this.Controls.Add(this.btn12);
            this.Controls.Add(this.btn11);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlphaKeyboard3";
            this.Text = "AlphaKeyboard3";
            this.ResumeLayout(false);
            this.PerformLayout();

            //INSTANT C# NOTE: Converted design-time event handler wireups:
            base.Load += new System.EventHandler(Form_Load);
            btnShiftL.Click += new System.EventHandler(btnShiftR_Click);
            btnCaps.Click += new System.EventHandler(btnCaps_Click);
            btn1.Click += new System.EventHandler(btn28_Click);
            btn10.Click += new System.EventHandler(btn28_Click);
            btn11.Click += new System.EventHandler(btn28_Click);
            btn12.Click += new System.EventHandler(btn28_Click);
            btn13.Click += new System.EventHandler(btn28_Click);
            btn14.Click += new System.EventHandler(btn28_Click);
            btn28.Click += new System.EventHandler(btn28_Click);
            btn15.Click += new System.EventHandler(btn28_Click);
            btn16.Click += new System.EventHandler(btn28_Click);
            btn2.Click += new System.EventHandler(btn28_Click);
            btn29.Click += new System.EventHandler(btn28_Click);
            btn3.Click += new System.EventHandler(btn28_Click);
            btn30.Click += new System.EventHandler(btn28_Click);
            btn4.Click += new System.EventHandler(btn28_Click);
            btn40.Click += new System.EventHandler(btn28_Click);
            btn41.Click += new System.EventHandler(btn28_Click);
            btn5.Click += new System.EventHandler(btn28_Click);
            btn6.Click += new System.EventHandler(btn28_Click);
            btn7.Click += new System.EventHandler(btn28_Click);
            btn8.Click += new System.EventHandler(btn28_Click);
            btn9.Click += new System.EventHandler(btn28_Click);
            btn_A.Click += new System.EventHandler(btn28_Click);
            btn_B.Click += new System.EventHandler(btn28_Click);
            btn_C.Click += new System.EventHandler(btn28_Click);
            btn_D.Click += new System.EventHandler(btn28_Click);
            btn_E.Click += new System.EventHandler(btn28_Click);
            btn_F.Click += new System.EventHandler(btn28_Click);
            btn_G.Click += new System.EventHandler(btn28_Click);
            btn_H.Click += new System.EventHandler(btn28_Click);
            btn_I.Click += new System.EventHandler(btn28_Click);
            btn_J.Click += new System.EventHandler(btn28_Click);
            btn_K.Click += new System.EventHandler(btn28_Click);
            btn_L.Click += new System.EventHandler(btn28_Click);
            btn_M.Click += new System.EventHandler(btn28_Click);
            btn_N.Click += new System.EventHandler(btn28_Click);
            btn_O.Click += new System.EventHandler(btn28_Click);
            btn_P.Click += new System.EventHandler(btn28_Click);
            btn_Q.Click += new System.EventHandler(btn28_Click);
            btn_R.Click += new System.EventHandler(btn28_Click);
            btn_S.Click += new System.EventHandler(btn28_Click);
            btn_T.Click += new System.EventHandler(btn28_Click);
            btn_V.Click += new System.EventHandler(btn28_Click);
            btn_U.Click += new System.EventHandler(btn28_Click);
            btn_W.Click += new System.EventHandler(btn28_Click);
            btn_X.Click += new System.EventHandler(btn28_Click);
            btn_Y.Click += new System.EventHandler(btn28_Click);
            btn_Z.Click += new System.EventHandler(btn28_Click);
            btnLeft.Click += new System.EventHandler(btnLeft_Click);
            btnUp.Click += new System.EventHandler(btnUp_Click);
            btnRight.Click += new System.EventHandler(btnRight_Click);
            btnDown.Click += new System.EventHandler(btnDown_Click);
            btnBack.Click += new System.EventHandler(btnBack_Click);
            btnEnter.Click += new System.EventHandler(btnEnter_Click);
            btnTab.Click += new System.EventHandler(btnTab_Click);
            btnSpace.Click += new System.EventHandler(btnSpace_Click);
            btnSelectAll.Click += new System.EventHandler(btnSelectAll_Click);
            btnCancel.Click += new System.EventHandler(btnCancel_Click);
        }
        public AlphaKeyboard3(int keypadWidth) : this()
        {
            //Me.KeypadWidth = keypadWidth

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



        public bool PassWordCharacters
        {
            get
            {
                return TextBox1.UseSystemPasswordChar;
            }
            set
            {
                TextBox1.UseSystemPasswordChar = value;
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

        public string Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
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

        #region Methods

        private void Form_Load(object sender, EventArgs e)
        {

            foreach (Control ctl in this.Controls)
            {
                if (ctl.Name.StartsWith("btn_"))
                {
                    Button bttn = (Button)ctl;
                    bttn.Tag = bttn.Text.ToLower();
                }
                if (ctl.Name.StartsWith("btn"))
                {
                    Button bttn = (Button)ctl;
                    bttn.MouseEnter += mouseEnterHandler;
                    bttn.MouseLeave += mouseLeaveHandler;
                    bttn.MouseDown += mouseDownHandler;
                    bttn.MouseUp += mouseUpHandler;
                }
            }
            Lower();

        }

        public void mouseEnterHandler(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ForeColor = Color.Black;
            control.BackColor = Color.FromArgb(229, 229, 229);
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
            control.BackColor = Color.FromArgb(0, 154, 187);
        }

        public void mouseUpHandler(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.ForeColor = Color.Black;
            control.BackColor = Color.FromArgb(229, 229, 229);
        }

        private void btnShiftR_Click(object sender, EventArgs e)
        {
            if (ShiftMemory)
            {
                ShiftMemory = false;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name.StartsWith("btn_"))
                    {
                        Button bttn = (Button)ctl;
                        bttn.Tag = bttn.Text.ToLower();
                        bttn.Text = bttn.Text.ToLower();
                        Lower();
                    }
                }
            }
            else if (!ShiftMemory)
            {
                ShiftMemory = true;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name.StartsWith("btn_"))
                    {
                        Button bttn = (Button)ctl;
                        bttn.Tag = bttn.Text.ToUpper();
                        bttn.Text = bttn.Text.ToUpper();
                        Upper();
                    }
                }
            }
        }

        private void btnCaps_Click(object sender, EventArgs e)
        {
            if (CapsMemory)
            {
                CapsMemory = false;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name.StartsWith("btn_"))
                    {
                        Button bttn = (Button)ctl;
                        bttn.Tag = bttn.Text.ToLower();
                        bttn.Text = bttn.Text.ToLower();
                        Lower();
                    }
                }
            }
            else if (!CapsMemory)
            {
                CapsMemory = true;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl.Name.StartsWith("btn_"))
                    {
                        Button bttn = (Button)ctl;
                        bttn.Tag = bttn.Text.ToUpper();
                        bttn.Text = bttn.Text.ToUpper();
                        Upper();
                    }
                }
            }
        }

        private void Lower()
        {

            btn1.Tag = "1";
            btn2.Tag = "2";
            btn3.Tag = "3";
            btn4.Tag = "4";
            btn5.Tag = "5";
            btn6.Tag = "6";
            btn7.Tag = "7";
            btn8.Tag = "8";
            btn9.Tag = "9";
            btn10.Tag = "0";
            btn11.Tag = "-";
            btn12.Tag = "=";
            btn13.Tag = "`";
            btn14.Tag = "\\";
            btn15.Tag = "]";
            btn16.Tag = "[";
            btn29.Tag = "'";
            btn30.Tag = ";";
            btn28.Tag = "/";
            btn40.Tag = ".";
            btn41.Tag = ",";

        }

        private void Upper()
        {

            btn1.Tag = "!";
            btn2.Tag = "@";
            btn3.Tag = "#";
            btn4.Tag = "$";
            btn5.Tag = "{%}";
            btn6.Tag = "{^}";
            btn7.Tag = "&";
            btn8.Tag = "*";
            btn9.Tag = "{(}";
            btn10.Tag = "{)}";
            btn11.Tag = "{_}";
            btn12.Tag = "{+}";
            btn13.Tag = "{~}";
            btn14.Tag = "|";
            btn15.Tag = "}";
            btn16.Tag = "{";
            btn29.Tag = "\"";
            btn30.Tag = ":";
            btn28.Tag = "?";
            btn40.Tag = ">";
            btn41.Tag = "<";

        }

        private void btn28_Click(dynamic sender, EventArgs e)
        {


            string t = sender.Tag;
            if (ShiftMemory)
            {
                btnShiftL.PerformClick();
            }
            TextBox1.Focus();
            SendKeys.Send(t);

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("{LEFT}");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("{UP}");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("{RIGHT}");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("{DOWN}");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("{BACKSPACE}");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnTab_Click(object sender, EventArgs e)
        {
            //TextBox1.Focus()
            //SendKeys.Send("{TAB}")
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send(" ");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            TextBox1.Focus();
            SendKeys.Send("^{A}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}