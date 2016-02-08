// https://community.topcoder.com/stat?c=problem_statement&pm=7650

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Trekking
    {
        public int findCamps(string trail, string[] plans)
        {
            int minCamps = int.MaxValue;

            foreach (string plan in plans)
            {
                int i = 0;
                int camps = 0;

                while (i < plan.Length)
                {
                    if (plan[i] == 'C')
                    {
                        if (trail[i] == '^')
                            break;

                        camps++;
                    }
                    i++;
                }

                if (i == plan.Length)
                    minCamps = Math.Min(camps, minCamps);
            }

            return (minCamps == int.MaxValue) ? -1 : minCamps;
        }
    }

    [TestClass]
    public class TrekkingTestClass
    {
        [TestMethod]
        public void TrekkingTest()
        {
            TrekkingTestClass.TrekkingTest("^^....^^^...", new string[] { "CwwCwwCwwCww", "wwwCwCwwwCww", "wwwwCwwwwCww" }, 2);
            TrekkingTestClass.TrekkingTest("^^^^", new string[] { "wwww", "wwwC" }, 0);
            TrekkingTestClass.TrekkingTest("^^.^^^^", new string[] { "wwCwwwC", "wwwCwww", "wCwwwCw" }, -1);
            TrekkingTestClass.TrekkingTest("^^^^....^.^.^.", new string[] { "wwwwCwwwwCwCwC", "wwwwCwwCwCwwwC", "wwwCwwwCwwwCww", "wwwwwCwwwCwwwC" }, 3);
            TrekkingTestClass.TrekkingTest("..............", new string[] { "CwCwCwCwCwCwCw", "CwwCwwCwwCwwCw" }, 5);
        }

        private static void TrekkingTest(string trail, string[] plans, int expected)
        {
            Trekking trekking = new Trekking();
            Assert.AreEqual(expected, trekking.findCamps(trail, plans));
        }
    }
}
