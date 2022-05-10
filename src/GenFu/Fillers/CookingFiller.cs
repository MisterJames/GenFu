namespace GenFu.Fillers;

class CookingFiller
{
    public class IngredientFiller : PropertyFiller<string>
    {
        public IngredientFiller()
            : base(new[] { "object" }, new[] { "ingredient", "ingredients" }) { }

        public override object GetValue(object instance)
         => ValueGenerators.Cooking.Ingredients.Ingredient();
    }
}
