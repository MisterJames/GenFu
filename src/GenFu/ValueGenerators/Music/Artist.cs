namespace GenFu.ValueGenerators.Music;

using System.Linq;

public class Artist : BaseValueGenerator
{
    public static string Name()
    {
        int index = _random.Next(0, ResourceLoader.Data(PropertyType.MusicArtists).Count());
        return ResourceLoader.Data(PropertyType.MusicArtists)[index];
    }
}
