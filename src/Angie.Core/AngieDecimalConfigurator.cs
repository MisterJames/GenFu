using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieDecimalConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieDecimalConfigurator(Angie angie, FillerManager maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        /// <summary>
        /// Fill the target property with values between the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (inclusive)</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithinRange(int min, int max)
        {
            DecimalFiller filler = new DecimalFiller(typeof(T), _propertyInfo.Name, min, max);
            _fillerManager.RegisterFiller(filler);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified array
        /// </summary>
        /// <param name="values">A array of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(decimal[] values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified list
        /// </summary>
        /// <param name="values">A list of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(List<decimal> values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified enumerable
        /// </summary>
        /// <param name="values">A enumerable of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(IEnumerable<decimal> values)
        {
            CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
