using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Angela.vNext.Reflection;
using StaticGenfu = GenFu.GenFu;

namespace GenFu
{
    public partial class GenFuInstance
    {
        private FillerManager _fillerManager;
        private int _listCount = StaticGenfu.Defaults.LIST_COUNT;

        public GenFuInstance()
        {
            _fillerManager = new FillerManager(this);
            Random = new Random();
        }

        public T New<T>() where T : new()
        {
            return (T)New(typeof(T));
        }

        public object New(Type type)
        {
            object instance = Activator.CreateInstance(type);
            return New(instance);
        }

        public T New<T>(T instance)
        {
            return (T)New((object)instance);
        }

        public object New(object instance)
        {
            if (instance != null)
            {
                var type = instance.GetType();
                if (type.FullName == "System.Guid")
                {
                    instance = Guid.NewGuid();
                }
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


        public List<T> ListOf<T>() where T : new()
        {
            return ListOf(typeof(T)).Cast<T>().ToList();
        }

        public List<object> ListOf(Type type)
        {
            return BuildList(type, _listCount);
        }
        /// <summary>
        /// Creates a new list of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemCount">Number of items to add</param>
        /// <returns></returns>
        public List<T> ListOf<T>(int itemCount) where T : new()
        {
            return ListOf(typeof(T), itemCount).Cast<T>().ToList();
        }

        public List<object> ListOf(Type type, int itemCount)
        {
            return BuildList(type, itemCount);
        }

        private List<object> BuildList(Type type, int itemCount)
        {
            var result = new List<object>();

            for (int i = 0; i < itemCount; i++)
            {
                result.Add(New(type));
            }

            return result;
        }

        private void SetPropertyValue(object instance, PropertyInfo property)
        {
            IPropertyFiller filler = _fillerManager.GetFiller(property);
            property.SetValue(instance, filler.GetValue(instance), null);
        }

        private void CallSetterMethod(object instance, MethodInfo method)
        {
            IPropertyFiller filler = _fillerManager.GetMethodFiller(method);
            if (filler != null)
                method.Invoke(instance, new[] { filler.GetValue(instance) });
        }



        public DateTime MinDateTime
        {
            get { return new GenericFillerDefaults(_fillerManager).GetMinDateTime(); }

            set
            {
                new GenericFillerDefaults(_fillerManager).SetMinDateTime(value);
            }
        }

        public DateTime MaxDateTime
        {
            get { return new GenericFillerDefaults(_fillerManager).GetMaxDateTime(); }
            set
            {
                new GenericFillerDefaults(_fillerManager).SetMaxDateTime(value);
            }
        }

        public Random Random { get; private set; }


        public GenFu.DefaultValues Defaults { get => _defaults; }

        private GenFu.DefaultValues _defaults = new GenFu.DefaultValues();
    }
}
