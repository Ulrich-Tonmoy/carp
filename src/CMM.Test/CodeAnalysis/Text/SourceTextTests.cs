using CMM.CodeAnalysis.Text;

namespace CMM.Test.CodeAnalysis.Text
{
    public class SourceTextTests
    {
        [Theory]
        [InlineData(".", 1)]
        [InlineData(".\r\n", 2)]
        [InlineData(".\r\n\r\n", 3)]
        public void SourceText_IncludesLastLine(string text, int exptectedLineCount)
        {
            var sourceText = SourceText.From(text);
            Assert.Equal(exptectedLineCount, sourceText.Lines.Length);
        }
    }
}
