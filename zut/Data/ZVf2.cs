using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvf2 
  {
    private float[] data;
    /// <summary>
    /// Create vector with given data.
    /// </summary>
    /// <param name="Data"></param>
    private zvf2(params float[] Data)
    { this.data = Data; }
    public zvf2(float first, float second)
      : this(new float[] { first, second })
    { }

    public static implicit operator zvf2(zvf vec)
    {
      if (vec.Length != 2) throw new InvalidCastException("Given vector's length is not 2.");
      return new zvf2(vec[0], vec[1]);
    }
    public static implicit operator zvf(zvf2 vec)
    {return new zvf(vec.data);}

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
    public static zvf2 operator +(zvf2 op1, zvf2 op2)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new zvf2(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvf2 operator *(zvf2 op1, float s)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new zvf2(data);
    }

    /// <summary>
    /// Arithmatic minus on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvf2 operator -(zvf2 op1, zvf2 op2)
    { return op1 + op2 * -1; }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// floateger division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvf2 operator /(zvf2 op1, float s)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] / s;
      return new zvf2(data);
    }

    /// <summary>
    /// Dot product with that vector.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public zvf2 dot(zvf2 that)
    {
      float[] data = new float[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new zvf2(data);
    }

    /// <summary>
    /// Two vectors are == if they are the same length, and all values are the same.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static bool operator ==(zvf2 op1, zvf2 op2)
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
    public static bool operator !=(zvf2 op1, zvf2 op2)
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
      if (!(this == (zvf2)obj)) return false;
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

    public zvf2 xy { get { return this; } }
    public zvf2 yx { get { return new zvf2(y, x); } }
  }
}
