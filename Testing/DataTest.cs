using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zuoanqh.libzut.Data;

namespace zuoanqh.libzut.Testing
{
	[TestClass]
	public class DataTest
	{
		[TestMethod]
		public void TestZViString()
		{
			zvi2 t = new zvi2(1, 2);
			Assert.AreEqual("[1, 2]", t.ToString());
		}
		[TestMethod]
		public void TestZViEquals()
		{
			zvi2 t = new zvi2(1, 2);
			zvi2 null1 = null, null2 = null;
			Assert.AreEqual(null1, null2);
			Assert.AreNotEqual(t, null1);
			Assert.AreEqual(null1, null);
			Assert.AreNotEqual(t, null);

			Assert.IsTrue(null1 == null2);
			Assert.IsFalse(null1 == t);
			Assert.IsFalse(t == null1);
			Assert.IsTrue(null1 == null);
			Assert.IsFalse(t == null);
			Assert.IsFalse(null == t);
		}

	}
}
