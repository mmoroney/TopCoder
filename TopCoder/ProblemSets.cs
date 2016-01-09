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

            while(low + 1 < high)
            {
                long middle = low + (high - low) / 2;

                if(ProblemSets.IsCandidate(middle, E, EM,M, MH, H))
                    low = middle;
                else
                    high = middle;
            }

            return low;
        }

        private static bool IsCandidate(long n, long E, long EM, long M, long MH, long H)
        {
            if (E + EM < n || MH + H < n)
                return false;

            EM -= Math.Max(0, n - E);
            MH -= Math.Max(0, n - H);

            return M + EM + MH >= n;
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
