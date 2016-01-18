// https://community.topcoder.com/stat?c=problem_statement&pm=12580

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class SemiPerfectSquare
    {
        public string check(int N)
        {
            for(int i = 2; i * i <= N; i++)
            {
                int square = i * i;
                if (N % square == 0 && N / square < i)
                    return "Yes";
            }

            return "No";
        }
    }

    [TestClass]
    public class SemiPerfectSquareTestClass
    {
        [TestMethod]
        public void SemiPerfectSquareTest()
        {
            SemiPerfectSquareTestClass.SemiPerfectSquareTest(48, "Yes");
            SemiPerfectSquareTestClass.SemiPerfectSquareTest(25, "Yes");
            SemiPerfectSquareTestClass.SemiPerfectSquareTest(1000, "No");
            SemiPerfectSquareTestClass.SemiPerfectSquareTest(47, "No");
            SemiPerfectSquareTestClass.SemiPerfectSquareTest(847, "Yes");
        }

        private static void SemiPerfectSquareTest(int N, string expected)
        {
            SemiPerfectSquare semiPerfectSquare = new SemiPerfectSquare();
            Assert.AreEqual(expected, semiPerfectSquare.check(N));
        }
    }
}
