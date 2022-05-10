namespace GenFu.ValueGenerators.Geospatial;

using System;
using System.Collections.Generic;

public class Address : BaseValueGenerator
{
    public static readonly Random random = new Random();

    public static string AddressLine()
    {
        var suffixes = new List<string> { "NW", "N", "NE", "E", "SE", "S", "SW", "W" };

        var number = _random.Next(100, 9999);
        number = _random.Next(1, 5) == 5 ? _random.Next(100, 99999) : number;

        var streetName = GetRandomValue(ResourceLoader.Data(PropertyType.StreetNames));
        var direction = _random.Next(1, 1) > 8 ? GetRandomValue(suffixes) : string.Empty;

        var result = string.Format("{0} {1} {2}", number, streetName, direction);

        return result;
    }

    public static string AddressLine2()
    {
        string result = string.Empty;

        List<string> units = new List<string> { "Apt ", "Unit ", "#", "Studio " };
        List<string> suffixes = new List<string> { "A", "B", "C", "D", "E", "F", "G" };

        var unit = _random.Next(1, 4) > 2 ? GetRandomValue(units) : string.Empty;
        var number = _random.Next(100, 999);
        var suffix = _random.Next(1, 4) > 2 ? GetRandomValue(suffixes) : string.Empty;

        if (unit.Length + suffix.Length != 0)
        {
            result = string.Format("{0}{1}{2}", unit, number, suffix);
            result = _random.Next(1, 4) == 1 ? result : string.Empty;
        }

        return result;
    }

    public static string City() => GetRandomValue(ResourceLoader.Data(PropertyType.CityNames));

    public static string UsaState() => GetRandomValue(ResourceLoader.Data(PropertyType.UsaStates));

    public static string UsaStateAbbreviation()
     => GetRandomValue(ResourceLoader.Data(PropertyType.UsaStateAbbreviations));

    public static string CanadianProvince()
     => GetRandomValue(ResourceLoader.Data(PropertyType.CanadianProvinces));

    public static string CanadianProvinceAbbreviation()
     => GetRandomValue(ResourceLoader.Data(PropertyType.CanadianProvinceAbbreviations));

    public static string ZipCode() => random.Next(0, 99999).ToString().PadLeft(5, '0');

    public static string PostalCode()
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var postalCode = string.Empty;
        postalCode += letters[random.Next(0, letters.Length)];
        postalCode += random.Next(0, 9);
        postalCode += letters[random.Next(0, letters.Length)];

        postalCode += " ";

        postalCode += random.Next(0, 9);
        postalCode += letters[random.Next(0, letters.Length)];
        postalCode += random.Next(0, 9);

        return postalCode;
    }
}
