using System.Collections.Generic;

namespace TextSplit.Tool.ByLineLength
{
    /// <summary>
    /// Characters indicated that line could be splitted
    /// </summary>
    public class SplitChars
    {
        /// <summary>
        /// Character with include in splitted result
        /// </summary>
        public List<char> Included { get; set; } = new List<char>() { '.', ',', '-' };
        /// <summary>
        /// Character with excluded from splitted result
        /// </summary>
        public List<char> Excluded { get; set; } = new List<char>() { ' ' };

    }
}