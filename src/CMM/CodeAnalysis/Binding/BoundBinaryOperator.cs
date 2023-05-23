using CMM.CodeAnalysis.Syntax;

namespace CMM.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryOperator
    {
        public SyntaxKind SyntaxKind { get; }
        public BoundBinaryOperatorKind Kind { get; }
        public Type LeftType { get; }
        public Type RighttType { get; }
        public Type ResultType { get; }

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type type) : this(syntaxKind, kind, type, type, type) { }
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type leftType, Type righttType, Type resultType)
        {
            SyntaxKind = syntaxKind;
            Kind = kind;
            LeftType = leftType;
            RighttType = righttType;
            ResultType = resultType;
        }

        private static BoundBinaryOperator[] _operators =
        {
            new BoundBinaryOperator(SyntaxKind.PlusToken,BoundBinaryOperatorKind.Addition,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.MinusToken,BoundBinaryOperatorKind.Subtraction,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.StarToken,BoundBinaryOperatorKind.Multiplication,typeof(int)),
            new BoundBinaryOperator(SyntaxKind.SlashToken,BoundBinaryOperatorKind.Division,typeof(int)),

            new BoundBinaryOperator(SyntaxKind.AndToken,BoundBinaryOperatorKind.LogicalAnd,typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.OrToken,BoundBinaryOperatorKind.LogicalOr,typeof(bool)),
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
