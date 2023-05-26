namespace CMM.CodeAnalysis.Syntax
{
    public sealed class AssignmentExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken IdentifierToken { get; }
        public SyntaxToken EqualToken { get; }
        public ExpressionSyntax Expression { get; }

        public override SyntaxKind Kind => SyntaxKind.AssignmentExpression;

        public AssignmentExpressionSyntax(SyntaxToken identifierToken, SyntaxToken equalToken, ExpressionSyntax expression)
        {
            IdentifierToken = identifierToken;
            EqualToken = equalToken;
            Expression = expression;
        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return IdentifierToken;
            yield return EqualToken;
            yield return Expression;
        }
    }
}