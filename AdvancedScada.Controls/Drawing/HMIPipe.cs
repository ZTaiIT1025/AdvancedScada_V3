using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AdvancedScada.HMIs.Drawing
{
	[ToolboxBitmap(typeof(HMIsPipes), "DASNetPipe.ico")]
	public class HMIsPipes : Control
	{
		 
		private bool flabB;

		private HMIPipeType c;

		private int d = 20;

		private int e = 1;

		private Color f = Color.DimGray;

		private DashStyle g;

		private bool h = true;

		private Point i = new Point(0, 0);

		private Point j = new Point(0, 0);

		private bool k = true;

		private IContainer l;

		[Description("Get/Set whether or not background is rendered in gradient mode")]
		[DefaultValue("true")]
		[Category("General")]
		public bool BkGradient
		{
			get
			{
				return h;
			}
			set
			{
				h = value;
				b();
			}
		}

		[Category("General")]
		[Description("Get/Set the border line color")]
		[DefaultValue("Color.DimGray")]
		public Color BorderColor
		{
			get
			{
				return f;
			}
			set
			{
				f = value;
				b();
			}
		}

		[DefaultValue("DashStyle.Solid")]
		[Description("Get/Set the dash style of the border line")]
		[Category("General")]
		public DashStyle BorderDash
		{
			get
			{
				return g;
			}
			set
			{
				g = value;
				b();
			}
		}

		[DefaultValue("1")]
		[Category("General")]
		[Description("Get/Set border line width")]
		public int BorderWidth
		{
			get
			{
				return e;
			}
			set
			{
				e = value;
				b();
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (k)
				{
					createParams.ExStyle |= 32;
				}
				return createParams;
			}
		}

		[Description("Get/Set the Left_Top Offset of drawing rectangle")]
		[DefaultValue("(0,0)")]
		[Category("General")]
		public Point LeftTopOffset
		{
			get
			{
				return i;
			}
			set
			{
				i = value;
				if (i.X < 0)
				{
					i.X = 0;
				}
				if (i.Y < 0)
				{
					i.Y = 0;
				}
				b();
			}
		}

		[Description("Get/Set the size of the pipe")]
		[Category("General")]
		[DefaultValue("20")]
		public int PipeSize
		{
			get
			{
				return d;
			}
			set
			{
				if (value >= 2)
				{
					d = value;
					b();
				}
			}
		}

		[DefaultValue("DAS_PipeType.PT_Horizontal")]
		[Description("Get/Set Pipe Type")]
		[Category("General")]
		public HMIPipeType PipeTYpe
		{
			get
			{
				return c;
			}
			set
			{
				c = value;
				b();
			}
		}

		[Category("General")]
		[DefaultValue("(0,0)")]
		[Description("Get/Set the Right_Bottom Offset of drawing rectangle")]
		public Point RightBottomOffset
		{
			get
			{
				return j;
			}
			set
			{
				j = value;
				if (j.X < 0)
				{
					j.X = 0;
				}
				if (j.Y < 0)
				{
					j.Y = 0;
				}
				b();
			}
		}

		[DefaultValue("True")]
		[Category("General")]
		[Description("Get/Set whether the background is transparent or not")]
		public bool TransparentBackground
		{
			get
			{
				return k;
			}
			set
			{
				k = value;
				if (k)
				{
					SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
					SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
				}
				else
				{
					SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
					SetStyle(ControlStyles.Opaque, value: true);
				}
				b();
			}
		}

		public HMIsPipes()
		{
			BackColor = Color.Gray;
			ForeColor = Color.White;
			if (!k)
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
				SetStyle(ControlStyles.Opaque, value: true);
			}
			else
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
				SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			}
			a();
		}

		private void a()
		{
			l = new Container();
		}

		protected override void Dispose(bool A_0)
		{
			if (A_0 && l != null)
			{
				l.Dispose();
			}
			base.Dispose(A_0);
		}

		protected override void OnPaint(PaintEventArgs A_0)
		{
			try
			{
				base.OnPaint(A_0);
				Rectangle rectangle = new Rectangle(base.ClientRectangle.Left + (e - 1), base.ClientRectangle.Top + (e - 1), base.ClientRectangle.Width - 1 - 2 * (e - 1), base.ClientRectangle.Height - 1 - 2 * (e - 1));
				if (rectangle.Width > i.X)
				{
					rectangle.X += i.X;
					rectangle.Width -= i.X;
				}
				if (rectangle.Height > i.Y)
				{
					rectangle.Y += i.Y;
					rectangle.Height -= i.Y;
				}
				if (rectangle.Width > j.X)
				{
					rectangle.Width -= j.X;
				}
				if (rectangle.Height > j.Y)
				{
					rectangle.Height -= j.Y;
				}
				A_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				A_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				if (!k)
				{
					SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
					A_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
					Pen pen = new Pen(solidBrush);
					A_0.Graphics.DrawRectangle(pen, base.ClientRectangle);
					pen.Dispose();
					solidBrush.Dispose();
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				int num = (rectangle.Left + rectangle.Right) / 2;
				int num2 = (rectangle.Top + rectangle.Bottom) / 2;
				int num3 = d;
				Rectangle rectangle2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				INBase iNBase = new INBase();
				SolidBrush solidBrush2 = new SolidBrush(BackColor);
				Pen pen2 = new Pen(f);
				if (e > 0)
				{
					pen2.Width = e;
				}
				pen2.DashStyle = g;
				if (c == HMIPipeType.PT_Horizontal)
				{
					if (num3 > rectangle.Height)
					{
						num3 = rectangle.Height;
					}
					rectangle2.Y = num2 - num3 / 2;
					rectangle2.Height = num3;
					graphicsPath.AddRectangle(rectangle2);
					if (h)
					{
						iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
					}
					else
					{
						A_0.Graphics.FillPath(solidBrush2, graphicsPath);
					}
					if (e > 0)
					{
						A_0.Graphics.DrawLine(pen2, rectangle2.Left, rectangle2.Top, rectangle2.Right, rectangle2.Top);
						A_0.Graphics.DrawLine(pen2, rectangle2.Left, rectangle2.Bottom, rectangle2.Right, rectangle2.Bottom);
					}
				}
				else if (c != HMIPipeType.PT_Vertical)
				{
					if (c == HMIPipeType.PT_LeftTop)
					{
						if (num3 > rectangle.Width)
						{
							num3 = rectangle.Width;
						}
						if (num3 > rectangle.Height)
						{
							num3 = rectangle.Height;
						}
						graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left + num3, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Bottom, rectangle.Left + num3, rectangle.Top);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Top, rectangle.Left, rectangle.Top);
						graphicsPath.CloseFigure();
						if (!h)
						{
							A_0.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						else
						{
							rectangle2.Width = num3;
							iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						graphicsPath.Reset();
						graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
						graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Top + num3);
						graphicsPath.AddLine(rectangle.Right, rectangle.Top + num3, rectangle.Left + num3, rectangle.Top + num3);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Top + num3, rectangle.Left, rectangle.Top);
						graphicsPath.CloseFigure();
						if (!h)
						{
							A_0.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						else
						{
							rectangle2.Width = rectangle.Width;
							rectangle2.Height = num3;
							iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						if (e > 0)
						{
							A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
							A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, rectangle.Bottom, rectangle.Left + num3, rectangle.Top + num3);
							A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
							A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top + num3, rectangle.Left + num3, rectangle.Top + num3);
						}
					}
					else if (c != HMIPipeType.PT_LeftBottom)
					{
						if (c == HMIPipeType.PT_RightTop)
						{
							if (num3 > rectangle.Width)
							{
								num3 = rectangle.Width;
							}
							if (num3 > rectangle.Height)
							{
								num3 = rectangle.Height;
							}
							graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
							graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right - num3, rectangle.Bottom);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Bottom, rectangle.Right - num3, rectangle.Top);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Top, rectangle.Right, rectangle.Top);
							graphicsPath.CloseFigure();
							if (h)
							{
								rectangle2.X = rectangle.Right - num3;
								rectangle2.Width = num3;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							graphicsPath.Reset();
							graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top);
							graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Top + num3);
							graphicsPath.AddLine(rectangle.Left, rectangle.Top + num3, rectangle.Right - num3, rectangle.Top + num3);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Top + num3, rectangle.Right, rectangle.Top);
							graphicsPath.CloseFigure();
							if (!h)
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							else
							{
								rectangle2.X = rectangle.X;
								rectangle2.Width = rectangle.Width;
								rectangle2.Height = num3;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
							}
							if (e > 0)
							{
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
								A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, rectangle.Bottom, rectangle.Right - num3, rectangle.Top + num3);
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top, rectangle.Left, rectangle.Top);
								A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top + num3, rectangle.Right - num3, rectangle.Top + num3);
							}
						}
						else if (c == HMIPipeType.PT_RightBottom)
						{
							if (num3 > rectangle.Width)
							{
								num3 = rectangle.Width;
							}
							if (num3 > rectangle.Height)
							{
								num3 = rectangle.Height;
							}
							graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
							graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right - num3, rectangle.Bottom);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Bottom, rectangle.Right - num3, rectangle.Top);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Top, rectangle.Right, rectangle.Top);
							graphicsPath.CloseFigure();
							if (!h)
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							else
							{
								rectangle2.X = rectangle.Right - num3;
								rectangle2.Width = num3;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
							}
							graphicsPath.Reset();
							graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Left, rectangle.Bottom);
							graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left, rectangle.Bottom - num3);
							graphicsPath.AddLine(rectangle.Left, rectangle.Bottom - num3, rectangle.Right - num3, rectangle.Bottom - num3);
							graphicsPath.AddLine(rectangle.Right - num3, rectangle.Bottom - num3, rectangle.Right, rectangle.Bottom);
							graphicsPath.CloseFigure();
							if (h)
							{
								rectangle2.X = rectangle.X;
								rectangle2.Width = rectangle.Width;
								rectangle2.Y = rectangle.Bottom - num3;
								rectangle2.Height = num3;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							if (e > 0)
							{
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Bottom, rectangle.Left, rectangle.Bottom);
								A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Bottom - num3, rectangle.Right - num3, rectangle.Bottom - num3);
								A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, rectangle.Bottom - num3, rectangle.Right - num3, rectangle.Top);
							}
						}
						else if (c == HMIPipeType.PT_TopLeftRight)
						{
							if (num3 > rectangle.Width)
							{
								num3 = rectangle.Width;
							}
							if (num3 > rectangle.Height)
							{
								num3 = rectangle.Height;
							}
							rectangle2.Y = rectangle.Bottom - num3;
							rectangle2.Height = num3;
							graphicsPath.AddRectangle(rectangle2);
							if (h)
							{
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							graphicsPath.Reset();
							graphicsPath.AddLine(num - num3 / 2, rectangle.Top, num - num3 / 2 + num3, rectangle.Top);
							graphicsPath.AddLine(num - num3 / 2 + num3, rectangle.Top, num - num3 / 2 + num3, rectangle.Bottom - num3);
							graphicsPath.AddLine(num - num3 / 2 + num3, rectangle.Bottom - num3, num, rectangle.Bottom - num3 / 2);
							graphicsPath.AddLine(num, rectangle.Bottom - num3 / 2, num - num3 / 2, rectangle.Bottom - num3);
							graphicsPath.AddLine(num - num3 / 2, rectangle.Bottom - num3, num - num3 / 2, rectangle.Top);
							graphicsPath.CloseFigure();
							if (h)
							{
								rectangle2.X = num - num3 / 2;
								rectangle2.Width = num3;
								rectangle2.Y = rectangle.Top;
								rectangle2.Height = rectangle.Height;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							if (e > 0)
							{
								A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Bottom - num3, num - num3 / 2 + num3, rectangle.Bottom - num3);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, rectangle.Bottom - num3, num - num3 / 2 + num3, rectangle.Top);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Top, num - num3 / 2, rectangle.Bottom - num3);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Bottom - num3, rectangle.Left, rectangle.Bottom - num3);
							}
						}
						else if (c != HMIPipeType.PT_BottomLeftRight)
						{
							if (c == HMIPipeType.PT_LeftTopBottom)
							{
								if (num3 > rectangle.Width)
								{
									num3 = rectangle.Width;
								}
								if (num3 > rectangle.Height)
								{
									num3 = rectangle.Height;
								}
								rectangle2.X = rectangle.Right - num3;
								rectangle2.Width = num3;
								graphicsPath.AddRectangle(rectangle2);
								if (!h)
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								else
								{
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
								}
								graphicsPath.Reset();
								graphicsPath.AddLine(rectangle.Left, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Left, num2 - num3 / 2 + num3, rectangle.Right - num3, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Right - num3, num2 - num3 / 2 + num3, rectangle.Right - num3 / 2, num2);
								graphicsPath.AddLine(rectangle.Right - num3 / 2, num2, rectangle.Right - num3, num2 - num3 / 2);
								graphicsPath.AddLine(rectangle.Right - num3, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2);
								graphicsPath.CloseFigure();
								if (!h)
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								else
								{
									rectangle2.Y = num2 - num3 / 2;
									rectangle2.Height = num3;
									rectangle2.X = rectangle.Left;
									rectangle2.Width = rectangle.Width;
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
								}
								if (e > 0)
								{
									A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
									A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, rectangle.Bottom, rectangle.Right - num3, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, num2 - num3 / 2 + num3, rectangle.Left, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, rectangle.Top, rectangle.Right - num3, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, rectangle.Right - num3, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2);
								}
							}
							else if (c == HMIPipeType.PT_RightTopBottom)
							{
								if (num3 > rectangle.Width)
								{
									num3 = rectangle.Width;
								}
								if (num3 > rectangle.Height)
								{
									num3 = rectangle.Height;
								}
								rectangle2.Width = num3;
								graphicsPath.AddRectangle(rectangle2);
								if (h)
								{
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
								}
								else
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								graphicsPath.Reset();
								graphicsPath.AddLine(rectangle.Right, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Right, num2 - num3 / 2 + num3, rectangle.Left + num3, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Left + num3, num2 - num3 / 2 + num3, rectangle.Left + num3 / 2, num2);
								graphicsPath.AddLine(rectangle.Left + num3 / 2, num2, rectangle.Left + num3, num2 - num3 / 2);
								graphicsPath.AddLine(rectangle.Left + num3, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2);
								graphicsPath.CloseFigure();
								if (!h)
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								else
								{
									rectangle2.Y = num2 - num3 / 2;
									rectangle2.Height = num3;
									rectangle2.X = rectangle.Left;
									rectangle2.Width = rectangle.Width;
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
								}
								if (e > 0)
								{
									A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
									A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, rectangle.Bottom, rectangle.Left + num3, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, num2 - num3 / 2 + num3, rectangle.Right, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, rectangle.Top, rectangle.Left + num3, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2);
								}
							}
							else if (c != HMIPipeType.PT_Cross)
							{
								if (c != HMIPipeType.PT_LeftTopArc)
								{
									if (c == HMIPipeType.PT_LeftBottomArc)
									{
										if (num3 > rectangle.Width / 4)
										{
											num3 = rectangle.Width / 4;
										}
										if (num3 > rectangle.Height / 4)
										{
											num3 = rectangle.Height / 4;
										}
										rectangle2.X = rectangle.Left;
										rectangle2.Width = 2 * rectangle.Width;
										rectangle2.Y = rectangle.Top - rectangle.Height;
										rectangle2.Height = 2 * rectangle.Height;
										graphicsPath.AddArc(rectangle2, 90f, 90f);
										graphicsPath.AddArc(rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 180f, -90f);
										graphicsPath.CloseFigure();
										if (!h)
										{
											A_0.Graphics.FillPath(solidBrush2, graphicsPath);
										}
										else
										{
											iNBase.a(A_0.Graphics, rectangle2, graphicsPath, BackColor, ForeColor, num3);
										}
										if (e > 0)
										{
											A_0.Graphics.DrawArc(pen2, rectangle2, 90f, 90f);
											A_0.Graphics.DrawArc(pen2, rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 180, -90);
										}
									}
									else if (c != HMIPipeType.PT_RightTopArc)
									{
										if (c == HMIPipeType.PT_RightBottomArc)
										{
											if (num3 > rectangle.Width / 4)
											{
												num3 = rectangle.Width / 4;
											}
											if (num3 > rectangle.Height / 4)
											{
												num3 = rectangle.Height / 4;
											}
											rectangle2.X = rectangle.Left - rectangle.Width;
											rectangle2.Width = 2 * rectangle.Width;
											rectangle2.Y = rectangle.Top - rectangle.Height;
											rectangle2.Height = 2 * rectangle.Height;
											graphicsPath.AddArc(rectangle2, 0f, 90f);
											graphicsPath.AddArc(rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 90f, -90f);
											graphicsPath.CloseFigure();
											if (!h)
											{
												A_0.Graphics.FillPath(solidBrush2, graphicsPath);
											}
											else
											{
												iNBase.a(A_0.Graphics, rectangle2, graphicsPath, BackColor, ForeColor, num3);
											}
											if (e > 0)
											{
												A_0.Graphics.DrawArc(pen2, rectangle2, 0f, 90f);
												A_0.Graphics.DrawArc(pen2, rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 90, -90);
											}
										}
									}
									else
									{
										if (num3 > rectangle.Width / 4)
										{
											num3 = rectangle.Width / 4;
										}
										if (num3 > rectangle.Height / 4)
										{
											num3 = rectangle.Height / 4;
										}
										rectangle2.X = rectangle.Left - rectangle.Width;
										rectangle2.Width = 2 * rectangle.Width;
										rectangle2.Y = rectangle.Top;
										rectangle2.Height = 2 * rectangle.Height;
										graphicsPath.AddArc(rectangle2, 270f, 90f);
										graphicsPath.AddArc(rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 360f, -90f);
										graphicsPath.CloseFigure();
										if (!h)
										{
											A_0.Graphics.FillPath(solidBrush2, graphicsPath);
										}
										else
										{
											iNBase.a(A_0.Graphics, rectangle2, graphicsPath, BackColor, ForeColor, num3);
										}
										if (e > 0)
										{
											A_0.Graphics.DrawArc(pen2, rectangle2, 270f, 90f);
											A_0.Graphics.DrawArc(pen2, rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 360, -90);
										}
									}
								}
								else
								{
									if (num3 > rectangle.Width / 4)
									{
										num3 = rectangle.Width / 4;
									}
									if (num3 > rectangle.Height / 4)
									{
										num3 = rectangle.Height / 4;
									}
									rectangle2.X = rectangle.Left;
									rectangle2.Width = 2 * rectangle.Width;
									rectangle2.Y = rectangle.Top;
									rectangle2.Height = 2 * rectangle.Height;
									graphicsPath.AddArc(rectangle2, 180f, 90f);
									graphicsPath.AddArc(rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 270f, -90f);
									graphicsPath.CloseFigure();
									if (h)
									{
										iNBase.a(A_0.Graphics, rectangle2, graphicsPath, BackColor, ForeColor, num3);
									}
									else
									{
										A_0.Graphics.FillPath(solidBrush2, graphicsPath);
									}
									if (e > 0)
									{
										A_0.Graphics.DrawArc(pen2, rectangle2, 180f, 90f);
										A_0.Graphics.DrawArc(pen2, rectangle2.Left + num3, rectangle2.Top + num3, rectangle2.Width - 2 * num3, rectangle2.Height - 2 * num3, 270, -90);
									}
								}
							}
							else
							{
								if (num3 > rectangle.Width / 2)
								{
									num3 = rectangle.Width / 2;
								}
								if (num3 > rectangle.Height / 2)
								{
									num3 = rectangle.Height / 2;
								}
								rectangle2.X = num - num3 / 2;
								rectangle2.Width = num3;
								graphicsPath.AddRectangle(rectangle2);
								if (h)
								{
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
								}
								else
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								graphicsPath.Reset();
								graphicsPath.AddLine(rectangle.Right, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Right, num2 - num3 / 2 + num3, num - num3 / 2 + num3, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(num - num3 / 2 + num3, num2 - num3 / 2 + num3, num, num2);
								graphicsPath.AddLine(num, num2, num - num3 / 2 + num3, num2 - num3 / 2);
								graphicsPath.AddLine(num - num3 / 2 + num3, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2);
								graphicsPath.CloseFigure();
								if (!h)
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								else
								{
									rectangle2.Y = num2 - num3 / 2;
									rectangle2.Height = num3;
									rectangle2.X = num;
									rectangle2.Width = rectangle.Right - num;
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
								}
								graphicsPath.Reset();
								graphicsPath.AddLine(rectangle.Left, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(rectangle.Left, num2 - num3 / 2 + num3, num - num3 / 2, num2 - num3 / 2 + num3);
								graphicsPath.AddLine(num - num3 / 2, num2 - num3 / 2 + num3, num, num2);
								graphicsPath.AddLine(num, num2, num - num3 / 2, num2 - num3 / 2);
								graphicsPath.AddLine(num - num3 / 2, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2);
								graphicsPath.CloseFigure();
								if (h)
								{
									rectangle2.Y = num2 - num3 / 2;
									rectangle2.Height = num3;
									rectangle2.X = num;
									rectangle2.Width = rectangle.Right - num;
									iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
								}
								else
								{
									A_0.Graphics.FillPath(solidBrush2, graphicsPath);
								}
								if (e > 0)
								{
									A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, rectangle.Top, num - num3 / 2 + num3, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, num2 - num3 / 2, rectangle.Right, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, rectangle.Bottom, num - num3 / 2 + num3, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, num2 - num3 / 2 + num3, rectangle.Right, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Top, num - num3 / 2, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2, num2 - num3 / 2, rectangle.Left, num2 - num3 / 2);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Bottom, num - num3 / 2, num2 - num3 / 2 + num3);
									A_0.Graphics.DrawLine(pen2, num - num3 / 2, num2 - num3 / 2 + num3, rectangle.Left, num2 - num3 / 2 + num3);
								}
							}
						}
						else
						{
							if (num3 > rectangle.Width)
							{
								num3 = rectangle.Width;
							}
							if (num3 > rectangle.Height)
							{
								num3 = rectangle.Height;
							}
							rectangle2.Height = num3;
							graphicsPath.AddRectangle(rectangle2);
							if (h)
							{
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							graphicsPath.Reset();
							graphicsPath.AddLine(num - num3 / 2, rectangle.Bottom, num - num3 / 2 + num3, rectangle.Bottom);
							graphicsPath.AddLine(num - num3 / 2 + num3, rectangle.Bottom, num - num3 / 2 + num3, rectangle.Top + num3);
							graphicsPath.AddLine(num - num3 / 2 + num3, rectangle.Top + num3, num, rectangle.Top + num3 / 2);
							graphicsPath.AddLine(num, rectangle.Top + num3 / 2, num - num3 / 2, rectangle.Top + num3);
							graphicsPath.AddLine(num - num3 / 2, rectangle.Top + num3, num - num3 / 2, rectangle.Bottom);
							graphicsPath.CloseFigure();
							if (h)
							{
								rectangle2.X = num - num3 / 2;
								rectangle2.Width = num3;
								rectangle2.Y = rectangle.Top;
								rectangle2.Height = rectangle.Height;
								iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
							}
							else
							{
								A_0.Graphics.FillPath(solidBrush2, graphicsPath);
							}
							if (e > 0)
							{
								A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top);
								A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Top + num3, num - num3 / 2 + num3, rectangle.Top + num3);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2 + num3, rectangle.Top + num3, num - num3 / 2 + num3, rectangle.Bottom);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Bottom, num - num3 / 2, rectangle.Top + num3);
								A_0.Graphics.DrawLine(pen2, num - num3 / 2, rectangle.Top + num3, rectangle.Left, rectangle.Top + num3);
							}
						}
					}
					else
					{
						if (num3 > rectangle.Width)
						{
							num3 = rectangle.Width;
						}
						if (num3 > rectangle.Height)
						{
							num3 = rectangle.Height;
						}
						graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Left + num3, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Bottom, rectangle.Left + num3, rectangle.Top);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Top, rectangle.Left, rectangle.Top);
						graphicsPath.CloseFigure();
						if (h)
						{
							rectangle2.Width = num3;
							iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							A_0.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						graphicsPath.Reset();
						graphicsPath.AddLine(rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Bottom - num3);
						graphicsPath.AddLine(rectangle.Right, rectangle.Bottom - num3, rectangle.Left + num3, rectangle.Bottom - num3);
						graphicsPath.AddLine(rectangle.Left + num3, rectangle.Bottom - num3, rectangle.Left, rectangle.Bottom);
						graphicsPath.CloseFigure();
						if (!h)
						{
							A_0.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						else
						{
							rectangle2.Width = rectangle.Width;
							rectangle2.Y = rectangle.Bottom - num3;
							rectangle2.Height = num3;
							iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						if (e > 0)
						{
							A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Top, rectangle.Left, rectangle.Bottom);
							A_0.Graphics.DrawLine(pen2, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom);
							A_0.Graphics.DrawLine(pen2, rectangle.Right, rectangle.Bottom - num3, rectangle.Left + num3, rectangle.Bottom - num3);
							A_0.Graphics.DrawLine(pen2, rectangle.Left + num3, rectangle.Bottom - num3, rectangle.Left + num3, rectangle.Top);
						}
					}
				}
				else
				{
					if (num3 > rectangle.Width)
					{
						num3 = rectangle.Width;
					}
					rectangle2.X = num - num3 / 2;
					rectangle2.Width = num3;
					graphicsPath.AddRectangle(rectangle2);
					if (!h)
					{
						A_0.Graphics.FillPath(solidBrush2, graphicsPath);
					}
					else
					{
						iNBase.a(A_0.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, ForeColor, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
					}
					if (e > 0)
					{
						A_0.Graphics.DrawLine(pen2, rectangle2.Left, rectangle2.Top, rectangle2.Left, rectangle2.Bottom);
						A_0.Graphics.DrawLine(pen2, rectangle2.Right, rectangle2.Top, rectangle2.Right, rectangle2.Bottom);
					}
				}
				solidBrush2.Dispose();
				pen2.Dispose();
				graphicsPath.Dispose();
				if (flabB)
				{
					SolidBrush solidBrush3 = new SolidBrush(Color.Red);
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					A_0.Graphics.DrawString("Designed By Hao Thien Co.,Ltd: 0909.886.483", Font, solidBrush3, base.ClientRectangle, format);
					solidBrush3.Dispose();
				}
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void a(object sender, EventArgs e)
		{
			flabB = true;
			 
		}

		protected void b()
		{
			if (k)
			{
				if (base.Parent != null)
				{
					Rectangle rc = new Rectangle(base.Location, base.Size);
					base.Parent.Invalidate(rc, invalidateChildren: true);
				}
			}
			else
			{
				Invalidate();
			}
		}

		protected override void OnPaintBackground(PaintEventArgs A_0)
		{
			if (!k)
			{
				base.OnPaintBackground(A_0);
			}
		}
	}
}
