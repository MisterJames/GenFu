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
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(IEnumerable<T2> values)
        {
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(T2[] values)
        {
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
