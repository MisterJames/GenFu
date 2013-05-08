using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Angela.Core.ValueGenerators.Cooking
{
    public class Ingredients:BaseValueGenerator
    {
        public string Ingredient()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Ingredients));
        }
    }
}
