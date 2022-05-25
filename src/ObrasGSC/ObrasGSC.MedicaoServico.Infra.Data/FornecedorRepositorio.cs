using ObrasGSC.MedicaoServico.Core.Entidades;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Infra.Data
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>, IFornecedorRepositorio
    {
        public override string ContainerName => "Fornecedor";

        public FornecedorRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
