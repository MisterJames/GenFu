namespace GenFu.HtmlHelpers.WireframeHelper;

using Microsoft.AspNetCore.Mvc.Rendering;

public static class WireframeHelperExtensions
{
    public static WireframeGenerator GenFu(this IHtmlHelper html) => new WireframeGenerator();
}
