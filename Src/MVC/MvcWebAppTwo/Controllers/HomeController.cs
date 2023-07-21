using Microsoft.AspNetCore.Mvc;
using MvcWebAppTwo.Models;
using MvcWebAppTwo.SingleInterfaceMultiInstances;
using System.Diagnostics;

namespace MvcWebAppTwo.Controllers
{
    public class HomeController : Controller
    {
private readonly IEnumerable<IDatabaseService> _databaseServices;

public HomeController(IEnumerable<IDatabaseService> databaseServices)
{
    _databaseServices = databaseServices;
}

        public IActionResult Index()
        {
            var services = _databaseServices.FirstOrDefault(x => x.GetType() == typeof(SqlService));
            if (services != null)
            {
                ViewBag.Name = services.GetName();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            var services = _databaseServices.FirstOrDefault(x => x.GetType() == typeof(MongoService));
            if (services != null)
            {
                ViewBag.Name = services.GetName();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}