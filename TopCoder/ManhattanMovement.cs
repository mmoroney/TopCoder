// https://community.topcoder.com/stat?c=problem_statement&pm=3498

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ManhattanMovement
    {
        public double getDistance(int a, int b, int x0, int y0)
        {
            double dx = (a == 0) ? double.MaxValue : Math.Abs((1.0 - b * y0) / a - x0);
            double dy = (b == 0) ? double.MaxValue : Math.Abs((1.0 - a * x0) / b - y0);

            return Math.Min(dx, dy);
        }
    }

    [TestClass]
    public class ManhattanMovementTestClass
    {
        [TestMethod]
        public void ManhattanMovementTest()
        {
            ManhattanMovementTestClass.ManhattanMovementTest(1, 2, -2, 3, 1.5);
            ManhattanMovementTestClass.ManhattanMovementTest(37, 37, 42, 19, 60.97297297297297);
            ManhattanMovementTestClass.ManhattanMovementTest(-100, 0, -999999, 314159, 999998.99);
            ManhattanMovementTestClass.ManhattanMovementTest(0, -2147483648, 1, 100000, 100000.00000000047);
        }

        private static void ManhattanMovementTest(int a, int b, int x0, int y0, double expected)
        {
            ManhattanMovement manhattanMovement = new ManhattanMovement();
            Assert.IsTrue(Math.Abs(expected - manhattanMovement.getDistance(a, b, x0, y0)) < 1e-9);
        }
    }
}
