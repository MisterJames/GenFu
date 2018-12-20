using System;

namespace GenFu.Fillers
{
    class GuidFiller:PropertyFiller<Guid>
    {
        public GuidFiller() : this(A.GenFuInstance) { }

        public GuidFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "*" }, true)
        { }

        public override object GetValue(object instance)
        {
            return Guid.NewGuid();
        }
    }
}