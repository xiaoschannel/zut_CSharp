using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.zuoanqh.open.zut
{
  /// <summary>
  /// A StopWatch used for timing tasks for optimization.
  /// </summary>
 [Obsolete("there already is a aystem.diagnostics.stopwatch")]
  public class StopWatch
  {
    /// <summary>
    /// The time stopwatch is last clicked.
    /// Time of creation if never clicked.
    /// </summary>
    public DateTime Last;
    /// <summary>
    /// Time to do a click operation itself.
    /// </summary>
    public double offset;
    /// <summary>
    /// Create a stopwatch. Will not calibrate on default.
    /// </summary>
    public StopWatch()
    {
      Last = DateTime.UtcNow;
    }
    /// <summary>
    /// Calibrate the Stopwatch to remove the effect of click operation itself.
    /// </summary>
    public void Calibrate()
    {
      double t = 0;
      for (int i = 0; i < 1000; i++)
      {
        t += Click();
      }
      offset += t / 1000;
    }
    /// <summary>
    /// Return the time elapsed in milliseconds since last clicked.
    /// </summary>
    /// <returns></returns>
    public double Click()
    {
      var now = DateTime.UtcNow;
      double ans = (now - Last).TotalMilliseconds;
      Last = now;
      return ans-offset;
    }
  }
}
