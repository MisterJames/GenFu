using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace GenFu
{
    /// <summary>
    /// Helps in managing the properties which we should not be initialized while creating new object,
    /// Reference types will be null, and value type properties will have default value unless those are nullable
    /// </summary>
    public static class IgnorePropertyCollection
    {
        private static Dictionary<Type, List<string>> _propertiesToIgnore;
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        static IgnorePropertyCollection()
        {
            _propertiesToIgnore = new Dictionary<Type, List<string>>();
        }

        /// <summary>
        /// Property which will be ignored for initialization during new object creation
        /// </summary>
        /// <param name="memberInfo">Property to be ignored</param>
        public static void AddPropertyToIgnoreList(MemberInfo memberInfo)
        {
            try
            {
                _readWriteLock.EnterWriteLock();
                if (!_propertiesToIgnore.ContainsKey(memberInfo.DeclaringType))
                {
                    var fieldCollection = new List<string>
                {
                    memberInfo.Name
                };
                    _propertiesToIgnore.Add(memberInfo.DeclaringType, fieldCollection);
                }
                else
                {
                    if (!_propertiesToIgnore[memberInfo.DeclaringType].Contains(memberInfo.Name))
                        _propertiesToIgnore[memberInfo.DeclaringType].Add(memberInfo.Name);
                }
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Checks whether given <paramref name="propertyInfo"/> needs to be ignored or not
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static bool IsPropertyInIgnoreList(PropertyInfo propertyInfo)
        {
            try
            {
                _readWriteLock.EnterReadLock();
                if (!_propertiesToIgnore.ContainsKey(propertyInfo.DeclaringType))
                    return false;

                List<string> fieldCollection = _propertiesToIgnore[propertyInfo.DeclaringType];
                return fieldCollection.Contains(propertyInfo.Name);
            }
            finally
            {
                _readWriteLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Removes all the properties from Ignore list of all Type
        /// </summary>
        public static void Reset()
        {
            try
            {
                _readWriteLock.EnterWriteLock();
                _propertiesToIgnore = new Dictionary<Type, List<string>>();
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Removes all the properties from Ignore list of the given Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Reset<T>()
        {
            try
            {
                _readWriteLock.EnterWriteLock();
                if (_propertiesToIgnore.ContainsKey(typeof(T)))
                {
                    _propertiesToIgnore.Remove(typeof(T));
                }
            }
            finally
            {
                _readWriteLock.ExitWriteLock();
            }
        }
    }
}
