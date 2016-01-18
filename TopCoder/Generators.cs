// https://community.topcoder.com/stat?c=problem_statement&pm=3043

using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Generators
    {
        public int[] find(int p)
        {
            List<int> generators = new List<int>();

            for(int i = 2; i < p; i++)
            {
                bool[] elements = new bool[p - 1];
                int n = 1;

                for (int j = 0; j < p - 1; j++)
                {
                    elements[n % p - 1] = true;
                    n = (n * i) % p;
                }

                if (elements.All(b => b))
                    generators.Add(i);
            }

            return generators.ToArray();
        }
    }

    [TestClass]
    public class GeneratorsTestClass
    {
        [TestMethod]
        public void GeneratorsTest()
        {
            GeneratorsTestClass.GeneratorsTest(3, new int[] { 2 });
            GeneratorsTestClass.GeneratorsTest(5, new int[] { 2, 3 });
            GeneratorsTestClass.GeneratorsTest(13, new int[] { 2, 6, 7, 11 });
            GeneratorsTestClass.GeneratorsTest(19, new int[] { 2, 3, 10, 13, 14, 15 });
            GeneratorsTestClass.GeneratorsTest(337, new int[]
            {
                10, 15, 19, 20, 22, 23, 29, 31, 33, 34, 44, 45, 46, 51, 53, 60, 61, 67, 68,
                70, 71, 73, 80, 83, 87, 89, 90, 93, 99, 101, 106, 109, 114, 116, 118,
                120, 124, 130, 132, 134, 139, 143, 151, 152, 154, 160, 161, 166, 171,
                176, 177, 183, 185, 186, 194, 198, 203, 205, 207, 213, 217, 219, 221,
                223, 228, 231, 236, 238, 244, 247, 248, 250, 254, 257, 264, 266, 267,
                269, 270, 276, 277, 284, 286, 291, 292, 293, 303, 304, 306, 308, 314,
                315, 317, 318, 322, 327
            });
        }

        private static void GeneratorsTest(int p, int[] expected)
        {
            Generators generators = new Generators();
            int[] results = generators.find(p);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
