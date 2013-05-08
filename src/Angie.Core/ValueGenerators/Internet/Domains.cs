using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.ValueGenerators.Internet
{
    public class Domains:BaseValueGenerator
    {
        public static string DomainName()
        {
            return GetRandomValue(Susan.Data(Properties.Domains));

        }
    }
}
