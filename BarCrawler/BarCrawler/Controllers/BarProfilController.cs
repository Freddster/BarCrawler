using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using System.Net;

namespace BarCrawler.Controllers
{

    
    public class BarProfilController : Controller
    {

        private BarCrawlerContext db = new BarCrawlerContext();

        // GET: BarProfil
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BarModel barmodel = db.BarModels.Include(i => i.Pictures).Include(e => e.Events).Include(f => f.Feeds).Include(d => d.Drinks).SingleOrDefault(x => x.BarID == id);
            if (barmodel == null)
            {
                return HttpNotFound();
            }
            return View(barmodel); 
        }

        public ActionResult BarLink(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var bar = db.BarModels.FirstOrDefault(b => b.userID == id);
                if (bar == null)
                {
                    return HttpNotFound();
                }
                return View("Index",bar);
            }
        }
    }
}