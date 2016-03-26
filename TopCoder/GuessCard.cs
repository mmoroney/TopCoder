// https://community.topcoder.com/stat?c=problem_statement&pm=4490

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class GuessCard
    {
        public int whichRow(int width, int height, int[] columns)
        {
            int begin = 0;
            int end = width * height - 1;
            int beginRow = 0;
            int endRow = height - 1;

            for(int i = 0; i < columns.Length; i++)
            {
                beginRow = (begin - columns[i] - 1 + width) / width;
                endRow = (end - columns[i]) / width;

                begin = columns[i] * height + beginRow;
                end = columns[i] * height + endRow;
            }

            return (beginRow == endRow) ? beginRow : -1;
        }
    }

    [TestClass]
    public class GuessCardTestClass
    {
        [TestMethod]
        public void GuessCardTest()
        {
            GuessCardTestClass.GuessCardTest(3, 7, new int[] { 2, 1, 0 }, 4);
            GuessCardTestClass.GuessCardTest(3, 7, new int[] { 2, 1 }, -1);
            GuessCardTestClass.GuessCardTest(1, 10, new int[] { 0, 0, 0 }, -1);
            GuessCardTestClass.GuessCardTest(10, 1, new int[] { 4, 4, 4 }, 0);
        }

        private static void GuessCardTest(int width, int height, int[] columns, int expected)
        {
            GuessCard guessCard = new GuessCard();
            Assert.AreEqual(expected, guessCard.whichRow(width, height, columns));
        }
    }
}
