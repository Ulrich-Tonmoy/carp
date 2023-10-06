namespace Carp.CodeAnalysis.Text
{
    public struct TextSpan
    {
        public int Start { get; }
        public int Length { get; }
        public int End => Start + Length;

        public TextSpan(int start, int length)
        {
            Start = start;
            Length = length;
        }

        public static TextSpan FromBounds(int start, int end)
        {
            var length = end - start;
            return new TextSpan(start, length);
        }

        public override string ToString() => $"{Start}..{End}";
    }
}