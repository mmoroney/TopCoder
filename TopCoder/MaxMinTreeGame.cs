// https://community.topcoder.com/stat?c=problem_statement&pm=12946

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class MaxMinTreeGame
    {
        public int findend(int[] edges, int[] costs)
        {
            int[] counts = new int[costs.Length];

            for (int i = 0; i < edges.Length; i++)
            {
                counts[i + 1]++;
                counts[edges[i]]++;
            }

            int max = int.MinValue;

            for(int i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 1)
                    max = Math.Max(max, costs[i]);
            }

            return max;
        }
    }

    [TestClass]
    public class MaxMinTreeGameTestClass
    {
        [TestMethod]
        public void MaxMinTreeGameTest()
        {
            MaxMinTreeGameTestClass.MaxMinTreeGameTest(new int[] { 0 }, new int[] { 4, 6 }, 6);
            MaxMinTreeGameTestClass.MaxMinTreeGameTest(new int[] { 0, 1 }, new int[] { 4, 6, 5 }, 5);
            MaxMinTreeGameTestClass.MaxMinTreeGameTest(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 0, 1, 0 }, 0);
            MaxMinTreeGameTestClass.MaxMinTreeGameTest(new int[] { 0, 0, 0 }, new int[] { 5, 1, 2, 3 }, 3);
            MaxMinTreeGameTestClass.MaxMinTreeGameTest(new int[] { 0, 0 }, new int[] { 3, 2, 5 }, 5);
        }

        private static void MaxMinTreeGameTest(int[] edges, int[] costs, int expected)
        {
            MaxMinTreeGame maxMinTreeGame = new MaxMinTreeGame();
            Assert.AreEqual(expected, maxMinTreeGame.findend(edges, costs));
        }
    }
}
