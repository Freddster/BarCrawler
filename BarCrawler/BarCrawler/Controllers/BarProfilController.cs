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
using BarCrawler.ViewModels;
using Microsoft.Ajax.Utilities;

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
            BarModel barmodel = db.BarModels.Include(i => i.Pictures).SingleOrDefault(x => x.BarID == id);
            if (barmodel == null)
            {
                return HttpNotFound();
            }
            EditViewModel viewModel = barmodel.Pictures.Count > 0 ? new EditViewModel(barmodel, barmodel.Pictures[0].Directory) : new EditViewModel(barmodel); 
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel editviewmodel)
        {
            if (ModelState.IsValid)
            {
                var bar = db.BarModels.FirstOrDefault(m => m.BarID == editviewmodel.BarID);
                if (bar != null)
                {
                    bar.Address1 = editviewmodel.Address1;
                    bar.Address2 = editviewmodel.Address2;
                    bar.PhoneNumber = editviewmodel.PhoneNumber;
                    bar.Zipcode = editviewmodel.Zipcode;
                    bar.Description = editviewmodel.Description;
                    bar.StreetNumber = editviewmodel.StreetNumber;
                    bar.City = editviewmodel.City;
                    bar.Faculty = editviewmodel.Faculty;
                    db.Entry(bar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return RedirectToAction("Index", new { id = bar.BarID });
            }
            else
            {
                return View(editviewmodel);
            }
        }


        //Virker stadig ikke 
        [HttpGet]
        public ActionResult CreateFeed(int id , string t/**/)
        {
            if (!t.IsNullOrWhiteSpace())
            {
                FeedModel feed = new FeedModel();
                feed.Text = t;
                feed.BarID = id;
                db.FeedModels.Add(feed);
                db.SaveChanges();
            }

            return RedirectToAction("Index", new {id = id});
        }

        [HttpGet]
        public ActionResult DeleteFeed(int id, int Fid/**/)
        {
            var feed = this.db.FeedModels.FirstOrDefault(b => b.FeedID == Fid);
            if (feed != null)
            {
                db.FeedModels.Remove(feed);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = id });
        }
    }
}