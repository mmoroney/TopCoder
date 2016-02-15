// https://community.topcoder.com/stat?c=problem_statement&pm=7613

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SumOfPerfectPowers
    {
        public int howMany(int lowerBound, int upperBound)
        {
            List<int> powers = new List<int>();
            bool[] flags = new bool[upperBound + 1];

            powers.Add(0);
            powers.Add(1);
            flags[0] = true;
            flags[1] = true;

            for (int i = 2; i * i <= upperBound; i++)
            {
                int j = i;
                while (j <= upperBound / i)
                {
                    j *= i;
                    powers.Add(j);
                    flags[j] = true;
                }
            }

            for (int i = 0; i < powers.Count; i++)
            {
                for (int j = 0; j < powers.Count; j++)
                {
                    int sum = powers[i] + powers[j];
                    if (sum <= upperBound)
                        flags[sum] = true;
                }
            }

            int count = 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (flags[i])
                    count++;
            }

            return count;
        }
    }

    [TestClass]
    public class SumOfPerfectPowersTestClass
    {
        [TestMethod]
        public void SumOfPerfectPowersTest()
        {
            SumOfPerfectPowersTestClass.SumOfPerfectPowersTest(0, 1, 2);
            SumOfPerfectPowersTestClass.SumOfPerfectPowersTest(5, 6, 1);
            SumOfPerfectPowersTestClass.SumOfPerfectPowersTest(25, 30, 5);
            SumOfPerfectPowersTestClass.SumOfPerfectPowersTest(103, 103, 0);
            SumOfPerfectPowersTestClass.SumOfPerfectPowersTest(1, 100000, 33604);
        }

        private static void SumOfPerfectPowersTest(int lowerBound, int upperBound, int expected)
        {
            SumOfPerfectPowers sumOfPerfectPowers = new SumOfPerfectPowers();
            Assert.AreEqual(expected, sumOfPerfectPowers.howMany(lowerBound, upperBound));
        }
    }
}
