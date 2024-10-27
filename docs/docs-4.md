# Making testing a blast

[Previous](docs-3.md) |
[Next](docs-5.md)

## Completed items

- Added tests for lexing all tokens and their combinations
- Added tests for parsing unary and binary operators
- Added tests for evaluating

## Interesting aspects

### Testing the lexer

Having a test that lexes all tokens is somewhat simple. In order to avoid
repetition, I've used xUnit theories, which allows me to parameterize the unit
test. You can see how this looks like in LexerTests:

```C#
[Theory]
[MemberData(nameof(GetTokensData))]
public void Lexer_Lexes_Token(SyntaxKind kind, string text)
{
    var tokens = SyntaxTree.ParseTokens(text);

    var token = Assert.Single(tokens);
    Assert.Equal(kind, token.Kind);
    Assert.Equal(text, token.Text);
}

public static IEnumerable<object[]> GetTokensData()
{
    foreach (var t in GetTokens())
        yield return new object[] { t.kind, t.text };
}

private static IEnumerable<(SyntaxKind kind, string text)> GetTokens()
{
    return new[]
    {
        (SyntaxKind.PlusToken, "+"),
        (SyntaxKind.MinusToken, "-"),
        (SyntaxKind.StarToken, "*"),
        (SyntaxKind.SlashToken, "/"),
        (SyntaxKind.BangToken, "!"),
        (SyntaxKind.EqualsToken, "="),
        (SyntaxKind.AmpersandAmpersandToken, "&&"),
        (SyntaxKind.PipePipeToken, "||"),
        (SyntaxKind.EqualsEqualsToken, "=="),
        (SyntaxKind.BangEqualsToken, "!="),
        (SyntaxKind.OpenParenthesisToken, "("),
        (SyntaxKind.CloseParenthesisToken, ")"),
        (SyntaxKind.FalseKeyword, "false"),
        (SyntaxKind.TrueKeyword, "true"),
        (SyntaxKind.NumberToken, "1"),
        (SyntaxKind.NumberToken, "123"),
        (SyntaxKind.IdentifierToken, "a"),
        (SyntaxKind.IdentifierToken, "abc"),
    };
}
```

However, the issue is that the lexer makes a bunch of decisions based on the
next character. Thus, generally want to make sure that it can
handle virtually arbitrary combinations of characters after the token that
actually is lexable. One way to do this is generate pairs of tokens and verify
that they lex:

```C#
[Theory]
[MemberData(nameof(GetTokenPairsData))]
public void Lexer_Lexes_TokenPairs(SyntaxKind t1Kind, string t1Text,
                                    SyntaxKind t2Kind, string t2Text)
{
    var text = t1Text + t2Text;
    var tokens = SyntaxTree.ParseTokens(text).ToArray();

    Assert.Equal(2, tokens.Length);
    Assert.Equal(tokens[0].Kind, t1Kind);
    Assert.Equal(tokens[0].Text, t1Text);
    Assert.Equal(tokens[1].Kind, t2Kind);
    Assert.Equal(tokens[1].Text, t2Text);
}
```

The tricky thing there is that certain tokens cannot actually appear directly
after each other. For example, you cannot parse two identifiers as they would
generally parse as one. Similarly, certain operators will be combined when they
appear next to each other (e.g. `!` and `=`). Thus, only generate pairs
where the combination doesn't require a separator.

```C#
private static IEnumerable<(SyntaxKind t1Kind, string t1Text, SyntaxKind t2Kind, string t2Text)> GetTokenPairs()
{
    foreach (var t1 in GetTokens())
    {
        foreach (var t2 in GetTokens())
        {
            if (!RequiresSeparator(t1.kind, t2.kind))
                yield return (t1.kind, t1.text, t2.kind, t2.text);
        }
    }
}
```

Checking whether combinations require separators is pretty
straight forward too:

```C#
private static bool RequiresSeparator(SyntaxKind t1Kind, SyntaxKind t2Kind)
{
    var t1IsKeyword = t1Kind.ToString().EndsWith("Keyword");
    var t2IsKeyword = t2Kind.ToString().EndsWith("Keyword");

    if (t1Kind == SyntaxKind.IdentifierToken && t2Kind == SyntaxKind.IdentifierToken)
        return true;

    if (t1IsKeyword && t2IsKeyword)
        return true;

    if (t1IsKeyword && t2Kind == SyntaxKind.IdentifierToken)
        return true;

    if (t1Kind == SyntaxKind.IdentifierToken && t2IsKeyword)
        return true;

    if (t1Kind == SyntaxKind.NumberToken && t2Kind == SyntaxKind.NumberToken)
        return true;

    if (t1Kind == SyntaxKind.BangToken && t2Kind == SyntaxKind.EqualsToken)
        return true;

    if (t1Kind == SyntaxKind.BangToken && t2Kind == SyntaxKind.EqualsEqualsToken)
        return true;

    if (t1Kind == SyntaxKind.EqualsToken && t2Kind == SyntaxKind.EqualsToken)
        return true;

    if (t1Kind == SyntaxKind.EqualsToken && t2Kind == SyntaxKind.EqualsEqualsToken)
        return true;

    return false;
}
```

### Testing binary operators

One of the key things that need to be made sure is that the parser honors priorities
of binary and unary operators and produces correctly shaped trees. One way to do
this is by flatting the tree and simply asserting the sequence of nodes and
tokens. To make life easier, wrote [a class] that holds on to an
`IEnumerator<SyntaxNode>` and offers public APIs for asserting nodes and tokens.
This allows writing fairly concise tests:

```C#
//     op2
//    /   \
//   op1   c
//  /   \
// a     b

using (var e = new AssertingEnumerator(expression))
{
    e.AssertNode(SyntaxKind.BinaryExpression);
    e.AssertNode(SyntaxKind.BinaryExpression);
    e.AssertNode(SyntaxKind.NameExpression);
    e.AssertToken(SyntaxKind.IdentifierToken, "a");
    e.AssertToken(op1, op1Text);
    e.AssertNode(SyntaxKind.NameExpression);
    e.AssertToken(SyntaxKind.IdentifierToken, "b");
    e.AssertToken(op2, op2Text);
    e.AssertNode(SyntaxKind.NameExpression);
    e.AssertToken(SyntaxKind.IdentifierToken, "c");
}
```

It's done for both binary operators as well as for
unary operators combined with binary operators.
