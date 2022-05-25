using Microsoft.Azure.Cosmos;
using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public abstract class RepositorioBase<T> : IContainerContext<T>, IRepositorioBase<T> where T : EntidadeBase
    {

        public abstract string ContainerName { get; }

        protected readonly Container _container;
        private readonly ICosmosDbContainerFactory _cosmosDbContainerFactory;

        public RepositorioBase(ICosmosDbContainerFactory cosmosDbContainerFactory)
        {
            this._cosmosDbContainerFactory = cosmosDbContainerFactory ?? throw new ArgumentNullException(nameof(ICosmosDbContainerFactory));
            this._container = this._cosmosDbContainerFactory.GetContainer(ContainerName)._container;
        }

        public async Task<bool> ExisteAsync(string id)
        {
            var existe = false;
            try
            {
                await this.ObterAsync(id);
                existe = true;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound) { }
            return existe;
        }

        public Task AdicionarAsync(T item)
        {
             return _container.CreateItemAsync(item, new PartitionKey(item.Id));
        }

        public Task ModificarAsync(string id, T item)
        {
            return _container.UpsertItemAsync(item, new PartitionKey(id));
        }

        public Task RemoverAsync(string id)
        {
            return _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        protected async Task<IEnumerable<T>> ConsultarAsync(QueryDefinition queryString)
        {
            var query = _container.GetItemQueryIterator<T>(queryString);

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<T> ObterAsync(string id)
        {
            var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
            return response.Resource;
        }
    }
}
