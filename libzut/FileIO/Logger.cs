using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.FileIO
{
  /// <summary>
  /// Provides a simple, stated solution for writing text into a file.
  /// </summary>
  public static class Logger
  {
    /// <summary>
    /// The default folder name for Logger.
    /// </summary>
    public const string FOLDER_NAME = "Logger";
    /// <summary>
    /// The date format used by Logger (for public references).
    /// </summary>
    public const string DATE_FORMAT = "yyyy_MM_dd___HH_mm_ss_fff";

    /// <summary>
    /// Where will Logger save its files.
    /// </summary>
    public static string LogDirectory;

    /// <summary>
    /// The data to be written.
    /// </summary>
    public static List<string> Logs;

    static Logger()
    {
      LogDirectory = Path.Combine(Directory.GetCurrentDirectory(), FOLDER_NAME);
      Logs = new List<string>();
    }
    /// <summary>
    /// Add a line.
    /// </summary>
    /// <param name="Line"></param>
    public static void Log(string Line)
    {
      Logs.Add(Line);
    }

    /// <summary>
    /// Add a line with a time stamp before it.
    /// </summary>
    /// <param name="Line"></param>
    public static void LogTimed(string Line)
    {
      Log(DateTime.Now.ToString(DATE_FORMAT) + "\t" + Line);
    }

    /// <summary>
    /// Save the log with default file name.
    /// </summary>
    public static void Save()
    {
      string fname = "LoggerEntry_" + DateTime.Now.ToString(DATE_FORMAT) + ".txt";
      Save(fname);
    }

    /// <summary>
    /// Save the log with given file name.
    /// Open currently don't work, sorry.
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="Open">Open the file afterwards.</param>
    public static void Save(string FileName)
    {
      string fPath = Path.Combine(LogDirectory, FileName);
      if (!Directory.Exists(LogDirectory))
        Directory.CreateDirectory(LogDirectory);

      ByLineFileIO.WriteFile(Logs, fPath);
      Logs.Clear();
    }

  }
}
