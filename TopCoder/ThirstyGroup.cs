// https://community.topcoder.com/stat?c=problem_statement&pm=4822

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ThirstyGroup
    {
        public int bestGlass(int availableWater, int[] capacities)
        {
            int t = MaxTime(availableWater, capacities);
            availableWater -= ThirstyGroup.TotalWaterTaken(t, capacities);

            int max = int.MinValue;
            int maxIndex = 0;

            for(int i = 0; i < capacities.Length; i++)
            {
                int amount = ThirstyGroup.WaterTaken(t, capacities[i]);
                if(t % (capacities[i] + 1) == 0)
                {
                    int last = Math.Min(capacities[i], availableWater);
                    amount += last;
                    availableWater -= last;
                }

                if(amount > max)
                {
                    max = amount;
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        private static int MaxTime(int availableWater, int[] capacities)
        {
            int low = 0;
            int high = availableWater + 1;

            while (low + 1 < high)
            {
                int mid = low + (high - low) / 2;

                if (capacities.Sum(i => WaterTaken(mid, i)) > availableWater)
                    high = mid;
                else
                    low = mid;
            }

            return low;
        }

        private static int TotalWaterTaken(int time, int[] capacities)
        {
            return capacities.Sum(i => ThirstyGroup.WaterTaken(time, i));
        }

        private static int WaterTaken(int time, int capacity)
        {
            return (time + capacity) / (capacity + 1) * capacity;
        }
    }

    [TestClass]
    public class ThirstyGroupTestClass
    {
        [TestMethod]
        public void ThirstyGroupTest()
        {
            ThirstyGroupTestClass.ThirstyGroupTest(100, new int[] { 1, 20 }, 1);
            ThirstyGroupTestClass.ThirstyGroupTest(101, new int[] { 8, 10 }, 0);
            ThirstyGroupTestClass.ThirstyGroupTest(32, new int[] { 2, 4, 4, 4, 1 }, 1);
        }

        private static void ThirstyGroupTest(int availableWater, int[] capacities, int expected)
        {
            ThirstyGroup thirstyGroup = new ThirstyGroup();
            Assert.AreEqual(expected, thirstyGroup.bestGlass(availableWater, capacities));
        }
    }
}
