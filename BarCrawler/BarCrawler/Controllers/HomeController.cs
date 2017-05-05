using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;

namespace BarCrawler.Controllers
{
    public class HomeController : Controller
    {
        private BarCrawlerContext db = new BarCrawlerContext();

        public ActionResult Index()
        {
            return View(db.BarModels.Include(b => b.Pictures).Include(k => k.Events).Include(f => f.Feeds).ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}