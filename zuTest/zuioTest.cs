using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.zuoanqh.open.zut.Data;
using System.Collections.Generic;
using cn.zuoanqh.open.zut;
using cn.zuoanqh.open.zut.FileIO.Text;
using System.IO;

namespace cn.zuoanqh.open.zut.unittest
{
  [TestClass]
  public class zuioTest
  {
    [TestMethod]
    public void TestLogger()
    {
      zuio.SetCurrentDirectory(Directory.GetCurrentDirectory());
      Logger.Log("Hey world!");
      Logger.SaveAndOpen();
    }


  }
}
