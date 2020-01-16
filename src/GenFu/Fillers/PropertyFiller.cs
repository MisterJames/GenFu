using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GenFu
{
    public abstract class PropertyFiller<T> : IPropertyFiller
    {
        /// <summary>
        /// Creates a property filler targeting the specified object types and properties
        /// </summary>
        /// <param name="objectTypeNames">The names of the object types that this property filler will target</param>
        /// <param name="propertyNames">The names of the properties that this property filler will target</param>
        protected PropertyFiller(string[] objectTypeNames, string[] propertyNames)
            : this(objectTypeNames, propertyNames, false)
        {

        }

        /// <summary>
        /// Creates a property filler targeting the specified object types and properties
        /// </summary>
        /// <param name="objectTypeNames">The names of the object types that this property filler will target</param>
        /// <param name="propertyNames">The names of the properties that this property filler will target</param>

        internal PropertyFiller(Type objectType, string propertyName,  bool isGeneric = false)
            : this(new[] { objectType.FullName }, new[] { propertyName }, isGeneric)
        {
            if (objectType != typeof(Object))
                AddAllBaseTypes(propertyName, objectType);
        }

        private PropertyFiller(string[] objectTypeNames, string[] propertyNames, bool isGenericFiller)
        {
            ObjectTypeNames = objectTypeNames.Select(o => o.ToLowerInvariant()).ToArray();
            PropertyNames = propertyNames.Select(p => p.ToLowerInvariant()).ToArray();
            IsGenericFiller = isGenericFiller;   
        }


        private void AddAllBaseTypes(string propertyName, Type objectType)
        {
            var objectTypeNames = new List<string> { objectType.FullName };

            var baseType = objectType.GetTypeInfo().BaseType;
            while (baseType.GetProperties().Any(x => x.Name == propertyName) && baseType != typeof(Object))
            {
                objectTypeNames.Add(baseType.FullName);
                baseType = baseType.GetTypeInfo().BaseType;
            }
            ObjectTypeNames = objectTypeNames.ToArray();
        }

        public string[] PropertyNames { get; private set; }
        public string[] ObjectTypeNames { get; protected set; }
        public bool IsGenericFiller { get; private set; }

        public Type PropertyType { get { return typeof(T); } }
        
        /// <summary>
        /// Returns a value that will be used to a particular property
        /// </summary>
        /// <returns>Some random-ish value</returns>
        public abstract object GetValue(object instance);
    }
}