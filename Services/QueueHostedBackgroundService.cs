namespace RabbitApi.Services
{
    public class QueueHostedBackgroundService : BackgroundService
    {
        private readonly IConsumeService _consumeService;

        public QueueHostedBackgroundService(IConsumeService consumeService)
        {
            _consumeService = consumeService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumeService.ReadMessages();
        }
    }
}
