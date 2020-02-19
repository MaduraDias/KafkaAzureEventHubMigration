using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace CustomerProfileMessageHandler
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka:9092",
                GroupId = "foo",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("customer");

            while (true)
            {
                var consumeResult = consumer.Consume();
                Console.WriteLine("consumed" + consumeResult.Message.Value ?? string.Empty);
            }
        }
    }
}
