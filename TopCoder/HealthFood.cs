// https://community.topcoder.com/stat?c=problem_statement&pm=3118

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class HealthFood
    {
        public int[] selectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] calories = new int[protein.Length];
            for (int i = 0; i < calories.Length; i++)
                calories[i] = 5 * protein[i] + 5 * carbs[i] + 9 * fat[i];

            int[] meals = new int[dietPlans.Length];

            for (int i = 0; i < dietPlans.Length; i++)
            {
                for (int j = 1; j < protein.Length; j++)
                {
                    if (HealthFood.IsBetterMeal(j, meals[i], dietPlans[i], protein, carbs, fat, calories))
                        meals[i] = j;
                }
            }

            return meals;
        }

        private static bool IsBetterMeal(int a, int b, string dietPlan, params int[][] information)
        {
            foreach(char c in dietPlan)
            {
                int i = "PpCcFfTt".IndexOf(c);
                int[] array = information[i / 2];

                if (array[a] != array[b])
                    return (array[a] > array[b]) == (i % 2 == 0);
            }

            return false;
        }
    }

    [TestClass]
    public class HealthFoodTestClass
    {
        [TestMethod]
        public void HealthFoodTest()
        {
            HealthFoodTestClass.HealthFoodTest(
                new int[] { 3, 4 },
                new int[] { 2, 8 },
                new int[] { 5, 2 },
                new string[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new int[] { 1, 0, 1, 0, 0, 1, 1, 0 });

            HealthFoodTestClass.HealthFoodTest(
                new int[] { 3, 4, 1, 5 },
                new int[] { 2, 8, 5, 1 },
                new int[] { 5, 2, 4, 4 },
                new string[] { "tFc", "tF", "Ftc" },
                new int[] { 3, 2, 0 });

            HealthFoodTestClass.HealthFoodTest(
                new int[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new int[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new int[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new string[] {"f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc"},
                new int[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
        }

        private static void HealthFoodTest(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            HealthFood healthFood = new HealthFood();
            int[] results = healthFood.selectMeals(protein, carbs, fat, dietPlans);
            for (int i = 0; i < results.Length; i++)
                Assert.AreEqual(expected[i], results[i]);
        }
    }
}
