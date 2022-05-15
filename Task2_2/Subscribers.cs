using Observers;
using System;
using System.Threading;

namespace Subscribers
{
    public class Subscriber
    {
        public Subscriber(CountDown x)
        {
            x.CountDownEvent += (sender, args) => { Display(args.Ms, args.Message); };
        }
        private void Display(int ms, string eventText)
        {
            if (eventText == null)
            {
                throw new ArgumentNullException("message argument is null");
            }
            Thread.Sleep(ms);
            Console.WriteLine("Подписчик({0}): Сообщение", eventText);
        }
    }

    public class Subscriber2
    {
        public Subscriber2(CountDown cd)
        {
            cd.CountDownEvent += (sender, args) => { Display(args.Ms, args.Message); };
        }
        private void Display(int ms, string eventText)
        {
            if (eventText == null)
            {
                throw new ArgumentNullException("message argument is null");
            }
            Thread.Sleep(ms);
            Console.WriteLine("~~Подписчик2({0}): Сообщение", eventText);
        }
    }
}