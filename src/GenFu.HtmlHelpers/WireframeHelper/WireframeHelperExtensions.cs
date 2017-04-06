using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenFu.HtmlHelpers.WireframeHelper
{
    public static class WireframeHelperExtensions
    {
        public static WireframeGenerator GenFu(this IHtmlHelper html)
        {
            return new WireframeGenerator();
        }
    }
}
