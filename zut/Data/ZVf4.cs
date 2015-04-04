using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class ZVf4 : ZVf
  {
    public ZVf4(float first, float second, float third, float forth)
      : base(first, second, third, forth) { }
    public ZVf4(ZVf3 vec, float forth)
      : base(vec[0], vec[1], vec[2], forth) { }
    public ZVf3 asVec3()
    { return new ZVf3(this[0], this[1], this[2]); }
  }
}
