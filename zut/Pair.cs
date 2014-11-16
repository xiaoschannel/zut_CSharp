using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// A simple, functional pair object for storing ordered elements.
  /// </summary>
  /// <typeparam name="F">Type of the first element.</typeparam>
  /// <typeparam name="S">Type of the second element.</typeparam>
  public class Pair<F, S>
  {
    /// <summary>
    /// The first element.
    /// </summary>
    public readonly F First;
    /// <summary>
    /// The second element.
    /// </summary>
    public readonly S Second;
    /// <summary>
    /// A copy constructor.
    /// </summary>
    /// <param name="First"></param>
    /// <param name="Second"></param>
    public Pair(F First, S Second)
    {
      this.First = First;
      this.Second = Second;
    }
  }

}
