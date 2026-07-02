namespace Carp.CodeAnalysis.Syntax
{
    public sealed class DoWhileStatementSyntax : StatementSyntax
    {
        public SyntaxToken DoKeyword { get; }
        public StatementSyntax Body { get; }
        public SyntaxToken WhileKeyword { get; }
        public ExpressionSyntax Condition { get; }
        public override SyntaxKind Kind => SyntaxKind.DoWhileStatement;

        public DoWhileStatementSyntax(SyntaxToken doKeyword, StatementSyntax body, SyntaxToken whileKeyword, ExpressionSyntax condition)
        {
            DoKeyword = doKeyword;
            Body = body;
            WhileKeyword = whileKeyword;
            Condition = condition;
        }
    }
}