namespace GenFu.Utilities;

using System;
using System.Threading;

public static class StaticRandom
{
    private static int seed;

    private static readonly ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
        (() => new Random(Interlocked.Increment(ref seed)));

    static StaticRandom()
    {
        seed = Environment.TickCount;
    }

    public static Random Instance { get { return threadLocal.Value; } }
}
