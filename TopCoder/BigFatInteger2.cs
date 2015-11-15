// https://community.topcoder.com/stat?c=problem_statement&pm=3118

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BigFatInteger2
    {
        public string isDivisible(int A, int B, int C, int D)
        {
            int i = 1;
            while (C > 1)
            {
                i++;
                if (i * i > C)
                    i = C;

                long j = 0;
                while(C % i == 0)
                {
                    j++;
                    C /= i;
                }

                long k = 0;
                while(A % i == 0)
                {
                    k++;
                    A /= i;
                }

                if (j * D > k * B)
                    return "not divisible";
            }

            return "divisible";
        }
    }

    [TestClass]
    public class BigFatInteger2TestClass
    {
        [TestMethod]
        public void BigFatInteger2Test()
        {
            BigFatInteger2TestClass.BigFatInteger2Test(6, 1, 2, 1, "divisible");
            BigFatInteger2TestClass.BigFatInteger2Test(2, 1, 6, 1, "not divisible");
            BigFatInteger2TestClass.BigFatInteger2Test(1000000000, 1000000000, 1000000000, 200000000, "divisible");
            BigFatInteger2TestClass.BigFatInteger2Test(8, 100, 4, 200, "not divisible");
            BigFatInteger2TestClass.BigFatInteger2Test(999999937, 1000000000, 999999929, 1, "not divisible");
            BigFatInteger2TestClass.BigFatInteger2Test(2, 2, 4, 1, "divisible");
        }

        private static void BigFatInteger2Test(int A, int B, int C, int D, string expected)
        {
            BigFatInteger2 bigFatInteger2 = new BigFatInteger2();
            Assert.AreEqual(expected, bigFatInteger2.isDivisible(A, B, C, D));
        }
    }
}
