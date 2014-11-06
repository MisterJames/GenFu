using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.ValueGenerators.Cooking
{
    public class Ingredients:BaseValueGenerator
    {
        public static string Ingredient()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Ingredients));
        }
    }
}
