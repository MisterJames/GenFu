using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenFu.ValueGenerators.Education
{
    public class Universities : BaseValueGenerator
    {

        public static string Name()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Universities));
        }

    }
}
