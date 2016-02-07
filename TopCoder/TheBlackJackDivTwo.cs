// https://community.topcoder.com/stat?c=problem_statement&pm=10616

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TheBlackJackDivTwo
    {
        public int score(string[] cards)
        {
            return cards.Sum(s =>
            {
                int i = "23456789TJQKA".IndexOf(s[0]);
                if (i < 8)
                    return i + 2;
                if (i <= 11)
                    return 10;
                return 11;
            });
        }
    }

    [TestClass]
    public class TheBlackJackDivTwoTestClass
    {
        [TestMethod]
        public void TheBlackJackDivTwoTest()
        {
            TheBlackJackDivTwoTestClass.TheBlackJackDivTwoTest(new string[] { "4S", "7D" }, 11);
            TheBlackJackDivTwoTestClass.TheBlackJackDivTwoTest(new string[] { "KS", "TS", "QC" }, 30);
            TheBlackJackDivTwoTestClass.TheBlackJackDivTwoTest(new string[] { "AS", "AD", "AH", "AC" }, 44);
            TheBlackJackDivTwoTestClass.TheBlackJackDivTwoTest(new string[] { "3S", "KC", "AS", "7C", "TC", "9C", "4H", "4S", "2S" }, 60);
        }

        private static void TheBlackJackDivTwoTest(string[] cards, int expected)
        {
            TheBlackJackDivTwo theBlackJackDivTwo = new TheBlackJackDivTwo();
            Assert.AreEqual(expected, theBlackJackDivTwo.score(cards));
        }
    }
}
