using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Angela.vNext.Reflection;

namespace GenFu
{
    public class A : GenFu { }
    

    public class Eh : GenFu { }

    public partial class GenFu
    {
        private static GenFu _genfu = new GenFu();
        private static FillerManager _fillerManager = new FillerManager();

        private static int _listCount = GenFu.Defaults.LIST_COUNT;

        static GenFu()
        {
            _fillerManager = new FillerManager();
            Random = new Random();
        }

        public static T New<T>() where T : new()
        {
            return (T) New(typeof(T));
        }

        public static object New(Type type)
        {
            object instance = Activator.CreateInstance(type);
            return New(instance);
        }

        public static T New<T>(T instance)
        {
            return (T) New((object) instance);
      
        }

        public static object New(object instance)
        {
            if (instance != null)
            {
                var type = instance.GetType();
                foreach (var property in type.GetTypeInfo().GetAllProperties())
                {
                    if (!DefaultValueChecker.HasValue(instance, property) && property.CanWrite)
                    {
                        SetPropertyValue(instance, property);
                    }
                }
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => !x.IsSpecialName && x.GetBaseDefinition().DeclaringType != typeof(object)))
                {
                    if (method.GetParameters().Count() == 1)
                    {
                        CallSetterMethod(instance, method);
                    }
                }

            }
            return instance;
        }


        public static List<T> ListOf<T>() where T : new()
        {
            return ListOf(typeof(T)).Cast<T>().ToList();
        }

        public static List<object> ListOf(Type type)
        {
            return BuildList(type, _listCount);
        }
        
        public static List<T> ListOf<T>(int personCount) where T : new()
        {
            return ListOf(typeof(T), personCount).Cast<T>().ToList();
        }

        public static List<object> ListOf(Type type, int personCount)
        {
            return BuildList(type, personCount);
        }

        private static List<object> BuildList(Type type, int itemCount)
        {
            var result = new List<object>();

            for (int i = 0; i < itemCount; i++)
            {
                result.Add(GenFu.New(type));
            }

            return result;
        }

        private static void SetPropertyValue(object instance, PropertyInfo property)
        {
            IPropertyFiller filler = _fillerManager.GetFiller(property);
            property.SetValue(instance, filler.GetValue(instance), null);
        }
        
        private static void CallSetterMethod(object instance, MethodInfo method)
        {
            IPropertyFiller filler = _fillerManager.GetMethodFiller(method);
            if (filler != null)
                method.Invoke(instance, new[] {filler.GetValue(instance)});
        }



        public static DateTime MinDateTime
        {
            get {  return new GenericFillerDefaults(_fillerManager).GetMinDateTime(); }

            set
            {
                new GenericFillerDefaults(_fillerManager).SetMinDateTime(value);
            }
        }

        public static DateTime MaxDateTime
        {
            get { return new GenericFillerDefaults(_fillerManager).GetMaxDateTime(); }
            set
            {
                new GenericFillerDefaults(_fillerManager).SetMaxDateTime(value);
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
            
            public static double SEED_PERCENTAGE = 0.2;

            public const string FILE_DOMAIN_NAMES = "DomainNames";
            public const string FILE_FIRST_NAMES = "FirstNames";
            public const string FILE_LAST_NAMES = "LastNames";
            public const string FILE_PERSON_TITLES = "PersonTitles";
            public const string FILE_TITLES = "Titles";
            public const string FILE_WORDS = "Words";
            public const string FILE_STREET_NAMES = "StreetNames";
            public const string FILE_CITY_NAMES = "CityNames";
            public const string FILE_USA_STATE_NAMES = "USAStateNames";
            public const string FILE_USA_STATE_ABREVIATIONS = "USAStateAbreviations";
            public const string FILE_CDN_PROVINCE_NAMES = "CanadianProvinceNames";
            public const string FILE_CDN_PROVINCE_ABREVIATIONS = "CanadianProvinceAbreviations";
            public const string FILE_MUSIC_ARTIST = "MusicArtists";
            public const string FILE_MUSIC_ALBUM = "MusicAlbums";
            public const string FILE_INGREDIENTS = "Ingredients";
            public const string FILE_COMPANY_NAMES = "CompanyNames";
            public const string FILE_INDUSTRIES = "Industries";
            
            public const string STRING_LOADFAIL = "The resource list for {0} failed to load.";
        }


    }



}
