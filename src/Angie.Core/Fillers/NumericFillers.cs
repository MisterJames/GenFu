using System;
using System.ComponentModel.Composition;

namespace Angela.Core
{
    public class IntFiller : IPropertyFiller
    {
        Random _random = new Random();

        public IntFiller()
        {
            Min = Angie.Defaults.MIN_INT;
            Max = Angie.Defaults.MAX_INT;
            PropertyNames = new[] { "*" };
            ObjectType = typeof(object);
        }

        public IntFiller(Type objectType, string propertyName, int min, int max)
        {
            Min = min;
            Max = max;
            PropertyNames = new[] { propertyName };
            ObjectType = objectType;
        }

        public string[] PropertyNames { get; private set; }

        public Type ObjectType { get; private set; }
        public Type PropertyType { get { return typeof(int); } }
        public bool IsGenericFiller { get { return true; } }

        public int Min { get; set; }
        public int Max { get; set; }

        public object GetValue()
        {
            return _random.Next(Min, Max);
        }
    }


    public class AgeFiller : IPropertyFiller
    {
        Random _random = new Random();
        private const int _minAge = 1;
        private const int _maxAge = 93;

        public string[] PropertyNames
        {
            get { return new[] { "Age" }; }
        }
        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(int); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Math.Abs(_random.Next(_minAge, _maxAge));
        }
    }

}
