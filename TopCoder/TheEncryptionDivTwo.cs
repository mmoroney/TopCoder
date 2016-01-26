// https://community.topcoder.com/stat?c=problem_statement&pm=10509

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TheEncryptionDivTwo
    {
        public string encrypt(string message)
        {
            char next = 'a';
            char[] cipher = new char[26];
            StringBuilder stringBuilder = new StringBuilder();

            foreach(char current in message)
            {
                int index = current - 'a';
                if(cipher[index] == 0)
                {
                    cipher[index] = next;
                    next++;
                }

                stringBuilder.Append(cipher[index]);
            }

            return stringBuilder.ToString();
        }
    }

    [TestClass]
    public class TheEncryptionDivTwoTestClass
    {
        [TestMethod]
        public void TheEncryptionDivTwoTest()
        {
            TheEncryptionDivTwoTestClass.TheEncryptionDivTwoTest("hello", "abccd");
            TheEncryptionDivTwoTestClass.TheEncryptionDivTwoTest("abcd", "abcd");
            TheEncryptionDivTwoTestClass.TheEncryptionDivTwoTest("topcoder", "abcdbefg");
            TheEncryptionDivTwoTestClass.TheEncryptionDivTwoTest("encryption", "abcdefghib");
        }

        private static void TheEncryptionDivTwoTest(string message, string expected)
        {
            TheEncryptionDivTwo theEncryptionDivTwo = new TheEncryptionDivTwo();
            Assert.AreEqual(expected, theEncryptionDivTwo.encrypt(message));
        }
    }
}
