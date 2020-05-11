using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQConsumer
{
    class Reciever
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Test", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.Span;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"New Message Recieved ! - {message}");

            };

            channel.BasicConsume("Test", true, consumer);
            Console.WriteLine("Message delivered");
            Console.ReadLine(); 
        }
    }
}
