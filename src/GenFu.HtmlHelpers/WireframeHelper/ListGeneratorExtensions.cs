using GenFu.HtmlHelpers.Utilities;
using GenFu.ValueGenerators.Lorem;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenFu.HtmlHelpers.WireframeHelper
{
    public static class ListGeneratorExtensions
    {
        /// <summary>
        /// Gets a ul element containing lorem ipsum
        /// </summary>
        /// <example>To create a unordered list of Lorem Ipusm nested in HTML 'ul' tags.<code>@Html.ul()</code></example>
        /// <param name="listCount">Number of list items to create</param>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="links">List item will contain a link, ex: href="#"</param>
        /// <param name="ulAttributes">ul element attributes</param>
        /// <param name="liAttributes">li element attributes</param>
        /// <returns></returns>
        public static WireframeGenerator Ul(this WireframeGenerator gen, int listCount = 5, int wordCount = 2, bool links = false, object ulAttributes = null, object liAttributes = null) =>
            gen.Add(GenerateListHtmlIpsum("ul", "li", listCount, links, liAttributes, wordCount, ulAttributes));

        /// <summary>
        /// Gets a ol element containing lorem ipsum
        /// </summary>
        /// <example>To create a unordered list of Lorem Ipusm nested in HTML 'ol' tags.<code>@Html.ol()</code></example>
        /// <param name="listCount">Number of list items to create</param>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="links">List item will contain a link, ex: href="#"</param>
        /// <param name="olAttributes">ol element attributes</param>
        /// <param name="liAttributes">li element attributes</param>
        /// <returns></returns>
        public static WireframeGenerator Ol(this WireframeGenerator gen, int listCount = 5, int wordCount = 2, bool links = false, object olAttributes = null, object liAttributes = null) =>
            gen.Add(GenerateListHtmlIpsum("ol", "li", listCount, links, liAttributes, wordCount, olAttributes));

        /// <summary>
        /// Gets a dl element containing lorem ipsum
        /// </summary>
        /// <example>To create a unordered list of Lorem Ipusm nested in HTML 'dl' tags.<code>@Html.dl()</code></example>
        /// <param name="listCount">Number of list items to create</param>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="links">List item will contain a link, ex: href="#"</param>
        /// <param name="dlAttributes">dl element attributes</param>
        /// <param name="ddAttributes">dd element attributes</param>
        /// <returns></returns>
        public static WireframeGenerator Dl(this WireframeGenerator gen, int listCount = 5, int wordCount = 2, bool links = false, object dlAttributes = null, object ddAttributes = null) =>
            gen.Add(GenerateListHtmlIpsum("dl", "dd", listCount, links, ddAttributes, wordCount, dlAttributes));

        private static IHtmlContent GenerateListHtmlIpsum(string outer, string inner, int listCount, bool links, object liAttributes, int wordCount, object ulAttributes)
        {
            TagBuilder element = new TagBuilder(outer);
            for (int i = 0; i < listCount; i++)
            {
                if (links)
                {
                    TagBuilder li = new TagBuilder(inner);
                    li.MergeAttributes(HtmlAttributeHelper.GetHtmlAttributeDictionaryOrNull(liAttributes));
                    li.InnerHtml.SetHtmlContent(WireframeGenerator.GenerateHtmlIpsum("a", () => Lorem.GenerateWords(wordCount), HtmlAttributeHelper.GetHtmlAttributeDictionaryOrNull(new { href = "#" })));
                    element.InnerHtml.AppendHtml(li);
                }
                else
                {
                    element.InnerHtml.AppendHtml(WireframeGenerator.GenerateHtmlIpsum(inner, () => Lorem.GenerateWords(wordCount), liAttributes));
                }
            }
            element.MergeAttributes(HtmlAttributeHelper.GetHtmlAttributeDictionaryOrNull(ulAttributes));

            return element;
        }

    }
}
