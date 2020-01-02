using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DegirmenciHukuk.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using DH.Entities.Entities;
using DH.Business.Abstracts;

namespace DegirmenciHukuk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailBusiness _mailBusiness;
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IMailBusiness mailBusiness)
        {
            _mailBusiness = mailBusiness;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["ReCaptchaKey"] = _configuration.GetSection("GoogleReCaptcha:key").Value;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Practice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Mail mail)
        {
            // get reCAPTHCA key from appsettings.json
            ViewData["ReCaptchaKey"] = _configuration.GetSection("GoogleReCaptcha:key").Value;

            if (ModelState.IsValid)
            {
                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"], _configuration.GetSection("GoogleReCaptcha:secret").Value, _logger
                    ))
                {
                    ModelState.AddModelError(string.Empty, "CAPTCHA doğrulaması hatalı");
                    return View();
                }

                _mailBusiness.Insert(mail);
                TempData["Success"] = "Emailiniz başarıyla gönderildi.";
                return View();
            }
            else
            {
                TempData["Error"] = "HATA";
                return View(mail);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static bool ReCaptchaPassed(string gRecaptchaResponse, string secret, ILogger logger)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={gRecaptchaResponse}").Result;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                logger.LogError("Error while sending request to ReCaptcha");
                return false;
            }

            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);
            if (JSONdata.success != "true")
            {
                return false;
            }

            return true;
        }
    }
}
