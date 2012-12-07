using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{
    class Susan
    {

        private static Random _random = new Random(Environment.TickCount);

        private static List<string> _firstNames = LoadStrings(Angie.Defaults.FILE_FIRST_NAMES);
        private static List<string> _lastNames = LoadStrings(Angie.Defaults.FILE_LAST_NAMES);
        private static List<string> _words = LoadStrings(Angie.Defaults.FILE_WORDS);
        
        internal static string StringFill(string propertyName)
        {
            int index = 0;
            switch (propertyName.ToLower())
            {
                case "firstname":
                case "fname":
                case "first_name":
                    index = _random.Next(0, _firstNames.Count());
                    return _firstNames[index];

                case "lastname":
                case "lname":
                case "last_name":
                    index = _random.Next(0, _lastNames.Count());
                    return _lastNames[index];
                
                default:
                    index = _random.Next(0, _words.Count());
                    return _words[index];
            }

        }

        internal static object IntFill(string propertyName, int min, int max)
        {
            switch (propertyName.ToLower())
            {
                case "age":
                    return Math.Abs(_random.Next(min, max));
                default:
                    return _random.Next(min, max);
            }
        }

        private static List<string> LoadStrings(string resourceName)
        {

            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var filename = string.Format(@"Resources\{0}.{1}.txt",resourceName, culture);

            if (File.Exists(filename))
            {
                return File.ReadAllLines(filename).ToList();
            }

            // fallback
            string failedStringLoad = string.Format(Angie.Defaults.STRING_LOAD_FAIL, resourceName);
            return new List<string>() { failedStringLoad };
        }



    }
}
