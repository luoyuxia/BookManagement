using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Boya.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username,
                    DateTime.Now, DateTime.Now.AddMinutes(30), true, "123", FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Management()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}