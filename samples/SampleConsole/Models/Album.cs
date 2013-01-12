using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("{0} - by {1}",Title, Artist == null ? "" : Artist.Name));
            sb.AppendLine(string.Format("  {0} ({1})", Genre == null ? "" : Genre.Name, Genre == null ? "" : Genre.Description ?? ""));
            sb.AppendLine(string.Format("  {0:c}", Price));

            return sb.ToString();
        }
    }
}
