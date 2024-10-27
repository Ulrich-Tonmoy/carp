using System.Collections.Immutable;

namespace Carp.CodeAnalysis.Symbols
{
    public sealed class FunctionSymbol : Symbol
    {
        public ImmutableArray<ParameterSymbol> Parameter { get; }
        public TypeSymbol Type { get; }

        public override SymbolKind Kind => SymbolKind.Function;

        public FunctionSymbol(string name, ImmutableArray<ParameterSymbol> parameter, TypeSymbol type) : base(name)
        {
            Parameter = parameter;
            Type = type;
        }
    }
}