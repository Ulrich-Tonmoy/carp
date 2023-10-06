namespace Carp.CodeAnalysis.Syntax
{
    public sealed class ElseClauseSyntax : SyntaxNode
    {
        public SyntaxToken ElseKeyword { get; }
        public StatementSyntax ElseStatement { get; }

        public override SyntaxKind Kind => SyntaxKind.ElseClause;

        public ElseClauseSyntax(SyntaxToken elseKeyword, StatementSyntax elseStatement)
        {
            ElseKeyword = elseKeyword;
            ElseStatement = elseStatement;
        }
    }
}