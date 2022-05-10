namespace GenFu.ValueGenerators.Medical;

public class Injuries : BaseValueGenerator
{
    public static string Injury()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.Injuries));
    }
}
