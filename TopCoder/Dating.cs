// https://community.topcoder.com/stat?c=problem_statement&pm=4514

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Dating
    {
        public string dates(string circle, int k)
        {
            bool[] flags = new bool[52];

            foreach (char c in circle)
                Dating.SetFlag(flags, c, true);

            StringBuilder sb = new StringBuilder();
            int i = -1;
            int remaining = circle.Length;

            while(remaining > 1)
            {
                int count = 0;

                do
                {
                    i = (i + 1) % circle.Length;
                    if (GetFlag(flags, circle[i]))
                        count++;
                }
                while (count < k);

                SetFlag(flags, circle[i], false);

                char initial = char.IsUpper(circle[i]) ? 'a' : 'A';
                char chosen = initial;

                while (initial - chosen < 26 && !GetFlag(flags, chosen))
                    chosen++;

                if (initial - chosen == 26)
                    break;

                SetFlag(flags, chosen, false);

                if (sb.Length > 0)
                    sb.Append(' ');

                sb.Append(circle[i]);
                sb.Append(chosen);

                remaining -= 2;
            }

            return sb.ToString();
        }

        private static bool GetFlag(bool[] flags, char c)
        {
            return flags[char.IsUpper(c) ? c - 'A' : c - 'a' + 26];
        }

        private static void SetFlag(bool[] flags, char c, bool value)
        {
            flags[char.IsUpper(c) ? c - 'A' : c - 'a' + 26] = value;
        }
    }

    [TestClass]
    public class DatingTestClass
    {
        [TestMethod]
        public void DatingTest()
        {
            DatingTestClass.DatingTest("abXCd", 2, "bC dX");
            DatingTestClass.DatingTest("abXCd", 8, "Xa dC");
            DatingTestClass.DatingTest("HGFhgfz", 1, "Hf Gg Fh");
        }

        private static void DatingTest(string circle, int k, string expected)
        {
            Dating dating = new Dating();
            Assert.AreEqual(expected, dating.dates(circle, k));
        }
    }
}
