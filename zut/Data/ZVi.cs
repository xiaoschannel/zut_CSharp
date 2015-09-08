using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  /// <summary>
  /// Zuoanqh's Vector of ints.
  /// A functional vector that allows arbitary length.
  /// </summary>
  public class zvi
  {
    private int[] data;

    /// <summary>
    /// Create vector with given data.
    /// </summary>
    /// <param name="Data"></param>
    public zvi(params int[] Data)
    { this.data = Data; }

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
    /// Compares two vectors to see if they are the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public bool sameLength(zvi that)
    { return this.Length == that.Length; }

    /// <summary>
    /// Arithmatic add on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvi operator +(zvi op1, zvi op2)
    {
      if (!op1.sameLength(op2)) throw new ArgumentException("Vector not same length");
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] + op2.data[i];
      return new zvi(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi operator *(zvi op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] * s;
      return new zvi(data);
    }

    /// <summary>
    /// Multiply every value in this vector by a given number.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi operator *(zvi op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] * s);
      return new zvi(data);
    }


    /// <summary>
    /// Arithmatic minus on element pairs.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static zvi operator -(zvi op1, zvi op2)
    { return op1 + op2 * -1; }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi operator /(zvi op1, int s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = op1.data[i] / s;
      return new zvi(data);
    }

    /// <summary>
    /// Divide every value in this vector by a given number. 
    /// Integer division rules apply.
    /// </summary>
    /// <param name="op1"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public static zvi operator /(zvi op1, float s)
    {
      int[] data = new int[op1.Length];
      for (int i = 0; i < op1.Length; i++)
        data[i] = (int)(op1.data[i] / s);
      return new zvi(data);
    }

    /// <summary>
    /// Dot product with that vector.
    /// Throws exception if two vectors are not the same length.
    /// </summary>
    /// <param name="that"></param>
    /// <returns></returns>
    public zvi dot(zvi that)
    {
      if (!sameLength(that)) throw new ArgumentException("Vector not same length");
      int[] data = new int[this.Length];
      for (int i = 0; i < this.Length; i++)
        data[i] = this.data[i] * that.data[i];
      return new zvi(data);
    }

		/// <summary>
		/// Since vectors aren't mutable, equal and == are the same.
		/// Implemented according to https://msdn.microsoft.com/en-US/library/ms173147(v=vs.80).aspx
		/// </summary>
    /// <param name="op1"></param>
    /// <param name="op2"></param>
    /// <returns></returns>
    public static bool operator ==(zvi op1, zvi op2)
    {
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(op1, op2))
				return true;

			// If one is null, but not both, return false.
			if (((object)op1 == null) || ((object)op2 == null))
				return false;

      if (!op1.sameLength(op2)) return false;

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
    public static bool operator !=(zvi op1, zvi op2)
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
			zvi that = obj as zvi;
			if ((object)that == null) return false;

			if (!this.sameLength(that)) return false;

			for (int i = 0; i < this.Length; i++)
				if (this[i] != that[i]) return false;

			return true;
    }
		/// <summary>
		/// Type-specific version of Equals(object).
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public bool Equals(zvi obj)
		{
			if ((object)obj == null) return false;
			if (!this.sameLength(obj)) return false;

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
  }
}
