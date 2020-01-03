using System.Linq;
using System.Security.Claims;
using DH.Business.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DegirmenciHukuk.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MailController : Controller
    {
        private readonly IMailBusiness _mail;

        public MailController(IMailBusiness mail)
        {
            _mail = mail;
        }

        public IActionResult Index()
        {
            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var mail = _mail.GetAll();
            return View(mail);
        }

        public IActionResult Details(int id)
        {
            var mail = _mail.Get(id);
            if (mail == null)
            {
                return NotFound();
            }
            return PartialView("Details", mail);
        }
    }
}