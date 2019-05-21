using AdvancedScada;
using AdvancedScada.Controls;
using AdvancedScada.Controls.Licenses;
using AdvancedScada.Controls.TankAll;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.TankAll
{
    /// <summary>
    ///     A cylindrical track bar filled with a gradient
    ///     * No warranty or gaurantee expressed or implied *
    /// </summary>
    [Designer(typeof(CylinderTrackBarDesigner))]
    [DefaultEvent("ValueChanged")]
    public class HMICylinderTrackBar : System.Windows.Forms.Control
    {
        public delegate void SetValuesCallback(string FullPath, object value);

        private string _TagName;
        private double _value;

        /// <summary>
        ///     Fields
        /// </summary>

        //private MouseState		mouseState;
        private int alpha;

        private Color barColor = Color.FromArgb(192, 255, 192);
        private double max;
        private string mh_TagPath;
        private double min;
        private Color outLineColor;
        private bool showValue;

        /// <summary>
        ///     Initializes a new instance of the CloseButton class.
        /// </summary>
        public HMICylinderTrackBar()
        {
            // This call is required by the Windows.Forms Form Designer.
            ForeColor = Color.Black;
            Name = "CylinderTrackBar";
            Size = new Size(56, 168);
            CreateNewGUID();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            //
            // Initialize Value
            //
            //this.mouseState = MouseState.Normal;
            alpha = 150;
            barColor = Color.Blue;
            max = 100;
            _value = 1;
            min = 0;
            outLineColor = Color.Gray;
            ForeColor = Color.LightGray;
            showValue = true;
        }

        [Category(".NET HMI")]
        [Browsable(true)]
        public string TagN
        {
            get
            {
                return mh_TagPath;
                ;
            }
            set
            {
                FireChanging();
                try
                {
                    mh_TagPath = value;
                    Check();
                }
                finally
                {
                    FireChanged();
                } //

                Invalidate();
            }
        }

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
                    DataBindings.Add(bd);
                }
                catch (Exception)
                {
                }
            }
        }

        private void Check()
        {
            try
            {
                //not support design time
                if (Process.GetCurrentProcess().ProcessName == "devenv"
                    || Process.GetCurrentProcess().ProcessName == "VCSExpress"
                    || Process.GetCurrentProcess().ProcessName == "vbexpress"
                    || Process.GetCurrentProcess().ProcessName == "WDExpress")
                    return;
            }
            catch
            {
                return;
            }

            StartRuntime();
        }


        //
        // Events
        //
        /// <summary>
        ///     Occurs when value was changed.
        /// </summary>
        public event EventHandler ValueChanged;

        protected override void OnResize(EventArgs e)
        {
            if (Height < 120) Height = 120;
            if (Width < 70) Width = 70;
            base.OnResize(e);
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
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

        private void StartRuntime()
        {
            //var array = new string[0];
            //if (StringType.StrCmp(mh_TagPath, "", false) != 0)
            //{
            //    array = (string[])Array.Copy(array,new string[array.GetLength(0) + 1]);

            //    array[array.GetLength(0) - 1] = mh_TagPath;
            //}

            //if (array.GetLength(0) > 0)
            //{
            //    //iDelegate.DelegateControlUpdateValues iiDelegate = new iDelegate.DelegateControlUpdateValues(this.UpdateValues);
            //    //Delegate @delegate = iiDelegate;
            //    //string Guid = m_InstanceGUID;
            //    //iDelegate.AddControlGUID(array, 0, Guid, ref @delegate);
            //    //iiDelegate = (iDelegate.DelegateControlUpdateValues)@delegate;
            //}
        }

        internal void UpdateValues(string FullPath, object value)
        {
            SetValues(FullPath, value);
        }

        private void SetValues(string FullPath, object value)
        {
            var method = new SetValuesCallback(SetFinalValues);
            Invoke(method, FullPath, value);
        }

        private void SetFinalValues(string FullPath, object value)
        {
            try
            {
                Value = Convert.ToDouble(value.ToString());
            }
            catch
            {
                Value = 0;
            }

            Invalidate();
        }

        #region EventHandler.

        /// <summary>
        ///     On value changed
        /// </summary>
        /// <param name="e"></param>
        private void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);

            Invalidate();
        }

        #endregion


        #region Public Properties

        /// <summary>
        ///     Inner color - will appear as a gradient
        /// </summary>
        [Category("Mycos TrackBar")]
        public Color BarColor
        {
            get { return barColor; }
            set
            {
                if (barColor != value)
                {
                    barColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///     Outline color
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(typeof(Color), "Gray")]
        public Color OutLineColor
        {
            get { return outLineColor; }
            set
            {
                if (outLineColor != value)
                {
                    outLineColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///     Determines the maximum value with the default set to 100
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(100f)]
        public double Maximum
        {
            get { return max; }
            set
            {
                if (max != value) max = value;
            }
        }

        /// <summary>
        ///     Determines the minimum value (defaults to 0)
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(0f)]
        public double Minimum
        {
            get { return min; }
            set
            {
                if (min != value) min = value;
            }
        }

        /// <summary>
        ///     Get or set the current Value
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(1f)]
        public double Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///     Customize the transparency
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(255)]
        public int Alpha
        {
            get { return alpha; }
            set
            {
                if (alpha != value)
                {
                    alpha = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///     Toggle the display of the value when resizing
        /// </summary>
        [Category("Mycos TrackBar")]
        [DefaultValue(false)]
        public bool ShowValue
        {
            get { return showValue; }
            set
            {
                if (showValue != value)
                {
                    showValue = value;
                    Invalidate();
                }
            }
        }

        #endregion

        #region 8/2015

        private string m_InstanceGUID;

        private void CreateNewGUID()
        {
            var array = new byte[16];
            var rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            rNGCryptoServiceProvider.GetBytes(array);
            var guid = new Guid(array);
            m_InstanceGUID = guid.ToString();
        }

        #endregion

        #region Paint Code.

        /// <summary>
        ///     Overridden OnPaint for custom painting.
        /// </summary>
        /// <param name="e">A System.Windows.Forms.PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            var g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBar(g, Color.WhiteSmoke);
        } //end Paint

        /// <summary>
        ///     Do the actual drawing here
        /// </summary>
        /// <param name="g"></param>
        /// <param name="foreColor"></param>
        private void DrawBar(Graphics g, Color foreColor)
        {
            if (Value > Maximum) Value = Maximum;
            if (Value < Minimum) Value = Minimum;

            var outLine = outLineColor != Color.Transparent;
            var bound = ClientRectangle;

            bound.Inflate(-2, -12);
            //nen
            DrawingUtils.FillCylinder(g, bound, new Size(0, 12), Color.FromArgb(255, foreColor), OutLineColor, outLine);
            //gia tri
            //if (this.Value < 1) { this.Value = 1; }
            if (Value >= Minimum && Value <= Maximum)
            {
                var barValue = bound.Height * ((Value - Minimum) / (Maximum - Minimum));
                if (barValue == 0) barValue = 1.0;
                var valueBound = RectangleF.FromLTRB(bound.Left, Convert.ToSingle(bound.Bottom - barValue), bound.Right,
                    bound.Bottom);
                DrawingUtils.FillCylinder(g, valueBound, new Size(0, 12), Color.FromArgb(Alpha, BarColor), OutLineColor,
                    outLine);
                DrawingUtils.elipse(g, valueBound, new Size(0, 12), Color.FromArgb(Alpha, BarColor), OutLineColor,
                    outLine);
                //ve vach chia
                var rate = -2;
                for (var i = 0; i <= 25; i++)
                {
                    rate = 17 + i * (Height - 30) / 25;
                    g.DrawLine(new Pen(Brushes.Black, 1), new Point(Width * 7 / 16, rate),
                        new Point(Width * 9 / 16, rate));
                    if (i % 5 == 0)
                    {
                        g.DrawLine(new Pen(Brushes.Black, 1), new Point(Width * 3 / 8, rate),
                            new Point(Width * 5 / 8, rate));
                        // ve chu

                        #region ve chu

                        var rec2 = new Rectangle(Width / 13, rate - (Height - 30) / 25, Width * 3 / 10,
                            (Height - 26) / 10);
                        var fon = new Font("arial", rec2.Height, FontStyle.Bold, GraphicsUnit.Pixel);
                        var str = new StringFormat();
                        str.Alignment = StringAlignment.Far;
                        str.LineAlignment = StringAlignment.Center;
                        var val = (25 - i) / 5 * 20;
                        //g.FillRectangle(new SolidBrush(Color.Blue), rec2);
                        g.DrawString(val.ToString(), fon, new SolidBrush(Color.Black), rec2, str);

                        #endregion
                    }
                }
            } //end in Length

            //nap 
            DrawingUtils.elipse(g, bound, new Size(0, 12), Color.FromArgb(255, foreColor), OutLineColor, outLine);
        }

        #endregion
    }

    internal class CylinderTrackBarDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;
        private HMICylinderTrackBar control;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new CylinderTrackBarListItem(this));
                }

                return actionLists;
            }
        }

        protected override void OnMouseDragBegin(int x, int y)
        {
            base.OnMouseDragBegin(x, y);
            control = (HMICylinderTrackBar)Control;
            // control.drag = true;
        }

        protected override void OnMouseLeave()
        {
            base.OnMouseLeave();
            control = (HMICylinderTrackBar)Control;
            //control.drag = false;
        }
    }

    internal class CylinderTrackBarListItem : DesignerActionList
    {
        private readonly HMICylinderTrackBar shape;

        public CylinderTrackBarListItem(CylinderTrackBarDesigner owner)
            : base(owner.Component)
        {
            shape = (HMICylinderTrackBar)owner.Component;
        }

        public string TagName
        {
            get { return shape.TagName; }
            set { shape.TagName = value; }
        }

        public Color BarColor
        {
            get { return ((HMICylinderTrackBar)Component).BarColor; }
            set { ((HMICylinderTrackBar)Component).BarColor = value; }
        }

        public Color OutLineColor
        {
            get { return ((HMICylinderTrackBar)Component).OutLineColor; }
            set { ((HMICylinderTrackBar)Component).OutLineColor = value; }
        }

        public double MinVal
        {
            get { return ((HMICylinderTrackBar)Component).Minimum; }
            set { ((HMICylinderTrackBar)Component).Minimum = value; }
        }

        public double MaxVal
        {
            get { return ((HMICylinderTrackBar)Component).Maximum; }
            set { ((HMICylinderTrackBar)Component).Maximum = value; }
        }

        public int Alpha
        {
            get { return ((HMICylinderTrackBar)Component).Alpha; }
            set { ((HMICylinderTrackBar)Component).Alpha = value; }
        }

        public bool ShowValue
        {
            get { return ((HMICylinderTrackBar)Component).ShowValue; }
            set { ((HMICylinderTrackBar)Component).ShowValue = value; }
        }

        public string TagN
        {
            get { return ((HMICylinderTrackBar)Component).TagN; }
            set { ((HMICylinderTrackBar)Component).TagN = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionHeaderItem("HMI Professional"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagList", "Choose Tag"));
            items.Add(new DesignerActionPropertyItem("BarColor", "BarColor"));
            items.Add(new DesignerActionPropertyItem("OutLineColor", "OutLineColor"));
            items.Add(new DesignerActionPropertyItem("MinVal", "MinVal"));
            items.Add(new DesignerActionPropertyItem("MaxVal", "MaxVal"));
            items.Add(new DesignerActionPropertyItem("Alpha", "Alpha"));
            items.Add(new DesignerActionPropertyItem("TagName", "TagName"));
            items.Add(new DesignerActionPropertyItem("ShowValue", "ShowValue"));
            return items;
        }

        private void ShowTagList()
        {
            var frm = new MonitorForm(TagName);
            frm.OnTagSelected_Clicked += tagName =>
            {
                var pd = TypeDescriptor.GetProperties(shape)["TagName"];
                pd.SetValue(shape, tagName);
            };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }


        private void check()
        {
            //TAGSELECT f = new TAGSELECT();
            //f.OnSelect += f_OnSelect;
            //f.Show();
        }

        private void f_OnSelect(string task, string tag)
        {
            SetProperty(shape, "TagN", task + ":" + tag);
        }

        public void SetProperty(System.Windows.Forms.Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
