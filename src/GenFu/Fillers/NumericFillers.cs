using System;

namespace GenFu
{
    public class IntFiller : PropertyFiller<int>
    {

        public IntFiller() : base(new []{"object"}, new []{"*"}, true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public IntFiller(Type objectType, string propertyName, int min, int max) : base(new []{objectType.FullName}, new []{propertyName})
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return GenFu.Random.Next(Min, Max);
        }
    }

    public class ShortFiller : PropertyFiller<short>
    {

        public ShortFiller() : base(new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_SHORT;
            Max = GenFu.Defaults.MAX_SHORT;
        }

        public ShortFiller(Type objectType, string propertyName, short min, short max)
            : base(new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public short Min { get; set; }
        public short Max { get; set; }

        public override object GetValue(object instance)
        {
            return (short) GenFu.Random.Next(Min, Max);
        }
    }

    public class DecimalFiller : PropertyFiller<decimal>
    {
        public DecimalFiller()
            : base(new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_DECIMAL;
            Max = GenFu.Defaults.MAX_DECIMAL;
        }

        public DecimalFiller(Type objectType, string propertyName, decimal min, decimal max)
            : base(new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }


        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public override object GetValue(object instance)
        {
            var rnd = GenFu.Random.NextDouble() - 0.5f;
            var baseValue = GenFu.Random.Next((int)Max - (int)Min) + rnd;
            decimal result = ((decimal)baseValue + Min) * 1.035m;

            if (result < Min) result += 0.5m;
            if (result > Max) result -= 0.5m;

            return Math.Round(result, 2);
        }
    }


    public class AgeFiller : PropertyFiller<int>
    {
        private const int _minAge = 1;
        private const int _maxAge = 93;

        public AgeFiller()
            : base(new[] { "object" }, new[] { "Age" })
        {
        }

        public override object GetValue(object instance)
        {
            return Math.Abs(GenFu.Random.Next(_minAge, _maxAge));
        }
    }

    public class PriceFiller : PropertyFiller<int>
    {
        private const int _maxPrice = 1000;

        public PriceFiller()
            : base(new[] { "object" }, new[] { "price", "amount", "amt" })
        {
        }

        public override object GetValue(object instance)
        {

            decimal result = (decimal)(GenFu.Random.NextDouble() * _maxPrice);

            return Math.Round(result,2);
        }
    }



}
