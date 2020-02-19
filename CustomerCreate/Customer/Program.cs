using MessageUtilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var msgPublisher = new MessagePublisher();
            while (true)
            {
                await msgPublisher.PublishAsync();
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
           // Console.WriteLine("Hello World!");
        }
    }
}
