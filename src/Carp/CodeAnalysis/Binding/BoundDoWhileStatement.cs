namespace Carp.CodeAnalysis.Binding
{
    internal sealed class BoundDoWhileStatement : BoundStatement
    {
        public BoundStatement Body { get; }
        public BoundExpression Condition { get; }
        public override BoundNodeKind Kind => BoundNodeKind.DoWhileStatement;

        public BoundDoWhileStatement(BoundStatement body, BoundExpression condition)
        {
            Body = body;
            Condition = condition;
        }
    }
}
