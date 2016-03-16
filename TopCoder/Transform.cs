// http://community.topcoder.com/tc?module=Static&d1=help&d2=sampleProblems

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class Transform
    {
        public int palindrome(int N)
        {
            while(N < 1000000000)
            {
                int r = Transform.Reverse(N);

                if (r == N)
                    return r;

                N += r;
            }

            return -1;
        }

        private static int Reverse(int n)
        {
            int r = 0;
            while(n > 0)
            {
                r = 10 * r + n % 10;
                n /= 10;
            }

            return r;
        }
    }

    [TestClass]
    public class TransformTestClass
    {
        [TestMethod]
        public void TransformTest()
        {
            TransformTestClass.TransformTest(28, 121);
            TransformTestClass.TransformTest(51, 66);
            TransformTestClass.TransformTest(11, 11);
            TransformTestClass.TransformTest(607, 4444);
            TransformTestClass.TransformTest(196, -1);
        }

        private static void TransformTest(int N, int expected)
        {
            Transform transform = new Transform();
            Assert.AreEqual(expected, transform.palindrome(N));
        }
    }
}
