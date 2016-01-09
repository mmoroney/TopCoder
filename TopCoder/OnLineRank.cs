// https://community.topcoder.com/stat?c=problem_statement&pm=2264

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class OnLineRank
    {
        public int calcRanks(int k, int[] scores)
        {
            return scores.Length + Enumerable.Range(0, scores.Length).Sum(i => Enumerable.Range(Math.Max(0, i - k), Math.Min(i, k)).Count(j => scores[j] > scores[i]));
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
