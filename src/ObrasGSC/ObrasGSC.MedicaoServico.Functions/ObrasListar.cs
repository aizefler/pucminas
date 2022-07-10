using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using GSCObras.MedicaoServico.Core.Repositorios;
using AutoMapper;
using GSCObras.MedicaoServico.Functions.Dtos;
using System.Collections.Generic;

namespace GSCObras.MedicaoServico.Functions
{
    public class ObrasListar
    {

        private readonly IObraRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ObrasListar(IMapper mapper, IObraRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }


        [FunctionName("ObrasListar")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var resultado = await _repositorio.ListarAsync();
            return new OkObjectResult(_mapper.Map<List<ObrasDto>>(resultado));
        }
    }
}
