// https://community.topcoder.com/stat?c=problem_statement&pm=8058

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TopCoder
{
    public class AntiPalindrome
    {
        public string rearrange(string s)
        {
            int[] counts = new int[26];
            foreach (char c in s)
                counts[c - 'a']++;

            char[] result = new char[s.Length];

            for(int i = 0; i < s.Length; i++)
            {
                int j = 0;
                while (j < 26 && (counts[j] == 0 || j == result[result.Length - i - 1] - 'a'))
                    j++;

                if (j == 26)
                    return string.Empty;

                result[i] = (char)(j + 'a');
                counts[j]--;
            }

            return new string(result);
        }
    }

    [TestClass]
    public class AntiPalindromeTestClass
    {
        [TestMethod]
        public void AntiPalindromeTest()
        {
            AntiPalindromeTestClass.AntiPalindromeTest("test", "estt");
            AntiPalindromeTestClass.AntiPalindromeTest("aabbcc", "aabcbc");
            AntiPalindromeTestClass.AntiPalindromeTest("reflectionnoitcelfer", "cceeeeffiillnnoorrtt");
            AntiPalindromeTestClass.AntiPalindromeTest("hello", "ehllo");
            AntiPalindromeTestClass.AntiPalindromeTest("www", "");
        }

        private static void AntiPalindromeTest(string s, string expected)
        {
            AntiPalindrome antiPalindrome = new AntiPalindrome();
            Assert.AreEqual(expected, antiPalindrome.rearrange(s));
        }
    }
}
