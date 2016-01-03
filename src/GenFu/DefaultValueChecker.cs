using System;
using System.Reflection;

namespace GenFu
{
    public class DefaultValueChecker
    {
        internal static bool HasValue(object instance, PropertyInfo property)
        {
            var value = property.GetValue(instance,null);
            bool valueSet = false;

            // Support Nullable items
            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return value != null;
            }

            switch (property.PropertyType.Name.ToLower())
            {
                case "int32":
                    if ((Int32)value != default(Int32))
                        valueSet = true;
                    break;
                case "string":
                    if ((string)value != default(string))
                        valueSet = true;
                    break;
                case "datetime":
                    if ((DateTime)value != default(DateTime))
                        valueSet = true;
                    break;
                default:
                    break;
            }

            return valueSet;
        }

    }
}
