// https://community.topcoder.com/stat?c=problem_statement&pm=2264

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class OnLineRank
    {
        public int calcRanks(int k, int[] scores)
        {
            int sum = scores.Length;

            for(int i = 0; i < scores.Length; i++)
            {
                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    if (scores[j] > scores[i])
                        sum++;
                }
            }

            return sum;
        }
    }

    [TestClass]
    public class OnLineRankTestClass
    {
        [TestMethod]
        public void OnLineRankTest()
        {
            OnLineRankTestClass.OnLineRankTest(3, new int[] { 6, 9, 8, 15, 7, 12 }, 11);
            OnLineRankTestClass.OnLineRankTest(80, new int[] { 3, 3, 3, 3, 3, 3, 3 }, 7);
        }

        private static void OnLineRankTest(int k, int[] scores, int expected)
        {
            OnLineRank onlineRank = new OnLineRank();
            Assert.AreEqual(expected, onlineRank.calcRanks(k, scores));
        }
    }
}
