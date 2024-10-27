# Line numbers and clean-up

[Previous](docs-4.md) |
[Next](docs-6.md)

## Completed items

- Clean-up
- Added `SourceText`, which allows us to compute line number information

## Interesting aspects

### Positions and Line Numbers

Our entire frontend is referring to the input as positions, i.e. a zero-based
offset into the text that was parsed. Positions are awesome because you can
easily do math on them. Unfortunately, they aren't great for error reporting.
What you really want is line number and character position.

We added the concept of `SourceText` which you can think of as
representing the document the user is editing. It's immutable and it has a
collection of line information. The `SourceText` is stored on the `SyntaxTree`
and can be used to get the index of a line given a position:

```C#
var lineIndex = syntaxTree.Text.GetLineIndex(diagnostic.Span.Start);
var line = syntaxTree.Text.Lines[lineIndex];
var lineNumber = lineIndex + 1;
var character = diagnostic.Span.Start - line.Start + 1;
```

### Computing line indexes

`SourceText` has a collection of `TextLines` which know the start
and end positions for each line. In order to compute a line index, we only
have to perform a binary search:

```C#
public int GetLineIndex(int position)
{
    var lower = 0;
    var upper = Lines.Length - 1;

    while (lower <= upper)
    {
        var index = lower + (upper - lower) / 2;
        var start = Lines[index].Start;

        if (position == start)
            return index;

        if (start > position)
        {
            upper = index - 1;
        }
        else
        {
            lower = index + 1;
        }
    }

    return lower - 1;
}
```
