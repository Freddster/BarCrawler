using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proto.Models;

namespace proto.Controllers
{
    public class BarModelsController : Controller
    {
        private protoContext db = new protoContext();

        // GET: BarModels
        public ActionResult Index()
        {
            return View(db.BarModels.ToList());
        }

        // GET: BarModels/Details/5
        public ActionResult Details(int? id)
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

        // GET: BarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BarModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file,[Bind(Include = "ID,Name,Description,Adresse,TelefonNr,Email,Fakultet,ImageDir")] BarModel barModel)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images"), file.FileName));
                    barModel.ImageDir = System.IO.Path.Combine("~/Images",file.FileName);
                }
                db.BarModels.Add(barModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barModel);
        }

        // GET: BarModels/Edit/5
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

        // POST: BarModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Adresse,TelefonNr,Email,Fakultet,ImageDir")] BarModel barModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barModel);
        }

        // GET: BarModels/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: BarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarModel barModel = db.BarModels.Find(id);
            db.BarModels.Remove(barModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
