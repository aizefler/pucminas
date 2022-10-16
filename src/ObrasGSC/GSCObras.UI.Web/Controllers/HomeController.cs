using GSCObras.Data.Services;
using GSCObras.Data.Services.Dtos;
using GSCObras.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using System.Text.Json;

namespace GSCObras.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApimGSCObras _apimGSCObras;

        public HomeController(ILogger<HomeController> logger, IApimGSCObras apimGSCObras)
        {
            _logger = logger;
            _apimGSCObras = apimGSCObras;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogDebug("Carregando página de pagamentos");

            var obras = await CarregarObras();
            ViewBag.DataSourceObras = obras;
            ViewBag.ObraSelected = obras[0].Id;

            var pagamentos = await CarregarPagamentos(ViewBag.ObraSelected);
            ViewBag.DataSourcePagamentos = JsonConvert.SerializeObject(pagamentos, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> MedicaoEncerrar()
        {
            _logger.LogDebug("Carregando página de testes de encerramento de medição");
            await _apimGSCObras.MedicaoServicoEncerrarAsync("AA01");
            return View();
        }

        public async Task<List<ObrasDto>> CarregarObras()
        {
            _logger.LogDebug("Carregando a lista de obras");

            var obras = await _apimGSCObras.ObrasListarAsync();
            return obras;
        }

        public async Task<List<MedicaoPagamentoDto>> CarregarPagamentos([FromQuery] string obraId)
        {
            _logger.LogDebug("Carregando a lista de pagamentos");

            var pagamentos = await _apimGSCObras.MedicaoPagamentoListarAsync(obraId);
            return pagamentos;
        }

    }
}