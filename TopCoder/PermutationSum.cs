// no hyperlink available

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class PermutationSum
    {
        public int add(int n)
        {
            int[] counts = new int[10];

            int digits = 0;
            int sum = 0;
            int permutations = 1;
            int multiplier = 0;

            while(n > 0)
            {
                digits++;

                int digit = n % 10;
                sum += digit;
                counts[digit]++;

                permutations = permutations * digits / counts[digit];
                multiplier = multiplier * 10 + 1;

                n /= 10;
            }

            return sum * multiplier * permutations / digits;
        }
    }

    [TestClass]
    public class PermutationSumTestClass
    {
        [TestMethod]
        public void PermutationSumTest()
        {
            PermutationSumTestClass.PermutationSumTest(157, 2886);
            PermutationSumTestClass.PermutationSumTest(313, 777);
            PermutationSumTestClass.PermutationSumTest(1234, 66660);
            PermutationSumTestClass.PermutationSumTest(5, 5);
            PermutationSumTestClass.PermutationSumTest(12345, 3999960);
            PermutationSumTestClass.PermutationSumTest(99999, 99999);
        }

        private static void PermutationSumTest(int n, int expected)
        {
            PermutationSum permutationSum = new PermutationSum();
            Assert.AreEqual(expected, permutationSum.add(n));
        }
    }
}
