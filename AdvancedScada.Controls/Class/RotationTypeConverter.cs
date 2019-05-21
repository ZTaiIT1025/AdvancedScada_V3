
using AdvancedScada;
using AdvancedScada.Controls;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class RotationTypeConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            bool flag = (!(sourceType.Equals(typeof(string)) || sourceType.Equals(typeof(RotationScale))) ? base.CanConvertFrom(context, sourceType) : true);
            return flag;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            bool flag = (!(destinationType.Equals(typeof(string)) || destinationType.Equals(typeof(RotationScale))) ? base.CanConvertTo(context, destinationType) : true);
            return flag;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            object rotationScale = null;
            if (!(value is string))
            {
                rotationScale = base.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value));
            }
            else
            {
                string str = Conversions.ToString(value);
                string[] strArrays = str.Split(new char[] { ',' });
                try
                {
                    rotationScale = new RotationScale(Conversions.ToSingle(strArrays[0]), Conversions.ToSingle(strArrays[1]), Conversions.ToSingle(strArrays[2]), Conversions.ToSingle(strArrays[3]), Conversions.ToInteger(strArrays[4]), Conversions.ToInteger(strArrays[5]));
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    throw new InvalidCastException(Conversions.ToString(value));
                }
            }
            return rotationScale;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object obj = null;
            if (!destinationType.Equals(typeof(string)))
            {
                obj = base.ConvertTo(context, culture, RuntimeHelpers.GetObjectValue(value), destinationType);
            }
            else
            {
                RotationScale rotationScale = (RotationScale)value;
                string[] str = { Conversions.ToString(rotationScale.RotationCCWAngle), ",", Conversions.ToString(rotationScale.RotationCWAngle), ",", Conversions.ToString(rotationScale.RotationMaxValueCCW), ",", Conversions.ToString(rotationScale.RotationMaxValueCW), ",", Conversions.ToString(rotationScale.XPosition), ",", Conversions.ToString(rotationScale.YPosition) };
                obj = string.Concat(str);
            }
            return obj;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] Attribute)
        {
            return TypeDescriptor.GetProperties(RuntimeHelpers.GetObjectValue(value));
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }


}