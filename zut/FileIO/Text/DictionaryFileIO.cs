using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO.Text
{
  /// <summary>
  /// IO helper class for a dictionary file.
  /// A dictionary file is made of entries, each takes one line, have a name in string, and a value in string.
  /// If a line does not have separator, it will be merged into last entry.
  /// </summary>
  public static class DictionaryFileIO
  {
    /// <summary>
    /// Write file into current directory.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="separator"></param>
    /// <param name="fileName"></param>
    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string fileName)
    {
      writeFile(data, separator, Directory.GetCurrentDirectory(), fileName);
    }
    /// <summary>
    /// Write file into given directory.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="separator"></param>
    /// <param name="absolutePath"></param>
    /// <param name="fileName"></param>
    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamWriter writer = new StreamWriter(fpath, false, Encoding.UTF8))
      {
        for (int i = 0; i < data.Count; i++)
        {
          if (data[i].Key.Trim().Length != 0)
            writer.WriteLine(data[i].Key + separator + data[i].Value);
          else
            writer.WriteLine(data[i].Value);
        }
      }
    }
    /// <summary>
    /// Read file from current directory.
    /// </summary>
    /// <param name="separator"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<KeyValuePair<string, string>> readFile(string separator, string fileName)
    {
      return readFile(separator, Directory.GetCurrentDirectory(), fileName);
    }
    /// <summary>
    /// Read file from given directory.
    /// </summary>
    /// <param name="separator"></param>
    /// <param name="absolutePath"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<KeyValuePair<string, string>> readFile(string separator, string absolutePath, string fileName)
    {
      List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
      List<string> lines = ByLineFileIO.readFileVerbatim(fileName, absolutePath);
      int l = 0;//line number
      while (true)
      {
        if (l >= lines.Count) break;
        string s = lines[l];
        int ind = s.IndexOf(separator);

        string tails = "";
        while (l + 1 < lines.Count && lines[l + 1].IndexOf(separator) < 0)
        {
          l++;
          tails += "\r\n" + lines[l];
        }

        data.Add(new KeyValuePair<string, string>(s.Substring(0, ind), s.Substring(ind + separator.Length) + tails));
        l++;
      }
      return data;
    }
    /// <summary>
    /// Return the first line of given file in current directory.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string peekFile(string fileName)
    {
      return peekFile(Directory.GetCurrentDirectory(), fileName);
    }
    /// <summary>
    /// Return the first line of given file in given directory.
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string peekFile(string absolutePath, string fileName)
    {
      string fpath = Path.Combine(absolutePath, fileName);
      using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
      {
        if (reader.Peek() == -1) return null;
        return reader.ReadLine();
      }
    }
  }
}
