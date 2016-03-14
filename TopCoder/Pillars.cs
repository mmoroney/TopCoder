// https://community.topcoder.com/stat?c=problem_statement&pm=12055

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Pillars
    {
        public double getExpectedLength(int w, int x, int y)
        {
            double sum = 0;

            for (int d = 0; d < x; d++)
                sum += Pillars.Length(w, d) * Math.Min(x - d, y);

            for (int d = 1; d < y; d++)
                sum += Pillars.Length(w, d) * Math.Min(y - d, x);

            return sum / x / y;
        }

        private static double Length(int x, int y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }

    [TestClass]
    public class PillarsTestClass
    {
        [TestMethod]
        public void PillarsTest()
        {
            PillarsTestClass.PillarsTest(1, 1, 1, 1.0);
            PillarsTestClass.PillarsTest(1, 5, 1, 2.387132965131785);
            PillarsTestClass.PillarsTest(2, 3, 15, 6.737191281760445);
            PillarsTestClass.PillarsTest(10, 15, 23, 12.988608956320535);
        }

        private static void PillarsTest(int w, int x, int y, double expected)
        {
            Pillars pillars = new Pillars();
            double result = pillars.getExpectedLength(w, x, y);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
