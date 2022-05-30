using System;

namespace GenFu;

internal static class ReflectionHelpers
{
    public static Type GetNullableUnderlyingType(this Type type)
    {
        return Nullable.GetUnderlyingType(type);
    }
}
