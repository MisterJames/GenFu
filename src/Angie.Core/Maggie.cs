using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Angela.Core.Fillers;

namespace Angela.Core
{
    public class Maggie
    {
        private IDictionary<Type, IList<IPropertyFiller>> _specificPropertyFillersByObjectType;
        private IDictionary<Type, IPropertyFiller> _genericPropertyFillersByPropertyType;

        [ImportMany(typeof(IPropertyFiller))]
        private IEnumerable<IPropertyFiller> _propertyFillers;


        public Maggie()
        {
            ResetFillers();
        }

        public void ResetFillers()
        {
            if (_propertyFillers == null)
            {
                AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }

            _specificPropertyFillersByObjectType = new Dictionary<Type, IList<IPropertyFiller>>();

            foreach (IGrouping<Type, IPropertyFiller> propertyFillersByType in _propertyFillers.Where(p => !p.IsGenericFiller).GroupBy(p => p.ObjectType))
            {
                IList<IPropertyFiller> typeFillers = new List<IPropertyFiller>();
                foreach (IPropertyFiller propertyFiller in propertyFillersByType)
                {
                    typeFillers.Add(propertyFiller);
                }
                _specificPropertyFillersByObjectType.Add(propertyFillersByType.Key, typeFillers);
            }

            _genericPropertyFillersByPropertyType = new Dictionary<Type, IPropertyFiller>();
            foreach (IPropertyFiller propertyFiller in _propertyFillers.Where(p => p.IsGenericFiller))
            {
                _genericPropertyFillersByPropertyType.Add(propertyFiller.PropertyType, propertyFiller);
            }
            
        }

        public void RegisterFiller(IPropertyFiller filler)
        {
            if (_specificPropertyFillersByObjectType.ContainsKey(filler.ObjectType))
            {
                _specificPropertyFillersByObjectType[filler.ObjectType].Add(filler);
            }
            else
            {
                List<IPropertyFiller> fillers = new List<IPropertyFiller>();
                fillers.Add(filler);
                _specificPropertyFillersByObjectType.Add(filler.ObjectType, fillers);
            }
        }

        public IPropertyFiller GetFiller(PropertyInfo propertyInfo)
        {
            IPropertyFiller result = null;
            Type objectType = propertyInfo.DeclaringType;
            while (objectType != null && result ==  null)
            {
                if (_specificPropertyFillersByObjectType.ContainsKey(objectType))
                {
                    foreach (IPropertyFiller propertyFiller in _specificPropertyFillersByObjectType[objectType  ])
                    {
                        if (propertyFiller.PropertyType == propertyInfo.PropertyType &&
                            propertyFiller.PropertyNames.Any(s =>  s.ToLowerInvariant() == propertyInfo.Name.ToLower()))
                        {
                            result = propertyFiller;
                            break;
                        }
                    }
                }

                objectType = objectType.BaseType;
            }

            if (result == null)
            {
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

        public void SetMinInt(int min)
        {
            IntFiller intFiller = (IntFiller) _genericPropertyFillersByPropertyType[typeof(int)];
            intFiller.Min = min;
        }

        public void SetMaxInt(int max)
        {
            IntFiller intFiller = (IntFiller)_genericPropertyFillersByPropertyType[typeof(int)];
            intFiller.Max = max;
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