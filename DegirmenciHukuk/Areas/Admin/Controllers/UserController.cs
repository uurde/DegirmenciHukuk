using System.Linq;
using System.Security.Claims;
using DH.Business.Abstracts;
using DH.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DegirmenciHukuk.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserBusiness _user;

        public UserController(IUserBusiness user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var user = _user.GetAll();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    int userId = _user.GetByName(name).UserId;
                    user.CreUser = userId;
                    _user.Insert(user);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _user.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                    int userId = _user.GetByName(name).UserId;
                    user.ModUser = userId;
                    _user.Update(user);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return View(user);
        }

        public IActionResult Details(int id)
        {
            var user = _user.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return PartialView("Details", user);
        }
    }
}