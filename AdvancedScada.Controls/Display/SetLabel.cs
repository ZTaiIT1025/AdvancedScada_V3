using System;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Display
{
    public static class SetLabel
    {
        public static void SetLabelText(System.Windows.Forms.Button Label, dynamic Text)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new SetbuttonTextInvoker(SetLabelText), Label, Text);
            else
                Label.Text = Convert.ToString(Text);
        }

        public static void SetLabelText(System.Windows.Forms.Label Label, string Text)
        {
            if (Label.InvokeRequired)
                Label.Invoke(new SetLabelTextInvoker(SetLabelText), Label, Text);
            else
                Label.Text = Text;
        }

        public static object DynamicConverter(string value, Type t)
        {
            if (t == typeof(bool))
            {
                var boolValue = false;
                if (bool.TryParse(value, out boolValue)) return boolValue;

                var intValue = 0;
                if (int.TryParse(value, out intValue))
                    return Convert.ChangeType(intValue, t);
                throw new Exception("Invalid Conversion of " + value);
            }

            return Convert.ChangeType(value, t);
        }

        internal delegate void SetbuttonTextInvoker(System.Windows.Forms.Button label, dynamic Text);

        internal delegate void SetLabelTextInvoker(System.Windows.Forms.Label label, string Text);
    }
}