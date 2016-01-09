// https://community.topcoder.com/stat?c=problem_statement&pm=10463

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class RedSquare
    {
        public int countTheEmptyReds(int maxRank, int maxFile, int[] rank, int[] file)
        {
            return maxRank * maxFile / 2 - Enumerable.Range(0, rank.Length).Count(i => (rank[i] + file[i]) % 2 == maxFile % 2);
        }
    }

    [TestClass]
    public class RedSquareTestClass
    {
        [TestMethod]
        public void RedSquareTest()
        {
            RedSquareTestClass.RedSquareTest(3, 5, new int[] { 1, 2, 2 }, new int[] { 4, 1, 2 }, 5);
            RedSquareTestClass.RedSquareTest(3, 3, new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 }, new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, 0);
            RedSquareTestClass.RedSquareTest(5, 5, new int[] { 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5 }, new int[] { 2, 4, 1, 3, 5, 2, 4, 1, 3, 5, 2, 4 }, 0);
            RedSquareTestClass.RedSquareTest(5, 6, new int[] { 1, 1, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5 }, new int[] { 2, 4, 1, 3, 5, 2, 4, 1, 3, 5, 2, 4 }, 15);
            RedSquareTestClass.RedSquareTest(1, 1, new int[] { }, new int[] { }, 0);
            RedSquareTestClass.RedSquareTest(50, 50, new int[] { 1 }, new int[] { 1 }, 1249);
            RedSquareTestClass.RedSquareTest(50, 50,
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 1225);
        }

        private static void RedSquareTest(int maxRank, int maxFile, int[] rank, int[] file, int expected)
        {
            RedSquare redSquare = new RedSquare();
            Assert.AreEqual(expected, redSquare.countTheEmptyReds(maxRank, maxFile, rank, file));
        }
    }
}
