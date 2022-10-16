using GSCObras.MedicaoServico.Core.Entidades;
using GSCObras.MedicaoServico.Core.Repositorios;

namespace GSCObras.MedicaoServico.Infra.Data.Comum
{
    public class CosmosDbSeed : ICosmosDbSeed
    {
        private readonly IObraRepositorio _obraRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IServicoRepositorio _servicoRepositorio;
        private readonly IObraEAPRepositorio _obraEAPRepositorio;
        private readonly IOrdemServicoRepositorio _ordemServicoRepositorio;
        private readonly IMedicaoOrdemServicoPagamentoRepositorio _medicaoOrdemServicoPagamentoRepositorio;
        private readonly IMedicaoOrdemServicoRepositorio _medicaoOrdemServicoRepositorio;

        private List<Obra> _obras;
        private List<Fornecedor> _fornecedores;
        private List<Servico> _servicos;
        private List<ObraEAP> _obrasEAP;
        private List<OrdemServico> _ordensServico;
        private List<MedicaoOrdemServicoPagamento> _medicaoOrdemServicoPagamento;
        private List<MedicaoOrdemServico> _medicaoOrdemServico;

        public CosmosDbSeed(IObraRepositorio obraRepositorio,
                            IFornecedorRepositorio fornecedorRepositorio,
                            IServicoRepositorio servicoRepositorio,
                            IObraEAPRepositorio obraEAPRepositorio, 
                            IOrdemServicoRepositorio ordemServicoRepositorio,
                            IMedicaoOrdemServicoPagamentoRepositorio medicaoOrdemServicoPagamentoRepositorio,
                            IMedicaoOrdemServicoRepositorio medicaoOrdemServicoRepositorio)
        {
            _obras = new List<Obra>();
            _fornecedores = new List<Fornecedor>();
            _servicos = new List<Servico>();
            _obrasEAP = new List<ObraEAP>();
            _ordensServico = new List<OrdemServico>();
            _medicaoOrdemServicoPagamento = new List<MedicaoOrdemServicoPagamento>();
            _medicaoOrdemServico = new List<MedicaoOrdemServico>();

            _obraRepositorio = obraRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
            _servicoRepositorio = servicoRepositorio;
            _obraEAPRepositorio = obraEAPRepositorio;
            _ordemServicoRepositorio = ordemServicoRepositorio;
            _medicaoOrdemServicoPagamentoRepositorio = medicaoOrdemServicoPagamentoRepositorio;
            _medicaoOrdemServicoRepositorio = medicaoOrdemServicoRepositorio;
        }

        private async Task CarregarObras()
        { 
            _obras.Add(new Obra() { 
                Id = "AA01",
                Descricao = "Residencial Golden Class"
            });
            _obras.Add(new Obra()
            {
                Id = "AA02",
                Descricao = "Residencial Golden Flage"
            });

            if (!await _obraRepositorio.ExisteAsync(_obras[0].Id))
                await _obraRepositorio.AdicionarAsync(_obras[0]);

            if (!await _obraRepositorio.ExisteAsync(_obras[1].Id))
                await _obraRepositorio.AdicionarAsync(_obras[1]);
        }

