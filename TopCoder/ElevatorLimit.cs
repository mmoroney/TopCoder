// https://community.topcoder.com/stat?c=problem_statement&pm=1965

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ElevatorLimit
    {
        public int[] getRange(int[] enter, int[] exit, int physicalLimit)
        {
            int min = 0;
            int max = 0;
            int current = 0;

            for(int i = 0; i < enter.Length; i++)
            {
                current -= exit[i];
                if (current < min)
                    min = current;

                current += enter[i];
                if (current > max)
                    max = current;

                if (max - min > physicalLimit)
                    return new int[] { };
            }

            return new int[] { -min, physicalLimit - max};
        }
    }

    [TestClass]
    public class ElevatorLimitTestClass
    {
        [TestMethod]
        public void ElevatorLimitTest()
        {
            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                1,
                new int[] { 0, 0 });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                2,
                new int[] { 0, 1 });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                1,
                new int[] { 1, 1 });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 0, 2 },
                new int[] { 1, 0 },
                1,
                new int[] { });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 6, 85, 106, 1, 199, 76, 162, 141 },
                new int[] { 38, 68, 62, 83, 170, 12, 61, 114 },
                668,
                new int[] { 223, 500 });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 179, 135, 104, 90, 97, 186, 187, 47, 152, 100, 119, 28, 193, 11, 103, 100, 179, 11, 80, 163, 50, 131, 103, 50, 142, 51, 112, 62, 69, 72, 88, 3, 162, 93, 190, 85, 79, 86, 146, 71, 65, 131, 179, 119, 66, 111 },
                new int[] { 134, 81, 178, 168, 86, 128, 1, 165, 62, 46, 188, 70, 104, 111, 3, 47, 144, 69, 163, 21, 101, 126, 169, 84, 146, 165, 198, 1, 65, 181, 135, 99, 100, 195, 171, 47, 16, 54, 79, 69, 6, 97, 154, 80, 151, 76 },
                954,
                new int[] { 453, 659 });

            ElevatorLimitTestClass.ElevatorLimitTest(
                new int[] { 2 }, 
                new int[] { 3 },
                2,
                new int[] { });
        }

        private static void ElevatorLimitTest(int[] enter, int[] exit, int physicalLimit, int[] expected)
        {
            ElevatorLimit elevatorLimit = new ElevatorLimit();
            int[] results = elevatorLimit.getRange(enter, exit, physicalLimit);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
