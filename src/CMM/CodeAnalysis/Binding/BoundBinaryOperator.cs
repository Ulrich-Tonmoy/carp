﻿using CMM.CodeAnalysis.Syntax;

namespace CMM.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryOperator
    {
        public SyntaxKind SyntaxKind { get; }
        public BoundBinaryOperatorKind Kind { get; }
        public Type LeftType { get; }
        public Type RighttType { get; }
        public Type Type { get; }

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type type) : this(syntaxKind, kind, type, type, type) { }
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type operandType, Type resultType) : this(syntaxKind, kind, operandType, operandType, resultType) { }
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type leftType, Type righttType, Type resultType)
        {
            SyntaxKind = syntaxKind;
            Kind = kind;
            LeftType = leftType;
            RighttType = righttType;
            Type = resultType;
        }

        private static BoundBinaryOperator[] _operators =
        {
            new BoundBinaryOperator(SyntaxKind.PlusToken,BoundBinaryOperatorKind.Addition,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.MinusToken,BoundBinaryOperatorKind.Subtraction,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.StarToken,BoundBinaryOperatorKind.Multiplication,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.SlashToken,BoundBinaryOperatorKind.Division,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.EqualityToken,BoundBinaryOperatorKind.Equality,typeof(int),typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.NotEqualToken,BoundBinaryOperatorKind.NotEquals,typeof(int),typeof(bool)),

            new BoundBinaryOperator(SyntaxKind.AndToken,BoundBinaryOperatorKind.LogicalAnd,typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.OrToken,BoundBinaryOperatorKind.LogicalOr,typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.EqualityToken,BoundBinaryOperatorKind.Equality,typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.NotEqualToken,BoundBinaryOperatorKind.NotEquals,typeof(bool)),
        };

        public static BoundBinaryOperator Bind(SyntaxKind syntaxKind, Type leftType, Type rightType)
        {
            foreach (var op in _operators)
            {
                if (op.SyntaxKind == syntaxKind && op.LeftType == leftType && op.RighttType == rightType)
                {
                    return op;
                }
            }
            return null;
        }
    }
}