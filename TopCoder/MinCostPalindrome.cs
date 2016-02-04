// https://community.topcoder.com/stat?c=problem_statement&pm=11727

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class MinCostPalindrome
    {
        public int getMinimum(string s, int oCost, int xCost)
        {
            int cost = 0;

            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                if (s[i] == '?')
                    cost += GetCost(s[j], oCost, xCost);
                else if (s[j] == '?')
                    cost += GetCost(s[i], oCost, xCost);
                else if (s[i] != s[j])
                    return -1;
            }

            return cost;
        }

        private static int GetCost(char c, int oCost, int xCost)
        {
            switch(c)
            {
                case 'o':
                    return oCost;
                case 'x':
                    return xCost;
                default:
                    return 2 * Math.Min(oCost, xCost);
            }
        }
    }

    [TestClass]
    public class MinCostPalindromeTestClass
    {
        [TestMethod]
        public void MinCostPalindromeTest()
        {
            MinCostPalindromeTestClass.MinCostPalindromeTest("oxo?xox?", 3, 5, 8);
            MinCostPalindromeTestClass.MinCostPalindromeTest("x??x", 9, 4, 8);
            MinCostPalindromeTestClass.MinCostPalindromeTest("ooooxxxx", 12, 34, -1);
            MinCostPalindromeTestClass.MinCostPalindromeTest("oxoxooxxxxooxoxo", 7, 4, 0);
            MinCostPalindromeTestClass.MinCostPalindromeTest("?o", 6, 2, 6);
            MinCostPalindromeTestClass.MinCostPalindromeTest("????????????????????", 50, 49, 980);
            MinCostPalindromeTestClass.MinCostPalindromeTest("o??oxxo?xoox?ox??x??", 3, 10, 38);
        }

        private static void MinCostPalindromeTest(string s, int oCost, int xCost, int expected)
        {
            MinCostPalindrome minCostPalindrome = new MinCostPalindrome();
            Assert.AreEqual(expected, minCostPalindrome.getMinimum(s, oCost, xCost));
        }
    }
}
