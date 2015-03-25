using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO.Text
{
  class DictionaryFileIO
  {
    public static void writeFile(List<KeyValuePair<string, string>> data, string separator, string fileName)
    {
      writeFile(data, separator, Directory.GetCurrentDirectory(), fileName);
    }

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

    public static List<KeyValuePair<string, string>> readFile(string separator, string fileName)
    {
      return readFile(separator, Directory.GetCurrentDirectory(), fileName);
    }

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

    public static string peekFile(string fileName)
    {
      return peekFile(Directory.GetCurrentDirectory(), fileName);
    }

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
