using Carp.CodeAnalysis.Symbols;

namespace Carp.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }
}
