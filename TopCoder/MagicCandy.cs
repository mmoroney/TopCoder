// https://community.topcoder.com/stat?c=problem_statement&pm=11706

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class MagicCandy
    {
        public int whichOne(int n)
        {
            int i = (int)Math.Sqrt(n - 1);

            int result = i * i + 1;
            if (n >= result + i)
                result += i;

            return result;
        }
    }

    [TestClass]
    public class MagicCandyTestClass
    {
        [TestMethod]
        public void MagicCandyTest()
        {
            MagicCandyTestClass.MagicCandyTest(5, 5);
            MagicCandyTestClass.MagicCandyTest(9, 7);
            MagicCandyTestClass.MagicCandyTest(20, 17);
            MagicCandyTestClass.MagicCandyTest(5265, 5257);
            MagicCandyTestClass.MagicCandyTest(20111223, 20110741);
            MagicCandyTestClass.MagicCandyTest(1, 1);
        }

        private static void MagicCandyTest(int n, int expected)
        {
            MagicCandy magicCandy = new MagicCandy();
            Assert.AreEqual(expected, magicCandy.whichOne(n));
        }
    }
}
