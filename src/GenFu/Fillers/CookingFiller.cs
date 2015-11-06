using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenFu.Fillers
{
    class CookingFiller
    {
        public class IngredientFiller : PropertyFiller<string>
        {
            public IngredientFiller()
                : base(new[] { "object" }, new[] { "ingredient", "ingredients" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Cooking.Ingredients.Ingredient();
            }
        }
    }
}
