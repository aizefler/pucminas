using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;
using GSCObras.MedicaoServico.Infra.Data.Comum;

namespace GSCObras.MedicaoServico.Infra.Data
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>, IFornecedorRepositorio
    {
        public override string ContainerName => "Fornecedor";

        public FornecedorRepositorio(ICosmosDbContainerFactory factory) : base(factory)
        { }

    }
}
