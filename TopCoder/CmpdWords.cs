// https://community.topcoder.com/stat?c=problem_statement&pm=3490

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class CmpdWords
    {
        public int ambiguous(string[] dictionary)
        {
            TrieNode root = new TrieNode();

            foreach (string word in dictionary)
                root.Add(word);

            int count = 0;

            for (int i = 0; i < dictionary.Length; i++)
            {
                for(int j = 0; j < dictionary.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (root.Add(dictionary[i] + dictionary[j]))
                        count++;
                }
            }

            return count;
        }

        private class TrieNode
        {
            TrieNode[] nodes = new TrieNode[26];
            int count;

            public bool Add(string s, int index = 0)
            {
                if (index == s.Length)
                {
                    this.count++;
                    return this.count == 2;
                }

                TrieNode node = this.nodes[s[index] - 'a'];
                if (node == null)
                {
                    node = new TrieNode();
                    this.nodes[s[index] - 'a'] = node;
                }

                return node.Add(s, index + 1);
            }
        }
    }

    [TestClass]
    public class CmpdWordsTestClass
    {
        [TestMethod]
        public void CmpdWordsTest()
        {
            CmpdWordsTestClass.CmpdWordsTest(new string[] { "am", "eat", "a", "meat", "hook", "meathook" }, 2);
            CmpdWordsTestClass.CmpdWordsTest(new string[] { "a", "b", "c" }, 0);
            CmpdWordsTestClass.CmpdWordsTest(new string[] { "a", "aa", "aaa" }, 3);
            CmpdWordsTestClass.CmpdWordsTest(new string[] { "abc", "bca", "bab", "a" }, 1);
        }

        private static void CmpdWordsTest(string[] dictionary, int expected)
        {
            CmpdWords cmpdWords = new CmpdWords();
            Assert.AreEqual(expected, cmpdWords.ambiguous(dictionary));
        }
    }
}
