using System;
using System.Collections.Generic;
using System.Linq;

namespace GenFu.Fillers
{
    class MedicalFiller
    {
        public class DrugFiller : PropertyFiller<string>
        {
            public DrugFiller()
                : base(new[] { "object" }, new[] { "drug", "drugs" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Medical.Drugs.Drug();
            }
        }
    }
}
