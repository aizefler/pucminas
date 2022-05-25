namespace ObrasGSC.MedicaoServico.Infra.Data.Comum
{
    public interface ICosmosDbSeed
    {
        Task CarregarDatabase();
    }
}
