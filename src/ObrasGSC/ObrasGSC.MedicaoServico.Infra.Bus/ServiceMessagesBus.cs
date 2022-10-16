using GSCObras.MedicaoServico.Core.ServiceBus;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace GSCObras.MedicaoServico.Infra.Bus
{
    public class ServiceMessagesBus : IServiceMessagesBus, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceBusClient _client;

        public ServiceMessagesBus(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new ServiceBusClient(configuration["ServiceBus_StringConnection"]);
        }

        public async Task Send(string body, string topicName)
        {
            var sender = default(ServiceBusSender);

            try
            {
                sender = _client.CreateSender(topicName);
                await sender.SendMessageAsync(new ServiceBusMessage(body));
            }
            finally
            {
                if (sender is not null)
                {
                    await sender.DisposeAsync();
                }
            }
        }

        public async void Dispose()
        {
            await _client.DisposeAsync();
        }
    }
}