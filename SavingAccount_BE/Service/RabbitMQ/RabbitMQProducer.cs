﻿using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SavingAccount_BE.Service.RabbitMQ
{
    public class RabbitMqProducer
    {
        private readonly ILogger<RabbitMqProducer> _logger;
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "example-queue";
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

        public async Task SendMessageAsync(string message)
        {
            try
            {
                using var channel = await _connection.CreateChannelAsync();
                await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
                var props = new BasicProperties();
                props.ContentType = "text/plain";
                props.DeliveryMode = (DeliveryModes)2;
                await channel.BasicPublishAsync(exchange: " ", routingKey: _queueName,
                    mandatory: true, basicProperties: props, body: messageBodyBytes);

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