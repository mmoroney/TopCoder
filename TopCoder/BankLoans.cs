// https://community.topcoder.com/stat?c=problem_statement&pm=9929

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BankLoans
    {
        public double expectedProfit(string[] loans, string[] riskClasses)
        {
            var parsedRiskClasses = riskClasses.Select(s =>
            {
                string[] tokens = s.Split(' ');
                return new { Class = tokens[0], Prob = int.Parse(tokens[1]) / 100.0 };
            });

            var parsedLoans = loans.Select(s =>
            {
                string[] tokens = s.Split(' ');
                double prob = parsedRiskClasses.First(t => t.Class == tokens[2]).Prob;
                return new { Amount = int.Parse(tokens[0]), Interest = int.Parse(tokens[1]), Prob = prob };
            });

            return parsedLoans.Sum(s => (1.0 - s.Prob) * s.Interest - s.Prob * s.Amount);
        }

        [TestClass]
        public class BankLoansTestClass
        {
            [TestMethod]
            public void ArithmeticProgressionTest()
            {
                BankLoansTestClass.BankLoansTest(
                    new string[] { "1000 100 a", "500 80 b", "600 120 c" },
                    new string[] { "a 0", "b 5", "c 10" },
                    199.0);

                BankLoansTestClass.BankLoansTest(
                    new string[] { "1000 150 beta", "1500 200 beta", "2000 250 beta" },
                    new string[] { "alpha 0", "beta 10", "gamma 20" },
                    90.0);

                BankLoansTestClass.BankLoansTest(
                    new string[] { "1000 400 hopeless", "1000 400 bad", "1000 400 weak" },
                    new string[] { "weak 50", "bad 75", "hopeless 100" },
                    -1950.0);

                BankLoansTestClass.BankLoansTest(
                    new string[] { "500 55 ok", "1500 170 fine" },
                    new string[] { "ok 10", "fine 10" },
                    2.5);

                BankLoansTestClass.BankLoansTest(
                    new string[]
                    {
                        "8132 19387 s",
                        "20219 1791 iarkhyvewuqo",
                        "19219 4464 s",
                        "6947 18098 s",
                        "28985 7338 iarkhyvewuqo",
                        "21878 7894 iarkhyvewuqo",
                        "21495 8307 s"
                    },
                    new string[]
                    {
                        "s 13", "iarkhyvewuqo 16"
                    },
                    39395.83);
            }

            private static void BankLoansTest(string[] loans, string[] riskClasses, double expected)
            {
                BankLoans bankLoans = new BankLoans();
                double result = bankLoans.expectedProfit(loans, riskClasses);
                Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
            }
        }
    }
}
