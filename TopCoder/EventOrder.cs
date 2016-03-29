// https://community.topcoder.com/stat?c=problem_statement&pm=11515

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class EventOrder
    {
        public int getCount(int longEvents, int instantEvents)
        {
            int eventCount = longEvents + instantEvents;
            long[,] counts = new long[eventCount + 2, 2 * (eventCount + 2)];

            if (longEvents == 0)
                counts[1, 1] = 1;
            else
                counts[1, 2] = 1;

            for (int i = 1; i < eventCount; i++)
            {
                for (int j = 1; j <= 2 * i; j++)
                {
                    if(i < longEvents)
                    {
                        counts[i + 1, j] = EventOrder.Add(counts[i + 1, j], (long)counts[i, j] * j * (j - 1) / 2);
                        counts[i + 1, j + 1] = EventOrder.Add(counts[i + 1, j + 1], counts[i, j] * (j + 1) * j);
                        counts[i + 1, j + 2] = EventOrder.Add(counts[i + 1, j + 2], counts[i, j] * (j + 2) * (j + 1) / 2);
                    }
                    else
                    {
                        counts[i + 1, j] = EventOrder.Add(counts[i + 1, j], counts[i, j] * j);
                        counts[i + 1, j + 1] = EventOrder.Add(counts[i + 1, j + 1], counts[i, j] * (j + 1));
                    }
                }
            }

            int result = 0;

            for (int j = 1; j <= 2 * longEvents + instantEvents; j++)
                result = EventOrder.Add(result, counts[eventCount, j]);

            return result;
        }

        private static int Add(long a, long b)
        {
            return (int)((a + b) % 1000000009);
        }
    }

    [TestClass]
    public class EventOrderTestClass
    {
        [TestMethod]
        public void EventOrderTest()
        {
            EventOrderTestClass.EventOrderTest(0, 2, 3);
            EventOrderTestClass.EventOrderTest(1, 1, 5);
            EventOrderTestClass.EventOrderTest(2, 0, 13);
            EventOrderTestClass.EventOrderTest(0, 4, 75);
        }

        private static void EventOrderTest(int longEvents, int instantEvents, int expected)
        {
            EventOrder eventOrder = new EventOrder();
            Assert.AreEqual(expected, eventOrder.getCount(longEvents, instantEvents));
        }
    }
}
