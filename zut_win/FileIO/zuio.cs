using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zuoanqh.libzut.win.FileIO
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
    public static string ToAbsolutePath(string fPath)
    {
      if (Path.IsPathRooted(fPath))//not sure whether this works across platforms...
        return fPath;

      return Path.Combine(Directory.GetCurrentDirectory(), fPath);
    }
    /// <summary>
    /// Use the first kilobyte only.
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under root.</param>
    /// <returns></returns>
    public static Encoding GetEncUde(string fPath)
    {
      return GetEncUde(fPath, 4096);
    }

    /// <summary>
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under root.</param>
    /// <param name="bytesToUse">for full file, use -1.</param>
    /// <returns></returns>
    public static Encoding GetEncUde(string fPath, int bytesToUse)
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
          return Encoding.GetEncoding(cdet.Charset);
        else
          return null;
      }
    }

    /// <summary>
    /// if fails, return given default.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="bytesToUse"></param>
    /// <param name="defaultEncoding"></param>
    /// <returns></returns>
    public static Encoding GetEncUde(string fPath, int bytesToUse, Encoding defaultEncoding)
    {
      return GetEncUde(fPath, bytesToUse, defaultEncoding, false);
    }

    /// <summary>
    /// if fails, retry with all bytes. if still fails, use given default.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="bytesToUse"></param>
    /// <param name="defaultEncoding"></param>
    /// <param name="retry"></param>
    /// <returns></returns>
    public static Encoding GetEncUde(string fPath, int bytesToUse, Encoding defaultEncoding, bool retry)
    {
      var ret = GetEncUde(fPath, bytesToUse);
      if (ret == null && retry)
        ret = GetEncUde(fPath, -1);
      if (ret == null)
        ret = defaultEncoding;
      return ret;
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
    public static string PeekFile(string fPath, Encoding encoding)
    {
      using (StreamReader reader = new StreamReader(File.OpenRead(ToAbsolutePath(fPath)), encoding))
      {
        if (reader.Peek() == -1) return null;
        return reader.ReadLine();
      }
    }
  }
}
