// https://community.topcoder.com/stat?c=problem_statement&pm=1846

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class PaperFold
    {
        public int numFolds(int[] paper, int[] box)
        {
            int min = Math.Min(folds(paper[0], box[0]) + folds(paper[1], box[1]), folds(paper[0], box[1]) + folds(paper[1], box[0]));
            return min > 8 ? -1 : min;
        }

        private static int folds(int paper, int box)
        {
            int folds = 0;
            while (paper > box)
            {
                box *= 2;
                folds++;
            }

            return folds;
        }
    }

    [TestClass]
    public class PaperFoldTestClass
    {
        [TestMethod]
        public void PaperFoldTest()
        {
            PaperFoldTestClass.PaperFoldTest(new int[] { 8, 11 }, new int[] { 6, 10 }, 1);
            PaperFoldTestClass.PaperFoldTest(new int[] { 11, 17 }, new int[] { 6, 4 }, 4);
            PaperFoldTestClass.PaperFoldTest(new int[] { 11, 17 }, new int[] { 5, 4 }, 4);
            PaperFoldTestClass.PaperFoldTest(new int[] { 1000, 1000 }, new int[] { 62, 63 }, -1);
            PaperFoldTestClass.PaperFoldTest(new int[] { 100, 30 }, new int[] { 60, 110 }, 0);
            PaperFoldTestClass.PaperFoldTest(new int[] { 1895, 6416 }, new int[] { 401, 1000 }, 5);
        }

        private static void PaperFoldTest(int[] paper, int[] box, int expected)
        {
            PaperFold PaperFold = new PaperFold();
            Assert.AreEqual(expected, PaperFold.numFolds(paper, box));
        }
    }
}
