// https://community.topcoder.com/stat?c=problem_statement&pm=8594

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class RoughStrings
    {
        public int minRoughness(string s, int n)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            int low = -1;
            int high = s.Length;

            while (low + 1 < high)
            {
                int mid = low + (high - low) / 2;
                if (RoughStrings.Check(counts, mid, n, s.Length))
                    high = mid;
                else
                    low = mid;
            }

            return low + 1;
        }

        private static bool Check(int[] counts, int roughness, int n, int length)
        {
            for(int min = 1; min <= length; min++)
            {
                int max = min + roughness;
                int removed = 0;

                foreach(int count in counts)
                {
                    if (count < min)
                        removed += count;
                    else if (count > max)
                        removed += count - max;
                }

                if (removed <= n)
                    return true;
            }

            return false;
        }
    }

    [TestClass]
    public class RoughStringsTestClass
    {
        [TestMethod]
        public void RoughStringsTest()
        {
            RoughStringsTestClass.RoughStringsTest("aaaaabbc", 1, 3);
            RoughStringsTestClass.RoughStringsTest("aaaabbbbc", 5, 0);
            RoughStringsTestClass.RoughStringsTest("veryeviltestcase", 1, 2);
            RoughStringsTestClass.RoughStringsTest("gggggggooooooodddddddllllllluuuuuuuccckkk", 5, 3);
            RoughStringsTestClass.RoughStringsTest("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz", 17, 0);
            RoughStringsTestClass.RoughStringsTest("bbbccca", 2, 0);
        }

        private static void RoughStringsTest(string s, int n, int expected)
        {
            RoughStrings roughStrings = new RoughStrings();
            Assert.AreEqual(expected, roughStrings.minRoughness(s, n));
        }
    }
}
