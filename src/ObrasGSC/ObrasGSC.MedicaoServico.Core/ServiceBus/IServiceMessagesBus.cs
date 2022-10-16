namespace GSCObras.MedicaoServico.Core.ServiceBus
{
    public interface IServiceMessagesBus
    {
        public Task Send(string body, string topicName);
        Task Send(List<NotificationItem> body, string topicName);
    }
}
