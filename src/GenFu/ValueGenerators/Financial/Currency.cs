
namespace GenFu.ValueGenerators.Financial
{
    public class Currency : BaseValueGenerator
    {

        public static string CurrencyName()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CurrencyNames));
        }

        public static string CurrencyCode()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.CurrencyCodes));
        }

    }
}
