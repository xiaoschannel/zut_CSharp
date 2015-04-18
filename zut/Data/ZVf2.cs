using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class zvf2 : zvf
  {
    public zvf2(float first, float second)
      : base(first, second) { }

    public float x { get { return this[0]; } }
    public float y { get { return this[1]; } }

    public zvf2 xy { get { return this; } }
    public zvf2 yx { get { return new zvf2(y, x); } }
  }
}
