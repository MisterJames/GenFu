using System.Collections.Generic;
using System.Reflection;

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

        public AngieConfigurator<T> WithRandom(int[] values)
        {
            CustomFiller<int> customFiller = new CustomFiller<int>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(List<int> values)
        {
            CustomFiller<int> customFiller = new CustomFiller<int>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieConfigurator<T> WithRandom(IEnumerable<int> values)
        {
            CustomFiller<int> customFiller = new CustomFiller<int>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
