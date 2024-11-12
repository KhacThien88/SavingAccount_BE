using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System.Text;

namespace SavingAccount_BE.Service.RabbitMQ
{
    public class RabbitMQConsumer
    {
        private readonly ILogger<RabbitMQConsumer> _logger;
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "example-queue";
        private IConnection _connection;
        private IChannel _channel;

        public RabbitMQConsumer(ILogger<RabbitMQConsumer> logger)
        {
            _logger = logger;
            InitializeConnection().GetAwaiter().GetResult();
        }

        private async Task InitializeConnection()
        {
            try
            {
                var factory = new ConnectionFactory { HostName = _hostname };
                _connection = await factory.CreateConnectionAsync();
                _channel = await _connection.CreateChannelAsync();

                // Declare the queue to ensure it exists
                await _channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create connection: {ex.Message}");
                throw;
            }
        }
        public async Task StartConsuming()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"Message Received: {message}");
                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            await _channel.BasicConsumeAsync(queue: _queueName, autoAck: false, consumer: consumer);
            Console.WriteLine("Consumer started. Press [enter] to exit.");
        }
    }
}
