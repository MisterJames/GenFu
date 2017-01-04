
namespace GenFu.ValueGenerators.Corporate
{
    public class Jobs : BaseValueGenerator
    {

        public static string JobTitles()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.JobTitles));
        }

    }
}
