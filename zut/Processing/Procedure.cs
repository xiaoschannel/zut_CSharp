using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Processing
{
  class Procedure<I,O>
  {
    public Func<I,O> func;
    public Procedure(Func<I, O> func)
    { this.func = func; }
    public Procedure<I, N> then<N>(Procedure<O, N> that)
    { return new Procedure<I,N>((x) => that.Process(this.Process(x))); }
    public O Process(I input)
    { return func.Invoke(input); }
  }
}
