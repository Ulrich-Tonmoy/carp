namespace CMM.CodeAnalysis.Syntax
{
    public sealed class CompilationUnitSyntax : SyntaxNode
    {
        public StatementSyntax Statement { get; }
        public SyntaxToken EndOfFileToken { get; }

        public override SyntaxKind Kind => SyntaxKind.CompilationUnit;

        public CompilationUnitSyntax(StatementSyntax statement, SyntaxToken endOfFileToken)
        {
            Statement = statement;
            EndOfFileToken = endOfFileToken;
        }
    }
}