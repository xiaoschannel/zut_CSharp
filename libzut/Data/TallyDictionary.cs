using System;
using System.Collections.Generic;
using System.Text;

namespace zuoanqh.libzut.Data
{
  /// <summary>
  /// For counting how many this thing are there.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class TallyDictionary<T> : Dictionary<T, int>
  {
    public TallyDictionary() : base()
      {}
    /// <summary>
    /// If this key already exists, add 1 to the value. 
    /// Else make new entry with 1.
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
      if (this.ContainsKey(item))
        this[item]++;
      else
        this.Add(item, 1);
    }
  }
}
