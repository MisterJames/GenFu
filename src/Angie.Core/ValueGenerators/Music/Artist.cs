using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core.ValueGenerators.Music
{
    public class Artist:BaseValueGenerator
    {
        public static string Name()
        {
            int index = _random.Next(0, Susan.Data(Properties.MusicArtists).Count());
            return Susan.Data(Properties.MusicArtists)[index];
        }
    }
}
