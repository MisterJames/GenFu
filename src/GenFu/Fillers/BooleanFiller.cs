using System;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{
    public class BooleanFiller : PropertyFiller<bool>
    {
        public BooleanFiller() : this(A.GenFuInstance) { }

        public BooleanFiller(Type objectType, string propertyName) : this(A.GenFuInstance, objectType, propertyName) { }

        public BooleanFiller(GenFuInstance genfu) : base(genfu, new[] { "object" }, new[] { "*" }, true)
        {

        }

        public BooleanFiller(GenFuInstance genfu, Type objectType, string propertyName) : base(genfu, new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return GenFu.Random.Next() % 2 == 0;
        }
    }

    public class NullableBooleanFiller : PropertyFiller<bool?>
    {
        public NullableBooleanFiller() : this(A.GenFuInstance) { }

        public NullableBooleanFiller(GenFuInstance genfu) : base(genfu, new[] { "object" }, new[] { "*" }, true)
        {

        }

        public NullableBooleanFiller(GenFuInstance genfu,Type objectType, string propertyName) : base(genfu, new[] { objectType.FullName }, new[] { propertyName })
        {

        }

        public override object GetValue(object instance)
        {
            return GenFu.Random.Next() % 2 == 0;
        }
    }
}
