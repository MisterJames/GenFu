using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

namespace GenFu
{
    public class ResourceLoader
    {
        private static Dictionary<Properties, List<string>> _data;

        static ResourceLoader()
        {
            _data = new Dictionary<Properties, List<string>>();

            _data.Add(Properties.FirstNames, LoadStrings(GenFu.Defaults.FILE_FIRST_NAMES));
            _data.Add(Properties.LastNames, LoadStrings(GenFu.Defaults.FILE_LAST_NAMES));
            _data.Add(Properties.PersonTitles, LoadStrings(GenFu.Defaults.FILE_PERSON_TITLES));
            _data.Add(Properties.Words, LoadStrings(GenFu.Defaults.FILE_WORDS));
            _data.Add(Properties.Titles, LoadStrings(GenFu.Defaults.FILE_TITLES));
            _data.Add(Properties.Domains, LoadStrings(GenFu.Defaults.FILE_DOMAIN_NAMES));
            _data.Add(Properties.StreetNames, LoadStrings(GenFu.Defaults.FILE_STREET_NAMES));
            _data.Add(Properties.CityNames, LoadStrings(GenFu.Defaults.FILE_CITY_NAMES));
            _data.Add(Properties.CanadianProvinces, LoadStrings(GenFu.Defaults.FILE_CDN_PROVINCE_NAMES));
            _data.Add(Properties.CanadianProvinceAbreviations, LoadStrings(GenFu.Defaults.FILE_CDN_PROVINCE_ABREVIATIONS));
            _data.Add(Properties.UsaStates, LoadStrings(GenFu.Defaults.FILE_USA_STATE_NAMES));
            _data.Add(Properties.UsaStateAbreviations, LoadStrings(GenFu.Defaults.FILE_USA_STATE_ABREVIATIONS));
            _data.Add(Properties.MusicArtists, LoadStrings(GenFu.Defaults.FILE_MUSIC_ARTIST));
            _data.Add(Properties.MusicAlbums, LoadStrings(GenFu.Defaults.FILE_MUSIC_ALBUM));
            _data.Add(Properties.Ingredients, LoadStrings(GenFu.Defaults.FILE_INGREDIENTS));
            _data.Add(Properties.CompanyNames, LoadStrings(GenFu.Defaults.FILE_COMPANY_NAMES));
            _data.Add(Properties.Industries, LoadStrings(GenFu.Defaults.FILE_INDUSTRIES));
            _data.Add(Properties.Injuries, LoadStrings(GenFu.Defaults.FILE_INJURIES));
            _data.Add(Properties.Genders, LoadStrings(GenFu.Defaults.FILE_GENDERS));
            _data.Add(Properties.Drugs, LoadStrings(GenFu.Defaults.FILE_DRUGS));
            _data.Add(Properties.Lorem, LoadStrings(GenFu.Defaults.FILE_LOREM));
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
            var namespaceName = "GenFu";

            //todo: correct this format when resource strings/names are fixed by .net team
            filename = string.Format("{0}.Resources.{1}.txt", namespaceName, resourceName);
            
            List<string> lines = new List<string>();
            try
            {
                var asm = typeof(ResourceLoader).GetTypeInfo().Assembly;
                var stream = asm.GetManifestResourceStream(filename);
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line); // Add to list.
                    }
                }

            }
            catch (Exception e)
            {
                // fallback - add one empty string
                lines.Add(string.Empty);
            }

            return lines;

        }

        public static void ReplacePropertyData(Properties propertyType, string filename)
        {
            if (File.Exists(filename))
            {
                var values = File.ReadLines(filename).ToList();
                _data[propertyType] = values;
            }                
        }
    }
}
