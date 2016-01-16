// https://community.topcoder.com/stat?c=problem_statement&pm=1789

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TopCoder
{
    public class BaseMystery
    {
        public int[] getBase(string equation)
        {
            string[] tokens = equation.Split('+', '=');
            return Enumerable.Range(2, 19).Where(i =>
            {
                int carry = 0;
                for (int j = 0; j < 5; j++)
                {
                    int sum = carry + BaseMystery.GetDigit(tokens[0], j) + BaseMystery.GetDigit(tokens[1], j);

                    if (sum % i != BaseMystery.GetDigit(tokens[2], j))
                        return false;

                    carry = sum / i;
                }

                return true;
            }).ToArray();
        }

        private static int GetDigit(string s, int digit)
        {
            int i = s.Length - digit - 1;
            if (i < 0)
                return 0;

            char c = s[i];
            return (c >= '0' && c <= '9') ? (c - '0') : (c - 'A' + 10);
        }
    }

    [TestClass]
    public class BaseMysteryTestClass
    {
        [TestMethod]
        public void BaseMysteryTest()
        {
            BaseMysteryTestClass.BaseMysteryTest("1+1=2", new int[] { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            BaseMysteryTestClass.BaseMysteryTest("1+1=10", new int[] { 2 });
            BaseMysteryTestClass.BaseMysteryTest("1+1=3", new int[] { });
            BaseMysteryTestClass.BaseMysteryTest("ABCD+211=B000", new int[] { 14 });
            BaseMysteryTestClass.BaseMysteryTest("ABCD+322=B000", new int[] { 15 });
            BaseMysteryTestClass.BaseMysteryTest("1+0=1", new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
            BaseMysteryTestClass.BaseMysteryTest("GHIJ+1111=HJ00", new int[] { 20 });
            BaseMysteryTestClass.BaseMysteryTest("1234+8765=9999", new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        }

        private static void BaseMysteryTest(string equation, int[] expected)
        {
            BaseMystery baseMystery = new BaseMystery();
            int[] results = baseMystery.getBase(equation);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
