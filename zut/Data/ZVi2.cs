using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  /// <summary>
  /// This class is exactly the same as ZVi, except it can only be created with two elements.
  /// </summary>
  public class zvi2 : zvi
  {
    public zvi2(int first, int second)
      : base(first, second) { }

    public int x { get { return this[0]; } }
    public int y { get { return this[1]; } }

    public zvi2 xy { get { return this; } }
    public zvi2 yx { get { return new zvi2(y, x); } }

  }
}
