// https://community.topcoder.com/stat?c=problem_statement&pm=10974&rd=14155

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class OnTheFarmDivTwo
    {
        public int[] animals(int heads, int legs)
        {
            if (legs % 2 != 0)
                return new int[] { };

            int cows = legs / 2 - heads;

            if(cows < 0)
                return new int[] { };

            int chickens = heads - cows;

            if(chickens < 0)
                return new int[] { };

            return new int[] { chickens, cows };
        }
    }

    [TestClass]
    public class OnTheFarmDivTwoTestClass
    {
        [TestMethod]
        public void OnTheFarmDivTwoTest()
        {
            OnTheFarmDivTwoTestClass.OnTheFarmDivTwoTest(3, 8, new int[] { 2, 1 });
            OnTheFarmDivTwoTestClass.OnTheFarmDivTwoTest(10, 40, new int[] { 0, 10 });
            OnTheFarmDivTwoTestClass.OnTheFarmDivTwoTest(10, 42, new int[] { });
            OnTheFarmDivTwoTestClass.OnTheFarmDivTwoTest(1, 3, new int[] { });
            OnTheFarmDivTwoTestClass.OnTheFarmDivTwoTest(0, 0, new int[] { 0, 0 });
        }

        private static void OnTheFarmDivTwoTest(int heads, int legs, int[] expected)
        {
            OnTheFarmDivTwo onTheFarmDivTwo = new OnTheFarmDivTwo();
            int[] results = onTheFarmDivTwo.animals(heads, legs);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
