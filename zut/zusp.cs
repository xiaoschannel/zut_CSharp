using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility for String Processing.
  /// </summary>
  public static class zusp
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s">The target string.</param>
    /// <param name="n">The amount of charecters.</param>
    /// <returns> The leftmost n charecters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Left(string s, int n)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (s.Length <= n) return s;
      return s.Substring(0, n);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s">The target string.</param>
    /// <param name="n">The amount of charecters.</param>
    /// <returns> The leftmost n charecters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Right(string s, int n)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (s.Length <= n) return s;
      return s.Substring(s.Length - n);
    }

    /// <summary>
    /// Remove the first n charecters from the given string. 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The remaining charecters. Empty if given string is not long enough.</returns>
    public static string Drop(string s, int n)
    {
      if (s.Length <= n) return "";
      return s.Substring(n);
    }
    /// <summary>
    /// Remove the last n charecters from the given string. 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The remaining charecters. Empty if given string is not long enough.</returns>
    public static string DropLast(string s, int n)
    {
      if (s.Length <= n) return "";
      return s.Substring(0, s.Length - n);
    }

    /// <summary>
    /// Chop the given string into two part, where the first part have n charecters.
    /// The two part are equavilent to Left(s, n) and Drop(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. The entire string then empty string if given string is not long enough.</returns>
    public static Twin<string> ChopLeft(string s, int n)
    {
      return new Twin<string>(Left(s, n), Drop(s, n));
    }
    /// <summary>
    /// Chop the given string into two part, where the first part have n charecters.
    /// The two part are equavilent to DropLast(s, n) and Right(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. Empty string then the entire string if given string is not long enough.</returns>
    public static Twin<string> ChopRight(string s, int n)
    {
      return new Twin<string>(DropLast(s, n), Right(s, n));
    }

    /// <summary>
    /// Chop down the part of given string before the first occourance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their origional order.</returns>
    public static Twin<string> CutFirst(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      int loc = s.IndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain Separator string.");
      return new Twin<string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }

    /// <summary>
    /// Chop down the part of given string before the last occourance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their origional order, without the separator.</returns>
    public static Twin<string> CutLast(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      int loc = s.LastIndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Twin<string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }

    /// <summary>
    /// The good'ol split method we are so used to in Java.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns></returns>
    public static string[] Split(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      return s.Split(new string[] { Separator }, StringSplitOptions.None).Where(r => r.Trim().Length > 0).Select(r => r).ToArray();
    }
  }
}
