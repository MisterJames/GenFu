using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenFu.HtmlHelpers.WireframeHelper
{
    public static class WireframeHelperExtensions
    {
        public static WireframeGenerator Genfu(this IHtmlHelper html)
        {
            return new WireframeGenerator();
        }
    }
}
