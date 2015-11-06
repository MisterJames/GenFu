using System;

namespace GenFu
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

    
        public override object GetValue(object instance)
        {
            return _filler.Invoke();
        }
    }

    public class CustomFiller<T1, T2> : PropertyFiller<T2>
    {
        private Func<T1, T2> _filler;

        public CustomFiller(string propertyName, Type objectType, Func<T1, T2> filler)
            : this(propertyName, objectType, false, filler)
        {
        }

        internal CustomFiller(string propertyName, Type objectType, bool isGeneric, Func<T1, T2> filler)
            : base(new[] { objectType.FullName }, new[] { propertyName }, isGeneric)
        {
            _filler = filler;
        }


        public override object GetValue(object instance)
        {
            return _filler.Invoke((T1) instance);
        }
    }
}
