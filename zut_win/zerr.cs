using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.win
{
  /// <summary>
  /// Zuoanqh's utility for ERRor handling.
  /// </summary>
  class zerr
  {
    /// <summary>
    /// Switch variable for d methods. You'll probably want to change this in your Program.cs.
    /// </summary>
    public static bool DEBUG = true;

    /// <summary>
    /// Switch variable for e methods. You'll probably want to change this in your Program.cs.
    /// </summary>
    public static bool ERRS = true;

    /// <summary>
    /// print given message if ERRS is true.
    /// </summary>
    /// <param name="message"></param>
    public static void e(string message)
    {
      if (ERRS) Console.WriteLine(message);
    }

    /// <summary>
    /// print in format of "subject: message" if ERRS is true.
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    public static void e(string subject, string message)
    {
      e(subject + ": " + message);
    }

    /// <summary>
    /// print given message if DEBUG is true.
    /// </summary>
    /// <param name="message"></param>
    public static void d(string message)
    {
      if (DEBUG) Console.WriteLine(message);
    }

    /// <summary>
    /// print in format of "subject: message" if ERRS is true.
    /// </summary>
    /// <param name="subject"></param>
    /// <param name="message"></param>
    public static void d(string subject, string message)
    {
      d(subject + ": " + message);
    }

    /// <summary>
    /// Print given words with spaces in between.
    /// </summary>
    /// <param name="words"></param>
    [Obsolete]
    public static void pw(params string[] words)
    {
      foreach (string s in words)
        Console.Write(s + " ");
      Console.WriteLine();
    }
    /// <summary>
    /// Returns method name.
    /// </summary>
    /// <returns></returns>
    public static string mname()
    {
      return new StackTrace().GetFrame(1).GetMethod().ToString();
    }
  }
}
