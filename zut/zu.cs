using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// zut class of general algorithms.
  /// </summary>
  public static class zu
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="before">the list before the change</param>
    /// <param name="after">the list after the change</param>
    /// <returns>a Tuple that first element is what's new, second element is what's deleted.</returns>
    public static Tuple<List<T>, List<T>> ListDiff<T>(List<T> before, List<T> after)
    {
      List<T> added, deleted;
      added = new List<T>(after);//only what we have now can possible be added
      deleted = new List<T>(before);//only what we've had can be deleted

      foreach (T i in after)
      {
        if (before.Contains(i))
        {
          deleted.Remove(i);//subtract the common ones
          added.Remove(i);
        }
      }

      return new Tuple<List<T>, List<T>>(added, deleted);
    }
    /// <summary>
    /// Open the given directory if exists. If not, a debug error message will be printed.
    /// </summary>
    /// <param name="targetDirectory"></param>
    public static void openDirectory(string targetDirectory)
    {
      if (Directory.Exists(targetDirectory))
        Process.Start(targetDirectory);
      else
        zerr.e("zut.openDirectory", "Directory not exist: " + targetDirectory);
    }
    /// <summary>
    /// Logic method. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="one"></param>
    /// <param name="other"></param>
    /// <returns>Other, if one is null. Else one.</returns>
    public static T OtherIfNull<T>(T one, T other)
    {
      return (one == null) ? other : one;
    }

    //public static T NullIfFalse<T>(bool condition, T result)
    //{
    //  return (condition)?result:null;
    //}

  }
}
