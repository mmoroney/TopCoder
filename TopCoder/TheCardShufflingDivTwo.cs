// https://community.topcoder.com/stat?c=problem_statement&pm=10618

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TheCardShufflingDivTwo
    {
        public int shuffle(int n, int m)
        {
            int x = 1;
            for(int i = 0; i < m; i++)
            {
                if (x <= n / 2)
                    x *= 2;
                else
                    x = (x - n / 2) * 2 - 1;
            }

            return x;
        }
    }

    [TestClass]
    public class TheCardShufflingDivTwoTestClass
    {
        [TestMethod]
        public void TheCardShufflingDivTwoTest()
        {
            TheCardShufflingDivTwoTestClass.TheCardShufflingDivTwoTest(5, 1, 2);
            TheCardShufflingDivTwoTestClass.TheCardShufflingDivTwoTest(5, 2, 4);
            TheCardShufflingDivTwoTestClass.TheCardShufflingDivTwoTest(2, 10, 1);
            TheCardShufflingDivTwoTestClass.TheCardShufflingDivTwoTest(17, 9, 2);
        }

        private static void TheCardShufflingDivTwoTest(int n, int m, int expected)
        {
            TheCardShufflingDivTwo theCardShufflingDivTwo = new TheCardShufflingDivTwo();
            Assert.AreEqual(expected, theCardShufflingDivTwo.shuffle(n, m));
        }
    }
}
