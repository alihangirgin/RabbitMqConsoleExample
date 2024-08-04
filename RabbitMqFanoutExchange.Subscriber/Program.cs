using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqps://qnjazkgn:3M3LtCMl8P1lfGi8h-wm_cOp56ySrUW9@sparrow.rmq.cloudamqp.com/qnjazkgn")
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();
channel.BasicQos(0, 1, false);
channel.ExchangeDeclare("fanout-logs", ExchangeType.Fanout, true);

// Geçici bir kuyruk oluştur
var queueName = channel.QueueDeclare().QueueName;
// Kuyruğu exchange'e bağla
channel.QueueBind(queueName, "fanout-logs", string.Empty);

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