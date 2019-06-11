
using AdvancedScada.IBaseService;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.HMIs.Drawing
{
    [ToolboxBitmap(typeof(HMIShape), "HMIShape.ico")]
	[ToolboxItem(true)]
	[Designer(typeof(HMIShapeDesigner))]
	public class HMIShape : Control
	{
		internal class HMIShapeDesigner : ControlDesigner
		{
			private DesignerActionListCollection actionLists;

			public override DesignerActionListCollection ActionLists
			{
				get
				{
					if (actionLists == null)
					{
						actionLists = new DesignerActionListCollection();
						actionLists.Add(new HMIShapeListItem(this));
					}
					return actionLists;
				}
			}
		}

		internal class HMIShapeListItem : DesignerActionList
		{
			private HMIShape _HMIShape;

			public Color BackColor
			{
				get
				{
					return _HMIShape.BackColor;
				}
				set
				{
					_HMIShape.BackColor = value;
				}
			}

			public Color OnColor
			{
				get
				{
					return _HMIShape.OnColor;
				}
				set
				{
					_HMIShape.OnColor = value;
				}
			}

			public Color OffColor
			{
				get
				{
					return _HMIShape.OffColor;
				}
				set
				{
					_HMIShape.OffColor = value;
				}
			}

			public string TagName
			{
				get
				{
					return _HMIShape.TagName;
				}
				set
				{
					_HMIShape.TagName = value;
					_HMIShape.Invalidate();
				}
			}

			public HMIShapeListItem(HMIShapeDesigner owner)
				: base(owner.Component)
			{
				_HMIShape = (HMIShape)owner.Component;
			}

			public override DesignerActionItemCollection GetSortedActionItems()
			{
				return new DesignerActionItemCollection
				{
					new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"),
					new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"),
					new DesignerActionPropertyItem("BackColor", "BackColor"),
					new DesignerActionPropertyItem("OnColor", "OnColor"),
					new DesignerActionPropertyItem("OffColor", "OffColor"),
					new DesignerActionPropertyItem("TagName", "TagName")
				};
			}

			private void ShowTagListForm()
			{
                MonitorForm tagCollectionForm = new MonitorForm();
				tagCollectionForm.OnTagSelected_Clicked = (EventTagSelected)Delegate.Combine(tagCollectionForm.OnTagSelected_Clicked, (EventTagSelected)delegate(string tagName)
				{
					SetProperty(_HMIShape, "TagName", tagName);
				});
				tagCollectionForm.StartPosition = FormStartPosition.CenterScreen;
				tagCollectionForm.ShowDialog();
			}

			public void SetProperty(Control control, string propertyName, object value)
			{
				TypeDescriptor.GetProperties(control)[propertyName].SetValue(control, value);
			}
		}

		private Timer timerLicence = new Timer();

		private int aa = 1;

		private Color ab = Color.Black;

		private bool ac;

		private Color ad = Color.White;

		private int ae;

		private DashStyle af;

		private float ag;

		private float ah = 0.5f;

		private bool ai;

		private int aj = 90;

		private HMIBkGradientStyle ak;

		private Color al = Color.White;

		private float am = 1f;

		private bool an;

		private int ao = 8;

		private Color ap = Color.DimGray;

		private float aq = 0.5f;

		private IContainer ar;

		private bool flagB;

		private HMIShapeType c = HMIShapeType.ST_Rectangle;

		private int d = 4;

		private Point e = new Point(0, 0);

		private Point f = new Point(0, 0);

		private Point g = new Point(0, 0);

		private Point h = new Point(0, 0);

		private Point i = new Point(0, 0);

		private Point j = new Point(0, 0);

		private Point k = new Point(0, 0);

		private Point l = new Point(0, 0);

		private Point m = new Point(0, 0);

		private Point n = new Point(0, 0);

		private int o = 20;

		private int p = 12;

		private int q = 10;

		private int r;

		private int s = 180;

		private int t = 20;

		private int u;

		private Point v = new Point(0, 0);

		private Point w = new Point(0, 0);

		private bool x;

		private Point y = new Point(0, 0);

		private bool z = true;

		private string _TagName;

		private bool _Value;

		private Color _OnColor = Color.Lime;

		private Color _OffColor = Color.Gainsboro;

		[Category("Link TagName")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
				catch (Exception)
				{
					throw new InvalidOperationException($"TagName is invalid: {_TagName}");
				}
				finally
				{
					FireChanged();
				}
			}
		}

		[Category("HMI Professional")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[DefaultValue(false)]
		public bool Value
		{
			get
			{
				return _Value;
			}
			set
			{
				FireChanged();
				try
				{
					_Value = value;
					if (_Value)
					{
						BackColor = OnColor;
					}
					else
					{
						BackColor = OffColor;
					}
				}
				finally
				{
					FireChanged();
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[Category("HMI Professional")]
		public Color OnColor
		{
			get
			{
				return _OnColor;
			}
			set
			{
				FireChanged();
				try
				{
					_OnColor = value;
				}
				finally
				{
					FireChanged();
				}
			}
		}

		[Category("HMI Professional")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public Color OffColor
		{
			get
			{
				return _OffColor;
			}
			set
			{
				FireChanged();
				try
				{
					_OffColor = value;
				}
				finally
				{
					FireChanged();
				}
			}
		}

		[Description("Get/Set the end angle of the arc")]
		[Category("General")]
		[DefaultValue("180")]
		public int ArcEndAngle
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

		[DefaultValue("0")]
		[Category("General")]
		[Description("Get/Set the start angle of the arc")]
		public int ArcStartAngle
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

		[DefaultValue("12")]
		[Category("General")]
		[Description("Get/Set the arrow bar width for some arrow shape types")]
		public int ArrowBarWidth
		{
			get
			{
				return p;
			}
			set
			{
				if (value >= 0)
				{
					p = value;
					b();
				}
			}
		}

		[Description("Get/Set whether or not background is rendered in gradient mode")]
		[Category("Filling")]
		[DefaultValue("False")]
		public bool BkGradient
		{
			get
			{
				return ai;
			}
			set
			{
				ai = value;
				b();
			}
		}

		[Description("Get/Set background gradient angle")]
		[DefaultValue("90")]
		[Category("Filling")]
		public int BkGradientAngle
		{
			get
			{
				return aj;
			}
			set
			{
				aj = value;
				b();
			}
		}

		[Description("Get/Set background gradient color")]
		[Category("Filling")]
		[DefaultValue("Color.White")]
		public Color BkGradientColor
		{
			get
			{
				return al;
			}
			set
			{
				al = value;
				b();
			}
		}

		[DefaultValue("0.5")]
		[Description("Get/Set background gradient rate of the control")]
		[Category("Filling")]
		public float BkGradientRate
		{
			get
			{
				return ah;
			}
			set
			{
				if (value <= 1f || (double)value >= 0.0)
				{
					ah = value;
					b();
				}
			}
		}

		[Description("Get/Set background gradient Type")]
		[DefaultValue("BKGS_Linear")]
		[Category("Filling")]
		public HMIBkGradientStyle BkGradientType
		{
			get
			{
				return ak;
			}
			set
			{
				ak = value;
				b();
			}
		}

		[Category("Filling")]
		[Description("Get/Set the shine position of the background gradient rendering")]
		[DefaultValue("1.0")]
		public float BkShinePosition
		{
			get
			{
				return am;
			}
			set
			{
				if (value <= 1f || (double)value >= 0.0)
				{
					am = value;
					b();
				}
			}
		}

		[DefaultValue("0.0")]
		[Category("Filling")]
		[Description("Get/Set background transparency rate of the control")]
		public float BkTransparency
		{
			get
			{
				return ag;
			}
			set
			{
				if (value <= 1f || (double)value >= 0.0)
				{
					ag = value;
					b();
				}
			}
		}

		[DefaultValue("Color.Black")]
		[Description("Get/Set the border line color")]
		[Category("Outline")]
		public Color BorderColor
		{
			get
			{
				return ab;
			}
			set
			{
				ab = value;
				b();
			}
		}

		[Category("Outline")]
		[DefaultValue("DashStyle.Solid")]
		[Description("Get/Set the dash style of the border line")]
		public DashStyle BorderDash
		{
			get
			{
				return af;
			}
			set
			{
				af = value;
				b();
			}
		}

		[Description("Specify whether the border line is drawn in gradient mode or not")]
		[Category("Outline")]
		[DefaultValue("false")]
		public bool BorderGradient
		{
			get
			{
				return ac;
			}
			set
			{
				ac = value;
				b();
			}
		}

		[DefaultValue("0")]
		[Category("Outline")]
		[Description("Get/Set the border gradient angle")]
		public int BorderGradientAngle
		{
			get
			{
				return ae;
			}
			set
			{
				ae = value;
				b();
			}
		}

		[DefaultValue("Color.White")]
		[Description("Get/Set the border line gradient color")]
		[Category("Outline")]
		public Color BorderGradientColor
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

		[Description("Get/Set border line width")]
		[DefaultValue("1")]
		[Category("Outline")]
		public int BorderWidth
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

		[DefaultValue("false")]
		[Description("Get/Set whether the shadow is rendered or not")]
		[Category("Shadow")]
		public bool ControlShadow
		{
			get
			{
				return an;
			}
			set
			{
				an = value;
				Invalidate();
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (z)
				{
					createParams.ExStyle |= 32;
				}
				return createParams;
			}
		}

		[Description("Get/Set the Left_Top Offset of drawing rectangle")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point LeftTopOffset
		{
			get
			{
				return v;
			}
			set
			{
				v = value;
				if (v.X < 0)
				{
					v.X = 0;
				}
				if (v.Y < 0)
				{
					v.Y = 0;
				}
				b();
			}
		}

		[Description("Get/Set the first vertex point of the polygon shape")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point PolygonPoint1
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

		[Description("Get/Set the tenth vertex point of the polygon shape")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point PolygonPoint10
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

		[Description("Get/Set the second vertex point of the polygon shape")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point PolygonPoint2
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

		[Category("General")]
		[Description("Get/Set the third vertex point of the polygon shape")]
		[DefaultValue("(0,0)")]
		public Point PolygonPoint3
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

		[DefaultValue("(0,0)")]
		[Category("General")]
		[Description("Get/Set the forth vertex point of the polygon shape")]
		public Point PolygonPoint4
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
		[DefaultValue("(0,0)")]
		[Description("Get/Set the fifth vertex point of the polygon shape")]
		public Point PolygonPoint5
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

		[Category("General")]
		[DefaultValue("(0,0)")]
		[Description("Get/Set the sixth vertex point of the polygon shape")]
		public Point PolygonPoint6
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

		[DefaultValue("(0,0)")]
		[Description("Get/Set the seventh vertex point of the polygon shape")]
		[Category("General")]
		public Point PolygonPoint7
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

		[Description("Get/Set the eighth vertex point of the polygon shape")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point PolygonPoint8
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

		[DefaultValue("(0,0)")]
		[Category("General")]
		[Description("Get/Set the ninth vertex point of the polygon shape")]
		public Point PolygonPoint9
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

		[Category("General")]
		[Description("Get/Set the vertex number of the polygon ")]
		[DefaultValue("4")]
		public int PolygonVertexNumber
		{
			get
			{
				return d;
			}
			set
			{
				if (value >= 3 && value <= 10)
				{
					d = value;
					b();
				}
			}
		}

		[Description("Get/Set the Right_Bottom Offset of drawing rectangle")]
		[DefaultValue("(0,0)")]
		[Category("General")]
		public Point RightBottomOffset
		{
			get
			{
				return w;
			}
			set
			{
				w = value;
				if (w.X < 0)
				{
					w.X = 0;
				}
				if (w.Y < 0)
				{
					w.Y = 0;
				}
				b();
			}
		}

		[Category("General")]
		[Description("Get/Set the width of the ring shape")]
		[DefaultValue("20")]
		public int RingWidth
		{
			get
			{
				return t;
			}
			set
			{
				if (value >= 2)
				{
					t = value;
					b();
				}
			}
		}

		[DefaultValue("10")]
		[Category("General")]
		[Description("Get/Set Round Radius of Round Rectangle")]
		public int RoundRadius
		{
			get
			{
				return q;
			}
			set
			{
				if (value >= 0)
				{
					q = value;
				}
			}
		}

		[Category("Shadow")]
		[DefaultValue("Color.DimGray")]
		[Description("Get/Set the shadow color")]
		public Color ShadowColor
		{
			get
			{
				return ap;
			}
			set
			{
				ap = value;
			}
		}

		[Description("Get/Set the shadow depth")]
		[Category("Shadow")]
		[DefaultValue("8")]
		public int ShadowDepth
		{
			get
			{
				return ao;
			}
			set
			{
				if (value > 0)
				{
					ao = value;
				}
			}
		}

		[Description("Get/Set the shadow rate")]
		[DefaultValue("0.5")]
		[Category("Shadow")]
		public float ShadowRate
		{
			get
			{
				return aq;
			}
			set
			{
				if ((double)value >= 0.05 && (double)value <= 0.95)
				{
					aq = value;
				}
			}
		}

		[Description("Get/Set the header height for some specific shape types")]
		[Category("General")]
		[DefaultValue("20")]
		public int ShapeHeader
		{
			get
			{
				return o;
			}
			set
			{
				if (value >= 0)
				{
					o = value;
					b();
				}
			}
		}

		[DefaultValue("0")]
		[Description("Get/Set the rotation angle of the shape")]
		[Category("General")]
		public int ShapeRotationAngle
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

		[DefaultValue("DAS_ShapeType.ST_Rectangle")]
		[Description("Get/Set Shape Type")]
		[Category("General")]
		public HMIShapeType ShapeTYpe
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

		[Description("Get/Set the offset of the text display")]
		[Category("General")]
		[DefaultValue("(0,0)")]
		public Point TextOffset
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

		[DefaultValue("False")]
		[Category("General")]
		[Description("Get/Set the visibility of Text")]
		public bool TextVisible
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

		[DefaultValue("True")]
		[Description("Get/Set whether the background is transparent or not")]
		[Category("General")]
		public bool TransparentBackground
		{
			get
			{
				return z;
			}
			set
			{
				z = value;
				if (!z)
				{
					SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
					SetStyle(ControlStyles.Opaque, value: true);
				}
				else
				{
					SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, value: true);
					SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
				}
				b();
			}
		}

		public HMIShape()
		{
			BackColor = Color.YellowGreen;
			if (z)
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
			ar = new Container();
		}

		protected override void Dispose(bool A_0)
		{
			if (A_0 && ar != null)
			{
				ar.Dispose();
			}
			base.Dispose(A_0);
		}

		protected override void OnPaint(PaintEventArgs A_0)
		{
			try
			{
				base.OnPaint(A_0);
				Rectangle rectangle = new Rectangle(base.ClientRectangle.Left + (aa - 1), base.ClientRectangle.Top + (aa - 1), base.ClientRectangle.Width - 1 - 2 * (aa - 1), base.ClientRectangle.Height - 1 - 2 * (aa - 1));
				if (rectangle.Width > v.X)
				{
					rectangle.X += v.X;
					rectangle.Width -= v.X;
				}
				if (rectangle.Height > v.Y)
				{
					rectangle.Y += v.Y;
					rectangle.Height -= v.Y;
				}
				if (rectangle.Width > w.X)
				{
					rectangle.Width -= w.X;
				}
				if (rectangle.Height > w.Y)
				{
					rectangle.Height -= w.Y;
				}
				if (an && ao > 0 && ao < rectangle.Width / 3 && ao < rectangle.Height / 3)
				{
					rectangle.Width -= ao;
					rectangle.Height -= ao;
				}
				if (c == HMIShapeType.ST_Text && Text != "")
				{
					A_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				}
				else
				{
					A_0.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				}
				A_0.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
				if (!z)
				{
					SolidBrush solidBrush = new SolidBrush(base.Parent.BackColor);
					A_0.Graphics.FillRectangle(solidBrush, base.ClientRectangle);
					Pen pen = new Pen(solidBrush);
					A_0.Graphics.DrawRectangle(pen, base.ClientRectangle);
					pen.Dispose();
					solidBrush.Dispose();
				}
				int left = rectangle.Left;
				int top = rectangle.Top;
				if (u != 0)
				{
					A_0.Graphics.TranslateTransform((rectangle.Left + rectangle.Right) / 2, (rectangle.Top + rectangle.Bottom) / 2);
					A_0.Graphics.RotateTransform(u);
					rectangle.X = -rectangle.Width / 2;
					rectangle.Y = -rectangle.Height / 2;
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				a(graphicsPath, rectangle, c);
				if (an && ao > 0 && ao < rectangle.Width / 3 && ao < rectangle.Height / 3)
				{
					rectangle.X += ao;
					rectangle.Y += ao;
					GraphicsPath graphicsPath2 = new GraphicsPath();
					a(graphicsPath2, rectangle, c);
					rectangle.X -= ao;
					rectangle.Y -= ao;
					Region region = new Region(graphicsPath2);
					Region region2 = new Region(graphicsPath2);
					region2.Intersect(graphicsPath);
					region.Xor(region2);
					A_0.Graphics.SetClip(region, CombineMode.Replace);
					new INBase().a(A_0.Graphics, rectangle, graphicsPath, ap, ao, aq);
					A_0.Graphics.ResetClip();
					region2.Dispose();
					region.Dispose();
					graphicsPath2.Dispose();
					A_0.Graphics.ResetTransform();
					rectangle.X = left;
					rectangle.Y = top;
					if (u != 0)
					{
						A_0.Graphics.TranslateTransform((rectangle.Left + rectangle.Right) / 2, (rectangle.Top + rectangle.Bottom) / 2);
						A_0.Graphics.RotateTransform(u);
						rectangle.X = -rectangle.Width / 2;
						rectangle.Y = -rectangle.Height / 2;
					}
				}
				A_0.Graphics.SetClip(graphicsPath);
				Pen pen2 = new Pen(ab, aa)
				{
					DashStyle = af
				};
				Rectangle rect = new Rectangle(-base.ClientRectangle.Width / 2, -base.ClientRectangle.Height / 2, base.ClientRectangle.Width, base.ClientRectangle.Height);
				if (u == 0)
				{
					rect.X = base.ClientRectangle.X;
					rect.Y = base.ClientRectangle.Y;
				}
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, ab, ad, ae);
				if (ac)
				{
					pen2.Brush = linearGradientBrush;
				}
				if (BackgroundImage != null)
				{
					if (BackgroundImageLayout == ImageLayout.Center)
					{
						PointF pointF = default(PointF);
						pointF.X = (float)rectangle.Left + (float)(rectangle.Width - BackgroundImage.Width) / 2f;
						pointF.Y = (float)rectangle.Top + (float)(rectangle.Height - BackgroundImage.Height) / 2f;
						PointF point = pointF;
						A_0.Graphics.DrawImage(BackgroundImage, point);
					}
					else if (BackgroundImageLayout == ImageLayout.None)
					{
						PointF pointF = default(PointF);
						pointF.X = rectangle.Left;
						pointF.Y = rectangle.Top;
						PointF point2 = pointF;
						A_0.Graphics.DrawImage(BackgroundImage, point2);
					}
					else if (BackgroundImageLayout == ImageLayout.Stretch)
					{
						A_0.Graphics.DrawImage(BackgroundImage, rectangle);
					}
					else if (BackgroundImageLayout != ImageLayout.Zoom)
					{
						if (BackgroundImageLayout == ImageLayout.Tile)
						{
							TextureBrush textureBrush = new TextureBrush(BackgroundImage);
							A_0.Graphics.FillRectangle(textureBrush, rectangle);
							textureBrush.Dispose();
						}
					}
					else
					{
						float num = rectangle.Width;
						float num2 = (float)BackgroundImage.Height / (float)BackgroundImage.Width * num;
						if (num2 > (float)rectangle.Height)
						{
							num2 = rectangle.Height;
							num = (float)BackgroundImage.Width / (float)BackgroundImage.Height * num2;
						}
						RectangleF rect2 = new RectangleF((float)rectangle.Left + ((float)rectangle.Width - num) / 2f, (float)rectangle.Top + ((float)rectangle.Height - num2) / 2f, num, num2);
						A_0.Graphics.DrawImage(BackgroundImage, rect2);
					}
				}
				int alpha = 255;
				if ((double)ag > 0.0)
				{
					alpha = 255 - (int)(255f * ag);
				}
				Color color = Color.FromArgb(alpha, BackColor);
				Color a_ = Color.FromArgb(alpha, al);
				if (!ai)
				{
					SolidBrush solidBrush2 = new SolidBrush(color);
					A_0.Graphics.FillPath(solidBrush2, graphicsPath);
					solidBrush2.Dispose();
				}
				else
				{
					new INBase().a(A_0.Graphics, rectangle, c, graphicsPath, color, a_, ak, aj, ah, q, 0, am);
				}
				A_0.Graphics.ResetClip();
				A_0.Graphics.DrawPath(pen2, graphicsPath);
				linearGradientBrush.Dispose();
				pen2.Dispose();
				if (u != 0)
				{
					A_0.Graphics.ResetTransform();
					rectangle.X = left;
					rectangle.Y = top;
				}
				if (x && Text != "")
				{
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					rectangle.X += y.X;
					rectangle.Y += y.Y;
					SolidBrush solidBrush3 = new SolidBrush(ForeColor);
					A_0.Graphics.DrawString(Text, Font, solidBrush3, rectangle, format);
					solidBrush3.Dispose();
				}
				graphicsPath.Dispose();
				if (flagB)
				{
					SolidBrush solidBrush4 = new SolidBrush(Color.Red);
					StringFormat format2 = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					A_0.Graphics.DrawString("Designed By Hao Thien Co.,Ltd: 0909.886.483", Font, solidBrush4, base.ClientRectangle, format2);
					solidBrush4.Dispose();
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

		private void a(GraphicsPath A_0, Rectangle A_1, HMIShapeType A_2)
		{
			int num = p;
			int num2 = o;
			switch (A_2)
			{
			case HMIShapeType.ST_Text:
				if (Text != "")
				{
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					};
					A_0.AddString(Text, Font.FontFamily, (int)Font.Style, Font.SizeInPoints, A_1, format);
				}
				break;
			case HMIShapeType.ST_RoundRectangle:
				new INBase().a(A_0, A_1, q);
				break;
			case HMIShapeType.ST_TopTriangle:
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_BottomTriangle:
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				break;
			case HMIShapeType.ST_LeftTopTriangle:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				break;
			case HMIShapeType.ST_LeftBottomTriangle:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Top);
				break;
			case HMIShapeType.ST_RightTopTriangle:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Top);
				break;
			case HMIShapeType.ST_RightBottomTriangle:
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Top);
				break;
			case HMIShapeType.ST_LeftArrow:
				if (num > A_1.Height)
				{
					num = A_1.Height / 2;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left + num2, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (A_1.Height - num) / 2, A_1.Right, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Right, A_1.Top + (A_1.Height - num) / 2, A_1.Right, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Right, A_1.Top + (A_1.Height + num) / 2, A_1.Left + num2, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (A_1.Height + num) / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_RightArrow:
				if (num > A_1.Height)
				{
					num = A_1.Height / 2;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right - num2, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (A_1.Height - num) / 2, A_1.Left, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Left, A_1.Top + (A_1.Height - num) / 2, A_1.Left, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Left, A_1.Top + (A_1.Height + num) / 2, A_1.Right - num2, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (A_1.Height + num) / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_BottomArrow:
				if (num > A_1.Width)
				{
					num = A_1.Width / 2;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left + (A_1.Width - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Bottom - num2, A_1.Left + (A_1.Width - num) / 2, A_1.Top);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Top, A_1.Left + (A_1.Width + num) / 2, A_1.Top);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Top, A_1.Left + (A_1.Width + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Bottom - num2, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				break;
			case HMIShapeType.ST_TopLeftArrow:
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Bottom, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left + (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Bottom - num2, A_1.Left + (num2 - num) / 2, A_1.Top);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Top + num);
				A_0.AddLine(A_1.Right, A_1.Top + num, A_1.Left + (num2 + num) / 2, A_1.Top + num);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Top + num, A_1.Left + (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Bottom - num2, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left + num2 / 2, A_1.Bottom);
				break;
			case HMIShapeType.ST_BottomLeftArrow:
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left + (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Top + num2, A_1.Left + (num2 - num) / 2, A_1.Bottom);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right, A_1.Bottom - num);
				A_0.AddLine(A_1.Right, A_1.Bottom - num, A_1.Left + (num2 + num) / 2, A_1.Bottom - num);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Bottom - num, A_1.Left + (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Top + num2, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left + num2 / 2, A_1.Top);
				break;
			case HMIShapeType.ST_RightBottomArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Bottom - num2 / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Left + num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 - num) / 2, A_1.Right, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Right, A_1.Bottom - (num2 - num) / 2, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right - num, A_1.Top);
				A_0.AddLine(A_1.Right - num, A_1.Top, A_1.Right - num, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2 / 2);
				break;
			case HMIShapeType.ST_BottomRightArrow:
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Top, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, A_1.Right - (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Top + num2, A_1.Right - (num2 - num) / 2, A_1.Bottom);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Bottom - num);
				A_0.AddLine(A_1.Left, A_1.Bottom - num, A_1.Right - (num2 + num) / 2, A_1.Bottom - num);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Bottom - num, A_1.Right - (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Top + num2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right - num2 / 2, A_1.Top);
				break;
			case HMIShapeType.ST_LeftBottomTwoArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Top + num2 / 2, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left + num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 - num) / 2, A_1.Right - (num2 - num) / 2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Top + (num2 - num) / 2, A_1.Right - (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Bottom - num2, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Right - num2 / 2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Bottom, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right - (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Bottom - num2, A_1.Right - (num2 + num) / 2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left, A_1.Top + num2 / 2);
				break;
			case HMIShapeType.ST_RightTopTwoArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right, A_1.Bottom - num2 / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right - num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 - num) / 2, A_1.Left + (num2 - num) / 2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Bottom - (num2 - num) / 2, A_1.Left + (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Top + num2, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left + num2 / 2, A_1.Top);
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Top, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left + (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Top + num2, A_1.Left + (num2 + num) / 2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Bottom - (num2 + num) / 2, A_1.Right - num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 + num) / 2, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right, A_1.Bottom - num2 / 2);
				break;
			case HMIShapeType.ST_LeftRightBottomThreeArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Top + num2 / 2, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left + num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 - num) / 2, A_1.Right - num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top - (num2 - num) / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right, A_1.Top + num2 / 2);
				A_0.AddLine(A_1.Right, A_1.Top + num2 / 2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right - num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (num2 + num) / 2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + (num2 + num) / 2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, (A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left, A_1.Top + num2 / 2);
				break;
			case HMIShapeType.ST_LeftTopBottomThreeArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Top, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, A_1.Right - (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Top + num2, A_1.Right - (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Bottom - num2, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Right - num2 / 2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Bottom, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right - (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Bottom - num2, A_1.Right - (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Right - (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Right - (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Top + num2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right - num2 / 2, A_1.Top);
				break;
			case HMIShapeType.ST_TopHalfEllipse:
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top, A_1.Width, 2 * A_1.Height, 180f, 180f);
				break;
			case HMIShapeType.ST_BottomHalfEllipse:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddArc(A_1.Left, A_1.Top - A_1.Height, A_1.Width, 2 * A_1.Height, 0f, 180f);
				break;
			case HMIShapeType.ST_LeftTopEllipse:
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top, 2 * A_1.Width, 2 * A_1.Height, 180f, 90f);
				break;
			case HMIShapeType.ST_LeftBottomEllipse:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top - A_1.Height, 2 * A_1.Width, 2 * A_1.Height, 90f, 90f);
				break;
			case HMIShapeType.ST_RightTopEllipse:
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddArc(A_1.Left - A_1.Width, A_1.Top, 2 * A_1.Width, 2 * A_1.Height, 270f, 90f);
				break;
			case HMIShapeType.ST_RightBottomEllipse:
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddArc(A_1.Left - A_1.Width, A_1.Top - A_1.Height, 2 * A_1.Width, 2 * A_1.Height, 0f, 90f);
				break;
			case HMIShapeType.ST_LeftTopChord:
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Left, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top, 2 * A_1.Width, 2 * A_1.Height, 180f, 90f);
				break;
			case HMIShapeType.ST_LeftBottomChord:
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top - A_1.Height, 2 * A_1.Width, 2 * A_1.Height, 90f, 90f);
				break;
			case HMIShapeType.ST_CustomizedChord:
				A_0.AddArc(A_1, r, s - r);
				A_0.CloseFigure();
				break;
			case HMIShapeType.ST_CustomizedPie:
				A_0.AddPie(A_1, r, s - r);
				break;
			case HMIShapeType.ST_Polygon:
			{
				Point[] array = new Point[d];
				if (d >= 3)
				{
					array[0] = e;
					array[1] = f;
					array[2] = g;
				}
				if (d >= 4)
				{
					array[3] = h;
				}
				if (d >= 5)
				{
					array[4] = i;
				}
				if (d >= 6)
				{
					array[5] = j;
				}
				if (d >= 7)
				{
					array[6] = k;
				}
				if (d >= 8)
				{
					array[7] = l;
				}
				if (d >= 9)
				{
					array[8] = m;
				}
				if (d >= 10)
				{
					array[9] = n;
				}
				if (d >= 4)
				{
					array[3] = h;
				}
				A_0.AddPolygon(array);
				break;
			}
			case HMIShapeType.ST_RectRing:
			{
				int num5 = t;
				if (2 * num5 > A_1.Width - 2)
				{
					num5 = (A_1.Width - 2) / 2;
				}
				if (2 * num5 > A_1.Height - 2)
				{
					num5 = (A_1.Height - 2) / 2;
				}
				A_0.AddRectangle(A_1);
				Rectangle rect = new Rectangle(A_1.Left + num5, A_1.Top + num5, A_1.Width - 2 * num5, A_1.Height - 2 * num5);
				A_0.AddRectangle(rect);
				break;
			}
			case HMIShapeType.ST_RectTopTriangle:
				if (num2 > A_1.Height - 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_RectBottomTriangle:
				if (num2 > A_1.Height - 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				break;
			case HMIShapeType.ST_RectLeftRightTwoTriangle:
				if (num2 > A_1.Width / 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_RectLeftArc:
				if (num2 > A_1.Width - 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Top, 2 * num2, A_1.Height, 270f, -180f);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Left + num2, A_1.Top);
				break;
			case HMIShapeType.ST_RectTopArc:
				if (num2 > A_1.Height - 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Top, A_1.Width, 2 * num2, 0f, -180f);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right, A_1.Top + num2);
				break;
			case HMIShapeType.ST_RectBottomArc:
				if (num2 > A_1.Height - 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Bottom - 2 * num2, A_1.Width, 2 * num2, 0f, 180f);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom - num2);
				break;
			case HMIShapeType.ST_RectTopBottomTwoArc:
				if (num2 > A_1.Height / 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Top, A_1.Width, 2 * num2, 0f, -180f);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left, A_1.Bottom - num2);
				A_0.AddArc(A_1.Left, A_1.Bottom - 2 * num2, A_1.Width, 2 * num2, 180f, -180f);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Right, A_1.Top + num2);
				break;
			case HMIShapeType.ST_RectLRTBFourArc:
				if (num2 > A_1.Width / 2)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 > A_1.Height / 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Top + num2, 2 * num2, A_1.Height - 2 * num2, 270f, -180f);
				A_0.AddArc(A_1.Left + num2, A_1.Bottom - 2 * num2, A_1.Width - 2 * num2, 2 * num2, 180f, -180f);
				A_0.AddArc(A_1.Right - 2 * num2, A_1.Top + num2, 2 * num2, A_1.Height - 2 * num2, 90f, -180f);
				A_0.AddArc(A_1.Left + num2, A_1.Top, A_1.Width - 2 * num2, 2 * num2, 0f, -180f);
				break;
			case HMIShapeType.ST_RectLeftRightTwoArc:
				if (num2 > A_1.Width / 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddArc(A_1.Left, A_1.Top, 2 * num2, A_1.Height, 270f, -180f);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Right - num2, A_1.Bottom);
				A_0.AddArc(A_1.Right - 2 * num2, A_1.Top, 2 * num2, A_1.Height, 90f, -180f);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Left + num2, A_1.Top);
				break;
			case HMIShapeType.ST_RectRightArc:
				if (num2 > A_1.Width - 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddArc(A_1.Right - 2 * num2, A_1.Top, 2 * num2, A_1.Height, 270f, 180f);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right - num2, A_1.Top);
				break;
			case HMIShapeType.ST_RectLRTBFourTriangle:
				if (num2 > A_1.Width / 2)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 > A_1.Height / 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_RectTopBottomTwoTriangle:
				if (num2 > A_1.Height / 2)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_RectRightTriangle:
				if (num2 > A_1.Width - 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_RectLeftTriangle:
				if (num2 > A_1.Width - 2)
				{
					num2 = A_1.Width / 2;
				}
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_HalfEllipseRing:
			{
				int num4 = t;
				if (2 * num4 > A_1.Width - 2)
				{
					num4 = (A_1.Width - 2) / 2;
				}
				if (2 * num4 > A_1.Height - 2)
				{
					num4 = (A_1.Height - 2) / 2;
				}
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top, A_1.Width, 2 * A_1.Height, 180f, 180f);
				A_0.CloseFigure();
				A_0.StartFigure();
				A_0.AddLine(A_1.Right - num4, A_1.Bottom - num4, A_1.Left + num4, A_1.Bottom - num4);
				A_0.AddArc(A_1.Left + num4, A_1.Top + num4, A_1.Width - 2 * num4, 2 * (A_1.Height - 2 * num4), 180f, 180f);
				A_0.CloseFigure();
				break;
			}
			case HMIShapeType.ST_EllipseRing:
			{
				int num3 = t;
				if (2 * num3 > A_1.Width - 2)
				{
					num3 = (A_1.Width - 2) / 2;
				}
				if (2 * num3 > A_1.Height - 2)
				{
					num3 = (A_1.Height - 2) / 2;
				}
				A_0.AddEllipse(A_1);
				A_0.AddEllipse(A_1.Left + num3, A_1.Top + num3, A_1.Width - 2 * num3, A_1.Height - 2 * num3);
				break;
			}
			case HMIShapeType.ST_RightBottomChord:
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, A_1.Top);
				A_0.AddArc(A_1.Left - A_1.Width, A_1.Top - A_1.Height, 2 * A_1.Width, 2 * A_1.Height, 0f, 90f);
				break;
			case HMIShapeType.ST_RightTopChord:
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddArc(A_1.Left - A_1.Width, A_1.Top, 2 * A_1.Width, 2 * A_1.Height, 270f, 90f);
				break;
			case HMIShapeType.ST_RightHalfEllipse:
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left, A_1.Top);
				A_0.AddArc(A_1.Left - A_1.Width, A_1.Top, 2 * A_1.Width, A_1.Height, 270f, 180f);
				break;
			case HMIShapeType.ST_LeftHalfEllipse:
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddArc(A_1.Left, A_1.Top, 2 * A_1.Width, A_1.Height, 90f, 180f);
				break;
			case HMIShapeType.ST_LRTBFourArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, (A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 - num / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2, A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Left + num2, (A_1.Top + A_1.Bottom) / 2 + num / 2, (A_1.Left + A_1.Right) / 2 - num / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, (A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2 + num / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num / 2, (A_1.Left + A_1.Right) / 2 + num / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_RightTopBottomThreeArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left + (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Top + num2, A_1.Left + (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left + num2 / 2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Bottom, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left + (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Bottom - num2, A_1.Left + (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 + num2 / 2, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num2 / 2, A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Right - num2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Left + (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, (A_1.Top + A_1.Bottom) / 2 - num / 2, A_1.Left + (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Top + num2, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left + num2 / 2, A_1.Top);
				break;
			case HMIShapeType.ST_LeftRightTopThreeArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Bottom - num2 / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Left + num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 - num) / 2, A_1.Right - num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 - num) / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right, A_1.Bottom - num2 / 2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2 / 2, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right - num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 + num) / 2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Bottom - (num2 + num) / 2, (A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 + num2 / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, (A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num2 / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + num2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Top + num2, (A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine((A_1.Left + A_1.Right) / 2 - num / 2, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2 / 2);
				break;
			case HMIShapeType.ST_RightBottomTwoArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right, A_1.Top + num2 / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right - num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (num2 - num) / 2, A_1.Left + (num2 - num) / 2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Top + (num2 - num) / 2, A_1.Left + (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 - num) / 2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, A_1.Left + num2 / 2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2 / 2, A_1.Bottom, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left + (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Bottom - num2, A_1.Left + (num2 + num) / 2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Left + (num2 + num) / 2, A_1.Top + (num2 + num) / 2, A_1.Right - num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (num2 + num) / 2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right, A_1.Top + num2 / 2);
				break;
			case HMIShapeType.ST_LeftTopTwoArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Bottom - num2 / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Left + num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 - num) / 2, A_1.Right - (num2 - num) / 2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Bottom - (num2 - num) / 2, A_1.Right - (num2 - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Top + num2, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, A_1.Right - num2 / 2, A_1.Top);
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Top, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right - (num2 + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Top + num2, A_1.Right - (num2 + num) / 2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - (num2 + num) / 2, A_1.Left + num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2 / 2);
				break;
			case HMIShapeType.ST_TopBottomTwoArrow:
				if (num > A_1.Width)
				{
					num = A_1.Width / 2;
				}
				if (num2 > A_1.Height / 2)
				{
					num2 = A_1.Height / 4;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left + (A_1.Width - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Top + num2, A_1.Left + (A_1.Width - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Bottom - num2, A_1.Left, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left, A_1.Bottom - num2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Left + (A_1.Width + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Bottom - num2, A_1.Left + (A_1.Width + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Top + num2, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_LeftRightTwoArrow:
				if (num > A_1.Height)
				{
					num = A_1.Height / 2;
				}
				if (num2 > A_1.Width / 2)
				{
					num2 = A_1.Width / 4;
				}
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left + num2, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (A_1.Height - num) / 2, A_1.Right - num2, A_1.Top + (A_1.Height - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (A_1.Height - num) / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right - num2, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (A_1.Height + num) / 2, A_1.Left + num2, A_1.Top + (A_1.Height + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (A_1.Height + num) / 2, A_1.Left + num2, A_1.Bottom);
				A_0.AddLine(A_1.Left + num2, A_1.Bottom, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_TopRightArrow:
				if (num > A_1.Width / 2)
				{
					num = A_1.Width / 4;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right - num2 / 2, A_1.Bottom, A_1.Right, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right, A_1.Bottom - num2, A_1.Right - (num2 - num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Bottom - num2, A_1.Right - (num2 - num) / 2, A_1.Top);
				A_0.AddLine(A_1.Right - (num2 - num) / 2, A_1.Top, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Left, A_1.Top + num);
				A_0.AddLine(A_1.Left, A_1.Top + num, A_1.Right - (num2 + num) / 2, A_1.Top + num);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Top + num, A_1.Right - (num2 + num) / 2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - (num2 + num) / 2, A_1.Bottom - num2, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right - num2 / 2, A_1.Bottom);
				break;
			case HMIShapeType.ST_RightTopArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Left, A_1.Top + num2 / 2, A_1.Left + num2, A_1.Top);
				A_0.AddLine(A_1.Left + num2, A_1.Top, A_1.Left + num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 - num) / 2, A_1.Right, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Right, A_1.Top + (num2 - num) / 2, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Right - num, A_1.Bottom);
				A_0.AddLine(A_1.Right - num, A_1.Bottom, A_1.Right - num, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + (num2 + num) / 2, A_1.Left + num2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + num2, A_1.Top + num2, A_1.Left, A_1.Top + num2 / 2);
				break;
			case HMIShapeType.ST_LeftBottomArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right, A_1.Bottom - num2 / 2, A_1.Right - num2, A_1.Bottom);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom, A_1.Right - num2, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 - num) / 2, A_1.Left, A_1.Bottom - (num2 - num) / 2);
				A_0.AddLine(A_1.Left, A_1.Bottom - (num2 - num) / 2, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Left + num, A_1.Top);
				A_0.AddLine(A_1.Left + num, A_1.Top, A_1.Left + num, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num, A_1.Bottom - (num2 + num) / 2, A_1.Right - num2, A_1.Bottom - (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - (num2 + num) / 2, A_1.Right - num2, A_1.Bottom - num2);
				A_0.AddLine(A_1.Right - num2, A_1.Bottom - num2, A_1.Right, A_1.Bottom - num2 / 2);
				break;
			case HMIShapeType.ST_LeftTopArrow:
				if (num > A_1.Height / 2)
				{
					num = A_1.Height / 4;
				}
				if (num2 > A_1.Width)
				{
					num2 = A_1.Width / 2;
				}
				if (num2 < num)
				{
					num2 = num;
				}
				A_0.AddLine(A_1.Right, A_1.Top + num2 / 2, A_1.Right - num2, A_1.Top);
				A_0.AddLine(A_1.Right - num2, A_1.Top, A_1.Right - num2, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (num2 - num) / 2, A_1.Left, A_1.Top + (num2 - num) / 2);
				A_0.AddLine(A_1.Left, A_1.Top + (num2 - num) / 2, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Left + num, A_1.Bottom);
				A_0.AddLine(A_1.Left + num, A_1.Bottom, A_1.Left + num, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Left + num, A_1.Top + (num2 + num) / 2, A_1.Right - num2, A_1.Top + (num2 + num) / 2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + (num2 + num) / 2, A_1.Right - num2, A_1.Top + num2);
				A_0.AddLine(A_1.Right - num2, A_1.Top + num2, A_1.Right, A_1.Top + num2 / 2);
				break;
			case HMIShapeType.ST_TopArrow:
				if (num > A_1.Width)
				{
					num = A_1.Width / 2;
				}
				if (num2 > A_1.Height)
				{
					num2 = A_1.Height / 2;
				}
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, A_1.Top + num2);
				A_0.AddLine(A_1.Left, A_1.Top + num2, A_1.Left + (A_1.Width - num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Top + num2, A_1.Left + (A_1.Width - num) / 2, A_1.Bottom);
				A_0.AddLine(A_1.Left + (A_1.Width - num) / 2, A_1.Bottom, A_1.Left + (A_1.Width + num) / 2, A_1.Bottom);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Bottom, A_1.Left + (A_1.Width + num) / 2, A_1.Top + num2);
				A_0.AddLine(A_1.Left + (A_1.Width + num) / 2, A_1.Top + num2, A_1.Right, A_1.Top + num2);
				A_0.AddLine(A_1.Right, A_1.Top + num2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_RightTriangle:
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, A_1.Left, A_1.Top);
				A_0.AddLine(A_1.Left, A_1.Top, A_1.Left, A_1.Bottom);
				A_0.AddLine(A_1.Left, A_1.Bottom, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_LeftTriangle:
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, A_1.Right, A_1.Top);
				A_0.AddLine(A_1.Right, A_1.Top, A_1.Right, A_1.Bottom);
				A_0.AddLine(A_1.Right, A_1.Bottom, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				break;
			case HMIShapeType.ST_Diamond:
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Top, A_1.Left, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Left, (A_1.Top + A_1.Bottom) / 2, (A_1.Left + A_1.Right) / 2, A_1.Bottom);
				A_0.AddLine((A_1.Left + A_1.Right) / 2, A_1.Bottom, A_1.Right, (A_1.Top + A_1.Bottom) / 2);
				A_0.AddLine(A_1.Right, (A_1.Top + A_1.Bottom) / 2, (A_1.Left + A_1.Right) / 2, A_1.Top);
				break;
			case HMIShapeType.ST_Ellipse:
				A_0.AddEllipse(A_1);
				break;
			case HMIShapeType.ST_Rectangle:
				A_0.AddRectangle(A_1);
				break;
			}
			A_0.CloseFigure();
		}

		protected void b()
		{
			if (z)
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
			if (!z)
			{
				base.OnPaintBackground(A_0);
			}
		}
	}
}
