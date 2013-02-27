using System;
using System.ComponentModel.Composition;

namespace Angela.Core
{
    public class IntFiller : IPropertyFiller
    {

        public IntFiller()
        {
            Min = Angie.Defaults.MIN_INT;
            Max = Angie.Defaults.MAX_INT;
            PropertyNames = new[] { "*" };
            ObjectTypeNames = new[] { "object" };
        }

        public IntFiller(Type objectType, string propertyName, int min, int max)
        {
            Min = min;
            Max = max;
            PropertyNames = new[] { propertyName };
            ObjectTypeNames = new[] { objectType.FullName };

        }

        public string[] PropertyNames { get; private set; }
        public string[] ObjectTypeNames { get; private set; }

        public Type PropertyType { get { return typeof(int); } }
        public bool IsGenericFiller { get { return true; } }

        public int Min { get; set; }
        public int Max { get; set; }

        public object GetValue()
        {
            return Angie.Random.Next(Min, Max);
        }
    }

    public class ShortFiller : IPropertyFiller
    {

        public ShortFiller()
        {
            Min = Angie.Defaults.MIN_SHORT;
            Max = Angie.Defaults.MAX_SHORT;
            PropertyNames = new[] { "*" };
            ObjectTypeNames = new[] { "object" };
        }

        public ShortFiller(Type objectType, string propertyName, short min, short max)
        {
            Min = min;
            Max = max;
            PropertyNames = new[] { propertyName };
            ObjectTypeNames = new[] { objectType.FullName };

        }

        public string[] PropertyNames { get; private set; }
        public string[] ObjectTypeNames { get; private set; }

        public Type PropertyType { get { return typeof(short); } }
        public bool IsGenericFiller { get { return true; } }

        public short Min { get; set; }
        public short Max { get; set; }

        public object GetValue()
        {
            return (short) Angie.Random.Next(Min, Max);
        }
    }

    public class DecimalFiller : IPropertyFiller
    {
        public DecimalFiller()
        {
            Min = Angie.Defaults.MIN_DECIMAL;
            Max = Angie.Defaults.MAX_DECIMAL;
            PropertyNames = new[] { "*" };
            ObjectTypeNames = new[] {"object"};
        }

        public DecimalFiller(Type objectType, string propertyName, decimal min, decimal max)
        {
            Min = min;
            Max = max;
            PropertyNames = new[] { propertyName };
            ObjectTypeNames = new []{ objectType.FullName};
        }

        public string[] PropertyNames { get; private set; }

        public string[] ObjectTypeNames { get; private set; }

        public Type PropertyType { get { return typeof(decimal); } }
        public bool IsGenericFiller { get { return true; } }

        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public object GetValue()
        {
            var rnd = Angie.Random.NextDouble() - 0.5f;
            var baseValue = Angie.Random.Next((int)Max - (int)Min) + rnd;
            decimal result = ((decimal)baseValue + Min) * 1.035m;

            if (result < Min) result += 0.5m;
            if (result > Max) result -= 0.5m;

            return Math.Round(result, 2);
        }
    }


    public class AgeFiller : IPropertyFiller
    {
        private const int _minAge = 1;
        private const int _maxAge = 93;

        public string[] PropertyNames
        {
            get { return new[] { "Age" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(int); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Math.Abs(Angie.Random.Next(_minAge, _maxAge));
        }
    }

    public class PriceFiller : IPropertyFiller
    {
        private const int _maxPrice = 1000;

        public string[] PropertyNames
        {
            get { return new[] { "price", "amount", "amt" }; }
        }

        public string[] ObjectTypeNames
        {
            get { return new[] { "object" }; }
        }

        public Type PropertyType { get { return typeof(decimal); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {

            decimal result = (decimal)(Angie.Random.NextDouble() * _maxPrice);

            return Math.Round(result,2);
        }
    }



}
