using System;

namespace GenFu.Fillers
{
    class GuidFiller:PropertyFiller<Guid>
    {
        public GuidFiller()
             : base(typeof(object), "*", true)
        { }

        public override object GetValue(object instance)
        {
            return Guid.NewGuid();
        }
    }
}