using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;

namespace BarCrawler.Controllers
{
    public class BarProfilController : Controller
    {
        private BarCrawlerContext db = new BarCrawlerContext();

        // GET: BarProfil
        public ActionResult Index(int? id)
        {
            return View();
        }
    }
}