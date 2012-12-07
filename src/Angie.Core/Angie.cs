using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{
    public class Angie
    {
        private static Angie _angie = new Angie();

        private static int _minInt = Defaults.DEFAULT_MIN_INT;
        private static int _maxInt = Defaults.DEFAULT_MAX_INT;
        private static int _listCount = Defaults.DEFAULT_LIST_COUNT;

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
            var result = new List<T>();

            for (int i = 0; i < _listCount; i++)
            {
                result.Add(Angie.FastMake<T>());
            }

            return result;
        }

        private static void SetPropertyValue<T>(T instance, PropertyInfo property)
        {
            switch (property.PropertyType.Name.ToLower())
            {
                case "int32":
                    property.SetValue(instance, Susan.IntFill(property.Name, _minInt, _maxInt), null);
                    break;
                case "string":
                    property.SetValue(instance, Susan.StringFill(property.Name), null);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Resets Angie to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public static Angie Configure()
        {
            _minInt = Defaults.DEFAULT_MIN_INT;
            _maxInt = Defaults.DEFAULT_MAX_INT;
            _listCount = Defaults.DEFAULT_LIST_COUNT;

            return _angie;
        }

        //public Angie SomeSetterIAmComtemplating<T>(Expression<Func<T, object>> property, object value)
        //{
        //    // do something interesting
        //    var propertyInfo = (((UnaryExpression)property.Body)
        //        .Operand as MemberExpression)
        //        .Member as PropertyInfo;

        //    return _angie;
        //}

        public Angie MaxInt(int max)
        {
            _maxInt = max;
            return _angie;
            
        }

        public Angie MinInt(int min)
        {
            _minInt = min;
            return _angie;
        }

        public Angie IntRange(int min, int max)
        {
            _minInt = min;
            _maxInt = max;

            return _angie;

        }

        public Angie ListCount(int count)
        {
            _listCount = count;
            return _angie;
        }

        public class Defaults
        {
            public const int DEFAULT_MIN_INT = 1;
            public const int DEFAULT_MAX_INT = 100;
            public const int DEFAULT_LIST_COUNT = 25;

            public const string FILE_FIRST_NAMES = "FirstNames";
            public const string FILE_LAST_NAMES = "LastNames";
            public const string FILE_WORDS = "Words";
            public const string STRING_LOAD_FAIL = "The resource list for {0} failed to load.";
        }

    }
}
