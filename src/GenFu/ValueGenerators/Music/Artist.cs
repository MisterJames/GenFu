using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.ValueGenerators.Music
{
    public class Artist:BaseValueGenerator
    {
        public static string Name()
        {
            int index = _random.Next(0, ResourceLoader.Data(PropertyType.MusicArtists).Count());
            return ResourceLoader.Data(PropertyType.MusicArtists)[index];
        }
    }
}
