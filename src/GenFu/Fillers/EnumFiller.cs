using System;
using System.Linq;

namespace GenFu
{
    public class EnumFiller : PropertyFiller<Enum>
    {
        readonly Type _type;

        public EnumFiller(Type type)
            : this(A.GenFuInstance, type)
        {
        }

        public EnumFiller(GenFuInstance genFu, Type type)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        {
            this._type = type;
        }

        public override object GetValue(object instance)
        {
            var values = Enum.GetValues(_type);
            return values.GetValue(new Random().Next(values.Length-1));
        }
    }
}
