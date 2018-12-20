using System;
using System.Collections.Generic;
using System.Linq;

namespace GenFu.Fillers
{
    public class MedicalProcedureFiller : PropertyFiller<string>
    {
        public MedicalProcedureFiller() : this(A.GenFuInstance) { }

        public MedicalProcedureFiller(GenFuInstance genFu)
            : base(genFu, new[] { "object" }, new[] { "procedure", "MedicalProcedure" })
        {
        }

        public override object GetValue(object instance)
        {
            return ValueGenerators.Medical.MedicalProcedures.MedicalProcedure();
        }
    }
}
