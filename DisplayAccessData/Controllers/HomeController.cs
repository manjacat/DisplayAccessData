using System.Diagnostics;
using DisplayAccessData.Models;
using DisplayAccessData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DisplayAccessData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<EqpReservation> models = EqpReservationDbContext.GetAll();
            return View(models);
        }

        public IActionResult PLCControl()
        {
            List<PLCControl> models = PLCControlDbContext.GetAll();
            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
