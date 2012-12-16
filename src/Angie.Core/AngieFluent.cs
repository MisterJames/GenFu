using System;

namespace Angela.Core
{
    public partial class Angie
    {
        /// <summary>
        /// Resets Angie to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public static Angie Configure()
        {
            Reset();

            return _angie;
        }

        public static Angie Set()
        {
            return _angie;
        }

        public static void Reset()
        {
            _minInt = Defaults.MIN_INT;
            _maxInt = Defaults.MAX_INT;
            _listCount = Defaults.LIST_COUNT;

            _minDateTime = DateTime.MinValue;
            _maxDateTime = DateTime.MaxValue;

            Susan.PropertyFillers.Clear();
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

        public Angie DateRange(DateTime minDateTime, DateTime maxDateTime)
        {
            return _angie;
        }

        public Angie FillBy<T>(string propertyName, Func<T> filler)
        {
            var propName = propertyName.ToLower();
            if (!Susan.PropertyFillers.ContainsKey(propName))
                Susan.PropertyFillers.Add(propName, filler);
            return _angie;
        }
    }
}
