// https://community.topcoder.com/stat?c=problem_statement&pm=12188

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class XorBoardDivTwo
    {
        public int theMax(string[] board)
        {
            int[] rowDiff = new int[board.Length];
            int[] colDiff = new int[board[0].Length];
            int total = 0;

            for(int i = 0; i < rowDiff.Length; i++)
            {
                for(int j = 0; j < colDiff.Length; j++)
                {
                    if(board[i][j] == '0')
                    {
                        rowDiff[i]++;
                        colDiff[j]++;
                    }
                    else
                    {
                        rowDiff[i]--;
                        colDiff[j]--;
                        total++;
                    }
                }
            }

            int maxChange = int.MinValue;

            for (int i = 0; i < rowDiff.Length; i++)
            {
                for (int j = 0; j < colDiff.Length; j++)
                {
                    int adjust = board[i][j] == '0' ? -1 : 1;
                    int rowChange = rowDiff[i] + adjust;
                    int colChange = colDiff[j] + adjust;
                    maxChange = Math.Max(maxChange, rowChange + colChange);
                }
            }

            return total + maxChange;
        }
    }

    [TestClass]
    public class XorBoardDivTwoTestClass
    {
        [TestMethod]
        public void XorBoardDivTwoTest()
        {
            XorBoardDivTwoTestClass.XorBoardDivTwoTest(new string[]
            {
                "101",
                "010",
                "101"
            }, 9);

            XorBoardDivTwoTestClass.XorBoardDivTwoTest(new string[]
            {
                "111",
                "111",
                "111"
            }, 5);

            XorBoardDivTwoTestClass.XorBoardDivTwoTest(new string[]
            {
                "0101001",
                "1101011"
            }, 9);

            XorBoardDivTwoTestClass.XorBoardDivTwoTest(new string[]
            {
                "000",
                "001",
                "010",
                "011",
                "100",
                "101",
                "110",
                "111"
            }, 15);

            XorBoardDivTwoTestClass.XorBoardDivTwoTest(new string[]
            {
                "000000000000000000000000",
                "011111100111111001111110",
                "010000000100000001000000",
                "010000000100000001000000",
                "010000000100000001000000",
                "011111100111111001111110",
                "000000100000001000000010",
                "000000100000001000000010",
                "000000100000001000000010",
                "011111100111111001111110",
                "000000000000000000000000"
            }, 105);
        }

        private static void XorBoardDivTwoTest(string[] board, int expected)
        {
            XorBoardDivTwo xorBoardDivTwo = new XorBoardDivTwo();
            Assert.AreEqual(expected, xorBoardDivTwo.theMax(board));
        }
    }
}
