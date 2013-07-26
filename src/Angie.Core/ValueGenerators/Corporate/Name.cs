using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.ValueGenerators.Corporate
{
    class Company: BaseValueGenerator
    {
        public static string Name()
        {
            var names = from c in  ResourceLoader.Data(Properties.CompanyNames) 
                        join i in ResourceLoader.Data(Properties.Industries) on 1 equals 1
                        select c + " " + i;
            return names.GetRandomElement();
        }
    }
   
}
