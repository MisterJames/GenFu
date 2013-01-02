using System;

namespace Angela.Core.Fillers
{
    public class CustomFiller<T> : IPropertyFiller
    {
        private string _propertyName;
        private Type _objectType;
        private Type _propertyType;
        private Func<T> _filler;

        public CustomFiller(string propertyName, Type objectType, Func<T> filler)
        {
            _propertyName = propertyName;
            _objectType = objectType;
            _propertyType = typeof(T);
            _filler = filler;
        }

        public string[] PropertyNames
        {
            get
            {
                return new[]
                    {
                        _propertyName
                    };
            }
        }
        public Type ObjectType { get { return _objectType; } }
        public Type PropertyType { get { return _propertyType; } }
        public object GetValue()
        {
            return _filler.Invoke();
        }
    }
}
