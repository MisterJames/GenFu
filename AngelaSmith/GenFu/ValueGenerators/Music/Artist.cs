using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core.ValueGenerators.Music
{
    public class Artist:BaseValueGenerator
    {
        public static string Name()
        {
            int index = _random.Next(0, ResourceLoader.Data(Properties.MusicArtists).Count());
            return ResourceLoader.Data(Properties.MusicArtists)[index];
        }
    }
}
