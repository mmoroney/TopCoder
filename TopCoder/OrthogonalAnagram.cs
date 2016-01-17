// https://community.topcoder.com/stat?c=problem_statement&pm=11513

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class OrthogonalAnagram
    {
        public string solve(string S)
        {
            int[] counts = new int[26];
            foreach (char c in S)
                counts[c - 'a']++;

            char[] result = new char[S.Length];

            for(int i = 0; i < S.Length; i++)
            {
                int j = 0;
                while (j < counts.Length && (counts[j] == 0 || j == S[i] - 'a'))
                    j++;

                if (j == counts.Length)
                    return string.Empty;

                result[i] = (char)('a' + j);
                counts[j]--;
            }

            return new string(result);
        }
    }

    [TestClass]
    public class OrthogonalAnagramTestClass
    {
        [TestMethod]
        public void OrthogonalAnagramTest()
        {
            OrthogonalAnagramTestClass.OrthogonalAnagramTest("dcba", "abcd");
            OrthogonalAnagramTestClass.OrthogonalAnagramTest("edcba", "abdce");
            OrthogonalAnagramTestClass.OrthogonalAnagramTest("aaaaa", "");
            OrthogonalAnagramTestClass.OrthogonalAnagramTest("abba", "baab");
        }

        private static void OrthogonalAnagramTest(string S, string expected)
        {
            OrthogonalAnagram orthogonalAnagram = new OrthogonalAnagram();
            Assert.AreEqual(expected, orthogonalAnagram.solve(S));
        }
    }
}
