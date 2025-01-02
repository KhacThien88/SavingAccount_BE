using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using SavingAccount_BE.Model;
using SavingAccount_BE.Service.Accounts;
using System.Text.Json;
using System.Text;

namespace SavingAccount_BE.Service.RabbitMQ
{
    public class RabbitMQConsumerSignUp
    {
        private readonly RabbitMqProducer _producer;
        private readonly IAccountService _accountService;
        private readonly ILogger<RabbitMQConsumer> _logger;
        private readonly string _hostname = "3.107.206.208";
        private readonly string _queueName = "signup-queue";
        private IConnection _connection;
        private IChannel _channel;

        public RabbitMQConsumerSignUp(ILogger<RabbitMQConsumer> logger, IAccountService accountService, RabbitMqProducer producer)
        {
            _producer = producer;
            _accountService = accountService;
            _logger = logger;
            InitializeConnection().GetAwaiter().GetResult();
            StartConsuming().GetAwaiter().GetResult();
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
        private async Task<string> AuthenticateViaSignUpEndpoint(SignUpModel loginRequest)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.devkhacthien.somee.com");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContent = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/Account/SignUp", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }

            _logger.LogWarning($"Failed to register user {loginRequest.Email}");
            return string.Empty;
        }

        public async Task StartConsuming()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var loginRequest = JsonSerializer.Deserialize<SignUpModel>(message);

                _logger.LogInformation($"Received login request: {JsonSerializer.Serialize(loginRequest)}");

                var result = await AuthenticateViaSignUpEndpoint(loginRequest);
                var responseMessage = string.IsNullOrEmpty(result)
                        ? new MessageSendModel { Message = "Invalid credentials" }
                        : new MessageSendModel { Message = result };
                await _producer.SendMessageAsync(responseMessage);

                _logger.LogInformation($"Response message to send: {JsonSerializer.Serialize(responseMessage)}");

                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                _logger.LogInformation($"Send successfully");
            };

            await _channel.BasicConsumeAsync(queue: _queueName, autoAck: false, consumer: consumer);
            Console.WriteLine("Consumer started. Press [enter] to exit.");
        }
    }
}
