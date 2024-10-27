using Carp.CodeAnalysis.Symbols;
using System.Collections.Immutable;

namespace Carp.CodeAnalysis.Binding
{
    internal sealed class BoundCallExpression : BoundExpression
    {
        public FunctionSymbol Function { get; }
        public ImmutableArray<BoundExpression> Args { get; }

        public override TypeSymbol Type => Function.Type;

        public override BoundNodeKind Kind => BoundNodeKind.CallExpression;

        public BoundCallExpression(FunctionSymbol function, ImmutableArray<BoundExpression> args)
        {
            Function = function;
            Args = args;
        }
    }
}
