namespace Carp.CodeAnalysis.Syntax
{
    public static class SyntaxFacts
    {
        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                case SyntaxKind.NotToken:
                case SyntaxKind.TildeToken:
                    return 6;

                default:
                    return 0;
            }
        }

        public static IEnumerable<SyntaxKind> GetUnaryOperatorKinds()
        {
            var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
            foreach (var kind in kinds)
            {
                if (GetUnaryOperatorPrecedence(kind) > 0)
                    yield return kind;
            }
        }

        public static IEnumerable<SyntaxKind> GetBinaryOperatorKinds()
        {
            var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
            foreach (var kind in kinds)
            {
                if (GetBinaryOperatorPrecedence(kind) > 0)
                    yield return kind;
            }
        }

        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.StarToken:
                case SyntaxKind.SlashToken:
                    return 5;

                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 4;

                case SyntaxKind.EqualityToken:
                case SyntaxKind.NotEqualToken:
                case SyntaxKind.LessThanToken:
                case SyntaxKind.LessThanOrEqualToken:
                case SyntaxKind.GreaterThanToken:
                case SyntaxKind.GreaterThanOrEqualToken:
                    return 3;

                case SyntaxKind.AndToken:
                case SyntaxKind.AndAndToken:
                    return 2;
                case SyntaxKind.OrToken:
                case SyntaxKind.OrOrToken:
                case SyntaxKind.HatToken:
                    return 1;

                default:
                    return 0;
            }
        }

        public static SyntaxKind GetKeywordKind(string text)
        {
            switch (text)
            {
                case "else":
                    return SyntaxKind.ElseKeyword;
                case "if":
                    return SyntaxKind.IfKeyword;
                case "true":
                    return SyntaxKind.TrueKeyword;
                case "false":
                    return SyntaxKind.FalseKeyword;
                case "const":
                    return SyntaxKind.ConstKeyword;
                case "var":
                    return SyntaxKind.VarKeyword;
                case "let":
                    return SyntaxKind.LetKeyword;
                case "for":
                    return SyntaxKind.ForKeyword;
                case "to":
                    return SyntaxKind.ToKeyword;
                case "while":
                    return SyntaxKind.WhileKeyword;
                case "do":
                    return SyntaxKind.DoKeyword;
                default:
                    return SyntaxKind.IdentifierToken;
            }
        }

        public static string GetText(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.PlusToken:
                    return "+";
                case SyntaxKind.MinusToken:
                    return "-";
                case SyntaxKind.StarToken:
                    return "*";
                case SyntaxKind.SlashToken:
                    return "/";
                case SyntaxKind.NotToken:
                    return "!";
                case SyntaxKind.EqualToken:
                    return "=";
                case SyntaxKind.TildeToken:
                    return "~";
                case SyntaxKind.LessThanToken:
                    return "<";
                case SyntaxKind.LessThanOrEqualToken:
                    return "<=";
                case SyntaxKind.GreaterThanToken:
                    return ">";
                case SyntaxKind.GreaterThanOrEqualToken:
                    return ">=";
                case SyntaxKind.AndToken:
                    return "&";
                case SyntaxKind.AndAndToken:
                    return "&&";
                case SyntaxKind.OrToken:
                    return "|";
                case SyntaxKind.OrOrToken:
                    return "||";
                case SyntaxKind.HatToken:
                    return "^";
                case SyntaxKind.EqualityToken:
                    return "==";
                case SyntaxKind.NotEqualToken:
                    return "!=";
                case SyntaxKind.OpenParenthesisToken:
                    return "(";
                case SyntaxKind.CloseParenthesisToken:
                    return ")";
                case SyntaxKind.OpenBraceToken:
                    return "{";
                case SyntaxKind.CloseBraceToken:
                    return "}";
                case SyntaxKind.CommaToken:
                    return ",";
                case SyntaxKind.ElseKeyword:
                    return "else";
                case SyntaxKind.IfKeyword:
                    return "if";
                case SyntaxKind.FalseKeyword:
                    return "false";
                case SyntaxKind.TrueKeyword:
                    return "true";
                case SyntaxKind.ConstKeyword:
                    return "const";
                case SyntaxKind.VarKeyword:
                    return "var";
                case SyntaxKind.LetKeyword:
                    return "let";
                case SyntaxKind.ForKeyword:
                    return "for";
                case SyntaxKind.ToKeyword:
                    return "to";
                case SyntaxKind.WhileKeyword:
                    return "while";
                case SyntaxKind.DoKeyword:
                    return "do";
                default:
                    return null;
            }
        }
    }
}