using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQProducer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; //where the RabbtiMqService is running
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "Test", false, false, false, null); //Creates a queue


            var message = "I am testing RabbitMQ";
            var body = Encoding.UTF8.GetBytes(message);


            Console.WriteLine("Sending message.....................");
            channel.BasicPublish("", "Test", null, body);
            Console.WriteLine("Message Sent!");
            Console.ReadLine();

        }
    }
}
