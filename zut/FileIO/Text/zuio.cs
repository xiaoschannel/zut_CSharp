using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO.Text
{
  /// <summary>
  /// Zuoanqh's IO utility class. This is for general helper methods.
  /// </summary>
  public class zuio
  {
    /// <summary>
    /// Checks if given path is rooted; If not, combine it with current directory.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ToAbsolutePath(string path)
    {
      if (!Path.IsPathRooted(path))
        return Path.Combine(Directory.GetCurrentDirectory(), path);
      else
        return path;
    }
    /// <summary>
    /// Use the first kilobyte only.
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under current directory.</param>
    /// <returns></returns>
    public static string GetEncUde(string fPath)
    {
      return GetEncUde(fPath, 1024);
    }
    /// <summary>
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under current directory.</param>
    /// <param name="bytesToUse">for full file, use -1.</param>
    /// <returns></returns>
    public static string GetEncUde(string fPath,int bytesToUse)
    {
      using (FileStream fs = File.OpenRead(ToAbsolutePath(fPath)))
      {
        Ude.CharsetDetector cdet = new Ude.CharsetDetector();

        if (bytesToUse == -1)
        {
          cdet.Feed(fs);
          cdet.DataEnd();
        }
        else
        {
          byte[] b = new byte[bytesToUse];
          int len = fs.Read(b, 0, b.Length);
          cdet.Feed(b, 0, len);
          cdet.DataEnd();
        }
        if (cdet.Charset != null)
          return cdet.Charset;
        else
          return "";//TODO: error handling
      }
    }

    /// <summary>
    /// Return the first line of given file in current directory.
    /// Assumes File is UTF-8.
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under current directory.</param>
    /// <returns></returns>
    public static string PeekFile(string fPath)
    {
      return PeekFile(fPath, Encoding.UTF8);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under current directory.</param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string PeekFile(string fPath,  Encoding encoding)
    {
      using (StreamReader reader = new StreamReader(fPath, encoding))
      {
        if (reader.Peek() == -1) return null;
        return reader.ReadLine();
      }
    }
  }
}
