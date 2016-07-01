using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GenFu.Web.Helpers
{
	public static class SourceCodeHelpers
	{
		public static readonly Type[] SupportedTypes = new Type[]
		{
			typeof(A),
			typeof(Object),
			typeof(short),
			typeof(float),
			typeof(Int32),
			typeof(Int16),
			typeof(double),
			typeof(decimal),
			typeof(Guid),
			typeof(long),
			typeof(ulong),
			typeof(uint),
			typeof(ushort),
			typeof(bool),
			typeof(string),
			typeof(DateTime)
		};

		public static MetadataReference GetMeta(this Type type)
		{
			return MetadataReference.CreateFromFile(type.GetTypeInfo().Assembly.Location);
		}
	}
}
