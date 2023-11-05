using Microsoft.AspNetCore.Mvc;
using MvcWebAppTwo.Services;
using MvcWebAppTwo.Models;

namespace MvcWebAppTwo.Controllers
{
    public class TransientScopedController : Controller
    {
        private readonly ILogger<TransientScopedController> _logger;
        private IMobileService _mobileService;
        public TransientScopedController(ILogger<TransientScopedController> logger, IMobileService mobileService)
        {
            _logger = logger;
            _mobileService = mobileService;
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                Mobile newMobile = _mobileService.Add(mobile);
            }

            return View();
        }
    }
}
