namespace CoverletExtension
{
    public class LineInfo
    {
        public int LineNumber { get; }
        public int LineUsages { get; }

        public LineInfo(int lineNumber, int usages)
        {
            LineNumber = lineNumber;
            LineUsages = usages;
        }
    }
}