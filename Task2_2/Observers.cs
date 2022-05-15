using System.Threading;

namespace Observers
{
    public delegate void Timer(CountDown sender, CountDownEventArgs args);
    public class CountDown 
    {
        public event Timer CountDownEvent;     
        public void Timer(int ms, string message)
        {
            CountDownEvent(this, new CountDownEventArgs(ms, message));
        }
    }
    public class CountDownEventArgs
    {
        public string Message { get; }
        public int Ms { get; }
        public CountDownEventArgs(int ms, string message)
        {
            Message = message;
            Ms = ms;
        }
    }
}