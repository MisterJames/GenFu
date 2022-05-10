namespace GenFu.Fillers;

using System;

class GuidFiller : PropertyFiller<Guid>
{
    public GuidFiller()
         : base(typeof(object), "*", true) { }

    public override object GetValue(object instance) => Guid.NewGuid();
}
