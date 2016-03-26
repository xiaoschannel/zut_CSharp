using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  /// <summary>
  /// For when you want to use it like an array but it's not an array.
  /// </summary>
  public class VirtualArray<T> : IEnumerable<T>
  {
    private Func<int, T> get;
    private Action<int, T> set;
    private Func<int> length;
    /// <summary>
    /// Feed me functions!!!
    /// </summary>
    /// <param name="Get">This should return a value at given index.</param>
    /// <param name="Set"></param>
    /// <param name="Length"></param>
    public VirtualArray(Func<int, T> Get, Action<int, T> Set, Func<int> Length)
    {
      this.get = Get;
      this.set = Set;
    }

    /// <summary>
    /// This works just like an array, but operation is redirected to somewhere else.
    /// </summary>
    /// <param name="Index"></param>
    /// <returns></returns>
    public T this[int Index]
    {
      get { return get(Index); }
      set { set(Index, value); }
    }

    /// <summary>
    /// returns how many elements are underlying this array.
    /// </summary>
    /// <returns></returns>
    public int Length { get { return length.Invoke(); } }

    /// <summary>
    /// Enumerate the array.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
      for (int i = 0; i < Length; i++)
        yield return this[i];
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
