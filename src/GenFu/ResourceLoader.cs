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
        private static Dictionary<PropertyType, List<string>> _data;

        static ResourceLoader()
        {
            _data = new Dictionary<PropertyType, List<string>>();

            _data.Add(PropertyType.FirstNames, LoadStrings(GenFu.Defaults.FILE_FIRST_NAMES));
            _data.Add(PropertyType.LastNames, LoadStrings(GenFu.Defaults.FILE_LAST_NAMES));
            _data.Add(PropertyType.PersonTitles, LoadStrings(GenFu.Defaults.FILE_PERSON_TITLES));
            _data.Add(PropertyType.Words, LoadStrings(GenFu.Defaults.FILE_WORDS));
            _data.Add(PropertyType.Titles, LoadStrings(GenFu.Defaults.FILE_TITLES));
            _data.Add(PropertyType.Domains, LoadStrings(GenFu.Defaults.FILE_DOMAIN_NAMES));
            _data.Add(PropertyType.StreetNames, LoadStrings(GenFu.Defaults.FILE_STREET_NAMES));
            _data.Add(PropertyType.CityNames, LoadStrings(GenFu.Defaults.FILE_CITY_NAMES));
            _data.Add(PropertyType.CanadianProvinces, LoadStrings(GenFu.Defaults.FILE_CDN_PROVINCE_NAMES));
            _data.Add(PropertyType.CanadianProvinceAbreviations, LoadStrings(GenFu.Defaults.FILE_CDN_PROVINCE_ABREVIATIONS));
            _data.Add(PropertyType.UsaStates, LoadStrings(GenFu.Defaults.FILE_USA_STATE_NAMES));
            _data.Add(PropertyType.UsaStateAbreviations, LoadStrings(GenFu.Defaults.FILE_USA_STATE_ABREVIATIONS));
            _data.Add(PropertyType.MusicArtists, LoadStrings(GenFu.Defaults.FILE_MUSIC_ARTIST));
            _data.Add(PropertyType.MusicAlbums, LoadStrings(GenFu.Defaults.FILE_MUSIC_ALBUM));
            _data.Add(PropertyType.Ingredients, LoadStrings(GenFu.Defaults.FILE_INGREDIENTS));
            _data.Add(PropertyType.CompanyNames, LoadStrings(GenFu.Defaults.FILE_COMPANY_NAMES));
            _data.Add(PropertyType.Industries, LoadStrings(GenFu.Defaults.FILE_INDUSTRIES));
            _data.Add(PropertyType.Injuries, LoadStrings(GenFu.Defaults.FILE_INJURIES));
            _data.Add(PropertyType.Genders, LoadStrings(GenFu.Defaults.FILE_GENDERS));
            _data.Add(PropertyType.Drugs, LoadStrings(GenFu.Defaults.FILE_DRUGS));
            _data.Add(PropertyType.Lorem, LoadStrings(GenFu.Defaults.FILE_LOREM));
        }

        public static List<string> Data (PropertyType propertyType) 
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
            filename = $"{namespaceName}.Resources.{resourceName}.txt";
            
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
            catch (Exception)
            {
                // fallback - add one empty string
                lines.Add(string.Empty);
            }

            return lines;

        }

        public static void ReplacePropertyData(PropertyType propertyType, string filename)
        {
            if (File.Exists(filename))
            {
                var values = File.ReadLines(filename).ToList();
                _data[propertyType] = values;
            }                
        }
    }
}
