namespace GenFu.ValueGenerators.Corporate;

using System.Linq;

class Company : BaseValueGenerator
{
    public static string Name()
    {
        var names = from c in ResourceLoader.Data(PropertyType.CompanyNames)
                    join i in ResourceLoader.Data(PropertyType.Industries) on 1 equals 1
                    select c + " " + i;
        return names.GetRandomElement();
    }
}
