
using AdvancedScada.IBaseService;
using AdvancedScada.Monitor;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedScada.HMIs.Drawing
{
	internal class HMILineListItem : DesignerActionList
	{
		private HMILine _HMILine;

		public HMILineType HMILineType
		{
			get
			{
				return _HMILine.LineTYpe;
			}
			set
			{
				_HMILine.LineTYpe = value;
			}
		}

		public int LineWidth
		{
			get
			{
				return _HMILine.LineWidth;
			}
			set
			{
				_HMILine.LineWidth = value;
			}
		}

		public Color LineColor
		{
			get
			{
				return _HMILine.LineColor;
			}
			set
			{
				_HMILine.LineColor = value;
			}
		}

		public bool Value
		{
			get
			{
				return (_HMILine.Value == null) ? ((object)false) : _HMILine.Value;
			}
			set
			{
				_HMILine.Value = value;
			}
		}

		public string TagName
		{
			get
			{
				return _HMILine.TagName;
			}
			set
			{
				_HMILine.TagName = value;
				_HMILine.Invalidate();
			}
		}

		public HMILineListItem(HMILineDesigner owner)
			: base(owner.Component)
		{
			_HMILine = (HMILine)owner.Component;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			return new DesignerActionItemCollection
			{
				new DesignerActionTextItem("HMI Professional Edition", "HMI Professional Edition"),
				new DesignerActionMethodItem(this, "ShowTagListForm", "Choose Tag"),
				new DesignerActionPropertyItem("HMILineType", "HMILineType"),
				new DesignerActionPropertyItem("LineWidth", "LineWidth"),
				new DesignerActionPropertyItem("LineColor", "LineColor"),
				new DesignerActionPropertyItem("Value", "Value"),
				new DesignerActionPropertyItem("TagName", "TagName")
			};
		}

		private void ShowTagListForm()
		{
            MonitorForm tagCollectionForm = new MonitorForm();
			tagCollectionForm.OnTagSelected_Clicked = (EventTagSelected)Delegate.Combine(tagCollectionForm.OnTagSelected_Clicked, (EventTagSelected)delegate(string tagName)
			{
				SetProperty(_HMILine, "TagName", tagName);
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
