// https://community.topcoder.com/stat?c=problem_statement&pm=13548

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BuyingTShirts
    {
        public int meet(int T, int[] Q, int[] P)
        {
            int p = 0;
            int q = 0;

            int count = 0;

            for (int i = 0; i < Q.Length; i++)
            {
                p += P[i];
                q += Q[i];

                if (p >= T && q >= T)
                    count++;

                p %= T;
                q %= T;
            }

            return count;
        }
    }

    [TestClass]
    public class BuyingTShirtsTestClass
    {
        [TestMethod]
        public void BuyingTShirtsTest()
        {
            BuyingTShirtsTestClass.BuyingTShirtsTest(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 }, 2);
            BuyingTShirtsTestClass.BuyingTShirtsTest(10, new int[] { 10, 10, 10 }, new int[] { 10, 10, 10 }, 3);
            BuyingTShirtsTestClass.BuyingTShirtsTest(2, new int[] { 1, 2, 1, 2, 1, 2, 1, 2 }, new int[] { 1, 1, 1, 1, 2, 2, 2, 2 }, 5);
            BuyingTShirtsTestClass.BuyingTShirtsTest(100, new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 0);
            BuyingTShirtsTestClass.BuyingTShirtsTest(10, new int[] { 10, 1, 10, 1 }, new int[] { 1, 10, 1, 10 }, 0);
        }

        private static void BuyingTShirtsTest(int T, int[] Q, int[] P, int expected)
        {
            BuyingTShirts buyingTShirts = new BuyingTShirts();
            Assert.AreEqual(expected, buyingTShirts.meet(T, Q, P));
        }
    }
}
