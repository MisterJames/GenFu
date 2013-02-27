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

        public AngieConfigurator<T> WithRandom(decimal[] values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(List<decimal> values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(IEnumerable<decimal> values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
