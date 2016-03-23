// https://community.topcoder.com/stat?c=problem_statement&pm=10511

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TheNewHouseDivTwo
    {
        public int count(int[] x, int[] y)
        {
            int count = 0;
            for(int i = -100; i <= 100; i++)
            {
                for(int j = -100; j <= 100; j++)
                {
                    bool[] flags = new bool[4];
                    for(int k = 0; k < x.Length; k++)
                    {
                        flags[0] |= x[k] == i && y[k] > j;
                        flags[1] |= x[k] == i && y[k] < j;
                        flags[2] |= y[k] == j && x[k] > i;
                        flags[3] |= y[k] == j && x[k] < i;
                    }

                    if (flags.All(b => b))
                        count++;
                }
            }
            return count;
        }
    }

    [TestClass]
    public class TheNewHouseDivTwoTestClass
    {
        [TestMethod]
        public void TheNewHouseDivTwoTest()
        {
            TheNewHouseDivTwoTestClass.TheNewHouseDivTwoTest(
                new int[]
                {
                    -1, 1, 0, 0
                }, 
                new int[]
                {
                    0, 0, -1, 1
                }, 1);

            TheNewHouseDivTwoTestClass.TheNewHouseDivTwoTest(
                new int[]
                {
                    4, 5, 0, 8, -3, 5, 4, 7
                }, 
                new int[]
                {
                    9, -4, 2, 1, 1, 11, 0, 2
                }, 4);

            TheNewHouseDivTwoTestClass.TheNewHouseDivTwoTest(
                new int[]
                {
                    4, 4, 4
                },
                new int[]
                {
                    7, 7, 7
                }, 0);

            TheNewHouseDivTwoTestClass.TheNewHouseDivTwoTest(
                new int[]
                {
                    1, 7, 3, 4, 9, 3, 7, 1, 1, 6, 1, 6, 1, 9, 7, 9, 4, 9, 1, 4, 7, 1, 2, 5, 3, 8, 7, 7, 1
                },
                new int[]
                {
                    7, 2, 8, 9, 4, 3, 4, 1, 4, 1, 7, 8, 1, 1, 1, 4, 7, 1, 9, 4, 9, 1, 4, 1, 1, 1, 2, 4, 3
                }, 5);
        }

        private static void TheNewHouseDivTwoTest(int[] x, int[] y, int expected)
        {
            TheNewHouseDivTwo theNewHouseDivTwo = new TheNewHouseDivTwo();
            Assert.AreEqual(expected, theNewHouseDivTwo.count(x, y));
        }
    }
}
