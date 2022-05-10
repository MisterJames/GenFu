namespace GenFu.ValueGenerators.People;

using System;
using System.Linq;

public class Names : BaseValueGenerator
{
    public static string Title()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.Titles));
    }

    public static string LastName()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.LastNames));
    }

    public static string FirstName()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.FirstNames));
    }

    public static string PersonTitle()
    {
        return GetRandomValue(ResourceLoader.Data(PropertyType.PersonTitles));
    }

    public static string UserName()
    {
        return FirstName().First() + LastName();
    }

    public static string FullName()
    {
        return String.Format("{0} {1}", FirstName(), LastName());
    }
}
