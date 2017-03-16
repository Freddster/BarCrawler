using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proto.Models;

namespace proto.Controllers
{
    public class HomeController : Controller
    {
        private protoContext db = new protoContext();

        public ActionResult Index()
        {
            return View(db.BarModels.ToList());
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