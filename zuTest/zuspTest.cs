using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.zuoanqh.open.zut.Data;
//using cn.zuoanqh.open.zut;

namespace cn.zuoanqh.open.zut.unittest
{
  [TestClass]
  public class zuspTest
  {
    [TestMethod]
    public void TestLeft()
    {
      Assert.AreEqual("hello", zusp.Left("hello world", 5));
      Assert.AreEqual("hello", zusp.Left("hello", 10));
    }
    [TestMethod]
    public void TestRight()
    {
      Assert.AreEqual("world", zusp.Right("hello world", 5));
      Assert.AreEqual("hello", zusp.Right("hello", 10));
    }

    [TestMethod]
    public void TestList()
    {
      Assert.AreEqual("[1, 2]", zusp.List("[]", ", ", 1, 2));
      Assert.AreEqual("1, 2", zusp.List(", ", 1, 2));
      Assert.AreEqual("[1, 2]", zusp.List("[]", ", ", new object[]{1,2}));
    }

  }
}
