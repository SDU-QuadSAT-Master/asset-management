using System;
using System.Text;
using asset_management.RabbitMQ;
using RabbitMQ.Client;

public class MessagePublisher
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;
    ConnectionService connService = new ConnectionService();


    public MessagePublisher(string queueName)
    {
        _connection = connService.GetRabbitMqConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: queueName,
                              durable: true,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
        _queueName = queueName;
    }

    public void PublishMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;
        _channel.BasicPublish(exchange: "",
                              routingKey: _queueName,
                              basicProperties: properties,
                              body: body);
        Console.WriteLine("Sent message: {0}", message);
    }

    public void Dispose()
    {
        _channel.Close();
        _connection.Close();
    }
}