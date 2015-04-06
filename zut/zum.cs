﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility of Math stuff.
  /// </summary>
  public static class zum
  {
    /// <summary>
    /// Lowerbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <returns>The larger of two numbers.</returns>
    public static int LowerBound(int n, int LowerBound) { return Math.Max(n, LowerBound); }
    /// <summary>
    /// Lowerbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <returns>The larger of two numbers.</returns>
    public static long LowerBound(long n, long LowerBound) { return Math.Max(n, LowerBound); }
    /// <summary>
    /// Lowerbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <returns>The larger of two numbers.</returns>
    public static float LowerBound(float n, float LowerBound) { return Math.Max(n, LowerBound); }
    /// <summary>
    /// Lowerbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <returns>The larger of two numbers.</returns>
    public static double LowerBound(double n, double LowerBound) { return Math.Max(n, LowerBound); }
    /// <summary>
    /// Upperbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="UpperBound"></param>
    /// <returns>The smaller of two numbers.</returns>
    public static int UpperBound(int n, int UpperBound) { return Math.Min(n, UpperBound); }
    /// <summary>
    /// Upperbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="UpperBound"></param>
    /// <returns>The smaller of two numbers.</returns>
    public static long UpperBound(long n, long UpperBound) { return Math.Min(n, UpperBound); }
    /// <summary>
    /// Upperbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="UpperBound"></param>
    /// <returns>The smaller of two numbers.</returns>
    public static float UpperBound(float n, float UpperBound) { return Math.Min(n, UpperBound); }
    /// <summary>
    /// Upperbound n.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="UpperBound"></param>
    /// <returns>The smaller of two numbers.</returns>
    public static double UpperBound(double n, double UpperBound) { return Math.Min(n, UpperBound); }
    /// <summary>
    /// Bound n's value between given range.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <param name="UpperBound"></param>
    /// <returns>N or one of the bounds. Inclusive.</returns>
    public static int Bound(int n, int LowerBound, int UpperBound) { return Math.Max(Math.Min(n, UpperBound), LowerBound); }
    /// <summary>
    /// Bound n's value between given range.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <param name="UpperBound"></param>
    /// <returns>N or one of the bounds. Inclusive.</returns>
    public static long Bound(long n, long LowerBound, long UpperBound) { return Math.Max(Math.Min(n, UpperBound), LowerBound); }
    /// <summary>
    /// Bound n's value between given range.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <param name="UpperBound"></param>
    /// <returns>N or one of the bounds. Inclusive.</returns>
    public static float Bound(float n, float LowerBound, float UpperBound) { return Math.Max(Math.Min(n, UpperBound), LowerBound); }
    /// <summary>
    /// Bound n's value between given range.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="LowerBound"></param>
    /// <param name="UpperBound"></param>
    /// <returns>N or one of the bounds. Inclusive.</returns>
    public static double Bound(double n, double LowerBound, double UpperBound) { return Math.Max(Math.Min(n, UpperBound), LowerBound); }

    /// <summary>
    /// Discretizes a function linearly. Example: 
    ///         factor 2
    /// Number: 1 2 3 4 5 6 7 8 9
    /// Result: 0 2 2 4 4 6 6 8 8
    /// </summary>
    /// <param name="n"></param>
    /// <param name="Factor"></param>
    /// <returns>Closest multiple of factor. Rounds down.</returns>
    public static int DiscretizeLinear(int n, int Factor)
    {
      return n - (n % Factor);
    }
    /// <summary>
    /// Discretizes a function logrithmically. Example: 
    ///         base 2
    /// Number: 1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16
    /// Result: 1  2  2  4  4  4  4  8  8  8  8  8  8  8  8 16
    /// </summary>
    /// <param name="n"></param>
    /// <param name="Base"></param>
    /// <returns>Closest integer power of given base. Rounds down.</returns>
    public static int DiscretizeLogrithmic(int n, int Base)
    {
      return (int)(Math.Pow(Base, Math.Floor(Math.Log(n, Base))));
    }
  }
}
