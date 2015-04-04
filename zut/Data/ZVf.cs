using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  /// <summary>
  /// Zuoanqh's Vector of floats.
  /// It is sad I have to write the same code for ZVf and ZVi with minor differences.
  /// </summary>
  public class ZVf
  {
    private float[] data;

    public ZVf(params float[] Data)
    { this.data = Data; }

    public float this[int i]
    { get { return data[i]; } }

    /// <summary>
    /// Length of the vector.
    /// </summary>
    public int Length { get { return this.data.Length; } }

    public bool sameLength(ZVf that)
    { return this.Length == that.Length; }

    public static ZVf operator +(ZVf op1, ZVf op2)
    {
      if (!op1.sameLength(op2)) throw new ArgumentException("Vector not same length");
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new ZVf(data);
    }

    public static ZVf operator *(ZVf op1, float s)
    {
      float[] data = new float[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new ZVf(data);
    }

    public static ZVf operator -(ZVf op1, ZVf op2)
    { return op1 + op2 * -1; }

    public static ZVf operator /(ZVf op1, float s)
    {
      return op1 * (1 / s);
    }

    public ZVf dot(ZVf that)
    {
      if (!sameLength(that)) throw new ArgumentException("Vector not same length");
      float[] data = new float[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new ZVf(data);
    }
    /// <summary>
    /// Return a string in the form of "[n1, n2, ... ]".
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return zusp.List("[]", ", ", data);
    }
  }
}
