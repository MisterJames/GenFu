using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieDateTimeConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private MemberInfo _propertyInfo;

        public AngieDateTimeConfigurator(Angie angie, FillerManager fillerManager, MemberInfo propertyInfo)
            : base(angie, fillerManager)
        {
            _propertyInfo = propertyInfo;
        }

        public MemberInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
