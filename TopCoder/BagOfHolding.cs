// https://community.topcoder.com/stat?c=problem_statement&pm=2348

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BagOfHolding
    {
        public double oddsReachable(int[] sizes, int item)
        {
            int count = 0;
            foreach(int size in sizes)
            {
                if (size >= sizes[item])
                    count++;
            }

            return 1.0 / count;
        }
    }

    [TestClass]
    public class BagOfHoldingTestClass
    {
        [TestMethod]
        public void BagOfHoldingTest()
        {
            BagOfHoldingTestClass.BagOfHoldingTest(new int[] { 1, 2, 3 }, 1, 0.5);
            BagOfHoldingTestClass.BagOfHoldingTest(new int[] { 1, 2, 3 }, 2, 1.0);
            BagOfHoldingTestClass.BagOfHoldingTest(new int[] { 1, 1, 2, 3 }, 2, 0.5);
            BagOfHoldingTestClass.BagOfHoldingTest(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 4, 0.16666666666666666);
        }

        private static void BagOfHoldingTest(int[] sizes, int item, double expected)
        {
            BagOfHolding bagOfHolding = new BagOfHolding();
            double result = bagOfHolding.oddsReachable(sizes, item);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
