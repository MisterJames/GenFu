namespace GenFu.HtmlHelpers.Utilities;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

using System.Collections.Generic;

public static class HtmlAttributeHelper
{
    // Only need a dictionary if htmlAttributes is non-null. TagBuilder.MergeAttributes() is fine with null.
    public static IDictionary<string, object> GetHtmlAttributeDictionaryOrNull(object htmlAttributes)
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
}
