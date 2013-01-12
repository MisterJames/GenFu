using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Core
{
    public partial class Jen
    {
        public partial class Music
        {
            public class Artist
            {
                public static string Name()
                {
                    int index = _random.Next(0, Susan.Data(Properties.MusicArtists).Count());
                    return Susan.Data(Properties.MusicArtists)[index];
                }

            }
        }

    }
}
