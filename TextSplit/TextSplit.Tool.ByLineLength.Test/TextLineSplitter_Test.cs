using NUnit.Framework;

namespace TextSplit.Tool.ByLineLength.Test
{
    [TestFixture]
    public class TextLineSplitter_Test
    {

        /// <summary>
        /// Split length is more than text length
        /// </summary>
        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void SplitPerLine_1_1_Test(int len)
        {
            string _text = "1234 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(2, _textArr.Length);
            Assert.AreEqual("1234", _textArr[0]);
            Assert.AreEqual("5678", _textArr[1]);
        }
        /// <summary>
        /// Split length is more than text length
        /// Check correct splitting by split characters
        /// </summary>
        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void SplitPerLine_1_2_Test(int len)
        {
            string _text = "123, 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(2, _textArr.Length);
            Assert.AreEqual("123,", _textArr[0]);
            Assert.AreEqual("5678", _textArr[1]);
        }

        /// <summary>
        /// Line length is lower than word length
        /// </summary>
        [Test]
        [TestCase(2)]
        public void SplitPerLine_2_1_Test(int len)
        {
            string _text = "1234 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(4, _textArr.Length);
            Assert.AreEqual("12", _textArr[0]);
            Assert.AreEqual("34", _textArr[1]);
            Assert.AreEqual("56", _textArr[2]);
            Assert.AreEqual("78", _textArr[3]);
        }
        /// <summary>
        /// Line length is lower than word length
        /// Check correct splitting by split characters
        /// </summary>
        [Test]
        [TestCase(2)]
        public void SplitPerLine_2_2_Test(int len)
        {
            string _text = "123, 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(4, _textArr.Length);
            Assert.AreEqual("12", _textArr[0]);
            Assert.AreEqual("3,", _textArr[1]);
            Assert.AreEqual("56", _textArr[2]);
            Assert.AreEqual("78", _textArr[3]);
        }

        /// <summary>
        /// Line length is lower than word length, division is not equal
        /// </summary>
        [Test]
        [TestCase(3)]
        public void SplitPerLine_3_1_Test(int len)
        {
            string _text = "1234 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(4, _textArr.Length);
            Assert.AreEqual("123", _textArr[0]);
            Assert.AreEqual("4", _textArr[1]);
            Assert.AreEqual("567", _textArr[2]);
            Assert.AreEqual("8", _textArr[3]);
        }

        /// <summary>
        /// Line length is lower than word length, division is not equal
        /// Check correct splitting by split characters
        /// </summary>
        [Test]
        [TestCase(3)]
        public void SplitPerLine_3_2_Test(int len)
        {
            string _text = "1234, 5678";
            string[] _textArr = _text.SplitByLineLength(len);

            Assert.AreEqual(4, _textArr.Length);
            Assert.AreEqual("123", _textArr[0]);
            Assert.AreEqual("4,", _textArr[1]);
            Assert.AreEqual("567", _textArr[2]);
            Assert.AreEqual("8", _textArr[3]);
        }

        /// <summary>
        /// Split by split character
        /// </summary>
        [Test]
        public void SplitPerLine_4_Test()
        {
            string _text = "1234,5678";
            string[] _textArr = _text.SplitByLineLength(4);

            Assert.AreEqual(3, _textArr.Length);
            Assert.AreEqual("1234", _textArr[0]);
            Assert.AreEqual(",", _textArr[1]);
            Assert.AreEqual("5678", _textArr[2]);
        }

        /// <summary>
        /// Double space
        /// </summary>
        [Test]

        public void SplitPerLine_manyTrim_Test()
        {
            string _text = "1234  5678";
            string[] _textArr = _text.SplitByLineLength(4);

            Assert.AreEqual(2, _textArr.Length);
            Assert.AreEqual("1234", _textArr[0]);
            Assert.AreEqual("5678", _textArr[1]);
        }
    }

}