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
  /// </summary>
  public static class ByLineFileIO
  {
    /// <summary>
    /// Write file into given directory.
    /// Why would you want to specify an encoding?
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="fPath"></param>
    public static void writeFile(List<string> lines, string fPath)
    {
      using (StreamWriter writer = new StreamWriter(zuio.toAbsolutePath(fPath), false, Encoding.UTF8))
      {
        for (int i = 0; i < lines.Count; i++)
          writer.WriteLine(lines[i]);
      }
    }
    /// <summary>
    /// Read file from given directory. Reads with whitespace preserved and empty lines.
    /// This assume the file is UTF8.
    /// </summary>
    /// <param name="fPath"></param>
    /// <returns></returns>
    public static List<string> readFileVerbatim(string fPath)
    {
      return readFile(fPath, false, false, Encoding.UTF8);
    }
    /// <summary>
    /// Read file from given directory. Reads with whitespace preserved and empty lines.
    /// Uses given encoding. You can use zuio.getEncoding to guess the encoding for most files.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<string> readFileVerbatim(string fPath, Encoding encoding)
    {
      return readFile(fPath, false, false, encoding);
    }
    /// <summary>
    /// Read file from given directory. This will trim all lines and ignore empty lines.
    /// This assume the file is UTF8.
    /// </summary>
    /// <param name="fPath"></param>
    /// <returns></returns>
    public static List<string> readFileNoWhitespace(string fPath)
    {
      return readFile(fPath, true, true, Encoding.UTF8);
    }
    /// <summary>
    /// Read file from given directory. This will trim all lines and ignore empty lines.
    /// Uses given encoding. You can use zuio.getEncoding to guess the encoding for most files.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<string> readFileNoWhitespace(string fPath, Encoding encoding)
    {
      return readFile(fPath, true, true, encoding);
    }
    /// <summary>
    /// The ugly read file function that give you all features. Other functions are implemented using this one.
    /// This assume the file is UTF8.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="ignoreSpace"></param>
    /// <param name="ignoreEmptyLine"></param>
    /// <returns></returns>
    public static List<string> readFile(string fPath, bool ignoreSpace, bool ignoreEmptyLine)
    {
      return readFile(fPath, ignoreSpace, ignoreEmptyLine, Encoding.UTF8);
    }

    /// <summary>
    /// The ugly read file function that give you all features. Other functions are implemented using this one.
    /// Uses given encoding. You can use zuio.getEncoding to guess the encoding for most files.
    /// All other readFile methods uses this as implementation.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="ignoreSpace"></param>
    /// <param name="ignoreEmptyLine"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<string> readFile(string fPath, bool ignoreSpace, bool ignoreEmptyLine, Encoding encoding)
    {
      List<string> lines = new List<string>();
      using (StreamReader reader = new StreamReader(zuio.toAbsolutePath(fPath), encoding))
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
