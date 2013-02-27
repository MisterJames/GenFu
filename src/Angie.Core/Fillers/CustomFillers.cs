using System;

namespace Angela.Core
{
    public class CustomFiller<T> : IPropertyFiller
    {
        private string _propertyName;
        private string _objectTypeName;
        private Type _objectType;
        private Type _propertyType;
        private Func<T> _filler;

        public CustomFiller(string propertyName, Type objectType, Func<T> filler)
        {
            _propertyName = propertyName;
            _objectType = objectType;
            _objectTypeName = objectType.FullName;
            _propertyType = typeof(T);
            _filler = filler;
        }

        public string[] PropertyNames
        {
            get
            {
                return new[] { _propertyName };
            }
        }

        public string[] ObjectTypeNames
        {
            get
            {
                return new[] { _objectTypeName };
            }
        }

        public Type PropertyType { get { return _propertyType; } }
        public bool IsGenericFiller { get; set; }

        public object GetValue()
        {
            return _filler.Invoke();
        }
    }
}
