using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBlog(int id)
        {
            var value = c.Blogs.Find(id);
            return View("GetBlog",value);          
        }

        public ActionResult UpdateBlog(Blog b)
        {
            var value = c.Blogs.Find(b.ID);
            value.Description = b.Description;
            value.Title = b.Title;
            value.BlogImage = b.BlogImage;
            value.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentList()
        {
            var value = c.Comments.ToList();
            return View(value);
        }
        public ActionResult DeleteComment(int id)
        {
            var value = c.Comments.Find(id);
            c.Comments.Remove(value);
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }

        public ActionResult GetComment(int id)
        {
            var value = c.Comments.Find(id);
            return View("GetComment", value);
        }

        public ActionResult UpdateComment(Comment cmt)
        {
            var value=c.Comments.Find(cmt.ID);
            value.Commentt = cmt.Commentt; 
            value.Username = cmt.Username;
            value.Mail= cmt.Mail;
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }


    }
}