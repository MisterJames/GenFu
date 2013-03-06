using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Angela.Core
{
    public class Maggie
    {
        private IDictionary<string, IList<IPropertyFiller>> _specificPropertyFillersByObjectType;
        private IDictionary<Type, IPropertyFiller> _genericPropertyFillersByPropertyType;

#pragma warning disable 0649 //property injected by MEF
        [ImportMany(typeof(IPropertyFiller))]
        private IEnumerable<IPropertyFiller> _propertyFillers;
#pragma warning restore 0649


        public Maggie()
        {
            ResetFillers();
        }

        public void ResetFillers()
        {
            if (_propertyFillers == null)
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog("."));
                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }

            _specificPropertyFillersByObjectType = new Dictionary<string, IList<IPropertyFiller>>();

            foreach (IPropertyFiller propertyFiller in _propertyFillers.Where(p => !p.IsGenericFiller))
            {
                RegisterFiller(propertyFiller);
            }

            _genericPropertyFillersByPropertyType = new Dictionary<Type, IPropertyFiller>();
            foreach (IPropertyFiller propertyFiller in _propertyFillers.Where(p => p.IsGenericFiller))
            {
                _genericPropertyFillersByPropertyType.Add(propertyFiller.PropertyType, propertyFiller);
            }

        }

        public void RegisterFiller(IPropertyFiller filler)
        {
            foreach (string objectTypeName in filler.ObjectTypeNames.Select(s => s.ToLowerInvariant()))
            {
                if (!_specificPropertyFillersByObjectType.ContainsKey(objectTypeName))
                {
                    _specificPropertyFillersByObjectType[objectTypeName] = new List<IPropertyFiller>();
                }
                IList<IPropertyFiller> typeFillers = _specificPropertyFillersByObjectType[objectTypeName];
                typeFillers.Add(filler);
            }
        }

        public IPropertyFiller GetFiller(PropertyInfo propertyInfo)
        {
            IPropertyFiller result = null;
            Type objectType = propertyInfo.DeclaringType;
            while (objectType != null && result == null)
            {
                //First try to get a specific filler based on a full type name (including namespace)
                string fullTypeName = objectType.FullName.ToLowerInvariant();
                if (_specificPropertyFillersByObjectType.ContainsKey(fullTypeName))
                {
                    IList<IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[fullTypeName];
                    result = GetMatchingPropertyFiller(propertyInfo, propertyFillers);
                }

                //Second try to get a more generic filler based on only the class name (no namespace)
                if (result == null)
                {
                    string classTypeName = objectType.Name.ToLowerInvariant();
                    if (_specificPropertyFillersByObjectType.ContainsKey(classTypeName))
                    {
                        IList<IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[classTypeName];
                        result = GetMatchingPropertyFiller(propertyInfo, propertyFillers);
                    }
                }

                objectType = objectType.BaseType;
            }

            if (result == null)
            {
                //Finally, grab a generic property filler for that property type
                if (_genericPropertyFillersByPropertyType.ContainsKey(propertyInfo.PropertyType))
                {
                    result = _genericPropertyFillersByPropertyType[propertyInfo.PropertyType];
                }
                else
                {
                    //TODO: Can we build a custom filler here for other value types that we have not explicitly implemented (eg. long, decimal, etc.)
                    result = new CustomFiller<object>("*", typeof(object), () => null) { IsGenericFiller = true };

                    _genericPropertyFillersByPropertyType.Add(propertyInfo.PropertyType, result);
                }
            }

            return result;
        }

        private static IPropertyFiller GetMatchingPropertyFiller(PropertyInfo propertyInfo, IList<IPropertyFiller> propertyFillers)
        {
            IPropertyFiller result = null;
            foreach (IPropertyFiller propertyFiller in propertyFillers)
            {
                if (propertyFiller.PropertyType == propertyInfo.PropertyType &&
                    propertyFiller.PropertyNames.Any(s => propertyInfo.Name.ToLowerInvariant().Contains(s.ToLowerInvariant())))
                {
                    result = propertyFiller;
                    break;
                }
            }
            return result;
        }

        public void SetMinInt(int min)
        {
            IntFiller intFiller = (IntFiller)_genericPropertyFillersByPropertyType[typeof(int)];
            intFiller.Min = min;
        }

        public void SetMaxInt(int max)
        {
            IntFiller intFiller = (IntFiller)_genericPropertyFillersByPropertyType[typeof(int)];
            intFiller.Max = max;
        }

        public void SetMinShort(short min)
        {
            ShortFiller shortFiller = (ShortFiller)_genericPropertyFillersByPropertyType[typeof(short)];
            shortFiller.Min = min;
        }

        public void SetMaxShort(short max)
        {
            ShortFiller shortFiller = (ShortFiller)_genericPropertyFillersByPropertyType[typeof(short)];
            shortFiller.Max = max;
        }

        public void SetMinDecimal(decimal min)
        {
            DecimalFiller decFiller = (DecimalFiller)_genericPropertyFillersByPropertyType[typeof(decimal)];
            decFiller.Min = min;
        }

        public void SetMaxDecimal(decimal max)
        {
            DecimalFiller decFiller = (DecimalFiller)_genericPropertyFillersByPropertyType[typeof(decimal)];
            decFiller.Max = max;
        }

        public void SetMinDateTime(DateTime minValue)
        {
            DateTimeFiller dateTimeFiller = (DateTimeFiller)_genericPropertyFillersByPropertyType[typeof(DateTime)];
            dateTimeFiller.Min = minValue;
        }

        public void SetMaxDateTime(DateTime maxValue)
        {
            DateTimeFiller dateTimeFiller = (DateTimeFiller)_genericPropertyFillersByPropertyType[typeof(DateTime)];
            dateTimeFiller.Max = maxValue;
        }

        public DateTime GetMinDateTime()
        {
            DateTimeFiller dateTimeFiller = (DateTimeFiller)_genericPropertyFillersByPropertyType[typeof(DateTime)];
            return dateTimeFiller.Min;
        }

        public DateTime GetMaxDateTime()
        {
            DateTimeFiller dateTimeFiller = (DateTimeFiller)_genericPropertyFillersByPropertyType[typeof(DateTime)];
            return dateTimeFiller.Max;
        }

    }
}