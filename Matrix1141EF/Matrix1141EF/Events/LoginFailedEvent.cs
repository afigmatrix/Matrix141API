using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Matrix1141EF.Events
{
    public class LoginFailedEvent
    {
        private readonly ILogger<LoginFailedEvent> _logger;

        public LoginFailedEvent(ILogger<LoginFailedEvent> logger)
        {
            _logger = logger;
        }

        public object Username { get; internal set; }
        public object Timestamp { get; internal set; }

        public async Task PublishAsync<TEvent>(TEvent eventData)
        {
            _logger.LogInformation($"Event published: {eventData.GetType().Name}, Data: {eventData}");

            await Task.CompletedTask;
        }
    }
}
