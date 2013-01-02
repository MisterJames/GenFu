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
        //private static List<string> _firstNames =           LoadStrings(Angie.Defaults.FILE_FIRST_NAMES);
        //private static List<string> _lastNames =            LoadStrings(Angie.Defaults.FILE_LAST_NAMES);
        //private static List<string> _words =                LoadStrings(Angie.Defaults.FILE_WORDS);
        //private static List<string> _titles =               LoadStrings(Angie.Defaults.FILE_TITLES);
        //private static List<string> _domains =              LoadStrings(Angie.Defaults.FILE_DOMAIN_NAMES);
        //private static List<string> _streetNames =          LoadStrings(Angie.Defaults.FILE_STREET_NAMES);
        //private static List<string> _cityNames =            LoadStrings(Angie.Defaults.FILE_CITY_NAMES);
        //private static List<string> _canadianProvinces =    LoadStrings(Angie.Defaults.FILE_CDN_PROVINCE_NAMES);
        //private static List<string> _usaStates =            LoadStrings(Angie.Defaults.FILE_USA_STATE_NAMES);

        private static Dictionary<Properties, List<string>> _data;

        static Susan()
        {
            _data = new Dictionary<Properties, List<string>>();

            _data.Add(Properties.FirstNames, LoadStrings(Angie.Defaults.FILE_FIRST_NAMES));
            _data.Add(Properties.LastNames, LoadStrings(Angie.Defaults.FILE_LAST_NAMES));
            _data.Add(Properties.Words, LoadStrings(Angie.Defaults.FILE_WORDS));
            _data.Add(Properties.Titles, LoadStrings(Angie.Defaults.FILE_TITLES));
            _data.Add(Properties.Domains, LoadStrings(Angie.Defaults.FILE_DOMAIN_NAMES));
            _data.Add(Properties.StreetNames, LoadStrings(Angie.Defaults.FILE_STREET_NAMES));
            _data.Add(Properties.CityNames, LoadStrings(Angie.Defaults.FILE_CITY_NAMES));
            _data.Add(Properties.CanadianProvinces, LoadStrings(Angie.Defaults.FILE_CDN_PROVINCE_NAMES));
            _data.Add(Properties.UsaStates, LoadStrings(Angie.Defaults.FILE_USA_STATE_NAMES));            

        }

        public static List<string> Data (Properties propertyType) 
        {
            return _data[propertyType];
        }

        private static Dictionary<string, object> _propertyFillers = new Dictionary<string, object>();

        internal static Dictionary<string, object> PropertyFillers
        {
            get { return _propertyFillers; }
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
