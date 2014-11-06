using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core.ValueGenerators.Internet
{
    public class Domains : BaseValueGenerator
    {
        public static string DomainName()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Domains));

        }
    }
}
