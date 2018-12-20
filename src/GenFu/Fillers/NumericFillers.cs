using System;

using GenfuStatic = GenFu.GenFu;

namespace GenFu
{
    public class IntFiller : PropertyFiller<int>
    {
        public IntFiller() : this(A.GenFuInstance) { }

        public IntFiller(Type objectType, string propertyName, int min, int max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public IntFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = genFu.Defaults.MIN_INT;
            Max = genFu.Defaults.MAX_INT;
        }

        public IntFiller(GenFuInstance genFu, Type objectType, string propertyName, int min, int max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return this.GenFu.Random.Next(Min, Max);
        }
    }

    public class NullableIntFiller : PropertyFiller<int?>
    {
        public NullableIntFiller() : this(A.GenFuInstance) { }
        public NullableIntFiller(Type objectType, string propertyName, int min, int max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableIntFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = this.GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableIntFiller(GenFuInstance genFu, Type objectType, string propertyName, int min, int max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new int?(this.GenFu.Random.Next(Min, Max));
        }
    }

    public class NullableUIntFiller : PropertyFiller<uint?>
    {
        public NullableUIntFiller(): this(A.GenFuInstance) { }

        public NullableUIntFiller(Type objectType, string propertyName, uint min, uint max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableUIntFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_UINT;
            Max = GenFu.Defaults.MAX_UINT;
        }

        public NullableUIntFiller(GenFuInstance genFu, Type objectType, string propertyName, uint min, uint max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public uint Min { get; set; }
        public uint Max { get; set; }

        public override object GetValue(object instance)
        {
            return new uint?((uint)this.GenFu.Random.Next((int)Min, (int)Max));
        }
    }

    public class ShortFiller : PropertyFiller<short>
    {
        public ShortFiller() : this(A.GenFuInstance) { }

        public ShortFiller(Type objectType, string propertyName, short min, short max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public ShortFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_SHORT;
            Max = GenFu.Defaults.MAX_SHORT;
        }

        public ShortFiller(GenFuInstance genFu, Type objectType, string propertyName, short min, short max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public short Min { get; set; }
        public short Max { get; set; }

        public override object GetValue(object instance)
        {
            return (short)this.GenFu.Random.Next(Min, Max);
        }
    }

    public class NullableShortFiller : PropertyFiller<short?>
    {
        public NullableShortFiller() : this(A.GenFuInstance) { }