        private async Task CarregarObrasEAP()
        {
            _obrasEAP.Add(new ObraEAP()
            {
                Id = "1.1.1",
                Etapa = "Etapa XPTO",
                Obra = _obras[0],
                Unidade = "001",
                DataFimPrevisto = DateTime.Now.AddDays(7),
                DataInicioPrevisto = DateTime.Now.AddDays(-3)
                
            });
            _obrasEAP.Add(new ObraEAP()
            {
                Id = "1.1.2",
                Etapa = "Etapa XPTO",
                Obra = _obras[0],
                Unidade = "001",
                DataFimPrevisto = DateTime.Now.AddDays(7),
                DataInicioPrevisto = DateTime.Now.AddDays(-3)

            });
            _obrasEAP.Add(new ObraEAP()
            {
                Id = "1.1.3",
                Etapa = "Etapa XPTO",
                Obra = _obras[0],
                Unidade = "001",
                DataFimPrevisto = DateTime.Now.AddDays(7),
                DataInicioPrevisto = DateTime.Now.AddDays(-3)

            });
            _obrasEAP.Add(new ObraEAP()
            {
                Id = "1.1.4",
                Etapa = "Etapa XPTO",
                Obra = _obras[0],
                Unidade = "001",
                DataFimPrevisto = DateTime.Now.AddDays(7),
                DataInicioPrevisto = DateTime.Now.AddDays(-3)

            });

            if (!await _obraEAPRepositorio.ExisteAsync(_obrasEAP[0].Id))
                await _obraEAPRepositorio.AdicionarAsync(_obrasEAP[0]);

            if (!await _obraEAPRepositorio.ExisteAsync(_obrasEAP[1].Id))
                await _obraEAPRepositorio.AdicionarAsync(_obrasEAP[1]);

            if (!await _obraEAPRepositorio.ExisteAsync(_obrasEAP[2].Id))
                await _obraEAPRepositorio.AdicionarAsync(_obrasEAP[2]);

            if (!await _obraEAPRepositorio.ExisteAsync(_obrasEAP[3].Id))
                await _obraEAPRepositorio.AdicionarAsync(_obrasEAP[3]);
        }


        private async Task CarregarFornecedores()
        {
            _fornecedores.Add(new Fornecedor()
            {
                Id = "1010101",
                Descricao = "Fornecedor 01",
                CNPJ = "09.986.976/0001-76"
            });
            _fornecedores.Add(new Fornecedor()
            {
                Id = "1010102",
                Descricao = "Fornecedor 02",
                CNPJ = "10.986.976/0001-84"
            });

            if (!await _fornecedorRepositorio.ExisteAsync(_fornecedores[0].Id))
                await _fornecedorRepositorio.AdicionarAsync(_fornecedores[0]);

            if (!await _fornecedorRepositorio.ExisteAsync(_fornecedores[1].Id))
                await _fornecedorRepositorio.AdicionarAsync(_fornecedores[1]);
        }

        private async Task CarregarServicos()
        {
            _servicos.Add(new Servico()
            {
                Id = "100100",
                Descricao = "Servico 001",
                Quantidade = 1000,
                Valor = 56.9m
            });
            _servicos.Add(new Servico()
            {
                Id = "100200",
                Descricao = "Servico 002",
                Quantidade = 500,
                Valor = 1056.5m
            });
            _servicos.Add(new Servico()
            {
                Id = "100300",
                Descricao = "Servico 003",
                Quantidade = 2000,
                Valor = 156.5m
            });
            _servicos.Add(new Servico()
            {
                Id = "100400",
                Descricao = "Servico 004",
                Quantidade = 5000,
                Valor = 1000.0m
            });

            if (!await _servicoRepositorio.ExisteAsync(_servicos[0].Id))
                await _servicoRepositorio.AdicionarAsync(_servicos[0]);

            if (!await _servicoRepositorio.ExisteAsync(_servicos[1].Id))
                await _servicoRepositorio.AdicionarAsync(_servicos[1]);

            if (!await _servicoRepositorio.ExisteAsync(_servicos[2].Id))
                await _servicoRepositorio.AdicionarAsync(_servicos[2]);

            if (!await _servicoRepositorio.ExisteAsync(_servicos[3].Id))
                await _servicoRepositorio.AdicionarAsync(_servicos[3]);
        }

