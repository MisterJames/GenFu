using System;
using System.Collections.Generic;
using System.Linq;

namespace GenFu.ValueGenerators.Medical
{
    public class MedicalProcedures : BaseValueGenerator
    {
        public static string MedicalProcedure()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.MedicalProcedures));
        }
    }
}
