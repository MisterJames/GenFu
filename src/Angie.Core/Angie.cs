using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public static DateTime MakeDate(DateRules rules)
        {
            // grab a copy of the current config
            var minDate = _minDateTime;
            var maxDate = _maxDateTime;

            // apply rule restrictions
            if (rules == DateRules.Within1Year)
            {
                _minDateTime = DateTime.Now.AddYears(-1);
                _maxDateTime = DateTime.Now.AddYears(1);
            }

            if (rules == DateRules.Within10Years)
            {
                _minDateTime = DateTime.Now.AddYears(-10);
                _maxDateTime = DateTime.Now.AddYears(10);
            }

            if (rules == DateRules.Within25years)
            {
                _minDateTime = DateTime.Now.AddYears(-25);
                _maxDateTime = DateTime.Now.AddYears(25);
            }

            if (rules == DateRules.Within50Years)
            {
                _minDateTime = DateTime.Now.AddYears(-50);
                _maxDateTime = DateTime.Now.AddYears(50);
            }

            if (rules == DateRules.Within100Years)
            {
                _minDateTime = DateTime.Now.AddYears(-100);
                _maxDateTime = DateTime.Now.AddYears(100);
            }

            if (rules == DateRules.FutureDates)
                _minDateTime = DateTime.Now;

            if (rules == DateRules.PastDate)
                _maxDateTime = DateTime.Now;

            return Susan.DateTimeFill("", _minDateTime, _maxDateTime);
        }

        public class Defaults
        {
            public const int MIN_INT = 1;
            public const int MAX_INT = 100;
            public const int LIST_COUNT = 25;

            public static DateTime MIN_DATETIME = DateTime.Now.AddDays(-30);
            public static DateTime MAX_DATETIME = DateTime.Now.AddDays(30);
            
            public static string FILE_DOMAIN_NAMES = "DomainNames";
            public const string FILE_FIRST_NAMES = "FirstNames";
            public const string FILE_LAST_NAMES = "LastNames";
            public const string FILE_TITLES = "Titles";
            public const string FILE_WORDS = "Words";
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
