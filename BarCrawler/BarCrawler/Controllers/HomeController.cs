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
        BarCrawlerContext db; // = new BarCrawlerContext();
        private readonly UnitOfWork _unitOfWork;// = new UnitOfWork();
        private UnitOfWork uow;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public HomeController(BarCrawlerContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public HomeController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }

        public ActionResult Index()
        {
            List<BarModel> barModelList = (List<BarModel>)_unitOfWork.GetAllBarsForHome();
            return View(barModelList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}