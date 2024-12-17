using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;


namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c=  new Context();
        BlogComment bc = new BlogComment();

        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            bc.Deger1 = c.Blogs.ToList();
            bc.Deger3=c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            bc.Deger4=c.Comments.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(bc);
        }

        public ActionResult BlogDetay(int id)
        {
           // var blogBul = c.Blogs.Where(x => x.ID == id).ToList();
            bc.Deger1= c.Blogs.Where(x => x.ID == id).ToList();
            bc.Deger2=c.Comments.Where(x=>x.BlogId == id).ToList();
            return View(bc);
        }
        [HttpGet]
        public PartialViewResult DoComment(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult DoComment(Comment cm)
        {
            c.Comments.Add(cm);
            c.SaveChanges();
            return PartialView();
        }
        
    }
}