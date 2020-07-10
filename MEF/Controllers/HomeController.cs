using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MEF.Models;
using MEFApp.Interfaces;
using MEFApp.ViewModels;

namespace MEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountantService _accountantService;

        public HomeController(ILogger<HomeController> logger, IAccountantService accountantService)
        {
            _accountantService = accountantService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel()
            {
                VAT = _accountantService.CalcVat(100)
            };
            
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
