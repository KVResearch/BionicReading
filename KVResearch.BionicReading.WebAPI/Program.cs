using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/getStylisedText", (TextModel input) =>
{
    return new TextModel
    {
        OutputType = input.OutputType,
        Text = GetBoldedText(input.Text, GetConfig(input))
    };
});

app.Run();

bool isAlphabet(char c)
{
    return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
}

string GetBoldedText(string text, (string prefix, string suffix) config)
{
    var sb = new StringBuilder();
    var tmp = new StringBuilder();
    foreach (char c in text)
    {
        if (isAlphabet(c))
            tmp.Append(c);
        else
        {
            if (tmp.Length > 0)
            {
                string str = tmp.ToString();
                tmp.Clear();
                var boldLen = KVResearch.BionicReading.Library.Algorithm.GetBoldLength(str.Length);
                if (boldLen > 0)
                {
                    sb.Append(config.prefix);
                    sb.Append(str[..boldLen]);
                    sb.Append(config.suffix);
                    sb.Append(str[boldLen..]);
                }
                else
                    sb.Append(str);
            }
            sb.Append(c);
        }
    }
    return sb.ToString();

}

(string prefix, string suffix) GetConfig(OutputBase outputbase)
{
    return outputbase.OutputType switch
    {
        OutputType.HtmlBold => ("<b>", "</b>"),
        OutputType.HttpItalic => ("<i>", "</i>"),
        OutputType.HttpUnderline => ("<u>", "</u>"),
        OutputType.MarkdownBold => ("**", "**"),
        OutputType.MarkdownItalic => ("*", "*"),
        OutputType.MarkdownUnderline => ("_", "_"),
        OutputType.Customised => (outputbase.Prefix, outputbase.Suffix),
        _ => ("", ""),
    };
}

class TextModel : OutputBase
{
    public string Text { get; set; }

}

class OutputBase
{
    public OutputType OutputType { get; set; }
    public string? Prefix { get; set; }
    public string? Suffix { get; set; }
}

enum OutputType
{
    MarkdownBold,
    MarkdownItalic,
    MarkdownUnderline,
    HtmlBold,
    HttpItalic,
    HttpUnderline,
    Customised
}