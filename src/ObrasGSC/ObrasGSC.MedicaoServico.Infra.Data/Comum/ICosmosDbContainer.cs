using Microsoft.Azure.Cosmos;

namespace GSCObras.MedicaoServico.Infra.Data.Comum
{
    public interface ICosmosDbContainer
    {
        /// <summary>
        ///     Instance of Azure Cosmos DB Container class
        /// </summary>
        Container _container { get; }
    }
}
