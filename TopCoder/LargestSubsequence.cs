// https://community.topcoder.com/stat?c=problem_statement&pm=11471

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class LargestSubsequence
    {
        public string getLargest(string s)
        {
            StringBuilder sb = new StringBuilder();

            char largest = '\0';

            for(int i = s.Length - 1; i >= 0; i--)
            {
                if(s[i] >= largest)
                {
                    sb.Insert(0, s[i]);
                    largest = s[i];
                }
            }
            return sb.ToString();
        }
    }

    [TestClass]
    public class LargestSubsequenceTestClass
    {
        [TestMethod]
        public void LargestSubsequenceTest()
        {
            LargestSubsequenceTestClass.LargestSubsequenceTest("test", "tt");
            LargestSubsequenceTestClass.LargestSubsequenceTest("a", "a");
            LargestSubsequenceTestClass.LargestSubsequenceTest("example", "xple");
            LargestSubsequenceTestClass.LargestSubsequenceTest("aquickbrownfoxjumpsoverthelazydog", "zyog");
        }

        private static void LargestSubsequenceTest(string s, string expected)
        {
            LargestSubsequence largestSubsequence = new LargestSubsequence();
            Assert.AreEqual(expected, largestSubsequence.getLargest(s));
        }
    }
}
