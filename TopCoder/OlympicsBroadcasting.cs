// https://community.topcoder.com/stat?c=problem_statement&pm=6461

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class OlympicsBroadcasting
    {
        public int getMaxChannels(int[] from, int[] to, int totalUnits)
        {
            SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();

            for(int i = 0; i < from.Length; i++)
            {
                int n = 0;
                dictionary.TryGetValue(from[i], out n);
                dictionary[from[i]] = n + 1;

                n = 0;
                dictionary.TryGetValue(to[i], out n);
                dictionary[to[i]] = n - 1;
            }

            if (dictionary[0] == 0)
                return 0;

            int height = 0;
            int channels = int.MaxValue;

            foreach(KeyValuePair<int, int> pair in dictionary)
            {
                if(pair.Key < totalUnits)
                {
                    height += pair.Value;
                    channels = Math.Min(channels, height);
                }
            }

            return channels;
        }
    }

    [TestClass]
    public class OlympicsBroadcastingTestClass
    {
        [TestMethod]
        public void OlympicsBroadcastingTest()
        {
            OlympicsBroadcastingTestClass.OlympicsBroadcastingTest(new int[] { 0, 1, 1, 1, 0 }, new int[] { 2, 2, 3, 3, 3 }, 3, 2);
            OlympicsBroadcastingTestClass.OlympicsBroadcastingTest(new int[] { 0 }, new int[] { 1000 }, 1000, 1);
            OlympicsBroadcastingTestClass.OlympicsBroadcastingTest(new int[] { 0, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 }, 5, 1);
            OlympicsBroadcastingTestClass.OlympicsBroadcastingTest(new int[] { 0, 4, 8 }, new int[] { 1, 9, 12 }, 12, 0);
        }

        private static void OlympicsBroadcastingTest(int[] from, int[] to, int totalUnits, int expected)
        {
            OlympicsBroadcasting olympicsBroadcasting = new OlympicsBroadcasting();
            Assert.AreEqual(expected, olympicsBroadcasting.getMaxChannels(from, to, totalUnits));
        }
    }
}
