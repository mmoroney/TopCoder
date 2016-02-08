// https://community.topcoder.com/stat?c=problem_statement&pm=11101

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TxMsg
    {
        public string getMessage(string original)
        {
            string[] words = original.Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                if (sb.Length > 0)
                    sb.Append(' ');

                int i = 0;
                bool allVowels = true;

                while (true)
                {
                    while (i < word.Length && TxMsg.IsVowel(word[i]))
                        i++;

                    if (i == word.Length)
                    {
                        if (allVowels)
                            sb.Append(word);

                        break;
                    }

                    allVowels = false;

                    sb.Append(word[i]);
                    i++;

                    while (i < word.Length && !TxMsg.IsVowel(word[i]))
                        i++;
                }
            }

            return sb.ToString();
        }

        private static bool IsVowel(char c)
        {
            return "aeiou".IndexOf(c) >= 0;
        }
    }

    [TestClass]
    public class TxMsgTestClass
    {
        [TestMethod]
        public void TxMsgTest()
        {
            TxMsgTestClass.TxMsgTest("text message", "tx msg");
            TxMsgTestClass.TxMsgTest("ps i love u", "p i lv u");
            TxMsgTestClass.TxMsgTest("please please me", "ps ps m");
            TxMsgTestClass.TxMsgTest("back to the ussr", "bc t t s");
            TxMsgTestClass.TxMsgTest("aeiou bcdfghjklmnpqrstvwxyz", "aeiou b");
        }

        private static void TxMsgTest(string original, string expected)
        {
            TxMsg txMsg = new TxMsg();
            Assert.AreEqual(expected, txMsg.getMessage(original));
        }
    }
}
