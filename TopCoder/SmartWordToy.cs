// https://community.topcoder.com/stat?c=problem_statement&pm=3935

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SmartWordToy
    {
        public int minPresses(string start, string finish, string[] forbid)
        {
            int[] flags = new int[26 * 26 * 26 * 26 / 8];
            SmartWordToy.SetForbiddenFlags(flags, forbid);

            int finishIndex = SmartWordToy.ToIndex(finish);
            if (SmartWordToy.GetFlag(flags, finishIndex))
                return -1;

            Queue<int> next = new Queue<int>();
            Queue<int> current = new Queue<int>();

            int startIndex = SmartWordToy.ToIndex(start);

            SmartWordToy.SetFlag(flags, startIndex);
            current.Enqueue(startIndex);

            int count = 1;

            while(current.Count > 0)
            {
                int currentIndex = current.Dequeue();

                foreach(int adjacentIndex in SmartWordToy.GetAdjacentIndices(currentIndex))
                {
                    if (adjacentIndex == finishIndex)
                        return count;

                    if (SmartWordToy.GetFlag(flags, adjacentIndex))
                        continue;

                    SmartWordToy.SetFlag(flags, adjacentIndex);
                    next.Enqueue(adjacentIndex);
                }

                if (current.Count == 0)
                {
                    current = next;
                    next = new Queue<int>();
                    count++;
                }
            }

            return -1;
        }

        private static void SetForbiddenFlags(int[] flags, string[] forbid)
        {
            for (int i = 0; i < forbid.Length; i++)
            {
                string[] tokens = forbid[i].Split(' ');
                foreach (char w in tokens[0])
                {
                    foreach (char x in tokens[1])
                    {
                        foreach (char y in tokens[2])
                        {
                            foreach (char z in tokens[3])
                            {
                                SmartWordToy.SetFlag(flags, SmartWordToy.ToIndex(w, x, y, z));
                            }
                        }
                    }
                }
            }
        }

        private static IEnumerable<int> GetAdjacentIndices(int index)
        {
            int p = 1;
            for(int i = 0; i < 4; i++)
            {
                for(int j = -1; j <= 1; j += 2)
                {
                    int d = index % (p * 26) - index % p;
                    yield return index - d + (d + j * p + (p * 26)) % (p * 26);
                }

                p *= 26;
            }
        }

        private static bool GetFlag(int[] flags, int index)
        {
            return (flags[index / 8] & 1 << (index % 8)) > 0;
        }

        private static void SetFlag(int[] flags, int index)
        {
            flags[index / 8] |= 1 << (index % 8);
        }

        private static int ToIndex(string s)
        {
            return SmartWordToy.ToIndex(s[0], s[1], s[2], s[3]);
        }

        private static int ToIndex(char c0, char c1, char c2, char c3)
        {
            return SmartWordToy.ToIndex(c0 - 'a', c1 - 'a', c2 - 'a', c3 - 'a');
        }

        private static int ToIndex(int d0, int d1, int d2, int d3)
        {
            return d3 * 26 * 26 * 26 +  d2 * 26 * 26 + d1 * 26 + d0;
        }
    }

    [TestClass]
    public class SmartWordToyTestClass
    {
        [TestMethod]
        public void SmartWordToyTest()
        {
            SmartWordToyTestClass.SmartWordToyTest("aaaa", "zzzz",
                new string[] 
                {
                    "a a a z", "a a z a", "a z a a", "z a a a", "a z z z", "z a z z", "z z a z", "z z z a"
                }, 8);

            SmartWordToyTestClass.SmartWordToyTest("aaaa", "bbbb",
                new string[]
                {
                }, 4);

            SmartWordToyTestClass.SmartWordToyTest("aaaa", "mmnn",
                new string[]
                {
                }, 50);

            SmartWordToyTestClass.SmartWordToyTest("aaaa", "zzzz",
                new string[]
                {
                    "bz a a a", "a bz a a", "a a bz a", "a a a bz"
                }, -1);

            SmartWordToyTestClass.SmartWordToyTest("aaaa", "zzzz",
                new string[]
                {
                    "cdefghijklmnopqrstuvwxyz a a a",
                    "a cdefghijklmnopqrstuvwxyz a a",
                    "a a cdefghijklmnopqrstuvwxyz a",
                    "a a a cdefghijklmnopqrstuvwxyz"
                }, 6);

            SmartWordToyTestClass.SmartWordToyTest("aaaa", "bbbb",
                new string[]
                {
                    "b b b b"
                }, -1);

            SmartWordToyTestClass.SmartWordToyTest("zzzz", "aaaa",
                new string[]
                {
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk",
                    "abcdefghijkl abcdefghijkl abcdefghijkl abcdefghijk"
                }, -1);
        }

        private static void SmartWordToyTest(string start, string finish, string[] forbid, int expected)
        {
            SmartWordToy smartWordToy = new SmartWordToy();
            Assert.AreEqual(expected, smartWordToy.minPresses(start, finish, forbid));
        }
    }
}
