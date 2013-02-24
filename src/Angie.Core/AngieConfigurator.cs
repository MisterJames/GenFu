using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

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
        
        public AngieConfigurator Fill<T>(string propertyName, Func<T> filler)
        {
            var propName = propertyName.ToLower();
            if (!Susan.PropertyFillers.ContainsKey(propName))
                Susan.PropertyFillers.Add(propName, filler);
            return this;
        }

        public AngieConfigurator Fill<T1, T2>(Expression<Func<T1, T2>> expression, Func<T2> filler)
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

        public List<T> MakeList<T>(int count) where T : new()
        {
            return FastList<T>(count);
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

    public class AngieConfigurator<T> : AngieConfigurator where T : new()
    {
        public AngieConfigurator(Angie angie, Maggie maggie)
            : base(angie, maggie)
        {
        }

        public static T FastMake()
        {
            return Angie.FastMake<T>();
        }

        public static T FastFill(T instance)
        {
            return Angie.FastFill(instance);
        }

        public T Make()
        {
            return Angie.FastMake<T>();
        }

        public static List<T> FastList()
        {
            return Angie.FastList<T>();
        }

        public static List<T> FastList(int count)
        {
            return Angie.FastList<T>(count);
        }

        public List<T> MakeList()
        {
            return FastList<T>();
        }


        private PropertyInfo GetPropertyInfoFromExpression<T2>(Expression<Func<T, T2>> expression)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            return propertyInfo;
        }

        public AngieConfigurator<T> Fill<T2>(Expression<Func<T, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(propertyInfo.Name, typeof(T), filler);
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        public AngieIntegerConfigurator<T> Fill(Expression<Func<T, int>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieIntegerConfigurator<T>(_angie, _maggie, propertyInfo);
        }
        public AngieDecimalConfigurator<T> Fill(Expression<Func<T, decimal>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieDecimalConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        public AngieStringConfigurator<T> Fill(Expression<Func<T, string>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieStringConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        public AngieDateTimeConfigurator<T> Fill(Expression<Func<T, DateTime>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieDateTimeConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        public AngieComplexPropertyConfigurator<T, T2> Fill<T2>(Expression<Func<T, T2>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieComplexPropertyConfigurator<T, T2>(_angie, _maggie, propertyInfo);
        }
    }
}