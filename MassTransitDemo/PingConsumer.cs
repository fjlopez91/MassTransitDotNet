using MassTransit;

namespace MassTransitDemo
{
    public class PingConsumer(ILogger<PingConsumer> logger) : IConsumer<Ping>
    {
        private readonly ILogger<PingConsumer> _logger = logger;

        public Task Consume(ConsumeContext<Ping> context)
        {
            var button = context.Message.Button;
            _logger.LogInformation("Button pressed {Button}", button);
            return Task.CompletedTask;
        }
    }
}
