using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mek.TypedStrings
{
	public class NEString : TypedString<NEString>
	{
		public NEString(string value) : base(value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("value is empty or null", nameof(value));
		}
	}
}