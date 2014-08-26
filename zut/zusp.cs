using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility for String Processing
  /// </summary>
  public static class zusp
  {
    public static string Left(string s, int Length)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (s.Length <= Length) return s;
      return s.Substring(0, Length);
    }

    public static string Right(string s, int Length)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (s.Length <= Length) return s;
      return s.Substring(s.Length - Length);
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
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Pair<string, string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }
    /// <summary>
    /// Chop down the part of given string before the last occourance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their origional order.</returns>
    public static Pair<string, string> ChopTail(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      int loc = s.LastIndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Pair<string, string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }

    public static string[] Split(string s, string Separator)
    {
      if (s == null) throw new ArgumentNullException("s");
      if (Separator == null) throw new ArgumentNullException("Separator");
      return s.Split(new string[] { Separator }, StringSplitOptions.None).Where(r => r.Trim().Length > 0).Select(r => r).ToArray();
    }
  }
}
