using mwvlog.Models;
using System;
using System.Collections.Generic;
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

        public ActionResult Contact()
        {
            return View();
        }
    }
}