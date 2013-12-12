using System;
using System.Reflection;
using System.Collections.Generic;

namespace Angela.Core
{
    public partial class Angie
    {
        private static Angie _angie = new Angie();
        private static Maggie _maggie = new Maggie();

        private static int _listCount = Defaults.LIST_COUNT;

        static Angie()
        {
            _maggie = new Maggie();
            Random = new Random();
        }

        public static T FastMake<T>() where T : new()
        {
            var instance = new T();

            FastFill(instance);

            return instance;
        }

        public static T FastFill<T>(T instance)
        {
            if (instance != null)
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!Chastity.HasValue<T>(instance, property) && property.CanWrite)
                    {
                        SetPropertyValue<T>(instance, property);
                    }
                }
            }
            return instance;
        }

        public T Make<T>() where T : new()
        {
            var instance = new T();

            FastFill<T>(instance);

            return instance;
        }

        public static List<T> FastList<T>() where T : new()
        {
            return BuildList<T>(_listCount);
        }
        
        public static List<T> FastList<T>(int personCount) where T : new()
        {
            return BuildList<T>(personCount);
        }

        public List<T> MakeList<T>() where T : new()
        {
            return FastList<T>();
        }

        private static List<T> BuildList<T>(int itemCount) where T : new()
        {
            var result = new List<T>();

            for (int i = 0; i < itemCount; i++)
            {
                result.Add(Angie.FastMake<T>());
            }

            return result;
        }

        private static void SetPropertyValue<T>(T instance, PropertyInfo property)
        {
            IPropertyFiller filler = _maggie.GetFiller(property);
            property.SetValue(instance, filler.GetValue(), null);
        }

        public static DateTime MinDateTime
        {
            get { return _maggie.GetMinDateTime(); }

            set
            {
                _maggie.SetMinDateTime(value);
            }
        }

        public static DateTime MaxDateTime
        {
            get { return _maggie.GetMaxDateTime(); }
            set
            {
                _maggie.SetMaxDateTime(value);
            }
        }

        public static Random Random { get; private set; }

        public class Defaults
        {
            public const int MIN_INT = 1;
            public const int MAX_INT = 100;

            public static short MIN_SHORT = 1;
            public static short MAX_SHORT = Int16.MaxValue;

            
            public const decimal MIN_DECIMAL = 0;
            public const decimal MAX_DECIMAL = 100;

            public const int LIST_COUNT = 25;

            public static DateTime MIN_DATETIME = DateTime.Now.AddYears(-30);
            public static DateTime MAX_DATETIME = DateTime.Now.AddYears(30);
            

            public const string FILE_DOMAIN_NAMES = "DomainNames";
            public const string FILE_FIRST_NAMES = "FirstNames";
            public const string FILE_LAST_NAMES = "LastNames";
            public const string FILE_TITLES = "Titles";
            public const string FILE_WORDS = "Words";
            public const string FILE_STREET_NAMES = "StreetNames";
            public const string FILE_CITY_NAMES = "CityNames";
            public const string FILE_USA_STATE_NAMES = "USAStateNames";
            public const string FILE_CDN_PROVINCE_NAMES = "CanadianProvinceNames";
            public const string FILE_MUSIC_ARTIST = "MusicArtists";
            public const string FILE_MUSIC_ALBUM = "MusicAlbums";
            public const string INGREDIENTS = "Ingredients";
            
            public const string STRING_LOADFAIL = "The resource list for {0} failed to load.";
        }


    }



}
