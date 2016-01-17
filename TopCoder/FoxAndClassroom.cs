// https://community.topcoder.com/stat?c=problem_statement&pm=12811

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class FoxAndClassroom
    {
        public string ableTo(int n, int m)
        {
            return FoxAndClassroom.GCD(n, m) == 1 ? "Possible" : "Impossible";
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;

            return FoxAndClassroom.GCD(b, a % b);
        }
    }

    [TestClass]
    public class FoxAndClassroomTestClass
    {
        [TestMethod]
        public void FoxAndClassroomTest()
        {
            FoxAndClassroomTestClass.FoxAndClassroomTest(2, 3, "Possible");
            FoxAndClassroomTestClass.FoxAndClassroomTest(2, 2, "Impossible");
            FoxAndClassroomTestClass.FoxAndClassroomTest(4, 6, "Impossible");
            FoxAndClassroomTestClass.FoxAndClassroomTest(3, 6, "Impossible");
            FoxAndClassroomTestClass.FoxAndClassroomTest(5, 7, "Possible");
            FoxAndClassroomTestClass.FoxAndClassroomTest(10, 10, "Impossible");
        }

        private static void FoxAndClassroomTest(int n, int m, string expected)
        {
            FoxAndClassroom foxAndClassroom = new FoxAndClassroom();
            Assert.AreEqual(expected, foxAndClassroom.ableTo(n, m));
        }
    }
}
