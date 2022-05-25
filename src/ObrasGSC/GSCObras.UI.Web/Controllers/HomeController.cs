using GSCObras.Data.Services;
using GSCObras.Data.Services.Dtos;
using GSCObras.UI.Web.Models;
using GSCObras.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var result = await _apimGSCObras.MedicaoPagamentoListarAsync("AA01");
            ViewBag.DataSource = result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}