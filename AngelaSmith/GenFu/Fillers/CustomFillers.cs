using System;

namespace Angela.Core
{
    public class CustomFiller<T> : PropertyFiller<T>
    {
        private Func<T> _filler;

        public CustomFiller(string propertyName, Type objectType, Func<T> filler) 
            : this(propertyName, objectType, false, filler )
        {
        }

        internal CustomFiller(string propertyName, Type objectType, bool isGeneric, Func<T> filler)
            : base(new[] { objectType.FullName }, new[] { propertyName }, isGeneric)
        {
            _filler = filler;
        }

    
        public override object GetValue()
        {
            return _filler.Invoke();
        }
    }
}
