using mwvlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mwvlog.Controllers
{
    public class HomeController : Controller
    {

        VlogDb _db = new VlogDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Blog()
        {
            var model = _db.MoviePosts.OrderByDescending(p => p.Id).ToList();
            return View(model);
        }

        [Authorize(Users = "micaiahwallace")]
        public ActionResult Delete(int postid)
        {
            MoviePost post = _db.MoviePosts.Find(postid);
            _db.Entry(post).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();
            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/videos"), postid + ".mp4"))) {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/videos"), postid + ".mp4"));
            }
            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/videos"), postid + ".ogv"))) {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/videos"), postid + ".ogv"));
            }
            if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/videos"), postid + ".webm"))) {
                System.IO.File.Delete(Path.Combine(Server.MapPath("~/videos"), postid + ".webm"));
            }

            return RedirectToAction("Blog", "Home");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}