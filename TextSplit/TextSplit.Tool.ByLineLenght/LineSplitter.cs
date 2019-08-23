using System;
using System.Collections.Generic;

namespace TextSplit.Tool.ByLineLenght
{
    /// <summary>
    /// Split text per lines of fix length
    /// </summary>
    public class LineSplitter
    {
        public LineSplitter(int lineLength)
        {
            LineLength = lineLength;
        }

        /// <summary>
        /// Max line lenght
        /// </summary>
        public int LineLength { get; set; }

        /// <summary>
        /// Char witch indecate of csplitting line
        /// </summary>
        public SplitChars splitChars { get; set; } = new SplitChars();

        public string[] Split(string text)
        {
            List<string> _return = new List<string>();
            int beginIndex = GetNextBeginIndex(text, -1);

            do
            {
                int endIndex = beginIndex + LineLength - 1;
                //Check if endIndex is last index
                if (endIndex >= text.Length - 1)
                {
                    CutLineTillEnd(text, beginIndex, _return);
                    break;
                }

                //Check if next char is excluded split char
                if (splitChars.Excluded.Contains(text[endIndex + 1]))
                {
                    CutLineByStep(text, beginIndex, LineLength, _return);
                    beginIndex = GetNextBeginIndex(text, endIndex);
                    continue;
                }

                while (endIndex >= beginIndex)
                {
                    if (splitChars.Excluded.Contains(text[endIndex]) || splitChars.Included.Contains(text[endIndex]))
                    {
                        CutLine(text, beginIndex, endIndex, _return);
                        beginIndex = GetNextBeginIndex(text, endIndex);
                        break;
                    }
                    else if (endIndex == beginIndex)
                    {
                        CutLineByStep(text, beginIndex, LineLength, _return);
                        beginIndex = GetNextBeginIndex(text, beginIndex, LineLength);
                        break;
                    }
                    endIndex--;
                }

            } while (true);

            return _return.ToArray();
        }

        /// <summary>
        /// Get next begin index
        /// Skip excluded chars
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="endIndex">current end line index</param>
        /// <returns></returns>
        private int GetNextBeginIndex(string text, int endIndex)
        {
            var newBeginIndex = endIndex + 1;
            TrimNewBeginIndex(text, ref newBeginIndex);
            return newBeginIndex;
        }

        /// <summary>
        /// Get next begin index
        /// Skip excluded chars
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="CurBeginIndex">current begin line index</param>
        /// <param name="Step">step of cur line</param>
        /// <returns></returns>
        private int GetNextBeginIndex(string text, int CurBeginIndex, int Step)
        {
            var newBeginIndex = CurBeginIndex + Step;
            TrimNewBeginIndex(text, ref newBeginIndex);
            return newBeginIndex;
        }
        /// <summary>
        /// Cut exclude char from new begin index
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="newBeginIndex">new begin line index</param>
        private void TrimNewBeginIndex(string text, ref int newBeginIndex)
        {
            while (newBeginIndex < text.Length && splitChars.Excluded.Contains(text[newBeginIndex]))
            {
                newBeginIndex++;
            }
        }


        private void CutLine(string text, int beginIndex, int endIndex, List<string> LinesList)
        {
            CutLineByStep(text, beginIndex, endIndex - beginIndex + 1, LinesList);
        }
        private void CutLineTillEnd(string text, int beginIndex, List<string> LinesList)
        {
            LinesList.Add(text.Substring(beginIndex).Trim());
        }
        private void CutLineByStep(string text, int beginIndex, int step, List<string> LinesList)
        {
            LinesList.Add(text.Substring(beginIndex, step).Trim());
        }
    }

    public class SplitChars
    {
        public List<char> Included { get; set; } = new List<char>() { '.', ',' };
        public List<char> Excluded { get; set; } = new List<char>() { ' ' };

    }

}
