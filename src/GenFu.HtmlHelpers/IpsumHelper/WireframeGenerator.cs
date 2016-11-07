using GenFu.ValueGenerators.Lorem;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Reflection;


namespace GenFu.HtmlHelpers.WireframeHelper
{
    public class WireframeGenerator : IHtmlContent
    {
        private readonly List<IHtmlContent> contentBuffer;

        public WireframeGenerator()
        {
            contentBuffer = new List<IHtmlContent>();
        }

        public WireframeGenerator Words(int count)
        {
            var words = Lorem.GenerateWords(count);
            contentBuffer.Add(new HtmlString(words));
            return this;
        }

        public WireframeGenerator Paragraphs(int count)
        {
            var paragraphs = Lorem.GenerateSentences(count);
            contentBuffer.Add(new HtmlString(paragraphs));
            return this;
        }

        #region H Elements
        /// <summary>
        /// <summary>
        /// Gets an h1 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h1 tag containing Lorem Ipsum.
        /// <code>@Html.h1()</code>
        /// </example>
        /// <example>To create an HTML h1 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h1(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H1(int wordCount = 2, object htmlAttributes = null) => BufferH(1, wordCount, htmlAttributes);

        /// <summary>
        /// Gets an h2 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h2 tag containing Lorem Ipsum.
        /// <code>@Html.h2()</code>
        /// </example>
        /// <example>To create an HTML h2 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h2(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H2(int wordCount = 2, object htmlAttributes = null) => BufferH(2, wordCount, htmlAttributes);

        /// <summary>
        /// Gets an h3 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h3 tag containing Lorem Ipsum.
        /// <code>@Html.h3()</code>
        /// </example>
        /// <example>To create an HTML h3 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h3(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H3(int wordCount = 2, object htmlAttributes = null) => BufferH(3, wordCount, htmlAttributes);
        /// <summary>
        /// Gets an h4 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h4 tag containing Lorem Ipsum.
        /// <code>@Html.h4()</code>
        /// </example>
        /// <example>To create an HTML h4 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h4(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H4(int wordCount = 2, object htmlAttributes = null) => BufferH(4, wordCount, htmlAttributes);
        /// <summary>
        /// Gets an h5 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h5 tag containing Lorem Ipsum.
        /// <code>@Html.h5()</code>
        /// </example>
        /// <example>To create an HTML h5 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h5(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H5(int wordCount = 2, object htmlAttributes = null) => BufferH(5, wordCount, htmlAttributes);
        /// <summary>
        /// Gets an h6 element containing lorem ipsum
        /// </summary>
        /// <example>To create an HTML h6 tag containing Lorem Ipsum.
        /// <code>@Html.h6()</code>
        /// </example>
        /// <example>To create an HTML h6 tag containing three Lorem Ipsum words and with attributes.
        /// <code>@Html.h6(3, new { @class = "my-css-class"})</code>
        /// </example>
        /// <param name="wordCount">Number of words to create</param>
        /// <param name="htmlAttributes">Html attributes</param>
        /// <returns></returns>
        public WireframeGenerator H6(int wordCount = 2, object htmlAttributes = null) => BufferH(6, wordCount, htmlAttributes);

        private WireframeGenerator BufferH(int level, int wordCount = 2, object htmlAttributes = null) =>
            Buffer(GenerateHtmlIpsum($"h{level}", () => Lorem.GenerateWords(wordCount), htmlAttributes));

        #endregion

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
        public WireframeGenerator Ul(int listCount = 5, int wordCount = 2, bool links = false, object ulAttributes = null, object liAttributes = null) =>
            Buffer(GenerateListHtmlIpsum("ul", "li", listCount, links, liAttributes, wordCount, ulAttributes));

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
        public WireframeGenerator Ol(int listCount = 5, int wordCount = 2, bool links = false, object olAttributes = null, object liAttributes = null) =>
            Buffer(GenerateListHtmlIpsum("ol", "li", listCount, links, liAttributes, wordCount, olAttributes));

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
        public WireframeGenerator Dl(int listCount = 5, int wordCount = 2, bool links = false, object dlAttributes = null, object ddAttributes = null) =>
            Buffer(GenerateListHtmlIpsum("dl", "dd", listCount, links, ddAttributes, wordCount, dlAttributes));