        public NullableShortFiller(Type objectType, string propertyName, short min, short max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableShortFiller(GenFuInstance genfu) : base(genfu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_SHORT;
            Max = GenFu.Defaults.MAX_SHORT;
        }

        public NullableShortFiller(GenFuInstance genfu, Type objectType, string propertyName, short min, short max)
            : base(genfu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public short Min { get; set; }
        public short Max { get; set; }

        public override object GetValue(object instance)
        {
            return (short?)this.GenFu.Random.Next(Min, Max);
        }
    }

    public class NullableUShortFiller : PropertyFiller<ushort?>
    {
        public NullableUShortFiller() : this(A.GenFuInstance) { }

        public NullableUShortFiller(Type objectType, string propertyName, ushort min, ushort max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableUShortFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_USHORT;
            Max = GenFu.Defaults.MAX_USHORT;
        }

        public NullableUShortFiller(GenFuInstance genFu, Type objectType, string propertyName, ushort min, ushort max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public ushort Min { get; set; }
        public ushort Max { get; set; }

        public override object GetValue(object instance)
        {
            return (ushort?)this.GenFu.Random.Next(Min, Max);
        }
    }

    public class LongFiller : PropertyFiller<long>
    {
        public LongFiller() : this(A.GenFuInstance) { }

        public LongFiller(Type objectType, string propertyName, int min, int max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }
        
        public LongFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public LongFiller(GenFuInstance genFu, Type objectType, string propertyName, int min, int max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return this.GenFu.Random.Next(Min, Max);
        }
    }

    public class NullableLongFiller : PropertyFiller<long?>
    {
        public NullableLongFiller() : this(A.GenFuInstance) { }

        public NullableLongFiller(Type objectType, string propertyName, int min, int max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableLongFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_INT;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableLongFiller(GenFuInstance genFu, Type objectType, string propertyName, int min, int max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new long?(this.GenFu.Random.Next(Min, Max));
        }
    }

    public class NullableULongFiller : PropertyFiller<ulong?>
    {
        public NullableULongFiller() : this(A.GenFuInstance) { }

        public NullableULongFiller(Type objectType, string propertyName, int min, int max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableULongFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = 0;
            Max = GenFu.Defaults.MAX_INT;
        }

        public NullableULongFiller(GenFuInstance genFu, Type objectType, string propertyName, int min, int max) : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public override object GetValue(object instance)
        {
            return new ulong?((ulong)this.GenFu.Random.Next(Min, Max));
        }
    }

    public class DecimalFiller : PropertyFiller<decimal>
    {
        public DecimalFiller() : this(A.GenFuInstance) { }
        public DecimalFiller(Type objectType, string propertyName, decimal min, decimal max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public DecimalFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_DECIMAL;
            Max = GenFu.Defaults.MAX_DECIMAL;
        }

        public DecimalFiller(GenFuInstance genFu, Type objectType, string propertyName, decimal min, decimal max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }


        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public override object GetValue(object instance)
        {
            var rnd = this.GenFu.Random.NextDouble() - 0.5f;
            var baseValue = this.GenFu.Random.Next((int)Max - (int)Min) + rnd;
            decimal result = ((decimal)baseValue + Min) * 1.035m;

            if (result < Min) result += 0.5m;
            if (result > Max) result -= 0.5m;

            return Math.Round(result, 2);
        }
    }

    public class NullableDecimalFiller : PropertyFiller<decimal?>
    {
        public NullableDecimalFiller() : this(A.GenFuInstance) { }

        public NullableDecimalFiller(Type objectType, string propertyName, decimal min, decimal max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableDecimalFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_DECIMAL;
            Max = GenFu.Defaults.MAX_DECIMAL;
        }

        public NullableDecimalFiller(GenFuInstance genFu, Type objectType, string propertyName, decimal min, decimal max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;
        }


        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public override object GetValue(object instance)
        {
            var rnd = this.GenFu.Random.NextDouble() - 0.5f;
            var baseValue = this.GenFu.Random.Next((int)Max - (int)Min) + rnd;
            decimal result = ((decimal)baseValue + Min) * 1.035m;

            if (result < Min) result += 0.5m;
            if (result > Max) result -= 0.5m;

            return new decimal?(Math.Round(result, 2));
        }
    }


    public class DoubleFiller : PropertyFiller<double>
    {
        public DoubleFiller() : this(A.GenFuInstance) { }

        public DoubleFiller(Type objectType, string propertyName, double min, double max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }
        
        public DoubleFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_DOUBLE;
            Max = GenFu.Defaults.MAX_DOUBLE;
        }

        public DoubleFiller(GenFuInstance genFu, Type objectType, string propertyName, double min, double max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public double Min { get; set; }
        public double Max { get; set; }

        public override object GetValue(object instance)
        {
            return (this.GenFu.Random.NextDouble() * (Max - Min)) + Min;
        }
    }

    public class NullableDoubleFiller : PropertyFiller<double?>
    {
        public NullableDoubleFiller() : this(A.GenFuInstance) { }

        public NullableDoubleFiller(Type objectType, string propertyName, double min, double max) : this(A.GenFuInstance, objectType, propertyName, min, max) { }

        public NullableDoubleFiller(GenFuInstance genFu) : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            Min = GenFu.Defaults.MIN_DOUBLE;
            Max = GenFu.Defaults.MAX_DOUBLE;
        }

        public NullableDoubleFiller(GenFuInstance genFu, Type objectType, string propertyName, double min, double max)
            : base(genFu, new[] { objectType.FullName }, new[] { propertyName })
        {
            Min = min;
            Max = max;

        }

        public double Min { get; set; }
        public double Max { get; set; }

        public override object GetValue(object instance)
        {
            return new double?((this.GenFu.Random.NextDouble() * (Max - Min)) + Min);
        }
    }

    public class AgeFiller : PropertyFiller<int>
    {
        private const int _minAge = 1;
        private const int _maxAge = 93;

        public AgeFiller() : this(A.GenFuInstance) { }
        
        public AgeFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "Age" })
        {
        }

        public override object GetValue(object instance)
        {
            return Math.Abs(this.GenFu.Random.Next(_minAge, _maxAge));
        }
    }

    public class PriceFiller : PropertyFiller<decimal>
    {
        private const int _maxPrice = 1000;
        
        public PriceFiller() : this(A.GenFuInstance) { }

        public PriceFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "price", "amount", "amt" })
        {
        }

        public override object GetValue(object instance)
        {

            decimal result = (decimal)(this.GenFu.Random.NextDouble() * _maxPrice);

            return Math.Round(result, 2);
        }
    }



}
