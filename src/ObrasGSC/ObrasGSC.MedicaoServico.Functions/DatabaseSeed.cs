using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ObrasGSC.MedicaoServico.Infra.Data.Comum;

namespace ObrasGSC.MedicaoServico.Functions
{
    public class DatabaseSeed
    {

        private readonly ICosmosDbSeed _repositorio;

        public DatabaseSeed(ICosmosDbSeed repositorio)
        {
            _repositorio = repositorio;
        }

        [FunctionName("DatabaseSeed")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {

            await _repositorio.CarregarDatabase();

            return new OkResult();
        }
    }
}
