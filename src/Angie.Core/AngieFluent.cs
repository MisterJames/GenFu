using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Angela.Core.Fillers;

namespace Angela.Core
{
    public class AngieConfigurator
    {
        protected Angie _angie;
        protected Maggie _maggie;

        public AngieConfigurator(Angie angie, Maggie maggie)
        {
            _angie = angie;
            _maggie = maggie;
        }


        public AngieConfigurator MaxInt(int max)
        {
            _maggie.SetMaxInt(max);
            return this;

        }

        public AngieConfigurator MinInt(int min)
        {
            _maggie.SetMinInt(min);
            return this;
        }

        public AngieConfigurator IntRange(int min, int max)
        {
            MinInt(min);
            MaxInt(max);

            return this;

        }

        public AngieConfigurator ListCount(int count)
        {
            _angie.ListCount(count);
            return this;
        }

        public AngieConfigurator DateRange(DateTime minDateTime, DateTime maxDateTime)
        {
            _maggie.SetMinDateTime(minDateTime);
            _maggie.SetMaxDateTime(maxDateTime);
            return this;
        }

        public AngieConfigurator FillBy<T>(string propertyName, Func<T> filler)
        {
            var propName = propertyName.ToLower();
            if (!Susan.PropertyFillers.ContainsKey(propName))
                Susan.PropertyFillers.Add(propName, filler);
            return this;
        }

        public AngieConfigurator FillBy<T1, T2>(Expression<Func<T1, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            CustomFiller<T2> customFiller = new CustomFiller<T2>(propertyInfo.Name, typeof(T1), filler);
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public static T FastMake<T>() where T : new()
        {
            return Angie.FastMake<T>();
        }

        public static T FastFill<T>(T instance)
        {
            return Angie.FastFill(instance);
        }

        public T Make<T>() where T : new()
        {
            return Angie.FastMake<T>();
        }

        public static List<T> FastList<T>() where T : new()
        {
            return Angie.FastList<T>();
        }

        public static List<T> FastList<T>(int count) where T : new()
        {
            return Angie.FastList<T>(count);
        }

        public List<T> MakeList<T>() where T : new()
        {
            return FastList<T>();
        }

        public Angie Angie
        {
            get { return _angie; }
        }

        public Maggie Maggie
        {
            get { return _maggie; }
        }
    }

    public class AngieConfigurator<T> : AngieConfigurator
    {
        public AngieConfigurator(Angie angie, Maggie maggie) : base(angie, maggie)
        {
        }

        public AngieIntegerConfigurator<T> WithProperty(Expression<Func<T, int>> expression)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            return new AngieIntegerConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        public AngieStringConfigurator<T> WithProperty(Expression<Func<T, string>> expression)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            return new AngieStringConfigurator<T>(_angie, _maggie, propertyInfo);
        }
    }

    public class AngieIntegerConfigurator<T> : AngieConfigurator<T>
    {
        private PropertyInfo _propertyInfo;

        public AngieIntegerConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo) : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public AngieIntegerConfigurator<T> WithinRange(int min, int max)
        {
            IntFiller filler = new IntFiller(typeof(T), _propertyInfo.Name, min, max);
            _maggie.RegisterFiller(filler);
            return this;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }

    public class AngieStringConfigurator<T> : AngieConfigurator<T>
    {
        private PropertyInfo _propertyInfo;

        public AngieStringConfigurator(Angie angie, Maggie maggie, PropertyInfo propertyInfo) : base(angie, maggie)
        {
            _propertyInfo = propertyInfo;
        }

        public PropertyInfo PropertyInfo
        {
            get { return _propertyInfo; }
        }
    }


    public partial class Angie
    {
        /// <summary>
        /// Resets Angie to default state for next generation
        /// and allows access to fluent interface.
        /// </summary>
        /// <returns></returns>
        public static AngieConfigurator Configure()
        {
            Reset();
            return new AngieConfigurator(_angie, _maggie);
        }

        public static AngieConfigurator<T> Configure<T>()
        {
            return new AngieConfigurator<T>(_angie, _maggie);
        }

        public static AngieConfigurator Set()
        {
            return new AngieConfigurator(_angie, _maggie);
        }

        public static void Reset()
        {
            _maggie.SetMinInt(Angie.Defaults.MIN_INT);
            _maggie.SetMaxInt(Angie.Defaults.MAX_INT);
            _listCount = Angie.Defaults.LIST_COUNT;

            _maggie.SetMinDateTime(DateTime.MinValue);
            _maggie.SetMaxDateTime(DateTime.MaxValue);

            Susan.PropertyFillers.Clear();
        }

        public void ListCount(int count)
        {
            _listCount = count;
        }
    }
}