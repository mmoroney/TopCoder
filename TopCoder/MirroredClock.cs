// https://community.topcoder.com/stat?c=problem_statement&pm=8058

using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TopCoder
{
    public class MirroredClock
    {
        public string whatTimeIsIt(string time)
        {
            string[] tokens = time.Split(':');

            int hour = 11 - int.Parse(tokens[0]);
            int minute = (60 - int.Parse(tokens[1])) % 60;
            if (minute == 0)
                hour = (hour + 1) % 12;

            return string.Format("{0}:{1}", hour, minute.ToString("D2"));
        }
    }

    [TestClass]
    public class MirroredClockTestClass
    {
        [TestMethod]
        public void MirroredClockTest()
        {
            MirroredClockTestClass.MirroredClockTest("10:00", "2:00");
            MirroredClockTestClass.MirroredClockTest("1:15", "10:45");
            MirroredClockTestClass.MirroredClockTest("3:40", "8:20");
            MirroredClockTestClass.MirroredClockTest("0:00", "0:00");
            MirroredClockTestClass.MirroredClockTest("0:07", "11:53");
        }

        private static void MirroredClockTest(string time, string expected)
        {
            MirroredClock mirroredClock = new MirroredClock();
            Assert.AreEqual(expected, mirroredClock.whatTimeIsIt(time));
        }
    }
}
