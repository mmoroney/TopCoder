// https://community.topcoder.com/stat?c=problem_statement&pm=3543

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ATaleOfThreeCities
    {
        public double connect(int[] ax, int[] ay, int[] bx, int[] by, int[] cx, int[] cy)
        {
            double ab = ATaleOfThreeCities.MinDistance(ax, ay, bx, by);
            double ac = ATaleOfThreeCities.MinDistance(ax, ay, cx, cy);
            double bc = ATaleOfThreeCities.MinDistance(bx, by, cx, cy);

            return Math.Min(ab + ac, Math.Min(ab + bc, ac + bc));
        }

        private static double MinDistance(int[] x1, int[] y1, int[] x2, int[] y2)
        {
            double min = double.MaxValue;

            for(int i = 0; i < x1.Length; i++)
            {
                for(int j = 0; j < x2.Length; j++)
                {
                    double dx = x1[i] - x2[j];
                    double dy = y1[i] - y2[j];

                    min = Math.Min(min, dx * dx + dy * dy);
                }
            }

            return Math.Sqrt(min);
        }
    }

    [TestClass]
    public class ATaleOfThreeCitiesTestClass
    {
        [TestMethod]
        public void ATaleOfThreeCitiesTest()
        {
            ATaleOfThreeCitiesTestClass.ATaleOfThreeCitiesTest(
                new int[] { 0, 0, 0 }, new int[] { 0, 1, 2 },
                new int[] { 2, 3 }, new int[] { 1, 1 },
                new int[] { 1, 5 }, new int[] { 3, 28 },
                3.414213562373095);

            ATaleOfThreeCitiesTestClass.ATaleOfThreeCitiesTest(
                new int[] { -2, -1, 0, 1, 2 }, new int[] { 0, 0, 0, 0, 0 },
                new int[] { -2, -1, 0, 1, 2 }, new int[] { 1, 1, 1, 1, 1 },
                new int[] { -2, -1, 0, 1, 2 }, new int[] { 2, 2, 2, 2, 2 },
                2.0);

            ATaleOfThreeCitiesTestClass.ATaleOfThreeCitiesTest(
                new int[] { 4, 5, 11, 21, 8, 10, 3, 9, 5, 6 }, new int[] { 12, 8, 9, 12, 2, 3, 5, 7, 10, 13 },
                new int[] { 34, 35, 36, 41, 32, 39, 41, 37, 39, 50 }, new int[] { 51, 33, 41, 45, 48, 22, 33, 51, 41, 40 },
                new int[] { 86, 75, 78, 81, 89, 77, 83, 88, 99, 77 }, new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 },
                50.323397776611024);
        }

        private static void ATaleOfThreeCitiesTest(int[] ax, int[] ay, int[] bx, int[] by, int[] cx, int[] cy, double expected)
        {
            ATaleOfThreeCities aTaleOfThreeCities = new ATaleOfThreeCities();
            double result = aTaleOfThreeCities.connect(ax, ay, bx, by, cx, cy);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
