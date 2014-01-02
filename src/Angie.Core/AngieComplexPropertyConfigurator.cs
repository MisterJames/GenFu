using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieComplexPropertyConfigurator<T, T2> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieComplexPropertyConfigurator(Angie angie, FillerManager maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified list
        /// </summary>
        /// <param name="values">A list of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(IList<T2> values)
        {
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified enumerable
        /// </summary>
        /// <param name="values">An enumerable of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(IEnumerable<T2> values)
        {
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified array
        /// </summary>
        /// <param name="values">A array of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(T2[] values)
        {
            CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
