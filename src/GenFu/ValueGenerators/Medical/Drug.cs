namespace GenFu.ValueGenerators.Medical;

public class Drugs : BaseValueGenerator
{
    public static string Drug()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.Drugs));
    }
}
