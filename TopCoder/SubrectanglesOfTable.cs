// https://community.topcoder.com/stat?c=problem_statement&pm=10246

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SubrectanglesOfTable
    {
        public long[] getQuantity(string[] table)
        {
            long[] quantities = new long[26];
            int width = table.Length;
            int height = table[0].Length;

            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    int count = SubrectanglesOfTable.Count(i, j, width, height)
                        + SubrectanglesOfTable.Count(i + width, j, width, height)
                        + SubrectanglesOfTable.Count(i, j + height, width, height)
                        + SubrectanglesOfTable.Count(i + width, j + height, width, height);

                    quantities[table[i][j] - 'A'] += count;
                }
            }

            return quantities;
        }

        private static int Count(int i, int j, int width, int height)
        {
            return (i + 1) * (2 * width - i) * (j + 1) * (2 * height - j);
        }
    }

    [TestClass]
    public class SubrectanglesOfTableTestClass
    {
        [TestMethod]
        public void SubrectanglesOfTableTest()
        {
            SubrectanglesOfTableTestClass.SubrectanglesOfTableTest(new string[] { "OK" },
                new long[]
                {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 40, 0, 0, 0, 40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                });

            SubrectanglesOfTableTestClass.SubrectanglesOfTableTest(new string[] { "GOOD", "LUCK" },
                new long[]
                {
                    0, 0, 320, 280, 0, 0, 280, 0, 0, 0, 280, 280, 0, 0, 640, 0, 0, 0, 0, 0, 320, 0, 0, 0, 0, 0
                });

            SubrectanglesOfTableTestClass.SubrectanglesOfTableTest(new string[] { "TANYA", "HAPPY", "BIRTH", "DAYYY" },
                new long[]
                {
                    5168, 1280, 0, 1120, 0, 0, 0, 2560, 1472, 0, 0, 0, 0, 1344, 0, 3008, 0, 1536, 0, 2592, 0, 0, 0, 0, 6320, 0
                });
        }

        private static void SubrectanglesOfTableTest(string[] table, long[] expected)
        {
            SubrectanglesOfTable subrectanglesOfTable = new SubrectanglesOfTable();
            long[] results = subrectanglesOfTable.getQuantity(table);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
