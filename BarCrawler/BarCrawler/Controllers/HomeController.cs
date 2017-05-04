using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using DataAccessLogic.UnitOfWork;

namespace BarCrawler.Controllers
{
    public class HomeController : Controller
    {
        //private BarCrawlerContext db = new BarCrawlerContext();
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(_unitOfWork.GetAllBarprofile());
            //return View(db.BarModels.Include(b => b.Pictures).ToList());
            return View(db.BarModels.Include(b => b.Pictures).Include(k => k.Events).ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}