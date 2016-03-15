// https://community.topcoder.com/stat?c=problem_statement&pm=4516

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Popularity
    {
        public string[] sort(string[] reply)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach(string name in reply)
            {
                string firstName = Popularity.GetFirstName(name);

                if(dictionary.ContainsKey(firstName))
                    dictionary[firstName]++;
                else
                    dictionary[firstName] = 1;
            }

            int[] a = new int[reply.Length];
            for (int i = 0; i < reply.Length; i++)
                a[i] = i;

            Array.Sort(a, (x, y) =>
            {
                int z = Popularity.GetCount(reply[y], dictionary).CompareTo(Popularity.GetCount(reply[x], dictionary));
                return z == 0 ? x.CompareTo(y) : z;
            });

            string[] results = new string[reply.Length];
            for(int i = 0; i < results.Length; i++)
                results[i] = reply[a[i]];

            return results;
        }

        private static int GetCount(string firstName, Dictionary<string, int> dictionary)
        {
            return dictionary[Popularity.GetFirstName(firstName)];
        }

        private static string GetFirstName(string fullName)
        {
            return fullName.Substring(0, fullName.IndexOf(' '));
        }
    }

    [TestClass]
    public class PopularityTestClass
    {
        [TestMethod]
        public void PopularityTest()
        {
            PopularityTestClass.PopularityTest(
                new string[]
                {
                    "DON XI", "EAGER TOPLEASE", "BJ SMITH", "BJ JONES", "BJ BJ", "DON SMITH", "EAGER SMITH"
                },
                new string[]
                {
                    "BJ SMITH", "BJ JONES", "BJ BJ", "DON XI", "EAGER TOPLEASE", "DON SMITH", "EAGER SMITH"
                });

            PopularityTestClass.PopularityTest(
                new string[]
                {
                    "BOB JONES", "BOB ADAMS", "BOBBY ADAMS", "BOB ADAMS"
                },
                new string[]
                {
                    "BOB JONES", "BOB ADAMS", "BOB ADAMS", "BOBBY ADAMS"
                });

            PopularityTestClass.PopularityTest(
                new string[]
                {
                    "FRED EVANS", "AL BAKER", "CAL ADAMS", "ED FARMER", "AL ADAMS", "CAL DETROIT"
                },
                new string[]
                {
                    "AL BAKER", "CAL ADAMS", "AL ADAMS", "CAL DETROIT", "FRED EVANS", "ED FARMER"
                });
        }

        private static void PopularityTest(string[] reply, string[] expected)
        {
            Popularity popularity = new Popularity();
            string[] results = popularity.sort(reply);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
