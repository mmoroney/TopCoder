// https://community.topcoder.com/stat?c=problem_statement&pm=1599

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BridgeCrossing
    {
        public int minTime(int[] times)
        {
            if (times.Length == 1)
                return times[0];

            Array.Sort(times);

            int minTime = (times.Length / 2 - 1) * (2 * times[1] + times[0]) + times[1];

            for (int i = times.Length - 1; i > 2; i -= 2)
                minTime += times[i];

            if(times.Length % 2 == 1)
                minTime += times[0] + times[2];

            return minTime;
        }
    }

    [TestClass]
    public class BridgeCrossingTestClass
    {
        [TestMethod]
        public void BridgeCrossingTest()
        {
            BridgeCrossingTestClass.BridgeCrossingTest(new int[] { 1, 2, 5, 10 }, 17);
            BridgeCrossingTestClass.BridgeCrossingTest(new int[] { 1, 2, 3, 4, 5 }, 16);
            BridgeCrossingTestClass.BridgeCrossingTest(new int[] { 100 }, 100);
            BridgeCrossingTestClass.BridgeCrossingTest(new int[] { 1, 2, 3, 50, 99, 100 }, 162);
        }

        private static void BridgeCrossingTest(int[] times, int expected)
        {
            BridgeCrossing bridgeCrossing = new BridgeCrossing();
            Assert.AreEqual(expected, bridgeCrossing.minTime(times));
        }
    }
}
