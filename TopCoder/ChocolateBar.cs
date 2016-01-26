// https://community.topcoder.com/stat?c=problem_statement&pm=12190

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ChocolateBar
    {
        public int maxLength(string letters)
        {
            bool[] flags = new bool[26];
            int maxLength = 0;

            int i = 0;

            for(int j = 0; j < letters.Length; j++)
            {
                while(flags[letters[j] - 'a'] == true)
                {
                    flags[letters[i] - 'a'] = false;
                    i++;
                }

                flags[letters[j] - 'a'] = true;
                maxLength = Math.Max(maxLength, j - i + 1);
            }

            return maxLength;
        }
    }

    [TestClass]
    public class ChocolateBarTestClass
    {
        [TestMethod]
        public void ChocolateBarTest()
        {
            ChocolateBarTestClass.ChocolateBarTest("srm", 3);
            ChocolateBarTestClass.ChocolateBarTest("dengklek", 6);
            ChocolateBarTestClass.ChocolateBarTest("haha", 2);
            ChocolateBarTestClass.ChocolateBarTest("www", 1);
            ChocolateBarTestClass.ChocolateBarTest("thisisansrmbeforetopcoderopenfinals", 9);
        }

        private static void ChocolateBarTest(string letters, int expected)
        {
            ChocolateBar chocolateBar = new ChocolateBar();
            Assert.AreEqual(expected, chocolateBar.maxLength(letters));
        }
    }
}
