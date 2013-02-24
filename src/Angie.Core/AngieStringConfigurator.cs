using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieStringConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieStringConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
