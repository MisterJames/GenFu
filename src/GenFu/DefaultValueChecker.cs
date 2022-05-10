using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace GenFu
{
    /// <summary>
    /// Implements checking if a member has the default value
    /// </summary>
    public class DefaultValueChecker
    {
        internal static bool HasValue(object instance, MemberInfo member)
        {
            (object value, Type type) = member switch
            {
                PropertyInfo property => (property.GetValue(instance, null), property.PropertyType),
                FieldInfo field => (field.GetValue(instance), field.FieldType),
                _ => throw new ArgumentException($"{member.Name} is not a property or field")
            };

            TypeInfo typeInfo = type.GetTypeInfo();
            if (typeInfo.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return value != null;
            }

            if (value is null)
                return false;
            else if (type == typeof(Int32) && (Int32)value == default(Int32))
                return false;
            else if (type == typeof(Int16) && (Int16)value == default(Int16))
                return false;
            else if (type == typeof(double) && (double)value == default(double))
                return false;
            else if (type == typeof(decimal) && (decimal)value == default(decimal))
                return false;
            else if (type == typeof(float) && (float)value == default(float))
                return false;
            else if (type == typeof(Guid) && (Guid)value == default(Guid))
                return false;
            else if (type == typeof(long) && (long)value == default(long))
                return false;
            else if (type == typeof(ulong) && (ulong)value == default(ulong))
                return false;
            else if (type == typeof(uint) && (uint)value == default(uint))
                return false;
            else if (type == typeof(ushort) && (ushort)value == default(ushort))
                return false;
            else if (type == typeof(bool) && (bool)value == default(bool))
                return false;
            else if (type == typeof(string) && (string)value == default(string))
                return false;
            else if (type == typeof(DateTime) && ((DateTime)value).Equals(default(DateTime)))
                return false;
            else if (type == typeof(DateTimeOffset) && ((DateTimeOffset)value).Equals(default(DateTimeOffset)))
                return false;
            else if (typeInfo.BaseType == typeof(System.Enum) && IsDefaultEnum(type, value))
                return false;
            else if (typeInfo.IsValueType && IsDefaultStruct(typeInfo, value))
                return false;
            else if (typeInfo.ImplementedInterfaces.Contains(typeof(IEnumerable)) && !(value as IEnumerable).GetEnumerator().MoveNext())
                return false;
            return true;
        }


        private static bool IsDefaultEnum(Type type, object value)
        {
            var t = Enum.GetUnderlyingType(type);
            if (t == typeof(byte)) return ((byte)value) == 0;
            if (t == typeof(int)) return ((int)value) == 0;
            if (t == typeof(long)) return ((long)value) == 0;
            if (t == typeof(sbyte)) return ((sbyte)value) == 0;
            if (t == typeof(short)) return ((short)value) == 0;
            if (t == typeof(uint)) return ((uint)value) == 0;
            if (t == typeof(ulong)) return ((ulong)value) == 0;
            if (t == typeof(ushort)) return ((ushort)value) == 0;
            return false;
        }

        internal static bool IsDefaultStruct(TypeInfo typeInfo, object value)
         => !typeInfo.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                     .Any(p => HasValue(value, p));
    }
}