        private async Task CarregarOrdensServico()
        {
            _ordensServico.Add(new OrdemServico()
            {
                Id = "1010101",
                EAP = _obrasEAP[0],
                Obra = _obras[0],
                Fornecedor = _fornecedores[0],
                Progresso = 0,
                Servico = _servicos[0],
                Situacao = OrdemServicoSituacao.Aberta
            });
            _ordensServico.Add(new OrdemServico()
            {
                Id = "1010102",
                EAP = _obrasEAP[0],
                Obra = _obras[0],
                Fornecedor = _fornecedores[0],
                Progresso = 0,
                Servico = _servicos[1],
                Situacao = OrdemServicoSituacao.Aberta
            });
            _ordensServico.Add(new OrdemServico()
            {
                Id = "1010103",
                EAP = _obrasEAP[1],
                Obra = _obras[0],
                Fornecedor = _fornecedores[0],
                Progresso = 0,
                Servico = _servicos[2],
                Situacao = OrdemServicoSituacao.Aberta
            });
            _ordensServico.Add(new OrdemServico()
            {
                Id = "1010104",
                EAP = _obrasEAP[1],
                Obra = _obras[0],
                Fornecedor = _fornecedores[0],
                Progresso = 0,
                Servico = _servicos[3],
                Situacao = OrdemServicoSituacao.Aberta
            });

            if (!await _ordemServicoRepositorio.ExisteAsync(_ordensServico[0].Id))
                await _ordemServicoRepositorio.AdicionarAsync(_ordensServico[0]);

            if (!await _ordemServicoRepositorio.ExisteAsync(_ordensServico[1].Id))
                await _ordemServicoRepositorio.AdicionarAsync(_ordensServico[1]);

            if (!await _ordemServicoRepositorio.ExisteAsync(_ordensServico[2].Id))
                await _ordemServicoRepositorio.AdicionarAsync(_ordensServico[2]);

            if (!await _ordemServicoRepositorio.ExisteAsync(_ordensServico[3].Id))
                await _ordemServicoRepositorio.AdicionarAsync(_ordensServico[3]);
        }

        private async Task CarregarPagamentos()
        {
            _medicaoOrdemServicoPagamento.Add(new MedicaoOrdemServicoPagamento()
            {
                Id = Guid.NewGuid().ToString(),
                Janela = "03/2022",
                Fornecedor = _fornecedores[0],
                Situacao =  PagamentoSituacao.Pago,
                ObraId = _obras[0].Id,
                Valor = 5680.0m
            });

            _medicaoOrdemServicoPagamento.Add(new MedicaoOrdemServicoPagamento()
            {
                Id = Guid.NewGuid().ToString(),
                Janela = "04/2022",
                Fornecedor = _fornecedores[0],
                Situacao = PagamentoSituacao.Pago,
                ObraId = _obras[0].Id,
                Valor = 1780.0m
            });

            _medicaoOrdemServicoPagamento.Add(new MedicaoOrdemServicoPagamento()
            {
                Id = Guid.NewGuid().ToString(),
                Janela = "03/2022",
                Fornecedor = _fornecedores[1],
                Situacao = PagamentoSituacao.Pago,
                ObraId = _obras[0].Id,
                Valor = 2780.0m
            });

            _medicaoOrdemServicoPagamento.Add(new MedicaoOrdemServicoPagamento()
            {
                Id = Guid.NewGuid().ToString(),
                Janela = "03/2022",
                Fornecedor = _fornecedores[1],
                Situacao = PagamentoSituacao.Pago,
                ObraId = _obras[0].Id,
                Valor = 1680.0m
            });

                await _medicaoOrdemServicoPagamentoRepositorio.AdicionarAsync(_medicaoOrdemServicoPagamento[0]);
                await _medicaoOrdemServicoPagamentoRepositorio.AdicionarAsync(_medicaoOrdemServicoPagamento[1]);
                await _medicaoOrdemServicoPagamentoRepositorio.AdicionarAsync(_medicaoOrdemServicoPagamento[2]);
                await _medicaoOrdemServicoPagamentoRepositorio.AdicionarAsync(_medicaoOrdemServicoPagamento[3]);
        }


        private async Task CarregarMedicaoServico()
        {
            var medicao1 = new MedicaoOrdemServico()
            {
                Id = Guid.NewGuid().ToString(),
                Obra = new Obra()
                {
                    Id = "AA01",
                    Descricao = "Residencial Golden Class"
                },
                Janela = "03/2022"
            };
            medicao1.AbrirJanela();
            await _medicaoOrdemServicoRepositorio.AdicionarAsync(medicao1);
        }

            public async Task CarregarDatabase()
        {
            //await CarregarObras();
            //await CarregarServicos();
            //await CarregarFornecedores();
            //await CarregarObrasEAP();
            //await CarregarOrdensServico();
            //await CarregarPagamentos();
            //await CarregarMedicaoServico();
        }
    }
}
