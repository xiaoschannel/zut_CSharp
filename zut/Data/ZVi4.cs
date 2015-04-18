using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvi4 
  {

    private int[] data;
    /// <summary>
    /// Create vector with given data.
    /// </summary>
    /// <param name="Data"></param>
    private zvi4(params int[] Data)
    { this.data = Data; }
    public zvi4(int first, int second, int third, int forth)
      : this(new int[] { first, second, third, forth }) { }
    public zvi4(zvi3 vec, int forth)
      : this(vec[0], vec[1], vec[2], forth) { }
    public zvi4(zvi2 vec, int third, int forth)
      : this(vec[0], vec[1], third, forth) { }

    public static implicit operator zvi4(zvi vec)
    {
      if (vec.Length != 4) throw new InvalidCastException("Given vector's length is not 4.");
      return new zvi4(vec[0], vec[1], vec[2], vec[3]);
    }
    public static explicit operator zvi2(zvi4 v)
    { return new zvi2(v[0], v[1]); }
    public static explicit operator zvi3(zvi4 v)
    { return new zvi3(v[0], v[1], v[2]); }
    public static implicit operator zvi(zvi4 vec)
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
    public static zvi4 operator +(zvi4 op1, zvi4 op2)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new zvi4(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi4 operator *(zvi4 op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new zvi4(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi4 operator *(zvi4 op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] * s);
      return new zvi4(data);
    }


    /// <summary>
    /// Arithmatic minus on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvi4 operator -(zvi4 op1, zvi4 op2)
    { return op1 + op2 * -1; }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi4 operator /(zvi4 op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] / s;
      return new zvi4(data);
    }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi4 operator /(zvi4 op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] / s);
      return new zvi4(data);
    }

    /// <summary>
    /// Dot product with that vector.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public zvi4 dot(zvi4 that)
    {
      int[] data = new int[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new zvi4(data);
    }

    /// <summary>
    /// Two vectors are == if they are the same length, and all values are the same.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static bool operator ==(zvi4 op1, zvi4 op2)
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
    public static bool operator !=(zvi4 op1, zvi4 op2)
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
      if (!(this == (zvi4)obj)) return false;
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
    public int w { get { return this[3]; } }

    public int r { get { return this[0]; } }
    public int g { get { return this[1]; } }
    public int b { get { return this[2]; } }
    public int a { get { return this[3]; } }

    public zvi2 xy { get { return new zvi2(x, y); } }
    public zvi2 xz { get { return new zvi2(x, z); } }
    public zvi2 xw { get { return new zvi2(x, w); } }
    public zvi2 yz { get { return new zvi2(y, z); } }
    public zvi2 yw { get { return new zvi2(y, w); } }
    public zvi2 zw { get { return new zvi2(z, w); } }
    public zvi2 yx { get { return new zvi2(y, x); } }
    public zvi2 zx { get { return new zvi2(z, x); } }
    public zvi2 wx { get { return new zvi2(w, x); } }
    public zvi2 zy { get { return new zvi2(z, y); } }
    public zvi2 wy { get { return new zvi2(w, y); } }
    public zvi2 wz { get { return new zvi2(w, z); } }
    public zvi2 xx { get { return new zvi2(x, x); } }
    public zvi2 yy { get { return new zvi2(y, y); } }
    public zvi2 zz { get { return new zvi2(z, z); } }
    public zvi2 ww { get { return new zvi2(w, w); } }

    public zvi2 rg { get { return new zvi2(x, y); } }
    public zvi2 rb { get { return new zvi2(x, z); } }
    public zvi2 ra { get { return new zvi2(x, w); } }
    public zvi2 gb { get { return new zvi2(y, z); } }
    public zvi2 ga { get { return new zvi2(y, w); } }
    public zvi2 ba { get { return new zvi2(z, w); } }
    public zvi2 gr { get { return new zvi2(y, x); } }
    public zvi2 br { get { return new zvi2(z, x); } }
    public zvi2 ar { get { return new zvi2(w, x); } }
    public zvi2 bg { get { return new zvi2(z, y); } }
    public zvi2 ag { get { return new zvi2(w, y); } }
    public zvi2 ab { get { return new zvi2(w, z); } }
    public zvi2 rr { get { return new zvi2(x, x); } }
    public zvi2 gg { get { return new zvi2(y, y); } }
    public zvi2 bb { get { return new zvi2(z, z); } }
    public zvi2 aa { get { return new zvi2(w, w); } }

    public zvi3 xxx { get { return new zvi3(x, x, x); } }
    public zvi3 xxy { get { return new zvi3(x, x, y); } }
    public zvi3 xxz { get { return new zvi3(x, x, z); } }
    public zvi3 xxw { get { return new zvi3(x, x, w); } }
    public zvi3 xyx { get { return new zvi3(x, y, x); } }
    public zvi3 xyy { get { return new zvi3(x, y, y); } }
    public zvi3 xyz { get { return new zvi3(x, y, z); } }
    public zvi3 xyw { get { return new zvi3(x, y, w); } }
    public zvi3 xzx { get { return new zvi3(x, z, x); } }
    public zvi3 xzy { get { return new zvi3(x, z, y); } }
    public zvi3 xzz { get { return new zvi3(x, z, z); } }
    public zvi3 xzw { get { return new zvi3(x, z, w); } }
    public zvi3 xwx { get { return new zvi3(x, w, x); } }
    public zvi3 xwy { get { return new zvi3(x, w, y); } }
    public zvi3 xwz { get { return new zvi3(x, w, z); } }
    public zvi3 xww { get { return new zvi3(x, w, w); } }
    public zvi3 yxx { get { return new zvi3(y, x, x); } }
    public zvi3 yxy { get { return new zvi3(y, x, y); } }
    public zvi3 yxz { get { return new zvi3(y, x, z); } }
    public zvi3 yxw { get { return new zvi3(y, x, w); } }
    public zvi3 yyx { get { return new zvi3(y, y, x); } }
    public zvi3 yyy { get { return new zvi3(y, y, y); } }
    public zvi3 yyz { get { return new zvi3(y, y, z); } }
    public zvi3 yyw { get { return new zvi3(y, y, w); } }
    public zvi3 yzx { get { return new zvi3(y, z, x); } }
    public zvi3 yzy { get { return new zvi3(y, z, y); } }
    public zvi3 yzz { get { return new zvi3(y, z, z); } }
    public zvi3 yzw { get { return new zvi3(y, z, w); } }
    public zvi3 ywx { get { return new zvi3(y, w, x); } }
    public zvi3 ywy { get { return new zvi3(y, w, y); } }
    public zvi3 ywz { get { return new zvi3(y, w, z); } }
    public zvi3 yww { get { return new zvi3(y, w, w); } }
    public zvi3 zxx { get { return new zvi3(z, x, x); } }
    public zvi3 zxy { get { return new zvi3(z, x, y); } }
    public zvi3 zxz { get { return new zvi3(z, x, z); } }
    public zvi3 zxw { get { return new zvi3(z, x, w); } }
    public zvi3 zyx { get { return new zvi3(z, y, x); } }
    public zvi3 zyy { get { return new zvi3(z, y, y); } }
    public zvi3 zyz { get { return new zvi3(z, y, z); } }
    public zvi3 zyw { get { return new zvi3(z, y, w); } }
    public zvi3 zzx { get { return new zvi3(z, z, x); } }
    public zvi3 zzy { get { return new zvi3(z, z, y); } }
    public zvi3 zzz { get { return new zvi3(z, z, z); } }
    public zvi3 zzw { get { return new zvi3(z, z, w); } }
    public zvi3 zwx { get { return new zvi3(z, w, x); } }
    public zvi3 zwy { get { return new zvi3(z, w, y); } }
    public zvi3 zwz { get { return new zvi3(z, w, z); } }
    public zvi3 zww { get { return new zvi3(z, w, w); } }
    public zvi3 wxx { get { return new zvi3(w, x, x); } }
    public zvi3 wxy { get { return new zvi3(w, x, y); } }
    public zvi3 wxz { get { return new zvi3(w, x, z); } }
    public zvi3 wxw { get { return new zvi3(w, x, w); } }
    public zvi3 wyx { get { return new zvi3(w, y, x); } }
    public zvi3 wyy { get { return new zvi3(w, y, y); } }
    public zvi3 wyz { get { return new zvi3(w, y, z); } }
    public zvi3 wyw { get { return new zvi3(w, y, w); } }
    public zvi3 wzx { get { return new zvi3(w, z, x); } }
    public zvi3 wzy { get { return new zvi3(w, z, y); } }
    public zvi3 wzz { get { return new zvi3(w, z, z); } }
    public zvi3 wzw { get { return new zvi3(w, z, w); } }
    public zvi3 wwx { get { return new zvi3(w, w, x); } }
    public zvi3 wwy { get { return new zvi3(w, w, y); } }
    public zvi3 wwz { get { return new zvi3(w, w, z); } }
    public zvi3 www { get { return new zvi3(w, w, w); } }

    public zvi3 rrr { get { return new zvi3(x, x, x); } }
    public zvi3 rrg { get { return new zvi3(x, x, y); } }
    public zvi3 rrb { get { return new zvi3(x, x, z); } }
    public zvi3 rra { get { return new zvi3(x, x, w); } }
    public zvi3 rgr { get { return new zvi3(x, y, x); } }
    public zvi3 rgg { get { return new zvi3(x, y, y); } }
    public zvi3 rgb { get { return new zvi3(x, y, z); } }
    public zvi3 rga { get { return new zvi3(x, y, w); } }
    public zvi3 rbr { get { return new zvi3(x, z, x); } }
    public zvi3 rbg { get { return new zvi3(x, z, y); } }
    public zvi3 rbb { get { return new zvi3(x, z, z); } }
    public zvi3 rba { get { return new zvi3(x, z, w); } }
    public zvi3 rar { get { return new zvi3(x, w, x); } }
    public zvi3 rag { get { return new zvi3(x, w, y); } }
    public zvi3 rab { get { return new zvi3(x, w, z); } }
    public zvi3 raa { get { return new zvi3(x, w, w); } }
    public zvi3 grr { get { return new zvi3(y, x, x); } }
    public zvi3 grg { get { return new zvi3(y, x, y); } }
    public zvi3 grb { get { return new zvi3(y, x, z); } }
    public zvi3 gra { get { return new zvi3(y, x, w); } }
    public zvi3 ggr { get { return new zvi3(y, y, x); } }
    public zvi3 ggg { get { return new zvi3(y, y, y); } }
    public zvi3 ggb { get { return new zvi3(y, y, z); } }
    public zvi3 gga { get { return new zvi3(y, y, w); } }
    public zvi3 gbr { get { return new zvi3(y, z, x); } }
    public zvi3 gbg { get { return new zvi3(y, z, y); } }
    public zvi3 gbb { get { return new zvi3(y, z, z); } }
    public zvi3 gba { get { return new zvi3(y, z, w); } }
    public zvi3 gar { get { return new zvi3(y, w, x); } }
    public zvi3 gag { get { return new zvi3(y, w, y); } }
    public zvi3 gab { get { return new zvi3(y, w, z); } }
    public zvi3 gaa { get { return new zvi3(y, w, w); } }
    public zvi3 brr { get { return new zvi3(z, x, x); } }
    public zvi3 brg { get { return new zvi3(z, x, y); } }
    public zvi3 brb { get { return new zvi3(z, x, z); } }
    public zvi3 bra { get { return new zvi3(z, x, w); } }
    public zvi3 bgr { get { return new zvi3(z, y, x); } }
    public zvi3 bgg { get { return new zvi3(z, y, y); } }
    public zvi3 bgb { get { return new zvi3(z, y, z); } }
    public zvi3 bga { get { return new zvi3(z, y, w); } }
    public zvi3 bbr { get { return new zvi3(z, z, x); } }
    public zvi3 bbg { get { return new zvi3(z, z, y); } }
    public zvi3 bbb { get { return new zvi3(z, z, z); } }
    public zvi3 bba { get { return new zvi3(z, z, w); } }
    public zvi3 bar { get { return new zvi3(z, w, x); } }
    public zvi3 bag { get { return new zvi3(z, w, y); } }
    public zvi3 bab { get { return new zvi3(z, w, z); } }
    public zvi3 baa { get { return new zvi3(z, w, w); } }
    public zvi3 arr { get { return new zvi3(w, x, x); } }
    public zvi3 arg { get { return new zvi3(w, x, y); } }
    public zvi3 arb { get { return new zvi3(w, x, z); } }
    public zvi3 ara { get { return new zvi3(w, x, w); } }
    public zvi3 agr { get { return new zvi3(w, y, x); } }
    public zvi3 agg { get { return new zvi3(w, y, y); } }
    public zvi3 agb { get { return new zvi3(w, y, z); } }
    public zvi3 aga { get { return new zvi3(w, y, w); } }
    public zvi3 abr { get { return new zvi3(w, z, x); } }
    public zvi3 abg { get { return new zvi3(w, z, y); } }
    public zvi3 abb { get { return new zvi3(w, z, z); } }
    public zvi3 aba { get { return new zvi3(w, z, w); } }
    public zvi3 aar { get { return new zvi3(w, w, x); } }
    public zvi3 aag { get { return new zvi3(w, w, y); } }
    public zvi3 aab { get { return new zvi3(w, w, z); } }
    public zvi3 aaa { get { return new zvi3(w, w, w); } }

    public zvi4 xxxx { get { return new zvi4(x, x, x, x); } }
    public zvi4 xxxy { get { return new zvi4(x, x, x, y); } }
    public zvi4 xxxz { get { return new zvi4(x, x, x, z); } }
    public zvi4 xxxw { get { return new zvi4(x, x, x, w); } }
    public zvi4 xxyx { get { return new zvi4(x, x, y, x); } }
    public zvi4 xxyy { get { return new zvi4(x, x, y, y); } }
    public zvi4 xxyz { get { return new zvi4(x, x, y, z); } }
    public zvi4 xxyw { get { return new zvi4(x, x, y, w); } }
    public zvi4 xxzx { get { return new zvi4(x, x, z, x); } }
    public zvi4 xxzy { get { return new zvi4(x, x, z, y); } }
    public zvi4 xxzz { get { return new zvi4(x, x, z, z); } }
    public zvi4 xxzw { get { return new zvi4(x, x, z, w); } }
    public zvi4 xxwx { get { return new zvi4(x, x, w, x); } }
    public zvi4 xxwy { get { return new zvi4(x, x, w, y); } }
    public zvi4 xxwz { get { return new zvi4(x, x, w, z); } }
    public zvi4 xxww { get { return new zvi4(x, x, w, w); } }
    public zvi4 xyxx { get { return new zvi4(x, y, x, x); } }
    public zvi4 xyxy { get { return new zvi4(x, y, x, y); } }
    public zvi4 xyxz { get { return new zvi4(x, y, x, z); } }
    public zvi4 xyxw { get { return new zvi4(x, y, x, w); } }
    public zvi4 xyyx { get { return new zvi4(x, y, y, x); } }
    public zvi4 xyyy { get { return new zvi4(x, y, y, y); } }
    public zvi4 xyyz { get { return new zvi4(x, y, y, z); } }
    public zvi4 xyyw { get { return new zvi4(x, y, y, w); } }
    public zvi4 xyzx { get { return new zvi4(x, y, z, x); } }
    public zvi4 xyzy { get { return new zvi4(x, y, z, y); } }
    public zvi4 xyzz { get { return new zvi4(x, y, z, z); } }
    public zvi4 xyzw { get { return new zvi4(x, y, z, w); } }
    public zvi4 xywx { get { return new zvi4(x, y, w, x); } }
    public zvi4 xywy { get { return new zvi4(x, y, w, y); } }
    public zvi4 xywz { get { return new zvi4(x, y, w, z); } }
    public zvi4 xyww { get { return new zvi4(x, y, w, w); } }
    public zvi4 xzxx { get { return new zvi4(x, z, x, x); } }
    public zvi4 xzxy { get { return new zvi4(x, z, x, y); } }
    public zvi4 xzxz { get { return new zvi4(x, z, x, z); } }
    public zvi4 xzxw { get { return new zvi4(x, z, x, w); } }
    public zvi4 xzyx { get { return new zvi4(x, z, y, x); } }
    public zvi4 xzyy { get { return new zvi4(x, z, y, y); } }
    public zvi4 xzyz { get { return new zvi4(x, z, y, z); } }
    public zvi4 xzyw { get { return new zvi4(x, z, y, w); } }
    public zvi4 xzzx { get { return new zvi4(x, z, z, x); } }
    public zvi4 xzzy { get { return new zvi4(x, z, z, y); } }
    public zvi4 xzzz { get { return new zvi4(x, z, z, z); } }
    public zvi4 xzzw { get { return new zvi4(x, z, z, w); } }
    public zvi4 xzwx { get { return new zvi4(x, z, w, x); } }
    public zvi4 xzwy { get { return new zvi4(x, z, w, y); } }
    public zvi4 xzwz { get { return new zvi4(x, z, w, z); } }
    public zvi4 xzww { get { return new zvi4(x, z, w, w); } }
    public zvi4 xwxx { get { return new zvi4(x, w, x, x); } }
    public zvi4 xwxy { get { return new zvi4(x, w, x, y); } }
    public zvi4 xwxz { get { return new zvi4(x, w, x, z); } }
    public zvi4 xwxw { get { return new zvi4(x, w, x, w); } }
    public zvi4 xwyx { get { return new zvi4(x, w, y, x); } }
    public zvi4 xwyy { get { return new zvi4(x, w, y, y); } }
    public zvi4 xwyz { get { return new zvi4(x, w, y, z); } }
    public zvi4 xwyw { get { return new zvi4(x, w, y, w); } }
    public zvi4 xwzx { get { return new zvi4(x, w, z, x); } }
    public zvi4 xwzy { get { return new zvi4(x, w, z, y); } }
    public zvi4 xwzz { get { return new zvi4(x, w, z, z); } }
    public zvi4 xwzw { get { return new zvi4(x, w, z, w); } }
    public zvi4 xwwx { get { return new zvi4(x, w, w, x); } }
    public zvi4 xwwy { get { return new zvi4(x, w, w, y); } }
    public zvi4 xwwz { get { return new zvi4(x, w, w, z); } }
    public zvi4 xwww { get { return new zvi4(x, w, w, w); } }
    public zvi4 yxxx { get { return new zvi4(y, x, x, x); } }
    public zvi4 yxxy { get { return new zvi4(y, x, x, y); } }
    public zvi4 yxxz { get { return new zvi4(y, x, x, z); } }
    public zvi4 yxxw { get { return new zvi4(y, x, x, w); } }
    public zvi4 yxyx { get { return new zvi4(y, x, y, x); } }
    public zvi4 yxyy { get { return new zvi4(y, x, y, y); } }
    public zvi4 yxyz { get { return new zvi4(y, x, y, z); } }
    public zvi4 yxyw { get { return new zvi4(y, x, y, w); } }
    public zvi4 yxzx { get { return new zvi4(y, x, z, x); } }
    public zvi4 yxzy { get { return new zvi4(y, x, z, y); } }
    public zvi4 yxzz { get { return new zvi4(y, x, z, z); } }
    public zvi4 yxzw { get { return new zvi4(y, x, z, w); } }
    public zvi4 yxwx { get { return new zvi4(y, x, w, x); } }
    public zvi4 yxwy { get { return new zvi4(y, x, w, y); } }
    public zvi4 yxwz { get { return new zvi4(y, x, w, z); } }
    public zvi4 yxww { get { return new zvi4(y, x, w, w); } }
    public zvi4 yyxx { get { return new zvi4(y, y, x, x); } }
    public zvi4 yyxy { get { return new zvi4(y, y, x, y); } }
    public zvi4 yyxz { get { return new zvi4(y, y, x, z); } }
    public zvi4 yyxw { get { return new zvi4(y, y, x, w); } }
    public zvi4 yyyx { get { return new zvi4(y, y, y, x); } }
    public zvi4 yyyy { get { return new zvi4(y, y, y, y); } }
    public zvi4 yyyz { get { return new zvi4(y, y, y, z); } }
    public zvi4 yyyw { get { return new zvi4(y, y, y, w); } }
    public zvi4 yyzx { get { return new zvi4(y, y, z, x); } }
    public zvi4 yyzy { get { return new zvi4(y, y, z, y); } }
    public zvi4 yyzz { get { return new zvi4(y, y, z, z); } }
    public zvi4 yyzw { get { return new zvi4(y, y, z, w); } }
    public zvi4 yywx { get { return new zvi4(y, y, w, x); } }
    public zvi4 yywy { get { return new zvi4(y, y, w, y); } }
    public zvi4 yywz { get { return new zvi4(y, y, w, z); } }
    public zvi4 yyww { get { return new zvi4(y, y, w, w); } }
    public zvi4 yzxx { get { return new zvi4(y, z, x, x); } }
    public zvi4 yzxy { get { return new zvi4(y, z, x, y); } }
    public zvi4 yzxz { get { return new zvi4(y, z, x, z); } }
    public zvi4 yzxw { get { return new zvi4(y, z, x, w); } }
    public zvi4 yzyx { get { return new zvi4(y, z, y, x); } }
    public zvi4 yzyy { get { return new zvi4(y, z, y, y); } }
    public zvi4 yzyz { get { return new zvi4(y, z, y, z); } }
    public zvi4 yzyw { get { return new zvi4(y, z, y, w); } }
    public zvi4 yzzx { get { return new zvi4(y, z, z, x); } }
    public zvi4 yzzy { get { return new zvi4(y, z, z, y); } }
    public zvi4 yzzz { get { return new zvi4(y, z, z, z); } }
    public zvi4 yzzw { get { return new zvi4(y, z, z, w); } }
    public zvi4 yzwx { get { return new zvi4(y, z, w, x); } }
    public zvi4 yzwy { get { return new zvi4(y, z, w, y); } }
    public zvi4 yzwz { get { return new zvi4(y, z, w, z); } }
    public zvi4 yzww { get { return new zvi4(y, z, w, w); } }
    public zvi4 ywxx { get { return new zvi4(y, w, x, x); } }
    public zvi4 ywxy { get { return new zvi4(y, w, x, y); } }
    public zvi4 ywxz { get { return new zvi4(y, w, x, z); } }
    public zvi4 ywxw { get { return new zvi4(y, w, x, w); } }
    public zvi4 ywyx { get { return new zvi4(y, w, y, x); } }
    public zvi4 ywyy { get { return new zvi4(y, w, y, y); } }
    public zvi4 ywyz { get { return new zvi4(y, w, y, z); } }
    public zvi4 ywyw { get { return new zvi4(y, w, y, w); } }
    public zvi4 ywzx { get { return new zvi4(y, w, z, x); } }
    public zvi4 ywzy { get { return new zvi4(y, w, z, y); } }
    public zvi4 ywzz { get { return new zvi4(y, w, z, z); } }
    public zvi4 ywzw { get { return new zvi4(y, w, z, w); } }
    public zvi4 ywwx { get { return new zvi4(y, w, w, x); } }
    public zvi4 ywwy { get { return new zvi4(y, w, w, y); } }
    public zvi4 ywwz { get { return new zvi4(y, w, w, z); } }
    public zvi4 ywww { get { return new zvi4(y, w, w, w); } }
    public zvi4 zxxx { get { return new zvi4(z, x, x, x); } }
    public zvi4 zxxy { get { return new zvi4(z, x, x, y); } }
    public zvi4 zxxz { get { return new zvi4(z, x, x, z); } }
    public zvi4 zxxw { get { return new zvi4(z, x, x, w); } }
    public zvi4 zxyx { get { return new zvi4(z, x, y, x); } }
    public zvi4 zxyy { get { return new zvi4(z, x, y, y); } }
    public zvi4 zxyz { get { return new zvi4(z, x, y, z); } }
    public zvi4 zxyw { get { return new zvi4(z, x, y, w); } }
    public zvi4 zxzx { get { return new zvi4(z, x, z, x); } }
    public zvi4 zxzy { get { return new zvi4(z, x, z, y); } }
    public zvi4 zxzz { get { return new zvi4(z, x, z, z); } }
    public zvi4 zxzw { get { return new zvi4(z, x, z, w); } }
    public zvi4 zxwx { get { return new zvi4(z, x, w, x); } }
    public zvi4 zxwy { get { return new zvi4(z, x, w, y); } }
    public zvi4 zxwz { get { return new zvi4(z, x, w, z); } }
    public zvi4 zxww { get { return new zvi4(z, x, w, w); } }
    public zvi4 zyxx { get { return new zvi4(z, y, x, x); } }
    public zvi4 zyxy { get { return new zvi4(z, y, x, y); } }
    public zvi4 zyxz { get { return new zvi4(z, y, x, z); } }
    public zvi4 zyxw { get { return new zvi4(z, y, x, w); } }
    public zvi4 zyyx { get { return new zvi4(z, y, y, x); } }
    public zvi4 zyyy { get { return new zvi4(z, y, y, y); } }
    public zvi4 zyyz { get { return new zvi4(z, y, y, z); } }
    public zvi4 zyyw { get { return new zvi4(z, y, y, w); } }
    public zvi4 zyzx { get { return new zvi4(z, y, z, x); } }
    public zvi4 zyzy { get { return new zvi4(z, y, z, y); } }
    public zvi4 zyzz { get { return new zvi4(z, y, z, z); } }
    public zvi4 zyzw { get { return new zvi4(z, y, z, w); } }
    public zvi4 zywx { get { return new zvi4(z, y, w, x); } }
    public zvi4 zywy { get { return new zvi4(z, y, w, y); } }
    public zvi4 zywz { get { return new zvi4(z, y, w, z); } }
    public zvi4 zyww { get { return new zvi4(z, y, w, w); } }
    public zvi4 zzxx { get { return new zvi4(z, z, x, x); } }
    public zvi4 zzxy { get { return new zvi4(z, z, x, y); } }
    public zvi4 zzxz { get { return new zvi4(z, z, x, z); } }
    public zvi4 zzxw { get { return new zvi4(z, z, x, w); } }
    public zvi4 zzyx { get { return new zvi4(z, z, y, x); } }
    public zvi4 zzyy { get { return new zvi4(z, z, y, y); } }
    public zvi4 zzyz { get { return new zvi4(z, z, y, z); } }
    public zvi4 zzyw { get { return new zvi4(z, z, y, w); } }
    public zvi4 zzzx { get { return new zvi4(z, z, z, x); } }
    public zvi4 zzzy { get { return new zvi4(z, z, z, y); } }
    public zvi4 zzzz { get { return new zvi4(z, z, z, z); } }
    public zvi4 zzzw { get { return new zvi4(z, z, z, w); } }
    public zvi4 zzwx { get { return new zvi4(z, z, w, x); } }
    public zvi4 zzwy { get { return new zvi4(z, z, w, y); } }
    public zvi4 zzwz { get { return new zvi4(z, z, w, z); } }
    public zvi4 zzww { get { return new zvi4(z, z, w, w); } }
    public zvi4 zwxx { get { return new zvi4(z, w, x, x); } }
    public zvi4 zwxy { get { return new zvi4(z, w, x, y); } }
    public zvi4 zwxz { get { return new zvi4(z, w, x, z); } }
    public zvi4 zwxw { get { return new zvi4(z, w, x, w); } }
    public zvi4 zwyx { get { return new zvi4(z, w, y, x); } }
    public zvi4 zwyy { get { return new zvi4(z, w, y, y); } }
    public zvi4 zwyz { get { return new zvi4(z, w, y, z); } }
    public zvi4 zwyw { get { return new zvi4(z, w, y, w); } }
    public zvi4 zwzx { get { return new zvi4(z, w, z, x); } }
    public zvi4 zwzy { get { return new zvi4(z, w, z, y); } }
    public zvi4 zwzz { get { return new zvi4(z, w, z, z); } }
    public zvi4 zwzw { get { return new zvi4(z, w, z, w); } }
    public zvi4 zwwx { get { return new zvi4(z, w, w, x); } }
    public zvi4 zwwy { get { return new zvi4(z, w, w, y); } }
    public zvi4 zwwz { get { return new zvi4(z, w, w, z); } }
    public zvi4 zwww { get { return new zvi4(z, w, w, w); } }
    public zvi4 wxxx { get { return new zvi4(w, x, x, x); } }
    public zvi4 wxxy { get { return new zvi4(w, x, x, y); } }
    public zvi4 wxxz { get { return new zvi4(w, x, x, z); } }
    public zvi4 wxxw { get { return new zvi4(w, x, x, w); } }
    public zvi4 wxyx { get { return new zvi4(w, x, y, x); } }
    public zvi4 wxyy { get { return new zvi4(w, x, y, y); } }
    public zvi4 wxyz { get { return new zvi4(w, x, y, z); } }
    public zvi4 wxyw { get { return new zvi4(w, x, y, w); } }
    public zvi4 wxzx { get { return new zvi4(w, x, z, x); } }
    public zvi4 wxzy { get { return new zvi4(w, x, z, y); } }
    public zvi4 wxzz { get { return new zvi4(w, x, z, z); } }
    public zvi4 wxzw { get { return new zvi4(w, x, z, w); } }
    public zvi4 wxwx { get { return new zvi4(w, x, w, x); } }
    public zvi4 wxwy { get { return new zvi4(w, x, w, y); } }
    public zvi4 wxwz { get { return new zvi4(w, x, w, z); } }
    public zvi4 wxww { get { return new zvi4(w, x, w, w); } }
    public zvi4 wyxx { get { return new zvi4(w, y, x, x); } }
    public zvi4 wyxy { get { return new zvi4(w, y, x, y); } }
    public zvi4 wyxz { get { return new zvi4(w, y, x, z); } }
    public zvi4 wyxw { get { return new zvi4(w, y, x, w); } }
    public zvi4 wyyx { get { return new zvi4(w, y, y, x); } }
    public zvi4 wyyy { get { return new zvi4(w, y, y, y); } }
    public zvi4 wyyz { get { return new zvi4(w, y, y, z); } }
    public zvi4 wyyw { get { return new zvi4(w, y, y, w); } }
    public zvi4 wyzx { get { return new zvi4(w, y, z, x); } }
    public zvi4 wyzy { get { return new zvi4(w, y, z, y); } }
    public zvi4 wyzz { get { return new zvi4(w, y, z, z); } }
    public zvi4 wyzw { get { return new zvi4(w, y, z, w); } }
    public zvi4 wywx { get { return new zvi4(w, y, w, x); } }
    public zvi4 wywy { get { return new zvi4(w, y, w, y); } }
    public zvi4 wywz { get { return new zvi4(w, y, w, z); } }
    public zvi4 wyww { get { return new zvi4(w, y, w, w); } }
    public zvi4 wzxx { get { return new zvi4(w, z, x, x); } }
    public zvi4 wzxy { get { return new zvi4(w, z, x, y); } }
    public zvi4 wzxz { get { return new zvi4(w, z, x, z); } }
    public zvi4 wzxw { get { return new zvi4(w, z, x, w); } }
    public zvi4 wzyx { get { return new zvi4(w, z, y, x); } }
    public zvi4 wzyy { get { return new zvi4(w, z, y, y); } }
    public zvi4 wzyz { get { return new zvi4(w, z, y, z); } }
    public zvi4 wzyw { get { return new zvi4(w, z, y, w); } }
    public zvi4 wzzx { get { return new zvi4(w, z, z, x); } }
    public zvi4 wzzy { get { return new zvi4(w, z, z, y); } }
    public zvi4 wzzz { get { return new zvi4(w, z, z, z); } }
    public zvi4 wzzw { get { return new zvi4(w, z, z, w); } }
    public zvi4 wzwx { get { return new zvi4(w, z, w, x); } }
    public zvi4 wzwy { get { return new zvi4(w, z, w, y); } }
    public zvi4 wzwz { get { return new zvi4(w, z, w, z); } }
    public zvi4 wzww { get { return new zvi4(w, z, w, w); } }
    public zvi4 wwxx { get { return new zvi4(w, w, x, x); } }
    public zvi4 wwxy { get { return new zvi4(w, w, x, y); } }
    public zvi4 wwxz { get { return new zvi4(w, w, x, z); } }
    public zvi4 wwxw { get { return new zvi4(w, w, x, w); } }
    public zvi4 wwyx { get { return new zvi4(w, w, y, x); } }
    public zvi4 wwyy { get { return new zvi4(w, w, y, y); } }
    public zvi4 wwyz { get { return new zvi4(w, w, y, z); } }
    public zvi4 wwyw { get { return new zvi4(w, w, y, w); } }
    public zvi4 wwzx { get { return new zvi4(w, w, z, x); } }
    public zvi4 wwzy { get { return new zvi4(w, w, z, y); } }
    public zvi4 wwzz { get { return new zvi4(w, w, z, z); } }
    public zvi4 wwzw { get { return new zvi4(w, w, z, w); } }
    public zvi4 wwwx { get { return new zvi4(w, w, w, x); } }
    public zvi4 wwwy { get { return new zvi4(w, w, w, y); } }
    public zvi4 wwwz { get { return new zvi4(w, w, w, z); } }
    public zvi4 wwww { get { return new zvi4(w, w, w, w); } }

    public zvi4 rrrr { get { return new zvi4(x, x, x, x); } }
    public zvi4 rrrg { get { return new zvi4(x, x, x, y); } }
    public zvi4 rrrb { get { return new zvi4(x, x, x, z); } }
    public zvi4 rrra { get { return new zvi4(x, x, x, w); } }
    public zvi4 rrgr { get { return new zvi4(x, x, y, x); } }
    public zvi4 rrgg { get { return new zvi4(x, x, y, y); } }
    public zvi4 rrgb { get { return new zvi4(x, x, y, z); } }
    public zvi4 rrga { get { return new zvi4(x, x, y, w); } }
    public zvi4 rrbr { get { return new zvi4(x, x, z, x); } }
    public zvi4 rrbg { get { return new zvi4(x, x, z, y); } }
    public zvi4 rrbb { get { return new zvi4(x, x, z, z); } }
    public zvi4 rrba { get { return new zvi4(x, x, z, w); } }
    public zvi4 rrar { get { return new zvi4(x, x, w, x); } }
    public zvi4 rrag { get { return new zvi4(x, x, w, y); } }
    public zvi4 rrab { get { return new zvi4(x, x, w, z); } }
    public zvi4 rraa { get { return new zvi4(x, x, w, w); } }
    public zvi4 rgrr { get { return new zvi4(x, y, x, x); } }
    public zvi4 rgrg { get { return new zvi4(x, y, x, y); } }
    public zvi4 rgrb { get { return new zvi4(x, y, x, z); } }
    public zvi4 rgra { get { return new zvi4(x, y, x, w); } }
    public zvi4 rggr { get { return new zvi4(x, y, y, x); } }
    public zvi4 rggg { get { return new zvi4(x, y, y, y); } }
    public zvi4 rggb { get { return new zvi4(x, y, y, z); } }
    public zvi4 rgga { get { return new zvi4(x, y, y, w); } }
    public zvi4 rgbr { get { return new zvi4(x, y, z, x); } }
    public zvi4 rgbg { get { return new zvi4(x, y, z, y); } }
    public zvi4 rgbb { get { return new zvi4(x, y, z, z); } }
    public zvi4 rgba { get { return new zvi4(x, y, z, w); } }
    public zvi4 rgar { get { return new zvi4(x, y, w, x); } }
    public zvi4 rgag { get { return new zvi4(x, y, w, y); } }
    public zvi4 rgab { get { return new zvi4(x, y, w, z); } }
    public zvi4 rgaa { get { return new zvi4(x, y, w, w); } }
    public zvi4 rbrr { get { return new zvi4(x, z, x, x); } }
    public zvi4 rbrg { get { return new zvi4(x, z, x, y); } }
    public zvi4 rbrb { get { return new zvi4(x, z, x, z); } }
    public zvi4 rbra { get { return new zvi4(x, z, x, w); } }
    public zvi4 rbgr { get { return new zvi4(x, z, y, x); } }
    public zvi4 rbgg { get { return new zvi4(x, z, y, y); } }
    public zvi4 rbgb { get { return new zvi4(x, z, y, z); } }
    public zvi4 rbga { get { return new zvi4(x, z, y, w); } }
    public zvi4 rbbr { get { return new zvi4(x, z, z, x); } }
    public zvi4 rbbg { get { return new zvi4(x, z, z, y); } }
    public zvi4 rbbb { get { return new zvi4(x, z, z, z); } }
    public zvi4 rbba { get { return new zvi4(x, z, z, w); } }
    public zvi4 rbar { get { return new zvi4(x, z, w, x); } }
    public zvi4 rbag { get { return new zvi4(x, z, w, y); } }
    public zvi4 rbab { get { return new zvi4(x, z, w, z); } }
    public zvi4 rbaa { get { return new zvi4(x, z, w, w); } }
    public zvi4 rarr { get { return new zvi4(x, w, x, x); } }
    public zvi4 rarg { get { return new zvi4(x, w, x, y); } }
    public zvi4 rarb { get { return new zvi4(x, w, x, z); } }
    public zvi4 rara { get { return new zvi4(x, w, x, w); } }
    public zvi4 ragr { get { return new zvi4(x, w, y, x); } }
    public zvi4 ragg { get { return new zvi4(x, w, y, y); } }
    public zvi4 ragb { get { return new zvi4(x, w, y, z); } }
    public zvi4 raga { get { return new zvi4(x, w, y, w); } }
    public zvi4 rabr { get { return new zvi4(x, w, z, x); } }
    public zvi4 rabg { get { return new zvi4(x, w, z, y); } }
    public zvi4 rabb { get { return new zvi4(x, w, z, z); } }
    public zvi4 raba { get { return new zvi4(x, w, z, w); } }
    public zvi4 raar { get { return new zvi4(x, w, w, x); } }
    public zvi4 raag { get { return new zvi4(x, w, w, y); } }
    public zvi4 raab { get { return new zvi4(x, w, w, z); } }
    public zvi4 raaa { get { return new zvi4(x, w, w, w); } }
    public zvi4 grrr { get { return new zvi4(y, x, x, x); } }
    public zvi4 grrg { get { return new zvi4(y, x, x, y); } }
    public zvi4 grrb { get { return new zvi4(y, x, x, z); } }
    public zvi4 grra { get { return new zvi4(y, x, x, w); } }
    public zvi4 grgr { get { return new zvi4(y, x, y, x); } }
    public zvi4 grgg { get { return new zvi4(y, x, y, y); } }
    public zvi4 grgb { get { return new zvi4(y, x, y, z); } }
    public zvi4 grga { get { return new zvi4(y, x, y, w); } }
    public zvi4 grbr { get { return new zvi4(y, x, z, x); } }
    public zvi4 grbg { get { return new zvi4(y, x, z, y); } }
    public zvi4 grbb { get { return new zvi4(y, x, z, z); } }
    public zvi4 grba { get { return new zvi4(y, x, z, w); } }
    public zvi4 grar { get { return new zvi4(y, x, w, x); } }
    public zvi4 grag { get { return new zvi4(y, x, w, y); } }
    public zvi4 grab { get { return new zvi4(y, x, w, z); } }
    public zvi4 graa { get { return new zvi4(y, x, w, w); } }
    public zvi4 ggrr { get { return new zvi4(y, y, x, x); } }
    public zvi4 ggrg { get { return new zvi4(y, y, x, y); } }
    public zvi4 ggrb { get { return new zvi4(y, y, x, z); } }
    public zvi4 ggra { get { return new zvi4(y, y, x, w); } }
    public zvi4 gggr { get { return new zvi4(y, y, y, x); } }
    public zvi4 gggg { get { return new zvi4(y, y, y, y); } }
    public zvi4 gggb { get { return new zvi4(y, y, y, z); } }
    public zvi4 ggga { get { return new zvi4(y, y, y, w); } }
    public zvi4 ggbr { get { return new zvi4(y, y, z, x); } }
    public zvi4 ggbg { get { return new zvi4(y, y, z, y); } }
    public zvi4 ggbb { get { return new zvi4(y, y, z, z); } }
    public zvi4 ggba { get { return new zvi4(y, y, z, w); } }
    public zvi4 ggar { get { return new zvi4(y, y, w, x); } }
    public zvi4 ggag { get { return new zvi4(y, y, w, y); } }
    public zvi4 ggab { get { return new zvi4(y, y, w, z); } }
    public zvi4 ggaa { get { return new zvi4(y, y, w, w); } }
    public zvi4 gbrr { get { return new zvi4(y, z, x, x); } }
    public zvi4 gbrg { get { return new zvi4(y, z, x, y); } }
    public zvi4 gbrb { get { return new zvi4(y, z, x, z); } }
    public zvi4 gbra { get { return new zvi4(y, z, x, w); } }
    public zvi4 gbgr { get { return new zvi4(y, z, y, x); } }
    public zvi4 gbgg { get { return new zvi4(y, z, y, y); } }
    public zvi4 gbgb { get { return new zvi4(y, z, y, z); } }
    public zvi4 gbga { get { return new zvi4(y, z, y, w); } }
    public zvi4 gbbr { get { return new zvi4(y, z, z, x); } }
    public zvi4 gbbg { get { return new zvi4(y, z, z, y); } }
    public zvi4 gbbb { get { return new zvi4(y, z, z, z); } }
    public zvi4 gbba { get { return new zvi4(y, z, z, w); } }
    public zvi4 gbar { get { return new zvi4(y, z, w, x); } }
    public zvi4 gbag { get { return new zvi4(y, z, w, y); } }
    public zvi4 gbab { get { return new zvi4(y, z, w, z); } }
    public zvi4 gbaa { get { return new zvi4(y, z, w, w); } }
    public zvi4 garr { get { return new zvi4(y, w, x, x); } }
    public zvi4 garg { get { return new zvi4(y, w, x, y); } }
    public zvi4 garb { get { return new zvi4(y, w, x, z); } }
    public zvi4 gara { get { return new zvi4(y, w, x, w); } }
    public zvi4 gagr { get { return new zvi4(y, w, y, x); } }
    public zvi4 gagg { get { return new zvi4(y, w, y, y); } }
    public zvi4 gagb { get { return new zvi4(y, w, y, z); } }
    public zvi4 gaga { get { return new zvi4(y, w, y, w); } }
    public zvi4 gabr { get { return new zvi4(y, w, z, x); } }
    public zvi4 gabg { get { return new zvi4(y, w, z, y); } }
    public zvi4 gabb { get { return new zvi4(y, w, z, z); } }
    public zvi4 gaba { get { return new zvi4(y, w, z, w); } }
    public zvi4 gaar { get { return new zvi4(y, w, w, x); } }
    public zvi4 gaag { get { return new zvi4(y, w, w, y); } }
    public zvi4 gaab { get { return new zvi4(y, w, w, z); } }
    public zvi4 gaaa { get { return new zvi4(y, w, w, w); } }
    public zvi4 brrr { get { return new zvi4(z, x, x, x); } }
    public zvi4 brrg { get { return new zvi4(z, x, x, y); } }
    public zvi4 brrb { get { return new zvi4(z, x, x, z); } }
    public zvi4 brra { get { return new zvi4(z, x, x, w); } }
    public zvi4 brgr { get { return new zvi4(z, x, y, x); } }
    public zvi4 brgg { get { return new zvi4(z, x, y, y); } }
    public zvi4 brgb { get { return new zvi4(z, x, y, z); } }
    public zvi4 brga { get { return new zvi4(z, x, y, w); } }
    public zvi4 brbr { get { return new zvi4(z, x, z, x); } }
    public zvi4 brbg { get { return new zvi4(z, x, z, y); } }
    public zvi4 brbb { get { return new zvi4(z, x, z, z); } }
    public zvi4 brba { get { return new zvi4(z, x, z, w); } }
    public zvi4 brar { get { return new zvi4(z, x, w, x); } }
    public zvi4 brag { get { return new zvi4(z, x, w, y); } }
    public zvi4 brab { get { return new zvi4(z, x, w, z); } }
    public zvi4 braa { get { return new zvi4(z, x, w, w); } }
    public zvi4 bgrr { get { return new zvi4(z, y, x, x); } }
    public zvi4 bgrg { get { return new zvi4(z, y, x, y); } }
    public zvi4 bgrb { get { return new zvi4(z, y, x, z); } }
    public zvi4 bgra { get { return new zvi4(z, y, x, w); } }
    public zvi4 bggr { get { return new zvi4(z, y, y, x); } }
    public zvi4 bggg { get { return new zvi4(z, y, y, y); } }
    public zvi4 bggb { get { return new zvi4(z, y, y, z); } }
    public zvi4 bgga { get { return new zvi4(z, y, y, w); } }
    public zvi4 bgbr { get { return new zvi4(z, y, z, x); } }
    public zvi4 bgbg { get { return new zvi4(z, y, z, y); } }
    public zvi4 bgbb { get { return new zvi4(z, y, z, z); } }
    public zvi4 bgba { get { return new zvi4(z, y, z, w); } }
    public zvi4 bgar { get { return new zvi4(z, y, w, x); } }
    public zvi4 bgag { get { return new zvi4(z, y, w, y); } }
    public zvi4 bgab { get { return new zvi4(z, y, w, z); } }
    public zvi4 bgaa { get { return new zvi4(z, y, w, w); } }
    public zvi4 bbrr { get { return new zvi4(z, z, x, x); } }
    public zvi4 bbrg { get { return new zvi4(z, z, x, y); } }
    public zvi4 bbrb { get { return new zvi4(z, z, x, z); } }
    public zvi4 bbra { get { return new zvi4(z, z, x, w); } }
    public zvi4 bbgr { get { return new zvi4(z, z, y, x); } }
    public zvi4 bbgg { get { return new zvi4(z, z, y, y); } }
    public zvi4 bbgb { get { return new zvi4(z, z, y, z); } }
    public zvi4 bbga { get { return new zvi4(z, z, y, w); } }
    public zvi4 bbbr { get { return new zvi4(z, z, z, x); } }
    public zvi4 bbbg { get { return new zvi4(z, z, z, y); } }
    public zvi4 bbbb { get { return new zvi4(z, z, z, z); } }
    public zvi4 bbba { get { return new zvi4(z, z, z, w); } }
    public zvi4 bbar { get { return new zvi4(z, z, w, x); } }
    public zvi4 bbag { get { return new zvi4(z, z, w, y); } }
    public zvi4 bbab { get { return new zvi4(z, z, w, z); } }
    public zvi4 bbaa { get { return new zvi4(z, z, w, w); } }
    public zvi4 barr { get { return new zvi4(z, w, x, x); } }
    public zvi4 barg { get { return new zvi4(z, w, x, y); } }
    public zvi4 barb { get { return new zvi4(z, w, x, z); } }
    public zvi4 bara { get { return new zvi4(z, w, x, w); } }
    public zvi4 bagr { get { return new zvi4(z, w, y, x); } }
    public zvi4 bagg { get { return new zvi4(z, w, y, y); } }
    public zvi4 bagb { get { return new zvi4(z, w, y, z); } }
    public zvi4 baga { get { return new zvi4(z, w, y, w); } }
    public zvi4 babr { get { return new zvi4(z, w, z, x); } }
    public zvi4 babg { get { return new zvi4(z, w, z, y); } }
    public zvi4 babb { get { return new zvi4(z, w, z, z); } }
    public zvi4 baba { get { return new zvi4(z, w, z, w); } }
    public zvi4 baar { get { return new zvi4(z, w, w, x); } }
    public zvi4 baag { get { return new zvi4(z, w, w, y); } }
    public zvi4 baab { get { return new zvi4(z, w, w, z); } }
    public zvi4 baaa { get { return new zvi4(z, w, w, w); } }
    public zvi4 arrr { get { return new zvi4(w, x, x, x); } }
    public zvi4 arrg { get { return new zvi4(w, x, x, y); } }
    public zvi4 arrb { get { return new zvi4(w, x, x, z); } }
    public zvi4 arra { get { return new zvi4(w, x, x, w); } }
    public zvi4 argr { get { return new zvi4(w, x, y, x); } }
    public zvi4 argg { get { return new zvi4(w, x, y, y); } }
    public zvi4 argb { get { return new zvi4(w, x, y, z); } }
    public zvi4 arga { get { return new zvi4(w, x, y, w); } }
    public zvi4 arbr { get { return new zvi4(w, x, z, x); } }
    public zvi4 arbg { get { return new zvi4(w, x, z, y); } }
    public zvi4 arbb { get { return new zvi4(w, x, z, z); } }
    public zvi4 arba { get { return new zvi4(w, x, z, w); } }
    public zvi4 arar { get { return new zvi4(w, x, w, x); } }
    public zvi4 arag { get { return new zvi4(w, x, w, y); } }
    public zvi4 arab { get { return new zvi4(w, x, w, z); } }
    public zvi4 araa { get { return new zvi4(w, x, w, w); } }
    public zvi4 agrr { get { return new zvi4(w, y, x, x); } }
    public zvi4 agrg { get { return new zvi4(w, y, x, y); } }
    public zvi4 agrb { get { return new zvi4(w, y, x, z); } }
    public zvi4 agra { get { return new zvi4(w, y, x, w); } }
    public zvi4 aggr { get { return new zvi4(w, y, y, x); } }
    public zvi4 aggg { get { return new zvi4(w, y, y, y); } }
    public zvi4 aggb { get { return new zvi4(w, y, y, z); } }
    public zvi4 agga { get { return new zvi4(w, y, y, w); } }
    public zvi4 agbr { get { return new zvi4(w, y, z, x); } }
    public zvi4 agbg { get { return new zvi4(w, y, z, y); } }
    public zvi4 agbb { get { return new zvi4(w, y, z, z); } }
    public zvi4 agba { get { return new zvi4(w, y, z, w); } }
    public zvi4 agar { get { return new zvi4(w, y, w, x); } }
    public zvi4 agag { get { return new zvi4(w, y, w, y); } }
    public zvi4 agab { get { return new zvi4(w, y, w, z); } }
    public zvi4 agaa { get { return new zvi4(w, y, w, w); } }
    public zvi4 abrr { get { return new zvi4(w, z, x, x); } }
    public zvi4 abrg { get { return new zvi4(w, z, x, y); } }
    public zvi4 abrb { get { return new zvi4(w, z, x, z); } }
    public zvi4 abra { get { return new zvi4(w, z, x, w); } }
    public zvi4 abgr { get { return new zvi4(w, z, y, x); } }
    public zvi4 abgg { get { return new zvi4(w, z, y, y); } }
    public zvi4 abgb { get { return new zvi4(w, z, y, z); } }
    public zvi4 abga { get { return new zvi4(w, z, y, w); } }
    public zvi4 abbr { get { return new zvi4(w, z, z, x); } }
    public zvi4 abbg { get { return new zvi4(w, z, z, y); } }
    public zvi4 abbb { get { return new zvi4(w, z, z, z); } }
    public zvi4 abba { get { return new zvi4(w, z, z, w); } }
    public zvi4 abar { get { return new zvi4(w, z, w, x); } }
    public zvi4 abag { get { return new zvi4(w, z, w, y); } }
    public zvi4 abab { get { return new zvi4(w, z, w, z); } }
    public zvi4 abaa { get { return new zvi4(w, z, w, w); } }
    public zvi4 aarr { get { return new zvi4(w, w, x, x); } }
    public zvi4 aarg { get { return new zvi4(w, w, x, y); } }
    public zvi4 aarb { get { return new zvi4(w, w, x, z); } }
    public zvi4 aara { get { return new zvi4(w, w, x, w); } }
    public zvi4 aagr { get { return new zvi4(w, w, y, x); } }
    public zvi4 aagg { get { return new zvi4(w, w, y, y); } }
    public zvi4 aagb { get { return new zvi4(w, w, y, z); } }
    public zvi4 aaga { get { return new zvi4(w, w, y, w); } }
    public zvi4 aabr { get { return new zvi4(w, w, z, x); } }
    public zvi4 aabg { get { return new zvi4(w, w, z, y); } }
    public zvi4 aabb { get { return new zvi4(w, w, z, z); } }
    public zvi4 aaba { get { return new zvi4(w, w, z, w); } }
    public zvi4 aaar { get { return new zvi4(w, w, w, x); } }
    public zvi4 aaag { get { return new zvi4(w, w, w, y); } }
    public zvi4 aaab { get { return new zvi4(w, w, w, z); } }
    public zvi4 aaaa { get { return new zvi4(w, w, w, w); } }
  }
}
