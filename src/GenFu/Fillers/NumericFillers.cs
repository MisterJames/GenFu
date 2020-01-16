using System;

namespace GenFu
{
    public class IntFiller : PropertyFiller<int>
    {

        public IntFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public IntFiller(Type objectType, string propertyName, int min, int max) 
            : base(objectType, propertyName, false)
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

    public class NullableIntFiller : PropertyFiller<int?>
    {

        public NullableIntFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableIntFiller(Type objectType, string propertyName, int min, int max) 
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new int?(GenFu.Random.Next(Min, Max));
        }
    }

    public class NullableUIntFiller : PropertyFiller<uint?>
    {

        public NullableUIntFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_UINT;
            Max = GenFu.Defaults.MAX_UINT;
        }

        public NullableUIntFiller(Type objectType, string propertyName, uint min, uint max) 
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;
        }

        public uint Min { get; set; }
        public uint Max { get; set; }

        public override object GetValue(object instance)
        {
            return new uint?((uint)GenFu.Random.Next((int)Min, (int)Max));
        }
    }

    public class ShortFiller : PropertyFiller<short>
    {

        public ShortFiller() : base(typeof(object), "*", true)
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

    public class NullableShortFiller : PropertyFiller<short?>
    {

        public NullableShortFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_SHORT;
            Max = GenFu.Defaults.MAX_SHORT;
        }

        public NullableShortFiller(Type objectType, string propertyName, short min, short max)
            : base(new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public short Min { get; set; }
        public short Max { get; set; }

        public override object GetValue(object instance)
        {
            return (short?)GenFu.Random.Next(Min, Max);
        }
    }

    public class NullableUShortFiller : PropertyFiller<ushort?>
    {

        public NullableUShortFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_USHORT;
            Max = GenFu.Defaults.MAX_USHORT;
        }

        public NullableUShortFiller(Type objectType, string propertyName, ushort min, ushort max)
            : base(new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public ushort Min { get; set; }
        public ushort Max { get; set; }

        public override object GetValue(object instance)
        {
            return (ushort?)GenFu.Random.Next(Min, Max);
        }
    }

    public class LongFiller : PropertyFiller<long>
    {

        public LongFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public LongFiller(Type objectType, string propertyName, int min, int max) 
            : base(objectType, propertyName, false)
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

    public class NullableLongFiller : PropertyFiller<long?>
    {

        public NullableLongFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableLongFiller(Type objectType, string propertyName, int min, int max) 
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new long?(GenFu.Random.Next(Min, Max));
        }
    }

    public class NullableULongFiller : PropertyFiller<ulong?>
    {

        public NullableULongFiller() : base(typeof(object), "*", true)
        {
            Min = 0;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableULongFiller(Type objectType, string propertyName, int min, int max)
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new ulong?((ulong)GenFu.Random.Next(Min, Max));
        }
    }

    public class DecimalFiller : PropertyFiller<decimal>
    {
        public DecimalFiller()
         : base(typeof(object), "*", true)
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

    public class NullableDecimalFiller : PropertyFiller<decimal?>
    {
        public NullableDecimalFiller()
             : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_DECIMAL;
            Max = GenFu.Defaults.MAX_DECIMAL;
        }

        public NullableDecimalFiller(Type objectType, string propertyName, decimal min, decimal max)
            : base(objectType, propertyName, false)
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

            return new decimal?(Math.Round(result, 2));
        }
    }


    public class DoubleFiller : PropertyFiller<double>
    {

        public DoubleFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_DOUBLE;
            Max = GenFu.Defaults.MAX_DOUBLE;
        }

        public DoubleFiller(Type objectType, string propertyName, double min, double max)
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;

        }

        public double Min { get; set; }
        public double Max { get; set; }

        public override object GetValue(object instance)
        {
            return (GenFu.Random.NextDouble() * (Max-Min)) + Min;
        }
    }

    public class NullableDoubleFiller : PropertyFiller<double?>
    {

        public NullableDoubleFiller() : base(typeof(object), "*", true)
        {
            Min = GenFu.Defaults.MIN_DOUBLE;
            Max = GenFu.Defaults.MAX_DOUBLE;
        }

        public NullableDoubleFiller(Type objectType, string propertyName, double min, double max)
            : base(objectType, propertyName, false)
        {
            Min = min;
            Max = max;

        }

        public double Min { get; set; }
        public double Max { get; set; }

        public override object GetValue(object instance)
        {
            return new double?((GenFu.Random.NextDouble() * (Max - Min)) + Min);
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

    public class PriceFiller : PropertyFiller<decimal>
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
