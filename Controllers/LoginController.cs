using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler=c.Admins.FirstOrDefault(x=>x.Username==ad.Username && x.Password==ad.Password);
            if (bilgiler!=null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username, false);
                Session["Username"]=bilgiler.Username.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}