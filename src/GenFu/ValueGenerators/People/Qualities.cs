using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.ValueGenerators.People
{
    public class Qualities : BaseValueGenerator
    {
        public static string Gender()
        {
            return GetRandomValue(ResourceLoader.Data(PropertyType.Genders));
        }
    }
}
