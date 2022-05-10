using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace GenFu
{
    /// <summary>
    /// Implements checking if a member has the default value
    /// </summary>
    public static class DefaultValueChecker
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
            else if (type == typeof(Int32)) return (Int32)value != default(Int32);
            else if (type == typeof(Int16)) return (Int16)value != default(Int16);
            else if (type == typeof(double)) return (double)value != default(double);
            else if (type == typeof(decimal)) return (decimal)value != default(decimal);
            else if (type == typeof(float)) return (float)value != default(float);
            else if (type == typeof(Guid)) return (Guid)value != default(Guid);
            else if (type == typeof(long)) return (long)value != default(long);
            else if (type == typeof(ulong)) return (ulong)value != default(ulong);
            else if (type == typeof(uint)) return (uint)value != default(uint);
            else if (type == typeof(ushort)) return (ushort)value != default(ushort);
            else if (type == typeof(bool)) return (bool)value != default(bool);
            else if (type == typeof(string)) return (string)value != default(string);
            else if (type == typeof(DateTime)) return !((DateTime)value).Equals(default(DateTime));
            else if (type == typeof(DateTimeOffset)) return !((DateTimeOffset)value).Equals(default(DateTimeOffset));
            else if (typeInfo.BaseType == typeof(System.Enum)) return !IsDefaultEnum(type, value);
            else if (typeInfo.IsValueType) return !IsDefaultStruct(typeInfo, value);
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
