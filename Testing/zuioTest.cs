using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zuoanqh.libzut.Data;
using System.Collections.Generic;
using zuoanqh.libzut.FileIO;
using System.IO;

namespace zuoanqh.libzut.Testing
{
  [TestClass]
  public class zuioTest
  {
    [TestMethod]
    public void TestLogger()
    {
      Logger.Log("Hey world!");
      Logger.Save();
    }

    [TestMethod]
    public void TestUde()
    {
      zuio.GetEncUde("Testing.deps.json");
    }
  }
}
