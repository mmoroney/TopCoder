// https://community.topcoder.com/stat?c=problem_statement&pm=6254

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Hotel
    {
        public int marketCost(int minCustomers, int[] customers, int[] cost)
        {
            int[] minCosts = new int[minCustomers + 1];
            for (int i = 1; i < minCosts.Length; i++)
            {
                minCosts[i] = int.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    for (int k = 0; k < customers.Length; k++)
                    {
                        if (customers[k] >= i - j)
                            minCosts[i] = Math.Min(minCosts[i], minCosts[j] + cost[k]);
                    }
                }
            }

            return minCosts[minCustomers];
        }
    }

    [TestClass]
    public class HotelTestClass
    {
        [TestMethod]
        public void HotelTest()
        {
            HotelTestClass.HotelTest(10, new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, 4);
            HotelTestClass.HotelTest(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10);
            HotelTestClass.HotelTest(12, new int[] { 5, 1 }, new int[] { 3, 1 }, 8);
            HotelTestClass.HotelTest(100, new int[] { 9, 11, 4, 7, 2, 8 }, new int[] { 4, 9, 3, 8, 1, 9 }, 45);
        }

        private static void HotelTest(int minCustomers, int[] customers, int[] cost, int expected)
        {
            Hotel hotel = new Hotel();
            Assert.AreEqual(expected, hotel.marketCost(minCustomers, customers, cost));
        }
    }
}
