// https://community.topcoder.com/stat?c=problem_statement&pm=4504

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TopCoder
{
    public class PrintScheduler
    {
        public string getOutput(string[] threads, string[] slices)
        {
            StringBuilder sb = new StringBuilder();
            int[] counts = new int[threads.Length];

            for (int i = 0; i < slices.Length; i++)
            {
                string[] tokens = slices[i].Split(' ');
                int thread = int.Parse(tokens[0]);
                int time = int.Parse(tokens[1]);
                string s = threads[thread];

                for (int j = 0; j < time; j++)
                {
                    sb.Append(s[counts[thread] % s.Length]);
                    counts[thread]++;
                }
            }

            return sb.ToString();
        }
    }

    [TestClass]
    public class PrintSchedulerTestClass
    {
        [TestMethod]
        public void PrintSchedulerTest()
        {
            PrintSchedulerTestClass.PrintSchedulerTest(new string[] { "AB", "CD" }, new string[] { "0 1", "1 1", "0 1", "1 2" }, "ACBDC");
            PrintSchedulerTestClass.PrintSchedulerTest(new string[] { "ABCDE" }, new string[] { "0 20", "0 21" }, "ABCDEABCDEABCDEABCDEABCDEABCDEABCDEABCDEA");
            PrintSchedulerTestClass.PrintSchedulerTest(new string[] { "A", "B" }, new string[] { "1 10", "0 1", "1 10", "0 2" }, "BBBBBBBBBBABBBBBBBBBBAA");
            PrintSchedulerTestClass.PrintSchedulerTest(new string[] { "A" }, new string[] { "0 1" }, "A");
        }

        private static void PrintSchedulerTest(string[] threads, string[] slices, string expected)
        {
            PrintScheduler printScheduler = new PrintScheduler();
            Assert.AreEqual(expected, printScheduler.getOutput(threads, slices));
        }
    }
}
