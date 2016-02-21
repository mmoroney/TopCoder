// https://community.topcoder.com/stat?c=problem_statement&pm=1517

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class FryingHamburgers
    {
        public int howLong(int panSize, int hamburgers)
        {
            if (hamburgers == 0)
                return 0;

            return (((2 * hamburgers - 1) / Math.Min(panSize, hamburgers) + 1) * 5);
        }
    }

    [TestClass]
    public class FryingHamburgersTestClass
    {
        [TestMethod]
        public void FryingHamburgersTest()
        {
            FryingHamburgersTestClass.FryingHamburgersTest(2, 3, 15);
            FryingHamburgersTestClass.FryingHamburgersTest(3, 4, 15);
            FryingHamburgersTestClass.FryingHamburgersTest(3, 2, 10);
            FryingHamburgersTestClass.FryingHamburgersTest(100, 0, 0);
            FryingHamburgersTestClass.FryingHamburgersTest(303, 919, 35);
        }

        private static void FryingHamburgersTest(int panSize, int hamburgers, int expected)
        {
            FryingHamburgers fryingHamburgers = new FryingHamburgers();
            Assert.AreEqual(expected, fryingHamburgers.howLong(panSize, hamburgers));
        }
    }
}
