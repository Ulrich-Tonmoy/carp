namespace Carp.CodeAnalysis.Symbols
{
    public abstract class Symbol
    {
        public abstract SymbolKind Kind { get; }
        public string Name { get; }
        public override string ToString() => Name;


        private protected Symbol(string name)
        {
            Name = name;
        }
    }
}