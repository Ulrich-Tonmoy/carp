namespace CMM.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        // Statements
        BlockStatement,
        ExpressionStatement,

        // Expressions
        BinaryExpression,
        UnaryExpression,
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
    }
}
