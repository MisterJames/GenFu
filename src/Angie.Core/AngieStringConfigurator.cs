using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public class AngieStringConfigurator<T> : AngieConfigurator<T> where T : new()
    {
        private PropertyInfo _propertyInfo;

        public AngieStringConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo)
            : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified array
        /// </summary>
        /// <param name="values">A array of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(string[] values)
        {
            CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified list
        /// </summary>
        /// <param name="values">A list of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(List<string> values)
        {
            CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified enumerable
        /// </summary>
        /// <param name="values">A enumerable of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> WithRandom(IEnumerable<string> values)
        {
            CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => Jen.GetRandomValue(values));
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
