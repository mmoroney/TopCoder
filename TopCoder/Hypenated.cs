// https://community.topcoder.com/stat?c=problem_statement&pm=1911

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Hyphenated
    {
        public double avgLength(string[] lines)
        {
            double letterCount = 0;
            int wordCount = 0;
            bool inWord = false;

            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    char c = lines[i][j];
                    switch(c)
                    {
                        case ' ':
                        case '.':
                            inWord = false;
                            break;
                        case '-':
                            if(j == 0 || j != lines[i].Length - 1)
                                inWord = false;
                            break;
                        default:
                            if(!inWord)
                            {
                                inWord = true;
                                wordCount++;
                            }

                            letterCount++;
                            break;
                    }
                }
            }

            return letterCount / wordCount;
        }
    }

    [TestClass]
    public class HyphenatedTestClass
    {
        [TestMethod]
        public void HyphenatedTest()
        {
            HyphenatedTestClass.HyphenatedTest(new string[] { " now is the ex-", "ample. " }, 3.75);
            HyphenatedTestClass.HyphenatedTest(new string[] { " now is the ex-", " ample. " }, 3.0);
            HyphenatedTestClass.HyphenatedTest(new string[] { "inter-", "national-", "ization.." }, 20.0);
            HyphenatedTestClass.HyphenatedTest(new string[] { "All the time I have well-defined ", " trouble." }, 4.125);
            HyphenatedTestClass.HyphenatedTest(new string[] { "hello-", "-", "-", "-", "great" }, 5.0);
        }

        private static void HyphenatedTest(string[] lines, double expected)
        {
            Hyphenated hyphenated = new Hyphenated();
            Assert.AreEqual(expected, hyphenated.avgLength(lines));
        }
    }
}
