// http://suhendry.net/blog/wp-content/uploads/2007/11/squaresinsidelattice.html

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SquaresInsideLattice
    {
        public long howMany(int width, int height)
        {
            int sum = 0;

            for (int i = 1; i <= Math.Min(width, height); i++)
                sum += (width - i + 1) * (height - i + 1) * i;

            return sum;
        }
    }

    [TestClass]
    public class SquaresInsideLatticeTestClass
    {
        [TestMethod]
        public void SquaresInsideLatticeTest()
        {
            SquaresInsideLatticeTestClass.SquaresInsideLatticeTest(1, 1, 1);
            SquaresInsideLatticeTestClass.SquaresInsideLatticeTest(2, 3, 10);
            SquaresInsideLatticeTestClass.SquaresInsideLatticeTest(3, 3, 20);
            SquaresInsideLatticeTestClass.SquaresInsideLatticeTest(27, 19, 23940);
        }

        private static void SquaresInsideLatticeTest(int width, int height, long expected)
        {
            SquaresInsideLattice SquaresInsideLattice = new SquaresInsideLattice();
            Assert.AreEqual(expected, SquaresInsideLattice.howMany(width, height));
        }
    }
}
