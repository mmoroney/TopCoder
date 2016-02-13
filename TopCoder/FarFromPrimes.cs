// https://community.topcoder.com/stat?c=problem_statement&pm=6074

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class FarFromPrimes
    {
        public int count(int A, int B)
        {
            int count = 0;
            int consecutive = 0;

            for(int i = Math.Max(A - 10, 0); i <= B + 10; i++)
            {
                if (FarFromPrimes.IsPrime(i))
                    consecutive = 0;
                else
                {
                    consecutive++;
                    if (consecutive > 20)
                        count++;
                }
            }

            return count;
        }

        private static bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            for(int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }

    [TestClass]
    public class FarFromPrimesTestClass
    {
        [TestMethod]
        public void FarFromPrimesTest()
        {
            FarFromPrimesTestClass.FarFromPrimesTest(3328, 4100, 4);
            FarFromPrimesTestClass.FarFromPrimesTest(10, 1000, 0);
            FarFromPrimesTestClass.FarFromPrimesTest(19240, 19710, 53);
            FarFromPrimesTestClass.FarFromPrimesTest(23659, 24065, 20);
            FarFromPrimesTestClass.FarFromPrimesTest(97001, 97691, 89);
        }

        private static void FarFromPrimesTest(int A, int B, int expected)
        {
            FarFromPrimes farFromPrimes = new FarFromPrimes();
            Assert.AreEqual(expected, farFromPrimes.count(A, B));
        }
    }
}
