﻿// https://community.topcoder.com/stat?c=problem_statement&pm=4670

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ListeningIn
    {
        public string probableMatch(string typed, string phrase)
        {
            string result = string.Empty;
            int i = 0;

            foreach(char c in phrase)
            {
                if (i < typed.Length && typed[i] == c)
                    i++;
                else
                    result += c;//.Append(c);
            }

            if (i < typed.Length)
                return "UNMATCHED";

            return result;
        }
    }

    [TestClass]
    public class ListeningInTestClass
    {
        [TestMethod]
        public void ListeningInTest()
        {
            ListeningInTestClass.ListeningInTest("cptr", "capture", "aue");
            ListeningInTestClass.ListeningInTest("port to me", "teleport to me", "tele");
            ListeningInTestClass.ListeningInTest("back  to base", "back to base", "UNMATCHED");
        }

        private static void ListeningInTest(string typed, string phrase, string expected)
        {
            ListeningIn listeningIn = new ListeningIn();
            Assert.AreEqual(expected, listeningIn.probableMatch(typed, phrase));
        }
    }
}
