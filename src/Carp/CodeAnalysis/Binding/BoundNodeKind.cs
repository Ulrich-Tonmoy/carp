namespace Carp.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        // Statements
        BlockStatement,
        VariableDeclaration,
        ExpressionStatement,
        IfStatement,
        ForStatement,
        WhileStatement,
        LabelStatement,
        GotoStatement,
        ConditionalGotoStatement,
        DoWhileStatement,

        // Expressions
        BinaryExpression,
        UnaryExpression,
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
        ErrorExpression,
        CallExpression,
        ConversionExpression,
    }
}
