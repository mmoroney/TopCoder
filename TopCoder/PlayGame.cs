// https://community.topcoder.com/stat?c=problem_statement&pm=12946

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class PlayGame
    {
        public int saveCreatures(int[] you, int[] computer)
        {
            Array.Sort(you);
            Array.Sort(computer);

            int sum = 0;

            int j = computer.Length - 1;
            for (int i = you.Length - 1; i >= 0; i--)
            {
                while (j >= 0 && you[i] <= computer[j])
                    j--;

                if (j < 0)
                    break;

                sum += you[i];
                j--;
            }

            return sum;
        }
    }

    [TestClass]
    public class PlayGameTestClass
    {
        [TestMethod]
        public void PlayGameTest()
        {
            PlayGameTestClass.PlayGameTest(new int[] { 5, 15, 100, 1, 5 }, new int[] { 5, 15, 100, 1, 5 }, 120);

            PlayGameTestClass.PlayGameTest(
                new int[]
                {
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000
                },
                new int[]
                {
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000,
                    1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000
                }, 0);

            PlayGameTestClass.PlayGameTest(new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 }, new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }, 99);

            PlayGameTestClass.PlayGameTest(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 65);

            PlayGameTestClass.PlayGameTest(
                new int[]
                {
                    651, 321, 106, 503, 227, 290, 915, 549, 660, 115,
                    491, 378, 495, 789, 507, 381, 685, 530, 603, 394,
                    7, 704, 101, 620, 859, 490, 744, 495, 379, 781,
                    550, 356, 950, 628, 177, 373, 132, 740, 946, 609,
                    29, 329, 57, 636, 132, 843, 860, 594, 718, 849
                },
                new int[]
                {
                    16, 127, 704, 614, 218, 67, 169, 621, 340, 319,
                    366, 658, 798, 803, 524, 608, 794, 896, 145, 627,
                    401, 253, 137, 851, 67, 426, 571, 302, 546, 225,
                    311, 111, 804, 135, 284, 784, 890, 786, 740, 612,
                    360, 852, 228, 859, 229, 249, 540, 979, 55, 82
                }, 25084);
        }

        private static void PlayGameTest(int[] you, int[] computer, int expected)
        {
            PlayGame playGame = new PlayGame();
            Assert.AreEqual(expected, playGame.saveCreatures(you, computer));
        }
    }
}
