// https://community.topcoder.com/stat?c=problem_statement&pm=6782

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Survived
    {
        public double minTime(int x, int y, int V, int U)
        {
            double a = V * V - U * U;
            double b = 2 * U * x;
            double c = - x * x - y * y;

            if (c == 0)
                return 0;

            if (a == 0)
            {
                if (b == 0)
                    return -1.0;

                return -c / b;
            }

            double d = b * b - 4 * a * c;
            if (d < 0)
                return -1.0;

            return (-b + Math.Sqrt(d)) / (2 * a);
        }
    }

    [TestClass]
    public class SurvivedTestClass
    {
        [TestMethod]
        public void SurvivedTest()
        {
            SurvivedTestClass.SurvivedTest(1, -1, 1, 1, 1.0);
            SurvivedTestClass.SurvivedTest(1, 1, 1, 0, 1.4142135623730951);
            SurvivedTestClass.SurvivedTest(1, 1, 0, 1, -1.0);
            SurvivedTestClass.SurvivedTest(9, 3, 2, 3, 2.0593413823019864);
            SurvivedTestClass.SurvivedTest(0, 0, 0, 0, 0.0);
            SurvivedTestClass.SurvivedTest(5, 12, 24, 26, 1.3);
        }

        private static void SurvivedTest(int x, int y, int V, int U, double expected)
        {
            Survived survived = new Survived();
            double result = survived.minTime(x, y, V, U);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
