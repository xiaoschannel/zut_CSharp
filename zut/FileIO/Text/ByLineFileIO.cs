using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO.Text
{
  /// <summary>
  /// A simple IO helper class that reads file by lines and use a List of string to store them.
  /// 
  /// </summary>
  public static class ByLineFileIO
  {
    /// <summary>
    /// Write file into current directory.
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="fileName"></param>
    public static void writeFile(List<string> lines, string fileName)
    {
      writeFile(lines, Directory.GetCurrentDirectory(), fileName);
    }
    /// <summary>
    /// Write file into given directory.
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="absolutePath"></param>
    /// <param name="fileName"></param>
    public static void writeFile(List<string> lines, string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamWriter writer = new StreamWriter(fpath, false, Encoding.UTF8))
      {
        for (int i = 0; i < lines.Count; i++)
        {
          writer.WriteLine(lines[i]);
        }
      }
    }
    /// <summary>
    /// Read file from current directory. Verbatim reads with whitespace preserved and empty lines.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<string> readFileVerbatim(string fileName)
    {
      return readFileVerbatim(fileName, Directory.GetCurrentDirectory());
    }
    /// <summary>
    /// Read file from given directory. Verbatim reads with whitespace preserved and empty lines.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="absolutePath"></param>
    /// <returns></returns>
    public static List<string> readFileVerbatim(string fileName, string absolutePath)
    {
      return readFile(fileName, absolutePath, false, false);
    }
    /// <summary>
    /// Read file from current directory. This will ignore leading and trailing whitespace and empty lines.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<string> readFileNoWhitespace(string fileName)
    {
      return readFileNoWhitespace(fileName, Directory.GetCurrentDirectory());
    }
    /// <summary>
    /// Read file from given directory. This will ignore leading and trailing whitespace and empty lines.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="absolutePath"></param>
    /// <returns></returns>
    public static List<string> readFileNoWhitespace(string fileName, string absolutePath)
    {
      return readFile(fileName, absolutePath, true, true);
    }
    /// <summary>
    /// The ugly read file function that give you all features. Other functions are implemented using this one.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="absolutePath"></param>
    /// <param name="ignoreSpace"></param>
    /// <param name="ignoreEmptyLine"></param>
    /// <returns></returns>
    public static List<string> readFile(string fileName, string absolutePath, bool ignoreSpace, bool ignoreEmptyLine)
    {
      List<string> lines = new List<string>();
      string fpath = (fileName.StartsWith(absolutePath)) ? fileName : Path.Combine(absolutePath, fileName);
      using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
      {
        while (true)
        {
          if (reader.Peek() == -1) break;
          string line = reader.ReadLine();
          if (ignoreSpace) line = line.Trim();
          if (ignoreEmptyLine && line.Length == 0) continue;
          lines.Add(line);
        }
      }
      return lines;
    }
  }
}
