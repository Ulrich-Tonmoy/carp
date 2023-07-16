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
        LessThanToken,
        LessThanOrEqualToken,
        GreaterThanToken,
        GreaterThanOrEqualToken,

        //Keywords
        IfKeyword,
        ElseKeyword,
        TrueKeyword,
        FalseKeyword,
        ConstKeyword,
        VarKeyword,
        LetKeyword,
        ForKeyword,
        ToKeyword,
        WhileKeyword,

        // Nodes
        CompilationUnit,
        ElseClause,

        // Statements
        BlockStatement,
        VariableDeclaration,
        ExpressionStatement,
        IfStatement,
        ForStatement,
        WhileStatement,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
        NameExpression,
        AssignmentExpression,
    }
}