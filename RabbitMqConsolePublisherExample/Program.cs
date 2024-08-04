
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://qnjazkgn:3M3LtCMl8P1lfGi8h-wm_cOp56ySrUW9@sparrow.rmq.cloudamqp.com/qnjazkgn")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.QueueDeclare("my_queue", true, false, false);

for (int i = 0; i < 50; i++)
{
    var message = $"hello world{i}";
    var messageBytes = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(string.Empty, "my_queue", null, messageBytes);
    Console.WriteLine($"Message Sent:{i}");

}
Console.ReadLine();