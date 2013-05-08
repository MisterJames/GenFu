using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.ValueGenerators.Geospatial
{
    public class Address : BaseValueGenerator
    {
        public static string AddressLine()
        {
            var suffixes = new List<string> { "NW", "N", "NE", "E", "SE", "S", "SW", "W" };

            var number = _random.Next(100, 9999);
            number = _random.Next(1, 5) == 5 ? _random.Next(100, 99999) : number;

            var streetName = GetRandomValue(ResourceLoader.Data(Properties.StreetNames));
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

        public static string City()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CityNames));
        }

        public static string UsaState()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.UsaStates));
        }

        public static string CanadianProvince()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CanadianProvinces));
        }

    }
}
