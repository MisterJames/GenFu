using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenFu.ValueGenerators.Lorem
{
    public class Lorem : BaseValueGenerator
    {
        public static string LoremIpsum()
        {
            return GetRandomValue(ResourceLoader.Data(Properties.Lorem));
        }
        public static string LoremIpsum(int wordCount)
        {
            var words = new List<string>();
            for (int i = 0; i < wordCount; i++)
            {
                words.Add(GetRandomValue(ResourceLoader.Data(Properties.Lorem)));
            }
            return string.Join(" ", words);
        }
    }
}
