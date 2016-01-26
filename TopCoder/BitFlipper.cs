// https://community.topcoder.com/tc?module=Static&d1=help&d2=sampleProblems

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopCoder
{
    public class BitFlipper
    {
        public int minFlip(string bits)
        {
            int start = 0;
            int end = bits.Length - 1;
            char toFlip = '1';
            int flips = 0;

            while(true)
            {
                while (start <= end && bits[start] != toFlip)
                    start++;

                if (start > end)
                    break;

                while (bits[end] != toFlip)
                    end--;

                flips += end - start + 1;
                toFlip = (toFlip == '1') ? '0' : '1';
            }

            return flips;
        }
    }

    [TestClass]
    public class BitFlipperTestClass
    {
        [TestMethod]
        public void BitFlipperTest()
        {
            BitFlipperTestClass.BitFlipperTest("00110", 2);
            BitFlipperTestClass.BitFlipperTest("10110", 5);
            BitFlipperTestClass.BitFlipperTest("1001110001", 21);
            BitFlipperTestClass.BitFlipperTest("10001", 8);
            BitFlipperTestClass.BitFlipperTest("101010101", 25);
            BitFlipperTestClass.BitFlipperTest("", 0);
        }

        private static void BitFlipperTest(string bits, int expected)
        {
            BitFlipper bitFlipper = new BitFlipper();
            Assert.AreEqual(expected, bitFlipper.minFlip(bits));
        }
    }
}
