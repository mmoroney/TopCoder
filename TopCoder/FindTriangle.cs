// https://community.topcoder.com/stat?c=problem_statement&pm=5943

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class FindTriangle
    {
        public double largestArea(string[] points)
        {
            var parsed = points.Select(s =>
            {
                string[] tokens = s.Split(' ');
                return new { Color = "RBG".IndexOf(tokens[0]), X = int.Parse(tokens[1]), Y = int.Parse(tokens[2]), Z = int.Parse(tokens[3]) };
            }).ToArray();

            int max = 0;

            for (int i = 0; i < parsed.Length; i++)
            {
                for(int j = 0; j < parsed.Length; j++)
                {
                    for(int k = 0; k < parsed.Length; k++)
                    {
                        if ((parsed[i].Color + parsed[j].Color + parsed[k].Color) % 3 != 0)
                            continue;

                        int dx1 = parsed[i].X - parsed[j].X;
                        int dy1 = parsed[i].Y - parsed[j].Y;
                        int dz1 = parsed[i].Z - parsed[j].Z;

                        int dx2 = parsed[i].X - parsed[k].X;
                        int dy2 = parsed[i].Y - parsed[k].Y;
                        int dz2 = parsed[i].Z - parsed[k].Z;

                        int cx = dy1 * dz2 - dy2 * dz1;
                        int cy = dz1 * dx2 - dz2 * dx1;
                        int cz = dx1 * dy2 - dx2 * dy1;

                        max = Math.Max(max, cx * cx + cy * cy + cz * cz);
                    }
                }
            }

            return Math.Sqrt(max) / 2.0;
        }
    }

    [TestClass]
    public class FindTriangleTestClass
    {
        [TestMethod]
        public void FindTriangleTest()
        {
            FindTriangleTestClass.FindTriangleTest(new string[] { "R 0 0 0", "R 0 4 0", "R 0 0 3", "G 92 14 7", "G 12 16 8" }, 6.0);
            FindTriangleTestClass.FindTriangleTest(new string[] { "R 0 0 0", "R 0 4 0", "R 0 0 3", "G 0 5 0", "B 0 0 12"}, 30.0);
            FindTriangleTestClass.FindTriangleTest(new string[] { "R 0 0 0", "R 0 4 0", "R 0 0 3", "R 90 0 3", "G 2 14 7", "G 2 18 7", "G 29 14 3", "B 12 16 8"}, 225.0);
            FindTriangleTestClass.FindTriangleTest(new string[] { "R 0 0 0", "R 1 1 0", "R 4 4 0", "G 10 10 10", "G 0 1 2"}, 0.0);
        }

        private static void FindTriangleTest(string[] points, double expected)
        {
            FindTriangle findTriangle = new FindTriangle();
            double result = findTriangle.largestArea(points);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
