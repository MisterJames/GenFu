using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFu.ValueGenerators.Corporate
{
    class Company: BaseValueGenerator
    {
        public static string Name()
        {
            var names = from c in  ResourceLoader.Data(PropertyType.CompanyNames) 
                        join i in ResourceLoader.Data(PropertyType.Industries) on 1 equals 1
                        select c + " " + i;
            return names.GetRandomElement();
        }
    }
   
}
