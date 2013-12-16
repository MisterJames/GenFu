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

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target property type</typeparam>
        /// <param name="propertyName">The name of the target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator Fill<T>(string propertyName, Func<T> filler)
        {
            var propName = propertyName.ToLower();
            if (!ResourceLoader.PropertyFillers.ContainsKey(propName))
                ResourceLoader.PropertyFillers.Add(propName, filler);
            return this;
        }

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T1">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator Fill<T1, T2>(Expression<Func<T1, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            CustomFiller<T2> customFiller = new CustomFiller<T2>(propertyInfo.Name, typeof(T1), filler);
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Create a new object
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>An object filled with random data</returns>
        public static T FastMake<T>() where T : new()
        {
            return Angie.FastMake<T>();
        }

        /// <summary>
        /// Fill an existing object with random data
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="instance">The instance to fill</param>
        /// <returns>The instance filled with random data</returns>
        public static T FastFill<T>(T instance)
        {
            return Angie.FastFill(instance);
        }

        /// <summary>
        /// Create a new object
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <returns>An object filled with random data</returns>
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
        
        private MethodInfo GetMethodInfoFromExpression(Expression<Action<T>> expression)
        {

            var methodCall = expression.Body as MethodCallExpression;
            if (methodCall != null)
            {
                return methodCall.Method;
            }
            return null;
        }

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> Fill<T2>(Expression<Func<T, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(propertyInfo.Name, typeof(T), filler);
            _maggie.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Configure how the specified integer property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieIntegerConfigurator<T> Fill(Expression<Func<T, int>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieIntegerConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified short property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieShortConfigurator<T> Fill(Expression<Func<T, short>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieShortConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified decimal property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieDecimalConfigurator<T> Fill(Expression<Func<T, decimal>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieDecimalConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified string property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieStringConfigurator<T> Fill(Expression<Func<T, string>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieStringConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified DateTime property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieDateTimeConfigurator<T> Fill(Expression<Func<T, DateTime>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieDateTimeConfigurator<T>(_angie, _maggie, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public AngieComplexPropertyConfigurator<T, T2> Fill<T2>(Expression<Func<T, T2>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new AngieComplexPropertyConfigurator<T, T2>(_angie, _maggie, propertyInfo);
        }




        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target method parameter type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="filler">A function that will return a method parameter set value</param>
        /// <returns>A configurator for the target object type</returns>
        public AngieConfigurator<T> MemberFill<T2>(Expression<Action<T>> expression, Func<T2> filler)
        {
            MethodInfo methodInfo = GetMethodInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(methodInfo.Name, typeof(T), filler);
            _maggie.RegisterFiller(customFiller);
            return this;
        }


        /// <summary>
        /// Configure how the specified property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target method parameter type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified method of the target object type</returns>
        public AngieComplexPropertyConfigurator<T, T2> MemberFill<T2>(Expression<Action<T>> expression)
        {
            MethodInfo methodInfo = GetMethodInfoFromExpression(expression);
            IPropertyFiller filler = _maggie.GetGenericFillerForType(methodInfo.GetParameters()[0].ParameterType);
            PropertyFiller<T2> customFiller = new CustomFiller<T2>(methodInfo.Name,  typeof(T), () => (T2)filler.GetValue());
            _maggie.RegisterFiller(customFiller);
            return new AngieComplexPropertyConfigurator<T, T2>(_angie, _maggie, methodInfo);
        }
    }
}