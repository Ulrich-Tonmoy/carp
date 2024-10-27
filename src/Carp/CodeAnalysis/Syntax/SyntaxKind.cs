namespace Carp.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        StringToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        NotToken,
        EqualToken,
        TildeToken,
        HatToken,
        AndToken,
        AndAndToken,
        OrToken,
        OrOrToken,
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
        CommaToken,

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
        DoKeyword,

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
        DoWhileStatement,

        // Expressions
        LiteralExpression,
        NameExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
        AssignmentExpression,
        CallExpression,
    }
}