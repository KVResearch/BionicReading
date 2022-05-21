# Bionic Reading

This repository is inspired by original [Bionic Reading](https://bionic-reading.com/) project.
I have implemented the basic function with .NET and ASP.NET Core which might provide a pretty
cool and simple experience.

## API (without *s*)

```
[POST] /getStylisedText
==========================================================
REQUEST
==========================================================
TYPE   Json
STRUCT {
           string Text
           string OutputType { MarkdownBold, MarkdownItalic, 
                               MarkdownUnderline, HtmlBold,
                               HttpItalic, HttpUnderline,
                               Customised }
           string Prefix (Optional, only valid when OuputType = Customised)
           string Suffix (Optional, only valid when OuputType = Customised)
       }
==========================================================
RETURN
==========================================================
TYPE   Json
STRUCT {
           string Text
           string OutputType { MarkdownBold, MarkdownItalic, 
                               MarkdownUnderline, HtmlBold,
                               HttpItalic, HttpUnderline,
                               Customised }
       }
```
