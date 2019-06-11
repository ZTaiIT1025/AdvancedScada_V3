
using AdvancedScada.DriverBase.Client;
using AdvancedScada.IBaseService;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AdvancedScada.HMIs.Drawing
{
    [Designer(typeof(HMILineDesigner))]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(HMILine), "HMILine.ico")]
	public class HMILine : Control
	{
		private Timer timerLicence = new Timer();

		private Color tempColor = Color.Lime;

		private Point aa = new Point(0, 0);

		private Point ab = new Point(0, 0);

		private Point ac = new Point(0, 0);

		private bool ad;

		private float ae = 0.25f;

		private float af = 0.1f;

		private float ag = 0.3f;

		private float ah = 0.1f;

		private IContainer ai;

		private bool flagB;

		private HMILineType c;

		private int d = 1;

		private Color e = Color.Black;

		private bool f;

		private Color g = Color.White;

		private int h;

		private bool i = true;

		private LineCap j;

		private LineCap k;

		private DashStyle l;

		private DashCap m;

		private HMICustomizedCap n;

		private int o = 2;

		private HMICustomizedCap p;

		private int q = 2;

		private bool r = true;

		private bool s = true;

		private bool t = true;

		private bool u = true;

		private Point v = new Point(0, 0);

		private Point w = new Point(0, 0);

		private int x;

		private int y = 180;

		private Point z = new Point(0, 0);

		private string _TagName;

		private dynamic _Value;

		[Category("Link TagName")]
		[Browsable(true)]
		public string TagName
		{
			get
			{
				return _TagName;
			}
			set
			{
				FireChanged();
				try
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
				catch (Exception ex)
				{
					MessageBox.Show($"HMILine(TagName): {ex.Message}({_TagName})");
				}
				finally
				{
					FireChanged();
				}
			}
		}

		public dynamic Value
		{
			get
			{
				return _Value;
			}
			set
			{
				try
				{
					if (value is bool)
					{
						_Value = ((value == null) ? ((object)false) : value);
						if ((bool)value)
						{
							LineColor = Color.Lime;
						}
						else
						{
							LineColor = Color.Silver;
						}
					}
					else
					{
						_Value = value;
						switch ((int)_Value)
						{
						case 0:
							LineColor = Color.Silver;
							break;
						case 1:
							LineColor = Color.Lime;
							u = true;
							break;
						case 2:
							LineColor = Color.Red;
							u = true;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("HMILine: " + ex.Message);
				}
				finally
				{
					Invalidate();
				}
			}
		}

		[DefaultValue("180")]
		[Category("Position")]
		[Description("Get/Set the end angle of the arc")]
		public int ArcEndAngle
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
				b();
			}
		}

		[DefaultValue("0")]
		[Description("Get/Set the start angle of the arc")]
		[Category("Position")]
		public int ArcStartAngle
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
				b();
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (i)
				{
					createParams.ExStyle |= 32;
				}
				return createParams;
			}
		}

		[DefaultValue("(0,0)")]
		[Description("Get/Set the second curve point of the line")]
		[Category("Position")]
		public Point CurvePoint2
		{
			get
			{
				return z;
			}
			set
			{
				z = value;
				b();
			}
		}

		[Description("Get/Set the third curve point of the line")]
		[Category("Position")]
		[DefaultValue("(0,0)")]
		public Point CurvePoint3
		{
			get
			{
				return aa;
			}
			set
			{
				aa = value;
				b();
			}
		}

		[Category("Cap_Dash")]
		[DefaultValue("2")]
		[Description("Get/Set the size of the customized end cap")]
		public int CustomizedEndCapSize
		{
			get
			{
				return q;
			}
			set
			{
				if (value > 0)
				{
					q = value;
					b();
				}
			}
		}

		[Description("Get/Set the customized end cap of the line")]
		[Category("Cap_Dash")]
		[DefaultValue("DAS_CustomizedCap.Arrow")]
		public HMICustomizedCap CustomizedEndCapType
		{
			get
			{
				return p;
			}
			set
			{
				p = value;
				b();
			}
		}

		[Description("Get/Set whether the customized end cap of the line is at inner side or not")]
		[DefaultValue("true")]
		[Category("Cap_Dash")]
		public bool CustomizedInnerEndCap
		{
			get
			{
				return t;
			}
			set
			{
				t = value;
				b();
			}
		}

		[Description("Get/Set whether the customized start cap of the line is at inner side or not")]
		[Category("Cap_Dash")]
		[DefaultValue("true")]
		public bool CustomizedInnerStartCap
		{
			get
			{
				return r;
			}
			set
			{
				r = value;
				b();
			}
		}

		[Category("Cap_Dash")]
		[Description("Get/Set whether the customized end cap of the line is solid or not")]
		[DefaultValue("true")]
		public bool CustomizedSolidEndCap
		{
			get
			{
				return u;
			}
			set
			{
				u = value;
				b();
			}
		}

		[Category("Cap_Dash")]
		[Description("Get/Set whether the customized start cap of the line is solid or not")]
		[DefaultValue("true")]
		public bool CustomizedSolidStartCap
		{
			get
			{
				return s;
			}
			set
			{
				s = value;
				b();
			}
		}

		[Description("Get/Set the size of the customized start cap")]
		[Category("Cap_Dash")]
		[DefaultValue("2")]
		public int CustomizedStartCapSize
		{
			get
			{
				return o;
			}
			set
			{
				if (value > 0)
				{
					o = value;
					b();
				}
			}
		}

		[DefaultValue("DAS_CustomizedCap.Arrow")]
		[Category("Cap_Dash")]
		[Description("Get/Set the customized start cap of the line")]
		public HMICustomizedCap CustomizedStartCapType
		{
			get
			{
				return n;
			}
			set
			{
				n = value;
				b();
			}
		}

		[Category("Cap_Dash")]
		[DefaultValue("DashStyle.Solid")]
		[Description("Get/Set the dash style of the line")]
		public DashStyle Dash
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

		[Category("Cap_Dash")]
		[Description("Get/Set the dash cap style of the line")]
		[DefaultValue("DashCap.Flat")]
		public DashCap DashCapType
		{
			get
			{
				return m;
			}
			set
			{
				m = value;
				b();
			}
		}

		[Category("Cap_Dash")]
		[DefaultValue("LineCap.Flat")]
		[Description("Get/Set the cap type of the end point of the line")]
		public LineCap EndCap
		{
			get
			{
				return k;
			}
			set
			{
				k = value;
				b();
			}
		}

		[Category("Position")]
		[DefaultValue("(0,0)")]
		[Description("Get/Set the end point of the line")]
		public Point EndPoint
		{
			get
			{
				return w;
			}
			set
			{
				w = value;
				b();
			}
		}

		[DefaultValue("false")]
		[Description("Specify whether the line is drawn in gradient mode or not")]
		[Category("General")]
		public bool Gradient
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

		[Description("Get/Set the gradient angle")]
		[DefaultValue("0")]
		[Category("General")]
		public int GradientAngle
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
		[Description("Get/Set line gradient color")]
		[DefaultValue("Color.White")]
		public Color GradientColor
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

		[Description("Get/Set the Left_Top Offset of drawing rectangle")]
		[DefaultValue("(0,0)")]
		[Category("Position")]
		public Point LeftTopOffset
		{
			get
			{
				return ab;
			}
			set
			{
				ab = value;
				if (ab.X < 0)
				{
					ab.X = 0;
				}
				if (ab.Y < 0)
				{
					ab.Y = 0;
				}
				b();
			}
		}

		[Category("General")]
		[DefaultValue("Color.Black")]
		[Description("Get/Set line color")]
		public Color LineColor
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

		[Category("Compound")]
		[Description("Get/Set the percentage of the first invisible part of line")]
		[DefaultValue("0.1f")]
		public float LineCompoundInVisibleRate1
		{
			get
			{
				return af;
			}
			set
			{
				if (value >= 0f && value <= 1f)
				{
					af = value;
					b();
				}
			}
		}

		[Category("Compound")]
		[Description("Get/Set the percentage of the second invisible part of line")]
		[DefaultValue("0.1f")]
		public float LineCompoundInVisibleRate2
		{
			get
			{
				return ah;
			}
			set
			{
				if (value >= 0f && value <= 1f)
				{
					ah = value;
					b();
				}
			}
		}

		[Description("Get/Set the percentage of the first visible part of line")]
		[DefaultValue("0.25f")]
		[Category("Compound")]
		public float LineCompoundVisibleRate1
		{
			get
			{
				return ae;
			}
			set
			{
				if (value >= 0f && value <= 1f)
				{
					ae = value;
					b();
				}
			}
		}

		[Category("Compound")]
		[DefaultValue("0.3f")]
		[Description("Get/Set the percentage of the second visible part of line")]
		public float LineCompoundVisibleRate2
		{
			get
			{
				return ag;
			}
			set
			{
				if (value >= 0f && value <= 1f)
				{
					ag = value;
					b();
				}
			}
		}

		[Description("Get/Set Line Type")]
		[DefaultValue("DAS_LineType.LT_ForwardDiagonal")]
		[Category("General")]
		public HMILineType LineTYpe
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
		[Description("Get/Set line width")]
		[DefaultValue("1")]
		public int LineWidth
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

		[Description("Get/Set the Right_Bottom Offset of drawing rectangle")]
		[DefaultValue("(0,0)")]
		[Category("Position")]
		public Point RightBottomOffset
		{
			get
			{
				return ac;
			}
			set
			{
				ac = value;
				if (ac.X < 0)
				{
					ac.X = 0;
				}
				if (ac.Y < 0)
				{
					ac.Y = 0;
				}
				b();
			}
		}

		[Description("Get/Set the cap type of the start point of the line")]
		[Category("Cap_Dash")]
		[DefaultValue("LineCap.Flat")]
		public LineCap StartCap
		{
			get
			{
				return j;
			}
			set
			{
				j = value;
				b();
			}
		}

		[Category("Position")]
		[Description("Get/Set the start point of the line")]
		[DefaultValue("(0,0)")]
		public Point StartPoint
		{
			get
			{
				return v;
			}
			set
			{
				v = value;
				b();
			}
		}

		[DefaultValue("false")]
		[Description("Get/Set whether the line is drawn in a compund pen")]
		[Category("Compound")]
		public bool SupportCompoundPen
		{
			get
			{
				return ad;
			}
			set
			{
				ad = value;
				b();
			}
		}

		[Description("Get/Set whether the background is transparent or not")]
		[Category("General")]
		[DefaultValue("True")]
		public bool TransparentBackground
		{
			get
			{
				return i;
			}
			set
			{
				i = value;
				if (i)
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

		public HMILine()
		{
			if (i)
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
				SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			}
			else
			{
				SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
				SetStyle(ControlStyles.Opaque, value: true);
			}
			a();
			BackColor = Color.FromArgb(64, 64, 64);
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode && TagCollectionClient.Tags != null && !string.IsNullOrEmpty(_TagName) && !string.IsNullOrWhiteSpace(_TagName) && TagCollectionClient.Tags.Count != 0)
			{
				base.DataBindings.Add(new Binding("Value", TagCollectionClient.Tags[_TagName], "Value", formattingEnabled: true));
			}
		}

		private void FireChanging()
		{
			if (AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode)
			{
				GetComponentChangeService()?.OnComponentChanging(this, null);
			}
		}

		private void FireChanged()
		{
			if (AdvancedScada.Controls.Licenses.LicenseManager.IsInDesignMode)
			{
				GetComponentChangeService()?.OnComponentChanged(this, null, null, null);
			}
		}

		private IComponentChangeService GetComponentChangeService()
		{
			return GetService(typeof(IComponentChangeService)) as IComponentChangeService;
		}

		private void a()
		{
			ai = new Container();
		}

		protected override void Dispose(bool A_0)
		{
			if (A_0 && ai != null)
			{
				ai.Dispose();
			}
			base.Dispose(A_0);
		}

		protected override void OnPaint(PaintEventArgs A_0)
		{
			try
			{
				base.OnPaint(A_0);
				Rectangle rect = new Rectangle(base.ClientRectangle.Left + (d - 1), base.ClientRectangle.Top + (d - 1), base.ClientRectangle.Width - 1 - 2 * (d - 1), base.ClientRectangle.Height - 1 - 2 * (d - 1));
				if (rect.Width > ab.X)
				{
					rect.X += ab.X;
					rect.Width -= ab.X;
				}
				if (rect.Height > ab.Y)
				{
					rect.Y += ab.Y;
					rect.Height -= ab.Y;
				}
				if (rect.Width > ac.X)
				{
					rect.Width -= ac.X;
				}
				if (rect.Height > ac.Y)
				{
					rect.Height -= ac.Y;
				}
				A_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				A_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				if (!i)
				{
					SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
					A_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
					Pen pen = new Pen(solidBrush);
					A_0.Graphics.DrawRectangle(pen, base.ClientRectangle);
					pen.Dispose();
					solidBrush.Dispose();
				}
				Pen pen2 = new Pen(e, d)
				{
					DashCap = m,
					StartCap = j
				};
				if (pen2.StartCap == LineCap.Custom)
				{
					GraphicsPath graphicsPath = new GraphicsPath();
					int num = 0;
					if (s && !r)
					{
						num = -1;
					}
					if (n != HMICustomizedCap.CC_Circle)
					{
						if (n == HMICustomizedCap.CC_Diamond)
						{
							if (!r)
							{
								graphicsPath.AddLine(0, 2 * o + num, o, o + num);
								graphicsPath.AddLine(o, o + num, 0, num);
								graphicsPath.AddLine(0, num, -o, o + num);
								graphicsPath.AddLine(-o, o + num, 0, 2 * o + num);
							}
							else
							{
								graphicsPath.AddLine(0, num, o, -o);
								graphicsPath.AddLine(o, -o, 0, -2 * o);
								graphicsPath.AddLine(0, -2 * o, -o, -o);
								graphicsPath.AddLine(-o, -o, 0, 0);
							}
						}
						else if (n != HMICustomizedCap.CC_HalfCircle)
						{
							if (n == HMICustomizedCap.CC_HalfCircle2)
							{
								if (r)
								{
									graphicsPath.AddArc(-o, -o, 2 * o, 2 * o, 180f, 180f);
								}
								else
								{
									graphicsPath.AddArc(-o, num, 2 * o, 2 * o, 180f, 180f);
								}
								graphicsPath.CloseFigure();
							}
							else if (n == HMICustomizedCap.CC_Rectangle)
							{
								Rectangle rect2 = new Rectangle(-o, -2 * o, 2 * o, 2 * o);
								if (!r)
								{
									rect2.Y = num;
								}
								graphicsPath.AddRectangle(rect2);
							}
							else if (n == HMICustomizedCap.CC_Triangle)
							{
								if (!r)
								{
									graphicsPath.AddLine(-o, num, o, num);
									graphicsPath.AddLine(o, num, 0, o + num);
									graphicsPath.AddLine(0, o + num, -o, num);
								}
								else
								{
									graphicsPath.AddLine(0, 0, -o, -o);
									graphicsPath.AddLine(-o, -o, o, -o);
									graphicsPath.AddLine(o, -o, 0, 0);
								}
							}
							else if (r)
							{
								graphicsPath.AddLine(o, -o, 0, 0);
								graphicsPath.AddLine(0, 0, -o, -o);
							}
							else
							{
								graphicsPath.AddLine(o, o + num, 0, num);
								graphicsPath.AddLine(0, num, -o, o + num);
							}
						}
						else
						{
							if (!r)
							{
								graphicsPath.AddArc(-o, -o + num, 2 * o, 2 * o, 0f, 180f);
							}
							else
							{
								graphicsPath.AddArc(-o, -2 * o, 2 * o, 2 * o, 0f, 180f);
							}
							graphicsPath.CloseFigure();
						}
					}
					else if (r)
					{
						graphicsPath.AddEllipse(-o, -2 * o, 2 * o, 2 * o);
					}
					else
					{
						graphicsPath.AddEllipse(-o, num, 2 * o, 2 * o);
					}
					if (!s)
					{
						CustomLineCap customLineCap2 = pen2.CustomStartCap = new CustomLineCap(null, graphicsPath);
						customLineCap2.Dispose();
					}
					else
					{
						graphicsPath.CloseFigure();
						CustomLineCap customLineCap4 = pen2.CustomStartCap = new CustomLineCap(graphicsPath, null);
						customLineCap4.Dispose();
					}
					graphicsPath.Dispose();
				}
				pen2.EndCap = k;
				if (pen2.EndCap == LineCap.Custom)
				{
					GraphicsPath graphicsPath2 = new GraphicsPath();
					int num2 = 0;
					if (u && !t)
					{
						num2 = -1;
					}
					if (p == HMICustomizedCap.CC_Circle)
					{
						if (t)
						{
							graphicsPath2.AddEllipse(-q, -2 * q, 2 * q, 2 * q);
						}
						else
						{
							graphicsPath2.AddEllipse(-q, num2, 2 * q, 2 * q);
						}
					}
					else if (p == HMICustomizedCap.CC_Diamond)
					{
						if (t)
						{
							graphicsPath2.AddLine(0, 0, q, -q);
							graphicsPath2.AddLine(q, -q, 0, -2 * q);
							graphicsPath2.AddLine(0, -2 * q, -q, -q);
							graphicsPath2.AddLine(-q, -q, 0, 0);
						}
						else
						{
							graphicsPath2.AddLine(0, 2 * q + num2, q, q + num2);
							graphicsPath2.AddLine(q, q + num2, 0, num2);
							graphicsPath2.AddLine(0, num2, -q, q + num2);
							graphicsPath2.AddLine(-q, q + num2, 0, 2 * q + num2);
						}
					}
					else if (p == HMICustomizedCap.CC_HalfCircle)
					{
						if (t)
						{
							graphicsPath2.AddArc(-q, -2 * q, 2 * q, 2 * q, 0f, 180f);
						}
						else
						{
							graphicsPath2.AddArc(-q, -q + num2, 2 * q, 2 * q, 0f, 180f);
						}
						graphicsPath2.CloseFigure();
					}
					else if (p != HMICustomizedCap.CC_HalfCircle2)
					{
						if (p == HMICustomizedCap.CC_Rectangle)
						{
							Rectangle rect3 = new Rectangle(-q, -2 * q, 2 * q, 2 * q);
							if (!t)
							{
								rect3.Y = num2;
							}
							graphicsPath2.AddRectangle(rect3);
						}
						else if (p == HMICustomizedCap.CC_Triangle)
						{
							if (!t)
							{
								graphicsPath2.AddLine(-q, num2, q, num2);
								graphicsPath2.AddLine(q, num2, 0, q + num2);
								graphicsPath2.AddLine(0, q + num2, -q, num2);
							}
							else
							{
								graphicsPath2.AddLine(0, 0, -q, -q);
								graphicsPath2.AddLine(-q, -q, q, -q);
								graphicsPath2.AddLine(q, -q, 0, 0);
							}
						}
						else if (!t)
						{
							graphicsPath2.AddLine(q, q + num2, 0, num2);
							graphicsPath2.AddLine(0, num2, -q, q + num2);
						}
						else
						{
							graphicsPath2.AddLine(q, -q, 0, 0);
							graphicsPath2.AddLine(0, 0, -q, -q);
						}
					}
					else
					{
						if (t)
						{
							graphicsPath2.AddArc(-q, -q, 2 * q, 2 * q, 180f, 180f);
						}
						else
						{
							graphicsPath2.AddArc(-q, num2, 2 * q, 2 * q, 180f, 180f);
						}
						graphicsPath2.CloseFigure();
					}
					if (u)
					{
						graphicsPath2.CloseFigure();
						CustomLineCap customLineCap6 = pen2.CustomEndCap = new CustomLineCap(graphicsPath2, null);
						customLineCap6.Dispose();
					}
					else
					{
						CustomLineCap customLineCap8 = pen2.CustomEndCap = new CustomLineCap(null, graphicsPath2);
						customLineCap8.Dispose();
					}
					graphicsPath2.Dispose();
				}
				pen2.DashStyle = l;
				if (ad)
				{
					float[] array = new float[6];
					float num3 = 0f;
					array[0] = 0f;
					array[1] = num3 + ae;
					num3 += ae;
					if (num3 <= 1f)
					{
						if (num3 + af <= 1f)
						{
							array[2] = num3 + af;
							num3 += af;
						}
						else
						{
							array[2] = 1f;
							num3 = 1f;
						}
					}
					if (num3 <= 1f)
					{
						if (num3 + ag <= 1f)
						{
							array[3] = num3 + ag;
							num3 += ag;
						}
						else
						{
							array[3] = 1f;
							num3 = 1f;
						}
					}
					if (num3 <= 1f)
					{
						if (num3 + ah <= 1f)
						{
							array[4] = num3 + ah;
							num3 += ah;
						}
						else
						{
							array[4] = 1f;
							num3 = 1f;
						}
					}
					if (num3 <= 1f)
					{
						array[5] = 1f;
						num3 = 1f;
					}
					pen2.CompoundArray = array;
				}
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, e, g, h);
				if (f)
				{
					pen2.Brush = linearGradientBrush;
				}
				if (c == HMILineType.LT_ForwardDiagonal)
				{
					A_0.Graphics.DrawLine(pen2, rect.Left, rect.Top, rect.Right, rect.Bottom);
				}
				else if (c != HMILineType.LT_BackwardDiagonal)
				{
					if (c == HMILineType.LT_Horizontal)
					{
						A_0.Graphics.DrawLine(pen2, rect.Left, (rect.Top + rect.Bottom) / 2, rect.Right, (rect.Top + rect.Bottom) / 2);
					}
					else if (c == HMILineType.LT_Vertical)
					{
						A_0.Graphics.DrawLine(pen2, (rect.Left + rect.Right) / 2, rect.Top, (rect.Left + rect.Right) / 2, rect.Bottom);
					}
					else if (c == HMILineType.LT_CustomizedLine)
					{
						A_0.Graphics.DrawLine(pen2, v, w);
					}
					else if (c != HMILineType.LT_LeftArc)
					{
						if (c != HMILineType.LT_RightArc)
						{
							if (c != HMILineType.LT_TopArc)
							{
								if (c != HMILineType.LT_BottomArc)
								{
									if (c != HMILineType.LT_LeftTopArc)
									{
										if (c == HMILineType.LT_RightTopArc)
										{
											A_0.Graphics.DrawArc(pen2, rect.Left - rect.Width, rect.Top, 2 * rect.Width, 2 * rect.Height, 270, 90);
										}
										else if (c != HMILineType.LT_LeftBottomArc)
										{
											if (c == HMILineType.LT_RightBottomArc)
											{
												A_0.Graphics.DrawArc(pen2, rect.Left - rect.Width, rect.Top - rect.Height, 2 * rect.Width, 2 * rect.Height, 0, 90);
											}
											else if (c == HMILineType.LT_CustomizedArc)
											{
												A_0.Graphics.DrawArc(pen2, rect, x, y - x);
											}
											else if (c == HMILineType.LT_FourPointCurve)
											{
												A_0.Graphics.DrawBezier(pen2, v, z, aa, w);
											}
										}
										else
										{
											A_0.Graphics.DrawArc(pen2, rect.Left, rect.Top - rect.Height, 2 * rect.Width, 2 * rect.Height, 90, 90);
										}
									}
									else
									{
										A_0.Graphics.DrawArc(pen2, rect.Left, rect.Top, 2 * rect.Width, 2 * rect.Height, 180, 90);
									}
								}
								else
								{
									A_0.Graphics.DrawArc(pen2, rect.Left, rect.Top - rect.Height, rect.Width, 2 * rect.Height, 0, 180);
								}
							}
							else
							{
								A_0.Graphics.DrawArc(pen2, rect.Left, rect.Top, rect.Width, 2 * rect.Height, 180, 180);
							}
						}
						else
						{
							A_0.Graphics.DrawArc(pen2, rect.Left - rect.Width, rect.Top, 2 * rect.Width, rect.Height, 270, 180);
						}
					}
					else
					{
						A_0.Graphics.DrawArc(pen2, rect.Left, rect.Top, 2 * rect.Width, rect.Height, 90, 180);
					}
				}
				else
				{
					A_0.Graphics.DrawLine(pen2, rect.Right, rect.Top, rect.Left, rect.Bottom);
				}
				linearGradientBrush.Dispose();
				pen2.Dispose();
				if (flagB)
				{
					SolidBrush solidBrush2 = new SolidBrush(Color.Red);
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					A_0.Graphics.DrawString("Designed By Hao Thien Co.,Ltd: 0909.886.483", Font, solidBrush2, base.ClientRectangle, format);
					solidBrush2.Dispose();
				}
			}
			catch (ApplicationException ex)
			{
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
			if (i)
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
			if (!i)
			{
				base.OnPaintBackground(A_0);
			}
		}
	}
}
