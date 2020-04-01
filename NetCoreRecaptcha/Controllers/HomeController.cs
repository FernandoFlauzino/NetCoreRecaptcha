using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreRecaptcha.Application.Interface;
using NetCoreRecaptcha.Application.Request;
using NetCoreRecaptcha.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NetCoreRecaptcha.Controllers
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendRecaptcha(
            [FromForm(Name = "g-recaptcha-response")] string token
           ,[FromServices] IGoogleRecaptchaService googleRecaptchaService)
        {
            var request = new GoogleRecaptchaRequest
            {
                Token = token
            };
            var result = await googleRecaptchaService.ValidateReCaptcha(request);

            if(result.ValidToken)
                return View("Index");

            return Error();
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
