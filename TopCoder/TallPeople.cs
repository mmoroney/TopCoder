// https://community.topcoder.com/stat?c=problem_statement&pm=2923

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class TallPeople
    {
        public int[] getPeople(string[] people)
        {
            int[][] parsed = new int[people.Length][];
            for(int i = 0; i < people.Length; i++)
                parsed[i] = people[i].Split(' ').Select(s => int.Parse(s)).ToArray();

            return new int[]
            {
                parsed.Select(a => a.Min()).Max(),
                Enumerable.Range(0, parsed[0].Length).Select(i => parsed.Select(a => a[i]).Max()).Min()
            };
        }
    }

    [TestClass]
    public class TallPeopleTestClass
    {
        [TestMethod]
        public void TallPeopleTest()
        {
            TallPeopleTestClass.TallPeopleTest(new string[] { "9 2 3", "4 8 7" }, new int[] { 4, 7 });
            TallPeopleTestClass.TallPeopleTest(new string[] { "1 2", "4 5", "3 6" }, new int[] { 4, 4 });
            TallPeopleTestClass.TallPeopleTest(new string[] { "1 1", "1 1" }, new int[] { 1, 1 });
        }

        private static void TallPeopleTest(string[] people, int[] expected)
        {
            TallPeople tallPeople = new TallPeople();
            int[] results = tallPeople.getPeople(people);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
