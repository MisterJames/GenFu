using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace GenFu
{
    public class GenFuConfigurator
    {
        protected GenFuInstance _genfu;
        protected FillerManager _fillerManager;

        public GenFuConfigurator(GenFuInstance genfu, FillerManager filterManager)
        {
            _genfu = genfu;
            _fillerManager = filterManager;
        }

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target property type</typeparam>
        /// <param name="propertyName">The name of the target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator Fill<T>(string propertyName, Func<T> filler)
        {
            var propName = propertyName.ToLower();
            if (!ResourceLoader.PropertyFillers.ContainsKey(propName))
                ResourceLoader.PropertyFillers.Add(propName, filler);
            return this;
        }

        /// <summary>
        /// Fill the specified property with the specified value
        /// </summary>
        /// <typeparam name="T1">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="value">A property value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator Fill<T1, T2>(Expression<Func<T1, T2>> expression, T2 value)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            CustomFiller<T2> customFiller = new CustomFiller<T2>(_genfu,propertyInfo.Name, typeof(T1), () => value);
            _fillerManager.RegisterFiller(customFiller);
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
        public GenFuConfigurator Fill<T1, T2>(Expression<Func<T1, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = (expression.Body as MemberExpression).Member as PropertyInfo;
            CustomFiller<T2> customFiller = new CustomFiller<T2>(_genfu, propertyInfo.Name, typeof(T1), filler);
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Replaces the well-known property with a user-supplied list of values loaded from the specified file
        /// </summary>
        /// <param name="propertyType">The property for which you wish to supply values</typeparam>
        /// <param name="filename">A value-per-line file with values for the property</typeparam>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator Data(PropertyType propertyType, string filename)
        {
            ResourceLoader.ReplacePropertyData(propertyType, filename);
            return this;
        }

        public GenFuInstance GenFu
        {
            get { return _genfu; }
        }

        public FillerManager Maggie
        {
            get { return _fillerManager; }
        }
    }

    public class GenFuConfigurator<T> : GenFuConfigurator where T : new()
    {
        public GenFuConfigurator(GenFuInstance genfu, FillerManager fillerManager)
            : base(genfu, fillerManager)
        {
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
        /// Fill the specified property with the specified value
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="value">A property value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> Fill<T2>(Expression<Func<T, T2>> expression, T2 value)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(_genfu, propertyInfo.Name, typeof(T), () => value);
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> Fill<T2>(Expression<Func<T, T2>> expression, Func<T2> filler)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(_genfu, propertyInfo.Name, typeof(T), filler);
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Fill the specified property with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <param name="filler">A function that will return a property value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> Fill<T2>(Expression<Func<T, T2>> expression, Func<T, T2> filler)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            CustomFiller<T, T2> customFiller = new CustomFiller<T, T2>(_genfu, propertyInfo.Name, typeof(T), filler);
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }

        /// <summary>
        /// Configure how the specified integer property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuIntegerConfigurator<T> Fill(Expression<Func<T, int>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuIntegerConfigurator<T>(_genfu, _fillerManager, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified short property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuShortConfigurator<T> Fill(Expression<Func<T, short>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuShortConfigurator<T>(_genfu, _fillerManager, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified decimal property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuDecimalConfigurator<T> Fill(Expression<Func<T, decimal>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuDecimalConfigurator<T>(_genfu, _fillerManager, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified string property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuStringConfigurator<T> Fill(Expression<Func<T, string>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuStringConfigurator<T>(_genfu, _fillerManager, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified DateTime property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuDateTimeConfigurator<T> Fill(Expression<Func<T, DateTime>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuDateTimeConfigurator<T>(_genfu, _fillerManager, propertyInfo);
        }

        /// <summary>
        /// Configure how the specified property should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target property type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified property of the target object type</returns>
        public GenFuComplexPropertyConfigurator<T, T2> Fill<T2>(Expression<Func<T, T2>> expression)
        {
            PropertyInfo propertyInfo = GetPropertyInfoFromExpression(expression);
            return new GenFuComplexPropertyConfigurator<T, T2>(_genfu, _fillerManager, propertyInfo);
        }




        /// <summary>
        /// Fill the specified method with the result of the specified function
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target method parameter type</typeparam>
        /// <param name="expression">The target method</param>
        /// <param name="filler">A function that will return a method parameter set value</param>
        /// <returns>A configurator for the target object type</returns>
        public GenFuConfigurator<T> MethodFill<T2>(Expression<Action<T>> expression, Func<T2> filler)
        {
            MethodInfo methodInfo = GetMethodInfoFromExpression(expression);
            CustomFiller<T2> customFiller = new CustomFiller<T2>(_genfu, methodInfo.Name, typeof(T), filler);
            _fillerManager.RegisterFiller(customFiller);
            return this;
        }


        /// <summary>
        /// Configure how the specified method should be filled
        /// </summary>
        /// <typeparam name="T">The target object type</typeparam>
        /// <typeparam name="T2">The target method parameter type</typeparam>
        /// <param name="expression">The target property</param>
        /// <returns>A configurator for the specified method of the target object type</returns>
        public GenFuComplexPropertyConfigurator<T, T2> MethodFill<T2>(Expression<Action<T>> expression)
        {
            MethodInfo methodInfo = GetMethodInfoFromExpression(expression);
            IPropertyFiller filler = _fillerManager.GetGenericFillerForType(methodInfo.GetParameters()[0].ParameterType);
            PropertyFiller<T2> customFiller = new CustomFiller<T2>(_genfu, methodInfo.Name,  typeof(T), () => (T2)filler.GetValue(null));
            _fillerManager.RegisterFiller(customFiller);
            return new GenFuComplexPropertyConfigurator<T, T2>(_genfu, _fillerManager, methodInfo);
        }
    }
}