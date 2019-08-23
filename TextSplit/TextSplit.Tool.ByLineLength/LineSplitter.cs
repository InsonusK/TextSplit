using System.Collections.Generic;

namespace TextSplit.Tool.ByLineLength
{
    /// <summary>
    /// Split text per lines of fix length
    /// </summary>
    public class LineSplitter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lineLength">line length</param>
        public LineSplitter(int lineLength)
        {
            LineLength = lineLength;
        }

        /// <summary>
        /// Max line length
        /// </summary>
        public int LineLength { get; set; }

        /// <summary>
        /// Char witch indicate of splitting line
        /// </summary>
        public SplitChars SplitChars { get; set; } = new SplitChars();

        /// <summary>
        /// Split text
        /// </summary>
        /// <param name="text">splitting text</param>
        /// <returns></returns>
        public string[] Split(string text)
        {
            List<string> _return = new List<string>();
            int _beginIndex = GetNextBeginIndex(text, -1);

            do
            {
                int _endIndex = _beginIndex + LineLength - 1;
                //Check if endIndex is last index
                if (_endIndex >= text.Length - 1)
                {
                    CutLineTillEnd(text, _beginIndex, _return);
                    break;
                }

                //Check if next char is excluded split char
                if (SplitChars.Excluded.Contains(text[_endIndex + 1]))
                {
                    CutLineByStep(text, _beginIndex, LineLength, _return);
                    _beginIndex = GetNextBeginIndex(text, _endIndex);
                    continue;
                }

                while (_endIndex >= _beginIndex)
                {
                    if (SplitChars.Excluded.Contains(text[_endIndex]) || SplitChars.Included.Contains(text[_endIndex]))
                    {
                        CutLine(text, _beginIndex, _endIndex, _return);
                        _beginIndex = GetNextBeginIndex(text, _endIndex);
                        break;
                    }
                    else if (_endIndex == _beginIndex)
                    {
                        CutLineByStep(text, _beginIndex, LineLength, _return);
                        _beginIndex = GetNextBeginIndex(text, _beginIndex, LineLength);
                        break;
                    }
                    _endIndex--;
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
            var _newBeginIndex = endIndex + 1;
            TrimNewBeginIndex(text, ref _newBeginIndex);
            return _newBeginIndex;
        }

        /// <summary>
        /// Get next begin index
        /// Skip excluded chars
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="curBeginIndex">current begin line index</param>
        /// <param name="step">step of cur line</param>
        /// <returns></returns>
        private int GetNextBeginIndex(string text, int curBeginIndex, int step)
        {
            var _newBeginIndex = curBeginIndex + step;
            TrimNewBeginIndex(text, ref _newBeginIndex);
            return _newBeginIndex;
        }
        /// <summary>
        /// Cut exclude char from new begin index
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="newBeginIndex">new begin line index</param>
        private void TrimNewBeginIndex(string text, ref int newBeginIndex)
        {
            while (newBeginIndex < text.Length && SplitChars.Excluded.Contains(text[newBeginIndex]))
            {
                newBeginIndex++;
            }
        }


        private void CutLine(string text, int beginIndex, int endIndex, List<string> linesList)
        {
            CutLineByStep(text, beginIndex, endIndex - beginIndex + 1, linesList);
        }
        private void CutLineTillEnd(string text, int beginIndex, List<string> linesList)
        {
            linesList.Add(text.Substring(beginIndex).Trim());
        }
        private void CutLineByStep(string text, int beginIndex, int step, List<string> linesList)
        {
            linesList.Add(text.Substring(beginIndex, step).Trim());
        }
    }
}
