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
    /// Chop down the part of given string before the first occourance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their origional order.</returns>
    public static Pair<string, string> ChopHead(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      int loc = s.IndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain Separator string.");
      return new Pair<string, string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }

    /// <summary>
    /// Chop down the part of given string before the last occourance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their origional order, without the separator.</returns>
    public static Pair<string, string> ChopTail(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      int loc = s.LastIndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Pair<string, string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
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
