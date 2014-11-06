using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

namespace Angela.Core
{
    public class ResourceLoader
    {
        private static Dictionary<Properties, List<string>> _data;

        static ResourceLoader()
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
            _data.Add(Properties.MusicArtists, LoadStrings(Angie.Defaults.FILE_MUSIC_ARTIST));
            _data.Add(Properties.MusicAlbums, LoadStrings(Angie.Defaults.FILE_MUSIC_ALBUM));
            _data.Add(Properties.Ingredients, LoadStrings(Angie.Defaults.FILE_INGREDIENTS));
            _data.Add(Properties.CompanyNames, LoadStrings(Angie.Defaults.FILE_COMPANY_NAMES));
            _data.Add(Properties.Industries, LoadStrings(Angie.Defaults.FILE_INDUSTRIES));
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
            //TODO: Test that this path name is correct.
            string path = typeof(ResourceLoader).GetTypeInfo().Assembly.GetName().Name;
          
            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            string filename = string.Format(@"{0}\Resources\{1}.{2}.txt", path, resourceName, culture);

            // attempt load from absolute path
            if (File.Exists(filename))
                return File.ReadLines(filename).ToList();

            // attempt load from relative path
            filename = string.Format(@"Resources\{0}.{1}.txt", resourceName, culture);
            if (File.Exists(filename))
                return File.ReadLines(filename).ToList();

            // attempt load from embedded resource
            //var namespaceName = typeof(Angie).Namespace;
            var namespaceName = "Angie.vNext";

            //todo: correct this format when resource strings/names are fixed by .net team
            filename = string.Format("{0}.Resources.{1}.txt", namespaceName, resourceName);
            filename = string.Format("Resources/{1}.txt", namespaceName, resourceName);

            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(typeof(ResourceLoader).GetTypeInfo().Assembly.GetManifestResourceStream(filename)))
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
                // fallback - add one empty string
                lines.Add(string.Empty);
            }

            return lines;

        }

    }
}
