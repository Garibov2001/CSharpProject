using CinemaApplication1.Entities;
using CinemaApplication1.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CinemaApplication1.Controllers
{
    public class AccountController : Controller
    {
        private CinemaContext _context = new CinemaContext();

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["authenticated"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email);

            if (user != null)
            {
                if (Crypto.VerifyHashedPassword(user.Password, model.Password))
                {
                    Session["authenticated"] = true;
                    return RedirectToAction("Index", "Home");
                }
            }

            
            ViewBag.Error = "Daxil etdiyiniz email ve ya sifre yalnisdir";
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (Session["authenticated"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("authenticated");
            return RedirectToAction("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            // Release the db resources
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}