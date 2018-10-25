using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post3_GoogleReCaptchaV2.Models;
using Post3_GoogleReCaptchaV2.Services;

namespace Post3_GoogleReCaptchaV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecaptchaService _recaptcha;

        public HomeController(IRecaptchaService recaptcha)
        {
            _recaptcha = recaptcha;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var captchaResponse = await _recaptcha.Validate(Request.Form);
                if (!captchaResponse.Success)
                {
                    ModelState.AddModelError("reCaptchaError", "reCAPTCHA error occured. Please try again.");
                    return View(model);
                }

                // TODO: save data

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
