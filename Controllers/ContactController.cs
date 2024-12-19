using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context c=new Context();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                c.Contacts.Add(contact);
                c.SaveChanges();
                TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
                return RedirectToAction("Index");
            }

            return View(contact); 
        }

    }
}