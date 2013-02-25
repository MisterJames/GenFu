using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieComplexPropertyConfigurator<T, T2> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieComplexPropertyConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public AngieConfigurator<T> WithRandom(IList<T2> values)
        {
            Random random = new Random(Environment.TickCount);

            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () =>
                {
                    return values[random.Next(0, values.Count)];
                });
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
