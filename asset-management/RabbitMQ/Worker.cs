using asset_management.RabbitMQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace asset_management
{

       
     public class RabbitWorker : BackgroundService
{
    private readonly string[] _queueNames;
    ConnectionService connService = new ConnectionService();
    DataContext _context = new DataContext();
    MessageHandler dbAdd = new MessageHandler();

    public RabbitWorker(string[] queueNames)
    {
        _queueNames = queueNames;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var connection = connService.GetRabbitMqConnection();
        using var channel = connection.CreateModel();

        foreach (var queueName in _queueNames)
        {
            channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                HandleMessage(message, queueName);
                channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(queueName, autoAck: false, consumer);
        }

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

        private void HandleMessage(string message, string queueName)
        {
            if (queueName == "drones")
            {
                try
                {
                    Drone payload = JsonConvert.DeserializeObject<Drone>(message);
                    dbAdd.AddToDatabase(payload);
                    Console.WriteLine("Received message: " + message + " on queue " + queueName);
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
        }
            else if (queueName == "flights")
            {
                try
                {
                    FlightEntry payload = JsonConvert.DeserializeObject<FlightEntry>(message);
                    dbAdd.AddToDatabase(payload);
                    Console.WriteLine("Received message: " + message + " on queue " + queueName);
                } catch (Exception e){
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                Console.WriteLine("Unknown message type:" + message);
                return;
            }
        }
    }
} 
 
