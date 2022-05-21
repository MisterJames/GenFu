namespace GenFu;

using System.Collections.Generic;
using System.Reflection;

public class GenFuDecimalConfigurator<T> : GenFuConfigurator<T> where T : new()
{
    private MemberInfo _propertyInfo;

    public GenFuDecimalConfigurator(GenFu genfu, FillerManager fillerManager, MemberInfo propertyInfo)
        : base(genfu, fillerManager)
    {
        _propertyInfo = propertyInfo;
    }

    /// <summary>
    /// Fill the target property with values between the specified range
    /// </summary>
    /// <param name="min">The minimum value (inclusive)</param>
    /// <param name="max">The maximum value (inclusive)</param>
    /// <returns>A configurator for the target object type</returns>
    public GenFuConfigurator<T> WithinRange(int min, int max)
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
    public GenFuConfigurator<T> WithRandom(decimal[] values)
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
    public GenFuConfigurator<T> WithRandom(List<decimal> values)
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
    public GenFuConfigurator<T> WithRandom(IEnumerable<decimal> values)
    {
        CustomFiller<decimal> customFiller = new CustomFiller<decimal>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
        _fillerManager.RegisterFiller(customFiller);
        return this;
    }

    public MemberInfo PropertyInfo => _propertyInfo;
}
