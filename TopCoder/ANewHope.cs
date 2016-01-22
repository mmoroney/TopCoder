// https://community.topcoder.com/stat?c=problem_statement&pm=13585&rd=16648

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ANewHope
    {
        public int count(int[] firstWeek, int[] lastWeek, int D)
        {
            int maxShift = 0;

            for(int i = D - 1; i < firstWeek.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && firstWeek[i] != lastWeek[j])
                    j--;

                if (j < 0)
                    continue;

                maxShift = Math.Max(maxShift, i - j);
            }

            int denominator = firstWeek.Length - D;
            return (maxShift + denominator - 1) / denominator + 1;
        }
    }

    [TestClass]
    public class ANewHopeTestClass
    {
        [TestMethod]
        public void ANewHopeTest()
        {
            ANewHopeTestClass.ANewHopeTest(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 }, 3, 4);
            ANewHopeTestClass.ANewHopeTest(new int[] { 8, 5, 4, 1, 7, 6, 3, 2 }, new int[] { 2, 4, 6, 8, 1, 3, 5, 7 }, 3, 3);
            ANewHopeTestClass.ANewHopeTest(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 2, 1);
        }

        private static void ANewHopeTest(int[] firstWeek, int[] lastWeek, int D, int expected)
        {
            ANewHope aNewHope = new ANewHope();
            Assert.AreEqual(expected, aNewHope.count(firstWeek, lastWeek, D));
        }
    }
}
