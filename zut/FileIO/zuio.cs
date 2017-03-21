using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.FileIO
{
  /// <summary>
  /// Zuoanqh's IO utility class. This is for general helper methods.
  /// </summary>
  public class zuio
  {
    /// <summary>
    /// Root folder of the application. This is required before using relative paths as fPath.
    /// </summary>
    public static IFolder CURRENT_DIRECTORY
    {
      get
      {
        if (current_directory == null)//just giving a better error message since this did get a bit messy.
          throw new InvalidOperationException("Please set zuio.CURRENT_DIRECTORY to the location you want relative paths refers to before doing whatever's caused this exception.");
        return current_directory;
      }
      set { current_directory = value; }
    }
    private static IFolder current_directory;

    public static void SetCurrentDirectory(string path)
    {
      CURRENT_DIRECTORY = FileSystem.Current.GetFolderFromPathAsync(path).Result;
    }

    public static void SetFileOperationProvider()
    {


    }

    /// <summary>
    /// Checks if given path is rooted; If not, combine it with current directory.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string ToAbsolutePath(string fPath)
    {
      if (Path.IsPathRooted(fPath))//not sure whether this works across platforms...
        return fPath;

      return Path.Combine(CURRENT_DIRECTORY.Path, fPath);
    }
    /// <summary>
    /// Use the first kilobyte only.
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under root.</param>
    /// <returns></returns>
    public static string GetEncUde(string fPath)
    {
      return GetEncUde(fPath, 1024);
    }
    /// <summary>
    /// Use Ude.CharsetDetector to find the encoding of things.
    /// Returns empty string upon errors. (for now, duh)
    /// </summary>
    /// <param name="fPath">If non-absolute path given, assumes relative path under root.</param>
    /// <param name="bytesToUse">for full file, use -1.</param>
    /// <returns></returns>
    public static string GetEncUde(string fPath, int bytesToUse)
    {
      using (Stream fs = PathToStream(ToAbsolutePath(fPath), FileAccess.Read))
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
    public static string PeekFile(string fPath, Encoding encoding)
    {
      using (StreamReader reader = new StreamReader(PathToStream(fPath, FileAccess.Read), encoding))
      {
        if (reader.Peek() == -1) return null;
        return reader.ReadLine();
      }
    }

    /// <summary>
    /// returns null if file does not exist.
    /// </summary>
    /// <param name="fPath"></param>
    /// <param name="Access"></param>
    /// <returns></returns>
    public static Stream PathToStream(string fPath, FileAccess Access)
    {
      var f = FileSystem.Current.GetFileFromPathAsync(fPath).Result;
      if (f == null) return null;
      else return f.OpenAsync(Access).Result;
    }

    public static bool FileExists(string fPath)
    {
      return FileSystem.Current.GetFileFromPathAsync(fPath).Result == null;
    }

    public static bool FolderExists(string fPath)
    {
      return FileSystem.Current.GetFolderFromPathAsync(fPath).Result == null;
    }
  }
}
