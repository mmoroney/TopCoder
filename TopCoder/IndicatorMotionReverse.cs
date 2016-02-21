// https://community.topcoder.com/stat?c=problem_statement&pm=6172

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class IndicatorMotionReverse
    {
        public string getMinProgram(string[] actions)
        {
            const int maxLength = 100;
            const string ellipsis = "...";

            StringBuilder sb = new StringBuilder();
            foreach (string action in actions)
                sb.Append(action);

            StringBuilder program = new StringBuilder();
            int i = 1;

            while (i < sb.Length && program.Length <= maxLength)
            {
                char command = IndicatorMotionReverse.GetCommand(sb[i - 1], sb[i]);
                int j = i + 1;

                while (j < sb.Length && IndicatorMotionReverse.GetCommand(sb[j - 1], sb[j]) == command)
                    j++;

                int count = j - i;

                program.Append(command);
                program.Append((count % 99).ToString("D02"));

                for(int k = 0; k < count / 99; k++)
                {
                    program.Append(command);
                    program.Append("99");
                }

                i = j;
            }

            string result = program.ToString();
            if(result.Length > maxLength)
                return result.Substring(0, maxLength - ellipsis.Length) + ellipsis;

            return result;
        }

        private static char GetCommand(char initial, char final)
        {
            const string states = "-/|\\";
            return "SLFR"[(states.IndexOf(final) - states.IndexOf(initial) + states.Length) % states.Length];
        }
    }

    [TestClass]
    public class IndicatorMotionReverseTestClass
    {
        [TestMethod]
        public void IndicatorMotionReverseTest()
        {
            IndicatorMotionReverseTestClass.IndicatorMotionReverseTest(
                new string[]
                {
                    "-|-|/-/|//////-/"
                },
                "F03R02L02R01S05R01L01");

            IndicatorMotionReverseTestClass.IndicatorMotionReverseTest(
                new string[] 
                {
                    "\\"
                },
                "");

            IndicatorMotionReverseTestClass.IndicatorMotionReverseTest(
                new string[]
                {
                    "||||||||||||||||||||||||||||||||||||||||||||||||||",
                    "||||||||||||||||||||||||||||||||||||||||||||||||||",
                    "||||||||||||||||||||||||||||||||||||||||||||||||||"
                },
                "S50S99");

                IndicatorMotionReverseTestClass.IndicatorMotionReverseTest(
                new string[]
                {
                    "\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\",
                    "-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\-\\"
                },
                "L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L01R01L...");
        }

        private static void IndicatorMotionReverseTest(string[] actions, string expected)
        {
            IndicatorMotionReverse indicatorMotionReverse = new IndicatorMotionReverse();
            Assert.AreEqual(expected, indicatorMotionReverse.getMinProgram(actions));
        }
    }
}
