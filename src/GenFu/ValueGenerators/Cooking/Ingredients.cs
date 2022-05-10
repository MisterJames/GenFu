namespace GenFu.ValueGenerators.Cooking;

public class Ingredients : BaseValueGenerator
{
    public static string Ingredient()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.Ingredients));
    }
}
