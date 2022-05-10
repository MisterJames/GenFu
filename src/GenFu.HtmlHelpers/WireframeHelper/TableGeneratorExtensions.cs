namespace GenFu.HtmlHelpers.WireframeHelper;

using global::GenFu.HtmlHelpers.Utilities;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

public static class TableGeneratorExtensions
{
    public static WireframeGenerator Table(this WireframeGenerator gen, int rows = 5, object tableAttributes = null)
    {
        A.Configure<IpsumTableModel>()
            .Fill(cfg => cfg.Lorem).AsLoremIpsumWords(2)
            .Fill(cfg => cfg.Ipsum).AsLoremIpsumWords(3)
            .Fill(cfg => cfg.Aliquam).AsLoremIpsumWords(1);
        IList<IpsumTableModel> data = A.ListOf<IpsumTableModel>(rows);

        return gen.Add(CreateTableHtmlIpsum(data, tableAttributes));
    }

    public static WireframeGenerator Table<T>(
        this WireframeGenerator gen,
        int rows = 5, object tableAttributes = null) where T : new() =>
        gen.Add(CreateTableHtmlIpsum(A.ListOf<T>(rows), tableAttributes));

    private static IHtmlContent CreateTableHtmlIpsum<T>(IList<T> data, object tableAttributes) where T : new()
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
        table.MergeAttributes(HtmlAttributeHelper.GetHtmlAttributeDictionaryOrNull(tableAttributes));
        //table.MergeAttribute("class", "", false);
        table.InnerHtml.AppendHtml(tbody);

        return table;
    }

    private static IHtmlContent BuildTableHeader<T>()
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
}
