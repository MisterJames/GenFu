namespace GenFu.HtmlHelpers.WireframeHelper;

using global::GenFu.ValueGenerators.Lorem;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

public class WireframeGenerator : IHtmlContent
{
    private readonly List<IHtmlContent> contentBuffer;

    public WireframeGenerator()
    {
        contentBuffer = new List<IHtmlContent>();
    }

    public WireframeGenerator(IHtmlContent buffer, IHtmlContent next)
    {
        contentBuffer = new List<IHtmlContent>();
        contentBuffer.Add(buffer);
        contentBuffer.Add(next);
    }

    public WireframeGenerator Add(IHtmlContent content) => new WireframeGenerator(this, content);

    public IHtmlContent Words(int count)
    {
        var words = Lorem.GenerateWords(count);
        return new HtmlString(words);
    }

    public IHtmlContent Paragraphs(int count)
    {
        var paragraphs = Lorem.GenerateSentences(count);
        return new HtmlString(paragraphs);
    }

    /// <summary>
    /// Gets a p element containing lorem ipsum
    /// </summary>
    /// <example>To create 3 paragraphs each 6 sentences nested in HTML 'p' tags.
    /// <code>@Html.p(3, 6)</code>
    /// </example>
    /// <param name="paragraphCount"></param>
    /// <param name="sentenceCount"></param>
    /// <param name="htmlAttributes"></param>
    /// <returns></returns>
    public WireframeGenerator P(int paragraphCount = 1, int sentenceCount = 5, object htmlAttributes = null)
    {
        for (int i = 0; i < paragraphCount; i++)
        {
            contentBuffer.Add(GenerateHtmlIpsum("p", () => Lorem.GenerateSentences(sentenceCount), htmlAttributes));
        }
        return this;
    }

    public static TagBuilder GenerateHtmlIpsum(
        string tag,
        Func<string> filler,
        object htmlAttributes = null)
    {
        TagBuilder element = new TagBuilder(tag);
        element.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        element.InnerHtml.SetContent(filler());
        return element;
    }

    public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    {
        foreach (var bufferedItem in contentBuffer)
        {
            bufferedItem.WriteTo(writer, encoder);
        }
    }
}
