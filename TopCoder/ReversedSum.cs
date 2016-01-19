// https://community.topcoder.com/stat?c=problem_statement&pm=9925

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ReversedSum
    {
        public int getReversedSum(int x, int y)
        {
            return ReversedSum.Reverse(ReversedSum.Reverse(x) + ReversedSum.Reverse(y));
        }

        private static int Reverse(int x)
        {
            int sum = 0;
            while(x > 0)
            {
                sum = sum * 10 + x % 10;
                x /= 10;
            }

            return sum;
        }
    }

    [TestClass]
    public class ReversedSumTestClass
    {
        [TestMethod]
        public void ReversedSumTest()
        {
            ReversedSumTestClass.ReversedSumTest(123, 100, 223);
            ReversedSumTestClass.ReversedSumTest(111, 111, 222);
            ReversedSumTestClass.ReversedSumTest(5, 5, 1);
            ReversedSumTestClass.ReversedSumTest(1000, 1, 2);
            ReversedSumTestClass.ReversedSumTest(456, 789, 1461);
        }

        private static void ReversedSumTest(int x, int y, int expected)
        {
            ReversedSum reversedSum = new ReversedSum();
            Assert.AreEqual(expected, reversedSum.getReversedSum(x, y));
        }
    }
}
