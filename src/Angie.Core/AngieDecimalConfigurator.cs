using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieDecimalConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieDecimalConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public AngieConfigurator<T> WithinRange(int min, int max)
        {
            DecimalFiller filler = new DecimalFiller(typeof(T), _propertyInfo.Name, min, max);
            _maggie.RegisterFiller(filler);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
