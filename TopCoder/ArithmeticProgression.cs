// https://community.topcoder.com/stat?c=problem_statement&pm=9839

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ArithmeticProgression
    {
        public double minCommonDifference(int a0, int[] seq)
        {
            double min = 0.0;
            double max = double.MaxValue;

            for (int i = 0; i < seq.Length; i++)
            {
                min = Math.Max(min, (double)(seq[i] - a0) / (i + 1));
                max = Math.Min(max, (double)(seq[i] + 1 - a0) / (i + 1));

                if (max <= min)
                    return -1.0;
            }

            return min;
        }
    }

    [TestClass]
    public class ArithmeticProgressionTestClass
    {
        [TestMethod]
        public void ArithmeticProgressionTest()
        {
            ArithmeticProgressionTestClass.ArithmeticProgressionTest(0, new int[] { 6, 13, 20, 27 }, 6.75);
            ArithmeticProgressionTestClass.ArithmeticProgressionTest(1, new int[] { 2, 3, 4, 5, 6 }, 1.0);
            ArithmeticProgressionTestClass.ArithmeticProgressionTest(3, new int[] { }, 0.0);
            ArithmeticProgressionTestClass.ArithmeticProgressionTest(1, new int[] { -3 }, -1.0);
            ArithmeticProgressionTestClass.ArithmeticProgressionTest(0, new int[] { 6, 14 }, -1.0);
        }

        private static void ArithmeticProgressionTest(int a0, int[] seqn, double expected)
        {
            ArithmeticProgression arithmeticProgression = new ArithmeticProgression();
            double result = arithmeticProgression.minCommonDifference(a0, seqn);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
