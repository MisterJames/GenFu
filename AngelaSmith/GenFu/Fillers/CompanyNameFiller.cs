using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFu.Fillers
{
    class CompanyNameFiller : PropertyFiller<string>, IPropertyFiller
    {
        public CompanyNameFiller(): base (new[] { "company" }, new[] { "name" }, false)
        {}

        public override object GetValue()
        {
            return ValueGenerators.Corporate.Company.Name();
        }
    }
}
