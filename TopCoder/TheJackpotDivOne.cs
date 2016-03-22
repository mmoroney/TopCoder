// https://community.topcoder.com/stat?c=problem_statement&pm=11097

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TheJackpotDivOne
    {
        public long[] find(long[] money, long jackpot)
        {
            double sum = money.Sum();
            int n = money.Length;

            while(jackpot > 0 && money.Any(a => a != money[0]))
            {
                int min = 0;
                for(int i = 1; i < money.Length; i++)
                {
                    if (money[i] < money[min])
                        min = i;
                }

                long amount = Math.Min(jackpot, (long)(sum / n) - money[min] + 1);

                money[min] += amount;
                sum += amount;
                jackpot -= amount;
            }

            Array.Sort(money);

            if(jackpot > 0)
            {
                for(int i = 0; i < money.Length; i++)
                {
                    money[i] += jackpot / n;
                    if (i >= n - jackpot % n)
                        money[i]++;
                }
            }

            return money;
        }
    }

    [TestClass]
    public class TheJackpotDivOneTestClass
    {
        [TestMethod]
        public void TheJackpotDivOneTest()
        {
            TheJackpotDivOneTestClass.TheJackpotDivOneTest(new long[] { 1, 2, 3, 4 }, 2, new long[] { 2, 3, 3, 4 });
            TheJackpotDivOneTestClass.TheJackpotDivOneTest(new long[] { 4 }, 7, new long[] { 11 });
            TheJackpotDivOneTestClass.TheJackpotDivOneTest(new long[] { 4, 44, 7, 77 }, 47, new long[] { 24, 34, 44, 77 });
            TheJackpotDivOneTestClass.TheJackpotDivOneTest(new long[] { 4, 10, 8, 3, 6, 5, 8, 3, 7, 5 }, 1000, new long[] { 105, 106, 106, 106, 106, 106, 106, 106, 106, 106 });
        }

        private static void TheJackpotDivOneTest(long[] money, long jackpot, long[] expected)
        {
            TheJackpotDivOne theJackpotDivOne = new TheJackpotDivOne();
            long[] results = theJackpotDivOne.find(money, jackpot);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
