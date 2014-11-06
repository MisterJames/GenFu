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
            int index = _random.Next(0, ResourceLoader.Data(Properties.MusicAlbums).Count());
            return ResourceLoader.Data(Properties.MusicAlbums)[index];
        }
    }
}
