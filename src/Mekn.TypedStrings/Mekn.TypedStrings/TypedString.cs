using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Mek.TypedStrings
{
	public class TypedString<T> : 
		IComparable,
		IEnumerable<char>,
		IComparable<T>,
		IEquatable<T>,
		ITypedString
	{
		private readonly int hashCode;

		protected TypedString(string value)
		{
			if(value == null)
				throw new ArgumentException("value is null");

			this.Value = value;
			this.hashCode = GetHashCodeCore();
		}

		private int GetHashCodeCore()
		{
			unchecked
			{
				var hash = 27;

				hash = (13 * hash) + typeof(T).GetHashCode();
				hash = (13 * hash) + this.Value.GetHashCode();

				return hash;
			}
		}

		public static implicit operator string (TypedString<T> str)
		{
			return str.Value;
		}

		public static bool operator ==(TypedString<T> x, TypedString<T> y)
		{
			return x.Equals(y);
		}

		public static bool operator !=(TypedString<T> x, TypedString<T> y)
		{
			return !x.Equals(y);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			else if(obj is ITypedString)
			{
				var typedString = obj as ITypedString;
				return Equals(typedString.Value, this.Value);
			}
			else if(obj is string)
			{
				return Equals(obj as string, this.Value);
			}
			else
			{
				return base.Equals(obj);
			}
		}

		public override int GetHashCode()
		{
			return this.hashCode;
		}

		public string Value { get; }

		public int CompareTo(object obj)
		{
			if(obj == null)
			{
				return 1;
			}
			else if(obj is ITypedString)
			{
				var typedString = obj as ITypedString;
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.CompareTo(typedString.Value);
			}
			else if(obj is string)
			{
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.CompareTo(obj as string);
			}
			else
			{
				return this.Value.CompareTo(obj);
			}
		}

		public IEnumerator<char> GetEnumerator()
		{
			return this.Value.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int CompareTo(T other)
		{
			if(other is string)
			{
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.CompareTo(other as string);
			}
			else if(other is ITypedString)
			{
				var typedString = other as ITypedString;
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.CompareTo(typedString.Value);
			}
			else
			{
				return this.Value.CompareTo(other);
			}
		}

		public bool Equals(T other)
		{
			if (other is string)
			{
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.Equals(other as string);
			}
			else if (other is ITypedString)
			{
				var typedString = other as ITypedString;
				// ReSharper disable once StringCompareToIsCultureSpecific
				return this.Value.Equals(typedString.Value);
			}
			else
			{
				return this.Value.Equals(other);
			}
		}

		public override string ToString()
		{
			return this.Value;
		}
	}
}
