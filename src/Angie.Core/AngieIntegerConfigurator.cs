using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieIntegerConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieIntegerConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public AngieConfigurator<T> WithinRange(int min, int max)
        {
            IntFiller filler = new IntFiller(typeof(T), _propertyInfo.Name, min, max);
            _maggie.RegisterFiller(filler);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
