using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zuoanqh.libzut.Data;
using System.Collections.Generic;

namespace zuoanqh.libzut.Testing
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
			Assert.AreEqual("1, 2", String.Join(", ", 1, 2));
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

		[TestMethod]
		public void TestListSplit()
		{
			List<string> l = new List<string>();
			l.Add("separator");
			l.Add("data1");
			l.Add("data2");
			l.Add("data3");
			l.Add("data4");
			l.Add("separator");

			var ans = zusp.ListSplit(l,"separator");
			Assert.AreEqual(1, ans.Count);
			var l0 = ans[0];
			Assert.AreEqual(4, l0.Count);

			l = new List<string>();
			l.Add("data1");
			l.Add("data2");
			l.Add("separator");
			l.Add("data3");
			l.Add("separator");
			l.Add("data4");

			ans = zusp.ListSplit(l, "separator");
			Assert.AreEqual(3, ans.Count);
			l0 = ans[0];
			var l1 = ans[1];
			var l2 = ans[2];

			Assert.AreEqual(2, l0.Count);
			Assert.AreEqual(1, l1.Count);
			Assert.AreEqual(1, l2.Count);

		}


		[TestMethod]
		public void TestListToDictionary()
		{
			List<string> l = new List<string>();
			l.Add("item name: asdf");
			l.Add("item id: 12345");
			l.Add("in stock: ");

			var ans = zusp.ListToDictionary(l, ": ");
			Assert.AreEqual(3, ans.Count);
			Assert.AreEqual("asdf", ans["item name"]);
			Assert.AreEqual("12345", ans["item id"]);
			Assert.AreEqual("", ans["in stock"]);


		}

        [TestMethod]
        public void TestCommonPrefixPostfix()
        {
            List<string> l = new List<string>();

            l.Add("prefix");
            l.Add("prefix1");
            l.Add("prefix123");
            Assert.AreEqual("prefix", zusp.GetCommonPrefix(l));

            l.Clear();
            l.Add("brefix");
            l.Add("prefix1");
            l.Add("prefix1");
            Assert.AreEqual("", zusp.GetCommonPrefix(l));

            l.Clear();
            l.Add("prafix");
            l.Add("prefix1");
            l.Add("prefix1");
            Assert.AreEqual("pr", zusp.GetCommonPrefix(l));

            l.Clear();
            l.Add("postfix");
            l.Add("1postfix");
            l.Add("123postfix");
            Assert.AreEqual("postfix", zusp.GetCommonPostfix(l));

            l.Clear();
            l.Add("postfiy");
            l.Add("1postfix");
            l.Add("123postfix");
            Assert.AreEqual("", zusp.GetCommonPostfix(l));

            l.Clear();
            l.Add("postnix");
            l.Add("1postfix");
            l.Add("123postfix");
            Assert.AreEqual("ix", zusp.GetCommonPostfix(l));
        }

    }
}
