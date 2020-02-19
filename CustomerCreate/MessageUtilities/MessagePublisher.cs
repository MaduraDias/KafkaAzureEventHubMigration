using System;
using System.Net;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace MessageUtilities
{
    public class MessagePublisher
    {
        public async Task PublishAsync()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "kafka:9092",
                ClientId = Dns.GetHostName()

            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                await producer.ProduceAsync("customer", new Message<Null, string> { Value = $"Published a message at {DateTime.Now}" });
               
            }
        }
    }
}

