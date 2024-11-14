using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.RabbitMQ
{
    public class RabbitMqProducer
    {
        private readonly ILogger<RabbitMqProducer> _logger;
        private readonly string _hostname = "3.107.206.208";
        private readonly string _queueName = "response-queue";
        private IConnection _connection;

        public RabbitMqProducer(ILogger<RabbitMqProducer> logger)
        {
            _logger = logger;
            InitializeConnectionAsync().Wait();
        }

        private async Task InitializeConnectionAsync()
        {
            try
            {
                var factory = new ConnectionFactory { HostName = _hostname };
                _connection = await factory.CreateConnectionAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create connection: {ex.Message}");
                throw;
            }
        }

        public async Task SendMessageAsync(MessageSendModel message)
        {
            try
            {
                using var channel = await _connection.CreateChannelAsync();
                await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message.Message);
                var props = new BasicProperties
                {
                    ContentType = "text/plain",
                    DeliveryMode = (DeliveryModes)2 // Persistent
                };

                await channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: _queueName,
                    mandatory: true,
                    basicProperties: props,
                    body: messageBodyBytes
                );

                _logger.LogInformation($"Message Sent: {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send message: {ex.Message}");
                throw;
            }
        }

    }
}
