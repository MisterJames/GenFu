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
    class Susan
    {

        private static Random _random = new Random(Environment.TickCount);

        private static List<string> _firstNames = LoadStrings(Angie.Defaults.FILE_FIRST_NAMES);
        private static List<string> _lastNames = LoadStrings(Angie.Defaults.FILE_LAST_NAMES);
        private static List<string> _words = LoadStrings(Angie.Defaults.FILE_WORDS);
        private static List<string> _titles = LoadStrings(Angie.Defaults.FILE_TITLES);

        private static Dictionary<string, object> _propertyFillers = new Dictionary<string, object>();

        internal static Dictionary<string, object> PropertyFillers
        {
            get { return _propertyFillers; }
        }
        
        internal static string StringFill(string propertyName)
        {
            var propName = propertyName.ToLower();

            // for common property names we'll try a resource
            int index = 0;
            switch (propName)
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

                case "title":
                    index = _random.Next(0, _titles.Count());
                    return _titles[index];
                
                default:
                    // aww, shucks.  we did our best!
                    index = _random.Next(0, _words.Count());
                    return _words[index];
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
