using System.Collections.Immutable;

namespace Carp.CodeAnalysis.Syntax
{
    public sealed class CallExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken Identifier { get; }
        public SyntaxToken OpenParenthesisToken { get; }
        public SeparatedSyntaxList<ExpressionSyntax> Args { get; }
        public SyntaxToken CloseParenthesisToken { get; }

        public override SyntaxKind Kind => SyntaxKind.CallExpression;

        public CallExpressionSyntax(SyntaxToken identifier, SyntaxToken openParenthesisToken, SeparatedSyntaxList<ExpressionSyntax> args, SyntaxToken closeParenthesisToken)
        {
            Identifier = identifier;
            OpenParenthesisToken = openParenthesisToken;
            Args = args;
            CloseParenthesisToken = closeParenthesisToken;
        }
    }
}