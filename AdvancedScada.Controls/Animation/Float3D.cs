using System;
using System.Drawing;

namespace AdvancedScada.Controls.Animation
{
    public class Float3D : IConvertible, IEquatable<Float3D>, IEquatable<Color>
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Float3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Float3D()
          : this(0.0f, 0.0f, 0.0f)
        {
        }

        public static implicit operator Color(Float3D float3D)
        {
            return Color.FromArgb((int)float3D.X, (int)float3D.Y, (int)float3D.Z);
        }

        public static bool operator ==(Float3D left, Float3D right)
        {
            if (left == null || right == null)
            {
                if (left == null)
                    return right == null;
                return false;
            }
            if (left == right)
                return true;
            if ((double)left.X == (double)right.X && (double)left.Y == (double)right.Y)
                return (double)left.Z == (double)right.Z;
            return false;
        }

        public static bool operator !=(Float3D left, Float3D right)
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
            if (conversionType == typeof(Color))
                return (object)(Color)this;
            throw new InvalidCastException();
        }

        public bool Equals(Color other)
        {
            return (Color)this == other;
        }

        public bool Equals(Float3D other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == (obj as Float3D))
                return true;
            if (obj.GetType() == typeof(Color))
                return (Color)this == (Color)obj;
            if (obj.GetType() == this.GetType())
                return this.Equals((Float3D)obj);
            return false;
        }

        public override int GetHashCode()
        {
            float num1 = this.X;
            int num2 = num1.GetHashCode() * 397;
            num1 = this.Y;
            int hashCode1 = num1.GetHashCode();
            int num3 = (num2 ^ hashCode1) * 397;
            num1 = this.Z;
            int hashCode2 = num1.GetHashCode();
            return num3 ^ hashCode2;
        }

        public override string ToString()
        {
            return "(" + this.X.ToString("0.00") + "," + this.Y.ToString("0.00") + "," + this.Z.ToString("0.00") + ")";
        }

        public static Float3D FromColor(Color color)
        {
            return new Float3D((float)color.R, (float)color.G, (float)color.B);
        }
    }
}
