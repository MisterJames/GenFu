using System;
using System.Reflection;

namespace GenFu
{
    public class DefaultValueChecker
    {
        internal static bool HasValue(object instance, PropertyInfo property)
        {
            var value = property.GetValue(instance,null);
            
            // Support Nullable items
            if (property.PropertyType.GetTypeInfo().IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return value != null;
            }

            if (property.PropertyType == typeof(int))
            {
                return (int)value != default(int);
            }

            if (property.PropertyType == typeof(string))
            {
                return (string)value != default(string);
            }

            if (property.PropertyType == typeof(DateTime))
            {
                return (DateTime)value != default(DateTime);
            }

            return false;
        }
    }
}
