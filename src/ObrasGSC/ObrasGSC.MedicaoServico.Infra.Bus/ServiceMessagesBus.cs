using GSCObras.MedicaoServico.Core.ServiceBus;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

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

        public async Task Send(List<NotificationItem> body, string topicName)
        {
            var sender = default(ServiceBusSender);

            try
            {
                sender = _client.CreateSender(topicName);

                using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

                foreach (var item in body)
                {
                    if (!messageBatch.TryAddMessage(new ServiceBusMessage(JsonSerializer.Serialize(item))))
                    {
                        throw new Exception($"The message is too large to fit in the batch.");
                    }
                }

                await sender.SendMessagesAsync(messageBatch);
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