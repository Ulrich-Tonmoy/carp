namespace Carp.CodeAnalysis.Syntax
{
    public sealed class TypeClauseSyntax : SyntaxNode
    {
        public SyntaxToken ColonToke { get; }
        public SyntaxToken Identifier { get; }

        public override SyntaxKind Kind => SyntaxKind.TypeClause;

        public TypeClauseSyntax(SyntaxToken colonToke, SyntaxToken identifier)
        {
            ColonToke = colonToke;
            Identifier = identifier;
        }
    }
}