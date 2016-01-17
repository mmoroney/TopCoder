// https://community.topcoder.com/stat?c=problem_statement&pm=10979

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SequenceOfCommands
    {
        public string whatHappens(string[] commands)
        {
            int[] position = new int[2];
            int[,] directions = new int[4, 2] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            int direction = 0;

            foreach(string element in commands)
            {
                foreach(char command in element)
                {
                    switch(command)
                    {
                        case 'S':
                            for (int i = 0; i < position.Length; i++)
                                position[i] += directions[direction, i];
                            break;
                        case 'R':
                            direction = (direction + 3) % 4;
                            break;
                        case 'L':
                            direction = (direction + 1) % 4;
                            break;
                    }
                }
            }

            return position.All(i => i == 0) || direction != 0 ? "bounded" : "unbounded";
        }
    }

    [TestClass]
    public class SequenceOfCommandsTestClass
    {
        [TestMethod]
        public void SequenceOfCommandsTest()
        {
            SequenceOfCommandsTestClass.SequenceOfCommandsTest(new string[] { "L" }, "bounded");
            SequenceOfCommandsTestClass.SequenceOfCommandsTest(new string[] { "SRSL" }, "unbounded");
            SequenceOfCommandsTestClass.SequenceOfCommandsTest(new string[] { "SSSS", "R" }, "bounded");
            SequenceOfCommandsTestClass.SequenceOfCommandsTest(new string[] { "SRSL", "LLSSSSSSL", "SSSSSS", "L" }, "unbounded");
        }

        private static void SequenceOfCommandsTest(string[] commands, string expected)
        {
            SequenceOfCommands SequenceOfCommands = new SequenceOfCommands();
            Assert.AreEqual(expected, SequenceOfCommands.whatHappens(commands));
        }
    }
}
