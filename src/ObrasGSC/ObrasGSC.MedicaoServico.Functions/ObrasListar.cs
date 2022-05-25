using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GSCObras.MedicaoServico.Core.Repositorios;

namespace GSCObras.MedicaoServico.Functions
{
    // https://levelup.gitconnected.com/event-driven-programming-in-c-9264efb06c01

    public class ObrasListar
    {

        private readonly IObraRepositorio _repositorio;

        public ObrasListar(IObraRepositorio repositorio)
        {
            _repositorio = repositorio;
        }


        [FunctionName("ObrasListar")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {

            var resultado = await _repositorio.ListarAsync();

            return new OkObjectResult(resultado);
        }
    }
}
