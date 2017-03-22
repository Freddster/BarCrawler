using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proto.DAL;
using proto.Models;

namespace proto.Controllers
{
    public class HomeController : Controller
    {
        private BarCrawlerContext db = new BarCrawlerContext();
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(unitOfWork.BarRepository.GetAllBars());
            //return View(db.BarModels.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

    }
}