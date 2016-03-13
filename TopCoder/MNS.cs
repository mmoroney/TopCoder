// https://community.topcoder.com/stat?c=problem_statement&pm=1744

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class MNS
    {
        public int combos(int[] numbers)
        {
            return MNS.combos(numbers, 0, new HashSet<int>());
        }

        private static int combos(int[] numbers, int index, HashSet<int> hashset)
        {
            if(index == numbers.Length)
            {
                int n = MNS.Encode(numbers);

                if (hashset.Contains(n))
                    return 0;

                hashset.Add(n);

                return MNS.Check(numbers) ? 1 : 0;
            }

            int combos = 0;

            for(int i = index; i < numbers.Length; i++)
            {
                MNS.Swap(numbers, i, index);
                combos += MNS.combos(numbers, index + 1, hashset);
                MNS.Swap(numbers, i, index);
            }

            return combos;
        }

        private static bool Check(int[] numbers)
        {
            int[] rowSums = new int[3];
            int[] colSums = new int[3];

            for(int i = 0; i < numbers.Length; i++)
            {
                rowSums[i / 3] += numbers[i];
                colSums[i % 3] += numbers[i];
            }

            return rowSums.All(i => i == rowSums[0]) && colSums.All(i => i == rowSums[0]);
        }

        private static int Encode(int[] numbers)
        {
            int n = 0;

            for (int i = 0; i < numbers.Length; i++)
                n = 10 * n + numbers[i];

            return n;
        }

        private static void Swap(int[] numbers, int i, int j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }

    [TestClass]
    public class MNSTestClass
    {
        [TestMethod]
        public void MNSTest()
        {
            MNSTestClass.MNSTest(new int[] { 1, 2, 3, 3, 2, 1, 2, 2, 2 }, 18);
            MNSTestClass.MNSTest(new int[] { 4, 4, 4, 4, 4, 4, 4, 4, 4 }, 1);
            MNSTestClass.MNSTest(new int[] { 1, 5, 1, 2, 5, 6, 2, 3, 2 }, 36);
            MNSTestClass.MNSTest(new int[] { 1, 2, 6, 6, 6, 4, 2, 6, 4 }, 0);
        }

        private static void MNSTest(int[] numbers, int expected)
        {
            MNS mns = new MNS();
            Assert.AreEqual(expected, mns.combos(numbers));
        }
    }
}
