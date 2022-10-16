using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GSCObras.MedicaoServico.Core.Services;
using GSCObras.MedicaoServico.Functions.Dtos;

namespace GSCObras.MedicaoServico.Functions
{
    public class MedicaoOrdemServicoEncerrar
    {

        private readonly IMedicaoOrdemServicoJanelasService _service;
        private readonly IMapper _mapper;
        public MedicaoOrdemServicoEncerrar(IMapper mapper, IMedicaoOrdemServicoJanelasService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [FunctionName("MedicaoOrdemServicoEncerrar")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var obraId = req.Query["obraId"];
            if (string.IsNullOrEmpty(obraId))
            {
                return new OkObjectResult("Informar uma Obra é obrigatório.") { StatusCode = 400 };
            }

            try
            {
                var medicaoNova = await _service.Encerrar(null);
                var resultado = new MedicaoEncerramentoDto();
                return new OkObjectResult(resultado);
            }
            catch (System.ApplicationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
