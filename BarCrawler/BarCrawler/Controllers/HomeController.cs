using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using BarCrawler.DataAccessLogic.UnitOfWork;

namespace BarCrawler.Controllers
{

    /// <summary>
    /// The <see cref="HomeController"/> is used to show all the barModels on the HomePage and a contact page
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;// = new UnitOfWork();

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public HomeController(BarCrawlerContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }



        /// <summary>
        /// When the homepage is loading all the bars are loaded as well, and returned to the view
        /// </summary>
        /// <returns>View(barModelList)</returns>
        public ActionResult Index()
        {
            List<BarModel> barModelList = (List<BarModel>)_unitOfWork.GetAllBarsForHome();
            return View(barModelList);
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>return View()</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}