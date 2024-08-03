using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://qnjazkgn:3M3LtCMl8P1lfGi8h-wm_cOp56ySrUW9@sparrow.rmq.cloudamqp.com/qnjazkgn")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.ExchangeDeclare("direct_logs", ExchangeType.Direct, true);

string[] errorTypes = { "Critical", "Error", "Warning", "Info" };

for (int i = 0; i < 50; i++)
{
    Random random = new Random();
    int index = random.Next(0, errorTypes.Length);

    string routingKey = errorTypes[index]; // Yönlendirme anahtarı
    var message = $"hello world{i}-{routingKey}";

    var messageBytes = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish("direct_logs", routingKey, null, messageBytes);
    Console.WriteLine($"Message Sent:{i}-{routingKey}");

}
Console.ReadLine();