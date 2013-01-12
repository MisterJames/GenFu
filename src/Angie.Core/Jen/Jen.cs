using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{
    public partial class Jen
    {

        private static Random _random = new Random(Environment.TickCount);

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

        /// <summary>
        /// Generates a random emails address
        /// </summary>
        /// <returns>A complete email address with a random account and domain.</returns>
        public static string Email()
        {
            int firstNameIndex = _random.Next(0, Susan.Data(Properties.FirstNames).Count());
            int lastNameIndex = _random.Next(0, Susan.Data(Properties.LastNames).Count());
            int domainNameIndex = _random.Next(0, Susan.Data(Properties.Domains).Count());

            // failing test on names with spaces
            string firstname = Susan.Data(Properties.FirstNames)[firstNameIndex].Replace(" ", "");
            string lastname = Susan.Data(Properties.LastNames)[lastNameIndex].Replace(" ", "");

            return string.Format("{0}.{1}@{2}", firstname, lastname, Susan.Data(Properties.Domains)[domainNameIndex]);
        }
        
        /// <summary>
        /// Only uses the specified domain for email generation
        /// </summary>
        /// <param name="domain">The domain that you want to have for all email addresses</param>
        /// <returns>A complete email address for the specified domain.</returns>
        public static string Email(string domain)
        {
            int firstNameIndex = _random.Next(0, Susan.Data(Properties.FirstNames).Count());
            int lastNameIndex = _random.Next(0, Susan.Data(Properties.LastNames).Count());
            return string.Format("{0}.{1}@{2}", Susan.Data(Properties.FirstNames)[firstNameIndex], Susan.Data(Properties.LastNames)[lastNameIndex], domain);
        }

        public static string Title()
        {
            int index = _random.Next(0, Susan.Data(Properties.Titles).Count());
            return Susan.Data(Properties.Titles)[index];
        }

        public static string LastName()
        {
            int index = _random.Next(0, Susan.Data(Properties.LastNames).Count());
            return Susan.Data(Properties.LastNames)[index];
        }

        public static string FirstName()
        {
            int index = _random.Next(0, Susan.Data(Properties.FirstNames).Count());
            return Susan.Data(Properties.FirstNames)[index];
        }

        public static string DomainName()
        {
            int index = _random.Next(0, Susan.Data(Properties.Domains).Count());
            return Susan.Data(Properties.Domains)[index];

        }

        public static string AddressLine()
        {
            int index = _random.Next(0, Susan.Data(Properties.StreetNames).Count());
            var suffixes = new List<string> { "NW", "N", "NE", "E", "SE", "S", "SW", "W" };

            var number = _random.Next(100, 9999);
            number = _random.Next(1, 5) == 5 ? _random.Next(100, 99999) : number;

            var streetName = Susan.Data(Properties.StreetNames)[index];
            var direction = _random.Next(1, 1) > 8 ? suffixes[_random.Next(suffixes.Count)] : string.Empty;

            var result = string.Format("{0} {1} {2}", number, streetName, direction);

            return result;
        }

        public static string AddressLine2()
        {
            string result = string.Empty;

            List<string> units = new List<string> { "Apt ", "Unit ", "#", "Studio " };
            List<string> suffixes = new List<string> { "A", "B", "C", "D", "E", "F", "G" };

            var unit = _random.Next(1, 4) > 2 ? units[_random.Next(units.Count)] : string.Empty;
            var number = _random.Next(100, 999);
            var suffix = _random.Next(1, 4) > 2 ? suffixes[_random.Next(suffixes.Count)] : string.Empty;

            if (unit.Length + suffix.Length != 0)
            {
                result = string.Format("{0}{1}{2}", unit, number, suffix);
                result = _random.Next(1, 4) == 1 ? result : string.Empty;
            }

            return result;
        }

        public static string City()
        {
            int index = _random.Next(0, Susan.Data(Properties.CityNames).Count());
            return Susan.Data(Properties.CityNames)[index];
        }

        public static string UsaState()
        {
            int index = _random.Next(0, Susan.Data(Properties.UsaStates).Count());
            return Susan.Data(Properties.UsaStates)[index];
        }

        public static string CanadianProvince()
        {
            int index = _random.Next(0, Susan.Data(Properties.CanadianProvinces).Count());
            return Susan.Data(Properties.CanadianProvinces)[index];
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
            // grab a copy of the current config

            var minDate = Angie.MinDateTime;
            var maxDate = Angie.MaxDateTime;

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
