using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mek.TypedStrings.Tests
{
	[TestFixture]
	public class TypedStringFixture
	{
		public class TestTypedString : TypedString<TestTypedString>
		{
			public TestTypedString(string value) : base(value)
			{

			}
		}

		[Test]
		public void can_equate()
		{
			var foo1 = new TestTypedString("foo");
			var foo2 = new TestTypedString("foo");
			var bar1 = new TestTypedString("bar");
			var bar2 = new TestTypedString("bar");

			Assert.AreEqual(foo1, foo2);
			Assert.AreEqual(bar1, bar2);

			Assert.AreNotEqual(foo1, bar1);

			Assert.IsTrue(foo1 == foo2);
			Assert.IsTrue(foo1 != bar1);

			Assert.AreEqual(foo1.GetHashCode(), foo2.GetHashCode());
			Assert.AreNotEqual(foo1.GetHashCode(), bar1.GetHashCode());
		}
	}
}