// https://community.topcoder.com/stat?c=problem_statement&pm=10966

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class KnightCircuit
    {
        public long maxSize(int w, int h, int a, int b)
        {
            int gcd = KnightCircuit.GCD(a, b);
            a /= gcd;
            b /= gcd;
            w = 1 + (w - 1) / gcd;
            h = 1 + (h - 1) / gcd;

            if (w <= 20 || h <= 20)
            {
                int[] dx = new int[] { -b, -b, -a, -a, a, a, b, b };
                int[] dy = new int[] { -a, a, -b, b, -b, b, -a, a };
                bool[,] visited = new bool[w, h];
                int max = 0;

                for(int x = 0; x < w; x++)
                {
                    for(int y = 0; y < h; y++)
                        max = Math.Max(max, KnightCircuit.Search(visited, x, y, dx, dy));
                }

                return max;
            }

            long count = (long)w * h;

            if ((a + b) % 2 == 1)
                return count;

            return count / 2 + 1;
        }

        private static int Search(bool[,] visited, int x, int y, int[] dx, int[] dy)
        {
            if (x < 0 || y < 0 || x >= visited.GetLength(0) || y >= visited.GetLength(1))
                return 0;

            if (visited[x, y])
                return 0;

            visited[x, y] = true;
            int count = 1;

            for(int i = 0; i < dx.Length; i++)
                count += KnightCircuit.Search(visited, x + dx[i], y + dy[i], dx, dy);

            return count;
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return KnightCircuit.GCD(b, a % b);
        }
    }

    [TestClass]
    public class KnightCircuitTestClass
    {
        [TestMethod]
        public void KnightCircuitTest()
        {
            KnightCircuitTestClass.KnightCircuitTest(1, 1, 2, 1, 1);
            KnightCircuitTestClass.KnightCircuitTest(3, 20, 1, 3, 11);
            KnightCircuitTestClass.KnightCircuitTest(100000, 100000, 1, 2, 10000000000);
            KnightCircuitTestClass.KnightCircuitTest(3, 3, 1, 2, 8);
            KnightCircuitTestClass.KnightCircuitTest(30, 30, 8, 4, 64);
            KnightCircuitTestClass.KnightCircuitTest(32, 34, 6, 2, 136);
        }

        private static void KnightCircuitTest(int w, int h, int a, int b, long expected)
        {
            KnightCircuit knightCircuit = new KnightCircuit();
            Assert.AreEqual(expected, knightCircuit.maxSize(w, h, a, b));
        }
    }
}
