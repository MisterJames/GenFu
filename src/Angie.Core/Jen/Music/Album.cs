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
            public class Album
            {
                public string AlbumArtUrl { get; set; }

                public static string Title()
                {
                    int index = _random.Next(0, Susan.Data(Properties.MusicAlbums).Count());
                    return Susan.Data(Properties.MusicAlbums)[index];
                }



            }
        }
    }
}
