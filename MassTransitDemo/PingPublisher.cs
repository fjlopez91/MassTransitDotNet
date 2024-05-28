﻿using MassTransit;

namespace MassTransitDemo
{
    public class PingPublisher(ILogger<PingPublisher> logger, IBus bus) : BackgroundService
    {
        private readonly ILogger<PingPublisher> _logger = logger;
        private readonly IBus _bus = bus;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Yield();

                var keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                {
                    //_logger.LogInformation("Pressed {Button}", keyPressed.Key.ToString());
                    await _bus.Publish(new Ping(keyPressed.Key.ToString()), stoppingToken);
                }

                await Task.Delay(200);
            }
        }
    }
}
