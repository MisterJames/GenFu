namespace GenFu;

using System.Collections.Generic;
using System.Reflection;

public class GenFuStringConfigurator<T> : GenFuConfigurator<T> where T : new()
{
    private MemberInfo _propertyInfo;

    public GenFuStringConfigurator(GenFu genfu, FillerManager fillerManager, MemberInfo propertyInfo)
        : base(genfu, fillerManager)
    {
        _propertyInfo = propertyInfo;
    }

    /// <summary>
    /// Fill the target property with a random value from the specified array
    /// </summary>
    /// <param name="values">A array of values to choose from</param>
    /// <returns>A configurator for the target object type</returns>
    public GenFuConfigurator<T> WithRandom(string[] values)
    {
        CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
        _fillerManager.RegisterFiller(customFiller);
        return this;
    }

    /// <summary>
    /// Fill the target property with a random value from the specified list
    /// </summary>
    /// <param name="values">A list of values to choose from</param>
    /// <returns>A configurator for the target object type</returns>
    public GenFuConfigurator<T> WithRandom(List<string> values)
    {
        CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
        _fillerManager.RegisterFiller(customFiller);
        return this;
    }

    /// <summary>
    /// Fill the target property with a random value from the specified enumerable
    /// </summary>
    /// <param name="values">A enumerable of values to choose from</param>
    /// <returns>A configurator for the target object type</returns>
    public GenFuConfigurator<T> WithRandom(IEnumerable<string> values)
    {
        CustomFiller<string> customFiller = new CustomFiller<string>(PropertyInfo.Name, typeof(T), () => BaseValueGenerator.GetRandomValue(values));
        _fillerManager.RegisterFiller(customFiller);
        return this;
    }

    public MemberInfo PropertyInfo => _propertyInfo;
}
