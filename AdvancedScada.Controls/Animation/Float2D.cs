using System;
using System.Drawing;

namespace AdvancedScada.Controls.Animation
{
    public class Float2D : IConvertible, IEquatable<Float2D>, IEquatable<Point>, IEquatable<PointF>, IEquatable<Size>, IEquatable<SizeF>
    {
        public float X { get; set; }

        public float Y { get; set; }

        public Float2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Float2D()
          : this(0.0f, 0.0f)
        {
        }

        public static implicit operator Size(Float2D float2D)
        {
            return new Size((int)float2D.X, (int)float2D.Y);
        }

        public static implicit operator Point(Float2D float2D)
        {
            return new Point((int)float2D.X, (int)float2D.Y);
        }

        public static implicit operator SizeF(Float2D float2D)
        {
            return new SizeF(float2D.X, float2D.Y);
        }

        public static implicit operator PointF(Float2D float2D)
        {
            return new PointF(float2D.X, float2D.Y);
        }

        public static bool operator ==(Float2D left, Float2D right)
        {
            if (left == null || right == null)
            {
                if (left == null)
                    return right == null;
                return false;
            }
            if (left == right)
                return true;
            if ((double)left.X == (double)right.X)
                return (double)left.Y == (double)right.Y;
            return false;
        }

        public static bool operator !=(Float2D left, Float2D right)
        {
            return !(left == right);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public Decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(Point))
                return (object)(Point)this;
            if (conversionType == typeof(Size))
                return (object)(Size)this;
            if (conversionType == typeof(PointF))
                return (object)(PointF)this;
            if (conversionType == typeof(SizeF))
                return (object)(SizeF)this;
            throw new InvalidCastException();
        }

        public bool Equals(Float2D other)
        {
            return this == other;
        }

        public bool Equals(Point other)
        {
            return (Point)this == other;
        }

        public bool Equals(PointF other)
        {
            return (PointF)this == other;
        }

        public bool Equals(Size other)
        {
            return (Size)this == other;
        }

        public bool Equals(SizeF other)
        {
            return (SizeF)this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == (obj as Float2D))
                return true;
            Type type = obj.GetType();
            if (type == typeof(Point))
                return (Point)this == (Point)obj;
            if (type == typeof(PointF))
                return (PointF)this == (PointF)obj;
            if (type == typeof(Size))
                return (Size)this == (Size)obj;
            if (type == typeof(SizeF))
                return (SizeF)this == (SizeF)obj;
            if (obj.GetType() == this.GetType())
                return this.Equals((Float2D)obj);
            return false;
        }

        public override int GetHashCode()
        {
            float num1 = this.X;
            int num2 = num1.GetHashCode() * 397;
            num1 = this.Y;
            int hashCode = num1.GetHashCode();
            return num2 ^ hashCode;
        }

        public override string ToString()
        {
            return "(" + this.X.ToString("0.00") + "," + this.Y.ToString("0.00") + ")";
        }

        public static Float2D FromPoint(Point point)
        {
            return new Float2D((float)point.X, (float)point.Y);
        }

        public static Float2D FromPoint(PointF point)
        {
            return new Float2D(point.X, point.Y);
        }

        public static Float2D FromSize(Size size)
        {
            return new Float2D((float)size.Width, (float)size.Height);
        }

        public static Float2D FromSize(SizeF size)
        {
            return new Float2D(size.Width, size.Height);
        }
    }
}
