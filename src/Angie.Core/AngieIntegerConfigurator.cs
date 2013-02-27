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

        /// <summary>
        /// Fill the target property with values between the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (inclusive)</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithinRange(int min, int max)
        {
            IntFiller filler = new IntFiller(typeof(T), _propertyInfo.Name, min, max);
            _maggie.RegisterFiller(filler);
            return this;
        }
        
        /// <summary>
        /// Fill the target property with a random value from the specified array
        /// </summary>
        /// <param name="values">A array of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(int[] values)
        {
            CustomFiller<int> customFiller = new CustomFiller<int>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified list
        /// </summary>
        /// <param name="values">A list of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(List<int> values)
        {
            CustomFiller<int> customFiller = new CustomFiller<int>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified enumerable
        /// </summary>
        /// <param name="values">A enumerable of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
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
