// https://community.topcoder.com/stat?c=problem_statement&pm=6555

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Trainyard
    {
        private static int[] dx = new int[] { 0, 1, 0, -1 };
        private static int[] dy = new int[] { 1, 0, -1, 0 };
        private static char[] forbidden = new char[] { '-', '|' };

        public int reachableSquares(string[] layout, int fuel)
        {
            for (int x = 0; x < layout[0].Length; x++)
            {
                for (int y = 0; y < layout.Length; y++)
                {
                    if (layout[y][x] == 'S')
                        return Trainyard.Count(layout, new bool[layout[0].Length, layout.Length], x, y, fuel);
                }
            }

            return 0;
        }

        private static int Count(string[] layout, bool[,] visited, int x, int y, int fuel)
        {
            visited[x, y] = true;

            int count = 1;

            if (fuel == 0)
                return count;

            char current = layout[y][x];

            for (int i = 0; i < 4; i++)
            {
                if (Trainyard.forbidden[i % 2] == current)
                    continue;

                int newx = x + Trainyard.dx[i];
                if (newx < 0 || newx >= layout[0].Length)
                    continue;

                int newy = y + Trainyard.dy[i];
                if (newy < 0 || newy >= layout.Length)
                    continue;

                if (visited[newx, newy])
                    continue;

                char next = layout[newy][newx];

                if (next == '.' || next == Trainyard.forbidden[i % 2])
                    continue;

                count += Trainyard.Count(layout, visited, newx, newy, fuel - 1);
            }

            return count;
        }
    }

    [TestClass]
    public class TrainyardTestClass
    {
        [TestMethod]
        public void TrainyardTest()
        {
            TrainyardTestClass.TrainyardTest(new string[] { ".-....", "-S---.", "......" }, 2, 4);
            TrainyardTestClass.TrainyardTest(new string[] { "..+-+.", "..|.|.", "S-+-+." }, 10, 10);
            TrainyardTestClass.TrainyardTest(new string[] { "-....-", "|....+", "+-S++|", "|.|..|", "..+-++" }, 8, 15);
            TrainyardTestClass.TrainyardTest(new string[] { ".|...", "-+S+|", ".|..." }, 5, 6);
        }

        private static void TrainyardTest(string[] layout, int fuel, int expected)
        {
            Trainyard trainyard = new Trainyard();
            Assert.AreEqual(expected, trainyard.reachableSquares(layout, fuel));
        }
    }
}
