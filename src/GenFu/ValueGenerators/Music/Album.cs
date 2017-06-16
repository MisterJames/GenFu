using System;
using System.Linq;
using System.Collections.Generic;

namespace GenFu.ValueGenerators.Music
{
    public class Album : BaseValueGenerator
    {
        public string AlbumArtUrl { get; set; }

        public static string Title()
        {
            int index = _random.Next(0, ResourceLoader.Data(PropertyType.MusicAlbums).Count());
            return ResourceLoader.Data(PropertyType.MusicAlbums)[index];
        }
    }
}
