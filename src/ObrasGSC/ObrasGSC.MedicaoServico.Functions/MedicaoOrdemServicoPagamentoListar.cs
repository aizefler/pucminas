using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ObrasGSC.MedicaoServico.Core.Repositorios;
using AutoMapper;
using ObrasGSC.MedicaoServico.Functions.Dtos;
using System.Collections.Generic;

namespace ObrasGSC.MedicaoServico.Functions
{
    public class MedicaoOrdemServicoPagamentoListar
    {

        private readonly IMedicaoOrdemServicoPagamentoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public MedicaoOrdemServicoPagamentoListar(IMapper mapper, IMedicaoOrdemServicoPagamentoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [FunctionName("MedicaoOrdemServicoPagamentoListar")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var obraId = req.Query["obraId"];
            if (string.IsNullOrEmpty(obraId))
            {
                return new OkObjectResult("Informar uma Obra é obrigatório.") { StatusCode = 400 };
            }

            var resultado = await _repositorio.ListarAsync(obraId);

            return new OkObjectResult(_mapper.Map<List<MedicaoPagamentoDto>>(resultado));
        }
    }
}
