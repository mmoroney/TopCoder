// https://community.topcoder.com/stat?c=problem_statement&pm=13771

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ProblemSets
    {
        public long maxSets(long E, long EM, long M, long MH, long H)
        {
            long low = 0;
            long high = E + EM + 1;

            while (low + 1 < high)
            {
                long mid = low + (high - low) / 2;

                if (E + EM >= mid && MH + H >= mid && M + EM + MH - Math.Max(0, mid - E) - Math.Max(0, mid - H) >= mid)
                    low = mid;
                else
                    high = mid;
            }

            return low;
        }
    }

    [TestClass]
    public class ProblemSetsTestClass
    {
        [TestMethod]
        public void ProblemSetsTest()
        {
            ProblemSetsTestClass.ProblemSetsTest(2, 2, 1, 2, 2, 3);
            ProblemSetsTestClass.ProblemSetsTest(100, 100, 100, 0, 0, 0);
            ProblemSetsTestClass.ProblemSetsTest(657, 657, 657, 657, 657, 1095);
            ProblemSetsTestClass.ProblemSetsTest(1, 2, 3, 4, 5, 3);
            ProblemSetsTestClass.ProblemSetsTest(1000000000000000000, 1000000000000000000, 1000000000000000000, 1000000000000000000, 1000000000000000000, 1666666666666666666);
        }

        private static void ProblemSetsTest(long E, long EM, long M, long MH, long H, long expected)
        {
            ProblemSets problemSets = new ProblemSets();
            Assert.AreEqual(expected, problemSets.maxSets(E, EM, M, MH, H));
        }
    }
}
