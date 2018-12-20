using System;
using System.Linq;

namespace GenFu
{
    public abstract class PropertyFiller<T> : IPropertyFiller
    {
        /// <summary>
        /// Creates a property filler targeting the specified object types and properties
        /// </summary>
        /// <param name="objectTypeNames">The names of the object types that this property filler will target</param>
        /// <param name="propertyNames">The names of the properties that this property filler will target</param>
        protected PropertyFiller(GenFuInstance genfu, string[] objectTypeNames, string[] propertyNames)
            : this(genfu, objectTypeNames, propertyNames, false)
        {
            GenFu = genfu;
        }

        internal PropertyFiller(GenFuInstance genfu, string[] objectTypeNames, string[] propertyNames, bool isGenericFiller)
        {
            ObjectTypeNames = objectTypeNames.Select(o => o.ToLowerInvariant()).ToArray();
            PropertyNames = propertyNames.Select(p => p.ToLowerInvariant()).ToArray();
            GenFu = genfu;
            IsGenericFiller = isGenericFiller;
        }


        public string[] PropertyNames { get; private set; }
        public string[] ObjectTypeNames { get; protected set; }
        public bool IsGenericFiller { get; private set; }

        public Type PropertyType { get { return typeof(T); } }

        public GenFuInstance GenFu { get; }

        /// <summary>
        /// Returns a value that will be used to a particular property
        /// </summary>
        /// <returns>Some random-ish value</returns>
        public abstract object GetValue(object instance);
    }
}