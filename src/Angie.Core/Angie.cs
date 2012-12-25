using System;
using System.Collections.Generic;
using System.Reflection;

namespace Angela.Core
{
    public partial class Angie
    {
        private static Angie _angie = new Angie();

        private static int _minInt = Defaults.MIN_INT;
        private static int _maxInt = Defaults.MAX_INT;
        private static int _listCount = Defaults.LIST_COUNT;

        private static DateTime _minDateTime = Defaults.MIN_DATETIME;
        private static DateTime _maxDateTime = Defaults.MAX_DATETIME;


        public static T FastMake<T>() where T : new()
        {
            var instance = new T();

            FastFill<T>(instance);

            return instance;
        }

        public static T FastFill<T>(T instance)
        {
            if (instance != null)
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    if (!Chastity.HasValue<T>(instance, property))
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

        private static List<T> BuildList<T>(int personCount) where T : new()
        {
            var result = new List<T>();

            for (int i = 0; i < personCount; i++)
            {
                result.Add(Angie.FastMake<T>());
            }

            return result;
        }

        private static void SetPropertyValue<T>(T instance, PropertyInfo property)
        {
            var propName = property.Name.ToString().ToLower();
            var customFillerExists = Susan.PropertyFillers.ContainsKey(propName);

            // try first our custom fillers for any objects
            if (customFillerExists)
            {
                var filler = Susan.PropertyFillers[propName] as Func<object>;
                if (filler != null)
                {
                    property.SetValue(instance, filler.Invoke(), null);
                }                
            }

            // try value types and other known types we can test for
            switch (property.PropertyType.Name.ToLower())
            {
                case "int32":
                    if (customFillerExists)
                        property.SetValue(instance, ((Func<int>)Susan.PropertyFillers[propName]).Invoke(), null);
                    else
                        property.SetValue(instance, Susan.IntFill(property.Name, _minInt, _maxInt), null);
                    break;
                case "string":
                    if (customFillerExists)
                        property.SetValue(instance, ((Func<string>)Susan.PropertyFillers[propName]).Invoke(), null);
                    else
                        property.SetValue(instance, Susan.StringFill(property.Name), null);
                    break;
                case "datetime":
                    if (customFillerExists)
                        property.SetValue(instance, ((Func<DateTime>)Susan.PropertyFillers[propName]).Invoke(), null);
                    else
                        property.SetValue(instance, Susan.DateTimeFill(property.Name, _minDateTime, _maxDateTime), null);
                    break;
                default:
                    break;
            }
        }

        public static DateTime MinDateTime
        {
            get
            {
                return _minDateTime;
            }

            set
            {
                _minDateTime = value;
            }
        }

        public static DateTime MaxDateTime
        {
            get
            {
                return _maxDateTime;
            }
            set
            {
                _maxDateTime = value;
            }
        }

        public class Defaults
        {
            public const int MIN_INT = 1;
            public const int MAX_INT = 100;
            public const int LIST_COUNT = 25;

            public static DateTime MIN_DATETIME = DateTime.Now.AddDays(-30);
            public static DateTime MAX_DATETIME = DateTime.Now.AddDays(30);
            
            public const string FILE_DOMAIN_NAMES = "DomainNames";
            public const string FILE_FIRST_NAMES = "FirstNames";
            public const string FILE_LAST_NAMES = "LastNames";
            public const string FILE_TITLES = "Titles";
            public const string FILE_WORDS = "Words";
            public const string FILE_STREET_NAMES = "StreetNames";
            public const string FILE_CITY_NAMES = "CityNames";
            public const string FILE_USA_STATE_NAMES = "USAStateNames";
            public const string FILE_CDN_PROVINCE_NAMES = "CanadianProvinceNames";
            public const string STRING_LOAD_FAIL = "The resource list for {0} failed to load.";
        }


    }

    [Flags]
    public enum DateRules
    {
        FutureDates = 0,
        Within1Year = 1,
        Within10Years = 2,
        Within25years = 4,
        Within50Years = 8,
        Within100Years = 16,
        PastDate = 32
    }

}
