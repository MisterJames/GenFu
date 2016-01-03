namespace GenFu.ValueGenerators.Cooking
{
    public class Ingredients : BaseValueGenerator
    {
        public static string Ingredient()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Ingredients));
        }
    }

    public class Meals : BaseValueGenerator
    {
        public static string Meal()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CookingStarters), ResourceLoader.Data(Properties.CookingMainCourses), ResourceLoader.Data(Properties.CookingDesserts));
        }
    }

    public class Starters : BaseValueGenerator
    {
        public static string Starter()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CookingStarters));
        }
    }

    public class MainCourses : BaseValueGenerator
    {
        public static string MainCourse()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CookingMainCourses));
        }
    }

    public class Desserts : BaseValueGenerator
    {
        public static string Dessert()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CookingDesserts));
        }
    }
}
