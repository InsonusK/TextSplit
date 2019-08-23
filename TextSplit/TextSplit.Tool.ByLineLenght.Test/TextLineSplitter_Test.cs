using NUnit.Framework;
using TextSplit.Tool.ByLineLenght;

namespace Tests
{
    [TestFixture]
    public class TextLineSplitter_Test
    {

        /// <summary>
        /// Разделение на строки
        /// </summary>
        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void SplitPerLine_1_1_Test(int len)
        {
            string text = "1234 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(2, textArr.Length);
            Assert.AreEqual("1234", textArr[0]);
            Assert.AreEqual("5678", textArr[1]);
        }
        /// <summary>
        /// Разделение на строки
        /// </summary>
        [Test]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void SplitPerLine_1_2_Test(int len)
        {
            string text = "123, 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(2, textArr.Length);
            Assert.AreEqual("123,", textArr[0]);
            Assert.AreEqual("5678", textArr[1]);
        }

        /// <summary>
        /// Слишком короткое деление
        /// </summary>
        [Test]
        [TestCase(2)]
        public void SplitPerLine_2_1_Test(int len)
        {
            string text = "1234 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(4, textArr.Length);
            Assert.AreEqual("12", textArr[0]);
            Assert.AreEqual("34", textArr[1]);
            Assert.AreEqual("56", textArr[2]);
            Assert.AreEqual("78", textArr[3]);
        }
        /// <summary>
        /// Слишком короткое деление
        /// </summary>
        [Test]
        [TestCase(2)]
        public void SplitPerLine_2_2_Test(int len)
        {
            string text = "123, 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(4, textArr.Length);
            Assert.AreEqual("12", textArr[0]);
            Assert.AreEqual("3,", textArr[1]);
            Assert.AreEqual("56", textArr[2]);
            Assert.AreEqual("78", textArr[3]);
        }

        /// <summary>
        /// Разделение на строки, не ровное деление
        /// </summary>
        [Test]
        [TestCase(3)]
        public void SplitPerLine_3_1_Test(int len)
        {
            string text = "1234 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(4, textArr.Length);
            Assert.AreEqual("123", textArr[0]);
            Assert.AreEqual("4", textArr[1]);
            Assert.AreEqual("567", textArr[2]);
            Assert.AreEqual("8", textArr[3]);
        }

        /// <summary>
        /// Разделение на строки, не ровное деление
        /// </summary>
        [Test]
        [TestCase(3)]
        public void SplitPerLine_3_2_Test(int len)
        {
            string text = "1234, 5678";
            string[] textArr = text.SplitByLineLenght(len);

            Assert.AreEqual(4, textArr.Length);
            Assert.AreEqual("123", textArr[0]);
            Assert.AreEqual("4,", textArr[1]);
            Assert.AreEqual("567", textArr[2]);
            Assert.AreEqual("8", textArr[3]);
        }

        /// <summary>
        /// Разделение на строки
        /// </summary>
        [Test]
        public void SplitPerLine_4_Test()
        {
            string text = "1234,5678";
            string[] textArr = text.SplitByLineLenght(4);

            Assert.AreEqual(3, textArr.Length);
            Assert.AreEqual("1234", textArr[0]);
            Assert.AreEqual(",", textArr[1]);
            Assert.AreEqual("5678", textArr[2]);
        }

        /// <summary>
        /// Разделение на строки
        /// </summary>
        [Test]

        public void SplitPerLine_manyTrim_Test()
        {
            string text = "1234  5678";
            string[] textArr = text.SplitByLineLenght(4);

            Assert.AreEqual(2, textArr.Length);
            Assert.AreEqual("1234", textArr[0]);
            Assert.AreEqual("5678", textArr[1]);
        }
    }

}