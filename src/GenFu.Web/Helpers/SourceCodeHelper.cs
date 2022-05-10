namespace GenFu.Web.Helpers;

using Microsoft.CodeAnalysis;

using System;
using System.Reflection;

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
