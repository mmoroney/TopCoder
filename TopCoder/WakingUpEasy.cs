// https://community.topcoder.com/stat?c=problem_statement&pm=13125

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class WakingUpEasy
    {
        public int countAlarms(int[] volume, int S)
        {
            int i = 0;
            int count = 0;

            while (S > 0)
            {
                S -= volume[i];
                i = (i + 1) % volume.Length;
                count++;
            }

            return count;
        }
    }

    [TestClass]
    public class WakingUpEasyTestClass
    {
        [TestMethod]
        public void WakingUpEasyTest()
        {
            WakingUpEasyTestClass.WakingUpEasyTest(new int[] { 5, 2, 4 }, 13, 4);
            WakingUpEasyTestClass.WakingUpEasyTest(new int[] { 5, 2, 4 }, 3, 1);
            WakingUpEasyTestClass.WakingUpEasyTest(new int[] { 1 }, 10000, 10000);
            WakingUpEasyTestClass.WakingUpEasyTest(
                new int[] 
                {
                    42, 68, 35, 1, 70, 25, 79, 59, 63, 65, 6, 46, 82, 28, 62, 92, 96,
                    43, 28, 37, 92, 5, 3, 54, 93, 83, 22, 17, 19, 96, 48, 27, 72, 39,
                    70, 13, 68, 100, 36, 95, 4, 12, 23, 34, 74, 65, 42, 12, 54, 69
                }, 9999, 203);
        }

        private static void WakingUpEasyTest(int[] volume, int S, int expected)
        {
            WakingUpEasy wakingUpEasy = new WakingUpEasy();
            Assert.AreEqual(expected, wakingUpEasy.countAlarms(volume, S));
        }
    }
}
