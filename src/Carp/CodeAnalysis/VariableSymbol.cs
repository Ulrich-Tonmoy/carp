﻿namespace Carp.CodeAnalysis
{
    public sealed class VariableSymbol
    {
        public string Name { get; }
        public bool IsReadOnly { get; }
        public Type Type { get; }

        public override string ToString() => Name;

        internal VariableSymbol(string name, bool isReadOnly, Type type)
        {
            Name = name;
            IsReadOnly = isReadOnly;
            Type = type;
        }
    }
}