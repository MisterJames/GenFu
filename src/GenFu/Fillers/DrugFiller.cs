using System;
using System.Collections.Generic;
using System.Linq;

namespace GenFu.Fillers
{ 
    public class DrugFiller : PropertyFiller<string>
    {
        public DrugFiller() : this(A.GenFuInstance) { }

        public DrugFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "drug", "drugs", "Rx", "perscription" })
        {
        }

        public override object GetValue(object instance)
        {
            return ValueGenerators.Medical.Drugs.Drug();
        }
    }
}