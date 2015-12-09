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
    /// Converts data format.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static Dictionary<string, string> toDictionary(List<KeyValuePair<string, string>> data)
    {
      var ans = new Dictionary<string, string>();
      foreach (var i in data)
        ans.Add(i.Key, i.Value);
      return ans;
    }
    /// <summary>
    /// Converts data format.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static List<KeyValuePair<string, string>> toList(Dictionary<string, string> data)
    {
      var ans = new List<KeyValuePair<string, string>>();
      foreach (var i in data)
        ans.Add(new KeyValuePair<string, string>(i.Key, i.Value));
      return ans;
    }

    /// <summary>
    /// Writes data into given file.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="separator"></param>
    /// <param name="fPath"></param>
    public static void writeFile(Dictionary<string, string> data, string separator, string fPath)
    { writeFile(toList(data), separator, fPath); }

    /// <summary>
    /// Writes data into given file.
    /// This is the implementation.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="separator"></param>
    /// <param name="fPath"></param>
    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string fPath)
    {
      using (StreamWriter writer = new StreamWriter(zuio.toAbsolutePath(fPath), false, Encoding.UTF8))
      {
        for (int i = 0; i < data.Count; i++)
        {
          if (data[i].Key.Trim().Length != 0)//do you actually had a key there?
            writer.WriteLine(data[i].Key + separator + data[i].Value);
          else
            writer.WriteLine(data[i].Value);
        }
      }
    }

    /// <summary>
    /// Read file from given directory. Assumes UTF-8 encoding.
    /// </summary>
    /// <param name="separator"></param>
    /// <param name="fPath"></param>
    /// <returns></returns>
    public static List<KeyValuePair<string, string>> readFile(string separator, string fPath)
    { return readFile(separator, fPath, Encoding.UTF8); }

    /// <summary>
    /// Read file from given directory. Uses given encoding.
    /// </summary>
    /// <param name="separator"></param>
    /// <param name="fPath"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static List<KeyValuePair<string, string>> readFile(string separator, string fPath, Encoding encoding)
    {
      List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
      List<string> lines = ByLineFileIO.readFileVerbatim(fPath,encoding);

      int l = 0;//line number
      while (true)
      {//These codes are like, pre zusp.
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
  }
}
