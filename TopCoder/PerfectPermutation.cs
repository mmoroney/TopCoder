// https://community.topcoder.com/stat?c=problem_statement&pm=10463

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class PerfectPermutation
    {
        public int reorder(int[] P)
        {
            bool[] visited = new bool[P.Length];
            int cycles = 0;

            for (int i = 0; i < P.Length; i++)
            {
                if (visited[i])
                    continue;

                cycles++;

                int j = i;
                while (!visited[j])
                {
                    visited[j] = true;
                    j = P[j];
                }
            }

            return (cycles == 1) ? 0 : cycles;
        }
    }

    [TestClass]
    public class PerfectPermutationTestClass
    {
        [TestMethod]
        public void PerfectPermutationTest()
        {
            PerfectPermutation perfectPermutation = new PerfectPermutation();
            Assert.AreEqual(0, perfectPermutation.reorder(new int[] { 2, 0, 1 }));
            Assert.AreEqual(2, perfectPermutation.reorder(new int[] { 2, 0, 1, 4, 3 }));
            Assert.AreEqual(2, perfectPermutation.reorder(new int[] { 2, 3, 0, 1 }));
            Assert.AreEqual(3, perfectPermutation.reorder(new int[] { 0, 5, 3, 2, 1, 4 }));
            Assert.AreEqual(5, perfectPermutation.reorder(new int[] { 4, 2, 6, 0, 3, 5, 9, 7, 8, 1 }));
        }

        private static void PerfectPermutationTest(int[] P, int expected)
        {
            PerfectPermutation perfectPermutation = new PerfectPermutation();
            Assert.AreEqual(expected, perfectPermutation.reorder(P));
        }
    }
}
