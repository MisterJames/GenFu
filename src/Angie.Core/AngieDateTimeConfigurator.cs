using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieDateTimeConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieDateTimeConfigurator(Angie angie, FillerManager maggie, PropertyInfo propertyInfo)
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
