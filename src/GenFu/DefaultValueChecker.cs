using System;
using System.Reflection;

namespace GenFu
{
    public class DefaultValueChecker
    {
        internal static bool HasValue(object instance, PropertyInfo property)
        {
            var value = property.GetValue(instance, null);
            if (property.PropertyType.GetTypeInfo().IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return value != null;
            }
            
            if (value == null)
                return false;
            if (property.PropertyType == typeof(Int32) && (Int32)value == default(Int32))
                return false;
            else if (property.PropertyType == typeof(Int16) && (Int16)value == default(Int16))
                return false;
            else if (property.PropertyType == typeof(double) && (double)value == default(double))
                return false;
            else if (property.PropertyType == typeof(decimal) && (decimal)value == default(decimal))
                return false;
            else if (property.PropertyType == typeof(float) && (float)value == default(float))
                return false;
            else if (property.PropertyType == typeof(Guid) && (Guid)value == default(Guid))
                return false;
            else if (property.PropertyType == typeof(long) && (long)value == default(long))
                return false;
            else if (property.PropertyType == typeof(ulong) && (ulong)value == default(ulong))
                return false;
            else if (property.PropertyType == typeof(uint) && (uint)value == default(uint))
                return false;
            else if (property.PropertyType == typeof(ushort) && (ushort)value == default(ushort))
                return false;
            else if (property.PropertyType == typeof(bool) && (bool)value == default(bool))
                return false;
            else if (property.PropertyType == typeof(string) && (string)value == default(string))
                return false;
            else if (property.PropertyType == typeof(DateTime) && ((DateTime)value).Equals(default(DateTime)))
                return false;
            else if (property.PropertyType == typeof(DateTimeOffset) && ((DateTimeOffset)value).Equals(default(DateTimeOffset)))
                return false;
            return true;
        }
    }
}
