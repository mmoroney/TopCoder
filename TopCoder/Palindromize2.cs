// https://community.topcoder.com/stat?c=problem_statement&pm=7406

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Palindromize2
    {
        public string minChanges(string s)
        {
            char[] array = s.ToCharArray();

            for (int i = 0, j = array.Length - 1; i < j; i++, j--)
                array[i] = array[j] = (array[i] < array[j] ? array[i] : array[j]);

            return new string(array);
        }
    }

    [TestClass]
    public class Palindromize2TestClass
    {
        [TestMethod]
        public void Palindromize2Test()
        {
            Palindromize2TestClass.Palindromize2Test("ameba", "abeba");
            Palindromize2TestClass.Palindromize2Test("cigartragic", "cigartragic");
            Palindromize2TestClass.Palindromize2Test("abcdef", "abccba");
            Palindromize2TestClass.Palindromize2Test("cxapaxc", "cxapaxc");
        }

        private static void Palindromize2Test(string s, string expected)
        {
            Palindromize2 palindromize2 = new Palindromize2();
            Assert.AreEqual(expected, palindromize2.minChanges(s));
        }
    }
}
