using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  public class Pair<T, V>
  {
    public readonly T First;
    public readonly V Second;
    public Pair(T First, V Second)
    {
      this.First = First;
      this.Second = Second;
    }
  }
}
