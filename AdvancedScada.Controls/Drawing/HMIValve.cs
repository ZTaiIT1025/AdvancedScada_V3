
using AdvancedScada.DriverBase.Client;
using AdvancedScada.IBaseService;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AdvancedScada.HMIs.Drawing
{
    [ToolboxBitmap(typeof(HMIValve), "HMIValve.ico")]
	[ToolboxItem(true)]
	[Designer(typeof(HMIValveDesigner))]
	public class HMIValve : Control
	{
		private Timer timerLicence = new Timer();

		private Color tempColor = Color.Lime;

		private bool flagB;

		private HMIValveType c = HMIValveType.VT_Valve3;

		private HMIValveKnobType d = HMIValveKnobType.VKT_Rectangle;

		private Color e = Color.Gray;

		private int f = 1;

		private Color g = Color.Black;

		private DashStyle h;

		private bool i = true;

		private Point j = new Point(0, 0);

		private Point k = new Point(0, 0);

		private int l;

		private int m = 12;

		private bool n = true;

		private IContainer objIContainer;

		private string _TagName;

		[Description("Get/Set the value of the indicator")]
		[DefaultValue("true")]
		[Category("General")]
		private dynamic _Value;

		[Category("General")]
		[DefaultValue("Color.Black")]
		[Description("Get/Set the border line color")]
		public Color BorderColor
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

		[DefaultValue("DashStyle.Solid")]
		[Category("General")]
		[Description("Get/Set the dash style of the border line")]
		public DashStyle BorderDash
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

		[DefaultValue("1")]
		[Description("Get/Set border line width")]
		[Category("General")]
		public int BorderWidth
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

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (n)
				{
					createParams.ExStyle |= 32;
				}
				return createParams;
			}
		}

		[DefaultValue("True")]
		[Category("General")]
		[Description("Get/Set whether or not background is rendered in gradient mode")]
		public bool Gradient
		{
			get
			{
				return i;
			}
			set
			{
				i = value;
				b();
			}
		}

		[Description("Get/Set the knob color")]
		[DefaultValue("Color.Gray")]
		[Category("General")]
		public Color KnobColor
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

		[Description("Get/Set the width of the Knob Stick of the valve")]
		[Category("General")]
		[DefaultValue("12")]
		public int KnobStickWidth
		{
			get
			{
				return m;
			}
			set
			{
				if (value >= 4)
				{
					m = value;
					b();
				}
			}
		}

		[Category("General")]
		[Description("Get/Set the knob type of the valve")]
		[DefaultValue("DAS_ValveKnobType.VKT_Rectangle")]
		public HMIValveKnobType KnobType
		{
			get
			{
				return d;
			}
			set
			{
				d = value;
				b();
			}
		}

		[Category("General")]
		[DefaultValue("(0,0)")]
		[Description("Get/Set the Left_Top Offset of drawing rectangle")]
		public Point LeftTopOffset
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

		[Category("General")]
		[DefaultValue("(0,0)")]
		[Description("Get/Set the Right_Bottom Offset of drawing rectangle")]
		public Point RightBottomOffset
		{
			get
			{
				return k;
			}
			set
			{
				k = value;
				if (k.X < 0)
				{
					k.X = 0;
				}
				if (k.Y < 0)
				{
					k.Y = 0;
				}
				b();
			}
		}

		[Category("General")]
		[DefaultValue("0")]
		[Description("Get/Set the rotation angle of the valve")]
		public int ShapeRotationAngle
		{
			get
			{
				return l;
			}
			set
			{
				l = value;
				b();
			}
		}

		[Description("Get/Set whether the background is transparent or not")]
		[DefaultValue("True")]
		[Category("General")]
		public bool TransparentBackground
		{
			get
			{
				return n;
			}
			set
			{
				n = value;
				if (n)
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

		[Category("General")]
		[DefaultValue("DAS_ValveType.VT_Valve3")]
		[Description("Get/Set Valve Type")]
		public HMIValveType ValveTYpe
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

		[Browsable(true)]
		[Category("Link TagName")]
		public string TagName
		{
			get
			{
				return _TagName;
			}
			set
			{
				if (value != null)
				{
					_TagName = value.Trim();
				}
				else
				{
					_TagName = value;
				}
			}
		}

		public dynamic Value
		{
			get
			{
				return i;
			}
			set
			{
				try
				{
					if (value is bool)
					{
						if (i != value)
						{
							_Value = value;
							i = value;
							if (i)
							{
								KnobColor = Color.Lime;
								BackColor = Color.Lime;
							}
							else
							{
								KnobColor = Color.Gray;
								BackColor = Color.Silver;
							}
						}
					}
					else
					{
						_Value = value;
						switch ((byte)_Value)
						{
						case 0:
							KnobColor = Color.DarkGray;
							BackColor = Color.Silver;
							i = false;
							break;
						case 1:
							KnobColor = Color.Lime;
							BackColor = Color.Lime;
							i = true;
							break;
						case 2:
							KnobColor = Color.Red;
							BackColor = Color.Red;
							i = true;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					Invalidate();
				}
			}
		}

		public HMIValve()
		{
			ForeColor = Color.Silver;
			BackColor = Color.DarkGray;
			if (!n)
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
				SetStyle(ControlStyles.Opaque, value: true);
			}
			else
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
				SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			}
			Initialize();
		}

		private void Initialize()
		{
			objIContainer = new Container();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && objIContainer != null)
			{
				objIContainer.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
            if (!AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode && TagCollectionClient.Tags != null && !string.IsNullOrEmpty(_TagName) && !string.IsNullOrWhiteSpace(_TagName) && TagCollectionClient.Tags.Count != 0)
            {
                base.DataBindings.Add(new Binding("Value", TagCollectionClient.Tags[_TagName], "Value", formattingEnabled: true));
            }
        }

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			try
			{
				Rectangle rectangle = new Rectangle(base.ClientRectangle.Left + (f - 1), base.ClientRectangle.Top + (f - 1), base.ClientRectangle.Width - 1 - 2 * (f - 1), base.ClientRectangle.Height - 1 - 2 * (f - 1));
				if (rectangle.Width > j.X)
				{
					rectangle.X += j.X;
					rectangle.Width -= j.X;
				}
				if (rectangle.Height > j.Y)
				{
					rectangle.Y += j.Y;
					rectangle.Height -= j.Y;
				}
				if (rectangle.Width > k.X)
				{
					rectangle.Width -= k.X;
				}
				if (rectangle.Height > k.Y)
				{
					rectangle.Height -= k.Y;
				}
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				if (!n)
				{
					SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
					e.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
					Pen pen = new Pen(solidBrush);
					e.Graphics.DrawRectangle(pen, base.ClientRectangle);
					pen.Dispose();
					solidBrush.Dispose();
				}
				int left = rectangle.Left;
				int top = rectangle.Top;
				if (l != 0)
				{
					e.Graphics.TranslateTransform((rectangle.Left + rectangle.Right) / 2, (rectangle.Top + rectangle.Bottom) / 2);
					e.Graphics.RotateTransform(l);
					rectangle.X = -rectangle.Width / 2;
					rectangle.Y = -rectangle.Height / 2;
				}
				Pen pen2 = new Pen(g, f)
				{
					DashStyle = h
				};
				SolidBrush solidBrush2 = new SolidBrush(ForeColor);
				SolidBrush solidBrush3 = new SolidBrush(BackColor);
				GraphicsPath graphicsPath = new GraphicsPath();
				INBase iNBase = new INBase();
				if (c == HMIValveType.VT_Valve1 || c == HMIValveType.VT_Valve2 || c == HMIValveType.VT_Valve3)
				{
					Rectangle a_ = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
					Rectangle rectangle2 = new Rectangle(rectangle.Left + (rectangle.Width - m) / 2, rectangle.Top, m, rectangle.Height);
					if (d != 0)
					{
						a_.Y = rectangle.Bottom - 6 * rectangle.Height / 10;
						a_.Height = 6 * rectangle.Height / 10;
						rectangle2.Y = rectangle.Top + rectangle.Height / 10 - 1;
						rectangle2.Height = (a_.Top + a_.Bottom) / 2 - rectangle2.Y;
						if (i)
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, null, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillRectangle(solidBrush2, rectangle2);
						}
						e.Graphics.DrawRectangle(pen2, rectangle2);
						rectangle2.X = rectangle.Left + rectangle.Width / 2 - (int)(3.5 * (double)rectangle.Width / 10.0);
						rectangle2.Width = 7 * rectangle.Width / 10;
						rectangle2.Y = rectangle.Top;
						if (d == HMIValveKnobType.VKT_Rectangle)
						{
							rectangle2.Height = 2 * rectangle.Height / 10;
						}
						else
						{
							rectangle2.Height = 3 * rectangle.Height / 10;
						}
						if (d != HMIValveKnobType.VKT_Rectangle)
						{
							if (d != HMIValveKnobType.VKT_Ellipse)
							{
								graphicsPath.AddArc(rectangle2.Left, rectangle2.Top, rectangle2.Width, 2 * rectangle2.Height, 180f, 180f);
								graphicsPath.AddLine(rectangle2.Right, rectangle2.Bottom, rectangle2.Left, rectangle2.Bottom);
							}
							else
							{
								graphicsPath.AddEllipse(rectangle2);
							}
						}
						else
						{
							graphicsPath.AddRectangle(rectangle2);
						}
						if (!i)
						{
							SolidBrush solidBrush4 = new SolidBrush(this.e);
							e.Graphics.FillPath(solidBrush4, graphicsPath);
							solidBrush4.Dispose();
						}
						else if (d == HMIValveKnobType.VKT_Rectangle)
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, this.e, Color.White, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else if (d != HMIValveKnobType.VKT_Chord)
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, this.e, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						else
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, this.e, Color.White, HMIBkGradientStyle.BKGS_Shine, 270, 0.5f, 0, 0, 0.8f);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
					}
					graphicsPath.Reset();
					if (c == HMIValveType.VT_Valve1)
					{
						graphicsPath.AddLine((a_.Left + a_.Right) / 2, (a_.Top + a_.Bottom) / 2, a_.Left, a_.Top);
						graphicsPath.AddLine(a_.Left, a_.Top, a_.Left, a_.Bottom);
						graphicsPath.AddLine(a_.Left, a_.Bottom, (a_.Left + a_.Right) / 2, (a_.Top + a_.Bottom) / 2);
						graphicsPath.AddLine((a_.Left + a_.Right) / 2, (a_.Top + a_.Bottom) / 2, a_.Right, a_.Top);
						graphicsPath.AddLine(a_.Right, a_.Top, a_.Right, a_.Bottom);
						graphicsPath.AddLine(a_.Right, a_.Bottom, (a_.Left + a_.Right) / 2, (a_.Top + a_.Bottom) / 2);
						if (i)
						{
							iNBase.a(e.Graphics, a_, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush3, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
					}
					else
					{
						rectangle2.X = a_.Left + 1;
						rectangle2.Width = a_.Width - 2;
						if (c == HMIValveType.VT_Valve2)
						{
							rectangle2.Y = (a_.Top + a_.Bottom) / 2 - a_.Height / 3;
							rectangle2.Height = 2 * a_.Height / 3;
							graphicsPath.AddRectangle(rectangle2);
						}
						else
						{
							rectangle2.Y = a_.Y;
							rectangle2.Height = a_.Height;
							graphicsPath.AddEllipse(rectangle2);
						}
						if (i)
						{
							if (c != HMIValveType.VT_Valve2)
							{
								iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, Color.White, HMIBkGradientStyle.BKGS_Shine, 90, 0.5f, 0, 0, 0f);
							}
							else
							{
								iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
							}
						}
						else
						{
							e.Graphics.FillPath(solidBrush3, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
						rectangle2.X = a_.Left;
						rectangle2.Y = a_.Top;
						rectangle2.Width = m;
						rectangle2.Height = a_.Height;
						graphicsPath.AddRectangle(rectangle2);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
						rectangle2.X = a_.Right - m;
						graphicsPath.AddRectangle(rectangle2);
						if (!i)
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						else
						{
							iNBase.a(e.Graphics, rectangle2, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
					}
				}
				if (c != HMIValveType.VT_Valve4 && c != HMIValveType.VT_Valve5 && c != HMIValveType.VT_Valve6)
				{
					if (c == HMIValveType.VT_Valve7)
					{
						e.Graphics.DrawLine(pen2, rectangle.Left, (rectangle.Top + rectangle.Bottom) / 2, rectangle.Right, (rectangle.Top + rectangle.Bottom) / 2);
						Rectangle rect = new Rectangle((rectangle.Left + rectangle.Right) / 2 - 3 * rectangle.Width / 8, rectangle.Top - (rectangle.Height / 2 - f - 2), 3 * rectangle.Width / 4, 2 * (rectangle.Height / 2 - f - 2));
						e.Graphics.DrawArc(pen2, rect, 150f, -120f);
						rect.Y = (rectangle.Top + rectangle.Bottom) / 2 + f + 2;
						e.Graphics.DrawArc(pen2, rect, 210f, 120f);
					}
					else if (c == HMIValveType.VT_Valve8)
					{
						int num = rectangle.Height / 2;
						if (num > rectangle.Width / 2)
						{
							num = rectangle.Width / 2;
						}
						e.Graphics.DrawLine(pen2, rectangle.Left, (rectangle.Top + rectangle.Bottom) / 2, (rectangle.Left + rectangle.Right) / 2 - num / 2, (rectangle.Top + rectangle.Bottom) / 2);
						e.Graphics.DrawLine(pen2, (rectangle.Left + rectangle.Right) / 2 - num / 2, (rectangle.Top + rectangle.Bottom) / 2, (rectangle.Left + rectangle.Right) / 2 + num / 2, (rectangle.Top + rectangle.Bottom) / 2 - num);
						e.Graphics.DrawLine(pen2, (rectangle.Left + rectangle.Right) / 2 - num / 2, (rectangle.Top + rectangle.Bottom) / 2, (rectangle.Left + rectangle.Right) / 2 + num / 2, (rectangle.Top + rectangle.Bottom) / 2 + num);
						int num2 = m;
						if ((double)num2 > (double)num * Math.Sqrt(2.0) / 2.0)
						{
							num2 = (int)((double)num * Math.Sqrt(2.0) / 2.0);
						}
						int num3 = (rectangle.Left + rectangle.Right) / 2 - num / 2 + (int)((double)num2 * Math.Sqrt(2.0));
						Rectangle rectangle3 = new Rectangle(num3 - num2, (rectangle.Top + rectangle.Bottom) / 2 - num2, 2 * num2, 2 * num2);
						graphicsPath.AddEllipse(rectangle3);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle3, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Sphere, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
						e.Graphics.DrawLine(pen2, num3 + num2, (rectangle.Top + rectangle.Bottom) / 2, rectangle.Right, (rectangle.Top + rectangle.Bottom) / 2);
					}
					else if (c == HMIValveType.VT_Valve9)
					{
						Rectangle rectangle4 = new Rectangle(rectangle.Left, rectangle.Top, m, rectangle.Height);
						graphicsPath.AddRectangle(rectangle4);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle4, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
						rectangle4.X = rectangle.Left + m;
						rectangle4.Width = rectangle.Width - m;
						graphicsPath.AddLine(rectangle.Left + m, (rectangle.Top + rectangle.Bottom) / 2, rectangle.Right, rectangle.Top);
						graphicsPath.AddLine(rectangle.Right, rectangle.Top, rectangle.Right, rectangle.Bottom);
						graphicsPath.AddLine(rectangle.Right, rectangle.Bottom, rectangle.Left + m, (rectangle.Top + rectangle.Bottom) / 2);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle4, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush3, graphicsPath);
						}
						e.Graphics.DrawPath(pen2, graphicsPath);
						graphicsPath.Reset();
					}
				}
				else
				{
					Rectangle a_2 = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
					Rectangle rectangle5 = new Rectangle(rectangle.Left + (rectangle.Width - m) / 2, rectangle.Top, m, rectangle.Height);
					if (c == HMIValveType.VT_Valve4)
					{
						a_2.Y = rectangle.Bottom - 6 * rectangle.Height / 10;
						a_2.Height = 6 * rectangle.Height / 10;
					}
					graphicsPath.AddLine((a_2.Left + a_2.Right) / 2, (a_2.Top + a_2.Bottom) / 2, a_2.Left, a_2.Top);
					graphicsPath.AddLine(a_2.Left, a_2.Top, a_2.Left, a_2.Bottom);
					graphicsPath.AddLine(a_2.Left, a_2.Bottom, (a_2.Left + a_2.Right) / 2, (a_2.Top + a_2.Bottom) / 2);
					graphicsPath.AddLine((a_2.Left + a_2.Right) / 2, (a_2.Top + a_2.Bottom) / 2, a_2.Right, a_2.Top);
					graphicsPath.AddLine(a_2.Right, a_2.Top, a_2.Right, a_2.Bottom);
					graphicsPath.AddLine(a_2.Right, a_2.Bottom, (a_2.Left + a_2.Right) / 2, (a_2.Top + a_2.Bottom) / 2);
					if (i)
					{
						iNBase.a(e.Graphics, a_2, HMIShapeType.ST_Rectangle, graphicsPath, BackColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 90, 0.5f, 0, 0, 0f);
					}
					else
					{
						e.Graphics.FillPath(solidBrush3, graphicsPath);
					}
					e.Graphics.DrawPath(pen2, graphicsPath);
					graphicsPath.Reset();
					if (c == HMIValveType.VT_Valve4)
					{
						rectangle5.X = (a_2.Left + a_2.Right) / 2 - 3 * rectangle.Width / 10;
						rectangle5.Width = 6 * rectangle.Width / 10;
						rectangle5.Y = rectangle.Top;
						rectangle5.Height = (a_2.Top + a_2.Bottom) / 2 - rectangle.Top;
						graphicsPath.AddLine(rectangle5.Left, rectangle5.Top, rectangle5.Right, rectangle5.Top);
						graphicsPath.AddLine(rectangle5.Right, rectangle5.Top, (rectangle5.Left + rectangle5.Right) / 2, rectangle5.Bottom);
						graphicsPath.AddLine((rectangle5.Left + rectangle5.Right) / 2, rectangle5.Bottom, rectangle5.Left, rectangle5.Top);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle5, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
					}
					else if (c != HMIValveType.VT_Valve5)
					{
						rectangle5.X = (a_2.Left + a_2.Right) / 2 - m / 2;
						rectangle5.Width = m;
						rectangle5.Y = (a_2.Top + a_2.Bottom) / 2 - m / 2;
						rectangle5.Height = m;
						graphicsPath.AddEllipse(rectangle5);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle5, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Sphere, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
					}
					else
					{
						rectangle5.X = (a_2.Left + a_2.Right) / 2 - m / 2;
						rectangle5.Width = m;
						rectangle5.Y = rectangle.Top;
						rectangle5.Height = rectangle.Height;
						graphicsPath.AddRectangle(rectangle5);
						if (i)
						{
							iNBase.a(e.Graphics, rectangle5, HMIShapeType.ST_Rectangle, graphicsPath, ForeColor, Color.White, HMIBkGradientStyle.BKGS_Linear2, 0, 0.5f, 0, 0, 0f);
						}
						else
						{
							e.Graphics.FillPath(solidBrush2, graphicsPath);
						}
					}
					e.Graphics.DrawPath(pen2, graphicsPath);
					graphicsPath.Reset();
				}
				if (l != 0)
				{
					e.Graphics.ResetTransform();
					rectangle.X = left;
					rectangle.Y = top;
				}
				pen2.Dispose();
				graphicsPath.Dispose();
				solidBrush2.Dispose();
				solidBrush3.Dispose();
				if (flagB)
				{
					SolidBrush solidBrush5 = new SolidBrush(Color.Red);
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					e.Graphics.DrawString("Designed By Hao Thien Co.,Ltd: 0909.886.483", Font, solidBrush5, base.ClientRectangle, format);
					solidBrush5.Dispose();
				}
			}
			catch (ApplicationException ex)
			{
				SolidBrush solidBrush6 = new SolidBrush(Color.Black);
				e.Graphics.DrawString("The control size is too small", Font, solidBrush6, base.ClientRectangle);
				solidBrush6.Dispose();
				MessageBox.Show(ex.ToString());
			}
		}

		private void a(object sender, EventArgs e)
		{
			flagB = true;
			timerLicence.Enabled = false;
		}

		protected void b()
		{
			if (n)
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
			if (!n)
			{
				base.OnPaintBackground(A_0);
			}
		}
	}
}
