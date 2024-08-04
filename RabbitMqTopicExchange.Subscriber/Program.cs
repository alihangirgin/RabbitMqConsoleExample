using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://qnjazkgn:3M3LtCMl8P1lfGi8h-wm_cOp56ySrUW9@sparrow.rmq.cloudamqp.com/qnjazkgn")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.ExchangeDeclare("topic_logs", ExchangeType.Topic, true);
channel.BasicQos(0, 1, false);

// Geçici bir kuyruk oluşturuyoruz
var queueName = channel.QueueDeclare().QueueName;
// Tüketicinin ilgilendiği desenler
string[] bindingKeys = { "logs.*.Critical" };

foreach (var bindingKey in bindingKeys)
{
    // Kuyruğu exchange'e ve desenine göre bağla
    channel.QueueBind(queueName, "topic_logs", bindingKey);
}

var consumer = new EventingBasicConsumer(channel);

Console.WriteLine("Waiting for messages.");

consumer.Received += (sender, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Message received:{message}");
    channel?.BasicAck(eventArgs.DeliveryTag, false);
    Thread.Sleep(1500);
};

channel.BasicConsume(queueName, false, consumer);

Console.ReadLine();