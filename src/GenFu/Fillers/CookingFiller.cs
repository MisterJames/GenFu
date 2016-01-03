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

        public class MealFiller : PropertyFiller<string>
        {
            public MealFiller()
                : base(new[] { "object" }, new[] { "meal", "dish", "recipe" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Cooking.Meals.Meal();
            }
        }

        public class StarterFiller : PropertyFiller<string>
        {
            public StarterFiller()
                : base(new[] { "object" }, new[] { "starter" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Cooking.Starters.Starter();
            }
        }

        public class MainCourseFiller : PropertyFiller<string>
        {
            public MainCourseFiller()
                : base(new[] { "object" }, new[] { "maincourse", "main" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Cooking.MainCourses.MainCourse();
            }
        }

        public class DessertFiller : PropertyFiller<string>
        {
            public DessertFiller()
                : base(new[] { "object" }, new[] { "dessert" })
            {
            }

            public override object GetValue(object instance)
            {
                return ValueGenerators.Cooking.Desserts.Dessert();
            }
        }
    }
}