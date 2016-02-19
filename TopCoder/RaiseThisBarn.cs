// https://community.topcoder.com/stat?c=problem_statement&pm=12780

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class RaiseThisBarn
    {
        public int calc(string str)
        {
            int left = -1;
            int right = str.Length;

            while (true)
            {
                int i = left + 1;
                while (i < right && str[i] == '.')
                    i++;

                if (i == right)
                    break;

                int j = right - 1;
                while (j > i  && str[j] == '.')
                    j--;

                if (j == i)
                    return 0;

                left = i;
                right = j;
            }

            return (right == str.Length) ? str.Length - 1 : right - left;
        }
    }

    [TestClass]
    public class RaiseThisBarnTestClass
    {
        [TestMethod]
        public void RaiseThisBarnTest()
        {
            RaiseThisBarnTestClass.RaiseThisBarnTest("cc..c.c", 3);
            RaiseThisBarnTestClass.RaiseThisBarnTest("c....c....c", 0);
            RaiseThisBarnTestClass.RaiseThisBarnTest("............", 11);
            RaiseThisBarnTestClass.RaiseThisBarnTest(".c.c...c..ccc.c..c.c.cc..ccc", 3);
        }

        private static void RaiseThisBarnTest(string str, int expected)
        {
            RaiseThisBarn raiseThisBarn = new RaiseThisBarn();
            Assert.AreEqual(expected, raiseThisBarn.calc(str));
        }
    }
}
