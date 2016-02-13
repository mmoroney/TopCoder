// https://community.topcoder.com/stat?c=problem_statement&pm=6375

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class NounReform
    {
        public string[] makePlural(string[] nouns)
        {
            return nouns.Select(noun =>
            {
                char last = noun.Last();
                char secondLast = (noun.Length > 1) ? noun[noun.Length - 2] : char.MinValue;

                if ("szx".Contains(last) || (last == 'h' && "sc".Contains(secondLast)))
                    return noun + "es";

                if (last == 'y' && !"aeiou".Contains(secondLast))
                    return noun.Substring(0, noun.Length - 1) + "ies";

                return noun + 's';
            }).ToArray();
        }
    }

    [TestClass]
    public class NounReformTestClass
    {
        [TestMethod]
        public void NounReformTest()
        {
            NounReformTestClass.NounReformTest(new string[] { "box", "church", "elephant", "stereo" }, new string[] { "boxes", "churches", "elephants", "stereos" });
            NounReformTestClass.NounReformTest(new string[] { "tray", "key", "enemy", "baby" }, new string[] { "trays", "keys", "enemies", "babies" });
            NounReformTestClass.NounReformTest(new string[] { "a", "s", "oy", "y", "yy" }, new string[] { "as", "ses", "oys", "ies", "yies" });
        }

        private static void NounReformTest(string[] nouns, string[] expected)
        {
            NounReform nounReform = new NounReform();
            string[] results = nounReform.makePlural(nouns);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
