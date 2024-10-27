using Carp.CodeAnalysis.Symbols;
using static Carp.CodeAnalysis.Binding.BoundCallExpression;

namespace Carp.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract TypeSymbol Type { get; }
    }
}
