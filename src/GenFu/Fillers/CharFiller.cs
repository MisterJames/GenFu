using System;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{
    public class CharFiller : PropertyFiller<char>
    {

        public CharFiller() : base(typeof(object), "*", true)
        {

        }

        public CharFiller(Type objectType, string propertyName) : base(new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return (char)GenFu.Random.Next(char.MinValue, char.MaxValue);
        }
    }

    public class NullableCharFiller : PropertyFiller<char?>
    {

        public NullableCharFiller() : base(typeof(object), "*", true)
        {

        }

        public NullableCharFiller(Type objectType, string propertyName) : base(new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return new char?((char)GenFu.Random.Next(char.MinValue, char.MaxValue));
        }
    }
}
