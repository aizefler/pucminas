using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GSCObras.MedicaoServico.Core.Services;
using GSCObras.MedicaoServico.Functions.Dtos;
using GSCObras.MedicaoServico.Core.Repositorios;

namespace GSCObras.MedicaoServico.Functions
{
    public class MedicaoOrdemServicoEncerrar
    {

        private readonly IMedicaoOrdemServicoJanelasService _service;
        private readonly IMapper _mapper;

        public MedicaoOrdemServicoEncerrar(IMapper mapper, IMedicaoOrdemServicoJanelasService service,
            IMedicaoOrdemServicoRepositorio repositorio)
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

            log.LogInformation(obraId);

            if (string.IsNullOrEmpty(obraId))
            {
                return new OkObjectResult("Informar uma Obra � obrigat�rio.") { StatusCode = 400 };
            }

            try
            {
                var medicaoNova = await _service.Encerrar(obraId);
                return new OkObjectResult(medicaoNova);
            }
            catch (System.ApplicationException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
