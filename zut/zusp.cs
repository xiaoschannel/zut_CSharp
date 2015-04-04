using cn.zuoanqh.open.zut.Data;
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
    /// Return first n charecters.
    /// </summary>
    /// <param name="s">Target string</param>
    /// <param name="n">Amount of charecters</param>
    /// <returns> The leftmost n charecters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Left(string s, int n)
    {
      if (s.Length <= n) return s;
      return s.Substring(0, n);
    }
    /// <summary>
    /// Return last n charecters.
    /// </summary>
    /// <param name="s">Target string</param>
    /// <param name="n">Amount of charecters</param>
    /// <returns> The rightmost n charecters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Right(string s, int n)
    {
      if (s.Length <= n) return s;
      return s.Substring(s.Length - n);
    }
    /// <summary>
    /// Remove first n charecters. 
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
    /// Remove last n charecters. 
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
    /// Chop string into two part. First part have n charecters.
    /// The two part are equavilent to Left(s, n) and Drop(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. If given string is not long enough, s then empty string.</returns>
    public static Twin<string> ChopLeft(string s, int n)
    {
      return new Twin<string>(Left(s, n), Drop(s, n));
    }
    /// <summary>
    /// Chop string into two part. Second part have n charecters.
    /// The two part are equavilent to DropLast(s, n) and Right(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. If given string is not long enough, empty string then s.</returns>
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
      int loc = s.LastIndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Twin<string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }
    /// <summary>
    /// The good'ol split method we are so used to in Java.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>Strings after divided by the separator. Empty strings are filtered out.</returns>
    public static string[] Split(string s, string Separator)
    {
      return s.Split(new string[] { Separator }, StringSplitOptions.None).
        Where(r => r.Trim().Length > 0).
        Select(r => r).ToArray();
    }
    /// <summary>
    /// Divide given string equally into two. String must have even number of charecters.
    /// </summary>
    /// <param name="s">String to divide.</param>
    /// <returns></returns>
    public static Twin<string> Halve(string s)
    {
      if (s.Length % 2 != 0) throw new ArgumentException("String must have even number of charecters.");
      return ChopLeft(s, s.Length / 2);
    }
    /// <summary>
    /// List given items into a string, items separated with given delimiter, enclosed by prepost.
    /// Example: "[]", ", ", 1, 2 will make "[1, 2]".
    /// </summary>
    /// <param name="prepost">A string to be divided and enclose the list</param>
    /// <param name="delim"></param>
    /// <param name="list">Items or array</param>
    /// <returns></returns>
    public static string List(string prepost, string delim, params object[] list)
    {
      StringBuilder s = new StringBuilder();
      var fl = Halve(prepost);

      object[] l;
      if (list.Length == 1 && list[0] is Array)//just to allow the user pass an array of primitives.
      { l = ((Array)list[0]).Cast<object>().ToArray<object>(); }
      else
       l = list; 

      s.Append(fl.First).Append(l[0]);
      for (int i = 1; i < l.Length; i++)
        s.Append(delim).Append(l[i]);
      s.Append(fl.Second);

      return s.ToString();
    }
    /// <summary>
    /// List given items into a string, items separated with given delimiter.
    /// </summary>
    /// <param name="delim"></param>
    /// <param name="list">Items or array</param>
    /// <returns></returns>
    public static string List(string delim, params object[] list)
    { return List("", delim, list); }
  }
}
