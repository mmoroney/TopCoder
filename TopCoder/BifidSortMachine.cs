// https://community.topcoder.com/stat?c=problem_statement&pm=6415

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BifidSortMachine
    {
        public int countMoves(int[] a)
        {
            int[] b = new int[a.Length];
            Array.Copy(a, b, a.Length);
            Array.Sort(b);

            int maxLength = int.MinValue;

            int i = 0;
            while (i < b.Length)
            {
                int start = i;
                for (int j = 0; j < a.Length; j++)
                {
                    if (b[i] == a[j])
                    {
                        i++;
                        if (i == b.Length)
                            break;
                    }
                }

                maxLength = Math.Max(maxLength, i - start);
            }

            return a.Length - maxLength;
        }
    }

    [TestClass]
    public class BifidSortMachineTestClass
    {
        [TestMethod]
        public void BifidSortMachineTest()
        {
            BifidSortMachineTestClass.BifidSortMachineTest(new int[] { 8, 12, 25, 7, 15, 19 }, 2);
            BifidSortMachineTestClass.BifidSortMachineTest(new int[] { 1, 2, 3, 4, 5 }, 0);
            BifidSortMachineTestClass.BifidSortMachineTest(new int[] { 1000, -1000, 0 }, 1);
            BifidSortMachineTestClass.BifidSortMachineTest(new int[] { 1, -10, -1, -8, 4 }, 3);
        }

        private static void BifidSortMachineTest(int[] a, int expected)
        {
            BifidSortMachine bifidSortMachine = new BifidSortMachine();
            Assert.AreEqual(expected, bifidSortMachine.countMoves(a));
        }
    }
}
