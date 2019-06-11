 using AdvancedScada.IBaseService;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AdvancedScada.HMIs.Drawing
{
	internal class HMIValveListItem : DesignerActionList
	{
		private HMIValve _HMIValve;

		public HMIValveType ValveTYpe
		{
			get
			{
				return _HMIValve.ValveTYpe;
			}
			set
			{
				_HMIValve.ValveTYpe = value;
			}
		}

		public HMIValveKnobType KnobType
		{
			get
			{
				return _HMIValve.KnobType;
			}
			set
			{
				_HMIValve.KnobType = value;
			}
		}

		public Color KnobColor
		{
			get
			{
				return _HMIValve.KnobColor;
			}
			set
			{
				_HMIValve.KnobColor = value;
			}
		}

		public DashStyle BorderDash
		{
			get
			{
				return _HMIValve.BorderDash;
			}
			set
			{
				_HMIValve.BorderDash = value;
			}
		}

		public Font Font
		{
			get
			{
				return _HMIValve.Font;
			}
			set
			{
				_HMIValve.Font = value;
			}
		}

		public bool TransparentBackground
		{
			get
			{
				return _HMIValve.TransparentBackground;
			}
			set
			{
				_HMIValve.TransparentBackground = value;
			}
		}

		public bool Gradient
		{
			get
			{
				return _HMIValve.Gradient;
			}
			set
			{
				_HMIValve.Gradient = value;
			}
		}

		public bool Value
		{
			get
			{
				return _HMIValve.Value;
			}
			set
			{
				_HMIValve.Value = value;
			}
		}

		public string TagName
		{
			get
			{
				return _HMIValve.TagName;
			}
			set
			{
				_HMIValve.TagName = value;
				_HMIValve.Invalidate();
			}
		}

		public HMIValveListItem(HMIValveDesigner owner)
			: base(owner.Component)
		{
			_HMIValve = (HMIValve)owner.Component;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			return new DesignerActionItemCollection
			{
				new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"),
				new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"),
				new DesignerActionPropertyItem("ValveTYpe", "ValveTYpe"),
				new DesignerActionPropertyItem("KnobType", "KnobType"),
				new DesignerActionPropertyItem("KnobColor", "KnobColor"),
				new DesignerActionPropertyItem("BorderDash", "BorderDash"),
				new DesignerActionPropertyItem("TransparentBackground", "TransparentBackground"),
				new DesignerActionPropertyItem("Gradient", "Gradient"),
				new DesignerActionPropertyItem("Value", "Value"),
				new DesignerActionPropertyItem("TagName", "TagName")
			};
		}

		private void ShowTagListForm()
		{
            MonitorForm tagCollectionForm = new MonitorForm();
			tagCollectionForm.OnTagSelected_Clicked = (EventTagSelected)Delegate.Combine(tagCollectionForm.OnTagSelected_Clicked, (EventTagSelected)delegate(string tagName)
			{
				SetProperty(_HMIValve, "TagName", tagName);
			});
			tagCollectionForm.StartPosition = FormStartPosition.CenterScreen;
			tagCollectionForm.ShowDialog();
		}

		public void SetProperty(Control control, string propertyName, object value)
		{
			TypeDescriptor.GetProperties(control)[propertyName].SetValue(control, value);
		}
	}
}
