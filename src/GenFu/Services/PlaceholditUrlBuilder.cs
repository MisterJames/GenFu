using GenFu.Fillers;
using GenFu.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenFu.Services
{
    public class PlaceholditUrlBuilder
    {
        public static string UrlFor(
            int width, 
            int height,
            string text = null,
            string backgroundColor = null,
            string textColor = null,
            ImgFormat format = ImgFormat.GIF) =>
                new StringBuilder()
                    .Append("http://placehold.it/")
                    .Append($"{width}x{height}")
                    .AppendWhen($".{format}", format != ImgFormat.GIF)
                    .AppendWhen($"/{backgroundColor}", !string.IsNullOrWhiteSpace(backgroundColor))
                    .AppendWhen($"/{textColor}", !string.IsNullOrWhiteSpace(textColor))
                    .AppendWhen($"?text={text}", !string.IsNullOrWhiteSpace(text))
                    .ToString();
        
    }
}
