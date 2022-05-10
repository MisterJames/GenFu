namespace GenFu.HtmlHelpers.WireframeHelper;

using global::GenFu.Fillers;
using global::GenFu.HtmlHelpers.Utilities;
using global::GenFu.Services;

using Microsoft.AspNetCore.Mvc.Rendering;

public static class ImageExtensions
{
    public static WireframeGenerator Image(this WireframeGenerator gen,
        int width,
        int height,
        string text = null,
        string backgroundColor = null,
        string textColor = null,
        object htmlAttributes = null,
        ImgFormat format = ImgFormat.GIF)
    {
        var img = new TagBuilder("img");
        img.TagRenderMode = TagRenderMode.SelfClosing;
        img.Attributes.Add("src", PlaceholditUrlBuilder.UrlFor(width, height, text, backgroundColor, textColor));
        img.MergeAttributes(HtmlAttributeHelper.GetHtmlAttributeDictionaryOrNull(htmlAttributes));
        return gen.Add(img);
    }
}
