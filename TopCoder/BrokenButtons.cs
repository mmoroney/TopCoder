// https://community.topcoder.com/stat?c=problem_statement&pm=7716

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BrokenButtons
    {
        public int minPresses(int page, int[] broken)
        {
            bool[] brokenFlags = new bool[10];
            foreach (int d in broken)
                brokenFlags[d] = true;

            int min = Math.Abs(page - 100);

            for(int i = 0; i <= 1000000; i++)
            {
                string s = i.ToString();
                if (s.Any(c => brokenFlags[c - '0']))
                    continue;

                min = Math.Min(min, Math.Abs(page - i) + s.Length);
            }

            return min;
        }
    }

    [TestClass]
    public class BrokenButtonsTestClass
    {
        [TestMethod]
        public void BrokenButtonsTest()
        {
            BrokenButtonsTestClass.BrokenButtonsTest(5457, new int[] { 6, 7, 8 }, 6);
            BrokenButtonsTestClass.BrokenButtonsTest(100, new int[] { 1, 0, 5 }, 0);
            BrokenButtonsTestClass.BrokenButtonsTest(14124, new int[] { }, 5);
            BrokenButtonsTestClass.BrokenButtonsTest(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2);
            BrokenButtonsTestClass.BrokenButtonsTest(80000, new int[] { 8, 9 }, 2228);
        }

        private static void BrokenButtonsTest(int page, int[] broken, int expected)
        {
            BrokenButtons brokenButtons = new BrokenButtons();
            Assert.AreEqual(expected, brokenButtons.minPresses(page, broken));
        }
    }
}
