using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cn.zuoanqh.open.zut.unittest
{
  [TestClass]
  public class zumTest
  {
    [TestMethod]
    public void TestDiscretizeLogrithmic()
    {
      Assert.AreEqual(1, zum.DiscretizeLogrithmic(1, 2));
      Assert.AreEqual(2, zum.DiscretizeLogrithmic(2, 2));
      Assert.AreEqual(2, zum.DiscretizeLogrithmic(3, 2));
      Assert.AreEqual(4, zum.DiscretizeLogrithmic(4, 2));
      Assert.AreEqual(4, zum.DiscretizeLogrithmic(5, 2));
      Assert.AreEqual(4, zum.DiscretizeLogrithmic(6, 2));
      Assert.AreEqual(4, zum.DiscretizeLogrithmic(7, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(8, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(9, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(10, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(11, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(12, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(13, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(14, 2));
      Assert.AreEqual(8, zum.DiscretizeLogrithmic(15, 2));
      Assert.AreEqual(16, zum.DiscretizeLogrithmic(16, 2));
      Assert.AreEqual(16, zum.DiscretizeLogrithmic(17, 2));
    }
  }
}
