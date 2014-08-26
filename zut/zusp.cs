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
      if (s.Length <= Length) return s;
      return s.Substring(0, Length);
    }

    public static string Right(string s, int Length)
    {
      if (s.Length <= Length) return s;
      int start = s.Length - Length;
      return s.Substring(start);
    }
  }
}
