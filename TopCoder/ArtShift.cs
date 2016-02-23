// https://community.topcoder-qa.com/stat?c=problem_statement&pm=11440

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ArtShift
    {
        public int maxShifts(string sequence)
        {
            int count = sequence.Count(c => c == 'B');
            return ArtShift.MaxShifts(sequence.Length, 2, 1, Math.Min(count, sequence.Length - count));
        }

        private static int MaxShifts(int n, int f, int lcm, int count)
        {
            if (count == 0 || n == 0)
                return lcm;

            int max = lcm;

            for(int i = f; i <= n; i++)
                max = Math.Max(max, MaxShifts(n - i, i + 1, LCM(i, lcm), count - 1));

            return max;
        }

        private static int LCM(int a, int b)
        {
            return a * b / ArtShift.GCD(a, b);
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return ArtShift.GCD(b, a % b);
        }
    }

    [TestClass]
    public class ArtShiftTestClass
    {
        [TestMethod]
        public void ArtShiftTest()
        {
            ArtShiftTestClass.ArtShiftTest("BW", 2);
            ArtShiftTestClass.ArtShiftTest("BBBWBBB", 7);
            ArtShiftTestClass.ArtShiftTest("BWBWB", 6);
            ArtShiftTestClass.ArtShiftTest("WWWWWWWWW", 1);
            ArtShiftTestClass.ArtShiftTest("WWWWWWWWWBBWB", 60);
        }

        private static void ArtShiftTest(string sequence, int expected)
        {
            ArtShift artShift = new ArtShift();
            Assert.AreEqual(expected, artShift.maxShifts(sequence));
        }
    }
}
