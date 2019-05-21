using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.ButtonAll;
using AdvancedScada.Controls.ClassBase;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;

using AdvancedScada.Monitor;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Linear
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMILinearMeterV), "HMI7Segment.ico")]
    [Designer(typeof(HMILinearMeterVDesigner))]
    public class HMILinearMeterV : LinearMeterBase
    {


        private Rectangle ValueRectangle;

        private SolidBrush ValueBrush;

        private Blend m_blend;


        public HMILinearMeterV()
        {

            this.ValueRectangle = new Rectangle();
            m_blend = new Blend();
            this.ValueRectangle = new Rectangle();
            base.BackColor = Color.FromArgb(255, 255, 255);
            base.ForeColor = Color.Black;
            this.m_blend.Factors = new float[] { 0.5F, 0.85F, 0.2F };
            this.m_blend.Positions = new float[] { 0.0F, 0.3F, 1.0F };

            this.ValueBrush = new SolidBrush(Color.Red);
        }



        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            this.CreateStaticImage();
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            string str = null;
            LinearGradientBrush linearGradientBrush = null;
            base.OnPaint(e);
            if (this.BackBuffer != null)
            {
                Graphics graphic = Graphics.FromImage(this.BackBuffer);
                graphic.DrawImage(this.StaticImage, 0, 0);
                double num = Math.Max(Math.Min(this.Value, this.m_Maximum / this.m_ValueScaleFactor), this.m_Minimum / this.m_ValueScaleFactor);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.Width = checked(this.BarRectangle.Width - 2);
                this.ValueRectangle.Width = this.BarRectangle.Width - 2;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.X = checked(this.BarRectangle.X + 1);
                this.ValueRectangle.X = this.BarRectangle.X + 1;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.ValueRectangle.Height = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(checked(this.BarRectangle.Height - 2)));
                this.ValueRectangle.Height = Convert.ToInt32((num * this.m_ValueScaleFactor - this.m_Minimum) / (this.m_Maximum - this.m_Minimum) * (double)(this.BarRectangle.Height - 2));
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: int y = checked(checked(checked(checked(checked(this.BarRectangle.Y + 1) + this.BarRectangle.Height) - 1) - this.ValueRectangle.Height) - 1);
                int y = ((this.BarRectangle.Y + 1 + this.BarRectangle.Height) - 1 - this.ValueRectangle.Height) - 1;
                if (this.m_FillType == FillTypes.WideBand)
                {
                    this.ValueRectangle.Height = 12;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.ValueRectangle.Y = checked(y - 6);
                    this.ValueRectangle.Y = y - 6;
                }
                else if (this.m_FillType != FillTypes.NarrowBand)
                {
                    this.ValueRectangle.Y = y;
                }
                else
                {
                    this.ValueRectangle.Height = 4;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.ValueRectangle.Y = checked(y - 2);
                    this.ValueRectangle.Y = y - 2;
                }
                if (this.ValueRectangle.Height > 0 && this.ValueRectangle.Width > 0)
                {
                    double mTargetValue = this.m_TargetValue;
                    if (this.m_ScaleTargetValue)
                    {
                        mTargetValue = this.m_TargetValue * this.m_ValueScaleFactor;
                    }
                    if (!(this.m_Value * this.m_ValueScaleFactor >= mTargetValue - this.m_ToleranceMinus && this.m_Value * this.m_ValueScaleFactor <= mTargetValue + this.m_TolerancePlus))
                    {
                        this.ValueBrush.Color = Color.Red;
                        linearGradientBrush = new LinearGradientBrush(this.ValueRectangle, HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColor, 0.5), HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColor, 2), 0.0F, false);
                    }
                    else
                    {
                        this.ValueBrush.Color = Color.Green;
                        linearGradientBrush = new LinearGradientBrush(this.ValueRectangle, HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.5), HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 1.5), 0.0F, false);
                    }
                    Blend blend = new Blend();
                    float[] singleArray = { 0.5F, 0.85F, 0.2F };
                    blend.Factors = singleArray;
                    singleArray = new float[] { 0.0F, 0.3F, 1.0F };
                    blend.Positions = singleArray;
                    linearGradientBrush.Blend = blend;
                    graphic.FillRectangle(linearGradientBrush, this.ValueRectangle);
                }
                if (this.m_FillType != FillTypes.Fill)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: graphic.DrawLine(Pens.Black, this.ValueRectangle.X, y, checked(checked(this.ValueRectangle.X + this.ValueRectangle.Width) - 1), y);
                    graphic.DrawLine(Pens.Black, this.ValueRectangle.X, y, (this.ValueRectangle.X + this.ValueRectangle.Width) - 1, y);
                }
                this.sf.Alignment = StringAlignment.Center;
                if ((this.m_NumericFormat == null || string.Compare(this.m_NumericFormat, string.Empty) == 0) ? true : false)
                {
                    str = Conversions.ToString(this.m_Value);
                }
                else
                {
                    try
                    {
                        str = this.m_Value.ToString(this.m_NumericFormat);
                    }
                    catch (Exception exception)
                    {
                        ProjectData.SetProjectError(exception);
                        str = "NumericFormat Invalid";
                        ProjectData.ClearProjectError();
                    }
                }
                if (this.m_FillType != FillTypes.Fill)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.X = checked(this.BarRectangle.X + 1);
                    this.TextRectangle.X = this.BarRectangle.X + 1;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.Y = checked(checked(this.ValueRectangle.Y - this.Font.Height) - 2);
                    this.TextRectangle.Y = (this.ValueRectangle.Y - this.Font.Height) - 2;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: this.TextRectangle.Height = checked(this.Font.Height + 2);
                    this.TextRectangle.Height = this.Font.Height + 2;
                    this.TextRectangle.Width = this.BarRectangle.Width;
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if (this.TextRectangle.Y < this.BarRectangle.Y & this.TextRectangle.Y >= checked(this.BarRectangle.Y - 5))
                    if (this.TextRectangle.Y < this.BarRectangle.Y && this.TextRectangle.Y >= this.BarRectangle.Y - 5)
                    {
                        this.TextRectangle.Y = this.BarRectangle.Y;
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: if (this.TextRectangle.Y < checked(this.BarRectangle.Y - 5))
                    if (this.TextRectangle.Y < this.BarRectangle.Y - 5)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: this.TextRectangle.Y = checked(checked(this.ValueRectangle.Y + this.ValueRectangle.Height) + 1);
                        this.TextRectangle.Y = (this.ValueRectangle.Y + this.ValueRectangle.Height) + 1;
                    }
                    this.sf.LineAlignment = StringAlignment.Center;
                    this.sf.Alignment = StringAlignment.Center;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.TextRectangle, this.sf);
                }
                else if (this.ValueRectangle.Height <= this.Font.Height)
                {
                    this.sf.LineAlignment = StringAlignment.Far;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.BarRectangle, this.sf);
                }
                else
                {
                    this.sf.LineAlignment = StringAlignment.Near;
                    graphic.DrawString(str, this.Font, this.TextBrush, this.ValueRectangle, this.sf);
                }
                e.Graphics.DrawImage(this.BackBuffer, 0, 0);
            }
        }


        protected override void CreateStaticImage()
        {
            Rectangle rectangle = new Rectangle();
            int num = 0;
            int x = 0;
            int num1 = 0;
            if (!(this.Width <= 0 && this.Height <= 0))
            {
                this.BackBuffer = new Bitmap(this.Width, this.Height);
                this.StaticImage = new Bitmap(this.Width, this.Height);
                Graphics graphic = Graphics.FromImage(this.StaticImage);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 1)), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
                graphic.FillRectangle(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_BorderColor, 1)), this.m_BorderWidth * 2, this.m_BorderWidth * 2, this.Width - this.m_BorderWidth * 4, this.Height - this.m_BorderWidth * 4);
                HMIBeveledButtonDisplay.Draw3DBorder(this, graphic, this.m_BorderColor, this.m_BorderWidth);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(this.BackColor), checked(this.m_BorderWidth * 2), checked(this.m_BorderWidth * 2), checked(this.Width - checked(this.m_BorderWidth * 4)), checked(this.Height - checked(this.m_BorderWidth * 4)));
                graphic.FillRectangle(new SolidBrush(this.BackColor), this.m_BorderWidth * 2, this.m_BorderWidth * 2, this.Width - this.m_BorderWidth * 4, this.Height - this.m_BorderWidth * 4);
                StringFormat stringFormat = new StringFormat();
                if ((this.Text == null || string.Compare(this.Text, string.Empty) == 0) ? false : true)
                {
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: rectangle = new Rectangle(checked(this.m_BorderWidth * 2), checked(checked(this.m_BorderWidth * 2) + 1), checked(checked(this.Width - checked(this.m_BorderWidth * 4)) - 1), checked(checked(this.Height - checked(this.m_BorderWidth * 4)) - 2));
                    rectangle = new Rectangle(this.m_BorderWidth * 2, (this.m_BorderWidth * 2) + 1, (this.Width - this.m_BorderWidth * 4) - 1, (this.Height - this.m_BorderWidth * 4) - 2);
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Near;
                    graphic.DrawString(this.Text, this.Font, this.TextBrush, rectangle, stringFormat);
                }
                SizeF sizeF = graphic.MeasureString(this.Text, this.Font, rectangle.Width);
                byte r = this.ForeColor.R;
                byte g = this.ForeColor.G;
                //INSTANT VB NOTE: The variable foreColor was renamed since Visual Basic does not handle local variables named the same as class members well:
                Color foreColor_Renamed = this.ForeColor;
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: graphic.DrawLine(new Pen(Color.FromArgb(80, (int)r, (int)g, (int)foreColor.B), 2f), (float)(checked(this.m_BorderWidth * 2)), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f, (float)(checked(this.Width - checked(this.m_BorderWidth * 2))), sizeF.Height + (float)(checked(this.m_BorderWidth * 2)) + 2f);
                graphic.DrawLine(new Pen(Color.FromArgb(80, (int)r, (int)g, (int)foreColor_Renamed.B), 2.0F), (float)(this.m_BorderWidth * 2), sizeF.Height + (float)(this.m_BorderWidth * 2) + 2.0F, (float)(this.Width - this.m_BorderWidth * 2), sizeF.Height + (float)(this.m_BorderWidth * 2) + 2.0F);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: this.BarRectangle = new Rectangle(checked((int)Math.Round((double)this.Width / 15 + (double)(checked(this.m_BorderWidth * 2)))), checked((int)Math.Round((double)((float)(sizeF.Height + (float)this.Font.Height + (float)(checked(this.m_BorderWidth * 2)))))), checked((int)Math.Round((double)(checked(checked(this.Width - this.MajorDivisions) - checked(this.BorderWidth * 2))) / 2.75)), checked((int)Math.Round((double)((float)(checked(this.Height - checked(this.m_BorderWidth * 4))) - sizeF.Height) - (double)this.Font.Height * 1.5)));
                this.BarRectangle = new Rectangle(Convert.ToInt32(Math.Truncate(Math.Round((double)this.Width / 15 + (double)(this.m_BorderWidth * 2)))), Convert.ToInt32(Math.Truncate(Math.Round((double)(sizeF.Height + (float)this.Font.Height + (float)(this.m_BorderWidth * 2))))), Convert.ToInt32(Math.Truncate(Math.Round((double)((this.Width - this.MajorDivisions) - this.BorderWidth * 2) / 2.75))), Convert.ToInt32(Math.Truncate(Math.Round((double)((float)(this.Height - this.m_BorderWidth * 4) - sizeF.Height) - (double)this.Font.Height * 1.5))));
                graphic.FillRectangle(Brushes.LightGray, this.BarRectangle);
                int num2 = Convert.ToInt32((double)this.Width * 0.12);
                int num3 = Convert.ToInt32((double)this.Width * 0.08);
                Pen pen = new Pen(this.ForeColor, 2.0F);
                Pen pen1 = new Pen(this.ForeColor, 1.0F);
                if (this.m_ShowValidRangeMarker)
                {
                    double mTargetValue = this.m_TargetValue;
                    if (this.m_ScaleTargetValue)
                    {
                        mTargetValue = this.m_TargetValue * this.m_ValueScaleFactor;
                    }
                    //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                    //ORIGINAL LINE: int yPos = checked(this.ValueToYPos(Math.Max(mTargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum)));
                    int yPos = this.ValueToYPos(Math.Max(mTargetValue - this.m_ToleranceMinus, this.m_Minimum)) - this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum));
                    if (yPos > 0)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.FillRectangle(new SolidBrush(BeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum)), num3, yPos);
                        graphic.FillRectangle(new SolidBrush(HMIBeveledButtonDisplay.GetRelativeColor(this.m_FillColorInRange, 0.7)), (this.BarRectangle.X + this.BarRectangle.Width) + 2, this.ValueToYPos(Math.Min(mTargetValue + this.m_TolerancePlus, this.m_Maximum)), num3, yPos);
                    }
                }
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), this.BarRectangle.Y);
                Point point = new Point((this.BarRectangle.X + this.BarRectangle.Width) + 2, this.BarRectangle.Y);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Point point1 = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2), this.BarRectangle.Y);
                Point point1 = new Point((this.BarRectangle.X + this.BarRectangle.Width) + num2, this.BarRectangle.Y);
                graphic.DrawLine(pen, point, point1);
                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                //ORIGINAL LINE: Rectangle rectangle1 = new Rectangle(checked(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2) + 2), checked(this.BarRectangle.Y - this.Font.Height), this.Width, checked(this.Font.Height * 2));
                Rectangle rectangle1 = new Rectangle((this.BarRectangle.X + this.BarRectangle.Width + num2) + 2, this.BarRectangle.Y - this.Font.Height, this.Width, this.Font.Height * 2);
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Near;
                graphic.DrawString(Conversions.ToString(this.m_Maximum), this.Font, this.TextBrush, rectangle1, stringFormat);
                if (this.m_MajorDivisions > 0)
                {
                    while (num < this.m_MajorDivisions)
                    {
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: num1 = checked((int)Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)(checked(num + 1)) - 1));
                        num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)(num + 1) - 1)));
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: x = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2);
                        x = (this.BarRectangle.X + this.BarRectangle.Width) + 2;
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: int x1 = checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num2);
                        int x1 = (this.BarRectangle.X + this.BarRectangle.Width) + num2;
                        point1 = new Point(x, num1);
                        point = new Point(x1, num1);
                        graphic.DrawLine(pen, point1, point);
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: rectangle1 = new Rectangle(checked(x1 + 2), checked(num1 - this.Font.Height), checked(this.Width - x1), checked(this.Font.Height * 2));
                        rectangle1 = new Rectangle(x1 + 2, num1 - this.Font.Height, this.Width - x1, this.Font.Height * 2);
                        //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                        //ORIGINAL LINE: graphic.DrawString(Conversions.ToString(this.m_Maximum - (double)(checked(num + 1)) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                        graphic.DrawString(Conversions.ToString(this.m_Maximum - (double)(num + 1) * ((this.m_Maximum - this.m_Minimum) / (double)this.m_MajorDivisions)), this.Font, this.TextBrush, rectangle1, stringFormat);
                        if (this.m_MinorDivisions > 1)
                        {
                            int i = 0;
                            //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                            //ORIGINAL LINE: for (int i = 0; i < checked(this.m_MinorDivisions - 1); i += 1)
                            while (i < this.m_MinorDivisions - 1)
                            {
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: int num4 = checked((int)Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)(checked(this.m_MajorDivisions * this.m_MinorDivisions)) * (double)(checked(i + 1)) + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)num - 1));
                                int num4 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.Y + (double)this.BarRectangle.Height / (double)(this.m_MajorDivisions * this.m_MinorDivisions) * (double)(i + 1) + (double)this.BarRectangle.Height / (double)this.m_MajorDivisions * (double)num - 1)));
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: point1 = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + 2), num4);
                                point1 = new Point((this.BarRectangle.X + this.BarRectangle.Width) + 2, num4);
                                //INSTANT VB TODO TASK: There is no VB equivalent to 'checked' in this context:
                                //ORIGINAL LINE: point = new Point(checked(checked(this.BarRectangle.X + this.BarRectangle.Width) + num3), num4);
                                point = new Point((this.BarRectangle.X + this.BarRectangle.Width) + num3, num4);
                                graphic.DrawLine(pen1, point1, point);
                                i += 1;
                            }
                        }
                        num += 1;
                    }
                    graphic.DrawLine(pen1, x, Convert.ToInt32(this.BarRectangle.Y), x, num1);
                }
                this.Invalidate();
            }
        }

        private int ValueToYPos(double value)
        {
            double mMaximum = this.m_Maximum - this.m_Minimum;
            double num = (value - this.m_Minimum) / mMaximum;
            int num1 = Convert.ToInt32(Math.Truncate(Math.Round((double)this.BarRectangle.Height * num)));
            int y = (this.BarRectangle.Y + this.BarRectangle.Height) - num1;
            return y;
        }

        #region propartas

        private string _TagName;

        [Category("Link TagName")]
        [Browsable(true)]
        public string TagName
        {
            get { return _TagName; }

            set
            {
                _TagName = value;
                try
                {
                    if (string.IsNullOrEmpty(_TagName) || string.IsNullOrWhiteSpace(_TagName) ||
                        Licenses.LicenseManager.IsInDesignMode) return;
                    var bd = new Binding("Value", TagCollectionClient.Tags[_TagName], "Value", true);
                    if (DataBindings.Count > 0) DataBindings.Clear();
                    DataBindings.Add(bd);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion
    }

    internal class HMILinearMeterVDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMILinearMeterVListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMILinearMeterVListItem : DesignerActionList
    {
        private readonly HMILinearMeterV _HMILinearMeterV;

        public HMILinearMeterVListItem(HMILinearMeterVDesigner owner)
            : base(owner.Component)
        {
            _HMILinearMeterV = (HMILinearMeterV)owner.Component;
        }


        public string TagName
        {
            get { return _HMILinearMeterV.TagName; }
            set { _HMILinearMeterV.TagName = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMILinearMeterV, "TagName", tagName); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}