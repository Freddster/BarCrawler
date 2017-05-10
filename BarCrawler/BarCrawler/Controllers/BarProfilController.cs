using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BarCrawler.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarModel barModel = db.BarModels.Find(id);
            if (barModel == null)
            {
                return HttpNotFound();
            }
            return View(barModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarID,TimeStamp,BarName,Description,Email,Faculty,PhoneNumber,Address1,Address2,StreetNumber,City,Zipcode,Longitude,Latitude")] BarModel barModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barModel);
        }
    }
}