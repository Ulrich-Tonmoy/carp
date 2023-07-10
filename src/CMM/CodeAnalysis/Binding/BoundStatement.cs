namespace CMM.CodeAnalysis.Binding
{
    internal abstract class BoundStatement : BoundNode
    {

    }
    internal sealed class BoundVariableDeclaration : BoundStatement
    {
        public VariableSymbol Variable { get; }
        public BoundExpression Initializer { get; }
        public override BoundNodeKind Kind => BoundNodeKind.VariableDeclaration;

        public BoundVariableDeclaration(VariableSymbol variable, BoundExpression initializer)
        {
            Variable = variable;
            Initializer = initializer;
        }
    }
    internal sealed class BoundIfStatement : BoundStatement
    {
        public BoundExpression Condition { get; }
        public BoundStatement ThenStatement { get; }
        public BoundStatement ElseStatement { get; }
        public override BoundNodeKind Kind => BoundNodeKind.IfStatement;

        public BoundIfStatement(BoundExpression condition, BoundStatement thenStatement, BoundStatement elseStatement)
        {
            Condition = condition;
            ThenStatement = thenStatement;
            ElseStatement = elseStatement;
        }
    }
}
