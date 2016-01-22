// https://community.topcoder.com/stat?c=problem_statement&pm=12125

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class EasyConversionMachine
    {
        public string isItPossible(string originalWord, string finalWord, int k)
        {
            int count = 0;
            for(int i = 0; i < originalWord.Length; i++)
            {
                if (originalWord[i] != finalWord[i])
                    count++;
            }

            return (k >= count && (k - count) % 2 == 0) ? "POSSIBLE" : "IMPOSSIBLE";
        }
    }

    [TestClass]
    public class EasyConversionMachineTestClass
    {
        [TestMethod]
        public void EasyConversionMachineTest()
        {
            EasyConversionMachineTestClass.EasyConversionMachineTest("aababba", "bbbbbbb", 2, "IMPOSSIBLE");
            EasyConversionMachineTestClass.EasyConversionMachineTest("aabb", "aabb", 1, "IMPOSSIBLE");
            EasyConversionMachineTestClass.EasyConversionMachineTest("aaaaabaa", "bbbbbabb", 8, "POSSIBLE");
            EasyConversionMachineTestClass.EasyConversionMachineTest("aaa", "bab", 4, "POSSIBLE");
            EasyConversionMachineTestClass.EasyConversionMachineTest("aababbabaa", "abbbbaabab", 9, "IMPOSSIBLE");
        }

        private static void EasyConversionMachineTest(string originalWord, string finalWord, int k, string expected)
        {
            EasyConversionMachine EasyConversionMachine = new EasyConversionMachine();
            Assert.AreEqual(expected, EasyConversionMachine.isItPossible(originalWord, finalWord, k));
        }
    }
}
