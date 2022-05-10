namespace GenFu;

using System.Collections.Generic;
using System.Reflection;

public class GenFuComplexPropertyConfigurator<T, T2> : GenFuConfigurator<T> where T : new()
{
    private MemberInfo _propertyInfo;

    public GenFuComplexPropertyConfigurator(GenFu genfu, FillerManager fillerManager, MemberInfo propertyInfo)
        : base(genfu, fillerManager)
    {
        _propertyInfo = propertyInfo;
    }

    /// <summary>
    /// Fill the target property with a random value from the specified list
    /// </summary>
    /// <param name="values">A list of values to choose from</param>
    /// <returns>A configurator for the target object type</returns>
    public GenFuConfigurator<T> WithRandom(IList<T2> values)
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
    public GenFuConfigurator<T> WithRandom(IEnumerable<T2> values)
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
    public GenFuConfigurator<T> WithRandom(T2[] values)
    {
        CustomFiller<T2> customFiller = new CustomFiller<T2>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
        _fillerManager.RegisterFiller(customFiller);
        return this;
    }

    public MemberInfo PropertyInfo => _propertyInfo;
}
