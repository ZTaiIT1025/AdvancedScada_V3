
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace AdvancedScada.Controls
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class RotationValueEditorForm : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
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

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.ValueAtMaxCCWTextBox = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.ValueAtMaxCWTextBox = new System.Windows.Forms.TextBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.CCWRotationTextBox = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.CWRotationTextBox = new System.Windows.Forms.TextBox();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.XPositionTextBox = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.YPositionTextBox = new System.Windows.Forms.TextBox();
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Button1.Location = new System.Drawing.Point(494, 399);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "OK";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(400, 399);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.ValueAtMaxCCWTextBox);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.ValueAtMaxCWTextBox);
			this.GroupBox1.Location = new System.Drawing.Point(12, 15);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(549, 112);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Value From PLC";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(250, 54);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(100, 13);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Value at Max CCW:";
			//
			//ValueAtMaxCCWTextBox
			//
			this.ValueAtMaxCCWTextBox.Location = new System.Drawing.Point(359, 54);
			this.ValueAtMaxCCWTextBox.Name = "ValueAtMaxCCWTextBox";
			this.ValueAtMaxCCWTextBox.Size = new System.Drawing.Size(100, 20);
			this.ValueAtMaxCCWTextBox.TabIndex = 2;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(15, 57);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(93, 13);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Value at Max CW:";
			//
			//ValueAtMaxCWTextBox
			//
			this.ValueAtMaxCWTextBox.Location = new System.Drawing.Point(114, 54);
			this.ValueAtMaxCWTextBox.Name = "ValueAtMaxCWTextBox";
			this.ValueAtMaxCWTextBox.Size = new System.Drawing.Size(100, 20);
			this.ValueAtMaxCWTextBox.TabIndex = 0;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.Label3);
			this.GroupBox2.Controls.Add(this.CCWRotationTextBox);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Controls.Add(this.CWRotationTextBox);
			this.GroupBox2.Location = new System.Drawing.Point(12, 133);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(549, 112);
			this.GroupBox2.TabIndex = 3;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Picture Rotation Angle";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(271, 46);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(79, 13);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "CCW Rotation:";
			//
			//CCWRotationTextBox
			//
			this.CCWRotationTextBox.Location = new System.Drawing.Point(359, 46);
			this.CCWRotationTextBox.Name = "CCWRotationTextBox";
			this.CCWRotationTextBox.Size = new System.Drawing.Size(100, 20);
			this.CCWRotationTextBox.TabIndex = 6;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(70, 49);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(72, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "CW Rotation:";
			//
			//CWRotationTextBox
			//
			this.CWRotationTextBox.Location = new System.Drawing.Point(148, 46);
			this.CWRotationTextBox.Name = "CWRotationTextBox";
			this.CWRotationTextBox.Size = new System.Drawing.Size(100, 20);
			this.CWRotationTextBox.TabIndex = 4;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.Label5);
			this.GroupBox3.Controls.Add(this.XPositionTextBox);
			this.GroupBox3.Controls.Add(this.Label6);
			this.GroupBox3.Controls.Add(this.YPositionTextBox);
			this.GroupBox3.Location = new System.Drawing.Point(12, 251);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(549, 112);
			this.GroupBox3.TabIndex = 3;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Center of Rotation Offset from Center";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(296, 49);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(57, 13);
			this.Label5.TabIndex = 7;
			this.Label5.Text = "X Position:";
			//
			//XPositionTextBox
			//
			this.XPositionTextBox.Location = new System.Drawing.Point(359, 46);
			this.XPositionTextBox.Name = "XPositionTextBox";
			this.XPositionTextBox.Size = new System.Drawing.Size(100, 20);
			this.XPositionTextBox.TabIndex = 6;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(85, 49);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(57, 13);
			this.Label6.TabIndex = 5;
			this.Label6.Text = "Y Position:";
			//
			//YPositionTextBox
			//
			this.YPositionTextBox.Location = new System.Drawing.Point(148, 46);
			this.YPositionTextBox.Name = "YPositionTextBox";
			this.YPositionTextBox.Size = new System.Drawing.Size(100, 20);
			this.YPositionTextBox.TabIndex = 4;
			//
			//RotationValueEditorForm
			//
			this.AcceptButton = this.Button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 434);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Name = "RotationValueEditorForm";
			this.Text = "RotationValue";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.ResumeLayout(false);

//INSTANT C# NOTE: Converted design-time event handler wireups:
			Button1.Click += new System.EventHandler(Button1_Click);
		}

		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox ValueAtMaxCCWTextBox;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox ValueAtMaxCWTextBox;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox CCWRotationTextBox;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox CWRotationTextBox;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox XPositionTextBox;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox YPositionTextBox;
	}

}