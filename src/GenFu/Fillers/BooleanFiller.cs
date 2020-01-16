using System;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{
    public class BooleanFiller : PropertyFiller<bool>
    {

        public BooleanFiller() : base(typeof(object), "*" , true)
        {

        }

        public BooleanFiller(Type objectType, string propertyName) : base(new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return GenFu.Random.Next() % 2 == 0;
        }
    }

    public class NullableBooleanFiller : PropertyFiller<bool?>
    {

        public NullableBooleanFiller() : base(typeof(object), "*", true)
        {

        }

        public NullableBooleanFiller(Type objectType, string propertyName) : base(new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return GenFu.Random.Next() % 2 == 0;
        }
    }
}
