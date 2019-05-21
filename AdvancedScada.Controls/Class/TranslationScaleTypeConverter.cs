
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
    public class TranslationScaleTypeConverter : TypeConverter
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
            object translationScale = null;
            if (!(value is string))
            {
                translationScale = base.ConvertFrom(context, culture, RuntimeHelpers.GetObjectValue(value));
            }
            else
            {
                string str = Conversions.ToString(value);
                string[] strArrays = str.Split(new char[] { ',' });
                try
                {
                    translationScale = new TranslationScale(Conversions.ToDouble(strArrays[0]), Conversions.ToDouble(strArrays[1]), Conversions.ToDouble(strArrays[2]), Conversions.ToDouble(strArrays[3]));
                }
                catch
                {
                    throw new InvalidCastException(Conversions.ToString(value));
                }
            }
            return translationScale;
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
                TranslationScale translationScale = (TranslationScale)value;
                string[] str = { Conversions.ToString(translationScale.InputMinValue), ",", Conversions.ToString(translationScale.InputMaxValue), ",", Conversions.ToString(translationScale.OutputMinValue), ",", Conversions.ToString(translationScale.OutputMaxValue) };
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