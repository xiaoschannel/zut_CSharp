using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public static void WriteFile(List<string> lines, string fPath)
    {
      WriteFile(lines, fPath, Encoding.UTF8);
    }
    /// <summary>
    /// Also, FUCK SHIFT-JIS
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    public static void WriteFile(List<string> lines, string fPath, Encoding encoding)
    {
      using (StreamWriter writer = new StreamWriter(zuio.PathToStream(fPath, FileAccess.ReadAndWrite), encoding))
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
    public static List<string> ReadFileVerbatim(string fPath)
    {
      return ReadFile(fPath, false, false, Encoding.UTF8);
    }
    /// <summary>
    /// Read file from given directory. Reads with whitespace preserved and empty lines.
    /// Uses given encoding. You can use zuio.getEncoding to guess the encoding for most files.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<string> ReadFileVerbatim(string fPath, Encoding encoding)
    {
      return ReadFile(fPath, false, false, encoding);
    }
    /// <summary>
    /// Read file from given directory. This will trim all lines and ignore empty lines.
    /// This assume the file is UTF8.
    /// </summary>
    /// <param name="fPath"></param>
    /// <returns></returns>
    public static List<string> ReadFileNoWhitespace(string fPath)
    {
      return ReadFile(fPath, true, true, Encoding.UTF8);
    }
    /// <summary>
    /// Read file from given directory. This will trim all lines and ignore empty lines.
    /// Uses given encoding. You can use zuio.getEncoding to guess the encoding for most files.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<string> ReadFileNoWhitespace(string fPath, Encoding encoding)
    {
      return ReadFile(fPath, true, true, encoding);
    }
    /// <summary>
    /// The ugly read file function that give you all features. Other functions are implemented using this one.
    /// This assume the file is UTF8.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="ignoreSpace"></param>
    /// <param name="ignoreEmptyLine"></param>
    /// <returns></returns>
    public static List<string> ReadFile(string fPath, bool ignoreSpace, bool ignoreEmptyLine)
    {
      return ReadFile(fPath, ignoreSpace, ignoreEmptyLine, Encoding.UTF8);
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
    public static List<string> ReadFile(string fPath, bool ignoreSpace, bool ignoreEmptyLine, Encoding encoding)
    {
      List<string> ans = new List<string>();
      using (StreamReader reader = new StreamReader(zuio.PathToStream(fPath, FileAccess.ReadAndWrite), encoding))
      {
        if (reader.Peek() == -1) return ans;

        string text = reader.ReadToEnd();
        foreach (string s in Regex.Split(text, "\r\n|\r|\n"))
        {
          string line = s;
          if (ignoreSpace) line = line.Trim();
          if (ignoreEmptyLine && line.Length == 0) continue;

          ans.Add(line);
        }
      }

      return ans;
    }
  }
}
