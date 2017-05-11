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
        BarCrawlerContext db = new BarCrawlerContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(db.BarModels
                .Include(pp => pp.ProfilPictureModel)
                .Include(p => p.Pictures)
                .Include(e => e.Events)
                .Include(f => f.Feeds)
                .ToList());
            return View(_unitOfWork.GetAllBarsForHome());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}