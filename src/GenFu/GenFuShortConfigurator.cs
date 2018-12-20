using System.Collections.Generic;
using System.Reflection;

namespace GenFu
{
    public class GenFuShortConfigurator<T> : GenFuConfigurator<T> where T : new()
    {
        private readonly GenFuInstance genfu;
        private MemberInfo _propertyInfo;

        public GenFuShortConfigurator(GenFuInstance genfu, FillerManager fillerManager, MemberInfo propertyInfo)
            : base(genfu, fillerManager)
        {
            this.genfu = genfu;
            _propertyInfo = propertyInfo;
        }

        /// <summary>
        /// Fill the target property with values between the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (inclusive)</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> WithinRange(short min, short max)
        {
            ShortFiller filler = new ShortFiller(this.genfu, typeof(T), _propertyInfo.Name, min, max);
            _fillerManager.RegisterFiller(filler);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified array
        /// </summary>
        /// <param name="values">A array of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> WithRandom(short[] values)
        {
            CustomFiller<short> customFiller = new CustomFiller<short>(genfu, PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified list
        /// </summary>
        /// <param name="values">A list of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> WithRandom(List<short> values)
        {
            CustomFiller<short> customFiller = new CustomFiller<short>(genfu, PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the target property with a random value from the specified enumerable
        /// </summary>
        /// <param name="values">A enumerable of values to choose from</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> WithRandom(IEnumerable<short> values)
        {
            CustomFiller<short> customFiller = new CustomFiller<short>(genfu, PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        public MemberInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }
}
