using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.zuoanqh.open.zut.Data;

namespace cn.zuoanqh.open.zut.unittest
{
  [TestClass]
  public class DataTest
  {
    [TestMethod]
    public void TestZViString()
    {
      ZVi2 t = new ZVi2(1, 2);
      Assert.AreEqual("[1, 2]", t.ToString());
    }
  }
}
