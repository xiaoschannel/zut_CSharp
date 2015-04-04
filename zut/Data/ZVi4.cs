using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Data
{
  public class ZVi4:ZVi
  {
    public ZVi4(int first, int second, int third, int forth)
      : base(first, second, third, forth) { }
    public ZVi4(ZVi3 vec, int forth) 
      : base(vec[0], vec[1], vec[2], forth) { }
    public ZVi3 asVec3()
    { return new ZVi3(this[0], this[1], this[2]); }
  }
}
