using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.Fillers
{
    public class InjuryFiller : PropertyFiller<string>
    {
        public InjuryFiller()
            : base(new[] { "object" }, new[] { "injury" })
        {
        }

        public override object GetValue(object instance)
        {
            return ValueGenerators.Medical.Injuries.Injury();
        }
    }
}
