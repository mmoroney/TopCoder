// https://community.topcoder.com/stat?c=problem_statement&pm=4830

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class AccessChanger
    {
        public string[] convert(string[] program)
        {
            string[] results = new string[program.Length];

            for (int i = 0; i < program.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                bool inComment = false;

                for (int j = 0; j < program[i].Length; j++)
                {
                    char current = program[i][j];

                    if (!inComment && current == '>' && sb.Length > 0 && sb[sb.Length - 1] == '-')
                        sb[sb.Length - 1] = '.';
                    else
                        sb.Append(current);

                    inComment |= (current == '/' && sb.Length >= 2 && sb[sb.Length - 2] == '/');
                }

                results[i] = sb.ToString();
            }

            return results;
        }
    }

    [TestClass]
    public class AccessChangerTestClass
    {
        [TestMethod]
        public void AccessChangerTest()
        {
            AccessChangerTestClass.AccessChangerTest(
                new string[]
                {
                    "Test* t = new Test();", "t->a = 1;", "t->b = 2;", "t->go(); // a=1, b=2 --> a=2, b=3"
                },
                new string[] 
                {
                    "Test* t = new Test();", "t.a = 1;", "t.b = 2;", "t.go(); // a=1, b=2 --> a=2, b=3"
                });

            AccessChangerTestClass.AccessChangerTest(
                new string[]
                {
                    "--. // the arrow --->", "---", "> // the parted arrow"
                },
                new string[]
                {
                    "--. // the arrow --->", "---", "> // the parted arrow"
                });

            AccessChangerTestClass.AccessChangerTest(
                new string[]
                {
                    "->-> // two successive arrows ->->"
                },
                new string[]
                {
                    ".. // two successive arrows ->->"
                });
        }

        private static void AccessChangerTest(string[] program, string[] expected)
        {
            AccessChanger accessChanger = new AccessChanger();
            string[] results = accessChanger.convert(program);
            Assert.AreEqual(expected.Length, results.Length);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
