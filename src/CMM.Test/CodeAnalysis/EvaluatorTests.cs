using CMM.CodeAnalysis;
using CMM.CodeAnalysis.Syntax;

namespace CMM.Test.CodeAnalysis
{
    public class EvaluatorTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("+1", 1)]
        [InlineData("-1", -1)]
        [InlineData("1+2", 3)]
        [InlineData("1-2", -1)]
        [InlineData("1*2", 2)]
        [InlineData("1/2", 0)]
        [InlineData("(10)", 10)]
        [InlineData("12==3", false)]
        [InlineData("3==3", true)]
        [InlineData("12!=3", true)]
        [InlineData("3!=3", false)]
        [InlineData("false==false", true)]
        [InlineData("true==false", false)]
        [InlineData("false!=false", false)]
        [InlineData("true!=false", true)]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("!true", false)]
        [InlineData("!false", true)]
        [InlineData("(a=10)*a", 100)]
        public void Evaluator_Computes_CorrectValues(string text, object expectedValue)
        {
            var syntaxTree = SyntaxTree.Parse(text);
            var compilation = new Compilation(syntaxTree);
            var variables = new Dictionary<VariableSymbol, object>();
            var result = compilation.Evaluate(variables);

            Assert.Empty(result.Diagnostics);
            Assert.Equal(expectedValue, result.Value);
        }
    }
}
