using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace AdvancedScada.HMI.Tools
{
    public static class NumericHelperHMI
    {
        public static bool IsNumeric(object expression)
        {
            if (expression == null)
                return false;

            double testDouble;
            if (expression is string)
            {
                CultureInfo provider;
                if (((string)expression).StartsWith("$"))
                    provider = new CultureInfo("en-US");
                else
                    provider = CultureInfo.InvariantCulture;

                if (double.TryParse((string)expression, NumberStyles.Any, provider, out testDouble))
                    return true;
            }
            else
            {
                if (double.TryParse(expression.ToString(), out testDouble))
                    return true;
            }

            //VB's 'IsNumeric' returns true for any boolean value:
            bool testBool;
            if (bool.TryParse(expression.ToString(), out testBool))
                return true;

            return false;
        }

        public static double Val(string expression)
        {
            if (expression == null)
                return 0;

            //try the entire string, then progressively smaller substrings to replicate the behavior of VB's 'Val', which ignores trailing characters after a recognizable value:
            for (int size = expression.Length; size > 0; size--)
            {
                double testDouble;
                if (double.TryParse(expression.Substring(0, size), out testDouble))
                    return testDouble;
            }

            //no value is recognized, so return 0:
            return 0;
        }

        public static double Val(object expression)
        {
            if (expression == null)
                return 0;

            double testDouble;
            if (double.TryParse(expression.ToString(), out testDouble))
                return testDouble;

            //VB's 'Val' function returns -1 for 'true':
            bool testBool;
            if (bool.TryParse(expression.ToString(), out testBool))
                return testBool ? -1 : 0;

            //VB's 'Val' function returns the day of the month for dates:
            DateTime testDate;
            if (DateTime.TryParse(expression.ToString(), out testDate))
                return testDate.Day;

            //no value is recognized, so return 0:
            return 0;
        }

        public static int Val(char expression)
        {
            int testInt;
            if (int.TryParse(expression.ToString(), out testInt))
                return testInt;
            else
                return 0;
        }
    }
    public class Tools
    {
        public static List<string> ListTankName = new List<string>();
        public static Label[] TankNameSelected = new Label[8];
        public static Label[] TankMixWeightRC = new Label[9];


        private DateTime sdata;
        private DateTime edata;
        private System.TimeSpan datar;
        #region دالة التاخير
        public void Delay(double dblSecs)
        {

            const double OneSec = 1.0D / (1440.0D * 60.0D);
            DateTime dblWaitTil = default(DateTime);
            DateTime.Now.AddSeconds(OneSec);
            dblWaitTil = DateTime.Now.AddSeconds(OneSec).AddSeconds(dblSecs);
            while (!(DateTime.Now > dblWaitTil))
            {
                Application.DoEvents(); // Allow windows messages to be processed
            }

        }

        #endregion
        #region دالة الوردية
        private static string d;
        public static object Work(Label num)
        {
            //دالة تحديد الوردية
            d = Microsoft.VisualBasic.DateAndTime.TimeString;
            if (string.CompareOrdinal((d), "08:00:00") >= 0 && string.CompareOrdinal((d), "15:55:00") < 0)
            {
                num.Text = "1";
            }
            if (string.CompareOrdinal((d), "16:00:00") >= 0 && string.CompareOrdinal((d), "23:55:00") < 0)
            {
                num.Text = "2";
            }
            if (string.CompareOrdinal((d), "23:55:00") >= 0 && string.CompareOrdinal((d), ("11:59:00 PM")) < 0 || string.CompareOrdinal((d), "08:00:00") < 0)
            {
                num.Text = "3";
            }
            return num;
        }
        #endregion
        #region دالة ايام الاسبوع
        public void DeyOfWeek(ref string lbl_dey)
        {
            int Day_Now = Microsoft.VisualBasic.DateAndTime.Weekday(DateTime.Today, Microsoft.VisualBasic.FirstDayOfWeek.Sunday);
            if (Day_Now == 1)
            {
                lbl_dey = "الأحد";
            }
            if (Day_Now == 2)
            {
                lbl_dey = "الاثنين";
            }
            if (Day_Now == 3)
            {
                lbl_dey = "الثلاثاء";
            }
            if (Day_Now == 4)
            {
                lbl_dey = "الأربعاء";
            }
            if (Day_Now == 5)
            {
                lbl_dey = "الخميس";
            }
            if (Day_Now == 6)
            {
                lbl_dey = "الجمعة";
            }
            if (Day_Now == 7)
            {
                lbl_dey = "السبت";
            }


        }
        #endregion
        public void ClcletorTimer(TextBox txt_sdata, TextBox txt_edata, TextBox txt_datar)
        {
            sdata = DateTime.Now;
            txt_sdata.Text = $"{sdata.Hour}:{sdata.Minute}:{sdata.Second}";

            edata = DateTime.Now;
            txt_edata.Text = $"{edata.Hour}:{edata.Minute}:{edata.Second}";
            datar = edata.Subtract(sdata);

            txt_datar.Text = $"{datar.Hours}:{datar.Minutes}:{datar.Seconds}";

        }

        internal delegate void SetLabelTextInvoker(Label label, string Text);
        public void SetLabelText(Label Label, string Text)
        {
            if (Label.InvokeRequired == true)
            {
                Label.Invoke(new SetLabelTextInvoker(SetLabelText), Label, Text);
            }
            else
            {
                Label.Text = Text;
            }
        }

    }
}
