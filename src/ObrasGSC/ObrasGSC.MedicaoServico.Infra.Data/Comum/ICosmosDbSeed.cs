namespace GSCObras.MedicaoServico.Infra.Data.Comum
{
    public interface ICosmosDbSeed
    {
        Task CarregarDatabase();
    }
}
