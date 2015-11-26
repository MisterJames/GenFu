using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GenFu.Fillers
{
    class GuidFiller:PropertyFiller<Guid>
    {
        public GuidFiller()
            : base(new[] { "object" }, new[] { "*" }, true)
        { }

        public override object GetValue(object instance)
        {
            return Guid.NewGuid();
        }
    }
}