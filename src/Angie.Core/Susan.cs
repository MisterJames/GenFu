using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        private static Dictionary<string, object> _propertyFillers = new Dictionary<string, object>();

        internal static Dictionary<string, object> PropertyFillers
        {
            get { return _propertyFillers; }
        }
        
        internal static string StringFill(string propertyName)
        {
            var propName = propertyName.ToLower();

            // for common property names we'll try a resource
            switch (propName)
            {
                case "firstname":
                case "fname":
                case "first_name":
                    return FillFirstName();

                case "lastname":
                case "lname":
                case "last_name":
                    return FillLastName();

                case "title":
                    return FillTitle();

                case "email":
                case "emailaddress":
                case "email_address":
                    return FillEmail();

                default:
                    return FillWord();
            }

        }

        internal static int IntFill(string propertyName, int min, int max)
        {
            var propName = propertyName.ToLower();

            // check to see if we can be smart about the name of the prop
            switch (propName)
            {
                case "age":
                    return Math.Abs(_random.Next(min, max));
                default:
                    // oh well, we tried!
                    return _random.Next(min, max);
            }
        }

        internal static DateTime DateTimeFill(string propertyName, DateTime min, DateTime max)
        {
            int totalDays = ((TimeSpan)(max - min)).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return min.AddDays(randomDays).AddSeconds(seconds);
        }
        
        public static string FillWord()
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

        public static string FillTitle()
        {
            int index = _random.Next(0, _titles.Count());
            return _titles[index];
        }

        public static string FillLastName()
        {
            int index = _random.Next(0, _lastNames.Count());
            return _lastNames[index];
        }

        public static string FillFirstName()
        {
            int index = _random.Next(0, _firstNames.Count());
            return _firstNames[index];
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

            return Susan.DateTimeFill("", Angie.MinDateTime, Angie.MaxDateTime);
        }

        private static List<string> LoadStrings(string resourceName)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = Path.GetDirectoryName(path);
            path = path.Replace(@"file:\", "");

            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            string filename = string.Format(@"{0}\Resources\{1}.{2}.txt", path, resourceName, culture);

            if (File.Exists(filename))
                return File.ReadAllLines(filename).ToList();

            filename = string.Format(@"Resources\{0}.{1}.txt", resourceName, culture);
            if (File.Exists(filename))
                return File.ReadAllLines(filename).ToList();


            // fallback
            string failedStringLoad = string.Format(Angie.Defaults.STRING_LOAD_FAIL, resourceName);
            return new List<string>() { failedStringLoad };
        }



    }
}
