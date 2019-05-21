using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Animation;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.ProgressBar
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMIProgressBar), "HMI7Segment.ico")]
    [Designer(typeof(HMIProgressBarDesigner))]
    public class HMIProgressBar : System.Windows.Forms.ProgressBar
    {
        private readonly Animator _animator;
        private int? _animatedStartAngle;

        private float? _animatedValue;

        private Brush _backBrush;

        private Color _InnerColor;

        private ProgressBarStyle? _lastStyle;

        private int _lastValue;

        private Color _OuterColor;

        private Color _ProgressColor;
        private string _TagName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HMIProgressBar" /> class.
        /// </summary>
        public HMIProgressBar()
        {
            SetStyle(
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            _animator = DesignMode ? null : new Animator();
            //AnimationFunction = AnimationFunctions.CubicEaseIn;
            AnimationSpeed = 20; // 500;
            MarqueeAnimationSpeed = 2000;
            StartAngle = 265; // 270;

            _lastValue = Value;

            // Child class should be responsible for handling this values at the constructor
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(64, 64, 64);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point,
                0); //new Font(Font.FontFamily, 72, FontStyle.Bold);
            SecondaryFont = new Font(Font.FontFamily, (float)(Font.Size * .5), FontStyle.Regular);
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            OuterMargin = -25;
            OuterWidth = 26;
            OuterColor = Color.Gray;

            ProgressWidth = 10; //25;
            ProgressColor = Color.FromArgb(255, 128, 0);

            InnerMargin = 2;
            InnerWidth = -1;
            InnerColor = Color.FromArgb(224, 224, 224);

            TextMargin = new Padding(0, 4, 0, 0); // new Padding(8, 8, 0, 0);
            Value = 56;

            SuperscriptMargin = new Padding(10, 35, 0, 0);
            SuperscriptColor = Color.FromArgb(166, 166, 166);
            SuperscriptText = string.Empty; // "°C";

            SubscriptMargin = new Padding(10, -35, 0, 0);
            SubscriptColor = Color.FromArgb(166, 166, 166);
            SubscriptText = string.Empty; // ".23";

            Size = new Size(80, 80);
        }

        /// <summary>
        ///     Gets or sets the font of text in the <see cref="HMIProgressBar" />.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Drawing.Font" /> of the text. The default is the font set by the container.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Gets or sets the text in the <see cref="HMIProgressBar" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        ///// <summary>
        /////     Gets or sets the animation function.
        ///// </summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //[Browsable(false)]
        //public AnimationFunctions.Function AnimationFunction { get; set; }

        /// <summary>
        ///     Gets or sets the animation speed in milliseconds.
        /// </summary>
        [Category("Behavior")]
        public int AnimationSpeed { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding TextMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SuperscriptMargin { get; set; }


        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SubscriptMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color InnerColor
        {
            get { return _InnerColor; }
            set
            {
                FireChanged();
                try
                {
                    _InnerColor = value;
                }
                finally
                {
                    FireChanged();
                }

                Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color OuterColor
        {
            get { return _OuterColor; }
            set
            {
                FireChanged();
                try
                {
                    _OuterColor = value;
                }
                finally
                {
                    FireChanged();
                }

                Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set
            {
                FireChanged();
                try
                {
                    _ProgressColor = value;
                }
                finally
                {
                    FireChanged();
                }

                Invalidate();
            }
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int StartAngle { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int ProgressWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SubscriptText { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SubscriptColor { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Font SecondaryFont { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SuperscriptText { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SuperscriptColor { get; set; }

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

        /// <inheritdoc />
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            Invalidate();
        }

        /// <inheritdoc />
        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
            Invalidate();
        }

        /// <inheritdoc />
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidated -= ParentOnInvalidated;
                Parent.Resize -= ParentOnResize;
            }

            base.OnParentChanged(e);
            if (Parent != null)
            {
                Parent.Invalidated += ParentOnInvalidated;
                Parent.Resize += ParentOnResize;
            }
        }

        /// <summary>
        ///     Occurs when parent's display requires redrawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="invalidateEventArgs"></param>
        protected virtual void ParentOnInvalidated(object sender, InvalidateEventArgs invalidateEventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Occurs when the parent resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected virtual void ParentOnResize(object sender, EventArgs eventArgs)
        {
            RecreateBackgroundBrush();
        }

        /// <summary>
        ///     Update or create the brush used for drawing the background
        /// </summary>
        protected virtual void RecreateBackgroundBrush()
        {
            lock (this)
            {
                //_backBrush?this.Dispose();
                _backBrush = new SolidBrush(BackColor);
                if (BackColor.A == 255) return;
                if (Parent != null)
                    using (var parentImage = new Bitmap(Parent.Width, Parent.Height))
                    {
                        using (var parentGraphic = Graphics.FromImage(parentImage))
                        {
                            var pe = new PaintEventArgs(parentGraphic,
                                new Rectangle(new Point(0, 0), parentImage.Size));
                            InvokePaintBackground(Parent, pe);
                            InvokePaint(Parent, pe);

                            if (BackColor.A > 0) // Translucent
                                parentGraphic.FillRectangle(_backBrush, Bounds);
                        }

                        _backBrush = new TextureBrush(parentImage);
                        ((TextureBrush)_backBrush).TranslateTransform(-Bounds.X, -Bounds.Y);
                    }
                else
                    _backBrush = new SolidBrush(Color.FromArgb(255, BackColor));
            }
        }

        /// <inheritdoc />
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }

        /// <inheritdoc />
        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            RecreateBackgroundBrush();
        }


        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (Style == ProgressBarStyle.Marquee)
                        InitializeMarquee(_lastStyle != Style);
                    else
                        InitializeContinues(_lastStyle != Style);
                    _lastStyle = Style;
                }

                if (_backBrush == null) RecreateBackgroundBrush();
                StartPaint(e.Graphics);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        ///     Initialize the animation for the continues styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeContinues(bool firstTime)
        {
            if (_lastValue == Value && !firstTime) return;

            _lastValue = Value;

            _animator.Stop();
            _animator.Paths = new Path(_animatedValue ?? Value, Value, (ulong)AnimationSpeed).ToArray();
            _animator.Repeat = false;
            _animatedStartAngle = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedValue = v;
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     Initialize the animation for the marquee styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitializeMarquee(bool firstTime)
        {
            if (!firstTime &&
                (_animator.ActivePath == null || _animator.ActivePath.Duration == (ulong)MarqueeAnimationSpeed))
                return;

            _animator.Stop();
            _animator.Paths = new Path(0, 359, (ulong)MarqueeAnimationSpeed).ToArray();
            _animator.Repeat = true;
            _animatedValue = null;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedStartAngle = (int)v;
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     The function responsible for painting the control
        /// </summary>
        /// <param name="g">The <see cref="Graphics" /> object to draw into</param>
        protected virtual void StartPaint(Graphics g)
        {
            try
            {
                lock (this)
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    var point = AddPoint(Point.Empty, 2);
                    var size = AddSize(Size, -2 * 2);
                    if (OuterWidth + OuterMargin < 0)
                    {
                        var offset = Math.Abs(OuterWidth + OuterMargin);
                        point = AddPoint(Point.Empty, offset);
                        size = AddSize(Size, -2 * offset);
                    }

                    if (OuterColor != Color.Empty && OuterColor != Color.Transparent && OuterWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(OuterColor), new RectangleF(point, size));
                        if (OuterWidth >= 0)
                        {
                            point = AddPoint(point, OuterWidth);
                            size = AddSize(size, -2 * OuterWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    point = AddPoint(point, OuterMargin);
                    size = AddSize(size, -2 * OuterMargin);

                    g.FillPie(
                        new SolidBrush(ProgressColor),
                        ToRectangle(new RectangleF(point, size)),
                        _animatedStartAngle ?? StartAngle,
                        (_animatedValue ?? Value) / (Maximum - Minimum) * 360);
                    if (ProgressWidth >= 0)
                    {
                        point = AddPoint(point, ProgressWidth);
                        size = AddSize(size, -2 * ProgressWidth);
                        g.FillEllipse(_backBrush, new RectangleF(point, size));
                    }

                    point = AddPoint(point, InnerMargin);
                    size = AddSize(size, -2 * InnerMargin);

                    if (InnerColor != Color.Empty && InnerColor != Color.Transparent && InnerWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(InnerColor), new RectangleF(point, size));
                        if (InnerWidth >= 0)
                        {
                            point = AddPoint(point, InnerWidth);
                            size = AddSize(size, -2 * InnerWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    if (Text == string.Empty) return;

                    point.X += TextMargin.Left;
                    point.Y += TextMargin.Top;
                    size.Width -= TextMargin.Right;
                    size.Height -= TextMargin.Bottom;
                    var stringFormat =
                        new StringFormat(RightToLeft == RightToLeft.Yes ? StringFormatFlags.DirectionRightToLeft : 0)
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Near
                        };
                    var textSize = g.MeasureString(Text, Font);
                    var textPoint = new PointF(
                        point.X + (size.Width - textSize.Width) / 2,
                        point.Y + (size.Height - textSize.Height) / 2);
                    if (SubscriptText != string.Empty || SuperscriptText != string.Empty)
                    {
                        float maxSWidth = 0;
                        var supSize = SizeF.Empty;
                        var subSize = SizeF.Empty;
                        if (SuperscriptText != string.Empty)
                        {
                            supSize = g.MeasureString(SuperscriptText, SecondaryFont);
                            maxSWidth = Math.Max(supSize.Width, maxSWidth);
                            supSize.Width -= SuperscriptMargin.Right;
                            supSize.Height -= SuperscriptMargin.Bottom;
                        }

                        if (SubscriptText != string.Empty)
                        {
                            subSize = g.MeasureString(SubscriptText, SecondaryFont);
                            maxSWidth = Math.Max(subSize.Width, maxSWidth);
                            subSize.Width -= SubscriptMargin.Right;
                            subSize.Height -= SubscriptMargin.Bottom;
                        }

                        textPoint.X -= maxSWidth / 4;
                        if (SuperscriptText != string.Empty)
                        {
                            var supPoint = new PointF(
                                textPoint.X + textSize.Width - supSize.Width / 2,
                                textPoint.Y - supSize.Height * 0.85f);
                            supPoint.X += SuperscriptMargin.Left;
                            supPoint.Y += SuperscriptMargin.Top;
                            g.DrawString(
                                SuperscriptText,
                                SecondaryFont,
                                new SolidBrush(SuperscriptColor),
                                new RectangleF(supPoint, supSize),
                                stringFormat);
                        }

                        if (SubscriptText != string.Empty)
                        {
                            var subPoint = new PointF(
                                textPoint.X + textSize.Width - subSize.Width / 2,
                                textPoint.Y + textSize.Height * 0.85f);
                            subPoint.X += SubscriptMargin.Left;
                            subPoint.Y += SubscriptMargin.Top;
                            g.DrawString(
                                SubscriptText,
                                SecondaryFont,
                                new SolidBrush(SubscriptColor),
                                new RectangleF(subPoint, subSize),
                                stringFormat);
                        }
                    }

                    Text = $"{Value}"; // LUUHV
                    g.DrawString(
                        Text,
                        Font,
                        new SolidBrush(ForeColor),
                        new RectangleF(textPoint, textSize),
                        stringFormat);
                }
            }
            catch
            {
                // ignored
            }
        }

        private static PointF AddPoint(PointF p, int v)
        {
            p.X += v;
            p.Y += v;
            return p;
        }

        private static SizeF AddSize(SizeF s, int v)
        {
            s.Height += v;
            s.Width += v;
            return s;
        }

        private static Rectangle ToRectangle(RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }

        private void FireChanging()
        {
            var service = GetComponentChangeService();
            if (service != null)
                service.OnComponentChanging(this, null);
        }

        private void FireChanged()
        {
            var service = GetComponentChangeService();
            if (service != null)
                service.OnComponentChanged(this, null, null, null);
        }

        private IComponentChangeService GetComponentChangeService()
        {
            return GetService(typeof(IComponentChangeService)) as IComponentChangeService;
        }
    }

    internal class HMIProgressBarDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new HMIProgressBarListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class HMIProgressBarListItem : DesignerActionList
    {
        private readonly HMIProgressBar _HMIProgressBarArray;

        public HMIProgressBarListItem(HMIProgressBarDesigner owner)
            : base(owner.Component)
        {
            _HMIProgressBarArray = (HMIProgressBar)owner.Component;
        }


        public Color ProgressColor
        {
            get { return _HMIProgressBarArray.ProgressColor; }
            set { _HMIProgressBarArray.ProgressColor = value; }
        }


        public string TagName
        {
            get { return _HMIProgressBarArray.TagName; }
            set { _HMIProgressBarArray.TagName = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("ProgressColor", "ProgressColor"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName => { SetProperty(_HMIProgressBarArray, "TagName", tagName); };
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