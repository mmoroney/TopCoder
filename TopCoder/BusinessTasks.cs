// https://community.topcoder.com/stat?c=problem_statement&pm=1585

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BusinessTasks
    {
        public string getTask(string[] list, int n)
        {
            List<string> tasks = new List<string>();
            foreach (string task in list)
                tasks.Add(task);

            int index = 0;

            while(tasks.Count > 1)
            {
                index = (index + n - 1) % (tasks.Count);
                tasks.RemoveAt(index);
            }

            return tasks[0];
        }
    }

    [TestClass]
    public class BusinessTasksTestClass
    {
        [TestMethod]
        public void BusinessTasksTest()
        {
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "a", "b", "c", "d" }, 2, "a");
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "a", "b", "c", "d", "e" }, 3, "d");
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "alpha", "beta", "gamma", "delta", "epsilon" }, 1, "epsilon");
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "a", "b" }, 1000, "a");
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" }, 17, "n");
            BusinessTasksTestClass.BusinessTasksTest(new string[] { "zlqamum", "yjsrpybmq", "tjllfea", "fxjqzznvg", "nvhekxr", "am", "skmazcey", "piklp", "olcqvhg", "dnpo", "bhcfc", "y", "h", "fj", "bjeoaxglt", "oafduixsz", "kmtbaxu", "qgcxjbfx", "my", "mlhy", "bt", "bo", "q" }, 9000000, "fxjqzznvg");
        }

        private static void BusinessTasksTest(string[] list, int n, string expected)
        {
            BusinessTasks businessTasks = new BusinessTasks();
            Assert.AreEqual(expected, businessTasks.getTask(list, n));
        }
    }
}
