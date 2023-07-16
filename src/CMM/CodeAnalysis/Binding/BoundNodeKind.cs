namespace CMM.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        // Statements
        BlockStatement,
        VariableDeclaration,
        ExpressionStatement,
        IfStatement,
        WhileStatment,

        // Expressions
        BinaryExpression,
        UnaryExpression,
        LiteralExpression,
        VariableExpression,
        AssignmentExpression,
    }
}
