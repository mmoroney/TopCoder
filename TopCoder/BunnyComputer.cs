// https://community.topcoder.com/stat?c=problem_statement&pm=11157

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BunnyComputer
    {
        public int getMaximum(int[] preference, int k)
        {
            int max = 0;

            for(int i = 0; i <= k; i++)
            {
                int sum = 0;
                int min = int.MaxValue;
                int count = 0;

                for(int j = i; j < preference.Length; j += k + 1)
                {
                    sum += preference[j];
                    if (count % 2 == 0)
                        min = Math.Min(min, preference[j]);

                    count++;
                }

                if (count % 2 == 1)
                    sum -= min;

                max += sum;
            }

            return max;
        }
    }

    [TestClass]
    public class BunnyComputerTestClass
    {
        [TestMethod]
        public void BunnyComputerTest()
        {
            BunnyComputerTestClass.BunnyComputerTest(new int[] { 3, 1, 4, 1, 5, 9, 2, 6 }, 2, 28);
            BunnyComputerTestClass.BunnyComputerTest(new int[] { 3, 1, 4, 1, 5, 9, 2, 6 }, 1, 31);
            BunnyComputerTestClass.BunnyComputerTest(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 14);
            BunnyComputerTestClass.BunnyComputerTest(new int[] { 487, 2010 }, 2, 0);
        }

        private static void BunnyComputerTest(int[] preference, int k, int expected)
        {
            BunnyComputer bunnyComputer = new BunnyComputer();
            Assert.AreEqual(expected, bunnyComputer.getMaximum(preference, k));
        }
    }
}
