// https://community.topcoder.com/stat?c=problem_statement&pm=11361

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TrafficCongestion
    {
        public int theMinCars(int treeHeight)
        {
            int min = 1;

            for (int i = 1; i <= treeHeight; i++)
                min = (2 * min + (i % 2 == 0 ? 1 : -1)) % 1000000007;

            return min;
        }
    }

    [TestClass]
    public class TrafficCongestionTestClass
    {
        [TestMethod]
        public void TrafficCongestionTest()
        {
            TrafficCongestionTestClass.TrafficCongestionTest(1, 1);
            TrafficCongestionTestClass.TrafficCongestionTest(2, 3);
            TrafficCongestionTestClass.TrafficCongestionTest(3, 5);
            TrafficCongestionTestClass.TrafficCongestionTest(585858, 548973404);
        }

        private static void TrafficCongestionTest(int treeHeight, int expected)
        {
            TrafficCongestion trafficCongestion = new TrafficCongestion();
            Assert.AreEqual(expected, trafficCongestion.theMinCars(treeHeight));
        }
    }
}
