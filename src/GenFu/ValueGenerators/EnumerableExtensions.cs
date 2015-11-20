using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu
{
    static class EnumerableExtensions
    {
        private static Random _random = new Random();
        public static int GetRandomIndex(this IEnumerable<string> list)
        {
            return _random.Next(0, list.Count() - 1);
        }

        public static string GetRandomElement(this IEnumerable<string> list)
        {
            return list.ElementAt(GetRandomIndex(list));
        }
    }
}
