using System;
using System.Linq;
using System.Collections.Generic;

namespace Angela.Core
{
    public partial class Jen
    {
        public partial class Music
        {
            public class Genre
            {
                public static string Name()
                {
                    var prefixes = new string[] { "Acid ", "Jazzy ", "Fresh ", "Classic ", "Free ", "Hard ", "Electronic ", "Modern ", "Brazillian ", "Caribbean ", "African ", "Asian ", "Avant-Garde ", "Kansas City ", "Glam ", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    var genres = new string[] { "Jazz", "Funk", "Jazz", "Jazz", "Dance", "House", "Rock", "Rock", "Rock", "Classical", "Emo", "Grunge", "Children's", "Doo-Wop", "Blues", "Blues", "R&B", "Pop", "Folk", "Easy Listening", "Emo", "Screamo" };

                    int prefixIndex = _random.Next(0, prefixes.Count());
                    int genresIndex = _random.Next(0, genres.Count());

                    return string.Format("{0}{1}", prefixes[prefixIndex], genres[genresIndex]);
                }

                public static string Description()
                {
                    var prefixes = new string[] { "A new take on the classic ", "Fresh sounds, with roots in ", "Known for generations as ", "Grounded in Jazz and Modern Doo-Wop, with traces of ", "Inspired by ", "A modern look on what we've known for ages as ", "The southern revival of ", "A colorful version of ", "Even tones and smooth percussion like " };
                    var body = new string[] { "lovable tradition", "folk sound", "stagnant rock", "peaceful melodies", "rythmic jive", "old-country sound", "basic but full sound", "acid rock", "East-European swing", "jazzy funk" };
                    var suffixes = new string[] { "with a twist of heart-throb", "re-invented by today's swooners", "with a hint of rum", "that pleases critics like no other Earthly beat", "spliced with daft loops that raise emotion and scare small children", "that impresses audiences world wide", "and known for its deep base lines", "that keeps true to it's roots in glam rock", "that inspired a new generation of Brit pop" };

                    int prefixIndex = _random.Next(0, prefixes.Count());
                    int bodyIndex = _random.Next(0, body.Count());
                    int suffixIndex = _random.Next(0, suffixes.Count());

                    return string.Format("{0}{1}, {2}.", prefixes[prefixIndex], body[bodyIndex], suffixes[suffixIndex]);
                }
            }
        }
    }
}
