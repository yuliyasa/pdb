using NUnit.Framework;
using Observers;
using Subscribers;
using System.Diagnostics;

namespace TestTask2_2
{
    public class Tests
    {

        [Test]
        public void TestCountDownWithTwoSubscribers()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Timer = new CountDown();
            var Subscriber_1 = new Subscriber(Timer);
            var Subscriber_2 = new Subscriber2(Timer);
            Timer.Timer(1000, "1 seconds left");
            sw.Stop();
            Assert.IsTrue(sw.Elapsed.TotalSeconds > 2);
            Assert.IsTrue(sw.Elapsed.TotalSeconds < 2.5);
        }

        [Test]
        public void TestCountDown()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var Timer = new CountDown();
            var Subscriber_1 = new Subscriber(Timer);
            Timer.Timer(1000, "1 seconds left");
            sw.Stop();
            Assert.IsTrue(sw.Elapsed.TotalSeconds > 1);
            Assert.IsTrue(sw.Elapsed.TotalSeconds < 1.5);
        }
    }
}