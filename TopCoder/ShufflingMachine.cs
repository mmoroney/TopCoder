// https://community.topcoder.com/stat?c=problem_statement&pm=10196

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class ShufflingMachine
    {
        public double stackDeck(int[] shuffle, int maxShuffles, int[] cardsReceived, int K)
        {
            int[] deck = new int[shuffle.Length];
            for (int i = 0; i < deck.Length; i++)
                deck[i] = i;

            int[] counts = new int[shuffle.Length];

            for(int i = 0; i < maxShuffles; i++)
            {
                int[] temp = new int[deck.Length];

                for (int j = 0; j < deck.Length; j++)
                    temp[j] = deck[shuffle[j]];

                deck = temp;

                for (int j = 0; j < cardsReceived.Length; j++)
                    counts[deck[cardsReceived[j]]]++;
            }

            Array.Sort(counts);

            double sum = 0;
            for (int i = 0; i < K; i++)
                sum += counts[counts.Length - i - 1];


            return sum / maxShuffles;
        }
    }

    [TestClass]
    public class ShufflingMachineTestClass
    {
        [TestMethod]
        public void ShufflingMachineTest()
        {
            ShufflingMachineTestClass.ShufflingMachineTest(new int[] { 1, 0 }, 3, new int[] { 0 }, 1, 0.6666666666666666);
            ShufflingMachineTestClass.ShufflingMachineTest(new int[] { 1, 2, 0 }, 5, new int[] { 0 }, 2, 0.8);
            ShufflingMachineTestClass.ShufflingMachineTest(new int[] { 1, 2, 0, 4, 3 }, 7, new int[] { 0, 3 }, 2, 1.0);
            ShufflingMachineTestClass.ShufflingMachineTest(new int[] { 0, 4, 3, 5, 2, 6, 1 }, 19, new int[] { 1, 3, 5 }, 2, 1.0526315789473684);
            ShufflingMachineTestClass.ShufflingMachineTest(new int[] { 3, 4, 7, 2, 8, 5, 6, 1, 0, 9 }, 47, new int[] { 6, 3, 5, 2, 8, 7, 4 }, 8, 6.297872340425532);
        }

        private static void ShufflingMachineTest(int[] shuffle, int maxShuffles, int[] cardsReceived, int K, double expected)
        {
            ShufflingMachine shufflingMachine = new ShufflingMachine();
            double result = shufflingMachine.stackDeck(shuffle, maxShuffles, cardsReceived, K);
            Assert.IsTrue(Math.Abs(expected - result) < 1e-9);
        }
    }
}
