using GenFu.ValueGenerators.Lorem;

namespace GenFu.HtmlHelpers.WireframeHelper
{
    public static class HeadingGeneratorExtensions
    {
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
        public static WireframeGenerator H1(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 1, wordCount, htmlAttributes);

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
        public static WireframeGenerator H2(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 2, wordCount, htmlAttributes);

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
        public static WireframeGenerator H3(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 3, wordCount, htmlAttributes);

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
        public static WireframeGenerator H4(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 4, wordCount, htmlAttributes);

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
        public static WireframeGenerator H5(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 5, wordCount, htmlAttributes);

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
        public static WireframeGenerator H6(
            this WireframeGenerator gen, 
            int wordCount = 2, 
            object htmlAttributes = null) => BufferH(gen, 6, wordCount, htmlAttributes);

        private static WireframeGenerator BufferH(
            WireframeGenerator gen, 
            int level, 
            int wordCount = 2, 
            object htmlAttributes = null) => gen.Add(
                    WireframeGenerator.GenerateHtmlIpsum($"h{level}", () => Lorem.GenerateWords(wordCount), htmlAttributes)
                );

    }
}