        public WireframeGenerator Table(int rows = 5)
        {
            A.Configure<IpsumTableModel>()
                .Fill(cfg => cfg.Lorem).AsLoremIpsumWords(2)
                .Fill(cfg => cfg.Ipsum).AsLoremIpsumWords(3)
                .Fill(cfg => cfg.Aliquam).AsLoremIpsumWords(1);
            IList<IpsumTableModel> data = A.ListOf<IpsumTableModel>(rows);

            return Buffer(CreateTableHtmlIpsum(data, null));
        }

        public WireframeGenerator Table<T>(int rows = 5) where T : new() => Buffer(CreateTableHtmlIpsum(A.ListOf<T>(rows), null));

        private TagBuilder GenerateHtmlIpsum(
            string tag,
            Func<string> filler,
            object htmlAttributes = null)
        {
            TagBuilder element = new TagBuilder(tag);
            element.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            element.InnerHtml.SetContent(filler());
            return element;
        }

        private IHtmlContent GenerateListHtmlIpsum(string outer, string inner, int listCount, bool links, object liAttributes, int wordCount, object ulAttributes)
        {
            TagBuilder element = new TagBuilder(outer);
            for (int i = 0; i < listCount; i++)
            {
                if (links)
                {
                    TagBuilder li = new TagBuilder(inner);
                    li.MergeAttributes(GetHtmlAttributeDictionaryOrNull(liAttributes));
                    li.InnerHtml.SetHtmlContent(GenerateHtmlIpsum("a", () => Lorem.GenerateWords(wordCount), GetHtmlAttributeDictionaryOrNull(new { href = "#" })));
                    element.InnerHtml.AppendHtml(li);
                }
                else
                {
                    element.InnerHtml.AppendHtml(GenerateHtmlIpsum(inner, () => Lorem.GenerateWords(wordCount), liAttributes));
                }
            }
            element.MergeAttributes(GetHtmlAttributeDictionaryOrNull(ulAttributes));

            return element;
        }

        private IHtmlContent CreateTableHtmlIpsum<T>(IList<T> data, object tableAttributes) where T : new()
        {
            TagBuilder table = new TagBuilder("table");
            table.InnerHtml.SetHtmlContent(BuildTableHeader<T>());

            TagBuilder tbody = new TagBuilder("tbody");
            foreach (var item in data)
            {
                TagBuilder tr = new TagBuilder("tr");
                foreach (var property in typeof(T).GetProperties())
                {
                    TagBuilder td = new TagBuilder("td");
                    td.InnerHtml.SetContent(property.GetValue(item).ToString());
                   tr.InnerHtml.AppendHtml(td);
                }
                tbody.InnerHtml.AppendHtml(tr);
            }
            table.MergeAttributes(GetHtmlAttributeDictionaryOrNull(tableAttributes));
            table.MergeAttribute("class", "table table-striped", false);
            table.InnerHtml.AppendHtml(tbody);

            return table;

        }

        private IHtmlContent BuildTableHeader<T>()
        {

            TagBuilder thr = new TagBuilder("tr"); //<tr>

            var type = typeof(T);
            foreach (var property in typeof(T).GetProperties())
            {
                TagBuilder th = new TagBuilder("th"); // <th>
                TagBuilder a = new TagBuilder("a"); // <a>
                a.InnerHtml.SetContent(property.Name);
                a.MergeAttribute("href", "#");
                th.InnerHtml.SetHtmlContent(a); //</a>
                thr.InnerHtml.AppendHtml(th); //<tr><th><a></a></th></tr>
            }

            TagBuilder thead = new TagBuilder("thead");
            thead.InnerHtml.SetHtmlContent(thr);
            return thead;
        }

        // Only need a dictionary if htmlAttributes is non-null. TagBuilder.MergeAttributes() is fine with null.
        private static IDictionary<string, object> GetHtmlAttributeDictionaryOrNull(object htmlAttributes)
        {
            IDictionary<string, object> htmlAttributeDictionary = null;
            if (htmlAttributes != null)
            {
                htmlAttributeDictionary = htmlAttributes as IDictionary<string, object>;
                if (htmlAttributeDictionary == null)
                {
                    htmlAttributeDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                }
            }

            return htmlAttributeDictionary;
        }

        private WireframeGenerator Buffer(IHtmlContent content)
        {
            contentBuffer.Add(content);
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            foreach (var bufferedItem in contentBuffer)
            {
                bufferedItem.WriteTo(writer, encoder);
            }
        }
    }
}
