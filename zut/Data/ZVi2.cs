using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
	/// <summary>
	/// This class is exactly the same as ZVi, except it can only be created with two elements.
	/// </summary>
	public class zvi2
	{
		private int[] data;
		/// <summary>
		/// Create vector with given data.
		/// </summary>
		/// <param name="Data"></param>
		private zvi2(params int[] Data)
		{ this.data = Data; }
		public zvi2(int first, int second)
			: this(new int[] { first, second })
		{ }

		public static implicit operator zvi2(zvi vec)
		{
			if (vec.Length != 2) throw new InvalidCastException("Given vector's length is not 2.");
			return new zvi2(vec[0], vec[1]);
		}
		public static implicit operator zvi(zvi2 vec)
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
		public static zvi2 operator +(zvi2 op1, zvi2 op2)
		{
			int[] data = new int[op1.Length];
			for (int i = 0; i < op1.Length; i++)
				data[i] = op1.data[i] + op2.data[i];
			return new zvi2(data);
		}

		/// <summary>
		/// Multiply every value in this vector by a given number.
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static zvi2 operator *(zvi2 op1, int s)
		{
			int[] data = new int[op1.Length];
			for (int i = 0; i < op1.Length; i++)
				data[i] = op1.data[i] * s;
			return new zvi2(data);
		}

		/// <summary>
		/// Multiply every value in this vector by a given number.
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static zvi2 operator *(zvi2 op1, float s)
		{
			int[] data = new int[op1.Length];
			for (int i = 0; i < op1.Length; i++)
				data[i] = (int)(op1.data[i] * s);
			return new zvi2(data);
		}


		/// <summary>
		/// Arithmatic minus on element pairs.
		/// Throws exception if two vectors are not the same length.
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="op2"></param>
		/// <returns></returns>
		public static zvi2 operator -(zvi2 op1, zvi2 op2)
		{ return op1 + op2 * -1; }

		/// <summary>
		/// Divide every value in this vector by a given number. 
		/// Integer division rules apply.
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static zvi2 operator /(zvi2 op1, int s)
		{
			int[] data = new int[op1.Length];
			for (int i = 0; i < op1.Length; i++)
				data[i] = op1.data[i] / s;
			return new zvi2(data);
		}

		/// <summary>
		/// Divide every value in this vector by a given number. 
		/// Integer division rules apply.
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static zvi2 operator /(zvi2 op1, float s)
		{
			int[] data = new int[op1.Length];
			for (int i = 0; i < op1.Length; i++)
				data[i] = (int)(op1.data[i] / s);
			return new zvi2(data);
		}

		/// <summary>
		/// Dot product with that vector.
		/// Throws exception if two vectors are not the same length.
		/// </summary>
		/// <param name="that"></param>
		/// <returns></returns>
		public zvi2 dot(zvi2 that)
		{
			int[] data = new int[this.Length];
			for (int i = 0; i < this.Length; i++)
				data[i] = this.data[i] * that.data[i];
			return new zvi2(data);
		}

		/// <summary>
		/// Apply the given function to all elements of this vector.
		/// Use this overload when same function applied to all elements.
		/// #experimental
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		public zvi2 toAll(Func<int, int> func)
		{
			int[] data = new int[this.Length];
			for (int i = 0; i < this.Length; i++)
				data[i] = func.Invoke(this.data[i]);
			return new zvi2(data);
		}
		/// <summary>
		/// Apply the given function to all elements of this vector
		/// Use this overload when you need to know which element it is.
		/// </summary>
		/// <param name="func"></param>
		/// <returns></returns>
		public zvi2 toAll(Func<int, int, int> func)
		{
			int[] data = new int[this.Length];
			for (int i = 0; i < this.Length; i++)
				data[i] = func.Invoke(i, this.data[i]);
			return new zvi2(data);
		}

		/// <summary>
		/// Since vectors aren't mutable, equal and == are the same.
		/// Implemented according to https://msdn.microsoft.com/en-US/library/ms173147(v=vs.80).aspx
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="op2"></param>
		/// <returns></returns>
		public static bool operator ==(zvi2 op1, zvi2 op2)
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
		public static bool operator !=(zvi2 op1, zvi2 op2)
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
			zvi2 that = obj as zvi2;
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
		public bool Equals(zvi2 obj)
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

		public zvi2 xy { get { return this; } }
		public zvi2 yx { get { return new zvi2(y, x); } }

	}
}
