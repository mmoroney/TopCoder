// https://community.topcoder.com/stat?c=problem_statement&pm=1975

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ProgressBar
    {
        public string showProgress(int[] taskTimes, int tasksCompleted)
        {
            int complete = 0;

            for(int i = 0; i < tasksCompleted; i++)
                complete += taskTimes[i];

            int total = complete;

            for (int i = tasksCompleted; i < taskTimes.Length; i++)
                total += taskTimes[i];

            int progressCount = 20 * complete / total;
            return new string('#', progressCount) + new string('.', 20 - progressCount);
        }
    }

    [TestClass]
    public class ProgressBarTestClass
    {
        [TestMethod]
        public void ProgressBarTest()
        {
            ProgressBarTestClass.ProgressBarTest(new int[] { 19, 6, 23, 17 }, 3, "##############......");
            ProgressBarTestClass.ProgressBarTest(new int[] { 2, 3, 7, 1, 4, 3 }, 4, "#############.......");
            ProgressBarTestClass.ProgressBarTest(new int[] { 553, 846, 816, 203, 101, 120, 161, 818, 315, 772 }, 4, "##########..........");
            ProgressBarTestClass.ProgressBarTest(new int[] { 7, 60, 468, 489, 707, 499, 350, 998, 1000, 716, 457, 104, 597, 583, 396, 862 }, 2, "....................");
            ProgressBarTestClass.ProgressBarTest(new int[] { 419, 337, 853, 513, 632, 861, 336, 594, 94, 367, 336, 297, 966, 627, 399, 433, 846, 859, 80, 2 }, 19, "###################.");
        }

        private static void ProgressBarTest(int[] taskTimes, int tasksCompleted, string expected)
        {
            ProgressBar progressBar = new ProgressBar();
            Assert.AreEqual(expected, progressBar.showProgress(taskTimes, tasksCompleted));
        }
    }
}
