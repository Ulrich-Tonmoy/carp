namespace Carp.CodeAnalysis.Symbols
{
    public sealed class TypeSymbol : Symbol
    {
        public override SymbolKind Kind => SymbolKind.Variable;

        internal TypeSymbol(string name) : base(name)
        {

        }
    }
}