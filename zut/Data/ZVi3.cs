using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvi3
  {
    private int[] data;
    /// <summary>
    /// Create vector with given data.
    /// </summary>
    /// <param name="Data"></param>
    private zvi3(params int[] Data)
    { this.data = Data; }
    public zvi3(int first, int second, int third)
      : this(new int[] { first, second, third }) { }
    public zvi3(zvi2 vec, int third)
      : this(vec[0], vec[1], third) { }

    public static implicit operator zvi3(zvi vec)
    {
      if (vec.Length != 3) throw new InvalidCastException("Given vector's length is not 3.");
      return new zvi3(vec[0], vec[1], vec[2]);
    }
    public static explicit operator zvi2(zvi3 v)
    { return new zvi2(v[0], v[1]); }
    public static implicit operator zvi(zvi3 vec)
    { return new zvi(vec.data); }

    /// <summary>
    /// Returns data at given location. Starting at 0.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public int this[int i]
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
    public static zvi3 operator +(zvi3 op1, zvi3 op2)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new zvi3(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi3 operator *(zvi3 op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new zvi3(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi3 operator *(zvi3 op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] * s);
      return new zvi3(data);
    }


    /// <summary>
    /// Arithmatic minus on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvi3 operator -(zvi3 op1, zvi3 op2)
    { return op1 + op2 * -1; }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi3 operator /(zvi3 op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] / s;
      return new zvi3(data);
    }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi3 operator /(zvi3 op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] / s);
      return new zvi3(data);
    }

    /// <summary>
    /// Dot product with that vector.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public zvi3 dot(zvi3 that)
    {
      int[] data = new int[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new zvi3(data);
    }

		/// <summary>
		/// Since vectors aren't mutable, equal and == are the same.
		/// Implemented according to https://msdn.microsoft.com/en-US/library/ms173147(v=vs.80).aspx
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="op2"></param>
		/// <returns></returns>
    public static bool operator ==(zvi3 op1, zvi3 op2)
    {
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(op1, op2))
				return true;

			// If one is null, but not both, return false.
			if (((object)op1 == null) || ((object)op2 == null))
				return false;

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
    public static bool operator !=(zvi3 op1, zvi3 op2)
    {
      return !(op1 == op2);
    }

		/// <summary>
		/// Since vectors aren't mutable, equal and == are the same.
		/// Implemented According to https://msdn.microsoft.com/en-US/library/ms173147(v=vs.80).aspx
		/// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
			if (obj == null) return false;
			zvi3 that = obj as zvi3;
			if ((object)that == null) return false;

			for (int i = 0; i < this.Length; i++)
				if (this[i] != that[i]) return false;

			return true;
    }
		/// <summary>
		/// Type-specific version of Equals(object).
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool Equals(zvi3 obj)
		{
			if ((object)obj == null) return false;

			for (int i = 0; i < this.Length; i++)
				if (this[i] != obj[i]) return false;

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

    public int x { get { return this[0]; } }
    public int y { get { return this[1]; } }
    public int z { get { return this[2]; } }

    public int r { get { return this[0]; } }
    public int g { get { return this[1]; } }
    public int b { get { return this[2]; } }

    public zvi2 xy { get { return new zvi2(x, y); } }
    public zvi2 xz { get { return new zvi2(x, z); } }
    public zvi2 yz { get { return new zvi2(y, z); } }
    public zvi2 yx { get { return new zvi2(y, x); } }
    public zvi2 zx { get { return new zvi2(z, x); } }
    public zvi2 zy { get { return new zvi2(z, y); } }
    public zvi2 xx { get { return new zvi2(x, x); } }
    public zvi2 yy { get { return new zvi2(y, y); } }
    public zvi2 zz { get { return new zvi2(z, z); } }

    public zvi2 rg { get { return new zvi2(x, y); } }
    public zvi2 rb { get { return new zvi2(x, z); } }
    public zvi2 gb { get { return new zvi2(y, z); } }
    public zvi2 gr { get { return new zvi2(y, x); } }
    public zvi2 br { get { return new zvi2(z, x); } }
    public zvi2 bg { get { return new zvi2(z, y); } }
    public zvi2 rr { get { return new zvi2(x, x); } }
    public zvi2 gg { get { return new zvi2(y, y); } }
    public zvi2 bb { get { return new zvi2(z, z); } }

    public zvi3 xxx { get { return new zvi3(x, x, x); } }
    public zvi3 xxy { get { return new zvi3(x, x, y); } }
    public zvi3 xxz { get { return new zvi3(x, x, z); } }
    public zvi3 xyx { get { return new zvi3(x, y, x); } }
    public zvi3 xyy { get { return new zvi3(x, y, y); } }
    public zvi3 xyz { get { return this; } }
    public zvi3 xzx { get { return new zvi3(x, z, x); } }
    public zvi3 xzy { get { return new zvi3(x, z, y); } }
    public zvi3 xzz { get { return new zvi3(x, z, z); } }
    public zvi3 yxx { get { return new zvi3(y, x, x); } }
    public zvi3 yxy { get { return new zvi3(y, x, y); } }
    public zvi3 yxz { get { return new zvi3(y, x, z); } }
    public zvi3 yyx { get { return new zvi3(y, y, x); } }
    public zvi3 yyy { get { return new zvi3(y, y, y); } }
    public zvi3 yyz { get { return new zvi3(y, y, z); } }
    public zvi3 yzx { get { return new zvi3(y, z, x); } }
    public zvi3 yzy { get { return new zvi3(y, z, y); } }
    public zvi3 yzz { get { return new zvi3(y, z, z); } }
    public zvi3 zxx { get { return new zvi3(z, x, x); } }
    public zvi3 zxy { get { return new zvi3(z, x, y); } }
    public zvi3 zxz { get { return new zvi3(z, x, z); } }
    public zvi3 zyx { get { return new zvi3(z, y, x); } }
    public zvi3 zyy { get { return new zvi3(z, y, y); } }
    public zvi3 zyz { get { return new zvi3(z, y, z); } }
    public zvi3 zzx { get { return new zvi3(z, z, x); } }
    public zvi3 zzy { get { return new zvi3(z, z, y); } }
    public zvi3 zzz { get { return new zvi3(z, z, z); } }

    public zvi3 rrr { get { return new zvi3(x, x, x); } }
    public zvi3 rrg { get { return new zvi3(x, x, y); } }
    public zvi3 rrb { get { return new zvi3(x, x, z); } }
    public zvi3 rgr { get { return new zvi3(x, y, x); } }
    public zvi3 rgg { get { return new zvi3(x, y, y); } }
    public zvi3 rgb { get { return this; } }
    public zvi3 rbr { get { return new zvi3(x, z, x); } }
    public zvi3 rbg { get { return new zvi3(x, z, y); } }
    public zvi3 rbb { get { return new zvi3(x, z, z); } }
    public zvi3 grr { get { return new zvi3(y, x, x); } }
    public zvi3 grg { get { return new zvi3(y, x, y); } }
    public zvi3 grb { get { return new zvi3(y, x, z); } }
    public zvi3 ggr { get { return new zvi3(y, y, x); } }
    public zvi3 ggg { get { return new zvi3(y, y, y); } }
    public zvi3 ggb { get { return new zvi3(y, y, z); } }
    public zvi3 gbr { get { return new zvi3(y, z, x); } }
    public zvi3 gbg { get { return new zvi3(y, z, y); } }
    public zvi3 gbb { get { return new zvi3(y, z, z); } }
    public zvi3 brr { get { return new zvi3(z, x, x); } }
    public zvi3 brg { get { return new zvi3(z, x, y); } }
    public zvi3 brb { get { return new zvi3(z, x, z); } }
    public zvi3 bgr { get { return new zvi3(z, y, x); } }
    public zvi3 bgg { get { return new zvi3(z, y, y); } }
    public zvi3 bgb { get { return new zvi3(z, y, z); } }
    public zvi3 bbr { get { return new zvi3(z, z, x); } }
    public zvi3 bbg { get { return new zvi3(z, z, y); } }
    public zvi3 bbb { get { return new zvi3(z, z, z); } }

  }
}
