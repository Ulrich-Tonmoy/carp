﻿namespace Carp.CodeAnalysis.Symbols
{
    public sealed class VariableSymbol : Symbol
    {
        public override SymbolKind Kind => SymbolKind.Variable;
        public bool IsReadOnly { get; }
        public Type Type { get; }


        internal VariableSymbol(string name, bool isReadOnly, Type type) : base(name)
        {
            IsReadOnly = isReadOnly;
            Type = type;
        }
    }
}