// https://community.topcoder.com/stat?c=problem_statement&pm=12778

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class WolfDelayMaster
    {
        public string check(string str)
        {
            int i = 0;
            while(i < str.Length)
            {
                int count = 0;
                while (i + count < str.Length && str[i + count] == 'w')
                    count++;

                int next = i + 4 * count;

                if (next == i || next > str.Length)
                    return "INVALID";

                for(int j = i + count; j < next; j++)
                {
                    if (str[j] != "olf"[(j - i) / count - 1])
                        return "INVALID";
                }

                i = next;
            }
            return "VALID";
        }
    }

    [TestClass]
    public class WolfDelayMasterTestClass
    {
        [TestMethod]
        public void WolfDelayMasterTest()
        {
            WolfDelayMasterTestClass.WolfDelayMasterTest("wolf", "VALID");
            WolfDelayMasterTestClass.WolfDelayMasterTest("wwolfolf", "INVALID");
            WolfDelayMasterTestClass.WolfDelayMasterTest("wolfwwoollffwwwooolllfffwwwwoooollllffff", "VALID");
            WolfDelayMasterTestClass.WolfDelayMasterTest("flowolf", "INVALID");
        }

        private static void WolfDelayMasterTest(string str, string expected)
        {
            WolfDelayMaster wolfDelayMaster = new WolfDelayMaster();
            Assert.AreEqual(expected, wolfDelayMaster.check(str));
        }
    }
}
