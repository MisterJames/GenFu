using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.Fillers
{
    class GuidFiller:PropertyFiller<Guid>
    {
        public GuidFiller()
            : base(new[] { "object" }, new[] { "*" }, true)
        { }

        public override object GetValue()
        {
            return Guid.NewGuid();
        }
    }
}
