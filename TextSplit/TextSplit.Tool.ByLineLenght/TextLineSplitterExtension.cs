namespace TextSplit.Tool.ByLineLenght
{
    public static class TextLineSplitterExtension
    {
        public static string[] SplitByLineLenght(this string text, int length)
        {
            LineSplitter _splitter = new LineSplitter(length);
            return _splitter.Split(text);
        }
    }
}