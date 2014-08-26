using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// zut class of general algorithms.
  /// </summary>
  public static class zut
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

    
  }
}
