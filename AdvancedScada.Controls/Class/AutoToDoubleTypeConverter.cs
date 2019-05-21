
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
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvancedScada.Controls.Class
{
    public class AutoToDoubleTypeConverter<T> : TypeConverter where T : IConvertible
    {


        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType.GetInterface("IConvertible", false) != null;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType.GetInterface("IConvertible", false) != null;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            object type = null;
            try
            {
                IConvertible convertible = (IConvertible)value;
                if (convertible != null)
                {
                    type = convertible.ToType(typeof(T), culture);
                    return type;
                }
            }
            catch (FormatException formatException)
            {

                if ((value == null || !(value.ToString().Equals("AUTO", StringComparison.CurrentCultureIgnoreCase))) ? true : false)
                {
                    throw;
                }
                else
                {
                    type = double.NaN;

                    return type;
                }
            }
            type = null;
            return type;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object type = null;
            if ((value == null || !double.IsNaN(Conversions.ToDouble(value))) ? true : false)
            {
                type = ((IConvertible)value).ToType(destinationType, culture);
            }
            else
            {
                type = "Auto";
            }
            return type;
        }
    }


}