using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// zut class for easy-to-use debug statements and error handling
  /// </summary>
  class zerr
  {
    public static readonly bool DEBUG = true;
    public static readonly bool ERRS = true;

    /// <summary>
    /// print if ERRS is true
    /// </summary>
    /// <param name="message"></param>
    public static void e(string message)
    {
      if (ERRS) Console.WriteLine(message);
    }

    public static void e(string subject, string message)
    {
      e(subject + ": " + message);
    }
    public static void pw(params string[] words)
    {
      foreach (string s in words)
        Console.Write(s + " ");
      Console.WriteLine();
    }
    public static void d(string message)
    {
      if (DEBUG) Console.WriteLine(message);
    }

    public static void d(string subject, string message)
    {
      d(subject + ": " + message);
    }
  }
}
