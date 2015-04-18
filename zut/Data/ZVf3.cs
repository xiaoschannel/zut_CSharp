using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvf3
  {
    private float[] data;
    /// <summary>
    /// Create vector with given data.
    /// </summary>
    /// <param name="Data"></param>
    private zvf3(params float[] Data)
    { this.data = Data; }
    public zvf3(float first, float second, float third)
      : this(new float[] { first, second, third }) { }
    public zvf3(zvf2 vec, float third)
      : this(vec[0], vec[1], third) { }

    public static implicit operator zvf3(zvf vec)
    {
      if (vec.Length != 3) throw new InvalidCastException("Given vector's length is not 3.");
      return new zvf3(vec[0], vec[1], vec[2]);
    }
    public static explicit operator zvf2(zvf3 v)
    { return new zvf2(v[0], v[1]); }
    public static implicit operator zvf(zvf3 vec)
    { return new zvf(vec.data); }

    /// <summary>
    /// Returns data at given location. Starting at 0.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float this[int i]
    { get { return data[i]; } }

    /// <summary>
    /// Length of the vector.
    /// </summary>
    public int Length { get { return this.data.Length; } }

    /// <summary>
    /// Arithmatic add on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvf3 operator +(zvf3 op1, zvf3 op2)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new zvf3(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvf3 operator *(zvf3 op1, float s)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new zvf3(data);
    }

    /// <summary>
    /// Arithmatic minus on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvf3 operator -(zvf3 op1, zvf3 op2)
    { return op1 + op2 * -1; }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// floateger division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvf3 operator /(zvf3 op1, float s)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] / s;
      return new zvf3(data);
    }

    /// <summary>
    /// Dot product with that vector.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public zvf3 dot(zvf3 that)
    {
      float[] data = new float[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new zvf3(data);
    }

    /// <summary>
    /// Two vectors are == if they are the same length, and all values are the same.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static bool operator ==(zvf3 op1, zvf3 op2)
    {
      for (int i = 0; i < op1.Length; i++)
        if (op1[i] != op2[i]) return false;

      return true;
    }

    /// <summary>
    /// Simply the negation of the == operator.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static bool operator !=(zvf3 op1, zvf3 op2)
    {
      return !(op1 == op2);
    }

    /// <summary>
    /// This vector is equal to the other object if:
    /// 1, Base.Equals pass.
    /// 2, They are the same type.
    /// 3, == check pass.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (!base.Equals(obj)) return false;
      if (obj.GetType() != this.GetType()) return false;
      if (!(this == (zvf3)obj)) return false;
      return true;
    }

    /// <summary>
    /// Same as base.GetHashCode to make compiler shut up.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /// <summary>
    /// Return a string in the form of "[n1, n2, ... ]".
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return zusp.List("[]", ", ", data);
    }

    public float x { get { return this[0]; } }
    public float y { get { return this[1]; } }
    public float z { get { return this[2]; } }

    public float r { get { return this[0]; } }
    public float g { get { return this[1]; } }
    public float b { get { return this[2]; } }

    public zvf2 xy { get { return new zvf2(x, y); } }
    public zvf2 xz { get { return new zvf2(x, z); } }
    public zvf2 yz { get { return new zvf2(y, z); } }
    public zvf2 yx { get { return new zvf2(y, x); } }
    public zvf2 zx { get { return new zvf2(z, x); } }
    public zvf2 zy { get { return new zvf2(z, y); } }
    public zvf2 xx { get { return new zvf2(x, x); } }
    public zvf2 yy { get { return new zvf2(y, y); } }
    public zvf2 zz { get { return new zvf2(z, z); } }

    public zvf2 rg { get { return new zvf2(x, y); } }
    public zvf2 rb { get { return new zvf2(x, z); } }
    public zvf2 gb { get { return new zvf2(y, z); } }
    public zvf2 gr { get { return new zvf2(y, x); } }
    public zvf2 br { get { return new zvf2(z, x); } }
    public zvf2 bg { get { return new zvf2(z, y); } }
    public zvf2 rr { get { return new zvf2(x, x); } }
    public zvf2 gg { get { return new zvf2(y, y); } }
    public zvf2 bb { get { return new zvf2(z, z); } }

    public zvf3 xxx { get { return new zvf3(x, x, x); } }
    public zvf3 xxy { get { return new zvf3(x, x, y); } }
    public zvf3 xxz { get { return new zvf3(x, x, z); } }
    public zvf3 xyx { get { return new zvf3(x, y, x); } }
    public zvf3 xyy { get { return new zvf3(x, y, y); } }
    public zvf3 xyz { get { return this; } }
    public zvf3 xzx { get { return new zvf3(x, z, x); } }
    public zvf3 xzy { get { return new zvf3(x, z, y); } }
    public zvf3 xzz { get { return new zvf3(x, z, z); } }
    public zvf3 yxx { get { return new zvf3(y, x, x); } }
    public zvf3 yxy { get { return new zvf3(y, x, y); } }
    public zvf3 yxz { get { return new zvf3(y, x, z); } }
    public zvf3 yyx { get { return new zvf3(y, y, x); } }
    public zvf3 yyy { get { return new zvf3(y, y, y); } }
    public zvf3 yyz { get { return new zvf3(y, y, z); } }
    public zvf3 yzx { get { return new zvf3(y, z, x); } }
    public zvf3 yzy { get { return new zvf3(y, z, y); } }
    public zvf3 yzz { get { return new zvf3(y, z, z); } }
    public zvf3 zxx { get { return new zvf3(z, x, x); } }
    public zvf3 zxy { get { return new zvf3(z, x, y); } }
    public zvf3 zxz { get { return new zvf3(z, x, z); } }
    public zvf3 zyx { get { return new zvf3(z, y, x); } }
    public zvf3 zyy { get { return new zvf3(z, y, y); } }
    public zvf3 zyz { get { return new zvf3(z, y, z); } }
    public zvf3 zzx { get { return new zvf3(z, z, x); } }
    public zvf3 zzy { get { return new zvf3(z, z, y); } }
    public zvf3 zzz { get { return new zvf3(z, z, z); } }

    public zvf3 rrr { get { return new zvf3(x, x, x); } }
    public zvf3 rrg { get { return new zvf3(x, x, y); } }
    public zvf3 rrb { get { return new zvf3(x, x, z); } }
    public zvf3 rgr { get { return new zvf3(x, y, x); } }
    public zvf3 rgg { get { return new zvf3(x, y, y); } }
    public zvf3 rgb { get { return this; } }
    public zvf3 rbr { get { return new zvf3(x, z, x); } }
    public zvf3 rbg { get { return new zvf3(x, z, y); } }
    public zvf3 rbb { get { return new zvf3(x, z, z); } }
    public zvf3 grr { get { return new zvf3(y, x, x); } }
    public zvf3 grg { get { return new zvf3(y, x, y); } }
    public zvf3 grb { get { return new zvf3(y, x, z); } }
    public zvf3 ggr { get { return new zvf3(y, y, x); } }
    public zvf3 ggg { get { return new zvf3(y, y, y); } }
    public zvf3 ggb { get { return new zvf3(y, y, z); } }
    public zvf3 gbr { get { return new zvf3(y, z, x); } }
    public zvf3 gbg { get { return new zvf3(y, z, y); } }
    public zvf3 gbb { get { return new zvf3(y, z, z); } }
    public zvf3 brr { get { return new zvf3(z, x, x); } }
    public zvf3 brg { get { return new zvf3(z, x, y); } }
    public zvf3 brb { get { return new zvf3(z, x, z); } }
    public zvf3 bgr { get { return new zvf3(z, y, x); } }
    public zvf3 bgg { get { return new zvf3(z, y, y); } }
    public zvf3 bgb { get { return new zvf3(z, y, z); } }
    public zvf3 bbr { get { return new zvf3(z, z, x); } }
    public zvf3 bbg { get { return new zvf3(z, z, y); } }
    public zvf3 bbb { get { return new zvf3(z, z, z); } }
  }
}
