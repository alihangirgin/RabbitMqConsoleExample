using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://qnjazkgn:3M3LtCMl8P1lfGi8h-wm_cOp56ySrUW9@sparrow.rmq.cloudamqp.com/qnjazkgn")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.ExchangeDeclare("topic_logs", ExchangeType.Topic, true);

string[] errorTypes = { "Error", "Warning", "Info" };

for (int i = 0; i < 50; i++)
{
    Random random = new Random();
    int index = random.Next(0, errorTypes.Length);

    string routingKey = $"logs.{errorTypes[index]}.Critical"; // Yönlendirme anahtarı
    var message = $"hello world{i}-{routingKey}";

    var messageBytes = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish("topic_logs", routingKey, null, messageBytes);
    Console.WriteLine($"Message Sent:{i}-{routingKey}");

}
Console.ReadLine();