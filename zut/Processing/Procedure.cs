using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut.Processing
{
  /// <summary>
  /// Models a procedure that holds a function to process something to another thing. Can be joined to make larger procedure.
  /// </summary>
  /// <typeparam name="I">Input type</typeparam>
  /// <typeparam name="O">Output type</typeparam>
  public class Procedure<I, O>
  {
    /// <summary>
    /// Function contained.
    /// </summary>
    public readonly Func<I, O> func;
    /// <summary>
    /// Create object with given function.
    /// </summary>
    /// <param name="func"></param>
    public Procedure(Func<I, O> func)
    { this.func = func; }
    /// <summary>
    /// Join this procedure with another procedure.
    /// </summary>
    /// <typeparam name="N">New output type</typeparam>
    /// <param name="that">The procedure to join</param>
    /// <returns>A procedure does this then that</returns>
    public Procedure<I, N> then<N>(Procedure<O, N> that)
    { return new Procedure<I, N>((x) => that.Process(this.Process(x))); }
    /// <summary>
    /// A shorthand to invoke the procedure.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public O Process(I input)
    { return func.Invoke(input); }
    /// <summary>
    /// Process a generic collection and return a collection.
    /// </summary>
    /// <param name="input">A collection of input type</param>
    /// <returns></returns>
    public IEnumerable<O> BatchProcess(IEnumerable<I> input)
    {
      foreach(var i in input)
        yield return func.Invoke(i);
    }

  }
}
