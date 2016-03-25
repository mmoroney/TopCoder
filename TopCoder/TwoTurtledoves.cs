// https://community.topcoder.com/stat?c=problem_statement&pm=10966

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TwoTurtledoves
    {
        public int presentType(int n)
        {
            int i = 1;
            while(true)
            {
                int gifts = i * (i + 1) / 2;
                if (gifts >= n)
                    break;

                n -= gifts;
                i++;
            }

            while (n > i)
            {
                n -= i;
                i--;
            }

            return i;
        }
    }

    [TestClass]
    public class TwoTurtledovesTestClass
    {
        [TestMethod]
        public void TwoTurtledovesTest()
        {
            TwoTurtledovesTestClass.TwoTurtledovesTest(10, 1);
            TwoTurtledovesTestClass.TwoTurtledovesTest(12, 4);
            TwoTurtledovesTestClass.TwoTurtledovesTest(399, 11);
            TwoTurtledovesTestClass.TwoTurtledovesTest(123456, 65);
            TwoTurtledovesTestClass.TwoTurtledovesTest(1000000000, 1704);
        }

        private static void TwoTurtledovesTest(int n, int expected)
        {
            TwoTurtledoves twoTurtledoves = new TwoTurtledoves();
            Assert.AreEqual(expected, twoTurtledoves.presentType(n));
        }
    }
}
