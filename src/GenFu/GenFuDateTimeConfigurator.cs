using System;
using System.Reflection;
using System.Collections.Generic;

namespace GenFu
{
    public class GenFuDateTimeConfigurator<T> : GenFuConfigurator<T> where T : new()
    {
        private MemberInfo _propertyInfo;

        public GenFuDateTimeConfigurator(GenFuInstance genfu, FillerManager fillerManager, MemberInfo propertyInfo)
            : base(genfu, fillerManager)
        {
            _propertyInfo = propertyInfo;
        }

        public MemberInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
