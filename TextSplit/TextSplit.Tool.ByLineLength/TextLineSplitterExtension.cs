namespace TextSplit.Tool.ByLineLength
{
    /// <summary>
    /// String extension class
    /// </summary>
    public static class TextLineSplitterExtension
    {
        /// <summary>
        /// Split text by lines using line length
        /// </summary>
        /// <param name="text">splitted text</param>
        /// <param name="length">line length</param>
        /// <returns></returns>
        public static string[] SplitByLineLength(this string text, int length)
        {
            LineSplitter _splitter = new LineSplitter(length);
            return _splitter.Split(text);
        }
    }
}