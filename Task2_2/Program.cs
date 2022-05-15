using System;
using Observers;
using Subscribers;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***");
            int ms;
            Console.WriteLine("Время задержки в миллисекундах:");
            var Timer = new CountDown();
            var Subscriber_1 = new Subscriber(Timer);
            var Subscriber_2 = new Subscriber2(Timer);
            while (!int.TryParse(Console.ReadLine(), out ms))
            {
            }
            Timer.Timer(ms, $"User event after {ms}");
            Timer.Timer(1000, "3 seconds left");
            Timer.Timer(1000, "2 seconds left");
            Timer.Timer(1000, "1 seconds left");
            Timer.Timer(1000, "End");
            Console.ReadKey();
        }
    }
}
