using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            var kafkaConn = "192.168.2.215:9092";
            var topic = "wl.branch.distributeline.success";

            var config = new Dictionary<string, object>
            {
                { "group.id", "wl.consumer" },
                { "bootstrap.servers", kafkaConn },
                { "enable.auto.commit", true }
            };

            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Assign(new List<TopicPartitionOffset> { new TopicPartitionOffset(topic, 0, 0) });
                consumer.Subscribe(topic);

                while (true)
                {
                    Message<Null, string> msg;
                    if (consumer.Consume(out msg,TimeSpan.FromSeconds(10)))
                    {
                        var temp = msg;
                        Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
                    }
                }
            }


            Console.Read();
        }
    }


    public static class TestClass
    {

    }
}
