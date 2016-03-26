using cn.zuoanqh.open.zut.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// Zuoanqh's Utility for String Processing.
  /// </summary>
  public static class zusp
  {
    /// <summary>
    /// Common regular expressions. Nope I can't find a library that have this. Sad eh? Do tell me if you find one.
    /// </summary>
    public static class RegEx
    {
      /// <summary>
      /// Matches any integer, with or without + or - sign.
      /// </summary>
      public const string INTEGER = @"[+-]?[\d]+";

      /// <summary>
      /// Matches any floating-point number (does not match scientific notation), with or without sign. will match strings without whole number part like ".05".
      /// </summary>
      public const string FLOATING_POINT_NUMBER = @"[+-]?[\d]?.[\d]+";
    }

    /// <summary>
    /// Return first n characters.
    /// </summary>
    /// <param name="s">Target string</param>
    /// <param name="n">Amount of characters</param>
    /// <returns> The leftmost n characters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Left(string s, int n)
    {
      if (s.Length <= n) return s;
      return s.Substring(0, n);
    }
    /// <summary>
    /// Return last n characters.
    /// </summary>
    /// <param name="s">Target string</param>
    /// <param name="n">Amount of characters</param>
    /// <returns> The rightmost n characters of s. If s is not long enough, the entire string is returned.</returns>
    public static string Right(string s, int n)
    {
      if (s.Length <= n) return s;
      return s.Substring(s.Length - n);
    }
    /// <summary>
    /// Remove first n characters. 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The remaining characters. Empty if given string is not long enough.</returns>
    public static string Drop(string s, int n)
    {
      if (s.Length <= n) return "";
      return s.Substring(n);
    }
    /// <summary>
    /// Remove last n characters. 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The remaining characters. Empty if given string is not long enough.</returns>
    public static string DropLast(string s, int n)
    {
      if (s.Length <= n) return "";
      return s.Substring(0, s.Length - n);
    }
    /// <summary>
    /// Chop string into two part. First part have n characters.
    /// The two part are equivalent to Left(s, n) and Drop(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. If given string is not long enough, s then empty string.</returns>
    public static Twin<string> ChopLeft(string s, int n)
    {
      return new Twin<string>(Left(s, n), Drop(s, n));
    }
    /// <summary>
    /// Chop string into two part. Second part have n characters.
    /// The two part are equivalent to DropLast(s, n) and Right(s, n) respectively.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="n"></param>
    /// <returns>The two parts. If given string is not long enough, empty string then s.</returns>
    public static Twin<string> ChopRight(string s, int n)
    {
      return new Twin<string>(DropLast(s, n), Right(s, n));
    }
    /// <summary>
    /// Chop down the part of given string before the first coinsurance of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their original order.</returns>
    public static Twin<string> CutFirst(string s, string Separator)
    {
      int loc = s.IndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain Separator string.");
      return new Twin<string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }
    /// <summary>
    /// Chop down the part of given string before the last occurrence of given separator.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>A pair of strings in their original order, without the separator.</returns>
    public static Twin<string> CutLast(string s, string Separator)
    {
      int loc = s.LastIndexOf(Separator);
      if (loc < 0) throw new ArgumentException("Given string does not contain given Separator.");
      return new Twin<string>(s.Substring(0, loc), s.Substring(loc + Separator.Length));
    }
    /// <summary>
    /// The one overload that i want to use but is missing.
    /// It also filters out empty elements by default. sorry about that.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns>Strings after divided by the separator. Empty strings are filtered out.</returns>
    public static string[] Split(string s, params string[] Separator)
    {
      return s.Split(Separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
    }
    /// <summary>
    /// Yes, I used a weird word on purpose. This method leaves empty elements as-is.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="Separator"></param>
    /// <returns></returns>
    public static string[] SplitAsIs(string s, params string[] Separator)
    {
      return s.Split(Separator, StringSplitOptions.None).ToArray();
    }
    /// <summary>
    /// Reverse what split does.
    /// This is simply an alias of List(string, string[]).
    /// </summary>
    /// <param name="l"></param>
    /// <param name="Separator"></param>
    /// <returns></returns>
    public static string Unsplit(string[] l, string Separator)
    {
      return List(Separator, l);
    }


    /// <summary>
    /// Divide given string equally into two. String must have even number of characters.
    /// </summary>
    /// <param name="s">String to divide.</param>
    /// <returns></returns>
    public static Twin<string> Halve(string s)
    {
      if (s.Length % 2 != 0) throw new ArgumentException("String must have even number of characters.");
      return ChopLeft(s, s.Length / 2);
    }
    /// <summary>
    /// List given items into a string, items separated with given delimiter, enclosed by prepost.
    /// Example: "[]", ", ", 1, 2 will make "[1, 2]".
    /// </summary>
    /// <param name="prepost">A string to be divided and enclose the list</param>
    /// <param name="delim"></param>
    /// <param name="list">Items or array. One array will be flattened. Multiple arrays will not.</param>
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

      s.Append(fl.First);
      if (l.Length > 0)
      {
        s.Append(l[0]);
        for (int i = 1; i < l.Length; i++)
          s.Append(delim).Append(l[i]);
        s.Append(fl.Second);
      }
      return s.ToString();
    }
    /// <summary>
    /// List given items into a string, items separated with given delimiter.
    /// </summary>
    /// <param name="delim"></param>
    /// <param name="list">Items or array. One array will be flattened. Multiple arrays will not.</param>
    /// <returns></returns>
    public static string List(string delim, params object[] list)
    { return List("", delim, list); }
    /// <summary>
    /// List given items into a string, items separated with ", ".
    /// </summary>
    /// <param name="list">Items or array. One array will be flattened. Multiple arrays will not.</param>
    /// <returns></returns>
    public static string List(params object[] list)
    { return List("", ", ", list); }

    /// <summary>
    /// Divide a string into segments of given length. Start from the left.
    /// Example: ("abcde", 2) gives {"ab", "cd", "e"}
    /// </summary>
    /// <param name="s"></param>
    /// <param name="SegmentLength"></param>
    /// <returns></returns>
    public static string[] DivideByLengthLeft(string s, int SegmentLength)
    {
      string[] ans = new string[s.Length / SegmentLength + ((s.Length % SegmentLength == 0) ? 0 : 1)];
      for (int i = 0; i < ans.Length - 1; i++)
        ans[i] = s.Substring(i * SegmentLength, SegmentLength);
      ans[ans.Length - 1] = s.Substring((ans.Length - 1) * SegmentLength);
      return ans;
    }

    /// <summary>
    /// Divide a string into segments of given length. Start from the right.
    /// Example: ("abcde", 2) gives {"a", "bc", "de"}
    /// </summary>
    /// <param name="s"></param>
    /// <param name="SegmentLength"></param>
    /// <returns></returns>
    public static string[] DivideByLengthRight(string s, int SegmentLength)
    {
      string[] ans = new string[s.Length / SegmentLength + ((s.Length % SegmentLength == 0) ? 0 : 1)];
      int t = s.Length % SegmentLength;
      ans[0] = s.Substring(0, (t == 0) ? SegmentLength : t);
      for (int i = 1; i < ans.Length; i++)
        ans[i] = s.Substring((i - 1) * SegmentLength + ((t == 0) ? SegmentLength : t), SegmentLength);
      return ans;
    }

    /// <summary>
    /// Divide the given string in to an array by given lengths.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="lengths"></param>
    /// <returns></returns>
    public static string[] DivideByLengths(string s, params int[] lengths)
    {
      int loc = 0;
      string[] ans = new string[lengths.Length];
      for (int i = 0; i < lengths.Length; i++)
      {
        try
        {
          ans[i] = s.Substring(loc, lengths[i]);
        }
        catch (IndexOutOfRangeException e)
        {
          throw new ArgumentException("Lengths added up to more than the length of entire string, exception: " + e.Message);
        }
        loc += lengths[i];
      }
      return ans;
    }

    /// <summary>
    /// Pick strings of certain length separated by certain length. Yup.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="lengths"></param>
    /// <returns></returns>
    public static string[] Pick(string s, params int[] lengths)
    {
      if (lengths.Length % 2 == 0) throw new ArgumentException("Odd number of lengths required");
      int loc = 0;
      string[] ans = new string[lengths.Length / 2 + 1];
      for (int i = 0; i < lengths.Length - 1; i += 2)
      {
        try
        {
          ans[i / 2] = s.Substring(loc, lengths[i]);
        }
        catch (IndexOutOfRangeException e)
        {
          throw new ArgumentException("Lengths added up to more than the length of entire string, exception: " + e.Message);
        }
        loc += lengths[i];
        loc += lengths[i + 1];
      }
      ans[ans.Length - 1] = s.Substring(loc, lengths[lengths.Length - 1]);
      return ans;
    }

    /// <summary>
    /// Split one list to many lists by a given separator. Separator will not be in the results. This removes empty parts.
    /// </summary>
    /// <param name="l"></param>
    /// <param name="Separator">Regular expression expected.</param>
    /// <returns></returns>
    public static List<List<string>> ListSplit(List<string> l, string Separator)
    {
      List<List<string>> ans = new List<List<string>>();
      List<string> current = new List<string>();

      foreach (string s in l)
      {
        if (Regex.IsMatch(s, Separator))
        {
          if (current.Count != 0)
          {
            ans.Add(current);
            current = new List<string>();
          }
        }
        else
          current.Add(s);
      }
      if (current.Count != 0)
        ans.Add(current);

      return ans;
    }
    /// <summary>
    /// Insert given string between lists. Designed to be the opposite of ListSplit operation.
    /// </summary>
    /// <param name="ls"></param>
    /// <param name="Separator"></param>
    /// <returns></returns>
    public static List<string> ListUnsplit(List<List<string>> ls, string Separator)
    {
      List<string> ans = new List<string>();
      foreach (var l in ls)
      {
        foreach (var s in l)
        {
          ans.Add(s);
        }
        ans.Add(Separator);
      }
      return ans;
    }

    /// <summary>
    /// Convert a DictionaryFileIO style list of string into a dictionary. no multilines, sorry!
    /// </summary>
    /// <param name="l"></param>
    /// <param name="Separator">Exact string expected.</param>
    /// <returns></returns>
    public static Dictionary<string, string> ListToDictionary(List<string> l, string Separator)
    {
      Dictionary<string, string> ans = new Dictionary<string, string>();
      foreach (string s in l)
      {
        var t = zusp.CutFirst(s, Separator);
        ans.Add(t.First, t.Second);
      }
      return ans;
    }
    /// <summary>
    /// get the common prefix of a list of strings.
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static string GetCommonPrefix(List<string> l)
    {
      int currentLength = 0;
      int minlength = l.Min(s => s.Length);

      while (currentLength < minlength)
      {
        bool flag = true;//assume the ith characters are the same
        foreach (string s in l)
          if (s[currentLength] != l[0][currentLength])
          {
            flag = false;
            break;
          }
        if (!flag) break;//sorry for cascade breaking
        currentLength++;
      }
      return l[0].Substring(0, currentLength);
    }

    /// <summary>
    /// get the common postfix of a list of strings.
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static string GetCommonPostfix(List<string> l)
    {
      int currentLength = 0;
      int minlength = l.Min(s => s.Length);

      while (currentLength < minlength)
      {
        bool flag = true;//assume the last ith characters are the same
        foreach (string s in l)
          if (s[s.Length - currentLength - 1] != l[0][l[0].Length - currentLength - 1])//-1 because... BITE ME
          {
            flag = false;
            break;
          }
        if (!flag) break;//sorry for cascade breaking
        currentLength++;
      }
      return zusp.ChopRight(l[0], currentLength).Second;
    }
  }
}
