// https://community.topcoder.com/stat?c=problem_statement&pm=2826

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Education
    {
        public int minimize(string desire, int[] tests)
        {
            int requiredScore = (90 - 10 * (desire[0] - 'A')) * (tests.Length + 1) - tests.Sum();

            if (requiredScore > 100)
                return -1;

            return Math.Max(requiredScore, 0);
        }
    }

    [TestClass]
    public class EducationTestClass
    {
        [TestMethod]
        public void EducationTest()
        {
            EducationTestClass.EducationTest("A", new int[] { 0, 70 }, -1);
            EducationTestClass.EducationTest("D", new int[] { 100, 100, 100, 100, 100, 100 }, 0);
            EducationTestClass.EducationTest("B", new int[] { 80, 80, 80, 73 }, 87);
            EducationTestClass.EducationTest("B", new int[] { 80, 80, 80, 73, 79 }, 88);
            EducationTestClass.EducationTest("A", new int[] { 80 }, 100);
        }

        private static void EducationTest(string desire, int[] tests, int expected)
        {
            Education education = new Education();
            Assert.AreEqual(expected, education.minimize(desire, tests));
        }
    }
}
