using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Angela.Core
{
    public class Susan
    {

        private static Random _random = new Random(Environment.TickCount);

        private static List<string> _firstNames = LoadStrings(Angie.Defaults.FILE_FIRST_NAMES);
        private static List<string> _lastNames = LoadStrings(Angie.Defaults.FILE_LAST_NAMES);
        private static List<string> _words = LoadStrings(Angie.Defaults.FILE_WORDS);
        private static List<string> _titles = LoadStrings(Angie.Defaults.FILE_TITLES);
        private static List<string> _domains = LoadStrings(Angie.Defaults.FILE_DOMAIN_NAMES);
        private static List<string> _streetNames = LoadStrings(Angie.Defaults.FILE_STREET_NAMES);
        private static List<string> _cityNames = LoadStrings(Angie.Defaults.FILE_CITY_NAMES);
        private static List<string> _canadianProvinces = LoadStrings(Angie.Defaults.FILE_CDN_PROVINCE_NAMES);
        private static List<string> _usaStates = LoadStrings(Angie.Defaults.FILE_USA_STATE_NAMES);

        private static Dictionary<string, object> _propertyFillers = new Dictionary<string, object>();

        internal static Dictionary<string, object> PropertyFillers
        {
            get { return _propertyFillers; }
        }

        private static DateTime DateTimeFill(DateTime min, DateTime max)
        {
            int totalDays = (max - min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return min.AddDays(randomDays).AddSeconds(seconds);
        }

        public static string GetWord()
        {
            // aww, shucks.  we did our best!
            int index = _random.Next(0, _words.Count());
            return _words[index];
        }

        public static string FillEmail()
        {
            int firstNameIndex = _random.Next(0, _firstNames.Count());
            int lastNameIndex = _random.Next(0, _lastNames.Count());
            int domainNameIndex = _random.Next(0, _domains.Count());
            return string.Format("{0}.{1}@{2}", _firstNames[firstNameIndex], _lastNames[lastNameIndex], _domains[domainNameIndex]);
        }

        public static string GetTitle()
        {
            int index = _random.Next(0, _titles.Count());
            return _titles[index];
        }

        public static string GetLastName()
        {
            int index = _random.Next(0, _lastNames.Count());
            return _lastNames[index];
        }

        public static string GetFirstName()
        {
            int index = _random.Next(0, _firstNames.Count());
            return _firstNames[index];
        }

        public static string GetDomainName()
        {
            int index = _random.Next(0, _domains.Count());
            return _domains[index];

		}
			
        public static string FillAddressLine()
        {
            int index = _random.Next(0, _streetNames.Count());
            var suffixes = new List<string> { "NW", "N", "NE", "E", "SE", "S", "SW", "W" };

            var number = _random.Next(100, 9999);
            number = _random.Next(1, 5) == 5 ? _random.Next(100, 99999 ) : number;

            var streetName = _streetNames[index];
            var direction = _random.Next(1, 1) > 8 ? suffixes[_random.Next(suffixes.Count)] : string.Empty;

            var result = string.Format("{0} {1} {2}", number, streetName, direction);

            return result;
        }

        public static string FillAddressLine2()
        {
            string result = string.Empty;

            List<string> units = new List<string> { "Apt ", "Unit ", "#", "Studio "};
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

        public static string FillCity()
        {
            int index = _random.Next(0, _cityNames.Count());
            return _cityNames[index];
        }

        public static string FillUsaState()
        {
            int index = _random.Next(0, _usaStates.Count());
            return _usaStates[index];
        }

        public static string FillCanadianProvince()
        {
            int index = _random.Next(0, _canadianProvinces.Count());
            return _canadianProvinces[index];
        }

        public static string FillPhoneNumber()
        {
            string result = string.Empty;

            int areacode = _random.Next(200, 799);
            int prefix = _random.Next(200, 799);
            int digits = _random.Next(0, 9999);

            result = string.Format("({0}) {1}-{2:0000}", areacode, prefix, digits);

            return result;
        }

        public static DateTime FillDate(DateRules rules)
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

        private static List<string> LoadStrings(string resourceName)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = Path.GetDirectoryName(path);
            path = path.Replace(@"file:\", "");

            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            string filename = string.Format(@"{0}\Resources\{1}.{2}.txt", path, resourceName, culture);

            // attempt load from absolute path
            if (File.Exists(filename))
                return File.ReadAllLines(filename).ToList();

            // attempt load from relative path
            filename = string.Format(@"Resources\{0}.{1}.txt", resourceName, culture);
            if (File.Exists(filename))
                return File.ReadAllLines(filename).ToList();

            // attempt load from embedded resource
            var namespaceName = typeof(Angie).Namespace;
            filename = string.Format("{0}.Resources.{1}.txt", namespaceName, resourceName);
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(filename)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line); // Add to list.
                    }
                }

            }
            catch (Exception)
            {
                // fallback
                string failedStringLoad = string.Format(Angie.Defaults.STRING_LOAD_FAIL, resourceName);
                lines.Add(failedStringLoad);
            }

            return lines;

        }



    }
}
