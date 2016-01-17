// https://community.topcoder.com/stat?c=problem_statement&pm=11513

using System.Text;
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

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < S.Length; i++)
            {
                for(int j = 0; j < counts.Length; j++)
                {
                    if(counts[j] > 0 && S[i] - 'a' != j)
                    {
                        sb.Append((char)('a' + j));
                        counts[j]--;
                        break;
                    }
                }

                if (sb.Length < i)
                    return string.Empty;
            }

            return sb.ToString();
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
