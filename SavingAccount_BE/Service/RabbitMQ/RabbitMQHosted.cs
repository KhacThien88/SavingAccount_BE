namespace SavingAccount_BE.Service.RabbitMQ
{
    public class RabbitMQHosted : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMQHosted(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var consumer = scope.ServiceProvider.GetRequiredService<RabbitMQConsumer>();
            var consumerRegistry = scope.ServiceProvider.GetRequiredService<RabbitMQConsumerSignUp>();
            await Task.WhenAll(
                consumer.StartConsuming(),
                consumerRegistry.StartConsuming()
            );
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}
