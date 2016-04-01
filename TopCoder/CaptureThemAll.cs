// https://community.topcoder.com/stat?c=problem_statement&pm=2915

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class CaptureThemAll
    {
        private const int Size = 8;

        public int fastKnight(string knight, string rook, string queen)
        {
            Pair knightPair = CaptureThemAll.MakePair(knight);
            Pair rookPair = CaptureThemAll.MakePair(rook);
            Pair queenPair = CaptureThemAll.MakePair(queen);

            int[] steps = new int[] { -2, -1, 2, -1, -2, 1, 2, 1, -2 };

            int knightToRook = CaptureThemAll.GetShortestPath(knightPair, rookPair, steps);
            int knightToQueen = CaptureThemAll.GetShortestPath(knightPair, queenPair, steps);
            int rookToQueen = CaptureThemAll.GetShortestPath(rookPair, queenPair, steps);

            return Math.Min(knightToRook, knightToQueen) + rookToQueen;
        }

        private class Pair
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private static Pair MakePair(string s)
        {
            return new Pair { X = s[0] - 'a', Y = s[1] - '1' };
        }

        private static int GetShortestPath(Pair from, Pair to, int[] steps)
        {
            int[,] depths = new int[CaptureThemAll.Size, CaptureThemAll.Size];

            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                Pair current = queue.Dequeue();

                if (current.X == to.X && current.Y == to.Y)
                    return depths[current.X, current.Y];

                for(int i = 0; i < steps.Length - 1; i++)
                {
                    int x = current.X + steps[i];
                    int y = current.Y + steps[i + 1];

                    if (x < 0 || x >= CaptureThemAll.Size || y < 0 || y >= CaptureThemAll.Size)
                        continue;

                    if (depths[x, y] > 0)
                        continue;

                    depths[x, y] = depths[current.X, current.Y] + 1;
                    queue.Enqueue(new Pair { X = x, Y = y });
                }
            }

            return int.MaxValue;
        }
    }

    [TestClass]
    public class CaptureThemAllTestClass
    {
        [TestMethod]
        public void CaptureThemAllTest()
        {
            CaptureThemAllTestClass.CaptureThemAllTest("a1", "b3", "c5", 2);
            CaptureThemAllTestClass.CaptureThemAllTest("b1", "c3", "a3", 3);
            CaptureThemAllTestClass.CaptureThemAllTest("a1", "a2", "b2", 6);
            CaptureThemAllTestClass.CaptureThemAllTest("a5", "b7", "e4", 3);
            CaptureThemAllTestClass.CaptureThemAllTest("h8", "e2", "d2", 6);
        }

        private static void CaptureThemAllTest(string knight, string rook, string queen, int expected)
        {
            CaptureThemAll captureThemAll = new CaptureThemAll();
            Assert.AreEqual(expected, captureThemAll.fastKnight(knight, rook, queen));
        }
    }
}
