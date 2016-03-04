// https://community.topcoder.com/stat?c=problem_statement&pm=6447

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class PartSorting
    {
        public int[] process(int[] data, int nSwaps)
        {
            int[] results = new int[data.Length];
            Array.Copy(data, results, data.Length);

            int i = 0;

            while(nSwaps > 0 && i < results.Length)
            {
                int j = i;
                for(int k = i + 1; k < results.Length && k - i <= nSwaps; k++)
                {
                    if(results[k] > results[j])
                        j = k;
                }

                int max = results[j];
                for (int k = j; k > i; k--)
                    results[k] = results[k - 1];

                results[i] = max;
                nSwaps -= (j - i);
                i++;
            }

            return results;
        }
    }

    [TestClass]
    public class PartSortingTestClass
    {
        [TestMethod]
        public void PartSortingTest()
        {
            PartSortingTestClass.PartSortingTest(new int[] { 10, 20, 30, 40, 50, 60, 70 }, 1, new int[] { 20, 10, 30, 40, 50, 60, 70 });
            PartSortingTestClass.PartSortingTest(new int[] { 3, 5, 1, 2, 4 }, 2, new int[] { 5, 3, 2, 1, 4 });
            PartSortingTestClass.PartSortingTest(new int[] { 19, 20, 17, 18, 15, 16, 13, 14, 11, 12 }, 5, new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11 });
        }

        private static void PartSortingTest(int[] data, int nSwaps, int[] expected)
        {
            PartSorting partSorting = new PartSorting();
            int[] results = partSorting.process(data, nSwaps);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
