namespace CMM.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        NotToken,
        EqualToken,
        AndToken,
        OrToken,
        EqualityToken,
        NotEqualToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        OpenBraceToken,
        CloseBraceToken,
        IdentifierToken,

        //Keywords
        TrueKeyword,
        FalseKeyword,

        // Nodes
        CompilationUnit,

        // Statements
        BlockStatement,
        ExpressionStatement,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
        NameExpression,
        AssignmentExpression,
    }
}