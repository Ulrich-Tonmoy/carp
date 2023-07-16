namespace CMM.CodeAnalysis.Syntax
{
    public sealed class ForStatementSyntax : StatementSyntax
    {
        public SyntaxToken Keyword { get; }
        public SyntaxToken Identifier { get; }
        public SyntaxToken EqualsToken { get; }
        public ExpressionSyntax LoweBound { get; }
        public SyntaxToken ToKeyword { get; }
        public ExpressionSyntax UpperBound { get; }
        public StatementSyntax Body { get; }

        public override SyntaxKind Kind => SyntaxKind.ForStatement;

        public ForStatementSyntax(SyntaxToken keyword, SyntaxToken identifier, SyntaxToken equalsToken, ExpressionSyntax loweBound, SyntaxToken toKeyword, ExpressionSyntax upperBound, StatementSyntax body)
        {
            Keyword = keyword;
            Identifier = identifier;
            EqualsToken = equalsToken;
            LoweBound = loweBound;
            ToKeyword = toKeyword;
            UpperBound = upperBound;
            Body = body;
        }
    }
}