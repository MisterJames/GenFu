namespace GenFu.ValueGenerators.Music;

using System.Linq;

public class Album : BaseValueGenerator
{
    public string AlbumArtUrl { get; set; }

    public static string Title()
    {
        int index = _random.Next(0, ResourceLoader.Data(PropertyType.MusicAlbums).Count());
        return ResourceLoader.Data(PropertyType.MusicAlbums)[index];
    }
}
