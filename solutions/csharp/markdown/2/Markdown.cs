using System.Text.RegularExpressions;

public static class Markdown
{
    private static readonly (string Delimiter, string Tag)[] DelimiterToTags = 
        [
            ("__", "strong"),
            ("_", "em"),
        ];
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag) => 
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");
    private static string ParseText(string markdown, bool list)
    {
        markdown = DelimiterToTags
            .Aggregate(markdown, (current, pair) =>
                Parse(current, pair.Delimiter, pair.Tag));
        return list ? markdown : Wrap(markdown, "p");
    }

    private static string? ParseHeader(string markdown, ref bool list)
    {
        var count = markdown.Take(7).TakeWhile(t => t == '#').Count();
        if (count is 0 or 7) return null;
        var headerHtml = Wrap(markdown[(count + 1)..], $"h{count}");
        headerHtml = list ? $"</ul>{headerHtml}" : headerHtml;
        list = false;
        return headerHtml;
    }

    private static string? ParseLineItem(string markdown, ref bool list)
    {
        if (!markdown.StartsWith('*')) return null;
        var innerHtml = Wrap(ParseText(markdown[2..], true), "li");
        if (list) return innerHtml;
        list = true;
        return $"<ul>{innerHtml}";
    }

    private static string ParseParagraph(string markdown, ref bool list)
    {
        var paragraphHtml = ParseText(markdown, false);
        if (!list) return paragraphHtml;
        list = false;
        return $"</ul>{paragraphHtml}";
    }

    private static string ParseLine(string markdown, ref bool list) =>
        ParseHeader(markdown, ref list) ??
        ParseLineItem(markdown, ref list) ??
        ParseParagraph(markdown, ref list);

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var list = false;
        var result = lines
            .Select(t => ParseLine(t, ref list))
            .Aggregate("", (current, lineResult) => current + lineResult);
        return list ? $"{result}</ul>" : result;
    }
}