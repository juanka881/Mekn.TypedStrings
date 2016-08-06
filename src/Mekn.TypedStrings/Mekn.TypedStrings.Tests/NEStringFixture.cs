using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mek.TypedStrings.Tests
{
	[TestFixture]
    public class NEStringFixture
    {
		[TestCase("", TestName = "empty string")]
		[TestCase(null, TestName = "null string")]
		[TestCase("   ", TestName = "space only string")]
		[TestCase("\t", TestName = "tab string")]
		[TestCase("\r\n", TestName = "newline string")]
		public void empty_string_throws(string input)
		{
			// ReSharper disable once ObjectCreationAsStatement
			Assert.Throws<ArgumentException>(() => new NEString(input));
		}

		[TestCase("cake!", TestName = "string")]
		public void can_create(string input)
		{
			var s = new NEString(input);
			Assert.AreEqual(input, s.Value);
		}
    }
}
