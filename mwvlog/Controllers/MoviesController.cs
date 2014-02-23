using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using mwvlog.Models;

namespace mwvlog.Controllers
{
    public class MoviesController : Controller
    {

        VlogDb _db = new VlogDb();

        public ActionResult Index()
        {
            var model = _db.MoviePosts.OrderByDescending(p=>p.Id).ToList();
            return View(model);
        }

        [HttpGet]
        [Authorize(Users="micaiahwallace")]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Users = "micaiahwallace")]
        public ActionResult Upload(HttpPostedFileBase file) 
        {
            if (file != null && file.ContentLength > 0)
            {
                var title = Request.Form["title"];
                var body = Request.Form["body"];

                MoviePost post = new MoviePost();
                post.Title = title;
                post.Body = body;

                _db.MoviePosts.Add(post);
                _db.SaveChanges();

                var id = _db.Entry(post).Entity.Id;

                var FileExtension = Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/videos"), id+FileExtension);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
	}
}