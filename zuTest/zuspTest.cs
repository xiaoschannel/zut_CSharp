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
			Assert.AreEqual("[1, 2]", zusp.List("[]", ", ", new object[] { 1, 2 }));
		}

		[TestMethod]
		public void TestDivideByLength()
		{
			//perfectly divisible string length
			string[] ans = zusp.DivideByLengthLeft("abcdef", 2);
			Assert.AreEqual(3, ans.Length);
			Assert.AreEqual("ab", ans[0]);
			Assert.AreEqual("cd", ans[1]);
			Assert.AreEqual("ef", ans[2]);
			ans = zusp.DivideByLengthRight("abcdef", 2);
			Assert.AreEqual(3, ans.Length);
			Assert.AreEqual("ab", ans[0]);
			Assert.AreEqual("cd", ans[1]);
			Assert.AreEqual("ef", ans[2]);

			//not perfectly divisible
			ans = zusp.DivideByLengthLeft("abcde", 2);
			Assert.AreEqual(3, ans.Length);
			Assert.AreEqual("ab", ans[0]);
			Assert.AreEqual("cd", ans[1]);
			Assert.AreEqual("e", ans[2]);
			ans = zusp.DivideByLengthRight("abcde", 2);
			Assert.AreEqual(3, ans.Length);
			Assert.AreEqual("a", ans[0]);
			Assert.AreEqual("bc", ans[1]);
			Assert.AreEqual("de", ans[2]);

			//segment length > string length
			ans = zusp.DivideByLengthLeft("ab", 5);
			Assert.AreEqual(1, ans.Length);
			Assert.AreEqual("ab", ans[0]);
			ans = zusp.DivideByLengthRight("ab", 5);
			Assert.AreEqual(1, ans.Length);
			Assert.AreEqual("ab", ans[0]);
		}
		[TestMethod]
		public void TestHalve()
		{
			var ans = zusp.Halve("1234");
			Assert.AreEqual("12", ans.First);
			Assert.AreEqual("34", ans.Second);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void TestHalveOddnumberException()
		{
			var ans = zusp.Halve("12343");
		}

		[TestMethod]
		public void TestDivideByLengths()
		{
			string[] ans = zusp.DivideByLengths("0123456789", 1, 2, 3, 4);
			Assert.AreEqual("0", ans[0]);
			Assert.AreEqual("12", ans[1]);
			Assert.AreEqual("345", ans[2]);
			Assert.AreEqual("6789", ans[3]);
		}
		[TestMethod]
		public void TestPick()
		{
			string[] ans = zusp.Pick("2015.06.30 00:08", 4, 1, 2, 1, 2, 1, 2, 1, 2);
			Assert.AreEqual(5, ans.Length);
			Assert.AreEqual("2015", ans[0]);
			Assert.AreEqual("06", ans[1]);
			Assert.AreEqual("30", ans[2]);
			Assert.AreEqual("00", ans[3]);
			Assert.AreEqual("08", ans[4]);
		}
	}
}
