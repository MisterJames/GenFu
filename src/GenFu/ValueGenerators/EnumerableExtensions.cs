﻿namespace GenFu;

using System;
using System.Collections.Generic;
using System.Linq;

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
