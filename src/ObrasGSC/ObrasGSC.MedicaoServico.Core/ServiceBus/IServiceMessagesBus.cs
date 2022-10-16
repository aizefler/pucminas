namespace GSCObras.MedicaoServico.Core.ServiceBus
{
    public interface IServiceMessagesBus
    {
        public Task Send(string body, string topicName);
    }
}
