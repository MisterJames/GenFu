using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core
{
    public partial class BaseValueGenerator
    {

        protected static Random _random = new Random(Environment.TickCount);

        private static DateTime DateTimeFill(DateTime min, DateTime max)
        {
            int totalDays = (max - min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);

            return min.AddDays(randomDays).AddSeconds(seconds);
        }

        public static string Word()
        {
            // aww, shucks.  we did our best!
            int index = _random.Next(0, Susan.Data(Properties.Words).Count());
            return Susan.Data(Properties.Words)[index];
        }

       

        public static T GetRandomValue<T>(T[] values)
        {
            int index = _random.Next(0, values.Length);
            return values[index];
        }

        public static T GetRandomValue<T>(List<T> values)
        {
            int index = _random.Next(0, values.Count);
            return values[index];
        }

        public static T GetRandomValue<T>(IEnumerable<T> values)
        {
            int index = _random.Next(0, values.Count());
            return values.ElementAt(index);
        }
        
        
       


        public static string AddressLine()
        {
            var suffixes = new List<string> { "NW", "N", "NE", "E", "SE", "S", "SW", "W" };

            var number = _random.Next(100, 9999);
            number = _random.Next(1, 5) == 5 ? _random.Next(100, 99999) : number;

            var streetName = GetRandomValue(Susan.Data(Properties.StreetNames));
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
            return GetRandomValue(Susan.Data(Properties.CityNames));
        }

        public static string UsaState()
        {
            return GetRandomValue(Susan.Data(Properties.UsaStates));
        }

        public static string CanadianProvince()
        {
            return GetRandomValue(Susan.Data(Properties.CanadianProvinces));
        }

        public static string PhoneNumber()
        {
            string result = string.Empty;

            int areacode = _random.Next(200, 799);
            int prefix = _random.Next(200, 799);
            int digits = _random.Next(0, 9999);

            result = string.Format("({0}) {1}-{2:0000}", areacode, prefix, digits);

            return result;
        }

        public static DateTime Date(DateTime earliestDate, DateTime latestDate)
        {
            return DateTimeFill(earliestDate, latestDate);
        }

        public static DateTime Date(DateRules rules)
        {
            // apply rule restrictions
            if (rules == DateRules.Within1Year)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-1);
                Angie.MaxDateTime = DateTime.Now.AddYears(1);
            }

            if (rules == DateRules.Within10Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-10);
                Angie.MaxDateTime = DateTime.Now.AddYears(10);
            }

            if (rules == DateRules.Within25years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-25);
                Angie.MaxDateTime = DateTime.Now.AddYears(25);
            }

            if (rules == DateRules.Within50Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-50);
                Angie.MaxDateTime = DateTime.Now.AddYears(50);
            }

            if (rules == DateRules.Within100Years)
            {
                Angie.MinDateTime = DateTime.Now.AddYears(-100);
                Angie.MaxDateTime = DateTime.Now.AddYears(100);
            }

            if (rules == DateRules.FutureDates)
                Angie.MinDateTime = DateTime.Now;

            if (rules == DateRules.PastDate)
                Angie.MaxDateTime = DateTime.Now;

            return DateTimeFill(Angie.MinDateTime, Angie.MaxDateTime);
        }

    }
}
