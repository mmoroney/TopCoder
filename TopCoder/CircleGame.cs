// https://community.topcoder.com/stat?c=problem_statement&pm=1735

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class CircleGame
    {
        public int cardsLeft(string deck)
        {
            bool[] removed = new bool[deck.Length];
            int i = 0;
            int cardsLeft = deck.Length;

            while(true)
            {
                while (i < deck.Length && removed[i])
                    i++;

                if (i == deck.Length)
                    break;

                if(deck[i] == 'K')
                {
                    removed[i] = true;
                    cardsLeft--;
                    continue;
                }

                int j = (i + 1) % deck.Length;
                while (removed[j])
                    j = (j + 1) % deck.Length;

                if (j == i)
                    break;

                if (CircleGame.Value(deck[i]) + CircleGame.Value(deck[j]) == 13)
                {
                    removed[i] = true;
                    removed[j] = true;
                    cardsLeft -= 2;
                    i = 0;
                }
                else
                    i++;
            }

            return cardsLeft;
        }

        private static int Value(char c)
        {
            return "A23456789TJQ".IndexOf(c) + 1;
        }
    }

    [TestClass]
    public class CircleGameTestClass
    {
        [TestMethod]
        public void CircleGameTest()
        {
            CircleGameTestClass.CircleGameTest("KKKKKKKKKK", 0);
            CircleGameTestClass.CircleGameTest("KKKKKAQT23", 1);
            CircleGameTestClass.CircleGameTest("KKKKATQ23J", 6);
            CircleGameTestClass.CircleGameTest("AT68482AK6875QJ5K9573Q", 4);
            CircleGameTestClass.CircleGameTest("AQK262362TKKAQ6262437892KTTJA332", 24);

        }

        private static void CircleGameTest(string deck, int expected)
        {
            CircleGame circleGame = new CircleGame();
            Assert.AreEqual(expected, circleGame.cardsLeft(deck));
        }
    }
}
