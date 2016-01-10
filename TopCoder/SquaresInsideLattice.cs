// http://suhendry.net/blog/wp-content/uploads/2007/11/squaresinsidelattice.html

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SquaresInsideLattice
    {
        public long howMany(int width, int height)
        {
            return Enumerable.Range(1, Math.Min(width, height)).Sum(i => (width - i + 1) * (height - i + 1) * i);
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
